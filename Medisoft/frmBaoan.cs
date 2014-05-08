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
	/// Summary description for frmBaoan.
	/// </summary>
	public class frmBaoan : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox manv;
        private System.Windows.Forms.TextBox tennv;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label lTenhc;
        private System.Windows.Forms.TextBox ma;
        private System.Windows.Forms.Label lMabd;
		private MaskedTextBox.MaskedTextBox soluong;
        private System.Windows.Forms.Label label16;
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
		private System.Windows.Forms.Button butCholai;
		private System.Windows.Forms.ComboBox cmbMabn;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private int i_phieu,i_userid,i_old,i_idthucdon,i_madoituong,i_duyet,itable;
		private string user,xxx,nam="",s_ngayvv="",s_makp,s_ngay,sql,s_mmyy,s_msg,s_tenkp,s_tenphieu,s_maicd="",s_mabs,s_title;
		private decimal l_id=0,l_duyet=0,l_maql,l_idkhoa;
        private bool bNew,bMadoituong,bNhapten, bPhonggiuong;
		private LibList.List listDmbd;
		private LibList.List listHoten;
        private LibList.List listNv;
		private DataRow r;
		private DataTable dthoten=new DataTable();
		private DataTable dtnv=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dttd=new DataTable();
		private DataTable dtdoituong=new DataTable();
        private DataTable dtgia = new DataTable();
        private DataSet dsxoa = new DataSet();
        private DataTable dtchedo = new DataTable();
        private System.Windows.Forms.Label label18;
        private MaskedTextBox.MaskedTextBox giuong;
        private System.Windows.Forms.TextBox stt;
        private System.Windows.Forms.CheckBox butChuyen;
        private System.Windows.Forms.TextBox mahc;
        private System.Windows.Forms.CheckBox chkmadt_def;
        private CheckBox chkThuoc;
        private TextBox tim;
        private Label label5;
        private ComboBox idcu;
        private CheckBox dacbiet;
        private Label label6;
        private TextBox chandoan;
        private Label label7;
        private ComboBox idgioan;
        private MaskedTextBox.MaskedTextBox e;
        private MaskedTextBox.MaskedTextBox p;
        private MaskedTextBox.MaskedTextBox l;
        private MaskedTextBox.MaskedTextBox g;
        private Label label9;
        private Label label10;
        private Label label11;
        private MaskedTextBox.MaskedTextBox dongia;
        private Button butList;
        private ComboBox idchedoan;
        private Label label8;
        private Label label12;
        private CheckBox moi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBaoan(string ngay,string makp,int phieu,int userid,string mmyy,decimal duyet,string title,string msg,string _tenkp,string _tenphieu,string _mabs)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
			s_ngay=ngay;s_makp=makp;i_userid=userid;
			i_phieu=phieu;s_mmyy=mmyy;s_msg=msg;
			l_duyet=duyet;s_tenkp=_tenkp;s_tenphieu=_tenphieu;
            this.Text = title; s_title = title; s_mabs = _mabs;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoan));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.manv = new MaskedTextBox.MaskedTextBox();
            this.tennv = new System.Windows.Forms.TextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ten = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.lMabd = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
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
            this.butCholai = new System.Windows.Forms.Button();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.giuong = new MaskedTextBox.MaskedTextBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.butChuyen = new System.Windows.Forms.CheckBox();
            this.mahc = new System.Windows.Forms.TextBox();
            this.chkmadt_def = new System.Windows.Forms.CheckBox();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idcu = new System.Windows.Forms.ComboBox();
            this.dacbiet = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.idgioan = new System.Windows.Forms.ComboBox();
            this.e = new MaskedTextBox.MaskedTextBox();
            this.p = new MaskedTextBox.MaskedTextBox();
            this.l = new MaskedTextBox.MaskedTextBox();
            this.g = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.listNv = new LibList.List();
            this.listHoten = new LibList.List();
            this.listDmbd = new LibList.List();
            this.butList = new System.Windows.Forms.Button();
            this.idchedoan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.moi = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 6);
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
            this.mabn.Size = new System.Drawing.Size(84, 21);
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
            this.hoten.Location = new System.Drawing.Point(175, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(175, 21);
            this.hoten.TabIndex = 2;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(348, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bác sĩ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(573, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "ĐDV :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mabs.Location = new System.Drawing.Point(398, 6);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(35, 21);
            this.mabs.TabIndex = 3;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(434, 6);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(143, 21);
            this.tenbs.TabIndex = 4;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // manv
            // 
            this.manv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manv.Enabled = false;
            this.manv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.manv.Location = new System.Drawing.Point(612, 6);
            this.manv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(36, 21);
            this.manv.TabIndex = 5;
            this.manv.Validated += new System.EventHandler(this.manv_Validated);
            // 
            // tennv
            // 
            this.tennv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv.Enabled = false;
            this.tennv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv.Location = new System.Drawing.Point(649, 6);
            this.tennv.Name = "tennv";
            this.tennv.Size = new System.Drawing.Size(142, 21);
            this.tennv.TabIndex = 6;
            this.tennv.TextChanged += new System.EventHandler(this.tennv_TextChanged);
            this.tennv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // treeView
            // 
            this.treeView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(629, 94);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(162, 337);
            this.treeView.TabIndex = 26;
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 34);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 397);
            this.dataGrid1.TabIndex = 28;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(271, 437);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(355, 21);
            this.ten.TabIndex = 14;
            this.ten.Validated += new System.EventHandler(this.tenbd_Validated);
            this.ten.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // lTenhc
            // 
            this.lTenhc.Location = new System.Drawing.Point(274, 458);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(157, 23);
            this.lTenhc.TabIndex = 70;
            this.lTenhc.Text = "E :                   kcal";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(184, 437);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(84, 21);
            this.ma.TabIndex = 13;
            this.ma.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lMabd
            // 
            this.lMabd.Location = new System.Drawing.Point(120, 437);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(64, 23);
            this.lMabd.TabIndex = 68;
            this.lMabd.Text = "Thực đơn :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(631, 460);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(35, 21);
            this.soluong.TabIndex = 20;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(571, 460);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 23);
            this.label16.TabIndex = 74;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(175, 28);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(81, 21);
            this.madoituong.TabIndex = 8;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(104, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 78;
            this.label15.Text = "Đối tượng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(620, 486);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 31;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(551, 486);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 30;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(483, 486);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(69, 25);
            this.butBoqua.TabIndex = 25;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(414, 486);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(69, 25);
            this.butXoa.TabIndex = 23;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(345, 486);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(69, 25);
            this.butThem.TabIndex = 22;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(276, 486);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(69, 25);
            this.butLuu.TabIndex = 24;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(207, 486);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(69, 25);
            this.butSua.TabIndex = 27;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(138, 486);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(69, 25);
            this.butMoi.TabIndex = 26;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butCholai
            // 
            this.butCholai.Enabled = false;
            this.butCholai.Image = ((System.Drawing.Image)(resources.GetObject("butCholai.Image")));
            this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCholai.Location = new System.Drawing.Point(0, 486);
            this.butCholai.Name = "butCholai";
            this.butCholai.Size = new System.Drawing.Size(69, 25);
            this.butCholai.TabIndex = 28;
            this.butCholai.Text = "&Cho lại";
            this.butCholai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCholai.Click += new System.EventHandler(this.butCholai_Click);
            // 
            // cmbMabn
            // 
            this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(48, 6);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(84, 21);
            this.cmbMabn.TabIndex = 0;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(-1, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 23);
            this.label18.TabIndex = 94;
            this.label18.Text = "Giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(48, 28);
            this.giuong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giuong.MaxLength = 10;
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(69, 21);
            this.giuong.TabIndex = 7;
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(640, 370);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 98;
            // 
            // butChuyen
            // 
            this.butChuyen.Appearance = System.Windows.Forms.Appearance.Button;
            this.butChuyen.Image = ((System.Drawing.Image)(resources.GetObject("butChuyen.Image")));
            this.butChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyen.Location = new System.Drawing.Point(689, 486);
            this.butChuyen.Name = "butChuyen";
            this.butChuyen.Size = new System.Drawing.Size(102, 25);
            this.butChuyen.TabIndex = 32;
            this.butChuyen.Text = "     Chuyển nhà ăn";
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
            // chkmadt_def
            // 
            this.chkmadt_def.Enabled = false;
            this.chkmadt_def.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkmadt_def.Location = new System.Drawing.Point(631, 434);
            this.chkmadt_def.Name = "chkmadt_def";
            this.chkmadt_def.Size = new System.Drawing.Size(111, 24);
            this.chkmadt_def.TabIndex = 107;
            this.chkmadt_def.Text = "Đối tượng khi vào";
            this.chkmadt_def.CheckedChanged += new System.EventHandler(this.chkmadt_def_CheckedChanged);
            // 
            // chkThuoc
            // 
            this.chkThuoc.AutoSize = true;
            this.chkThuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkThuoc.Location = new System.Drawing.Point(631, 76);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(107, 17);
            this.chkThuoc.TabIndex = 130;
            this.chkThuoc.Text = "Các ngày báo ăn";
            this.chkThuoc.UseVisualStyleBackColor = true;
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(629, 53);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(162, 21);
            this.tim.TabIndex = 136;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(249, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 23);
            this.label5.TabIndex = 137;
            this.label5.Text = "Cữ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // idcu
            // 
            this.idcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idcu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idcu.Enabled = false;
            this.idcu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idcu.Location = new System.Drawing.Point(281, 521);
            this.idcu.Name = "idcu";
            this.idcu.Size = new System.Drawing.Size(69, 21);
            this.idcu.TabIndex = 9;
            this.idcu.Visible = false;
            this.idcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idcu_KeyDown);
            // 
            // dacbiet
            // 
            this.dacbiet.AutoSize = true;
            this.dacbiet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dacbiet.Enabled = false;
            this.dacbiet.Location = new System.Drawing.Point(298, 33);
            this.dacbiet.Name = "dacbiet";
            this.dacbiet.Size = new System.Drawing.Size(66, 17);
            this.dacbiet.TabIndex = 10;
            this.dacbiet.Text = "Đặc biệt";
            this.dacbiet.UseVisualStyleBackColor = true;
            this.dacbiet.CheckedChanged += new System.EventHandler(this.dacbiet_CheckedChanged);
            this.dacbiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(359, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 140;
            this.label6.Text = "Chẩn đoán :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(434, 28);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(357, 21);
            this.chandoan.TabIndex = 11;
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-5, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 23);
            this.label7.TabIndex = 142;
            this.label7.Text = "Giờ ăn :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idgioan
            // 
            this.idgioan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idgioan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idgioan.Enabled = false;
            this.idgioan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idgioan.Location = new System.Drawing.Point(48, 437);
            this.idgioan.Name = "idgioan";
            this.idgioan.Size = new System.Drawing.Size(69, 21);
            this.idgioan.TabIndex = 12;
            this.idgioan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idgioan_KeyDown);
            // 
            // e
            // 
            this.e.BackColor = System.Drawing.SystemColors.HighlightText;
            this.e.Enabled = false;
            this.e.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.e.Location = new System.Drawing.Point(293, 460);
            this.e.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(51, 21);
            this.e.TabIndex = 16;
            this.e.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.e.Validated += new System.EventHandler(this.e_Validated);
            this.e.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.SystemColors.HighlightText;
            this.p.Enabled = false;
            this.p.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p.Location = new System.Drawing.Point(393, 460);
            this.p.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(30, 21);
            this.p.TabIndex = 17;
            this.p.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.p.Validated += new System.EventHandler(this.p_Validated);
            this.p.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // l
            // 
            this.l.BackColor = System.Drawing.SystemColors.HighlightText;
            this.l.Enabled = false;
            this.l.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.Location = new System.Drawing.Point(460, 460);
            this.l.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(30, 21);
            this.l.TabIndex = 18;
            this.l.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.l.Validated += new System.EventHandler(this.l_Validated);
            this.l.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // g
            // 
            this.g.BackColor = System.Drawing.SystemColors.HighlightText;
            this.g.Enabled = false;
            this.g.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g.Location = new System.Drawing.Point(528, 460);
            this.g.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(30, 21);
            this.g.TabIndex = 19;
            this.g.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.g.Validated += new System.EventHandler(this.g_Validated);
            this.g.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(442, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 23);
            this.label9.TabIndex = 149;
            this.label9.Text = "L :            %";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(508, 460);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 23);
            this.label10.TabIndex = 150;
            this.label10.Text = "G :            %";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(662, 460);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 23);
            this.label11.TabIndex = 151;
            this.label11.Text = "Đơn giá :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(721, 460);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(68, 21);
            this.dongia.TabIndex = 21;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(208, 542);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 91;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
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
            // listDmbd
            // 
            this.listDmbd.BackColor = System.Drawing.SystemColors.Info;
            this.listDmbd.ColumnCount = 0;
            this.listDmbd.Location = new System.Drawing.Point(366, 542);
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
            // butList
            // 
            this.butList.Enabled = false;
            this.butList.Image = ((System.Drawing.Image)(resources.GetObject("butList.Image")));
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(69, 486);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(69, 25);
            this.butList.TabIndex = 29;
            this.butList.Text = "Liệt &kê";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // idchedoan
            // 
            this.idchedoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idchedoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idchedoan.Enabled = false;
            this.idchedoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idchedoan.Location = new System.Drawing.Point(49, 460);
            this.idchedoan.Name = "idchedoan";
            this.idchedoan.Size = new System.Drawing.Size(219, 21);
            this.idchedoan.TabIndex = 15;
            this.idchedoan.SelectedIndexChanged += new System.EventHandler(this.idchedoan_SelectedIndexChanged);
            this.idchedoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idchedoan_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(374, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 23);
            this.label8.TabIndex = 145;
            this.label8.Text = "P :            %";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-15, 459);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 153;
            this.label12.Text = "Chế độ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // moi
            // 
            this.moi.AutoSize = true;
            this.moi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.moi.Enabled = false;
            this.moi.Location = new System.Drawing.Point(256, 32);
            this.moi.Name = "moi";
            this.moi.Size = new System.Drawing.Size(43, 17);
            this.moi.TabIndex = 9;
            this.moi.Text = "Mới";
            this.moi.UseVisualStyleBackColor = true;
            this.moi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // frmBaoan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.dacbiet);
            this.Controls.Add(this.moi);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.g);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.l);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.idchedoan);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.p);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.e);
            this.Controls.Add(this.idgioan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.idcu);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.chkmadt_def);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.butChuyen);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.listDmbd);
            this.Controls.Add(this.butCholai);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.tennv);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.mahc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu báo ăn";
            this.Load += new System.EventHandler(this.frmBaoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBaoan_Load(object sender, System.EventArgs e)
		{
            this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            user = d.user; xxx = user + s_mmyy;
            bNhapten = m.bNhapthuoc_ten;
            bPhonggiuong = m.bPhonggiuong;
            dtgia = m.get_data("select * from " + user + ".di_giabenhly order by tu,den").Tables[0];
			dttd=m.getdmthucdon(s_ngay);
			dthoten=m.get_hiendien(s_makp,s_ngay).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;

            dtchedo = d.get_data("select * from " + user + ".di_dmchedoan order by stt").Tables[0];
            idchedoan.DisplayMember = "TEN";
            idchedoan.ValueMember = "ID";
            idchedoan.DataSource = dtchedo;

            dtnv = d.get_data("select ma,hoten,nhom from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="ID";
            listDmbd.DataSource = dttd;

            idcu.DisplayMember = "TEN";
            idcu.ValueMember = "ID";
            idcu.DataSource = d.get_data("select * from " + user + ".di_dmcu order by stt").Tables[0];

            idgioan.DisplayMember = "TEN";
            idgioan.ValueMember = "ID";
            idgioan.DataSource = d.get_data("select * from " + user + ".di_dmgioan order by stt").Tables[0];
            
            dtdoituong = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdoituong;
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";

            sql = "select a.id,a.mabn,d.hoten,a.maql,a.idkhoa,to_char(b.ngay,'dd/mm/yyyy') as ngayvv,";
            sql+="a.madoituong,a.idcu,a.moi,a.dacbiet,a.giuong,a.maicd,a.chandoan,a.mabs,a.yta";
			sql+=" from "+xxx+".di_kthucdonll a inner join "+xxx+".di_duyet b on a.idduyet=b.id ";
            sql+=" inner join "+user+".btdbn d on a.mabn=d.mabn ";
			sql+=" where b.id="+l_duyet+" order by a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			//ref_text();
			dsxoa.ReadXml("..//..//..//xml//di_kthucdonct.xml");
			if (l_duyet!=0)
			{
                i_duyet = m.get_duyetnhaan(s_mmyy, l_duyet);
				butChuyen.Checked=i_duyet!=0;
				butChuyen.Enabled=i_duyet!=2;
				if (butChuyen.Enabled) col_butChuyen(i_duyet);
			}
		}

		private void load_grid()
		{
			sql="select a.stt,a.idgioan,a.idthucdon,c.ten as gioan,";
            sql+=" case when b.ma is null then '' else b.ma end as ma,";
            sql+=" case when b.ma is null then 'Bệnh lý : '||d.ten else b.ten end as tenthucdon,";
            sql+="a.e,a.p,a.l,a.g,a.idchedoan,a.soluong,a.dongia,a.soluong*a.dongia as sotien ";
            sql += " from " + xxx + ".di_kthucdonct a left join " + user + ".di_dmthucdon b on a.idthucdon=b.id ";
            sql += " inner join "+ user + ".di_dmgioan c on a.idgioan=c.id ";
            sql += " inner join "+ user + ".di_dmchedoan d on a.idchedoan=d.id where a.id=" + l_id + " order by a.stt";
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
			TextCol.MappingName = "gioan";
			TextCol.HeaderText = "Giờ ăn";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "tenthucdon";
			TextCol.HeaderText = "Thực đơn";
			TextCol.Width = 250;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "e";
			TextCol.HeaderText = "E (kcal)";
			TextCol.Width = 60;
            TextCol.Format = "### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "p";
			TextCol.HeaderText = "P (%)";
			TextCol.Width = 40;
            TextCol.Format = "###";
            TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "l";
			TextCol.HeaderText = "L (%)";
			TextCol.Width = 40;
            TextCol.Format = "###";
            TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "g";
			TextCol.HeaderText = "G (%)";
			TextCol.Width = 40;
            TextCol.Format = "###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "SL";
            TextCol.Width = 30; 
            TextCol.Format = "##0";
            TextCol.Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 60;
            TextCol.Format = "### ### ##0";
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
                DataRow r = d.getrowbyid(dtct, "stt=" + int.Parse(stt.Text));
                if (r != null)
                {
                    idgioan.SelectedValue = r["idgioan"].ToString();
                    ma.Text = r["ma"].ToString();
                    ten.Text = r["tenthucdon"].ToString();
                    e.Text = r["e"].ToString();
                    p.Text = r["p"].ToString();
                    l.Text = r["l"].ToString();
                    g.Text = r["g"].ToString();
                    idchedoan.SelectedValue = r["idchedoan"].ToString();
                    soluong.Text = r["soluong"].ToString();
                    dongia.Text = r["dongia"].ToString();
                }
			}
            catch { emp_detail(); }
		}

		private void ena_object(bool ena)
		{
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
			if (bNhapten) hoten.Enabled=ena;
			mabs.Enabled=ena;
			manv.Enabled=ena;
			tenbs.Enabled=ena;
			tennv.Enabled=ena;
            giuong.Enabled = ena;
			ma.Enabled=ena;
            tim.Enabled = !ena;
			chkmadt_def.Enabled=ena;
			ten.Enabled=ena;
            moi.Enabled = ena;
            //idcu.Enabled = ena;
            dacbiet.Enabled = ena;
            chandoan.Enabled = ena;
            idgioan.Enabled = ena;
            e.Enabled = ena;
            p.Enabled = ena;
            l.Enabled = ena;
            g.Enabled = ena;
            idchedoan.Enabled = ena;
			soluong.Enabled=ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butCholai.Enabled=ena;
            butList.Enabled = ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butChuyen.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
            if (s_mabs != "")
            {
                DataRow r = m.getrowbyid(dtnv, "ma='" + s_mabs + "'");
                if (r != null)
                {
                    if (int.Parse(r["nhom"].ToString()) == LibMedi.AccessData.nhanvien)
                    {
                        manv.Text = s_mabs; tennv.Text = r["hoten"].ToString();
                        manv.Enabled = false; tennv.Enabled = false;
                    }
                    else
                    {
                        mabs.Text = s_mabs; tenbs.Text = r["hoten"].ToString();
                        mabs.Enabled = false; tenbs.Enabled = false;
                    }
                }
            }
		}

		private void emp_head()
		{
            mabn.Text = ""; hoten.Text = ""; s_ngayvv = ""; nam = "";
            giuong.Text = ""; dacbiet.Checked = false; chandoan.Text = ""; ena_dacbiet();
            l_id = 0; l_maql = 0; moi.Checked = false;
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
            dsxoa.Clear();
		}

		private void emp_detail()
		{
            ma.Text = ""; ten.Text = ""; e.Text = ""; p.Text = ""; l.Text = ""; g.Text = "";
            soluong.Text = "1"; stt.Text = d.get_stt(dtct).ToString(); dongia.Text = "";
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
            nam = ""; s_ngayvv = ""; s_maicd = "";
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			DataRow r1;
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
                nam = r["nam"].ToString();
				hoten.Text=r["hoten"].ToString();
                s_ngayvv = r["ngay"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["id"].ToString());
				giuong.Text=r["giuong"].ToString().Trim();
                s_maicd = r["maicd"].ToString();
                chandoan.Text = r["chandoan"].ToString();
                if (mabs.Enabled)
                {
                    mabs.Text = r["mabs"].ToString();
                    r1 = d.getrowbyid(dtnv, "ma='" + mabs.Text + "'");
                    if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                    else tenbs.Text = "";
                }
                moi.Checked = s_ngayvv == s_ngay;
                i_madoituong = int.Parse(r["madoituong"].ToString());
				if (dtct.Rows.Count==0 && i_madoituong!=0) madoituong.SelectedValue=i_madoituong.ToString();
			}
			else{hoten.Text="";l_maql=0;l_idkhoa=0;}
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
			sql="select * from "+xxx+".di_kthucdonll where mabn='"+mabn.Text+"'";
			sql+=" order by id desc";
			foreach(DataRow r2 in d.get_data(sql).Tables[0].Rows)
			{
				if (r2["mabs"].ToString()!="") mabs.Text=r2["mabs"].ToString();
				if (r2["yta"].ToString()!="") manv.Text=r2["yta"].ToString();
				r1=d.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
                if (r1 != null) tenbs.Text = r1["hoten"].ToString();
                else mabs.Text = "";
				r1=d.getrowbyid(dtnv,"ma='"+manv.Text+"'");
				if (r1!=null) tennv.Text=r1["hoten"].ToString();
                else tennv.Text="";
                if (!bPhonggiuong) giuong.Text = r2["giuong"].ToString();
				break;
			}
            if (chkThuoc.Checked) load_treeview();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            i_duyet = m.get_duyetnhaan(s_mmyy, l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?"Số liệu đã chuyển xuống nhà ăn bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			treeView.Nodes.Clear();
			bNew=true;
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
            i_duyet = m.get_duyetnhaan(s_mmyy, l_duyet);
			if (i_duyet!=0)
			{
				sql=(i_duyet==1)?"Số liệu đã chuyển xuống nhà ăn bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
				MessageBox.Show(sql,s_msg);
				return;
			}
			l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
			if (d.get_paid(mabn.Text,0,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
				cmbMabn.Focus();
				return;
			}
			DataRow r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã xuất viện !"),LibMedi.AccessData.Msg);
				cmbMabn.Focus();
				return;
			}
            i_madoituong = int.Parse(r["madoituong"].ToString());
			ena_object(true);
            ena_dacbiet();
			mabn.Enabled=false;
			hoten.Enabled=false;
			bNew=false;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
            upd_table(dtct);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?m.get_id_di_kthucdonll:l_id;
            itable = m.tableid(m.mmyy(s_ngay), "di_kthucdonll");
            if (bNew)m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            else
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + l_duyet.ToString() + "^" + mabn.Text + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + madoituong.SelectedValue.ToString() + "^"+((idcu.SelectedIndex!=-1)?idcu.SelectedValue.ToString():"0")+"^"+((dacbiet.Checked)?"1":"0")+"^"+giuong.Text+"^"+chandoan.Text+"^"+mabs.Text+"^"+manv.Text);
            }
			if (l_duyet==0)
			{
				if (m.get_data("select id from "+xxx+".di_duyet where to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"' and phieu="+i_phieu+" and makp='"+s_makp+"'").Tables[0].Rows.Count>0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày")+" "+s_ngay+"\n"+lan.Change_language_MessageText("Khoa")+" "+s_tenkp+"\n"+lan.Change_language_MessageText("Phiếu")+" "+s_tenphieu+"\n"+lan.Change_language_MessageText("Đã nhập !"),LibMedi.AccessData.Msg);
					return;
				}
                if (l_duyet == 0) l_duyet = m.get_id_di_duyet;
                m.upd_di_duyet(s_mmyy, l_duyet,s_ngay,s_makp,i_phieu,0, 0,0,0,0,0,i_userid);
			}
            if (!m.upd_di_kthucdonll(s_mmyy, l_id, l_duyet, mabn.Text,l_maql, l_idkhoa,int.Parse(madoituong.SelectedValue.ToString()),(idcu.SelectedIndex!=-1)?int.Parse(idcu.SelectedValue.ToString()):0,(moi.Checked)?1:0,(dacbiet.Checked)?1:0,giuong.Text,s_maicd,chandoan.Text,mabs.Text,manv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),s_msg);
				return;
			}
            itable = m.tableid(m.mmyy(s_ngay), "di_kthucdonct");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".di_kthucdonct", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".di_kthucdonct where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
                    if (dacbiet.Checked) d.execute_data("delete from " + user + ".di_dmtdche where idkthucdonct=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
				}
			}
            decimal _id = 0;
			foreach(DataRow r1 in dtct.Rows)
			{
                if (m.get_data("select * from " + xxx + ".di_kthucdonct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["idgioan"].ToString() + "^" + r1["idthucdon"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["e"].ToString() + "^" + r1["p"].ToString() + "^" + r1["l"].ToString() + "^" + r1["g"].ToString() + "^" + r1["idchedoan"].ToString() + "^" + r1["dongia"].ToString());
                    if (dacbiet.Checked)
                        foreach (DataRow r2 in m.get_data("select id from " + user + ".di_dmtdche where idkthucdonct=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows)
                            _id = decimal.Parse(r2["id"].ToString());
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                    if (dacbiet.Checked) _id = m.get_id_di_dmthucdon;
                }
                m.upd_di_kthucdonct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["idgioan"].ToString()), int.Parse(r1["idthucdon"].ToString()), int.Parse(r1["soluong"].ToString()), decimal.Parse(r1["e"].ToString()),decimal.Parse(r1["p"].ToString()),decimal.Parse(r1["l"].ToString()),decimal.Parse(r1["g"].ToString()),int.Parse(r1["idchedoan"].ToString()),decimal.Parse(r1["dongia"].ToString()));
                if (dacbiet.Checked) m.upd_di_dmtdche(_id, s_ngay, mabn.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["idchedoan"].ToString()),int.Parse(r1["idgioan"].ToString()),decimal.Parse(r1["e"].ToString()), decimal.Parse(r1["p"].ToString()), decimal.Parse(r1["l"].ToString()), decimal.Parse(r1["g"].ToString()), decimal.Parse(r1["soluong"].ToString()));
			}
            m.updrec_kthucdonll(dtll, l_id, mabn.Text,hoten.Text,l_maql,l_idkhoa,s_ngayvv,int.Parse(madoituong.SelectedValue.ToString()),(idcu.SelectedIndex!=-1)?int.Parse(idcu.SelectedValue.ToString()):0,(moi.Checked)?1:0,(dacbiet.Checked)?1:0,s_maicd,chandoan.Text,giuong.Text,mabs.Text, manv.Text);
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

		private void Filt_dmbs(string ten,string exp)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%' and "+exp;
			}
			catch{}
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text,"nhom<>"+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tenbs,mabs,manv,35);
			}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tennv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennv)
			{
				Filt_dmbs(tennv.Text,"nhom="+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tennv,manv,giuong,35);
			}
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,mabs,55);
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
                i_duyet = m.get_duyetnhaan(s_mmyy, l_duyet);
				if (i_duyet==0 && dtll.Rows.Count>0)
				{
					DialogResult=MessageBox.Show(lan.Change_language_MessageText("Chuyển số liệu xuống nhà ăn ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					if (DialogResult==DialogResult.Yes)	m.execute_data("update "+xxx+".di_duyet set done=1 where id="+l_duyet);
					else if (DialogResult==DialogResult.Cancel) return;
				}
			}
			m.close();this.Close();
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				sql="ma like '"+ma.Trim()+"%'";
                sql += " and idgioan like '%" + idgioan.SelectedValue.ToString().PadLeft(2, '0') + ",%'";
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
				sql="ten like '"+ten.Trim()+"%'";
                sql += " and idgioan like '%" + idgioan.SelectedValue.ToString().PadLeft(2, '0') + ",%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				if (i_madoituong!=0)
				{
					if (int.Parse(madoituong.SelectedValue.ToString())!=i_madoituong)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							madoituong.SelectedValue=i_madoituong.ToString();
					}
				}
				SendKeys.Send("{Tab}");
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ma)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(ma.Text);
                listDmbd.Nhaan(ma, ten, soluong, idgioan.Location.X, ma.Location.Y + ma.Height - 2, ma.Width + ten.Width + idgioan.Width + lMabd.Width+7, ma.Height + 5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(ten.Text);
                listDmbd.Nhaan(ten, ma, soluong,idgioan.Location.X, ma.Location.Y + ma.Height - 2, ma.Width + ten.Width + idgioan.Width + lMabd.Width+7, ma.Height + 5);
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

		private void listDmbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs ev)
		{
			if (ev.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dttd,"id="+int.Parse(ma.Text));
					if (r!=null)
					{
						ma.Text=r["ma"].ToString();
						ten.Text=r["ten"].ToString();
						dongia.Text=r["dongia"].ToString().Trim();
                        e.Text = r["e"].ToString();
                        p.Text = r["p"].ToString();
                        l.Text = r["l"].ToString();
                        g.Text = r["g"].ToString();
                        idchedoan.SelectedValue = r["idchedoan"].ToString();
					}
				}
				catch{}
			}
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{			
			if (mabs.Text=="") return;
			r=d.getrowbyid(dtnv,"nhom<>"+LibMedi.AccessData.nhanvien+" and ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";
		}

		private void manv_Validated(object sender, System.EventArgs e)
		{
			if (manv.Text=="") return;
			r=d.getrowbyid(dtnv,"nhom="+LibMedi.AccessData.nhanvien+" and ma='"+manv.Text+"'");
			if (r!=null) tennv.Text=r["hoten"].ToString();
			else tennv.Text="";
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
					mabs.Text=r["mabs"].ToString();
					manv.Text=r["yta"].ToString();
					DataRow r1=d.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					r1=d.getrowbyid(dtnv,"ma='"+manv.Text+"'");
					if (r1!=null) tennv.Text=r1["hoten"].ToString();
					else tennv.Text="";
					giuong.Text=r["giuong"].ToString();
					l_maql=decimal.Parse(r["maql"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
                    r1 = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                    if (r1!=null) s_ngayvv = r1["ngay"].ToString();
                    madoituong.SelectedValue = r["madoituong"].ToString();
                    if (idcu.Items.Count>0) idcu.SelectedValue = r["idcu"].ToString();
                    dacbiet.Checked = r["dacbiet"].ToString() == "1";
                    moi.Checked = r["moi"].ToString() == "1";
                    s_maicd = r["maicd"].ToString();
                    chandoan.Text = r["chandoan"].ToString();
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
            nam = r["nam"].ToString().Trim();
			l_maql=decimal.Parse(r["maql"].ToString());
			l_idkhoa=decimal.Parse(r["id"].ToString());
            s_ngayvv = r["ngay"].ToString();
			if ((mabs.Text!="" && tenbs.Text=="") || (mabs.Text=="" && tenbs.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),s_msg);
				if (mabs.Text=="") mabs.Focus();
				else if (tenbs.Text=="") tenbs.Focus();
				return false;
			}
			if ((manv.Text!="" && tennv.Text=="") || (manv.Text=="" && tennv.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),s_msg);
				if (manv.Text=="") manv.Focus();
				else if (tennv.Text=="") tennv.Focus();
				return false;
			}
			if (d.get_paid(mabn.Text,0,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
				mabn.Focus();
				return false;
			}
            dtct.AcceptChanges();
            if (dtct.Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chế độ ăn !"), LibMedi.AccessData.Msg);
                butThem.Focus();
                return false;
            }
			return true;
		}

		private bool KiemtraDetail()
		{
			i_idthucdon=0;
            if (idgioan.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn giờ ăn !"),LibMedi.AccessData.Msg);
                idgioan.Focus();
                return false;
            }
            if (!dacbiet.Checked)
            {
                if (ma.Text == "" && ten.Text == "")
                {
                    if (ma.Enabled) ma.Focus();
                    else ten.Focus();
                    return false;
                }
                if ((ma.Text == "" && ten.Text != "") || (ma.Text != "" && ten.Text == ""))
                {
                    if (ma.Text == "" && ma.Enabled)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"), s_msg);
                        ma.Focus();
                        return false;
                    }
                    else if (ten.Text == "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"), s_msg);
                        ten.Focus();
                        return false;
                    }
                }
                r = d.getrowbyid(dttd, "ma='" + ma.Text + "'");
                if (r == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"), s_msg);
                    if (ma.Enabled) ma.Focus();
                    else ten.Focus();
                    return false;
                }
                i_idthucdon = int.Parse(r["id"].ToString());
            }
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
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),s_msg);
				mabn.Focus();
				return;
			}
            if (!dacbiet.Checked)
            {
                if (d.bNhapmaso) ma.Enabled = true;
                ten.Enabled = true;
            }
			soluong.Enabled=true;
			if (!upd_table(dtct)) return;
			emp_detail();
            idgioan.Focus();
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
            if (ten.Text!="" || e.Text!="")
                m.updrec_kthucdonct(dt, int.Parse(stt.Text), int.Parse(idgioan.SelectedValue.ToString()), i_idthucdon, idgioan.Text, ma.Text,(dacbiet.Checked)?"Bệnh lý : "+idchedoan.Text:ten.Text, (e.Text != "") ? decimal.Parse(e.Text) : 0, (p.Text != "") ? decimal.Parse(p.Text) : 0, (l.Text != "") ? decimal.Parse(l.Text) : 0, (g.Text != "") ? decimal.Parse(g.Text) : 0,(idchedoan.SelectedIndex!=-1)?int.Parse(idchedoan.SelectedValue.ToString()):0, (soluong.Text != "") ? decimal.Parse(soluong.Text) : 1, (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0, ((soluong.Text != "") ? decimal.Parse(soluong.Text) : 1)*((dongia.Text != "") ? decimal.Parse(dongia.Text) : 0));
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbMabn.Items.Count==0) return;
				if (d.get_paid(mabn.Text,0,l_maql,l_idkhoa,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
					cmbMabn.Focus();
					return;
				}
                i_duyet = m.get_duyetnhaan(s_mmyy, l_duyet);
				if (i_duyet!=0)
				{
					sql=(i_duyet==1)?"Số liệu đã chuyển xuống nhà ăn bạn không quyền thay đổi !":"Số liệu đã được cập nhật bạn không có quyền thay đổi !";
					MessageBox.Show(sql,s_msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = m.tableid(m.mmyy(s_ngay), "di_kthucdonct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".di_kthucdonct", "id=" + l_id+" and stt="+int.Parse(r1["stt"].ToString())));
                        if (dacbiet.Checked) d.execute_data("delete from "+user+".di_dmtdche where idkthucdonct="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
                    }
                    itable = m.tableid(m.mmyy(s_ngay), "di_kthucdonll");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".di_kthucdonll", "id=" + l_id));
					d.execute_data("delete from " + xxx + ".di_kthucdonct where id="+l_id);
                    d.execute_data("delete from " + xxx + ".di_kthucdonll where id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
                    CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                    DataView dv = (DataView)cm.List;
                    dv.RowFilter = "";
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count==0) 
					{
                        d.execute_data("delete from " + xxx + ".di_duyet where id=" + l_duyet);
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
			if (s_ngayvv=="" || mabn.Text=="" || l_maql==0) return;
            try
            {
                sql = "select to_char(c.ngay,'yyyymmdd') as ngay,case when b.idthucdon is null then 0 else b.idthucdon end as idthucdon,";
                sql += "b.idchedoan,sum(b.soluong) as soluong ";
                sql += " from xxx.di_kthucdonll a inner join xxx.di_kthucdonct b on a.id=b.id ";
                sql += " inner join xxx.di_duyet c on a.idduyet=c.id ";
                sql += " where a.mabn='" + mabn.Text + "'";
                sql += " group by to_char(c.ngay,'yyyymmdd'),case when b.idthucdon is null then 0 else b.idthucdon end,b.idchedoan ";
                treeView.Nodes.Clear();
                TreeNode node;
                DataTable dtngay = (nam != "") ? m.get_data_nam(nam, sql).Tables[0] : m.get_data_mmyy(sql, s_ngayvv.Substring(0, 10), s_ngay.Substring(0, 10), true).Tables[0];
                string ngay = "";
                DataRow[] dr;
                foreach (DataRow r1 in dtngay.Rows)
                {
                    if (ngay != r1["ngay"].ToString())
                    {
                        ngay = r1["ngay"].ToString();
                        node = treeView.Nodes.Add(ngay.Substring(6, 2) + "/" + ngay.Substring(4, 2) + "/" + ngay.Substring(0, 4));
                        dr = dtngay.Select("ngay='" + ngay + "'");
                        for (int i = 0; i < dr.Length; i++)
                        {
                            r = d.getrowbyid(dttd, "id=" + int.Parse(dr[i]["idthucdon"].ToString()));
                            if (r != null)
                                node.Nodes.Add(r["ten"].ToString().Trim() + " (" + dr[i]["soluong"].ToString().Trim() + ")");
                            else
                            {
                                r = d.getrowbyid(dttd, "idchedoan=" + int.Parse(dr[i]["idchedoan"].ToString()));
                                if (r != null) node.Nodes.Add("Bệnh lý :" + r["chedoan"].ToString().Trim() + " (" + dr[i]["soluong"].ToString().Trim() + ")");
                                else node.Nodes.Add("Bệnh lý (" + dr[i]["soluong"].ToString().Trim() + ")");
                            }
                        }
                    }
                }
            }
            catch { }
		}

		private void butCholai_Click(object sender, System.EventArgs e)
		{
			if (mabn.Text.Trim().Length!=8)
			{
				mabn.Focus();
				return;
			}
			decimal idcholai=m.get_cholai(s_ngayvv,s_ngay,mabn.Text,i_phieu,"di_kthucdonll");
			if (idcholai==0) return;
			dtct.Clear();
            sql = "select a.stt,a.idgioan,a.idthucdon,c.ten as gioan,";
            sql += " case when b.ma is null then '' else b.ma end as ma,";
            sql += " case when b.ma is null then 'Bệnh lý : '||d.ten else b.ten end as tenthucdon,";
            sql += "a.e,a.p,a.l,a.g,a.idchedoan,a.soluong,a.dongia,a.soluong*a.dongia as sotien ";
            sql += " from " + xxx + ".di_kthucdonct a left join " + user + ".di_dmthucdon b on a.idthucdon=b.id ";
            sql += " inner join " + user + ".di_dmgioan c on a.idgioan=c.id ";
            sql += " inner join "+ user +".di_dmchedoan d on a.idchedoan=d.id where a.id=" + idcholai + " order by a.stt";
			i_idthucdon=0;
			foreach(DataRow r in m.get_data_mmyy(sql,s_ngayvv,s_ngay,false).Tables[0].Rows)
			{
				i_idthucdon=int.Parse(r["idthucdon"].ToString());
                m.updrec_kthucdonct(dtct, d.get_stt(dtct), int.Parse(r["idgioan"].ToString()), i_idthucdon, r["gioan"].ToString(), r["ma"].ToString(), r["tenthucdon"].ToString(), decimal.Parse(r["e"].ToString()), decimal.Parse(r["p"].ToString()), decimal.Parse(r["l"].ToString()), decimal.Parse(r["g"].ToString()),int.Parse(r["idchedoan"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["sotien"].ToString()));
			}
			ref_text();
		}

		private void butChuyen_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==butChuyen)
			{
				if (l_duyet==0) return;
                i_duyet = m.get_duyetnhaan(s_mmyy, l_duyet);
				if (i_duyet==2)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được cập nhật bạn không có quyền thay đổi !"),s_msg);
					col_butChuyen(2);
					butChuyen.Checked=true;
					return;
				}
				i_duyet=(butChuyen.Checked)?1:0;
				m.execute_data("update "+xxx+".di_duyet set done="+i_duyet+" where id="+l_duyet);
				col_butChuyen(i_duyet);
                if (i_duyet == 1)
                {
                    m.close(); this.Close();
                }
                else cmbMabn.Focus();
			}
		}

		private void col_butChuyen(int i)
		{
			butChuyen.ForeColor=(i==2)?Color.Red:(i==1)?Color.Blue:Color.Black;
		}

		private void get_items(int stt)
		{
			try
			{
				r=d.getrowbyid(dttd,"id="+stt);
				if (r!=null)
				{
					ma.Text=r["ma"].ToString();
					ten.Text=r["ten"].ToString();
					dongia.Text=r["dongia"].ToString().Trim();
                    e.Text = r["e"].ToString();
                    p.Text = r["p"].ToString();
                    l.Text = r["l"].ToString();
                    g.Text = r["g"].ToString();
                    idchedoan.SelectedValue = r["idchedoan"].ToString();
					listDmbd.Hide();
                    soluong.Focus();
				}
			}
			catch{}		
		}

		private void listDmbd_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				get_items(int.Parse(listDmbd.Text));
			}
			catch{}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+ma.Text.Trim()+"%'";
                sql += " and idgioan like '%" + idgioan.SelectedValue.ToString().PadLeft(2, '0') + ",%'";
				DataRow [] dr=dttd.Select(sql);
				if (dr.Length==1)
				{
					ma.Text=dr[0]["id"].ToString();
					get_items(int.Parse(ma.Text));
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

		private void chkmadt_def_CheckedChanged(object sender, System.EventArgs e)
		{
			bMadoituong=!chkmadt_def.Checked;
			madoituong.Enabled=bMadoituong;
		}

        private void chkThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkThuoc)
            {
                if (chkThuoc.Checked) load_treeview();
                else treeView.Nodes.Clear();
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
                try
                {
                    l_id = decimal.Parse(cmbMabn.SelectedValue.ToString());
                }
                catch { l_id = 0; }
                load_head();
            }
        }

        private void idgioan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (idgioan.SelectedIndex == -1 && idgioan.Items.Count > 0) idgioan.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void dacbiet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == dacbiet)
            {
                if (dacbiet.Checked)
                {
                    DataRow r = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                    if (r != null) chandoan.Text = r["chandoan"].ToString();
                    if (idchedoan.SelectedIndex != -1) load_chedoan();
                }
                else chandoan.Text = "";
                ena_dacbiet();
            }
        }
        private void ena_dacbiet()
        {
            e.Enabled = dacbiet.Checked;
            p.Enabled = dacbiet.Checked;
            l.Enabled = dacbiet.Checked;
            g.Enabled = dacbiet.Checked;
            chandoan.Enabled = dacbiet.Checked;
            idchedoan.Enabled = dacbiet.Checked;
            ma.Enabled = !dacbiet.Checked;
            ten.Enabled = !dacbiet.Checked;
        }

        private void idcu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (idcu.SelectedIndex == -1 && idcu.Items.Count > 0) idcu.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void p_Validated(object sender, EventArgs e)
        {
            decimal zg = ((g.Text != "") ? decimal.Parse(g.Text) : 0);
            if (zg>0)
            {
                decimal zl = 100 - ((p.Text != "") ? decimal.Parse(p.Text) : 0) - zg;
                l.Text = zl.ToString();
            }
            if (!kiemtraplg()) return;
        }

        private void l_Validated(object sender, EventArgs e)
        {
           decimal zg = 100 - ((l.Text!="")?decimal.Parse(l.Text):0) - ((p.Text != "") ? decimal.Parse(p.Text) : 0);
           g.Text = zg.ToString();
           if (!kiemtraplg()) return;
        }

        private void g_Validated(object sender, EventArgs e)
        {
            decimal zp = 100 - ((g.Text != "") ? decimal.Parse(g.Text) : 0) - ((l.Text != "") ? decimal.Parse(l.Text) : 0);
            p.Text = zp.ToString();
            if (!kiemtraplg()) return;
        }

        private bool kiemtraplg()
        {
            bool ret = true;
            decimal zp = (p.Text != "") ? decimal.Parse(p.Text) : 0,zl=(l.Text != "") ? decimal.Parse(l.Text) : 0,zg=(g.Text != "") ? decimal.Parse(g.Text) : 0;
            if ((zp>100 || zp<0) || (zl>100 || zl<0) || (zg>100 || zg<0))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"), LibMedi.AccessData.Msg);
                if (zp > 100 || zp<0) p.Focus();
                else if (zl > 100 || zl<0) l.Focus();
                else g.Focus();
                ret=false;
            }
            return ret;
        }

        private void getgia()
        {
            decimal ret = 0;
            if (e.Text != "")
            {
                decimal ze = decimal.Parse(e.Text);
                sql=ze+">=tu and "+ze+"<=den";
                DataRow [] dr=dtgia.Select(sql);
                if (dr.Length > 0) ret = decimal.Parse(dr[0]["dongia"].ToString());
                else
                {
                    dr = dtgia.Select(ze + ">=tu and den=0");
                    if (dr.Length > 0) ret = decimal.Parse(dr[0]["dongia"].ToString());
                }
            }
            if (ret!=0) dongia.Text = ret.ToString();
        }

        private void e_Validated(object sender, EventArgs e)
        {
            getgia();
        }

        private void butList_Click(object sender, EventArgs e)
        {
            if (mabn.Text.Trim().Length != 8)
            {
                mabn.Focus();
                return;
            }
            frmChontd f = new frmChontd(m,s_ngay);
            f.ShowDialog();
            if (f.dt != null)
            {
                DataRow r1;
                foreach (DataRow r in f.dt.Rows)
                {
                    r1 = m.getrowbyid(dttd, "id=" + decimal.Parse(r["mavp"].ToString()));
                    if (r1 != null)
                       m.updrec_kthucdonct(dtct,d.get_stt(dtct),int.Parse(idgioan.SelectedValue.ToString()),int.Parse(r1["id"].ToString()),idgioan.Text,r1["ma"].ToString(),r1["ten"].ToString(),decimal.Parse(r1["e"].ToString()),decimal.Parse(r1["p"].ToString()),decimal.Parse(r1["l"].ToString()),decimal.Parse(r1["g"].ToString()),int.Parse(r1["idchedoan"].ToString()),1,decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["dongia"].ToString()));
                }
            }
        }

        private void idchedoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (idchedoan.SelectedIndex == -1 && idchedoan.Items.Count > 0) idchedoan.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void idchedoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == idchedoan && idchedoan.SelectedIndex != -1) load_chedoan();
        }

        private void load_chedoan()
        {
            e.Text = (dtchedo.Rows[idchedoan.SelectedIndex]["e"].ToString()!="0")?dtchedo.Rows[idchedoan.SelectedIndex]["e"].ToString():"";
            p.Text = (dtchedo.Rows[idchedoan.SelectedIndex]["p"].ToString()!="0")?dtchedo.Rows[idchedoan.SelectedIndex]["p"].ToString():"";
            l.Text = (dtchedo.Rows[idchedoan.SelectedIndex]["l"].ToString()!="0")?dtchedo.Rows[idchedoan.SelectedIndex]["l"].ToString():"";
            g.Text = (dtchedo.Rows[idchedoan.SelectedIndex]["g"].ToString()!="0")?dtchedo.Rows[idchedoan.SelectedIndex]["g"].ToString():"";
            getgia();
            if (dongia.Text == "" || dongia.Text == "0") dongia.Text = dtchedo.Rows[idchedoan.SelectedIndex]["dongia"].ToString();
        }
	}
}