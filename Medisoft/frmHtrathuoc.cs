using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmHtrathuoc.
	/// </summary>
	public class frmHtrathuoc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label lMabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label ldvt;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.ComboBox cmbMabn;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
		private int i_userid,i_old,i_mabd,itable;
		private string user,xxx,nam,sql,s_mmyy,s_msg,s_ngaylanh="",s_tenkho="";
		private decimal l_id=0;
		private decimal d_soluongcu,d_soluong,d_soluongton;
		private bool bNew,bEdit,bNhapten,bLockytu;
        private LibList.List listDmbd;
		private DataRow r;
		private DataSet dston=new DataSet();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtkho=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label label19;
		private MaskedTextBox.MaskedTextBox ghichu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox makho;
        private System.Windows.Forms.TextBox stt;
        private MaskedBox.MaskedBox ngay;
        private TextBox namsinh;
        private Label label3;
        private MaskedTextBox.MaskedTextBox dongia;
        private Label label4;
        private MaskedTextBox.MaskedTextBox sotien;
        private Label label5;
        private int i_nhom,i_loaiba,i_madoituong,i_done=0;
        private decimal l_maql, l_mavaovien;
        private string s_mabn,s_ngay,s_makp,s_mabs,s_hoten,s_namsinh;
        private TextBox sttt;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHtrathuoc(LibMedi.AccessData acc,int _nhom,string _mabn,string _hoten,string _namsinh,decimal _maql,decimal _mavaovien,string _ngay,string _makp,string _mabs,int _loaiba,int _madoituong)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

            m = acc; i_nhom = _nhom; s_mabn = _mabn; l_maql = _maql; l_mavaovien = _mavaovien;
            s_ngay = _ngay; s_makp = _makp; s_mabs = _mabs; i_loaiba = _loaiba; i_madoituong = _madoituong;
            s_hoten = _hoten; s_namsinh = _namsinh; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHtrathuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.mabd = new System.Windows.Forms.TextBox();
            this.lTen = new System.Windows.Forms.Label();
            this.lMabd = new System.Windows.Forms.Label();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.listDmbd = new LibList.List();
            this.label19 = new System.Windows.Forms.Label();
            this.ghichu = new MaskedTextBox.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sttt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(48, 6);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(176, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(341, 21);
            this.hoten.TabIndex = 2;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
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
            this.dataGrid1.Location = new System.Drawing.Point(3, 35);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 252);
            this.dataGrid1.TabIndex = 28;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // tenbd
            // 
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(280, 293);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(344, 21);
            this.tenbd.TabIndex = 7;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(72, 316);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(552, 21);
            this.tenhc.TabIndex = 8;
            // 
            // lTenhc
            // 
            this.lTenhc.Location = new System.Drawing.Point(0, 316);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(72, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabd
            // 
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(160, 293);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(60, 21);
            this.mabd.TabIndex = 6;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Location = new System.Drawing.Point(240, 293);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(40, 23);
            this.lTen.TabIndex = 69;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Location = new System.Drawing.Point(115, 293);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(48, 23);
            this.lMabd.TabIndex = 68;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(72, 339);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(40, 21);
            this.dang.TabIndex = 9;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(280, 339);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(68, 21);
            this.soluong.TabIndex = 12;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(223, 338);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 74;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Location = new System.Drawing.Point(0, 338);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(72, 23);
            this.ldvt.TabIndex = 73;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(0, 293);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 23);
            this.label25.TabIndex = 76;
            this.label25.Text = "Ngày lĩnh :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(536, 366);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 26;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(466, 366);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 25;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.butBoqua.Location = new System.Drawing.Point(396, 366);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 21;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(326, 366);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 19;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(256, 366);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 18;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(186, 366);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 20;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(116, 366);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 24;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(46, 366);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 22;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // cmbMabn
            // 
            this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(48, 6);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(80, 21);
            this.cmbMabn.TabIndex = 0;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // listDmbd
            // 
            this.listDmbd.BackColor = System.Drawing.SystemColors.Info;
            this.listDmbd.ColumnCount = 0;
            this.listDmbd.Location = new System.Drawing.Point(200, 425);
            this.listDmbd.MatchBufferTimeOut = 1000;
            this.listDmbd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDmbd.Name = "listDmbd";
            this.listDmbd.Size = new System.Drawing.Size(75, 17);
            this.listDmbd.TabIndex = 89;
            this.listDmbd.TextIndex = -1;
            this.listDmbd.TextMember = null;
            this.listDmbd.ValueIndex = -1;
            this.listDmbd.Visible = false;
            this.listDmbd.DoubleClick += new System.EventHandler(this.listDmbd_DoubleClick);
            this.listDmbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDmbd_KeyDown);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(-25, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Ghi chú :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(48, 29);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(571, 21);
            this.ghichu.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(120, 338);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 23);
            this.label20.TabIndex = 96;
            this.label20.Text = "Kho :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(160, 339);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(60, 21);
            this.makho.TabIndex = 11;
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(208, 210);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 98;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(72, 293);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(64, 21);
            this.ngay.TabIndex = 5;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(587, 6);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 108;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(523, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 107;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(400, 339);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(80, 21);
            this.dongia.TabIndex = 109;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(345, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 110;
            this.label4.Text = "Đơn giá :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotien
            // 
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(526, 339);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(98, 21);
            this.sotien.TabIndex = 111;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(470, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 112;
            this.label5.Text = "Số tiền :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sttt
            // 
            this.sttt.Enabled = false;
            this.sttt.Location = new System.Drawing.Point(303, 214);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(24, 20);
            this.sttt.TabIndex = 113;
            // 
            // frmHtrathuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(630, 448);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.listDmbd);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.sttt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHtrathuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoàn trả thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHtrathuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHtrathuoc_Load(object sender, System.EventArgs e)
		{
            user = d.user; s_mmyy = m.mmyy(s_ngay); xxx = user + s_mmyy;
			bLockytu=d.bLockytu_traiphai(i_nhom);
			bNhapten=m.bNhapthuoc_ten;
			dston.ReadXml("..//..//..//xml//d_tonkhohtra.xml");
			dtdmbd=d.get_data("select * from "+user+".d_dmbd where nhom="+i_nhom).Tables[0];

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";
			
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";

			sql="select id,mabn,mavaovien,maql,ghichu,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "madoituong,makp,mabs,loaiba,idduyet,done,userid ";
			sql+=" from "+xxx+".d_htrathuocll where mabn='"+s_mabn+"' and maql="+l_maql+" order by id";
			dtll=d.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..//..//..//xml//d_htrathuocct.xml");
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,";
            sql+="a.soluong,a.giaban,a.soluong*a.giaban as sotien,a.madoituong,a.makho,to_char(a.ngay,'dd/mm/yyyy') as ngay ";
			sql+=" from "+xxx+".d_htrathuocct a,"+user+".d_dmbd b,"+user+".d_dmkho f ";
            sql+=" where a.mabd=b.id and a.makho=f.id and a.id="+l_id+" order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de,1);
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày lĩnh";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 45;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 170;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 34;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "giaban";
            TextCol.HeaderText = "Đơn giá";
            TextCol.Width = 80;
            TextCol.Format = "###,###,##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;            
				stt.Text=dataGrid1[i,0].ToString();
                r = m.getrowbyid(dtct, "stt=" + int.Parse(stt.Text));
                if (r != null)
                {
                    sttt.Text = r["sttt"].ToString();
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    dang.Text = r["dang"].ToString();
                    d_soluong = (r["soluong"].ToString() == "") ? 0 : decimal.Parse(r["soluong"].ToString());
                    soluong.Text = d_soluong.ToString("###,##0.00");
                    dongia.Text = r["giaban"].ToString();
                    sotien.Text = r["sotien"].ToString();
                    makho.SelectedValue = r["makho"].ToString();
                    ngay.Text = r["ngay"].ToString();
                    if (ngay.Text != s_ngaylanh)
                    {
                        s_ngaylanh = ngay.Text;
                        load_dm();
                    }
                    d_soluongcu = d_soluong;
                }
			}
            catch {emp_detail(); }
		}

		private void ena_object(bool ena)
		{
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			ghichu.Enabled=ena;
            ngay.Enabled = ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
		}

		private void emp_head()
		{
            mabn.Text = s_mabn; hoten.Text = s_hoten; ghichu.Text = ""; l_id = 0;ngay.Text = s_ngay;
            s_ngaylanh = s_ngay; dsxoa.Clear(); i_done = 0;
		}

		private void emp_detail()
		{
			mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";
			soluong.Text="";makho.SelectedIndex=-1;stt.Text=d.get_stt(dtct).ToString();
            d_soluongcu = 0; sttt.Text = "0";
		}

		private void load_dm()
		{
			if (butLuu.Enabled)
			{
				if (ngay.Text==""){ngay.Focus();return;}
				dston.Clear();
				int istt=0;
				DateTime dt1,dt2,dt=d.StringToDate(ngay.Text);
				dt1=dt.AddDays(-d.iNgaykiemke);
				dt2=dt.AddDays(d.iNgaykiemke);
				int y1=dt1.Year,m1=dt1.Month;
				int y2=dt2.Year,m2=dt2.Month;
				int tu,den;
				string mmyy;
				for(int i=y1;i<=y2;i++)
				{
					tu=(i==y1)?m1:1;
					den=(i==y2)?m2:12;
					for(int j=tu;j<=den;j++)
					{
						mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
						if (d.bMmyy(mmyy))
						{
                            sql ="select b.sttt,b.makho,b.mabd,b.soluong,t.giamua,t.giaban from " + user + mmyy + ".bhytkb a," + user + mmyy + ".bhytthuoc b,"+user+mmyy+".d_theodoi t ";
                            sql+=" where a.id=b.id and b.sttt=t.id and a.loaiba=" + i_loaiba;
                            sql+=" and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0,10) + "'";
							sql+=" and a.mabn='"+s_mabn+"'";
                            sql+=" order by b.mabd";
							foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
							{
								r=d.getrowbyid(dtkho,"id="+int.Parse(r1["makho"].ToString()));
								if (r==null) s_tenkho="";
								else s_tenkho=r["ten"].ToString();
								r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
								if (r!=null)
                                    d.updrec_tonkhohtra(dston.Tables[0], istt++,r["ma"].ToString(), r["ten"].ToString().Trim() + " " + r["hamluong"].ToString(),r["dang"].ToString(), s_tenkho, decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["giaban"].ToString()), int.Parse(r1["mabd"].ToString()), int.Parse(r1["makho"].ToString()),int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sttt"].ToString()),r1["tenhc"].ToString());
							}
						}
					}
				}
				listDmbd.DataSource=dston.Tables[0];
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (i_done!=0)
			{
                MessageBox.Show(
lan.Change_language_MessageText("Số liệu đã cập nhật !"), s_msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			s_ngaylanh="";
			bNew=true;
			bEdit=true;
			ghichu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
            if (i_done != 0)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Số liệu đã cập nhật !"), s_msg);
                return;
            }
			l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			ena_object(true);
			bNew=false;
			bEdit=true;
			s_ngaylanh=ngay.Text;
			load_dm();
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			upd_table(dtct);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.getidyymmddhhmiss_stt_computer:l_id;
            itable = m.tableid(m.mmyy(s_ngay), "d_htrathuocll");
            if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + s_ngay + "^" + s_mabn + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + i_madoituong + "^" + s_makp+"^"+s_mabs+"^"+i_loaiba.ToString()+"^"+ghichu.Text+"^0^0^"+i_userid.ToString());
            }
            if (!d.upd_htrathuocll(l_id,i_nhom,s_ngay,s_mabn,l_mavaovien,l_maql,i_madoituong,s_makp,s_mabs,i_loaiba,ghichu.Text,i_userid))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            itable = m.tableid(m.mmyy(s_ngay), "d_htrathuocct");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_htrathuocct", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".d_htrathuocct where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
				}
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                if (m.get_data("select * from " + xxx + ".d_htrathuocct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["sttt"].ToString()+"^"+r1["ngay"].ToString() + "^" + r1["makho"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["giaban"].ToString());
                }
                else m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                d.upd_htrathuocct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()),decimal.Parse(r1["sttt"].ToString()), r1["ngay"].ToString(), int.Parse(r1["makho"].ToString()),int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["giaban"].ToString()));
            }
			d.updrec_hoantrall(dtll,l_id,s_mabn,l_maql,l_mavaovien,s_hoten,0,ghichu.Text,l_mavaovien);
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbMabn.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
			load_grid();
			ref_text();
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbMabn.SelectedIndex=i_old;
			}
			catch{}
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="soluong>0 and ma like '"+ma.Trim()+"%'";
				else sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="(soluong>0) and (ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
                listDmbd.Tonkhohtra(mabd, tenbd, soluong, ngay.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + ngay.Width + lMabd.Width, mabd.Height + 5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDmbd.Tonkhohtra(tenbd,mabd,soluong,ngay.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+ngay.Width+lMabd.Width,mabd.Height+5);
			}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDmbd.Visible) listDmbd.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDmbd.Focused) listDmbd.Hide();
		}

		private void listDmbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dston.Tables[0],"stt="+int.Parse(mabd.Text));
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
						makho.SelectedValue=r["makho"].ToString();
                        dongia.Text = r["giaban"].ToString();
                        sttt.Text = r["sttt"].ToString();
					}
				}
				catch(Exception ex){MessageBox.Show(ex.Message);}
			}
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn)
			{
				try
				{
					l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
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
					mabn.Text=r["mabn"].ToString();
					hoten.Text=s_hoten;
					ghichu.Text=r["ghichu"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                    i_done=int.Parse(r["done"].ToString());
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
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
lan.Change_language_MessageText("Nhập mã số !"),s_msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập tên !"),s_msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dston.Tables[0],"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Mã số không hợp lệ !"),s_msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số lượng !"),s_msg);
				soluong.Focus();
				return false;
			}
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
			if (!upd_table(dtct)) return;
			emp_detail();
			ngay.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
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
			d.updrec_htrathuocct(dt,int.Parse(stt.Text),decimal.Parse(sttt.Text),i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,(dongia.Text!="")?decimal.Parse(dongia.Text):0,d_soluong*((dongia.Text!="")?decimal.Parse(dongia.Text):0),0,int.Parse(makho.SelectedValue.ToString()),ngay.Text,dston.Tables[0]);
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
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString("#,###,##0.00");
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dston.Tables[0],"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=d.get_slton_sttt(dston.Tables[0],decimal.Parse(sttt.Text),d_soluongcu);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show(
lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",s_msg);
							soluong.Focus();
							return;
						}
					}
				}
				if (d_soluongcu!=0) upd_table(dtct);
			}
			catch{}
		}
		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbMabn.Items.Count==0) return;
				if (i_done!=0)
				{					
					MessageBox.Show(
lan.Change_language_MessageText("Số liệu đã cập nhật !"),s_msg);
					return;
				}
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = m.tableid(m.mmyy(s_ngay), "d_htrathuocct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_htrathuocct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    }
                    itable = m.tableid(m.mmyy(s_ngay), "d_htrathuocll");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_htrathuocll", "id=" + l_id));
					d.execute_data("delete from "+xxx+".d_htrathuocct where id="+l_id);
					d.execute_data("delete from "+xxx+".d_htrathuocll where id="+l_id);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngay.Text=="") return;
			ngay.Text=ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngay.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngay.Focus();
				return;
			}
			ngay.Text=d.Ktngaygio(ngay.Text,10);
			if (!d.bNgay(s_ngay,ngay.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày lãnh không được lớn hơn ngày trả !"),d.Msg);
				ngay.Focus();
				return;
			}
			if (ngay.Text!=s_ngaylanh)
			{
				s_ngaylanh=ngay.Text;
				load_dm();
			}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				DataRow [] dr=dston.Tables[0].Select("ma like '"+mabd.Text.Trim()+"%'");
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(int.Parse(mabd.Text));
					if(!listDmbd.Focused) listDmbd.Hide();
					soluong.Focus();
				}
				else
				{
					if (listDmbd.Visible)
					{
						listDmbd.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void listDmbd_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				get_items(int.Parse(listDmbd.Text));
			}
			catch{}
		}

		private void get_items(int stt)
		{
			try
			{
				r=d.getrowbyid(dston.Tables[0],"stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
                    dongia.Text = r["giaban"].ToString();
                    sttt.Text = r["sttt"].ToString();
					listDmbd.Hide();
					soluong.Focus();
				}
			}
			catch{}		
		}
	}
}
