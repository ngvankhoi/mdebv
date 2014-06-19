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
	/// Summary description for frmHoantra.
	/// </summary>
	public class frmHoantra : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TreeView treeView1;
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
		private LibMedi.AccessData m=new LibMedi.AccessData();
        private int i_nhom, i_makp, i_phieu, i_userid, i_old, i_mabd, i_loai, i_sudungthuoc, i_duyet, i_somay, i_buoi = 0, itable, iPhatthuoc_kho_khoa2, iPhatthuoc_kho_khoa, iPhatthuoc_kho, i_traituyen = 0, i_sttx=0;
		private string user,xxx,nam="",s_nguon,s_makho,s_makp,s_ngay,sql,s_mmyy,s_msg,s_ngaylanh,s_tenkho,s_doituong,s_tenkp,s_tenphieu,s_ngayvv,f_soluong;
        private decimal l_id = 0, l_duyet = 0, l_mavaovien, l_maql, l_idkhoa, l_idx;
		private decimal d_soluongcu,d_soluong,d_soluongton;
        private bool bNew, bEdit, bNhapten, bTTngay, bLockytu, bKhoasau_hoantra_F28, bPhattron;
		private LibList.List listDmbd;
		private LibList.List listHoten;
		private DataRow r;
		private DataTable dthoten=new DataTable();
		private DataSet dston=new DataSet();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtkho=new DataTable();
        private DataTable dtkhofull = new DataTable();
		private DataTable dtnguon=new DataTable();
		private DataTable dtdt=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label label19;
		private MaskedTextBox.MaskedTextBox ghichu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.CheckBox butChuyen;
		private System.Windows.Forms.TextBox mahc;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox lydo;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label22;
        private CheckBox chkThuoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHoantra(string ngay,string makho,string makp,int nhom,int loai,int phieu,int imakp,int userid,string mmyy,decimal duyet,string title,string msg,bool Dausinhton,int sudungthuoc,int buoi,string _tenkp,string _tenphieu,int somay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			s_ngay=ngay;s_makho=makho;s_makp=makp;i_userid=userid;i_nhom=nhom;
			i_loai=loai;i_somay=somay;i_phieu=phieu;i_makp=imakp;i_sudungthuoc=sudungthuoc;
			s_mmyy=mmyy;s_msg=msg;l_duyet=duyet;s_tenkp=_tenkp;s_tenphieu=_tenphieu;
            this.Text = title; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoantra));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
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
            this.listHoten = new LibList.List();
            this.label19 = new System.Windows.Forms.Label();
            this.ghichu = new MaskedTextBox.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.butChuyen = new System.Windows.Forms.CheckBox();
            this.mahc = new System.Windows.Forms.TextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.ComboBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
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
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
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
            this.hoten.Size = new System.Drawing.Size(199, 21);
            this.hoten.TabIndex = 2;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(632, 54);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 426);
            this.treeView1.TabIndex = 26;
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 13);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 395);
            this.dataGrid1.TabIndex = 28;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(280, 412);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(344, 21);
            this.tenbd.TabIndex = 7;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(72, 435);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(552, 21);
            this.tenhc.TabIndex = 8;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(0, 435);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(72, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(180, 412);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(60, 21);
            this.mabd.TabIndex = 6;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(240, 412);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(40, 23);
            this.lTen.TabIndex = 69;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(128, 412);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(48, 23);
            this.lMabd.TabIndex = 68;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(72, 458);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(40, 21);
            this.dang.TabIndex = 9;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(544, 458);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(80, 21);
            this.soluong.TabIndex = 12;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(492, 457);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 74;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(0, 457);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(72, 23);
            this.ldvt.TabIndex = 73;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(0, 412);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 23);
            this.label25.TabIndex = 76;
            this.label25.Text = "Ngày y lệnh :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(491, 486);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 26;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(431, 486);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 25;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(371, 486);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 21;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(311, 486);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(60, 25);
            this.butXoa.TabIndex = 19;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(251, 486);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 18;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(191, 486);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 20;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(131, 486);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 24;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(71, 486);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
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
            this.listDmbd.Location = new System.Drawing.Point(200, 544);
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
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(120, 542);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 90;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(517, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Ghi chú :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(592, 6);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(192, 21);
            this.ghichu.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(238, 457);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 23);
            this.label20.TabIndex = 96;
            this.label20.Text = "Kho :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(280, 458);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(80, 21);
            this.makho.TabIndex = 11;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(638, 432);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 98;
            // 
            // butChuyen
            // 
            this.butChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butChuyen.Appearance = System.Windows.Forms.Appearance.Button;
            this.butChuyen.Image = ((System.Drawing.Image)(resources.GetObject("butChuyen.Image")));
            this.butChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyen.Location = new System.Drawing.Point(561, 486);
            this.butChuyen.Name = "butChuyen";
            this.butChuyen.Size = new System.Drawing.Size(160, 25);
            this.butChuyen.TabIndex = 99;
            this.butChuyen.Text = "    Chuyển số liệu xuống kho";
            this.butChuyen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.butChuyen.CheckedChanged += new System.EventHandler(this.butChuyen_CheckedChanged);
            // 
            // mahc
            // 
            this.mahc.Location = new System.Drawing.Point(208, 360);
            this.mahc.Name = "mahc";
            this.mahc.Size = new System.Drawing.Size(48, 20);
            this.mahc.TabIndex = 102;
            // 
            // ngay
            // 
            this.ngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(72, 412);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(64, 21);
            this.ngay.TabIndex = 5;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.ItemHeight = 13;
            this.madoituong.Location = new System.Drawing.Point(180, 458);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(60, 21);
            this.madoituong.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(115, 457);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 78;
            this.label15.Text = "Đối tượng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(336, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 103;
            this.label3.Text = "Lý do :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(424, 6);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(112, 21);
            this.lydo.TabIndex = 3;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydo_KeyDown);
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(408, 458);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(80, 21);
            this.manguon.TabIndex = 106;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(355, 457);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 23);
            this.label22.TabIndex = 105;
            this.label22.Text = "Nguồn :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkThuoc
            // 
            this.chkThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThuoc.AutoSize = true;
            this.chkThuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkThuoc.Location = new System.Drawing.Point(632, 33);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(116, 17);
            this.chkThuoc.TabIndex = 131;
            this.chkThuoc.Text = "Các ngày trả thuốc";
            this.chkThuoc.UseVisualStyleBackColor = true;
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // frmHoantra
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butChuyen);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.listHoten);
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
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label15);
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
            this.Controls.Add(this.mahc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHoantra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoàn trả thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHoantra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHoantra_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
            chkThuoc.Checked = i_sudungthuoc != 3;
			bLockytu=d.bLockytu_traiphai(i_nhom);
            bKhoasau_hoantra_F28 = m.bKhoasau_hoantra_F28;
            iPhatthuoc_kho_khoa2 = m.iPhatthuoc_kho_khoa2;
            iPhatthuoc_kho_khoa = m.iPhatthuoc_kho_khoa;
            iPhatthuoc_kho = 0; bPhattron = d.bPhattron(i_nhom);
            sql = "select * from " + user + ".d_khonghi where ngay='" + s_ngay.Substring(0, 10) + "'";
            foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
            {
                iPhatthuoc_kho = int.Parse(r1["makho"].ToString());
                break;
            }
            if (iPhatthuoc_kho != 0) iPhatthuoc_kho = (iPhatthuoc_kho == iPhatthuoc_kho_khoa) ? iPhatthuoc_kho_khoa2 : iPhatthuoc_kho_khoa;
            else if (m.bPhatthuoc_kho_khoa)
            {
                if (m.sPhatthuoc_kho_khoa.IndexOf(i_makp.ToString().PadLeft(3, '0')) != -1) iPhatthuoc_kho = iPhatthuoc_kho_khoa;
                else iPhatthuoc_kho = iPhatthuoc_kho_khoa2;
            }
            bNhapten = m.bNhapthuoc_ten; f_soluong = d.format_soluong(i_nhom);
			bTTngay=(m.bChieu_sang && i_buoi==0)?d.get_ttngay(s_ngay,s_makp):false;
			dston.ReadXml("..//..//..//xml//d_tonkhothht.xml");
            //
            //
            dston.Tables[0].Columns.Add("idx", typeof(decimal)).DefaultValue = 0;
            dston.Tables[0].Columns.Add("sttx", typeof(decimal)).DefaultValue = 0;
            //
            //
			dtdmbd=d.get_data("select * from "+user+".d_dmbd where nhom="+i_nhom).Tables[0];
			dthoten=m.get_hiendien(s_makp,s_ngay).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";
			
			dtdt=d.get_data("select * from "+user+".d_doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdt;

			lydo.DisplayMember="TEN";
			lydo.ValueMember="ID";
            lydo.DataSource = d.get_data("select * from " + user + ".d_dmlydo where nhom=" + i_nhom + " order by stt").Tables[0];

            if (d.bQuanlynguon(i_nhom)) sql = "select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt";
            else sql = "select * from " + user + ".d_dmnguon where nhom=0 or nhom=" + i_nhom + " order by stt";
			dtnguon=d.get_data(sql).Tables[0];
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			manguon.DataSource=dtnguon;

            dtkhofull = d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom).Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=(iPhatthuoc_kho!=0)?dtkhofull:dtkho;
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";

			sql="select a.id,a.mabn,d.hoten,a.mavaovien,a.maql,a.idkhoa,a.lydo,c.ghichu,to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv, a.traituyen ";
			sql+=" from "+xxx+".d_hoantrall a inner join "+xxx+".d_duyet b on a.idduyet=b.id ";
            sql+=" left join "+xxx+".d_dausinhton c on a.id=c.iddutru ";
            sql+=" inner join "+user+".btdbn d on a.mabn=d.mabn ";
			sql+=" where a.thuoc=1 and b.id="+l_duyet+" order by a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			dsxoa.ReadXml("..//..//..//xml//d_hoantract.xml");
            //
            dsxoa.Tables[0].Columns.Add("idx", typeof(decimal)).DefaultValue = 0;
            dsxoa.Tables[0].Columns.Add("sttx", typeof(decimal)).DefaultValue = 0;
            dsxoa.Tables[0].Columns.Add("slcu", typeof(decimal)).DefaultValue = 0;
            dsxoa.Tables[0].Columns.Add("hoten", typeof(string));
            //
			if (l_duyet!=0)
			{
                i_duyet = d.get_duyet(s_mmyy, l_duyet);
				butChuyen.Checked=i_duyet!=0;
				butChuyen.Enabled=i_duyet!=2;
				if (butChuyen.Enabled) col_butChuyen(i_duyet);
			}
		}

		private void load_grid()
		{
            sql = " select a.stt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.mahc,a.manguon, a.idx, a.sttx, a.slyeucau as slcu,g.hoten  ";//Thuy 03.02.2012
            sql += " from " + xxx + ".d_hoantract a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".d_doituong e on a.madoituong=e.madoituong inner join " + user + ".d_dmkho f on a.makho=f.id left join " + user + ".dlogin g on a.userid=g.id where a.id=" + l_id + "  order by a.stt";//Thuy 03.02.2012
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

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 55;
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
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 34;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
            TextCol.Format = f_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "madoituong";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày y lệnh";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "mahc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 12);
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Người hoàn";
            TextCol.Width = 80;
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
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    dang.Text = r["dang"].ToString();
                    d_soluong = (r["soluong"].ToString() == "") ? 0 : decimal.Parse(r["soluong"].ToString());
                    soluong.Text = d_soluong.ToString(f_soluong);
                    madoituong.SelectedValue = (r["madoituong"].ToString() != "") ? r["madoituong"].ToString() : "1";
                    makho.SelectedValue = r["makho"].ToString();
                    manguon.SelectedValue = r["manguon"].ToString();
                    ngay.Text = r["ngay"].ToString();
                    if (ngay.Text != s_ngaylanh)
                    {
                        s_ngaylanh = ngay.Text;
                        load_dm();
                    }
                    mahc.Text = r["mahc"].ToString();
                    d_soluongcu = d_soluong;
                    l_idx = decimal.Parse(r["idx"].ToString());
                    i_sttx = int.Parse(r["sttx"].ToString());
                }
			}
            catch {emp_detail(); }
		}

		private void ena_object(bool ena)
		{
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
			if (bNhapten) hoten.Enabled=ena;
			lydo.Enabled=ena;
			ghichu.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			ngay.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butChuyen.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
			//if (ena) load_dm();
		}

		private void emp_head()
		{
            mabn.Text = ""; hoten.Text = ""; ghichu.Text = ""; l_id = 0; l_maql = 0; ngay.Text = s_ngay; l_mavaovien = 0;
            s_ngaylanh = s_ngay; dsxoa.Clear(); nam = ""; s_ngayvv = "";
            l_idx = 0;
            i_sttx = 0;
		}

		private void emp_detail()
		{
			mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
			soluong.Text="";makho.SelectedIndex=-1;stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;
            l_idx = 0;
            i_sttx = 0;
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
				string mmyy,xxx;
                DataRow r2;
                DataSet lds = new DataSet();
				for(int i=y1;i<=y2;i++)
				{
					tu=(i==y1)?m1:1;
					den=(i==y2)?m2:12;
					for(int j=tu;j<=den;j++)
					{
						mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
						if (d.bMmyy(mmyy))
						{
                            xxx = user + mmyy;
                            
                            sql = "select a.id,b.makho,b.madoituong,b.mabd,t.manguon,b.stt,";                            
                            sql += "sum(b.soluong)-sum(sltra) as soluong "; //bbbb
                            sql+=" from " + xxx + ".d_xuatsdll a," + xxx + ".d_xuatsdct b,"+xxx+".d_theodoi t ";
							sql +=" where a.id=b.id and b.sttt=t.id and a.loai in (1,2) ";
                            if (!bKhoasau_hoantra_F28) sql += " and a.makp=" + i_makp;
                            sql += " and to_char(a.ngayylenh,'dd/mm/yyyy')='" + ngay.Text + "'";
                            sql += " and a.mabn='" + mabn.Text + "' and b.makho in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
                            sql += " group by a.id,b.makho,b.madoituong,b.mabd,t.manguon, b.stt";//bbbb  
                            lds = d.get_data(sql);
                            if (lds != null && lds.Tables.Count > 0)
                            {
                                foreach (DataRow r1 in lds.Tables[0].Rows)
                                {
                                    r = d.getrowbyid(dtkho, "id=" + int.Parse(r1["makho"].ToString()));
                                    if (r == null)
                                    {
                                        s_tenkho = "";
                                        if (iPhatthuoc_kho != 0)
                                        {
                                            r = d.getrowbyid(dtkhofull, "id=" + iPhatthuoc_kho);
                                            if (r == null) s_tenkho = "";
                                            else
                                            {
                                                r1["makho"] = int.Parse(r["id"].ToString());
                                                s_tenkho = r["ten"].ToString();
                                            }
                                        }
                                    }
                                    else s_tenkho = r["ten"].ToString();
                                    r = d.getrowbyid(dtdt, "madoituong=" + int.Parse(r1["madoituong"].ToString()));
                                    if (r == null) s_doituong = "";
                                    else s_doituong = r["doituong"].ToString();
                                    r = d.getrowbyid(dtnguon, "id=" + int.Parse(r1["manguon"].ToString()));
                                    if (r == null) s_nguon = "";
                                    else s_nguon = r["ten"].ToString();
                                    r = d.getrowbyid(dtdmbd, "id=" + int.Parse(r1["mabd"].ToString()));
                                    if (r != null)
                                    {
                                        //d.updrec_tonkhothht(dston.Tables[0], istt++, s_nguon, r["ma"].ToString(), r["ten"].ToString().Trim() + " " + r["hamluong"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), s_tenkho, decimal.Parse(r1["soluong"].ToString()), int.Parse(r1["mabd"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["madoituong"].ToString()), s_doituong, int.Parse(r1["manguon"].ToString()));
                                        d.updrec_tonkhothht(dston.Tables[0], istt++, s_nguon, r["ma"].ToString(), r["ten"].ToString().Trim() + " " + r["hamluong"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), s_tenkho, decimal.Parse(r1["soluong"].ToString()), int.Parse(r1["mabd"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["madoituong"].ToString()), s_doituong, int.Parse(r1["manguon"].ToString()), decimal.Parse(r1["id"].ToString()), int.Parse(r1["stt"].ToString()));
                                    }
                                    //
                                }
                            }
						}
					}
				}
				listDmbd.DataSource=dston.Tables[0];
			}
		}
        private void load_dm_cu()
        {
            if (butLuu.Enabled)
            {
                if (ngay.Text == "") { ngay.Focus(); return; }
                dston.Clear();
                int istt = 0;
                DateTime dt1, dt2, dt = d.StringToDate(ngay.Text);
                dt1 = dt.AddDays(-d.iNgaykiemke);
                dt2 = dt.AddDays(d.iNgaykiemke);
                int y1 = dt1.Year, m1 = dt1.Month;
                int y2 = dt2.Year, m2 = dt2.Month;
                int tu, den;
                string mmyy, xxx;
                DataRow r2;
                for (int i = y1; i <= y2; i++)
                {
                    tu = (i == y1) ? m1 : 1;
                    den = (i == y2) ? m2 : 12;
                    for (int j = tu; j <= den; j++)
                    {
                        mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                        if (d.bMmyy(mmyy))
                        {
                            xxx = user + mmyy;

                            sql ="select b.makho,b.madoituong,b.mabd,t.manguon,";
                            //
                            //if (bPhattron) sql += "ceiling(sum(b.soluong)) as soluong ";
                            //else sql+="sum(b.soluong) as soluong ";
                            
                            sql += "sum(b.soluong) as soluong ";
                            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_xuatsdct b," + xxx + ".d_theodoi t ";
                            sql += " where a.id=b.id and b.sttt=t.id and a.loai in (1,2) ";
                            if (!bKhoasau_hoantra_F28) sql += " and a.makp=" + i_makp;
                            sql += " and to_char(a.ngayylenh,'dd/mm/yyyy')='" + ngay.Text + "'";
                            sql += " and a.mabn='" + mabn.Text + "'";
                            sql +=" group by b.makho,b.madoituong,b.mabd,t.manguon";
                            //
                            sql += " union all ";
                            sql += "select b.makho,b.madoituong,b.mabd,b.manguon,sum(b.slthuc) as soluong ";
                            sql += " from " + xxx + ".d_xtutrucll a," + xxx + ".d_xtutrucct b," + xxx + ".d_duyet t ";
                            sql += " where a.id=b.id and a.idduyet=t.id ";
                            if (!bKhoasau_hoantra_F28) sql += " and t.makp=" + i_makp;
                            sql += " and to_char(t.ngay,'dd/mm/yyyy')='" + ngay.Text + "'";
                            sql += " and a.mabn='" + mabn.Text + "' and b.slthuc>0";
                            sql += " group by b.makho,b.madoituong,b.mabd,b.manguon";
                            foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                            {
                                r = d.getrowbyid(dtkho, "id=" + int.Parse(r1["makho"].ToString()));
                                if (r == null)
                                {
                                    s_tenkho = "";
                                    if (iPhatthuoc_kho != 0)
                                    {
                                        r = d.getrowbyid(dtkhofull, "id=" + iPhatthuoc_kho);
                                        if (r == null) s_tenkho = "";
                                        else
                                        {
                                            r1["makho"] = int.Parse(r["id"].ToString());
                                            s_tenkho = r["ten"].ToString();
                                        }
                                    }
                                }
                                else s_tenkho = r["ten"].ToString();
                                r = d.getrowbyid(dtdt, "madoituong=" + int.Parse(r1["madoituong"].ToString()));
                                if (r == null) s_doituong = "";
                                else s_doituong = r["doituong"].ToString();
                                r = d.getrowbyid(dtnguon, "id=" + int.Parse(r1["manguon"].ToString()));
                                if (r == null) s_nguon = "";
                                else s_nguon = r["ten"].ToString();
                                r = d.getrowbyid(dtdmbd, "id=" + int.Parse(r1["mabd"].ToString()));
                                if (r != null)
                                {
                                    d.updrec_tonkhothht(dston.Tables[0], istt++, s_nguon, r["ma"].ToString(), r["ten"].ToString().Trim() + " " + r["hamluong"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), s_tenkho, decimal.Parse(r1["soluong"].ToString()), int.Parse(r1["mabd"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["madoituong"].ToString()), s_doituong, int.Parse(r1["manguon"].ToString()),0,0);
                                }
                                //
                            }
                            //hoantra
                            sql = "select b.makho,b.madoituong,b.mabd,t.manguon,sum(b.soluong) as soluong ";
                            sql+=" from " + user + mmyy + ".d_xuatsdll a," + user + mmyy + ".d_xuatsdct b," + user + mmyy + ".d_theodoi t ";
                            sql += "where a.id=b.id and b.sttt=t.id and a.loai in (3) ";
                            if (!bKhoasau_hoantra_F28) sql += " and a.makp=" + i_makp;
                            sql += " and to_char(a.ngayylenh,'dd/mm/yyyy')='" + ngay.Text + "'";
                            sql += " and a.mabn='" + mabn.Text + "'";
                            sql += " group by b.makho,b.madoituong,b.mabd,t.manguon";
                            foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                            {
                                sql = "soluong>0 ";
                                if (iPhatthuoc_kho != 0)
                                {
                                    sql += " and (makho=" + int.Parse(r1["makho"].ToString());
                                    sql += " or makho=" + iPhatthuoc_kho;
                                    sql += ")";
                                }
                                else sql += " and makho=" + int.Parse(r1["makho"].ToString());
                                sql += " and madoituong=" + int.Parse(r1["madoituong"].ToString()) + " and id=" + int.Parse(r1["mabd"].ToString()) + " and manguon=" + int.Parse(r1["manguon"].ToString());
                                r2 = m.getrowbyid(dston.Tables[0],sql);
                                if (r2!=null)
                                    r2["soluong"]=decimal.Parse(r2["soluong"].ToString())-decimal.Parse(r1["soluong"].ToString());
                            }
                            
                        }
                    }
                }
                listDmbd.DataSource = dston.Tables[0];
            }
        }
		private void mabn_Validated(object sender, System.EventArgs e)
		{
            nam = ""; s_ngayvv = "";
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
                nam = r["nam"].ToString().Trim();
                s_ngayvv = r["ngay"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				hoten.Text=r["hoten"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["id"].ToString());
                i_traituyen = r["traituyen"].ToString() == "" ? 0 : int.Parse(r["traituyen"].ToString());
			}
            else 
            {
                get_hoten(mabn.Text);
                r = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r != null)
                {
                    nam = r["nam"].ToString().Trim();
                    s_ngayvv = r["ngay"].ToString();
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                    hoten.Text = r["hoten"].ToString();
                    l_maql = decimal.Parse(r["maql"].ToString());
                    l_idkhoa = decimal.Parse(r["id"].ToString());
                }
                else
                {
                    hoten.Text = ""; l_mavaovien = 0; l_maql = 0; l_idkhoa = 0; 
                }               
            }
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập !"),s_msg);
					mabn.Focus();
					return;
				}
			}
			catch{}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            i_duyet = d.get_duyet(s_mmyy, l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}
            if (d.bKhoaso(i_nhom, s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), LibMedi.AccessData.Msg);
                return;
            }

			if (bTTngay)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+" "+lan.Change_language_MessageText("viện phí đã in danh sách thu tiền")+"\n"+lan.Change_language_MessageText("Yêu cầu chọn phiếu buổi chiều !"),LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			s_ngaylanh="";
            i_traituyen = 0;
			if (chkThuoc.Checked) treeView1.Nodes.Clear();
			bNew=true;
			bEdit=true;
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
            i_duyet = d.get_duyet(s_mmyy, l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}
            if (d.bKhoaso(i_nhom, s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), LibMedi.AccessData.Msg);
                return;
            }

			l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
            get_hoten(cmbMabn.Text);
			ena_object(true);
			mabn.Enabled=false;
			hoten.Enabled=false;
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
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatsd:l_id;
            itable = m.tableid(m.mmyy(s_ngay), "d_hoantrall");
            if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + l_duyet.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngayvv + "^" + lydo.SelectedValue.ToString() + "^" + "1");
            }
			if (l_duyet==0)
			{
				if (i_somay==1)
				{
					if (d.get_data("select id from "+xxx+".d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0].Rows.Count>0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+"\n"+lan.Change_language_MessageText("Khoa")+" "+s_tenkp+"\n"+lan.Change_language_MessageText("Phiếu")+" "+s_tenphieu+"\n"+lan.Change_language_MessageText("Đã nhập !"),LibMedi.AccessData.Msg);
						return;
					}
				}
				else 
				{
					DataTable dtd=d.get_data("select id from "+xxx+".d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0];
					if (dtd.Rows.Count!=0) l_duyet=decimal.Parse(dtd.Rows[0][0].ToString());
					else l_duyet=d.get_id_duyet;
				}
				if (l_duyet==0) l_duyet=d.get_id_duyet;
                d.upd_duyet(s_mmyy, l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makp,0);
                foreach (DataRow r in (iPhatthuoc_kho != 0) ? dtkhofull.Rows : m.get_data("select * from " + user + ".d_dmkho where hide=0 and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    d.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), 0);
			}
            else d.upd_duyet(s_mmyy, l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makp,0);
            d.upd_dausinhton(s_mmyy, l_id, l_idkhoa, l_id, s_ngay, "", "", 0, 0, "", 0, 0, "", "", ghichu.Text,mabn.Text);
            if (!d.upd_hoantrall(s_mmyy, l_id, l_duyet, mabn.Text,l_mavaovien, l_maql, l_idkhoa,s_ngayvv, int.Parse(lydo.SelectedValue.ToString()), 1))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            d.execute_data("update " + user + s_mmyy + ".d_hoantrall set traituyen=" + i_traituyen + " where id=" + l_id);
            itable = m.tableid(m.mmyy(s_ngay), "d_hoantract");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_hoantract", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    m.execute_data_mmyy("update xxx.d_xuatsdct set sltra=sltra-" + r1["soluong"].ToString() + " where id=" + r1["idx"].ToString() + " and stt=" + r1["sttx"].ToString(), s_ngay, m.Ngayhienhanh, true);//bbbb
					d.execute_data("delete from "+xxx+".d_hoantract where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
				}
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                if (m.get_data("select * from " + xxx + ".d_hoantract where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["ngay"].ToString() + "^" + r1["madoituong"].ToString() + "^" + r1["makho"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["soluong"].ToString() + "^" + "0"+"^"+r1["manguon"].ToString());
                }
                else m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                d.upd_hoantract(s_mmyy,l_id, int.Parse(r1["stt"].ToString()), r1["ngay"].ToString(), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), 0, int.Parse(r1["manguon"].ToString()),i_userid);//Thuy 03.02.2012
                //bbbb
                sql = "update " + m.user + s_mmyy + ".d_hoantract set idx=" + r1["idx"].ToString() + ",sttx=" + r1["sttx"].ToString() + " where id=" + l_id + " and stt=" + r1["stt"].ToString();
                d.execute_data(sql);
                d.execute_data_mmyy(" update xxx.d_xuatsdct set sltra=sltra+" + decimal.Parse(r1["soluong"].ToString()) + "-" + (bNew == false ? r1["slcu"].ToString() : "0") + " where id=" + decimal.Parse(r1["idx"].ToString()) + " and mabd=" + int.Parse(r1["mabd"].ToString()) + " and stt=" + r1["sttx"].ToString(), s_ngay, m.Ngayhienhanh, true);
                //
            }
			d.updrec_hoantrall(dtll,l_id,mabn.Text,l_maql,l_idkhoa,hoten.Text,int.Parse(lydo.SelectedValue.ToString()),ghichu.Text,l_mavaovien);
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

		private void Filt_hoten(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listHoten.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,lydo,55);
			}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHoten.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHoten.Visible) listHoten.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			if (l_duyet!=0)
			{
                i_duyet = d.get_duyet(s_mmyy, l_duyet);
				if (i_duyet==0 && dtll.Rows.Count>0)
				{
					DialogResult=MessageBox.Show(lan.Change_language_MessageText("Chuyển số liệu xuống kho ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					if (DialogResult==DialogResult.Yes)
					{
						d.execute_data("update "+xxx+".d_duyet set done=1 where id="+l_duyet);
                        //foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where hide=0 and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                        foreach (DataRow r in dtkhofull.Rows)
                            d.execute_data("update " + xxx + ".d_duyetkho set done=1 where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
						netsend();
					}
					else if (DialogResult==DialogResult.Cancel) return;
				}
			}
			m.close();this.Close();
		}

		private void Filter_mabd(string ma)
		{
			try
			{
                if (listDmbd.DataSource == null || dtct.Rows.Count <= 0) ngay_Validated(null, null);
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
                if (listDmbd.DataSource == null || dtct.Rows.Count<=0) ngay_Validated(null, null);
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
				listDmbd.Tonkhoctht(mabd,tenbd,soluong,ngay.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+ngay.Width+lMabd.Width+treeView1.Width+15,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDmbd.Tonkhoctht(tenbd,mabd,soluong,ngay.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+ngay.Width+lMabd.Width+treeView1.Width+15,mabd.Height+5);
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
						madoituong.SelectedValue=r["madoituong"].ToString();
						manguon.SelectedValue=r["manguon"].ToString();
                        l_idx = decimal.Parse(r["idx"].ToString());
                        i_sttx = int.Parse(r["sttx"].ToString());
					}
				}
				catch{}
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
					hoten.Text=r["hoten"].ToString();
					lydo.SelectedValue=r["lydo"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
                    s_ngayvv = r["ngayvv"].ToString();
					if (chkThuoc.Checked) load_treeview();
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}

		private bool KiemtraHead()
		{
			l_maql=0;
			if (bNew)
			{
				r=d.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập !"),s_msg);
					mabn.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
            //Thuy 18.01.12
            if (d.get_data("select id from " + user + ".xuatkhoa where id=" + r["id"] + "").Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã xuất khoa !"), s_msg);
                mabn.Focus();
                return false;
            }
            //end Thuy 18.01.12
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
				mabn.Focus();
				return false;
			}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),s_msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			l_maql=decimal.Parse(r["maql"].ToString());
			l_idkhoa=decimal.Parse(r["id"].ToString());
            l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
            s_ngayvv = r["ngay"].ToString();
            nam = r["nam"].ToString().Trim();
			if (lydo.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập lý do hoàn trả !"),s_msg);
				lydo.Focus();
				return false;
			}
			if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
				mabn.Focus();
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
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),s_msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),s_msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dston.Tables[0],"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),s_msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
            if (soluong.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"), s_msg);
                soluong.Focus();
                return false;
            }
            else
            {
                decimal sl = decimal.Parse(soluong.Text);
                if (sl == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"), s_msg);
                    soluong.Focus();
                    return false;
                }
            }
            if (ngay.Text != "")
            {
                DataRow r1 = d.getrowbyid(dtdmbd, "id=" + i_mabd + " and ngaytra>0");
                if (r1 != null)
                {
                    decimal songay = m.songay(m.StringToDate(s_ngay), m.StringToDate(ngay.Text), 0);
                    if (songay > decimal.Parse(r1["ngaytra"].ToString()))
                    {
                        MessageBox.Show(r1["ten"].ToString().Trim() + " " + r1["hamluong"].ToString().Trim() + " " + r1["dang"].ToString().Trim() + "\nQui định cho phép trả không quá " + r1["ngaytra"].ToString() + " ngày !(" + songay.ToString() + ")", LibMedi.AccessData.Msg);
                        if (mabd.Enabled) mabd.Focus();
                        else tenbd.Focus();
                        return false;
                    }
                }
            }
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
				mabn.Focus();
				return;
			}
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
			d.updrec_hoantract(dt,int.Parse(stt.Text),madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),ngay.Text,mahc.Text,int.Parse(manguon.SelectedValue.ToString()),dston.Tables[0],l_idx,i_sttx,d_soluongcu,i_userid);//Thuy 03.02.2012
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
                if (soluong.Text.IndexOf("/") != -1)
                {
                    string s1 = soluong.Text.Substring(0, soluong.Text.IndexOf("/")), s2 = soluong.Text.Substring(soluong.Text.IndexOf("/") + 1);
                    if (s1 != "" && s2 != "")
                    {
                        decimal sl = (s2 == "0") ? decimal.Parse(s1) : decimal.Parse(s1) / decimal.Parse(s2);
                        soluong.Text = sl.ToString();
                    }
                }
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(f_soluong);
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dston.Tables[0],"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=d.get_slton_nguon(dston.Tables[0],int.Parse(makho.SelectedValue.ToString()),int.Parse(madoituong.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu,l_idx,i_sttx);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",s_msg);
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
                i_duyet = d.get_duyet(s_mmyy, l_duyet);
				if (i_duyet!=0)
				{
					sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
					MessageBox.Show(sql,s_msg);
					return;
				}
				if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
					cmbMabn.Focus();
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = m.tableid(m.mmyy(s_ngay), "d_hoantract");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_hoantract", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.execute_data_mmyy("update xxx.d_xuatsdct set sltra=sltra-" + r1["soluong"].ToString() + " where id=" + r1["idx"].ToString() + " and stt=" + r1["sttx"].ToString(), s_ngay, m.Ngayhienhanh, true);
                    }
                    itable = m.tableid(m.mmyy(s_ngay), "d_hoantrall");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_hoantrall", "id=" + l_id));
					d.execute_data("delete from "+xxx+".d_hoantract where id="+l_id);
					d.execute_data("delete from "+xxx+".d_hoantrall where id="+l_id);
					d.execute_data("delete from "+xxx+".d_dausinhton where iddutru="+l_id);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count==0) 
					{
						d.execute_data("delete from " + xxx + ".d_duyet where id="+l_duyet);
                        d.execute_data("delete from " + xxx + ".d_duyetkho where idduyet=" + l_duyet);
						l_duyet=0;
					}
					if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}
		
		private void load_treeview()
		{
            if (s_ngayvv == "" || mabn.Text == "" || l_maql == 0) return;
            sql = "select to_char(c.ngay,'yyyymmdd') as ngay,b.mabd,sum(b.slyeucau) as soluong ";
            sql += " from xxx.d_hoantrall a,xxx.d_hoantract b,xxx.d_duyet c," + user + ".d_dmbd d ";
            sql += " where a.id=b.id and a.idduyet=c.id and b.mabd=d.id ";
            sql += " and a.thuoc=1 and a.mabn='" + mabn.Text + "'" + " and c.nhom=" + i_nhom;
            if (i_sudungthuoc == 2) sql += " and a.maql=" + l_maql;
            sql += " group by to_char(c.ngay,'yyyymmdd'),b.mabd";
            treeView1.Nodes.Clear();
            TreeNode node;
            DataTable dtngay = (i_sudungthuoc == 1 && nam != "") ? m.get_data_nam(nam, sql).Tables[0] : m.get_data_mmyy(sql, s_ngayvv.Substring(0, 10), s_ngay.Substring(0, 10), true).Tables[0];
			string ngay="";
			DataRow [] dr;
			foreach(DataRow r1 in dtngay.Rows)
			{
				if (ngay!=r1["ngay"].ToString())
				{
					ngay=r1["ngay"].ToString();
					node=treeView1.Nodes.Add(ngay.Substring(6,2)+"/"+ngay.Substring(4,2)+"/"+ngay.Substring(0,4));
					dr=dtngay.Select("ngay='"+ngay+"'");
					for(int i=0;i<dr.Length;i++)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(dr[i]["mabd"].ToString()));
						if (r!=null) node.Nodes.Add(r["ten"].ToString().Trim()+"/"+r["tenhc"].ToString().Trim()+" "+r["dang"].ToString().Trim()+" ("+dr[i]["soluong"].ToString().Trim()+")");
					}
				}
			}
		}

		private void butChuyen_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==butChuyen)
			{
				if (l_duyet==0) return;
                i_duyet = d.get_duyet(s_mmyy, l_duyet);
				if (i_duyet==2)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được cập nhật bạn không có quyền thay đổi !"),s_msg);
					col_butChuyen(2);
					butChuyen.Checked=true;
					return;
				}
                //Truong hop: khi cung 1 phieu: nhung phat sinh ra nhieu d_duyet.id (do co nhieu may cung nhap lieu) --> gom lai 1 d_duyet.id duy nhat
                string s_idduyet = m.f_get_idduyet(s_mmyy, s_ngay, i_nhom, i_loai, i_phieu, i_makp, l_duyet);
                m.f_chuyen_idduyet(s_mmyy, s_idduyet, l_duyet, i_loai);
                //
				i_duyet=(butChuyen.Checked)?1:0;
				d.execute_data("update "+xxx+".d_duyet set done="+i_duyet+" where id="+l_duyet);
                //foreach (DataRow r in m.get_data("select * from " + user + ".d_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                foreach (DataRow r in dtkhofull.Rows)
                    d.execute_data("update " + xxx + ".d_duyetkho set done=" + i_duyet + " where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
				col_butChuyen(i_duyet);
                d.upd_theodoiduyet(s_mmyy, s_ngay, i_nhom, i_loai, i_makp, i_duyet);
				if (i_duyet==1)
				{
					netsend();
					m.close();this.Close();
				}
				else cmbMabn.Focus();
			}
		}

		private void col_butChuyen(int i)
		{
			butChuyen.ForeColor=(i==2)?Color.Red:(i==1)?Color.Blue:Color.Black;
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngay.Text=="") return;
			ngay.Text=ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngay.Focus();
				return;
			}
			ngay.Text=d.Ktngaygio(ngay.Text,10);
            /*
			if (!d.bNgay(s_ngay,ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày lãnh không được lớn hơn ngày trả !"),d.Msg);
				ngay.Focus();
				return;
			}*/
			if (ngay.Text!=s_ngaylanh)
			{
				s_ngaylanh=ngay.Text;
				load_dm();
			}
		}

		private void lydo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (lydo.SelectedIndex==-1 && lydo.Items.Count>0) lydo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
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
					madoituong.SelectedValue=r["madoituong"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
                    //
                    l_idx = decimal.Parse(r["idx"].ToString());
                    i_sttx = int.Parse(r["sttx"].ToString());
                    //
					listDmbd.Hide();
					soluong.Focus();
				}
			}
			catch{}		
		}

		private void netsend()
		{
			if (d.bTinnhan(i_nhom))
			{
				foreach(DataRow r in dtkho.Rows)
					if (r["computer"].ToString()!="")
						d.netsend(d.sDomain(i_nhom),r["computer"].ToString().Trim(),"DUYET PHIEU HOAN TRA KHOA "+m.khongdau(s_tenkp)+" PHIEU "+m.khongdau(s_tenphieu));
			}
            if (d.bTinnhan_sound(i_nhom))
            {
                foreach (DataRow r in dtkho.Rows)
                    if (r["computer"].ToString() != "")
                        m.upd_tinnhan(r["computer"].ToString().Trim(), "duoc",1);
            }
		}

        private void chkThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkThuoc)
            {
                if (chkThuoc.Checked) load_treeview();
                else treeView1.Nodes.Clear();
            }
        }

        private void get_hoten(string ma)
        {
            DataRow r1, r2;
            sql = "select a.mabn,b.hoten,d.mavaovien,a.id,a.maql,a.giuong,a.mabs,a.maicd,b.nam,to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngay, e.traituyen ";
            sql += " from " + user + ".nhapkhoa a," + user + ".btdbn b," + user + ".xuatvien c," + user + ".benhandt d, " + user + ".bhyt e ";
            sql += " where a.mabn=b.mabn and a.maql=d.maql and a.maql=c.maql(+) and c.ngay is null and a.maql=e.maql(+) and a.mabn='" + ma + "' and a.makp='" + s_makp + "'";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                r1 = m.getrowbyid(dthoten, "mabn='" + ma + "'");
                if (r1 == null)
                {
                    r2 = dthoten.NewRow();
                    r2["mabn"] = r["mabn"].ToString();
                    r2["hoten"] = r["hoten"].ToString();
                    r2["mavaovien"] = r["mavaovien"].ToString();
                    r2["id"] = r["id"].ToString();
                    r2["maql"] = r["maql"].ToString();
                    r2["giuong"] = r["giuong"].ToString();
                    r2["mabs"] = r["mabs"].ToString();
                    r2["maicd"] = r["maicd"].ToString();
                    r2["nam"] = r["nam"].ToString();
                    r2["ngay"] = r["ngay"].ToString();
                    r2["traituyen"] = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
                    dthoten.Rows.Add(r2);
                }
            }
        }
	}
}
