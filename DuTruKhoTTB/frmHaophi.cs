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
	/// Summary description for frmHaophi.
	/// </summary>
	public class frmHaophi : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
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
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.ComboBox cmbMabn;
        private LibTTB.AccessData ttb;
		private int i_nhom,i_makp,i_phieu,i_userid,i_old,i_mabd,i_loai,i_sudungthuoc,i_duyet,i_haophi,tutruc,i_phieucstt,i_somay,itable;
		private string user,xxx,s_makho,s_makp,s_ngay,sql,s_mmyy,s_msg,s_manguon,s_nguon_doituong,s_nhom_doituong,s_makhocstt,s_tenkp,s_tenphieu,f_soluong;
		private decimal l_id=0,l_duyet=0;
		private decimal d_soluongcu,d_soluong,d_soluongton;
		private bool bNew,bEdit,bTutruc,bThuoc,bCstt,bLockytu,bTru_tonao;
		private LibList.List listDmbd;
		private DataRow r;
		private DataTable dtkho=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dttonct=new DataTable();
		private DataTable dtdoituong=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label label19;
		private MaskedTextBox.MaskedTextBox ghichu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.CheckBox butChuyen;
		private System.Windows.Forms.TextBox mahc;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label22;
        private CheckBox chkThuoc;
        private Button butGoi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHaophi(LibTTB.AccessData acc,string ngay,string makho,string makp,int nhom,int loai,int phieu,int imakp,int userid,string mmyy,decimal duyet,string title,string msg,int sudungthuoc,string manguon,bool thuoc,string _tenkp,string _tenphieu,int somay)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            ttb = acc;
			s_ngay=ngay;s_makho=makho;s_makp=makp;i_userid=userid;i_nhom=nhom;
			i_loai=loai;i_somay=somay;i_phieu=phieu;i_makp=imakp;i_sudungthuoc=sudungthuoc;
            s_mmyy = mmyy; s_msg = msg; l_duyet = duyet; s_manguon = manguon; bThuoc = thuoc;
            s_tenkp = _tenkp; s_tenphieu = _tenphieu; this.Text = title; if(ttb.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHaophi));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
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
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
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
            this.butChuyen = new System.Windows.Forms.CheckBox();
            this.mahc = new System.Windows.Forms.TextBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.butGoi = new System.Windows.Forms.Button();
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
            this.treeView1.Location = new System.Drawing.Point(629, 54);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(160, 426);
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 412);
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
            this.tenbd.Location = new System.Drawing.Point(276, 432);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(348, 21);
            this.tenbd.TabIndex = 13;
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
            this.tenhc.Location = new System.Drawing.Point(72, 530);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(552, 21);
            this.tenhc.TabIndex = 14;
            this.tenhc.Visible = false;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(8, 530);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(64, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lTenhc.Visible = false;
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(192, 432);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(48, 21);
            this.mabd.TabIndex = 12;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(240, 432);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(39, 23);
            this.lTen.TabIndex = 69;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(147, 432);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(45, 23);
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
            this.dang.Size = new System.Drawing.Size(80, 21);
            this.dang.TabIndex = 15;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(536, 458);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(88, 21);
            this.soluong.TabIndex = 16;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(480, 458);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 74;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(0, 456);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(72, 23);
            this.ldvt.TabIndex = 73;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(72, 432);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(80, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(0, 432);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 78;
            this.label15.Text = "Đối tượng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(526, 486);
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
            this.butHuy.Location = new System.Drawing.Point(466, 486);
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
            this.butBoqua.Location = new System.Drawing.Point(406, 486);
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
            this.butXoa.Location = new System.Drawing.Point(346, 486);
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
            this.butThem.Location = new System.Drawing.Point(286, 486);
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
            this.butLuu.Location = new System.Drawing.Point(226, 486);
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
            this.butSua.Location = new System.Drawing.Point(166, 486);
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
            this.butMoi.Location = new System.Drawing.Point(36, 486);
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
            this.listDmbd.Location = new System.Drawing.Point(350, 557);
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
            this.label19.Location = new System.Drawing.Point(152, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 23);
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
            this.ghichu.Location = new System.Drawing.Point(208, 6);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(583, 21);
            this.ghichu.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(145, 456);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 23);
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
            this.makho.Location = new System.Drawing.Point(192, 458);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(128, 21);
            this.makho.TabIndex = 97;
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
            this.butChuyen.Location = new System.Drawing.Point(596, 486);
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
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(360, 458);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(120, 21);
            this.manguon.TabIndex = 106;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(315, 456);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 23);
            this.label22.TabIndex = 105;
            this.label22.Text = "Nguồn :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkThuoc
            // 
            this.chkThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThuoc.AutoSize = true;
            this.chkThuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkThuoc.Location = new System.Drawing.Point(629, 33);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(117, 17);
            this.chkThuoc.TabIndex = 132;
            this.chkThuoc.Text = "Các ngày nhập liệu";
            this.chkThuoc.UseVisualStyleBackColor = true;
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // butGoi
            // 
            this.butGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butGoi.Enabled = false;
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(96, 486);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(70, 25);
            this.butGoi.TabIndex = 167;
            this.butGoi.Text = "Chọn &gói";
            this.butGoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // frmHaophi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butGoi);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butChuyen);
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
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.mahc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHaophi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dự trù hao phí thuốc, vật tư y tế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHaophi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHaophi_Load(object sender, System.EventArgs e)
		{
            //this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            user =  ttb.user; 
            xxx = user + s_mmyy;
            bTru_tonao = ttb.bTru_tonao(i_nhom);
            chkThuoc.Checked = i_sudungthuoc != 3;
			bLockytu=ttb.bLockytu_traiphai(i_nhom);
			s_makhocstt=ttb.get_makho(i_nhom,2,(bThuoc)?1:2);
			bCstt=ttb.bcstt_haophi(i_nhom);
            f_soluong = ttb.format_soluong(i_nhom);
			i_haophi=ttb.iHaophi;i_phieucstt=i_phieu;
			DataTable tmp=ttb.get_data("select id from "+user+".ttb_loaiphieu where loai=2 and nhom="+i_nhom+" order by id").Tables[0];
			if (tmp.Rows.Count>0) i_phieucstt=int.Parse(tmp.Rows[0]["id"].ToString());
            dtdmbd = ttb.get_data("select * from " + user + ".ttb_dmbd where nhom=" + i_nhom).Tables[0];
			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";

            dtdoituong = ttb.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdoituong;
			madoituong.SelectedValue=i_haophi.ToString();

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
            if (ttb.bQuanlynguon(i_nhom)) sql = "select * from " + user + ".ttb_dmnguon where nhom=" + i_nhom + " order by stt";
            else sql = "select * from " + user + ".ttb_dmnguon where id=0 or nhom=" + i_nhom + " order by stt";
			manguon.DataSource=ttb.get_data(sql).Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".ttb_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=ttb.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            cmbMabn.DisplayMember="SOPHIEU";
			cmbMabn.ValueMember="ID";

			sql="select a.id,a.sophieu,c.ghichu";
			sql+=" from "+xxx+".ttb_haophill a inner join "+xxx+".ttb_duyet b on a.idduyet=b.id ";
            sql+=" left join "+xxx+".ttb_dausinhton c on a.id=c.iddutru";
			sql+=" where b.id="+l_duyet+" order by a.id";
			dtll=ttb.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			dsxoa.ReadXml("..//..//..//xml//d_haophict.xml");
			if (l_duyet!=0)
			{
				i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
				butChuyen.Checked=i_duyet!=0;
				butChuyen.Enabled=i_duyet!=2;
				if (butChuyen.Enabled) col_butChuyen(i_duyet);
			}
            if (!bTru_tonao) load_dm();
		}

		private void load_grid()
		{
			sql="select a.stt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,'' as cachdung,b.mahc,a.manguon,a.tutruc,0 as idvpkhoa,1 as solan,1 as lan,0 as done ";
            sql += " from " + xxx + ".ttb_haophict a," + user + ".ttb_dmbd b," + user + ".ttb_doituong e," + user + ".ttb_dmkho f where a.mabd=b.id and a.madoituong=e.madoituong and a.makho=f.id and a.id=" + l_id + " order by a.stt";
			dtct=ttb.get_data(sql).Tables[0];
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
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bThuoc)?210:420;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (bThuoc)?210:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 54;
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

			TextCol=new DataGridColoredTextBoxColumn(de,9);
			TextCol.MappingName = "mahc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de,10);
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de,11);
			TextCol.MappingName = "tutruc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,11].ToString().Trim()=="1")	return Color.Blue;
			else return Color.Black;
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
				tenhc.Text=dataGrid1[i,4].ToString();
				dang.Text=dataGrid1[i,5].ToString();
				d_soluong=(dataGrid1[i,6].ToString()!="")?decimal.Parse(dataGrid1[i,6].ToString()):0;
				soluong.Text=d_soluong.ToString(f_soluong);
				madoituong.SelectedValue=dataGrid1[i,7].ToString();
				makho.SelectedValue=dataGrid1[i,8].ToString();
				mahc.Text=dataGrid1[i,9].ToString();
				manguon.SelectedValue=dataGrid1[i,10].ToString();
				tutruc=int.Parse(dataGrid1[i,11].ToString());
				d_soluongcu=d_soluong;
			}
            catch { emp_detail(); }
		}

		private void ena_object(bool ena)
		{
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
			ghichu.Enabled=ena;
			//madoituong.Enabled=ena;
			if (ttb.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
            butGoi.Enabled = ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butChuyen.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
            if (ena && bTru_tonao) load_dm();
		}

		private void emp_head()
		{
			mabn.Text=ttb.get_stt_haophi(i_nhom,i_makp,s_mmyy);
			ghichu.Text="";l_id=0;
			dsxoa.Clear();
		}

		private void emp_detail()
		{
			mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
			soluong.Text="";makho.SelectedIndex=-1;stt.Text=ttb.get_stt(dtct).ToString();
			d_soluongcu=0;madoituong.SelectedValue=i_haophi.ToString();tutruc=0;
		}

		private void load_tonct()
		{
			sql="select a.*,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,t.giaban,b.ten as tennguon,c.ten as tennhomcc from "+xxx+".ttb_tutrucct a,"+user+".ttb_dmnguon b,"+user+".ttb_dmnx c,"+xxx+".ttb_theodoi t where a.sttt=t.id and t.manguon=b.id and t.nhomcc=c.id and a.makp="+i_makp;
			if (s_makhocstt!="") sql+=" and a.makho in ("+s_makhocstt.Substring(0,s_makhocstt.Length-1)+")";
			if (s_manguon!="") sql+=" and t.manguon in ("+s_manguon.Substring(0,s_manguon.Length-1)+")";
			sql+=" order by a.stt";
			dttonct=ttb.get_data(sql).Tables[0];
		}

		private void load_dm()
		{
			dtton=ttb.get_tonkhoth_dutru(s_mmyy,s_makho,s_manguon,i_nhom);
			if (bThuoc && bCstt) updrec();
			listDmbd.DataSource=dtton;
		}

		private void updrec()
		{
			int irec=dtton.Rows.Count+1;
			DataRow r1;
			decimal stt;
			foreach(DataRow r in ttb.get_tutructh_dutru(s_mmyy,i_makp,s_makhocstt,s_manguon,1,i_nhom).Rows)
			{
				r1=dtton.NewRow();
				stt=irec+decimal.Parse(r["stt"].ToString());
				r1["stt"]=stt.ToString();
				r1["tennguon"]=r["tennguon"].ToString();
				r1["ma"]=r["ma"].ToString();
				r1["ten"]=r["ten"].ToString();
				r1["tenhc"]=r["tenhc"].ToString();
				r1["dang"]=r["dang"].ToString();
				r1["tenkho"]="Tủ trực ("+r["tenkho"].ToString().Trim()+")";
				r1["soluong"]=r["soluong"].ToString();
				r1["id"]=r["id"].ToString();
				r1["makho"]=r["makho"].ToString();
				r1["bhyt"]=r["bhyt"].ToString();
				r1["mahc"]=r["mahc"].ToString();
				r1["manguon"]=r["manguon"].ToString();
				r1["tutruc"]="1";
				dtton.Rows.Add(r1);
			}
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=ttb.getrowbyid(dtll,"sophieu='"+mabn.Text+"'");
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

			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			if (chkThuoc.Checked) treeView1.Nodes.Clear();
			bNew=true;
			bEdit=true;
			bTutruc=false;
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
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
			bTutruc=dtct.Select("tutruc=1").Length>0;
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
            itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_haophill");
            if (bNew) ttb.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                ttb.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + l_duyet.ToString() + "^" + mabn.Text);
            }
			if (!bNew && bTutruc && bThuoc) 
			{
                foreach (DataRow r1 in ttb.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien from " + xxx + ".ttb_thucxuat a,"+xxx+".ttb_theodoi b where a.sttt=b.id and a.id=" + l_id).Tables[0].Rows)
					ttb.upd_tonkhoct_thucxuat(ttb.delete,s_mmyy,i_makp,2,1,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
                ttb.execute_data("delete from " + xxx + ".ttb_xuatsdct where id=" + l_id);
                ttb.execute_data("delete from " + xxx + ".ttb_thucxuat where id=" + l_id);
                ttb.execute_data("delete from " + xxx + ".ttb_xuatsdll where id=" + l_id);
			}
			if (l_duyet==0)
			{
				if (i_somay==1)
				{
					if (ttb.get_data("select id from "+xxx+".ttb_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'"+" and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0].Rows.Count>0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+"\n"+lan.Change_language_MessageText("Khoa")+" "+s_tenkp+"\n"+lan.Change_language_MessageText("Phiếu")+" "+s_tenphieu+"\n"+lan.Change_language_MessageText("Đã nhập !"),ttb.Msg);
						return;
					}
				}
				else 
				{
					DataTable dtd=ttb.get_data("select id from "+xxx+".ttb_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'"+" and loai="+i_loai+" and phieu="+i_phieu+" and makhoa="+i_makp).Tables[0];
					if (dtd.Rows.Count!=0) l_duyet=decimal.Parse(dtd.Rows[0][0].ToString());
					else l_duyet=ttb.get_id_duyet;
				}
				if (l_duyet==0) l_duyet=ttb.get_id_duyet;
				ttb.upd_duyet(s_mmyy,l_duyet,i_nhom,s_ngay,i_loai,i_phieu,i_makp,0,i_userid,i_makp);
                foreach (DataRow r in ttb.get_data("select * from " + user + ".ttb_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    ttb.upd_duyetkho(s_mmyy, l_duyet, int.Parse(r["id"].ToString()), 0);
			}
            else ttb.upd_duyet(s_mmyy, l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makp);
			if (ghichu.Text!="") ttb.upd_dausinhton(s_mmyy,l_id,0,l_id,s_ngay,"","",0,0,"",0,0,"","",ghichu.Text);
			else ttb.execute_data("delete from "+xxx+".ttb_dausinhton where id="+l_id);
			if (!ttb.upd_haophill(s_mmyy,l_id,l_duyet,mabn.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_haophict");
			if (!bNew)
			{
                if (bTru_tonao)
                {
                    foreach (DataRow r1 in dtsave.Select("tutruc=0"))
                        ttb.upd_tonkhoth_dutru(ttb.delete, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                }
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    ttb.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "del", ttb.fields(xxx + ".ttb_haophict", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
					ttb.execute_data("delete from "+xxx+".ttb_haophict where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
					if (r1["tutruc"].ToString().Trim()=="0")
						ttb.upd_tonkhoth_dutru(ttb.delete,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
				}
			}
			foreach(DataRow r1 in dtct.Rows)
			{
                if (ttb.get_data("select * from " + xxx + ".ttb_haophict where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    ttb.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["madoituong"].ToString() + "^" + r1["makho"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["soluong"].ToString() + "^" + "0" + "^" + r1["manguon"].ToString() + "^" + r1["tutruc"].ToString());
                }
                else ttb.upd_eve_tables(s_ngay, itable, i_userid, "ins");
				ttb.upd_haophict(s_mmyy,l_id,int.Parse(r1["stt"].ToString()),int.Parse(r1["madoituong"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()),0,int.Parse(r1["manguon"].ToString()),int.Parse(r1["tutruc"].ToString()));
				if (r1["tutruc"].ToString()=="0") 
					ttb.upd_tonkhoth_dutru(ttb.dutru,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
			}
			if (bThuoc)
			{
			#region xuatsd
			if (dtct.Select("soluong>0 and tutruc=1").Length>0)
			{
                itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_xuatsdll");
                if (bNew) ttb.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                else
                {
                    ttb.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + mabn.Text + "^" + "0" + "^" + "0" + "^" + "0" + "^" + s_ngay + "^" + "2" + "^" + i_phieucstt.ToString() + "^" + i_makp.ToString() + "^" + i_userid.ToString() + "^" + l_id.ToString() + "^" + "1" + "^" + i_makp.ToString() + "^" + "0" + "^" + "0" + "^" + "");
                }
				if (!ttb.upd_xuatsdll(s_mmyy,l_id,i_nhom,mabn.Text,0,0,0,s_ngay,2,i_phieucstt,i_makp,i_userid,l_id,1,i_makp,0,0,"",s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh !"),ttb.Msg);
					return;
				}
				ttb.get_xuatsdct_cstt(s_mmyy,dtct.Select("soluong>0 and tutruc=1","stt"),i_makp,i_makp,1,l_id,"",0,0,0,2,1,s_ngay,i_nhom,s_ngay,0);
			}
			#endregion
			}
			ttb.updrec_haophill(dtll,l_id,mabn.Text,ghichu.Text);
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
				if (bLockytu) sql="soluong>0 and ma like '"+ma.Trim()+"%'";
				else sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
				if (madoituong.SelectedIndex!=-1)
				{
					s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
					s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
					s_nhom_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["manhom"].ToString().Trim();
					s_nhom_doituong=(s_nhom_doituong!="")?s_nhom_doituong.Substring(0,s_nhom_doituong.Length-1):"";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
					if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
				}
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
				if (madoituong.SelectedIndex!=-1)
				{
                    //s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
                    //s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
                    //s_nhom_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["manhom"].ToString().Trim();
                    //s_nhom_doituong=(s_nhom_doituong!="")?s_nhom_doituong.Substring(0,s_nhom_doituong.Length-1):"";
                    //if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
                    //if (s_nhom_doituong!="") sql+=" and manhom in ("+s_nhom_doituong+")";
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDmbd.Tonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width+3,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDmbd.Tonkhoct(tenbd,mabd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+madoituong.Width+lMabd.Width+treeView1.Width+3,mabd.Height+5);
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
					r=ttb.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
						makho.SelectedValue=r["makho"].ToString();
						mahc.Text=r["mahc"].ToString().Trim();
						manguon.SelectedValue=r["manguon"].ToString();
						tutruc=int.Parse(r["tutruc"].ToString());
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
				r=ttb.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					mabn.Text=r["sophieu"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					if (chkThuoc.Checked) load_treeview();
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}

		private bool KiemtraHead()
		{
			if (bNew)
			{
				r=ttb.getrowbyid(dtll,"sophieu='"+mabn.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu này đã nhập !"),s_msg);
					mabn.Focus();
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
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (ttb.bNhapmaso) mabd.Enabled=true;
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
			ttb.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			ttb.updrec_haophict(dt,int.Parse(stt.Text),madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,d_soluong,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),mahc.Text,int.Parse(manguon.SelectedValue.ToString()),tutruc,dtton);
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
				soluong.Text=d_soluong.ToString(f_soluong);
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=ttb.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=ttb.get_slton_nguon_tutruc(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),tutruc,d_soluongcu);
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
				if (cmbMabn.Items.Count==0)  return;
				i_duyet=ttb.get_duyet(s_mmyy,l_duyet);
				if (i_duyet!=0)
				{
					sql=(i_duyet==1)?"Số liệu đã chuyển xuống kho bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
					MessageBox.Show(sql,s_msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
					if (bThuoc)
					{                       
						if (dtct.Select("tutruc=1").Length>0)
						{
                            itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_thucxuat");
                            foreach (DataRow r1 in ttb.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien from " + xxx + ".ttb_thucxuat a," + xxx + ".ttb_theodoi b where a.sttt=b.id and a.id=" + l_id).Tables[0].Rows)
                            {
                                ttb.upd_eve_tables(s_ngay, itable, i_userid, "del");
                                ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "del", ttb.fields(xxx + ".ttb_thucxuat", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                                ttb.upd_tonkhoct_thucxuat(ttb.delete, s_mmyy, i_makp, 2, 1, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                            }
                            itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_xuatsdll");
                            ttb.upd_eve_tables(s_ngay, itable, i_userid, "del");
                            ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "del", ttb.fields(xxx + ".ttb_xuatsdll", "id=" + l_id));
                            ttb.execute_data("delete from " + xxx + ".ttb_xuatsdct where id=" + l_id);
                            ttb.execute_data("delete from " + xxx + ".ttb_thucxuat where id=" + l_id);
                            ttb.execute_data("delete from " + xxx + ".ttb_xuatsdll where id=" + l_id);
						}
					}
					foreach(DataRow r1 in dtct.Select("tutruc=0"))
						ttb.upd_tonkhoth_dutru(ttb.delete,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));

                    itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_haophict");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        ttb.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "del", ttb.fields(xxx + ".ttb_haophict", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    }
                    itable = ttb.tableid(ttb.mmyy(s_ngay), "ttb_haophill");
                    ttb.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    ttb.upd_eve_upd_del(s_ngay, itable, i_userid, "del", ttb.fields(xxx + ".ttb_haophill", "id=" + l_id));
					ttb.execute_data("delete from " + xxx + ".ttb_haophict where id="+l_id);
                    ttb.execute_data("delete from " + xxx + ".ttb_haophill where id=" + l_id);
                    ttb.execute_data("delete from " + xxx + ".ttb_dausinhton where iddutru=" + l_id);
					ttb.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count==0) 
					{
                        ttb.execute_data("delete from " + xxx + ".ttb_duyet where id=" + l_duyet);
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
			if (mabn.Text=="") return;
			sql="select to_char(c.ngay,'yyyymmdd') as ngay,b.mabd,sum(b.slyeucau) as soluong ";
            sql += " from " + xxx + ".ttb_haophill a," + xxx + ".ttb_haophict b," + xxx + ".ttb_duyet c,"+user+".ttb_dmbd d ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id ";
			sql+=" and c.makp="+i_makp+" and c.nhom="+i_nhom;
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
                //Truong hop: khi cung 1 phieu: nhung phat sinh ra nhieu d_duyet.id (do co nhieu may cung nhap lieu) --> gom lai 1 d_duyet.id duy nhat
                string s_idduyet = ttb.f_get_idduyet(s_mmyy, s_ngay, i_nhom, i_loai, i_phieu, i_makp, l_duyet);
                ttb.f_chuyen_idduyet(s_mmyy, s_idduyet, l_duyet, i_loai);
                //
				i_duyet=(butChuyen.Checked)?1:0;
				ttb.execute_data("update "+xxx+".ttb_duyet set done="+i_duyet+" where id="+l_duyet);
                foreach (DataRow r in ttb.get_data("select * from " + user + ".ttb_dmkho where id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                    ttb.execute_data("update " + xxx + ".ttb_duyetkho set done=" + i_duyet + " where idduyet=" + l_duyet + " and makho=" + int.Parse(r["id"].ToString()));
				col_butChuyen(i_duyet);
				ttb.upd_theodoiduyet(s_mmyy,s_ngay,i_nhom,i_loai,i_makp,i_duyet);
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

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtton.Select(sql);
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
				r=ttb.getrowbyid(dtton,"stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					mahc.Text=r["mahc"].ToString().Trim();
					manguon.SelectedValue=r["manguon"].ToString();
					tutruc=int.Parse(r["tutruc"].ToString());
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
						ttb.netsend(ttb.sDomain(i_nhom),r["computer"].ToString().Trim(),"DUYET PHIEU HAO PHI KHOA "+ttb.khongdau(s_tenkp)+" PHIEU "+ttb.khongdau(s_tenphieu));
			}
            if (ttb.bTinnhan_sound(i_nhom))
            {
                foreach (DataRow r in dtkho.Rows)
                    if (r["computer"].ToString() != "")
                        ttb.upd_tinnhan(r["computer"].ToString().Trim(), "duoc",1);
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

        private void butGoi_Click(object sender, EventArgs e)
        {
            if (mabn.Text=="")
            {
                mabn.Focus();
                return;
            }
            frmChongoi f = new frmChongoi(ttb,(bThuoc)? -1:-2, i_nhom);
            f.ShowDialog();
            if (f.dt.Rows.Count > 0)
            {
                string s = ""; i_mabd = 0;
                DataRow r1;
                foreach (DataRow r in f.dt.Rows)
                {
                    i_mabd = int.Parse(r["mabd"].ToString());
                    d_soluong = decimal.Parse(r["soluong"].ToString());
                    r1 = ttb.getrowbyid(dtton, "id=" + i_mabd);
                    if (r1 != null)
                    {
                        d_soluongton = ttb.get_slton_nguon(dtton, int.Parse(r1["makho"].ToString()), i_mabd, int.Parse(r1["manguon"].ToString()), 0);
                        if (d_soluong > d_soluongton) s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.000") + ")\n";
                        d_soluong = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                        ttb.updrec_dutruct("-", dtct, ttb.get_stt(dtct),"Hao phí", i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r1["tenkho"].ToString(), d_soluong, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(r1["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r1["manguon"].ToString()), 1, 0, 1, 1, dtton, 0);
                    }
                }
                if (i_mabd != 0 && s != "")
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n") + s, s_msg);
                ref_text();
            }
        }
	}
}
