using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXchuyenkho.
	/// </summary>
	public class frmTrungthau : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private MaskedBox.MaskedBox ngaysp;
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
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string user,s_ngay,sql,s_ngaysp,format_soluong,format_dongia,format_sotien;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_madv;
		private decimal l_id,l_idct;
		private decimal d_soluong,d_soluongcu,d_dongia,d_sotien;
        private bool bNew, bEdit = true, bAdmin, bLockytu, bMaso_ten;
		private AccessData d;
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataSet dsxoa=new DataSet();
        private DataTable dtdmnx = new DataTable();
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
        private MaskedTextBox.MaskedTextBox sophieu;
        private System.Windows.Forms.DataGrid dataGrid1;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.TextBox find;
		private MaskedBox.MaskedBox donvi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedBox.MaskedBox tenhang;
        private MaskedBox.MaskedBox tennuoc;
        private Label label6;
        private TextBox tendv;
        private TextBox madv;
        private Label label7;
        private MaskedBox.MaskedBox tu;
        private Label label8;
        private MaskedBox.MaskedBox den;
        private Label label9;
        private TextBox ghichu;
        private LibList.List listNX;
        private Label label10;
        private Label label11;
        private MaskedBox.MaskedBox sodk;
        private TextBox nguyenlieu;
        private ComboBox cl_nguyenlieu;
        private ComboBox chatluong;
        private Label label12;
        private MaskedTextBox.MaskedTextBox dongia;
        private Label label14;
        private MaskedTextBox.MaskedTextBox sotien;
        private CheckBox chkXml;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTrungthau(AccessData acc,string ngay,int nhom,int userid,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; i_nhom = nhom; i_userid = userid; s_ngay = ngay; bAdmin = admin;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrungthau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
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
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.find = new System.Windows.Forms.TextBox();
            this.donvi = new MaskedBox.MaskedBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tenhang = new MaskedBox.MaskedBox();
            this.tennuoc = new MaskedBox.MaskedBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tendv = new System.Windows.Forms.TextBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tu = new MaskedBox.MaskedBox();
            this.label8 = new System.Windows.Forms.Label();
            this.den = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.listNX = new LibList.List();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.sodk = new MaskedBox.MaskedBox();
            this.nguyenlieu = new System.Windows.Forms.TextBox();
            this.cl_nguyenlieu = new System.Windows.Forms.ComboBox();
            this.chatluong = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quyết định số :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(222, 4);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 551);
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
            this.label13.Location = new System.Drawing.Point(21, 426);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(136, 426);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(64, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Biệt dược :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ldvt.Location = new System.Drawing.Point(627, 471);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(44, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(142, 494);
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
            this.tenbd.Location = new System.Drawing.Point(197, 426);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(243, 21);
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
            this.mabd.Location = new System.Drawing.Point(50, 426);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(80, 21);
            this.mabd.TabIndex = 8;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(673, 471);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(110, 21);
            this.dang.TabIndex = 18;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(197, 494);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(243, 21);
            this.soluong.TabIndex = 20;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(50, 521);
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
            this.butSua.Location = new System.Drawing.Point(120, 521);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 25;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(190, 521);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 26;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(260, 521);
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
            this.butXoa.Location = new System.Drawing.Point(330, 521);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 23;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(400, 521);
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
            this.butHuy.Location = new System.Drawing.Point(470, 521);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 28;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(540, 521);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 29;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(610, 521);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 30;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(78, 3);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(110, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(497, 426);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(286, 21);
            this.tenhc.TabIndex = 10;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(426, 425);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(73, 23);
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
            this.sophieu.Location = new System.Drawing.Point(78, 3);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 10;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(110, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 31);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(781, 392);
            this.dataGrid1.TabIndex = 27;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // find
            // 
            this.find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(706, 4);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(83, 21);
            this.find.TabIndex = 105;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // donvi
            // 
            this.donvi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.donvi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donvi.Enabled = false;
            this.donvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donvi.Location = new System.Drawing.Point(497, 471);
            this.donvi.Mask = "";
            this.donvi.MaxLength = 20;
            this.donvi.Name = "donvi";
            this.donvi.Size = new System.Drawing.Size(139, 21);
            this.donvi.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(443, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 107;
            this.label3.Text = "Đóng gói :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(12, 469);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 108;
            this.label4.Text = "Hãng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(160, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 109;
            this.label5.Text = "Nước :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhang
            // 
            this.tenhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhang.Enabled = false;
            this.tenhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhang.Location = new System.Drawing.Point(50, 471);
            this.tenhang.Mask = "";
            this.tenhang.MaxLength = 10;
            this.tenhang.Name = "tenhang";
            this.tenhang.Size = new System.Drawing.Size(80, 21);
            this.tenhang.TabIndex = 14;
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(197, 471);
            this.tennuoc.Mask = "";
            this.tennuoc.MaxLength = 10;
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(120, 21);
            this.tennuoc.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(282, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 23);
            this.label6.TabIndex = 113;
            this.label6.Text = "Tên nhà thầu :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tendv
            // 
            this.tendv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Enabled = false;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(429, 4);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(275, 21);
            this.tendv.TabIndex = 4;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // madv
            // 
            this.madv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Enabled = false;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(364, 4);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(64, 21);
            this.madv.TabIndex = 3;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-3, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 23);
            this.label7.TabIndex = 116;
            this.label7.Text = "Hiệu lực từ  :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tu.Enabled = false;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(78, 26);
            this.tu.Mask = "##/##/####";
            this.tu.MaxLength = 10;
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 5;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(142, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 23);
            this.label8.TabIndex = 118;
            this.label8.Text = "Hiệu lực từ  :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.BackColor = System.Drawing.SystemColors.HighlightText;
            this.den.Enabled = false;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(222, 26);
            this.den.Mask = "##/##/####";
            this.den.MaxLength = 10;
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 6;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(289, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 23);
            this.label9.TabIndex = 120;
            this.label9.Text = "Ghi chú :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(364, 27);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(425, 21);
            this.ghichu.TabIndex = 7;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(457, 551);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 122;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            this.listNX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listNX_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(127, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 23);
            this.label10.TabIndex = 123;
            this.label10.Text = "Nguyên liệu :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(-3, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 124;
            this.label11.Text = "Số ĐK :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sodk
            // 
            this.sodk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sodk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sodk.Enabled = false;
            this.sodk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sodk.Location = new System.Drawing.Point(50, 449);
            this.sodk.Mask = "";
            this.sodk.MaxLength = 10;
            this.sodk.Name = "sodk";
            this.sodk.Size = new System.Drawing.Size(80, 21);
            this.sodk.TabIndex = 11;
            // 
            // nguyenlieu
            // 
            this.nguyenlieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguyenlieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguyenlieu.Enabled = false;
            this.nguyenlieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguyenlieu.Location = new System.Drawing.Point(197, 449);
            this.nguyenlieu.Name = "nguyenlieu";
            this.nguyenlieu.Size = new System.Drawing.Size(474, 21);
            this.nguyenlieu.TabIndex = 12;
            this.nguyenlieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // cl_nguyenlieu
            // 
            this.cl_nguyenlieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cl_nguyenlieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cl_nguyenlieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cl_nguyenlieu.Enabled = false;
            this.cl_nguyenlieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cl_nguyenlieu.Location = new System.Drawing.Point(673, 449);
            this.cl_nguyenlieu.Name = "cl_nguyenlieu";
            this.cl_nguyenlieu.Size = new System.Drawing.Size(110, 21);
            this.cl_nguyenlieu.TabIndex = 13;
            this.cl_nguyenlieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // chatluong
            // 
            this.chatluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chatluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chatluong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chatluong.Enabled = false;
            this.chatluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatluong.Location = new System.Drawing.Point(318, 471);
            this.chatluong.Name = "chatluong";
            this.chatluong.Size = new System.Drawing.Size(122, 21);
            this.chatluong.TabIndex = 16;
            this.chatluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(-4, 492);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 23);
            this.label12.TabIndex = 129;
            this.label12.Text = "Đơn giá :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(50, 494);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(80, 21);
            this.dongia.TabIndex = 19;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.Validated += new System.EventHandler(this.dongia_Validated);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(443, 492);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 131;
            this.label14.Text = "Số tiền :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(497, 494);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(286, 21);
            this.sotien.TabIndex = 21;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(698, 521);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 132;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // frmTrungthau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chatluong);
            this.Controls.Add(this.cl_nguyenlieu);
            this.Controls.Add(this.nguyenlieu);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.sodk);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.tenhang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.donvi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.find);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
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
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrungthau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục trúng thầu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTrungthau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTrungthau_Load(object sender, System.EventArgs e)
		{
            user = d.user; 
			bMaso_ten=d.bMaso_ten(i_nhom);
			bLockytu=d.bLockytu_traiphai(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
            format_dongia = d.format_dongia(i_nhom);
            format_sotien = d.format_sotien(i_nhom);
			i_songay=d.Ngaylv_Ngayht;

            cl_nguyenlieu.DisplayMember = "TEN";
            cl_nguyenlieu.ValueMember = "ID";
            cl_nguyenlieu.DataSource = d.get_data("select * from " + user + ".d_tieuchuan order by stt").Tables[0];

            chatluong.DisplayMember = "TEN";
            chatluong.ValueMember = "ID";
            chatluong.DataSource = d.get_data("select * from " + user + ".d_chatluong order by stt").Tables[0];

            listNX.DisplayMember = "MA";
            listNX.ValueMember = "TEN";
            sql = "select ma,ten,id,nhomcc,diachi,masothue,daidien,id,dienthoai from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt";
            dtdmnx = d.get_data(sql).Tables[0];
            listNX.DataSource = dtdmnx;

            listDMBD.DisplayMember = "TEN";
            listDMBD.ValueMember = "MA";

			load_dm();
			
			sql="select a.id,a.so,to_char(a.ngay,'dd/mm/yyyy') as ngay,to_char(a.tu,'dd/mm/yyyy') as tu,to_char(a.den,'dd/mm/yyyy') as den,";
            sql+="a.ghichu,a.madv,b.ma,b.ten from "+user+".d_dmthaull a inner join "+user+".d_dmnx b on a.madv=b.id where a.nhom="+i_nhom;
			if (!bAdmin) sql+=" and userid="+i_userid;
			sql+=" order by so";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="SO";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_xuatct.xml");
            dsxoa.Tables[0].Columns.Add("tenhang");
            dsxoa.Tables[0].Columns.Add("tennuoc");
            dsxoa.Tables[0].Columns.Add("sodk");
            dsxoa.Tables[0].Columns.Add("tentieuchuan");
            dsxoa.Tables[0].Columns.Add("tenchatluong");
            dsxoa.Tables[0].Columns.Add("nguyenlieu");
            dsxoa.Tables[0].Columns.Add("donvi");
            dsxoa.Tables[0].Columns.Add("cl_nguyenlieu",typeof(decimal));
            dsxoa.Tables[0].Columns.Add("chatluong", typeof(decimal));
            dsxoa.Tables[0].Columns.Add("id", typeof(decimal));
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.id,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.sodk,b.dang,c.ten as tentieuchuan,";
            sql+="d.ten as tenchatluong,a.nguyenlieu,a.cl_nguyenlieu,a.chatluong,f.ten as tennuoc,e.ten as tenhang,b.donvi,";
            sql+="a.soluong,a.dongia,a.soluong*a.dongia as sotien ";
			sql+=" from "+user+".d_dmthauct a inner join "+user+".d_dmbd b on a.mabd=b.id ";
            sql+=" left join "+user+".d_tieuchuan c on a.cl_nguyenlieu=c.id ";
            sql+=" left join "+user+".d_chatluong d on a.chatluong=d.id ";
            sql+=" left join "+user+".d_dmhang e on b.mahang=e.id ";
            sql+=" left join "+user+".d_dmnuoc f on b.manuoc=f.id ";
            sql+=" where a.idll="+l_id+" order by a.id";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
                l_idct = decimal.Parse(dataGrid1[i, 0].ToString());
                DataRow r = d.getrowbyid(dtct, "id=" + l_idct);
                if (r != null)
                {
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    donvi.Text = r["donvi"].ToString();
                    dang.Text = r["dang"].ToString();
                    tenhang.Text = r["tenhang"].ToString();
                    tennuoc.Text = r["tennuoc"].ToString();
                    nguyenlieu.Text = r["nguyenlieu"].ToString();
                    cl_nguyenlieu.SelectedValue = r["cl_nguyenlieu"].ToString();
                    chatluong.SelectedValue = r["chatluong"].ToString();
                    d_soluongcu = d_soluong = decimal.Parse(r["soluong"].ToString());
                    soluong.Text = d_soluong.ToString(format_soluong);
                    d_dongia = decimal.Parse(r["dongia"].ToString());
                    dongia.Text = d_dongia.ToString(format_dongia);
                    d_sotien = decimal.Parse(r["sotien"].ToString());
                    sotien.Text = d_sotien.ToString(format_sotien);
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

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
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
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Tên hoạt chất";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Biệt dược";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sodk";
            TextCol.HeaderText = "Số đăng ký";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "nguyenlieu";
            TextCol.HeaderText = "Nguyên liệu";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tentieuchuan";
            TextCol.HeaderText = "";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenhang";
            TextCol.HeaderText = "Hãng";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tennuoc";
            TextCol.HeaderText = "Nước";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenchatluong";
            TextCol.HeaderText = "Chất lượng";
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "donvi";
            TextCol.HeaderText = "Đóng gói";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dongia";
            TextCol.HeaderText = "Đơn giá";
            TextCol.Width = 80;
            TextCol.Format = format_dongia;
            TextCol.Alignment = HorizontalAlignment.Right;
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

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sotien";
            TextCol.HeaderText = "Số tiền";
            TextCol.Width = 80;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
            /*
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
			catch{}*/
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
					sophieu.Text=r["so"].ToString();
					ngaysp.Text=r["ngay"].ToString();
                    tu.Text = r["tu"].ToString();
                    den.Text = r["den"].ToString();
                    ghichu.Text = r["ghichu"].ToString();
                    madv.Text = r["ma"].ToString();
                    tendv.Text = r["ten"].ToString();
                    i_madv = int.Parse(r["madv"].ToString());
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
				if (bLockytu) sql="(ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
				sql+=" and (madv="+i_madv+" or madv=0)";
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
				listDMBD.BrowseToDmbd(tenbd,mabd,nguyenlieu,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-20,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
            if (!listDMBD.Focused) listDMBD.Hide();
            if (tenbd.Text != "" && mabd.Text == "")
            {
                r = d.getrowbyid(dtton, "ten='" + tenbd.Text + "'");
                if (r != null)
                {
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    if (nguyenlieu.Text != "") nguyenlieu.Text = tenhc.Text;
                    dang.Text = r["dang"].ToString();
                    donvi.Text = r["donvi"].ToString();
                    tenhang.Text = r["tenhang"].ToString();
                    tennuoc.Text = r["tennuoc"].ToString();
                    listDMBD.Hide();
                    nguyenlieu.Focus();
                }
            }
		}

		private void ena_object(bool ena)
		{
			find.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			sophieu.Enabled=ena;
			ngaysp.Enabled=ena;
			madv.Enabled=tendv.Enabled=tu.Enabled=den.Enabled=ghichu.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			nguyenlieu.Enabled=cl_nguyenlieu.Enabled=chatluong.Enabled=tenbd.Enabled=ena;
			dongia.Enabled=soluong.Enabled=ena;
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
            find.Text = "";
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
		}

		private void emp_head()
		{
			l_id=0;
			tu.Text=den.Text=ngaysp.Text=s_ngay;
            madv.Text=tendv.Text=sophieu.Text=ghichu.Text=find.Text = "";
            
			s_ngaysp=ngaysp.Text;
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
			mabd.Text=tenbd.Text=tenhc.Text=dang.Text=donvi.Text=tenhang.Text="";
            tennuoc.Text = nguyenlieu.Text = ""; l_idct = d.get_id_dmthauct;
			dongia.Text=sotien.Text=soluong.Text="";
			d_soluongcu=0;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			sophieu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			ena_object(true);
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			sophieu.Focus();
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
            if (tu.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập hiệu lực từ ngày !"), d.Msg);
                tu.Focus();
                return false;
            }
            if (den.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập hiệu lực đến ngày !"), d.Msg);
                den.Focus();
                return false;
            }
            if (!d.bNgay(den.Text,tu.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Hiệu lực đến không được nhỏ hơn từ !"), d.Msg);
                den.Focus();
                return false;
            }
            if (madv.Text == "" && tendv.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn nhà thầu !"), d.Msg);
                madv.Focus();
                return false;
            }
            if ((madv.Text != "" && tendv.Text == "") || (madv.Text == "" && tendv.Text != ""))
            {
                if (madv.Text == "")
                {
                    madv.Focus();
                    return false;
                }
                else if (tendv.Text == "")
                {
                    tendv.Focus();
                    return false;
                }
            }
            i_madv = 0;
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            if (r == null)
            {                
                MessageBox.Show(lan.Change_language_MessageText("Nhà thầu không hợp lệ !"), d.Msg);
                madv.Focus();
                return false;
            }
            i_madv = int.Parse(r["id"].ToString());
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
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
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
			d.delrec(dtct,"ma='"+mabd.Text+"'");
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

        private void updrec(DataTable dt,decimal id,int mabd, string ma, string ten, string tenhc,string sodk, string dang,
            string tentieuchuan,string tenchatluong,string nguyenlieu,int cl_nguyenlieu,int chatluong,
            string tennuoc,string tenhang,string donvi,decimal soluong,decimal dongia,decimal sotien)
        {
            string exp = "ma='" + ma+"'";
            DataRow r = d.getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["id"] = id;
                nrow["mabd"] = mabd;
                nrow["ma"] = ma;
                nrow["ten"] = ten;
                nrow["tenhc"] = tenhc;
                nrow["sodk"] = sodk;
                nrow["dang"] = dang;
                nrow["tentieuchuan"] = tentieuchuan;
                nrow["tenchatluong"] = tenchatluong;
                nrow["nguyenlieu"] = nguyenlieu;
                nrow["cl_nguyenlieu"] = cl_nguyenlieu;
                nrow["chatluong"] = chatluong;
                nrow["tennuoc"] = tennuoc;
                nrow["tenhang"] = tenhang;
                nrow["donvi"] = donvi;
                nrow["soluong"] = soluong;
                nrow["dongia"] = dongia;
                nrow["sotien"] = sotien;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                if (dr.Length > 0)
                {
                    dr[0]["mabd"] = mabd;
                    dr[0]["ma"] = ma;
                    dr[0]["ten"] = ten;
                    dr[0]["tenhc"] = tenhc;
                    dr[0]["sodk"] = sodk;
                    dr[0]["dang"] = dang;
                    dr[0]["tentieuchuan"] = tentieuchuan;
                    dr[0]["tenchatluong"] = tenchatluong;
                    dr[0]["nguyenlieu"] = nguyenlieu;
                    dr[0]["cl_nguyenlieu"] = cl_nguyenlieu;
                    dr[0]["chatluong"] = chatluong;
                    dr[0]["tennuoc"] = tennuoc;
                    dr[0]["tenhang"] = tenhang;
                    dr[0]["donvi"] = donvi;
                    dr[0]["soluong"] = soluong;
                    dr[0]["dongia"] = dongia;
                    dr[0]["sotien"] = sotien;
                }
            }
        }

        private void updrec(DataTable dt, decimal id,string so,string ngay,string tu,string den,string ghichu,
            int madv,string ma,string ten)
        {
            string exp = "id=" + id;
            DataRow r = d.getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["id"] = id;
                nrow["so"] = so;
                nrow["ngay"] = ngay;
                nrow["tu"] = tu;
                nrow["den"] = den;
                nrow["ghichu"] = ghichu;
                nrow["madv"] = madv;
                nrow["ma"] = ma;
                nrow["ten"] = ten;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                if (dr.Length > 0)
                {
                    dr[0]["id"] = id;
                    dr[0]["so"] = so;
                    dr[0]["ngay"] = ngay;
                    dr[0]["tu"] = tu;
                    dr[0]["den"] = den;
                    dr[0]["ghichu"] = ghichu;
                    dr[0]["madv"] = madv;
                    dr[0]["ma"] = ma;
                    dr[0]["ten"] = ten;
                }
            }
        }

		private bool upd_table(DataTable dt,bool del)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
            d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
            d_sotien = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
			updrec(dt,l_idct,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,sodk.Text,dang.Text,(cl_nguyenlieu.SelectedIndex!=-1)?cl_nguyenlieu.Text:"",
                (chatluong.SelectedIndex!=1)?chatluong.Text:"",nguyenlieu.Text,
                (cl_nguyenlieu.SelectedIndex!=-1)?int.Parse(cl_nguyenlieu.SelectedValue.ToString()):0,
                (chatluong.SelectedIndex!=-1)?int.Parse(chatluong.SelectedValue.ToString()):0,tennuoc.Text,tenhang.Text,
                donvi.Text,d_soluong,d_dongia,d_sotien);
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
            try
            {
                d_soluong = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
                soluong.Text = d_soluong.ToString(format_soluong);
                decimal dg = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                decimal st = d_soluong * dg;
                sotien.Text = st.ToString(format_sotien);
            }
            catch { }
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					d.execute_data("delete from "+user+".d_dmthauct where idll="+l_id);
					d.execute_data("delete from "+user+".d_dmthaull where id="+l_id);
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
            sql = "select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(b.ten)||'/'||c.ten as hang,trim(a.dang)||'/'||trim(a.donvi) as dang,a.tenhc,a.id,a.giaban,a.dongia,b.ten as tenhang,c.ten as tennuoc,a.manhom,nullif(d.ma,' ') as sotk,a.sldonggoi,a.madv,a.sodk,a.donvi from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id inner join " + user + ".d_dmnuoc c on a.manuoc=c.id left join " + user + ".d_dmnhomkt d on a.sotk=d.id where a.nhom=" + i_nhom + " and a.hide=0";
            sql += " order by a.ten";
            dtton = d.get_data(sql).Tables[0];
			listDMBD.DataSource=dtton;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct,false);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_dmthaull:l_id;
			if (!d.upd_dmthaull(l_id,i_nhom,i_madv,sophieu.Text,ngaysp.Text,tu.Text,den.Text,ghichu.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin thầu!"),d.Msg);
				return;
			}
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
					d.execute_data("delete from "+user+".d_dmthauct where id="+decimal.Parse(r1["id"].ToString()));
			}
			foreach(DataRow r1 in dtct.Rows)
				d.upd_dmthauct(decimal.Parse(r1["id"].ToString()),l_id,int.Parse(r1["mabd"].ToString()),r1["nguyenlieu"].ToString(),int.Parse(r1["cl_nguyenlieu"].ToString()),int.Parse(r1["chatluong"].ToString()),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["dongia"].ToString()));
			updrec(dtll,l_id,sophieu.Text,ngaysp.Text,tu.Text,den.Text,ghichu.Text,i_madv,madv.Text,tendv.Text);
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
			ena_object(false);
			butMoi.Focus();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			string tenfile="d_dmthau.rpt";
			string slydo="DANH MỤC THUỐC TRÚNG THẦU";
            string diachi="", dienthoai = "";
            sql = "select g.stt,g.ten as tennhom,a.id,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.sodk,b.dang,c.ten as tentieuchuan,";
            sql += "d.ten as tenchatluong,a.nguyenlieu,a.cl_nguyenlieu,a.chatluong,f.ten as tennuoc,e.ten as tenhang,b.donvi,";
            sql += "a.soluong,a.dongia,a.soluong*a.dongia as sotien ";
            sql += " from " + user + ".d_dmthauct a inner join " + user + ".d_dmbd b on a.mabd=b.id ";
            sql += " left join " + user + ".d_tieuchuan c on a.cl_nguyenlieu=c.id ";
            sql += " left join " + user + ".d_chatluong d on a.chatluong=d.id ";
            sql += " left join " + user + ".d_dmhang e on b.mahang=e.id ";
            sql += " left join " + user + ".d_dmnuoc f on b.manuoc=f.id ";
            sql += " left join " + user + ".d_dmnhom g on b.manhom=g.id ";
            sql += " where a.idll=" + l_id + " order by g.stt,g.ten,b.ma";
            DataSet ds = d.get_data(sql);
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                ds.WriteXml("..\\xml\\d_dmthau.xml", XmlWriteMode.WriteSchema);
            }
            DataRow r = d.getrowbyid(dtdmnx, "id=" + i_madv);
            if (r != null)
            {
                diachi = r["diachi"].ToString(); dienthoai = r["dienthoai"].ToString();
            }
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,ds.Tables[0], i_userid,tenfile,cmbSophieu.Text,ngaysp.Text,tu.Text,den.Text,"",slydo,tendv.Text,diachi,dienthoai,ghichu.Text);
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+tenfile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(ds.Tables[0]);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+tu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+den.Text+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+slydo+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+tendv.Text+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+diachi+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+dienthoai+"'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + ghichu.Text + "'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
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

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.BrowseToDmbd(mabd,tenbd,nguyenlieu,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-20,mabd.Height+5);
			}		
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu)
				{
					if (bMaso_ten) sql="ma like '"+ma.Trim()+"%' or ten like '"+ma.Trim()+"%' or tenhc like '"+ma.Trim()+"%'";
					else sql="ma like '"+ma.Trim()+"%'";
				}
				else 
				{
					if (bMaso_ten) sql="ma like '%"+ma.Trim()+"%' or ten like '%"+ma.Trim()+"%' or tenhc like '%"+ma.Trim()+"%'";
					else sql="ma like '%"+ma.Trim()+"%'";
                    
				}
                sql += " and (madv=0 or madv=" + i_madv + ")";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) mabd_Validated(null, null);
	    }

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
                if (listDMBD.Visible)
                {
                    listDMBD.Focus();
                    SendKeys.Send("{Up}");
                }
                else SendKeys.Send("{Tab}");
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
				dv.RowFilter="sophieu like '%"+text.Trim()+"%'";
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}
	
        private void mabd_Validated(object sender, EventArgs e)
        {
            if (mabd.Text != "")
            {
                r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                if (r != null)
                {
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    if (nguyenlieu.Text == "") nguyenlieu.Text = tenhc.Text;
                    dang.Text = r["dang"].ToString();
                    donvi.Text = r["donvi"].ToString();
                    tenhang.Text = r["tenhang"].ToString();
                    tennuoc.Text = r["tennuoc"].ToString();
                    listDMBD.Hide();
                    nguyenlieu.Focus();
                }
            }
            if (!listDMBD.Focused) listDMBD.Hide();
        }

        private void madv_Validated(object sender, EventArgs e)
        {  
			if (madv.Text!="")
			{
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
                if (r != null)
                {
                    tendv.Text = r["ten"].ToString();
                    i_madv = int.Parse(r["id"].ToString());
                }
			}
        }

        private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listNX.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listNX.Visible) listNX.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void tendv_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tendv)
            {
                Filter_dmnx(tendv.Text);
                listNX.BrowseToDmnx(tendv, madv,tu);
            }
        }

        private void Filter_dmnx(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listNX.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void tendv_Validated(object sender, System.EventArgs e)
        {
            if (!listNX.Focused) listNX.Hide();
            if (tendv.Text != "" && madv.Text == "")
            {
                r = d.getrowbyid(dtdmnx, "ten='" + tendv.Text + "'");
                if (r != null)
                {
                    madv.Text = r["ma"].ToString();
                    i_madv = int.Parse(r["id"].ToString());
                }
            }
        }

        private void madv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void listNX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) madv_Validated(sender, e);
        }

        private void tu_Validated(object sender, EventArgs e)
        {
            if (tu.Text == "") return;
            tu.Text = tu.Text.Trim();
            if (!d.bNgay(tu.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), d.Msg);
                tu.Focus();
                return;
            }
            den.Text = d.Ktngaygio(den.Text, 10);
        }

        private void den_Validated(object sender, EventArgs e)
        {
            if (den.Text == "") return;
            den.Text = den.Text.Trim();
            if (!d.bNgay(den.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), d.Msg);
                den.Focus();
                return;
            }
            den.Text = d.Ktngaygio(den.Text, 10);
        }

        private void dongia_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal dg = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                decimal st = ((soluong.Text != "") ? decimal.Parse(soluong.Text) : 0) * dg;
                dongia.Text = dg.ToString(format_dongia);
                sotien.Text = st.ToString(format_sotien);
            }
            catch { }
        }
	}
}