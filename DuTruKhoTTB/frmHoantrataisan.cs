using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibTTB;
namespace DuTruKhoTTB
{
	/// <summary>
	/// Summary description for frmHoantra.
	/// </summary>
	public class frmHoantrataisan : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.Label lTenhc;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label lMabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label ldvt;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
        private AccessData ttb = new AccessData();
		private int i_nhom,i_makp,i_phieu,i_userid,i_old,i_mabd,i_loai,i_sudungthuoc,i_duyet,i_somay,itable;
		private string s_makho,s_makp,s_ngay,sql,s_mmyy,s_msg,s_manguon,s_tenkp,s_tenphieu,user,xxx;
		private decimal l_id=0,l_duyet=0,l_maql,l_idkhoa;
		private decimal d_soluongcu,d_soluong,d_soluongton;
		private bool bNew,bEdit;
		private DataRow r;
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtkho=new DataTable();
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
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox lydo;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cmbMabn;
		private LibList.List listDmbd;
		private System.Windows.Forms.TextBox losx;
		private System.Windows.Forms.TextBox sttt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox sothe;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHoantrataisan(string ngay,string makho,string makp,int nhom,int loai,int phieu,int imakp,int userid,string mmyy,decimal duyet,string title,string msg,bool Dausinhton,int sudungthuoc,string manguon,string _tenkp,string _tenphieu,int somay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			s_ngay=ngay;s_makho=makho;	s_makp=makp;i_userid=userid;
			i_nhom=nhom;i_loai=loai;i_somay=somay;
			i_phieu=phieu;i_makp=imakp;	i_sudungthuoc=sudungthuoc;
			s_mmyy=mmyy;s_msg=msg;l_duyet=duyet;	
			s_manguon=manguon;s_tenkp=_tenkp;s_tenphieu=_tenphieu;this.Text=title;
            if (ttb.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoantrataisan));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.losx = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.mabd = new System.Windows.Forms.TextBox();
            this.lTen = new System.Windows.Forms.Label();
            this.lMabd = new System.Windows.Forms.Label();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.ghichu = new MaskedTextBox.MaskedTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.butChuyen = new System.Windows.Forms.CheckBox();
            this.mahc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.ComboBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.listDmbd = new LibList.List();
            this.sttt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(64, 6);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(632, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 448);
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
            this.tenbd.Location = new System.Drawing.Point(152, 412);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(472, 21);
            this.tenbd.TabIndex = 5;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(64, 435);
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(240, 21);
            this.losx.TabIndex = 6;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(4, 435);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(59, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "Số hiệu :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(64, 412);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(60, 21);
            this.mabd.TabIndex = 4;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(120, 412);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(32, 23);
            this.lTen.TabIndex = 69;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(32, 412);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(32, 23);
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
            this.dang.Location = new System.Drawing.Point(64, 458);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(50, 21);
            this.dang.TabIndex = 7;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(544, 458);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(80, 21);
            this.soluong.TabIndex = 10;
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
            this.ldvt.Location = new System.Drawing.Point(12, 457);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(51, 23);
            this.ldvt.TabIndex = 73;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(497, 486);
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
            this.butHuy.Location = new System.Drawing.Point(435, 486);
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
            this.butBoqua.Location = new System.Drawing.Point(373, 486);
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
            this.butThem.Location = new System.Drawing.Point(249, 486);
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
            this.butLuu.Location = new System.Drawing.Point(187, 486);
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
            this.butSua.Location = new System.Drawing.Point(125, 486);
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
            this.butMoi.Location = new System.Drawing.Point(63, 486);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 22;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(352, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Ghi chú :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(408, 6);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(376, 21);
            this.ghichu.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(120, 457);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 23);
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
            this.makho.Location = new System.Drawing.Point(152, 458);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(152, 21);
            this.makho.TabIndex = 8;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(640, 432);
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
            this.butChuyen.Location = new System.Drawing.Point(569, 486);
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(136, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
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
            this.lydo.Location = new System.Drawing.Point(184, 6);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(176, 21);
            this.lydo.TabIndex = 2;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydo_KeyDown);
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(349, 458);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(144, 21);
            this.manguon.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(300, 457);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 23);
            this.label22.TabIndex = 105;
            this.label22.Text = "Nguồn :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMabn
            // 
            this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.ItemHeight = 13;
            this.cmbMabn.Location = new System.Drawing.Point(64, 6);
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
            this.listDmbd.Location = new System.Drawing.Point(256, 544);
            this.listDmbd.MatchBufferTimeOut = 1000;
            this.listDmbd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDmbd.Name = "listDmbd";
            this.listDmbd.Size = new System.Drawing.Size(75, 17);
            this.listDmbd.TabIndex = 106;
            this.listDmbd.TextIndex = -1;
            this.listDmbd.TextMember = null;
            this.listDmbd.ValueIndex = -1;
            this.listDmbd.Visible = false;
            this.listDmbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDmbd_KeyDown);
            // 
            // sttt
            // 
            this.sttt.Enabled = false;
            this.sttt.Location = new System.Drawing.Point(312, 352);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(48, 20);
            this.sttt.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(289, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 108;
            this.label2.Text = "Số thẻ  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(349, 435);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(275, 21);
            this.sothe.TabIndex = 109;
            // 
            // frmHoantrataisan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listDmbd);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butChuyen);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.butKetthuc);
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
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.mahc);
            this.Controls.Add(this.sttt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHoantrataisan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoàn trả thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHoantrataisan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHoantrataisan_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = ttb.user; xxx = user + s_mmyy;
			dtdmbd=ttb.get_data("select * from "+user+".ttb_dmbd where nhom="+i_nhom).Tables[0];

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";
			
			lydo.DisplayMember="TEN";
			lydo.ValueMember="ID";
            lydo.DataSource = ttb.get_data("select * from " + user + ".ttb_dmlydo where nhom=" + i_nhom + " order by stt").Tables[0];

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (ttb.bQuanlynguon(i_nhom))
                dtnguon = ttb.get_data("select * from " + user + ".ttb_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                dtnguon = ttb.get_data("select * from " + user + ".ttb_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			manguon.DataSource=dtnguon;

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".ttb_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=ttb.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";

			sql="select a.id,a.mabn,' ' as hoten,a.maql,a.idkhoa,a.lydo,c.ghichu, a.mavaovien ";
			sql+=" from "+xxx+".ttb_hoantrall a inner join "+xxx+".ttb_duyet b on a.idduyet=b.id ";
            sql+=" left join "+xxx+".ttb_dausinhton c on a.id=c.iddutru ";
			sql+=" where a.maql=0 ";
			sql+=" and a.thuoc=2 and b.id="+l_duyet+" order by a.id";
			dtll=ttb.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			//ref_text();
			dsxoa.ReadXml("..//..//..//xml//d_haophict.xml");
			if (l_duyet!=0)
			{
				i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
				butChuyen.Checked=i_duyet!=0;
				butChuyen.Enabled=i_duyet!=2;
				if (butChuyen.Enabled) col_butChuyen(i_duyet);
			}
		}

		private void load_grid()
		{
			sql="select a.stt,' ' as doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,5 as madoituong,a.makho,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.mahc,a.manguon,1 as tutruc,a.sttt,' ' as losx,' ' as sothe ";
            sql += " from " + xxx + ".ttb_hoantract a," + user + ".ttb_dmbd b," + user + ".ttb_dmkho f where a.mabd=b.id and a.makho=f.id and a.id=" + l_id + " order by a.stt";
			dtct=ttb.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
			string s="";
			foreach(DataRow r in dtct.Rows)
			{
				s=ttb.losx_sothe(s_mmyy,decimal.Parse(r["sttt"].ToString()));
				r["losx"]=s.Substring(0,s.IndexOf("^"));
				r["sothe"]=s.Substring(s.IndexOf("^")+1);
			}
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
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = "Kho";
			TextCol.Width = 100;
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
			TextCol.Width = 350;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 0;
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
			TextCol.Width = 60;
			TextCol.Format="#,###,##0.00";
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
			TextCol.HeaderText = "";
			TextCol.Width = 0;
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

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "sttt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
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
				mabd.Text=dataGrid1[i,2].ToString();
				tenbd.Text=dataGrid1[i,3].ToString();
				dang.Text=dataGrid1[i,5].ToString();
				d_soluong=(dataGrid1[i,6].ToString()!="")?decimal.Parse(dataGrid1[i,6].ToString()):0;
				soluong.Text=d_soluong.ToString("###,###,##0.00");
				makho.SelectedValue=dataGrid1[i,8].ToString();
				manguon.SelectedValue=dataGrid1[i,11].ToString();
				mahc.Text=dataGrid1[i,10].ToString();
				sttt.Text=dataGrid1[i,12].ToString();
				losx.Text=dataGrid1[i,13].ToString();
				sothe.Text=dataGrid1[i,14].ToString();
				d_soluongcu=d_soluong;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
			lydo.Enabled=ena;
			ghichu.Enabled=ena;
			if (ttb.bNhapmaso) mabd.Enabled=ena;
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
			butChuyen.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
			if (ena) load_dm();
		}

		private void emp_head()
		{
			mabn.Text=ttb.get_stt(dtll,"mabn").ToString();
			ghichu.Text="";l_id=0;l_maql=0;dsxoa.Clear();
		}

		private void emp_detail()
		{
			mabd.Text="";tenbd.Text="";dang.Text="";mahc.Text="";sttt.Text="0";
			soluong.Text="";stt.Text=ttb.get_stt(dtct).ToString();d_soluongcu=0;losx.Text="";sothe.Text="";
		}

		private void load_dm()
		{
			dtton=ttb.get_tutrucct_dutru(s_mmyy,i_makp,s_makho,s_manguon,0,i_nhom);
			listDmbd.DataSource=dtton;
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=ttb.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu này đã nhập !"),s_msg);
					mabn.Focus();
					return;
				}
			}
			catch{}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (ttb.bKhoaso(i_nhom,s_mmyy))
			{
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), ttb.Msg);
				return;
			}

			i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}

			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			if (i_sudungthuoc!=3) treeView1.Nodes.Clear();
			bNew=true;
			bEdit=true;
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0)return;
			if (ttb.bKhoaso(i_nhom,s_mmyy))
			{
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), ttb.Msg);
				return;
			}

			i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}
            if (ttb.bKhoaso(i_nhom, s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), ttb.Msg);
                return;
            }

			l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			ena_object(true);
			mabn.Enabled=false;
			bNew=false;
			bEdit=true;
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
			l_id=(bNew)?ttb.get_id_xuatsd:l_id;
            itable = ttb.tableid(s_mmyy, "ttb_hoantrall");
            if (bNew) ttb.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                ttb.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                ttb.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", ttb.fields(xxx + ".ttb_hoantrall", "id=" + l_id));
            }
			if (l_duyet==0)
			{
				if (i_somay==1)
				{
					if (ttb.get_data("select id from "+xxx+".ttb_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0].Rows.Count>0)
					{
                        MessageBox.Show(lan.Change_language_MessageText("Ngày") + " " + s_ngay + "\n" + lan.Change_language_MessageText("Khoa") + " " + s_tenkp + "\n" + lan.Change_language_MessageText("Phiếu") + " " + s_tenphieu + "\n" + lan.Change_language_MessageText("Đã nhập !"), ttb.Msg);
						return;
					}
				}
				else 
				{
					DataTable dtd=ttb.get_data("select id from "+xxx+".ttb_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0];
					if (dtd.Rows.Count!=0) l_duyet=decimal.Parse(dtd.Rows[0][0].ToString());
					else l_duyet=ttb.get_id_duyet;
				}
				if (l_duyet==0) l_duyet=ttb.get_id_duyet;
				ttb.upd_duyet(s_mmyy,l_duyet,i_nhom,s_ngay,i_loai,i_phieu,i_makp,0,i_userid,i_makp);
                foreach (DataRow r in ttb.get_data("select * from " + user + ".ttb_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    ttb.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), 0);
			}
			if (ghichu.Text!="") ttb.upd_dausinhton(s_mmyy,l_id,l_idkhoa,l_id,s_ngay,"","",0,0,"",0,0,"","",ghichu.Text);
			else ttb.execute_data("delete from "+xxx+".ttb_dausinhton where iddutru="+l_id);
			if (!ttb.upd_hoantrall(s_mmyy,l_id,l_duyet,mabn.Text,0,l_maql,l_idkhoa,s_ngay,int.Parse(lydo.SelectedValue.ToString()),2))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            itable = ttb.tableid(s_mmyy, "ttb_hoantract");
			if (!bNew)
			{
                foreach (DataRow r1 in dsxoa.Tables[0].Rows)
                {
                    ttb.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    ttb.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", ttb.fields(xxx + ".ttb_hoantract", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    ttb.execute_data("delete from " + xxx + ".ttb_hoantract where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                }
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                if (ttb.get_data("select * from " + xxx + ".ttb_hoantract where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    ttb.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    ttb.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd",ttb.fields(xxx+".ttb_hoantract","id="+l_id+" and stt="+int.Parse(r1["stt"].ToString())));
                }
                else ttb.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                ttb.upd_hoantract(s_mmyy,l_id, int.Parse(r1["stt"].ToString()),s_ngay, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), 0, int.Parse(r1["manguon"].ToString()), decimal.Parse(r1["sttt"].ToString()));
            }
			ttb.updrec_hoantrall(dtll,l_id,mabn.Text,l_maql,l_idkhoa,"",int.Parse(lydo.SelectedValue.ToString()),ghichu.Text,0);
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
			if (l_duyet!=0)
			{
				i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
				if (i_duyet==0 && dtll.Rows.Count>0)
				{
                    DialogResult = MessageBox.Show(lan.Change_language_MessageText("Chuyển số liệu xuống kho ?"), ttb.Msg, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (DialogResult==DialogResult.Yes)
					{
						ttb.execute_data("update "+xxx+".ttb_duyet set done=1 where id="+l_duyet);
                        foreach (DataRow r in ttb.get_data("select * from " + user + ".ttb_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                            ttb.execute_data("update " + xxx + ".ttb_duyetkho set done=1 where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
						netsend();
					}
					else if (DialogResult==DialogResult.Cancel) return;
				}
			}
			ttb.close();this.Close();
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
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
				sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
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
				listDmbd.Tutrucct_taisan(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+treeView1.Width+5,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDmbd.Tutrucct_taisan(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+treeView1.Width+5,mabd.Height+5);
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
					r=ttb.getrowbyid(dtton,"stt="+decimal.Parse(mabd.Text));
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						dang.Text=r["dang"].ToString();
						mahc.Text=r["mahc"].ToString();
						makho.SelectedValue=r["makho"].ToString();
						manguon.SelectedValue=r["manguon"].ToString();
						sttt.Text=r["sttt"].ToString();
						losx.Text=r["losx"].ToString();
						sothe.Text=r["sothe"].ToString();
					}
				}
				catch{}//(Exception ex){MessageBox.Show(ex.Message);}
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
				r=ttb.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					mabn.Text=r["mabn"].ToString();
					lydo.SelectedValue=r["lydo"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
					if (i_sudungthuoc!=3) load_treeview();
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}

		private bool KiemtraHead()
		{
			if (mabn.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Số phiếu !"),s_msg);
				mabn.Focus();
				return false;
			}
			l_maql=0;l_idkhoa=0;
			if (lydo.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập lý do hoàn trả !"),s_msg);
				lydo.Focus();
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
			r=ttb.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),s_msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),s_msg);
				soluong.Focus();
				return false;
			}
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (ttb.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
			if (!upd_table(dtct)) return;
			emp_detail();
			mabd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0])) return;
			ttb.delrec(dtct,"stt="+decimal.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			ttb.updrec_hoantra_taisan(dt,int.Parse(stt.Text),"",i_mabd,mabd.Text,tenbd.Text,"",dang.Text,makho.Text,d_soluong,5,int.Parse(makho.SelectedValue.ToString()),mahc.Text,int.Parse(manguon.SelectedValue.ToString()),1,(sttt.Text!="")?decimal.Parse(sttt.Text):0,losx.Text,sothe.Text,dtton);
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
					r=ttb.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=ttb.get_slton_nguon(dtton,(sttt.Text!="")?decimal.Parse(sttt.Text):0,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
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
				if (cmbMabn.Items.Count==0)return;
				if (ttb.bKhoaso(i_nhom,s_mmyy))
				{
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm ") + s_mmyy.Substring(2, 2) + lan.Change_language_MessageText(" đã khóa !"), ttb.Msg);
					return;
				}
				i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
				if (i_duyet!=0)
				{
					sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
					MessageBox.Show(sql,s_msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = ttb.tableid(s_mmyy, "ttb_hoantract");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        ttb.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        ttb.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", ttb.fields(xxx + ".ttb_hoantract", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    }
                    itable = ttb.tableid(s_mmyy, "ttb_hoantrall");
                    ttb.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    ttb.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", ttb.fields(xxx + ".ttb_hoantrall", "id=" + l_id));
					ttb.execute_data("delete from "+xxx+".ttb_hoantract where id="+l_id);
					ttb.execute_data("delete from "+xxx+".ttb_hoantrall where id="+l_id);
					ttb.execute_data("delete from "+xxx+".ttb_dausinhton where iddutru="+l_id);
					ttb.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count==0)
					{
						ttb.execute_data("delete from "+xxx+".ttb_duyet where id="+l_duyet);
                        ttb.execute_data("delete from " + xxx + ".ttb_duyetkho where idduyet=" + l_duyet);
						l_duyet=0;
					}
					if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void load_treeview()
		{
			if ((mabn.Text=="") || (i_sudungthuoc==2 && l_maql==0)) return;
			sql="select to_char(c.ngay,'yyyymmdd') as ngay,b.mabd,sum(b.slyeucau) as soluong ";
			sql+=" from "+xxx+".ttb_hoantrall a,"+xxx+".ttb_hoantract b,"+xxx+".ttb_duyet c,"+user+".ttb_dmbd d ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id ";
			sql+=" and c.nhom="+i_nhom+" and a.maql=0 and a.thuoc=2";
			if (i_sudungthuoc==2) sql+=" and a.maql="+l_maql;
			sql+=" group by c.ngay,b.mabd order by c.ngay desc,b.mabd";
			treeView1.Nodes.Clear();
			TreeNode node;
			DataTable dtngay=ttb.get_data(sql).Tables[0];
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
						r=ttb.getrowbyid(dtdmbd,"id="+int.Parse(dr[i]["mabd"].ToString()));
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
				i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
				if (i_duyet==2)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được cập nhật bạn không có quyền thay đổi !"),s_msg);
					col_butChuyen(2);
					butChuyen.Checked=true;
					return;
				}
				i_duyet=(butChuyen.Checked)?1:0;
				ttb.execute_data("update "+xxx+".ttb_duyet set done="+i_duyet+" where id="+l_duyet);
                foreach (DataRow r in ttb.get_data("select * from " + user + ".ttb_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    ttb.execute_data("update " + xxx + ".ttb_duyetkho set done=" + i_duyet + " where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
				col_butChuyen(i_duyet);
                ttb.upd_theodoiduyet(s_mmyy, s_ngay, i_nhom, i_loai, i_makp, i_duyet);
				if (i_duyet==1)
				{
					netsend();
					ttb.close();this.Close();
				}
				else cmbMabn.Focus();
			}
		}

		private void col_butChuyen(int i)
		{
			butChuyen.ForeColor=(i==2)?Color.Red:(i==1)?Color.Blue:Color.Black;
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
				DataRow [] dr=dtton.Select("ma like '"+mabd.Text.Trim()+"%'");
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(decimal.Parse(mabd.Text));
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
				get_items(decimal.Parse(listDmbd.Text));
			}
			catch{}
		}

		private void get_items(decimal stt)
		{
			try
			{
				r=ttb.getrowbyid(dtton,"stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					sttt.Text=r["sttt"].ToString();
					losx.Text=r["losx"].ToString();
					sothe.Text=r["sothe"].ToString();
					listDmbd.Hide();
					soluong.Focus();
				}
			}
			catch{}		
		}
		private void netsend()
		{
			if (ttb.bTinnhan(i_nhom))
			{
				foreach(DataRow r in dtkho.Rows)
					if (r["computer"].ToString()!="")
						ttb.netsend(ttb.sDomain(i_nhom),r["computer"].ToString().Trim(),"DUYET PHIEU HOAN TRA KHOA "+ttb.khongdau(s_tenkp)+" PHIEU "+ttb.khongdau(s_tenphieu));
			}
            if (ttb.bTinnhan_sound(i_nhom))
            {
                foreach (DataRow r in dtkho.Rows)
                    if (r["computer"].ToString() != "")
                        ttb.upd_tinnhan(r["computer"].ToString().Trim(), "duoc",1);
            }
		}
	}
}
