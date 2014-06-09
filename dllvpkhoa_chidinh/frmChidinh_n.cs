using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibDuoc;
using LibVienphi;


namespace dllvpkhoa_chidinh
{
	/// <summary>
	/// Summary description for frmChidinh.
	/// </summary>
	public class frmChidinh_n : System.Windows.Forms.Form
	{
        //linh 25092012
        bool b_ApDungQuanLyGiaVienPhiTheoThongTuLienTich15042012 = false;
        string s_ngayloadgiavienphitheothongtulientich = "";
        string s_ngayvaovienbenhnhantheothongtulientich = "";
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
        decimal tmp_sotienchitiet = 0;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private LibList.List list;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox mavp;
		private System.Windows.Forms.Button butLietke;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
        private string xxx, user, nam = "", s_ngay, s_makp, s_tenkp, sql, s_dvt, s_table, s_loaivp = "", s_mucvp = "", s_ngayvao = "", s_chenhlech, s_title = "", i_nhomvp_pttt = "", username = "";
        private int i_madoituong, i_loai, i_done, i_paid, i_row = 0, i_userid, iChidinh, v1, v2, i_madoituongvao, i_tunguyen, i_vienphi, i_traituyen=0;
		private decimal l_maql,l_idkhoa,l_id,l_mavaovien,l_idchidinh;
        private decimal d_soluong, d_dongia, d_vattu, d_soluongcu, Tamung_min=0;
        private bool bMadoituong, bNhapten, bNew, bEdit = false, bHansd_thuoc, bChidinh_exp_txt, bCD_BS_Chidinh, bChuky, bChidinh_thutienlien, bChenhlech_doituong, bChidinh_loaivp, bAdmin, bNhapPTTT_chidinh_vpkhoa_miengiam, bNhapPTTT_chenhlech_miengiamtheo_I08;
        private bool bAdminHethong = false, bChidinh_lietke_kemgia = true, bvuottamung = false, bchiphi_lonhon_tamung_khongchothuchien_cls_H27 = false;
		private DataRow r;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtll=new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtbs = new DataTable();
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox tinhtrang;
		private System.Windows.Forms.ComboBox thuchien;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butNet;
		private LibList.List listHoten;
		private System.Windows.Forms.ComboBox cmbMabn;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox sothe;
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush disabledTextBrush1;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        bool afterCurrentCellChanged=true;
        private int checkCol = 0,i_loaiba=1;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private CheckBox chkmadt_def;
        private TextBox tenbs;
        private TextBox chandoan;
        private Label label13;
        private Label label12;
        private TextBox mabs;
        private LibList.List listBS;
        private TextBox maicd;
        private TextBox tim;
        private string sothe_jl;
        private int vitri_jl;
        private bool bChidinh_noitru_vienphi,bTinnhan,bTinnhan_sound;
        private bool bChidinh_dain_khongchohuy = false,bChiPhiVuotTamUngKoChoChiDinh=false;
        private string cl_cholam = "", cl_tendoituong = "";
        private decimal cl_tyle = 0;
        private int cl_doituong = 3;
        private bool bLocdichvu;
        private TextBox ghichu;
        private Label label14;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem mnu_thongbaochiphi;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnu_writexml;
        private ToolStripMenuItem tmn_xemlaichidinh;
        private Label label10;
        private Label label11;
        private Label label15;
        private TextBox lydogiam;
        private Label label16;
        private MaskedTextBox.MaskedTextBox tylegiam;
        private MaskedTextBox.MaskedTextBox stgiam;
        private ToolStripMenuItem tmn_chenhlechmiengiam;
        private bool bNhapvpkhoa = false;

        private int i_tutuoi, i_dentuoi, i_tuoi;
        private string s_gtvp = "", s_gioitinh = "";
        private ToolStripMenuItem tmn_hienthichenhlech;
        private bool b_cholai = false;
        private Button butCholai;
        private ToolStripMenuItem mnuSapXepTenTheoABC;
        private dllDanhmucMedisoft.CachedCrystalReport1 cachedCrystalReport11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChidinh_n(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid,string table,int loai,int loaiba,bool admin, bool nhapnhuvpkhoa)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table;
            i_userid = userid; i_loai = loai; i_loaiba = loaiba; bAdmin = admin;
            bNhapvpkhoa = nhapnhuvpkhoa;
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
                    if (disabledBackBrush != null)
                    {
                        disabledBackBrush.Dispose();
                        disabledTextBrush.Dispose();
                        disabledTextBrush1.Dispose();
                        alertBackBrush.Dispose();
                        alertFont.Dispose();
                        alertTextBrush.Dispose();
                        currentRowFont.Dispose();
                        currentRowBackBrush.Dispose();
                    }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChidinh_n));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.list = new LibList.List();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.mavp = new System.Windows.Forms.TextBox();
            this.butLietke = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.thuchien = new System.Windows.Forms.ComboBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.butNet = new System.Windows.Forms.Button();
            this.listHoten = new LibList.List();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.chkmadt_def = new System.Windows.Forms.CheckBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mabs = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.maicd = new System.Windows.Forms.TextBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnu_thongbaochiphi = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_xemlaichidinh = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_chenhlechmiengiam = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_hienthichenhlech = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu_writexml = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSapXepTenTheoABC = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lydogiam = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tylegiam = new MaskedTextBox.MaskedTextBox();
            this.stgiam = new MaskedTextBox.MaskedTextBox();
            this.butCholai = new System.Windows.Forms.Button();
            this.cachedCrystalReport11 = new dllDanhmucMedisoft.CachedCrystalReport1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-4, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(42, 28);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(102, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(142, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(188, 28);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(219, 21);
            this.hoten.TabIndex = 2;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(588, 51);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 161);
            this.treeView1.TabIndex = 23;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 32);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(576, 272);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(424, 465);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 30;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(508, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(573, 333);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(136, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Dịch vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(145, 356);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(456, 21);
            this.ten.TabIndex = 9;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(588, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Số lượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(653, 356);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(56, 21);
            this.soluong.TabIndex = 10;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(405, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "Khoa :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(442, 28);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(100, 21);
            this.tenkp.TabIndex = 22;
            // 
            // mavp
            // 
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(64, 204);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(46, 21);
            this.mavp.TabIndex = 24;
            this.mavp.Validated += new System.EventHandler(this.mavp_Validated);
            // 
            // butLietke
            // 
            this.butLietke.Enabled = false;
            this.butLietke.Image = ((System.Drawing.Image)(resources.GetObject("butLietke.Image")));
            this.butLietke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLietke.Location = new System.Drawing.Point(4, 434);
            this.butLietke.Name = "butLietke";
            this.butLietke.Size = new System.Drawing.Size(64, 25);
            this.butLietke.TabIndex = 18;
            this.butLietke.Text = "    Liệt kê";
            this.butLietke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLietke.Click += new System.EventHandler(this.butLietke_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(68, 434);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(64, 25);
            this.butMoi.TabIndex = 19;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(197, 434);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(64, 25);
            this.butSua.TabIndex = 20;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(261, 434);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(64, 25);
            this.butLuu.TabIndex = 16;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(325, 434);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(64, 25);
            this.butBoqua.TabIndex = 17;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(453, 434);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(64, 25);
            this.butHuy.TabIndex = 21;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(644, 434);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(64, 25);
            this.butKetthuc.TabIndex = 24;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-6, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Tình trạng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(250, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "Thực hiện :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Location = new System.Drawing.Point(56, 333);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(188, 21);
            this.tinhtrang.TabIndex = 5;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // thuchien
            // 
            this.thuchien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuchien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thuchien.Enabled = false;
            this.thuchien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuchien.Location = new System.Drawing.Point(312, 333);
            this.thuchien.Name = "thuchien";
            this.thuchien.Size = new System.Drawing.Size(192, 21);
            this.thuchien.TabIndex = 6;
            this.thuchien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thuchien_KeyDown);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(56, 356);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(88, 21);
            this.ma.TabIndex = 8;
            this.ma.Validated += new System.EventHandler(this.mavp_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butNet
            // 
            this.butNet.Image = ((System.Drawing.Image)(resources.GetObject("butNet.Image")));
            this.butNet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNet.Location = new System.Drawing.Point(581, 434);
            this.butNet.Name = "butNet";
            this.butNet.Size = new System.Drawing.Size(64, 25);
            this.butNet.TabIndex = 23;
            this.butNet.Text = "&Gửi tin";
            this.butNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNet.Click += new System.EventHandler(this.butNet_Click);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(335, 465);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 31;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // cmbMabn
            // 
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(42, 28);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(102, 21);
            this.cmbMabn.TabIndex = 1;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(132, 434);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(64, 25);
            this.butThem.TabIndex = 15;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(517, 434);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(64, 25);
            this.butIn.TabIndex = 22;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(541, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 74;
            this.label3.Text = "Số thẻ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(588, 28);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(119, 21);
            this.sothe.TabIndex = 73;
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(588, 214);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 257;
            this.pic.TabStop = false;
            // 
            // chkmadt_def
            // 
            this.chkmadt_def.Enabled = false;
            this.chkmadt_def.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkmadt_def.Location = new System.Drawing.Point(598, 404);
            this.chkmadt_def.Name = "chkmadt_def";
            this.chkmadt_def.Size = new System.Drawing.Size(111, 24);
            this.chkmadt_def.TabIndex = 258;
            this.chkmadt_def.Text = "Đối tượng khi vào";
            this.chkmadt_def.CheckedChanged += new System.EventHandler(this.chkmadt_def_CheckedChanged);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(56, 310);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(186, 21);
            this.tenbs.TabIndex = 3;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(312, 309);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(397, 21);
            this.chandoan.TabIndex = 4;
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(242, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 261;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-26, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 23);
            this.label12.TabIndex = 259;
            this.label12.Text = "Bác sỹ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(335, 238);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(44, 21);
            this.mabs.TabIndex = 263;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(526, 465);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 264;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // maicd
            // 
            this.maicd.Enabled = false;
            this.maicd.Location = new System.Drawing.Point(424, 251);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(51, 20);
            this.maicd.TabIndex = 266;
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(588, 287);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(121, 21);
            this.tim.TabIndex = 267;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(56, 379);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(653, 21);
            this.ghichu.TabIndex = 11;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(3, 380);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 23);
            this.label14.TabIndex = 269;
            this.label14.Text = "Ghi chú :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(714, 25);
            this.toolStrip1.TabIndex = 271;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_thongbaochiphi,
            this.tmn_xemlaichidinh,
            this.tmn_chenhlechmiengiam,
            this.tmn_hienthichenhlech,
            this.toolStripSeparator1,
            this.mnu_writexml,
            this.mnuSapXepTenTheoABC});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(64, 22);
            this.toolStripDropDownButton1.Text = "Tùy chọn";
            // 
            // mnu_thongbaochiphi
            // 
            this.mnu_thongbaochiphi.CheckOnClick = true;
            this.mnu_thongbaochiphi.Name = "mnu_thongbaochiphi";
            this.mnu_thongbaochiphi.Size = new System.Drawing.Size(316, 22);
            this.mnu_thongbaochiphi.Text = "Cảnh báo chi phí vượt quá tạm ứng";
            this.mnu_thongbaochiphi.Click += new System.EventHandler(this.mnu_thongbaochiphi_Click);
            // 
            // tmn_xemlaichidinh
            // 
            this.tmn_xemlaichidinh.CheckOnClick = true;
            this.tmn_xemlaichidinh.Name = "tmn_xemlaichidinh";
            this.tmn_xemlaichidinh.Size = new System.Drawing.Size(316, 22);
            this.tmn_xemlaichidinh.Text = "Xem các ngày điều trị";
            this.tmn_xemlaichidinh.Click += new System.EventHandler(this.tmn_xemlaichidinh_Click);
            // 
            // tmn_chenhlechmiengiam
            // 
            this.tmn_chenhlechmiengiam.CheckOnClick = true;
            this.tmn_chenhlechmiengiam.Name = "tmn_chenhlechmiengiam";
            this.tmn_chenhlechmiengiam.Size = new System.Drawing.Size(316, 22);
            this.tmn_chenhlechmiengiam.Text = "Chênh lệch miễn giảm theo";
            // 
            // tmn_hienthichenhlech
            // 
            this.tmn_hienthichenhlech.CheckOnClick = true;
            this.tmn_hienthichenhlech.Name = "tmn_hienthichenhlech";
            this.tmn_hienthichenhlech.Size = new System.Drawing.Size(316, 22);
            this.tmn_hienthichenhlech.Text = "Hiển thị chênh lệch";
            this.tmn_hienthichenhlech.Click += new System.EventHandler(this.tmn_hienthichenhlech_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(313, 6);
            // 
            // mnu_writexml
            // 
            this.mnu_writexml.CheckOnClick = true;
            this.mnu_writexml.Name = "mnu_writexml";
            this.mnu_writexml.Size = new System.Drawing.Size(316, 22);
            this.mnu_writexml.Text = "Xuất ra XML";
            // 
            // mnuSapXepTenTheoABC
            // 
            this.mnuSapXepTenTheoABC.CheckOnClick = true;
            this.mnuSapXepTenTheoABC.Name = "mnuSapXepTenTheoABC";
            this.mnuSapXepTenTheoABC.Size = new System.Drawing.Size(316, 22);
            this.mnuSapXepTenTheoABC.Text = "Liệt kê các dịch vụ sắp xếp Tên theo thứ tự ABC";
            this.mnuSapXepTenTheoABC.Click += new System.EventHandler(this.mnuSapXepTenTheoABC_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 23);
            this.label10.TabIndex = 273;
            this.label10.Text = "Tỷ lệ giảm";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(93, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 23);
            this.label11.TabIndex = 274;
            this.label11.Text = "%";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(108, 402);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 23);
            this.label15.TabIndex = 276;
            this.label15.Text = "Số tiền giảm :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydogiam
            // 
            this.lydogiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydogiam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lydogiam.Enabled = false;
            this.lydogiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydogiam.Location = new System.Drawing.Point(355, 402);
            this.lydogiam.Name = "lydogiam";
            this.lydogiam.Size = new System.Drawing.Size(237, 21);
            this.lydogiam.TabIndex = 14;
            this.lydogiam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(283, 402);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 23);
            this.label16.TabIndex = 278;
            this.label16.Text = "Lý do giảm";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tylegiam
            // 
            this.tylegiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tylegiam.Enabled = false;
            this.tylegiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tylegiam.Location = new System.Drawing.Point(56, 402);
            this.tylegiam.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tylegiam.Name = "tylegiam";
            this.tylegiam.Size = new System.Drawing.Size(37, 21);
            this.tylegiam.TabIndex = 12;
            this.tylegiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tylegiam.Validated += new System.EventHandler(this.tylegiam_Validated);
            // 
            // stgiam
            // 
            this.stgiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stgiam.Enabled = false;
            this.stgiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stgiam.Location = new System.Drawing.Point(188, 402);
            this.stgiam.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.stgiam.Name = "stgiam";
            this.stgiam.Size = new System.Drawing.Size(105, 21);
            this.stgiam.TabIndex = 13;
            this.stgiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stgiam.Validated += new System.EventHandler(this.stgiam_Validated);
            // 
            // butCholai
            // 
            this.butCholai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCholai.Enabled = false;
            this.butCholai.Image = ((System.Drawing.Image)(resources.GetObject("butCholai.Image")));
            this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCholai.Location = new System.Drawing.Point(389, 434);
            this.butCholai.Name = "butCholai";
            this.butCholai.Size = new System.Drawing.Size(63, 25);
            this.butCholai.TabIndex = 287;
            this.butCholai.Text = "&Cho lại";
            this.butCholai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCholai.Click += new System.EventHandler(this.butCholai_Click);
            // 
            // frmChidinh_n
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 494);
            this.Controls.Add(this.butCholai);
            this.Controls.Add(this.stgiam);
            this.Controls.Add(this.tylegiam);
            this.Controls.Add(this.lydogiam);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkmadt_def);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.butNet);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.thuchien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butLietke);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.maicd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChidinh_n";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định dịch vụ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChidinh_n_KeyDown);
            this.Load += new System.EventHandler(this.frmChidinh_n_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmChidinh_n_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //linh 25092012 quan ly thông tư liên tịch
            b_ApDungQuanLyGiaVienPhiTheoThongTuLienTich15042012 = m.QuanLyGiaVienPhiTheoThongTuLienTich15042012;
            if (b_ApDungQuanLyGiaVienPhiTheoThongTuLienTich15042012)
            {
                s_ngayloadgiavienphitheothongtulientich = m.NgayVienPhiThongTuLienTich15042012;
                s_ngayvaovienbenhnhantheothongtulientich = m.NgayBenhNhanVaoThongTuLienTich15042012;
            }
            else
            {
                s_ngayloadgiavienphitheothongtulientich = "";
                s_ngayvaovienbenhnhantheothongtulientich = "";
            }
            //end
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            //
            mnuSapXepTenTheoABC.Checked = m.Thongso("chidinh_sort_ten") == "1";
            //
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            sothe_jl = m.sSothe_jl.Trim(); vitri_jl = m.iSothe_jl_vitri;
            bChidinh_exp_txt = m.bChidinh_exp_txt;
            bAdminHethong = m.bAdminHethong(i_userid);
            bCD_BS_Chidinh = m.bCD_BS_Chidinh; bChidinh_loaivp = m.bChidinh_loaivp;
            i_tunguyen = m.iTunguyen; bLocdichvu = m.bLocdichvu_doituong;
            bChidinh_noitru_vienphi = m.bChidinh_noitru_vienphi;
            bTinnhan = m.bTinnhan_chidinh;
            bChenhlech_doituong = m.bChenhlech_doituong;
            bTinnhan_sound = m.bTinnhan_chidinh_sound;
            cl_cholam = m.mien_chenhlech_cholam.Trim().ToLower();
            cl_tyle = m.mien_chenhlech;
            i_vienphi = m.iVienphi;
            Tamung_min = m.Tamung_min;
            cl_doituong = m.mien_chenhlech_doituong;
            bChidinh_dain_khongchohuy = m.bChidinh_dain_khongchohuy;
            pic.Visible = m.bHinh;
            if (!pic.Visible) this.treeView1.Size = new System.Drawing.Size(121, 235);
            i_nhomvp_pttt = m.iNhompttt;
            bChuky = m.bChuky;
            user = m.user;
            xxx = user + m.mmyy(s_ngay);
            //
            f_capnhat_db();//cap nhat cau truc data v_chidinh
            //
            tmn_hienthichenhlech.Checked = m.Thongso("chidinh_chenhlech") == "1";
            bChidinh_lietke_kemgia = m.bChidinh_lietke_kemgia;
            bNhapPTTT_chidinh_vpkhoa_miengiam = m.bNhapPTTT_chidinh_vpkhoa_miengiam;
            if (bNhapPTTT_chidinh_vpkhoa_miengiam) { bNhapPTTT_chenhlech_miengiamtheo_I08 = m.bNhapPTTT_chenhlech_miengiamtheo_I08; tmn_chenhlechmiengiam.Checked = true; }
            else { bNhapPTTT_chenhlech_miengiamtheo_I08 = false; tmn_chenhlechmiengiam.Enabled = false; tmn_chenhlechmiengiam.Checked = false; }
            visibled_giam(bNhapPTTT_chidinh_vpkhoa_miengiam);
            bChiPhiVuotTamUngKoChoChiDinh = m.bChiPhiVuotTamUngKoChoChiDinh;
            mnu_thongbaochiphi.Checked = Tamung_min > 0;// m.Thongso("thongbaochiphi_cd") == "1";
            mnu_thongbaochiphi.Enabled = !bChiPhiVuotTamUngKoChoChiDinh;
            //
			v1=4;v2=2;
			//sring vitri=d.thetunguyen_vitri_ora(m.nhom_duoc); //gam 18/08/2011 comment
            string vitri = d.thetunguyen_vitri(m.nhom_duoc);
			if (vitri.Length==3)
			{
				//v1=int.Parse(vitri.Substring(0,1))-1;v2=int.Parse(vitri.Substring(2,1)); //Tu: 18/08/2011
                v1 = int.Parse(vitri.Substring(0, 1)) ; v2 = int.Parse(vitri.Substring(2, 1));
			}
            bHansd_thuoc = m.bHansd_thuoc;
			tenkp.Text=s_tenkp;
			bMadoituong=m.bSuadt_thuoc_vp;
            chkmadt_def.Checked = !bMadoituong;
            chkmadt_def.Checked = !bMadoituong;
			iChidinh=m.iChidinh;
			bNhapten=m.bNhapthuoc_ten;
            s_chenhlech = "";
            //
            bool bBatbuocNhapkhoa = m.get_data("select khonghiendien_chochidinh from medibv.btdkp_bv where makp='" + s_makp + "' and khonghiendien_chochidinh=0").Tables[0].Rows.Count > 0;
            //
            foreach (DataRow r in m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where chenhlech=1").Tables[0].Rows)
                s_chenhlech += r["madoituong"].ToString().Trim() + ",";
            dtdt = d.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where sothe>0 and ngay>0 order by madoituong").Tables[0];
            sql = "select a.mabn,b.hoten,a.id,c.mavaovien,a.maql,c.madoituong,d.sothe,b.nam,to_char(c.ngay,'dd/mm/yyyy') as ngay,coalesce(to_char(d.ngaygiahan,'dd/mm/yyyy'),to_char(d.denngay,'dd/mm/yyyy')) as denngay,e.mabs,e.chandoan,e.maicd, nvl(to_char(d.tungay,'dd/mm/yyyy'),to_char(c.ngay,'dd/mm/yyyy')) as tungay, nvl(d.traituyen,0) as traituyen ";//Thuy 04.01.2012
            sql+=" from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql+=" inner join " + user + ".benhandt c on a.maql=c.maql ";
            sql+=" left join " + user + ".bhyt d on a.maql=d.maql ";
            sql+=" inner join " + user + ".nhapkhoa e on a.id=e.id ";
            sql+=" where a.nhapkhoa=1 and a.xuatkhoa=0 ";
            if (!m.ma_phongmo(s_makp) && bBatbuocNhapkhoa) sql += " and a.makp='" + s_makp + "'";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + s_ngay + "','" + m.f_ngay + "')";
            sql += " and (d.sudung is null or d.sudung=1)";
            sql += " order by a.id desc";
            dthoten = m.get_data(sql).Tables[0];
            listHoten.DisplayMember = "MABN";
            listHoten.ValueMember = "HOTEN";
            listHoten.DataSource = dthoten;

            dtkp = m.get_data("select * from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0];
			if (dtkp.Rows.Count==1)
			{
				s_loaivp=dtkp.Rows[0]["loaicd"].ToString().Trim();
				s_mucvp=dtkp.Rows[0]["muccd"].ToString().Trim();
				if (s_loaivp!="") s_loaivp=s_loaivp.Substring(0,s_loaivp.Length-1);
				if (s_mucvp!="") s_mucvp=s_mucvp.Substring(0,s_mucvp.Length-1);
			}
            //linh 25092012
            //string s_ten = "a.ten";
            //if (bChidinh_lietke_kemgia) s_ten += "||' ['||a.gia_th||']'";
            //sql = "select a.id,"+s_ten+" as ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,";
            //sql += " a.vattu_nn,b.computer,b.computervp,a.trongoi,a.locthe,a.gia_cs,a.vattu_cs,a.chenhlech,a.gia_ksk,a.vattu_ksk, b.id_nhom, a.bhyt_tt, a.sothe, a.batbuocthutien,a.coso,a.cosothay,a.phongthuchiencls,a.hoichan,a.giaycamdoan,a.tgtrakq as thoigiantrakq,a.gioitinh,a.tutuoi,a.dentuoi, a.loaitrongoi ";
            //sql+=" from " + user + ".v_giavp a," + user + ".v_loaivp b ";
            //sql+="where a.id_loai=b.id and a.hide=0";
            //if (s_loaivp!="") sql+=" and a.id_loai in ("+s_loaivp+")";
            //if (s_mucvp!="") sql+=" and a.id not in ("+s_mucvp+")";
            //sql+=" and (a.loaibn=0 or a.loaibn="+v.iNgoaitru+")";
            //sql += " order by b.stt,a.stt";
            //dt = m.get_data(sql).Tables[0];
            dt = m.get_dmvp(s_ngay, s_loaivp, s_mucvp, v.iNgoaitru, b_ApDungQuanLyGiaVienPhiTheoThongTuLienTich15042012, mnuSapXepTenTheoABC.Checked).Tables[0];
            //end
			list.DisplayMember="TEN";
			list.ValueMember="ID";
			list.DataSource=dt;

			tinhtrang.DisplayMember="TEN";
			tinhtrang.ValueMember="ID";
            tinhtrang.DataSource = m.get_data("select * from " + user + ".dmtinhtrang order by id").Tables[0];

			thuchien.DisplayMember="TEN";
			thuchien.ValueMember="ID";
            thuchien.DataSource = m.get_data("select * from " + user + ".dmthuchien order by id").Tables[0];

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
			try
			{
				madoituong.SelectedValue=i_madoituong.ToString();
			}
			catch{}

			cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="IDKHOA";
			load_mabn();
			load_head();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            this.disabledBackBrush = new SolidBrush(Color.Black);
            this.disabledTextBrush = new SolidBrush(Color.Red);
            this.disabledTextBrush1 = new SolidBrush(Color.Chocolate);

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
            try
            {
                username = m.get_data("select hoten from " + user + ".dlogin where id=" + i_userid).Tables[0].Rows[0][0].ToString();
            }
            catch { }
			if (iChidinh!=4) load_treeView();
		}

		private void load_mabn()
		{
            //linh 25092012
			sql="select distinct a.mabn,b.hoten,a.mavaovien,a.maql,a.idkhoa,to_char(c.ngay,'dd/mm/yyyy') as ngayvao from "+xxx+".v_chidinh a,"+user+".btdbn b,"+user+".benhandt c "+
                " where a.mabn=b.mabn and a.maql=c.maql and a.makp='"+s_makp+"' and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
			dtll=m.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
            if (cmbMabn.Items.Count > 0)
            {
                l_idkhoa = decimal.Parse(cmbMabn.SelectedValue.ToString());
                s_ngayvao = dtll.Select("idkhoa='" + l_idkhoa+"'")[0]["ngayvao"].ToString();
                if (m.SoSanhNgay(s_ngayvaovienbenhnhantheothongtulientich, s_ngayvao) >= 0)
                {
                    dt = m.get_dmvp(s_ngayvao, s_loaivp, s_mucvp, v.iNgoaitru).Tables[0];
                }
                else
                {
                    dt = m.get_dmvp(s_ngayvaovienbenhnhantheothongtulientich, s_loaivp, s_mucvp, v.iNgoaitru).Tables[0];
                }
                //end
            }
            else l_idkhoa = 0;
		}
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 5;

            FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "chon";
            discontinuedCol.HeaderText = "Chọn";
            discontinuedCol.Width = 20;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tenkp";
            TextCol1.HeaderText = "Khoa/phòng";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ngay";
            TextCol1.HeaderText = "Ngày";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "doituong";
            TextCol1.HeaderText = "Đối tượng";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Dịch vụ";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "dvt";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 30;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = "SL";
            TextCol1.Width = 30;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "makp";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "madoituong";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "mavp";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "dongia";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "paid";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "done";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "maql";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "idkhoa";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "vattu";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tinhtrang";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "thuchien";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "mavaovien";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ghichu";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tylegiam";
            TextCol1.HeaderText = "%Giảm";
            TextCol1.Width = 40;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "stgiam";
            TextCol1.HeaderText = "ST Giảm";
            TextCol1.Width = 70;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "lydogiam";
            TextCol1.HeaderText = "Lý do giảm";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "user";
            TextCol1.HeaderText = "Người nhập";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                if (this.dataGrid1[e.Row, 12].ToString().Trim() == "1" )//|| this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush;
                else if (this.dataGrid1[e.Row, 13].ToString().Trim() == "1")// || this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush1;
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
                else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
            }
            catch { }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            RefreshRow(e.Row);
            this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }
        private void RefreshRow(int row)
        {
            Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
            rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
            this.dataGrid1.Invalidate(rect);
        }

        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
                    this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
            }
            catch { }
            ref_text();
        }

        private void dataGrid1_Click(object sender, System.EventArgs e)
        {
            Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
            DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
            BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
            if (afterCurrentCellChanged && hti.Row < bmb.Count
                && hti.Type == DataGrid.HitTestType.Cell
                && hti.Column == checkCol)
            {
                this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
                RefreshRow(hti.Row);
            }
        }

		private void load_grid(decimal maql,decimal idkhoa)
		{
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,a.paid,a.done,a.mavaovien,a.maql,a.idkhoa,a.vattu,a.tinhtrang,a.thuchien,b.ma,a.mabs,a.maicd,a.chandoan,a.loaiba,a.ghichu ";
            sql += ", a.tylegiam, a.stgiam, a.lydogiam,a.hide,e.hoten as user ";
			sql+=" from "+xxx+".v_chidinh a,"+user+".v_giavp b,"+user+".doituong c,"+user+".btdkp_bv d,"+user+".dlogin e ";
			sql+=" where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp and a.userid=e.id";
			sql+=" and a.mabn='"+mabn.Text+"' and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
            //if (iChidinh == 2) sql += " and a.maql=" + maql;
            //else if (iChidinh == 3) sql += " and a.idkhoa=" + idkhoa;
            if (idkhoa > 0) sql += " and a.idkhoa=" + idkhoa;
            if (maql > 0) sql += " and a.maql=" + maql;
            if (tmn_hienthichenhlech.Checked == false) sql += " and a.hide=0";
			sql+=" order by a.ngay";
			ds=m.get_data(sql);
            ds.Tables[0].Columns.Add("Chon", typeof(bool));
            dataGrid1.DataSource = ds.Tables[0];
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            foreach (DataRow row in ds.Tables[0].Rows) row["chon"] = false;
            ref_text();
		}
		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter(ten.Text);
				list.BrowseToDanhmuc_ma(ten,mavp,soluong,80);
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (soluong.Text=="") soluong.Text="1";
				d_soluong=decimal.Parse(soluong.Text);
				soluong.Text=d_soluong.ToString("###,###.00");
			}
			catch{soluong.Text="1";}
		}

		private void ref_text()
		{
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
				madoituong.SelectedValue=dataGrid1[i_row,9].ToString();
				mavp.Text=dataGrid1[i_row,10].ToString();
				ten.Text=dataGrid1[i_row,5].ToString();
				s_dvt=dataGrid1[i_row,6].ToString();
				d_dongia=decimal.Parse(dataGrid1[i_row,11].ToString());
				d_vattu=decimal.Parse(dataGrid1[i_row,16].ToString());
				i_paid=int.Parse(dataGrid1[i_row,12].ToString());
				i_done=int.Parse(dataGrid1[i_row,13].ToString());
				d_soluong=decimal.Parse(dataGrid1[i_row,7].ToString());
				soluong.Text=d_soluong.ToString("###,###.00");
				l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
				tinhtrang.SelectedValue=dataGrid1[i_row,17].ToString();
				thuchien.SelectedValue=dataGrid1[i_row,18].ToString();
				ma.Text=dataGrid1[i_row,19].ToString();
                l_maql = (dataGrid1[i_row, 14].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_row, 14].ToString());
                l_idkhoa = (dataGrid1[i_row, 15].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_row, 15].ToString());
                l_mavaovien = (dataGrid1[i_row, 20].ToString() == "") ? 0 : decimal.Parse(dataGrid1[i_row, 20].ToString());
				d_soluongcu=d_soluong;
                DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                if (r != null)
                {
                    mabs.Text = r["mabs"].ToString();
                    DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                    chandoan.Text = r["chandoan"].ToString();
                    maicd.Text = r["maicd"].ToString();
                    tylegiam.Text = r["tylegiam"].ToString();
                    stgiam.Text = r["stgiam"].ToString();
                    lydogiam.Text = r["lydogiam"].ToString();
                    if (butLuu.Enabled && r["hide"].ToString() != "1") enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
                    else enable_giam(false);
                }
                ghichu.Text = dataGrid1[i_row, 21].ToString();
			}
			catch{}
		}


		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				sql="ten like '%"+ten.Trim()+"%'";
				if (madoituong.SelectedValue.ToString()=="1" && bLocdichvu)
				{
                    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (sothe.Text.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                    }
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
            chkmadt_def.Enabled = ena;
			if (bNhapten) hoten.Enabled=ena;
			if (bMadoituong) madoituong.Enabled=ena;
            ghichu.Enabled = tenbs.Enabled = chandoan.Enabled = (bNhapvpkhoa) ? false : ena;           
            tinhtrang.Enabled = (bNhapvpkhoa) ? false : ena;
            thuchien.Enabled = (bNhapvpkhoa) ? false : ena;            
            ma.Enabled = ena;
			ten.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLietke.Enabled=ena;
			butNet.Enabled=!ena;
			butIn.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butThem.Enabled=ena;
            enable_giam(false);
            butCholai.Enabled = ena;//gam 02/12/2011
			if (ena && l_id==0)
			{
				ghichu.Text=ten.Text=ma.Text=lydogiam.Text="";
                tylegiam.Text = stgiam.Text = "0";
				soluong.Text="1";ds.Clear();
				s_dvt="";i_paid=0;i_done=0;
				maicd.Text=mabs.Text=tenbs.Text=chandoan.Text=hoten.Text=mabn.Text="";
                if (pic.Visible)
                {
                    pic.Tag = "0000.bmp";
                    fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    map = new Bitmap(Image.FromStream(fstr));
                    pic.Image = (Bitmap)map;
                }
			}
			else butMoi.Focus();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			bNew=true;
            l_id = 0; l_idchidinh = v.get_id_chidinhll;
            //l_mavaovien = 0; l_maql = 0;
            ena_object(true);
            load_treeView();
            try
            {
                mabn.Focus();
            }
            catch { }
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
            if (m.bRavien(l_maql))
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"), LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
                return;
            }
            if (!bAdmin)
            {
                r = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r == null)
                {
                    MessageBox.Show("Người bệnh này không còn hiện diện !", LibMedi.AccessData.Msg);
                    return;
                }
                else i_madoituongvao = int.Parse(r["madoituong"].ToString());
            }
            bEdit = true;
            ref_text();
  			ena_object(true);
            bNew = false; d_soluongcu = 0;
            mabn.Enabled = hoten.Enabled = bNew;
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
            if (r != null)
            {
                hoten.Text = r["hoten"].ToString();
                nam = r["nam"].ToString();
                s_ngayvao = r["ngay"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_maql = decimal.Parse(r["maql"].ToString());
                l_idkhoa = decimal.Parse(r["id"].ToString());
                i_madoituong=i_madoituongvao = d.get_madoituong(l_maql);
                madoituong.SelectedValue = i_madoituong.ToString();
                sothe.Text = r["sothe"].ToString();
                mabs.Text = r["mabs"].ToString();
                DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                chandoan.Text = r["chandoan"].ToString();
                maicd.Text = r["maicd"].ToString();
            }
            ghichu.Text = ma.Text = ten.Text = lydogiam.Text = ""; soluong.Text = "1";
            tylegiam.Text = stgiam.Text = "0";
            butThem_Click(sender, e);
            bEdit = false;
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
                MessageBox.Show(lan.Change_language_MessageText("Nhập đối tượng !"), LibMedi.AccessData.Msg);
				madoituong.Focus();
				return false;
			}
			if (tinhtrang.SelectedIndex==-1 && !bNhapvpkhoa)
			{
                MessageBox.Show(lan.Change_language_MessageText("Nhập tình trạng !"), LibMedi.AccessData.Msg);
				tinhtrang.Focus();
				return false;
			}
            if (thuchien.SelectedIndex == -1 && !bNhapvpkhoa)
			{
                MessageBox.Show(lan.Change_language_MessageText("Nhập thực hiện !"), LibMedi.AccessData.Msg);
				thuchien.Focus();
				return false;
			}
            decimal tmp_mavv = l_mavaovien;
            l_maql = 0; l_idkhoa = 0; l_mavaovien = 0;
			if (bNew)
			{
                r = d.getrowbyid(dtll, "mabn='" + mabn.Text + "' and mavaovien=" + tmp_mavv);
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập !"),LibMedi.AccessData.Msg);
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
					return false;
				}
			}
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
				return false;
			}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
                if (mabn.Text == "")
                {
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
                }
                else if (hoten.Text == "")
                {
                    try
                    {
                        hoten.Focus();
                    }
                    catch { }                    
                }
				return false;
			}
            if (!bAdminHethong && bChidinh_dain_khongchohuy && l_id>0 && bEdit==false )
            {
                if (m.get_dain_chidinh(m.mmyy(s_ngay), l_id))
                {
                    MessageBox.Show("Đã in phiếu chỉ định, không cho phép sửa.\nĐề nghị liên hệ với người quản trị hệ thống.!", LibMedi.AccessData.Msg);
                    return false;
                }
            }
            l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
			l_maql=decimal.Parse(r["maql"].ToString());
			l_idkhoa=decimal.Parse(r["id"].ToString());
            string s_denngay = r["denngay"].ToString();
            string s_tungay = r["tungay"].ToString();
            if (madoituong.SelectedIndex != -1)
            {
                if (i_madoituongvao != 1 && int.Parse(madoituong.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Người bệnh này không phải đối tượng " + madoituong.Text, LibMedi.AccessData.Msg);
                    madoituong.Focus();
                    return false;
                }
            }
            if (bHansd_thuoc && s_denngay != "")
            {
                r = d.getrowbyid(dtdt, "madoituong=" + int.Parse(madoituong.SelectedValue.ToString()));
                if (r != null)
                {
                    if (m.songay(m.StringToDate(s_denngay), m.StringToDate(s_ngay.Substring(0, 10)), 0) < 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đối tượng")+" " + madoituong.Text + " "+lan.Change_language_MessageText("hết hạn sử dụng {") + s_denngay + "}", d.Msg);
                        if (madoituong.Enabled) madoituong.Focus();
                        else ma.Focus();
                        return false;
                    }
                    //
                    if (m.songay(m.StringToDate(s_ngay.Substring(0, 10)),m.StringToDate(s_tungay), 0) < 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đối tượng") + " " + madoituong.Text + " " + lan.Change_language_MessageText("chưa có hiệu lực sử dụng {") + s_denngay + "}", d.Msg);
                        if (madoituong.Enabled) madoituong.Focus();
                        else ma.Focus();
                        return false;
                    }
                    //
                }                
            }
			if (l_maql==0 || l_idkhoa==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
				return false;
			}
            if (bCD_BS_Chidinh && !bNhapvpkhoa)
            {
                if (tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập bác sỹ "), LibMedi.AccessData.Msg);
                    tenbs.Focus();
                    return false;
                }
                if (chandoan.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán "), LibMedi.AccessData.Msg);
                    chandoan.Focus();
                    return false;
                }
            }
			return true;
		
        }
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (ma.Text!="" && ten.Text!="")
			{
                if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                {
                    sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                    if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%' or locthe like '%"
                                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%')";
                    if (m.getrowbyid(dt, sql) == null)
                    {
                        madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                        madoituong.Update();
                    }
                }
				DataRow [] dr=dt.Select("trongoi=1 and loaitrongoi=0 and id="+int.Parse(mavp.Text));
                int _madt = (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0;
                int tmp_madt = _madt;
                if (dr.Length > 0)
                {
                    sql = "select a.*, b.sothe from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                    sql += " where a.id_gia=b.id and a.id=" + int.Parse(mavp.Text);
                    if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu) sql += " and b.bhyt>0";
                    sql += " order by a.stt";
                    foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                    {
                        l_id = 0;
                        madoituong.SelectedValue = tmp_madt;
                        madoituong.Update();
                        _madt = tmp_madt;
                        if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r1["sothe"].ToString().Trim().Trim(',') != "")
                        {
                            string s_loaithe_bn = "";
                            if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                            {
                                s_loaithe_bn = sothe.Text.Substring(2, 1);
                            }
                            else
                            {
                                s_loaithe_bn = sothe.Text.Substring(0, 2);
                            }
                            if (r1["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                            {
                                _madt = 2;
                                madoituong.SelectedValue = _madt;
                                madoituong.Update();
                            }
                        }
                        if (bChidinh_thutienlien)
                            upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["id"].ToString()));
                        else upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        if (bvuottamung) break;
                    }
                   
                    if (l_id == 0)
                    {
                        if (bChidinh_thutienlien) upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                        else upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                    }
                }
                else
                {
                    DataRow rvp = m.getrowbyid(dt, "id=" + int.Parse(mavp.Text));
                    if (rvp != null)
                    {
                        if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && rvp["sothe"].ToString().Trim().Trim(',') != "")
                        {
                            string s_loaithe_bn = "";
                            if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                            {
                                s_loaithe_bn = sothe.Text.Substring(2, 1);
                            }
                            else
                            {
                                s_loaithe_bn = sothe.Text.Substring(0, 2);
                            }
                            if (rvp["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                            {
                                _madt = 2;
                                madoituong.SelectedValue = _madt;
                                madoituong.Update();
                            }
                        }
                    }
                    if (bChidinh_thutienlien) upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                    else upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                }
			}
			m.updrec_vpkhoa(dtll,mabn.Text,hoten.Text,l_mavaovien,l_maql,l_idkhoa);
			cmbMabn.Refresh();
			cmbMabn.SelectedValue=l_idkhoa.ToString();
			ena_object(false);
		}

        private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi)
        {
            bool bCont = true;
            string fie = "gia_bh";
            decimal d_tyle_traituyen = 1;
            int s_doituong_chenhlech = (i_madt == i_tunguyen || i_madt == i_madoituongvao) ? i_madoituongvao : i_madt;//binh 050109
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + s_doituong_chenhlech);//binh 050109
            if (r != null) { fie = r["field_gia"].ToString(); bCont = r["chenhlech"].ToString() == "1"; }
            else bCont = false;
            r = m.getrowbyid(dt, "id=" + i_mavp);
            tmp_sotienchitiet = 0;
            if (r != null)
            {
                try
                {
                    tmp_sotienchitiet = decimal.Parse(r[fie].ToString()) * decimal.Parse(soluong.Text);
                }
                catch { tmp_sotienchitiet = 0; }
                //if (madoituong.SelectedValue.ToString() != "1") d_tyle_traituyen = 1;
                //else if (i_traituyen > 0) d_tyle_traituyen = decimal.Parse(r["bhyt_tt"].ToString()) / 100;
                //else d_tyle_traituyen = decimal.Parse(r["bhyt"].ToString()) / 100;

                bCont = bCont && s_chenhlech.IndexOf((bChenhlech_doituong?i_madoituongvao.ToString(): i_madt.ToString().Trim()) + ",") != -1//bCont && s_chenhlech.IndexOf(i_madoituongvao.ToString().Trim() + ",") != -1
                        && r["chenhlech"].ToString().Trim() == "1" //&& i_loaiba == 3
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (i_madoituongvao == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                if (bCont)
                {
                    madoituong.SelectedValue = i_madoituongvao.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi,bCont);
                   
                    if (bChiPhiVuotTamUngKoChoChiDinh ==false || (bChiPhiVuotTamUngKoChoChiDinh && bvuottamung == false) )
                    {
                        m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                        l_id = -l_id;// 0;
                        madoituong.SelectedValue = i_tunguyen.ToString();
                        madoituong.Update();
                        upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi, bCont);
                        m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                    }
                }
                else
                {
                    madoituong.SelectedValue = i_madt.ToString();
                    madoituong.Update();
                    //Thuy 11.10.2012  
                    if (tmp_sotienchitiet > 0)
                    {
                        if ((mavp.Text != "" && bChiPhiVuotTamUngKoChoChiDinh)||(i_mavp!=0 &&bChiPhiVuotTamUngKoChoChiDinh))
                        {
                            if (!thongbao(false, tmp_sotienchitiet, 0))
                            {
                                return;
                            }
                        }
                        else if ((mavp.Text != "" && mnu_thongbaochiphi.Checked )|| (i_mavp != 0 && bChiPhiVuotTamUngKoChoChiDinh))
                        {
                            thongbao(false, tmp_sotienchitiet, 0);
                        }
                    }
                   upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi,bCont);// goc  
                 // upd_detail(false, i_mavp, d_soluong, tmp_sotienchitiet, idtrongoi,bCont);// truongthuy 02052014  
                }
                if (bTinnhan) netsend(r["computer"].ToString());
                if (bTinnhan_sound) m.upd_tinnhan((bChidinh_noitru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_noitru_vienphi) ? "vienphi" : "cls", 1);
            }
            
        }

        private void upd_detail(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi,bool bCont_chenhlech)
        {
            string gia, giavt;
            decimal tygia, dg_giam = 0, vt_giam = 0, d_tyle_traituyen = 1,tienchenhlech=0;
            DataRow r = m.getrowbyid(dt, "id=" + i_mavp);
            string giosrv = m.ngayhienhanh_server.Substring(11);//gam 24/08/2011
            if (r != null)
            {
                if (chenhlech)
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia - decimal.Parse(r["vattu_bh"].ToString());
                    if (cl_tyle != 0 && cl_cholam != "")
                    {
                        string scholam = m.get_cholam(mabn.Text).ToString().Trim().ToLower();
                        if (cl_cholam.IndexOf(scholam) != -1 && scholam != "")
                        {
                            dg_giam = d_dongia * (cl_tyle / 100);
                            vt_giam = d_vattu * (cl_tyle / 100);
                            d_dongia -= dg_giam;
                            d_vattu -= vt_giam;
                        }
                    }
                }
                else
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;//* d_tyle_traituyen
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }

                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }
                ///////////////////
                //Lay so tien chenh lech
                if (chenhlech == false && i_madoituongvao==1 && bCont_chenhlech && (bChiPhiVuotTamUngKoChoChiDinh || mnu_thongbaochiphi.Checked))
                {
                    decimal tmp_gia_tn = 0;
                    tmp_gia_tn = decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) * d_soluong - d_dongia;
                    if (!thongbao(false, d_dongia, tmp_gia_tn))
                    {
                        if (bChiPhiVuotTamUngKoChoChiDinh && bvuottamung)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Chi phí vượt tạm ứng, nên không cho phép chỉ định tiếp."));
                            return;
                        }
                    }

                }               
                if (!v.upd_chidinh(l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay + " "+giosrv , i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (maicd.Text == "" && chandoan.Text != "") ? "U00" : maicd.Text, chandoan.Text, mabs.Text, i_loaiba,ghichu.Text))//gam 24/08/2011
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (bvuottamung && bchiphi_lonhon_tamung_khongchothuchien_cls_H27)
                {
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=3 where done=0 and id=" + l_id);
                }
                if (chenhlech) m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=1,hide=1 where done=0 and id=" + l_id);
                m.execute_data("update " + user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + i_traituyen + " where id =" + l_id);
                if (idtrongoi != 0) m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set idtrongoi=" + idtrongoi + " where id=" + l_id);
                //
                decimal d_stgiam = (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text));
                d_stgiam = d_dongia * ((tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)) / 100);  
                decimal d_tylegiam = (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text));
                if (chenhlech && tmn_chenhlechmiengiam.Checked)//phan chenh lech cung mien giam theo
                {
                    //d_stgiam = d_dongia * ((tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)) / 100);                    
                }
                else if (chenhlech && tmn_chenhlechmiengiam.Checked==false)//phan chenh lech cung mien giam theo
                {
                    d_stgiam = 0;
                    d_tylegiam = 0;
                }
                if (d_stgiam > 0) m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set tylegiam=" + d_tylegiam  + ",stgiam=" + d_stgiam + ",lydogiam='" + lydogiam.Text + "' where id=" + l_id);
                //
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                if (bvuottamung)
                {
                    m.updrec_chidinh(ds.Tables[0], l_id, s_ngay + " " + giosrv, s_makp, s_tenkp,
                    int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp,
                    r["ten"].ToString(), r["dvt"].ToString(), d_soluong, (dongia != 0) ? dongia : d_dongia,
                    (dongia != 0) ? 0 : d_vattu, 0,3, int.Parse(tinhtrang.SelectedValue.ToString()),
                    int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(),
                    (maicd.Text == "" && chandoan.Text != "") ? "U00" : maicd.Text, chandoan.Text,
                    mabs.Text, i_loaiba, ghichu.Text, d_tylegiam, d_stgiam, lydogiam.Text);
                }
                else
                {
                    m.updrec_chidinh(ds.Tables[0], l_id, s_ngay + " " + giosrv, s_makp, s_tenkp,
                        int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp,
                        r["ten"].ToString(), r["dvt"].ToString(), d_soluong, (dongia != 0) ? dongia : d_dongia,
                        (dongia != 0) ? 0 : d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()),
                        int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(),
                        (maicd.Text == "" && chandoan.Text != "") ? "U00" : maicd.Text, chandoan.Text,
                        mabs.Text, i_loaiba, ghichu.Text, d_tylegiam, d_stgiam, lydogiam.Text);
                }
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id); 
                if (dr.Length > 0)
                {
                    dr[0]["chon"] = true;
                    if (chenhlech && dr[0]["done"].ToString() == "0") dr[0]["done"] = 1;
                }
                if (dg_giam != 0)
                {
                    l_id = v.get_id_chidinh;
                    v.upd_chidinh(l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay +" " +giosrv, i_loai, s_makp, cl_doituong, i_mavp, d_soluong, dg_giam, vt_giam, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (maicd.Text == "" && chandoan.Text != "") ? "U00" : maicd.Text, chandoan.Text, mabs.Text, i_loaiba,ghichu.Text);//gam 24/08/2011
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=0,hide=1, traituyen=" + i_traituyen + " where done=0 and id=" + l_id);
                    m.updrec_chidinh(ds.Tables[0], l_id, s_ngay + " " + giosrv, s_makp, s_tenkp, cl_doituong, cl_tendoituong, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, dg_giam, vt_giam, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (maicd.Text == "" && chandoan.Text != "") ? "U00" : maicd.Text, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)), (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)), lydogiam.Text);//gam 24/08/2011
                }
            }
        }
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            load_head();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
                bool bFound = true;
				i_row=dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i_row, 1].ToString());
                /*
                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["paid"].ToString() == "1" || tmp.Rows[0]["done"].ToString() == "1") //(dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }*/

                //Tu:19/08/2011 kiem tra benh nhan xuat khoa thi ko cho xoa //gam comment ngày 17/09/2011 --> bà rịa yêu cầu admin được quyền hủy khi bệnh nhân đã xuất khoa
                //DataRow r0 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                //if (r0 == null)
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra khỏi khoa !"), LibMedi.AccessData.Msg);
                //    return;
                //}//end Tu

                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["madoituong"].ToString()=="1" && tmp.Rows[0]["paid"].ToString() != "1")
                    {
                        DataTable tmp_cl = m.getChidinh_chenhlech_dathanhtoan(s_ngay, decimal.Parse(tmp.Rows[0]["maql"].ToString()), int.Parse(tmp.Rows[0]["mavp"].ToString()));
                        if (tmp_cl.Rows.Count > 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền phần chênh lệch, không thể hủy !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    if (!bAdminHethong && tmp.Rows[0]["hide"].ToString() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Phần chênh lệch dịch vụ, không hủy được, đề nghị liên hệ phòng máy tính!"), LibMedi.AccessData.Msg);
                        return;
                    }
                    if (tmp.Rows[0]["paid"].ToString() == "1" || tmp.Rows[0]["done"].ToString() == "1")//(dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1")
                    {
                        bFound = false;
                        if (tmp.Rows[0]["done"].ToString() == "1" && tmp.Rows[0]["paid"].ToString() == "0")//(dataGrid1[i_row, 13].ToString() == "1" && dataGrid1[i_row, 12].ToString() == "0")
                        {
                            //gam 26/10/2011
                            //if (!bAdminHethong)
                            //{
                            //    DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                            //    if (r != null)
                            //    {
                            //        if (int.Parse(r["madoituong"].ToString()) == i_tunguyen)
                            //            bFound = m.getrowbyid(dt, "chenhlech=1 and id=" + decimal.Parse(r["mavp"].ToString())) != null;
                            //    }
                            //}
                            //else bFound = true; 
                            //if (!bFound)
                            //{
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ này đã thực hiện, không hủy được !"), LibMedi.AccessData.Msg);
                                return;
                            //}
                        }
                        else //da dong tien
                        {
                            if (bAdminHethong && tmp.Rows[0]["idttrv"].ToString()=="0")
                            {
                                //DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền, Bạn có muốn hủy không !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                //if (dlg == DialogResult.No) return;
                            }
                            else
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền, không thể hủy !"), LibMedi.AccessData.Msg);
                                return;
                            }
                        }
                    }
                    //Tu:10/08/2011
                    if (tmp.Rows[0]["done"].ToString() == "2")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật, không thể hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                    //end Tu
                }
                //if (!bFound)
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                //    return;
                //}

                DataRow r1 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r1 == null && !bAdmin && !bAdminHethong)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra khỏi khoa !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (!bAdminHethong && bChidinh_dain_khongchohuy)
                {
                    if (m.get_dain_chidinh(m.mmyy(s_ngay), l_id))
                    {
                        MessageBox.Show("Đã in không có hủy !", LibMedi.AccessData.Msg);
                        return;
                    }
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
                    string mmyy=m.mmyy(s_ngay);
                    int itable = m.tableid(mmyy, "v_chidinh");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".v_chidinh", "id = " + l_id));
                    //
                    //                    
                    //string s_field = d.f_get_select_field_mmyy(mmyy, "v_chidinh", "");
                    //if (s_field != "")
                    //{
                    sql = "insert into " + xxx + ".v_chidinh_huy (id, mabn, maql, mavaovien, mavp, madoituong, dongia, ngay, makp, userid, ngayud)  select id, mabn, maql, mavaovien, mavp, madoituong, dongia, ngay, makp, " + i_userid + " as userid, now() as ngayud from " + xxx + ".v_chidinh where id in(" + l_id + ",-" + l_id + ")";
                        m.execute_data(sql);
                    //}
                    //
                    //
                    m.execute_data("delete from " + xxx + ".v_chidinh where id=" + l_id);
                    m.execute_data("delete from " + xxx + ".v_chidinh where id=-" + l_id);
					m.delrec(ds.Tables[0],"id="+l_id);
                    m.delrec(ds.Tables[0], "id=-" + l_id);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        m.delrec(dtll, "mabn='" + cmbMabn.Text + "' and mavaovien=" + l_mavaovien);
                        cmbMabn.DataSource = dtll;
                    }
					ref_text();
                    
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butLietke_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) 
                return;
            i_madoituong=int.Parse(madoituong.SelectedValue.ToString());
            frmChonchidinh f = new frmChonchidinh(m, mabn.Text, i_madoituong, s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false, l_mavaovien);
            f.SapxepTenKT_TheoABC = mnuSapXepTenTheoABC.Checked;
			f.ShowDialog(this);
			if (f.dt.Rows.Count>0)
			{
				DataRow [] dr;
                DataRow rvp;
                int _madt = (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0;
                int tmp_madt = _madt;
				foreach(DataRow r in f.dt.Rows)
				{
                    _madt = tmp_madt;
                    madoituong.SelectedValue = _madt;
                    madoituong.Update();
					l_id=0;
					dr=dt.Select("trongoi=1 and id="+int.Parse(r["mavp"].ToString()));
                    if (!bLocdichvu && _madt == 1)
                    {
                        sql = "id=" + decimal.Parse(r["mavp"].ToString()) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%'or locthe like '%"
                                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                            _madt = 2;
                        }
                    }
                   
                    if (dr.Length > 0)
                    {
                        sql = "select a.*, b.sothe from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                        sql += " where a.id_gia=b.id and a.id=" + int.Parse(r["mavp"].ToString());
                        if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu) sql += " and b.bhyt>0";
                        sql += " order by a.stt";
                        foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                        {
                            l_id = 0;
                            madoituong.SelectedValue = tmp_madt.ToString();
                            madoituong.Update();
                            if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r1["sothe"].ToString().Trim().Trim(',') != "")
                            {
                                string s_loaithe_bn = "";
                                if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                                {
                                    s_loaithe_bn = sothe.Text.Substring(2, 1);
                                }
                                else
                                {
                                    s_loaithe_bn = sothe.Text.Substring(0, 2);
                                }
                                if (r1["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                                {
                                    madoituong.SelectedValue = 2;
                                    madoituong.Update();
                                }
                            }
                            if (bChidinh_thutienlien)
                                upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["id"].ToString()));
                            else upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                            if (bvuottamung) break;
                        }
                    
                        if (l_id == 0)
                        {
                            if (bChidinh_thutienlien) upd_data(int.Parse(r["mavp"].ToString()),decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                            else upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()));
                        }
                    }
                    else
                    {
                        rvp = m.getrowbyid(dt, "id=" + r["mavp"].ToString());
                        if (rvp != null)
                        {
                            if (_madt == 1 && sothe.Text.Trim() != "" && rvp["sothe"].ToString().Trim().Trim(',') != "")
                            {
                                string s_loaithe_bn = "";
                                if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                                {
                                    s_loaithe_bn = sothe.Text.Substring(2, 1);
                                }
                                else
                                {
                                    s_loaithe_bn = sothe.Text.Substring(0, 2);
                                }
                                if (rvp["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                                {
                                    madoituong.SelectedValue = 2;
                                    madoituong.Update();
                                }
                            }
                        }
                        //
                        if (bChidinh_thutienlien) upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                        else upd_data(int.Parse(r["mavp"].ToString()),decimal.Parse(r["soluong"].ToString()));
                        if (bChiPhiVuotTamUngKoChoChiDinh && bvuottamung == true)
                            break;
                    }
				}
                m.updrec_vpkhoa(dtll, mabn.Text, hoten.Text, l_mavaovien, l_maql, l_idkhoa);
                cmbMabn.Refresh();
                cmbMabn.SelectedValue = l_idkhoa.ToString();
                ena_object(false);
			}
			//butLuu_Click(sender,e);
		}

        private void load_treeView___________()
        {
            treeView1.Nodes.Clear();
            if (nam == "" || s_ngayvao == "") return;
            TreeNode node;
            //if (l_idkhoa==0) //gam 05/12/2011  
            //{
            //    sql="select distinct b.ngay,b.mavaovien,a.maql,0 as idkhoa from "+s_table+" a,xxx.v_chidinh b where a.maql=b.maql";
            //    sql+=" and a.mabn='"+mabn.Text+"'";
            //    if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
            //    sql+=" order by b.ngay desc";
            //}
            //else
            //{
            sql = "select distinct b.ngay,b.mavaovien,a.maql,a.id as idkhoa from " + s_table + " a,xxx.v_chidinh b where a.id=b.idkhoa";
            sql += " and a.mabn='" + mabn.Text + "'";
            if (iChidinh == 2) sql += " and a.maql='" + l_maql + "'";
            else if (iChidinh == 3) sql += " and a.id='" + l_idkhoa + "'";
            sql += " order by b.ngay desc";
            //}
            dtngay = m.get_data_mmyy(sql, s_ngayvao, s_ngay.Substring(0, 10), false).Tables[0];// : m.get_data_nam(nam, sql).Tables[0];//gam 05/12/2011 
            foreach (DataRow r in dtngay.Rows)
            {
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + "-" + r["idkhoa"].ToString());
                sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id";
                if (l_idkhoa == 0) sql += " and a.maql=" + decimal.Parse(r["maql"].ToString());
                else sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                sql += " and a.mabn='" + mabn.Text + "'";
                sql += " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + "'";//gam 22/09/2011 thêm đk hh24:mi khi add node con
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    node.Nodes.Add(r1["ten"].ToString());
                r["ngay"] = m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
            }
        }
		private void load_treeView()
		{
			treeView1.Nodes.Clear();
            if (nam == "" || s_ngayvao == "") return;
			TreeNode node=null;
            //if (l_idkhoa==0) //gam 05/12/2011  
            //{
            //    sql="select distinct b.ngay,b.mavaovien,a.maql,0 as idkhoa from "+s_table+" a,xxx.v_chidinh b where a.maql=b.maql";
            //    sql+=" and a.mabn='"+mabn.Text+"'";
            //    if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
            //    sql+=" order by b.ngay desc";
            //}
            //else
            //{
				sql="select distinct to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.mavaovien,b.maql,a.id as idkhoa, c.ten, c.ma from "+s_table+" a,xxx.v_chidinh b, medibv.v_giavp c where a.id=b.idkhoa and b.mavp=c.id";
				sql+=" and a.mabn='"+mabn.Text+"'";
				if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
				else if (iChidinh==3) sql+=" and a.id='"+l_idkhoa+"'";
				sql+=" order by b.ngay desc";
            //}
            dtngay = m.get_data_mmyy(sql, s_ngayvao, s_ngay.Substring(0, 10), false).Tables[0];// : m.get_data_nam(nam, sql).Tables[0];//gam 05/12/2011 
            //
            string tmp_node = "";
            //
			foreach(DataRow r in dtngay.Rows)
			{
                if (tmp_node != r["ngay"].ToString() + "-" + r["idkhoa"].ToString())
                {
                    tmp_node = r["ngay"].ToString() + "-" + r["idkhoa"].ToString();
                    node = treeView1.Nodes.Add(tmp_node);
                    node.Nodes.Add(r["ten"].ToString() + " [" + r["ma"].ToString() + "]");
                }
                else
                {
                    node.Nodes.Add(r["ten"].ToString() + " [" + r["ma"].ToString() + "]");
                }
                //node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))+"-"+r["idkhoa"].ToString());
                //sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id";
                //if (l_idkhoa == 0) sql += " and a.maql=" + decimal.Parse(r["maql"].ToString());
                //else sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                //sql += " and a.mabn='" + mabn.Text + "'";
                //sql += " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + "'";//gam 22/09/2011 thêm đk hh24:mi khi add node con
                //foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                //    node.Nodes.Add(r1["ten"].ToString());
                //r["ngay"] = m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
                select_list();
			}
		}
        private void select_list()
        {
            try
            {
                DataRow r = m.getrowbyid(dt, "id=" + int.Parse(mavp.Text));
                if (r != null)
                {
                    if (bNhapPTTT_chidinh_vpkhoa_miengiam) enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
                    s_dvt = r["dvt"].ToString();
                    ten.Text = r["ten"].ToString();
                    ma.Text = r["ma"].ToString();
                    if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%' or locthe like '%"
                                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {

                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
                    //
                    //if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r["sothe"].ToString().Trim().Trim(',') != "") 
                    //{
                    //    string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                    //    if (r["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                    //    {
                    //        madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                    //        madoituong.Update();
                    //    }
                    //}
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }
            }
            catch { s_dvt = ""; d_dongia = 0; d_vattu = 0; }
        }

		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tinhtrang.SelectedIndex==-1) tinhtrang.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}

		private void thuchien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (thuchien.SelectedIndex==-1) thuchien.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mavp_Validated(object sender, System.EventArgs e)
		{
			 if (ma.Text!="")
			{
				sql="ma='"+ma.Text+"'";
                if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu)
                {
                    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (sothe.Text.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                    }
                }
                //if (madoituong.SelectedValue.ToString()=="1" && bLocdichvu)
                //{
                //    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                //    {
                //        if (sothe_jl.IndexOf(sothe.Text.Substring(vitri_jl - 1, 1)) != -1)
                //        {
                //            sql += " and bhyt<>0";
                //            if (sothe.Text.Trim().Length > v1 + v2)
                //            {
                //                sql += " and (locthe='' or locthe is null or locthe like '%"
                //                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%' or locthe like '%"
                //                    + sothe.Text.Substring(0, 2) + ",%')";
                //            }
                //        }
                //        else
                //        {
                //            madoituong.SelectedValue = 2;
                //        }
                //    }
                //    else
                //    {
                //        sql += " and bhyt<>0";
                //        if (sothe.Text.Trim().Length > v1 + v2)
                //        {
                //            sql += " and (locthe='' or locthe is null or locthe like '%" 
                //                + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" 
                //                + sothe.Text.Substring(0, 2) + ",%')";
                //        }
                //    }
                //}
				DataRow r=m.getrowbyid(dt,sql);
				if (r!=null)
				{
					mavp.Text=r["id"].ToString();
                    if (bNhapPTTT_chidinh_vpkhoa_miengiam) enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
					s_dvt=r["dvt"].ToString();
					ten.Text=r["ten"].ToString();
                    if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2)
                        {
                            sql += " and (locthe='' or locthe is null or locthe like '%" 
                                + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" 
                                + sothe.Text.Substring(0, 2) + ",%' or locthe like '%"
                                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%')";
                        }
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
                    //
                    //if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r["sothe"].ToString().Trim().Trim(',') != "")
                    //{
                    //    string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                    //    if (r["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                    //    {
                    //        madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                    //        madoituong.Update();
                    //    }
                    //}
                    //
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
				}				
			}
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butNet_Click(object sender, System.EventArgs e)
		{
			string s1="",s2="";
			DataRow r1;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				r1=m.getrowbyid(dt,"id="+int.Parse(r["mavp"].ToString()));
				if (r1!=null)
					if (s1.IndexOf(r1["computer"].ToString().Trim()+"+")==-1) s1+=r1["computer"].ToString().Trim()+"+";
			}			
			m.writeXml("d_netsend","ma",s1);
			m.writeXml("d_netsend","ten",s2);
			NetSend f=new NetSend();
			f.ShowDialog(this);
		}

        private void netsend(String computer)
        {
            if (bTinnhan && computer != "")
                d.netsend(d.sDomain(m.nhom_duoc), computer, mabn.Text + " " + m.khongdau(hoten.Text));
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

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHoten.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHoten.Visible) listHoten.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,tenbs);
			}
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn)
			{
				try
				{
					l_idkhoa=decimal.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_idkhoa=0;}
				load_head();
			}
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
            nam = ""; s_ngayvao = "";
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
            if (mabn.Text.Trim().Length != i_maxlength_mabn) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');//(6,'0');
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
                nam = r["nam"].ToString();
                s_ngayvao = r["ngay"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["id"].ToString());
                i_traituyen  =(r["traituyen"].ToString()=="")?0:int.Parse(r["traituyen"].ToString());
				i_madoituong=i_madoituongvao=d.get_madoituong(l_maql);
				madoituong.SelectedValue=i_madoituong.ToString();
				sothe.Text=r["sothe"].ToString();
                mabs.Text = r["mabs"].ToString();
                DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                chandoan.Text = r["chandoan"].ToString();
                maicd.Text = r["maicd"].ToString();
                //linh 25092012
                if (m.SoSanhNgay(s_ngayvaovienbenhnhantheothongtulientich, s_ngayvao) >= 0)
                {
                    dt = m.get_dmvp(s_ngayvao, s_loaivp, s_mucvp, v.iNgoaitru).Tables[0];
                }
                else
                {
                    dt = m.get_dmvp(s_ngayvaovienbenhnhantheothongtulientich, s_loaivp, s_mucvp, v.iNgoaitru).Tables[0];
                }//end
                if (pic.Visible)
                {
                    foreach (DataRow r2 in d.get_data("select * from " + d.user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows)
                    {
                        try
                        {
                            image = new byte[0];
                            image = (byte[])(r2["image"]);
                            memo = new MemoryStream(image);
                            map = new Bitmap(Image.FromStream(memo));
                            pic.Image = (Bitmap)map;
                        }
                        catch
                        {
                            pic.Tag = "0000.bmp";
                            fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            map = new Bitmap(Image.FromStream(fstr));
                            pic.Image = (Bitmap)map;
                        }
                    }
                }
                if (tmn_xemlaichidinh.Checked)
                {
                    load_treeView();
                }
			}
            else { hoten.Text = ""; l_mavaovien = 0; l_maql = 0; l_idkhoa = 0; sothe.Text = ""; }
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"mabn='"+mabn.Text+"' and mavaovien="+l_mavaovien);
				if (r!=null)
				{
					DialogResult dlg= MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập. Bạn có muốn sửa không?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
					if(dlg==DialogResult.No)
					{
                        try
                        {
                            mabn.Focus();
                        }
                        catch { }
						return;
					}
					else
					{
						l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
						cmbMabn.SelectedValue=l_idkhoa.ToString();
						load_head();
						butSua_Click(null,null);
					}
				}
			}
			catch{}
            load_congno();
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}

		private void load_head()
		{
            if (l_idkhoa != 0)
                r = m.getrowbyid(dtll, "idkhoa='" + l_idkhoa+"'");
            else
                r = m.getrowbyid(dtll, "mabn='" + cmbMabn.Text + "'");
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
                DataRow r1 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r1 != null)
                {
                    nam = r1["nam"].ToString();
                    s_ngayvao = r1["ngay"].ToString();
                    sothe.Text = r1["sothe"].ToString();
                }
				if (m.iChidinh!=4) load_treeView();
                if (pic.Visible)
                {
                    foreach (DataRow r2 in d.get_data("select * from " + d.user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows)
                    {
                        try
                        {
                            image = new byte[0];
                            image = (byte[])(r2["image"]);
                            memo = new MemoryStream(image);
                            map = new Bitmap(Image.FromStream(memo));
                            pic.Image = (Bitmap)map;
                        }
                        catch
                        {
                            pic.Tag = "0000.bmp";
                            fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            map = new Bitmap(Image.FromStream(fstr));
                            pic.Image = (Bitmap)map;
                        }
                    }
                }
			}
			else l_idkhoa=0;
			load_grid(l_maql,l_idkhoa);
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			
            if (!kiemtra()) 
                return;

            //gam 16/08/2011
            string s_vitri_xet_chiphivanchuyen = d.thetunguyen_vitri(1);
            int iKytubegin_xet_chiphivanchuyen = 0, ikytuend_xet_chiphivanchuyen = 0;
            try
            {
                iKytubegin_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(0, 1));
                ikytuend_xet_chiphivanchuyen = int.Parse(s_vitri_xet_chiphivanchuyen.Substring(2, 1));

            }
            catch
            {
                iKytubegin_xet_chiphivanchuyen = 0;
                ikytuend_xet_chiphivanchuyen = 2;
            }
            //end gam
                    
			if (ma.Text!="" && ten.Text!="" && l_id>=0)
			{
				//l_id=0;
                int _madt = (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0;
                int tmp_madt = _madt;
				DataRow [] dr=dt.Select("trongoi=1 and loaitrongoi=0 and id="+int.Parse(mavp.Text));
                if (dr.Length > 0)
                {
                    sql = "select a.*, b.sothe from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                    sql += " where a.id_gia=b.id and a.id=" + int.Parse(mavp.Text);
                    if (madoituong.SelectedValue.ToString() == "1") sql += " and b.bhyt>0";
                    sql += " order by a.stt";
                    foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                    {
                        l_id = 0;
                        madoituong.SelectedValue = tmp_madt; ;
                        madoituong.Update();
                        _madt = int.Parse(madoituong.SelectedValue.ToString());

                        if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r1["sothe"].ToString().Trim().Trim(',') != "")
                        {
                            //string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);//gam 18/08/2011 
                            string s_loaithe_bn = sothe.Text.Substring(iKytubegin_xet_chiphivanchuyen,ikytuend_xet_chiphivanchuyen);
                            if (r1["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                            {
                                _madt = 2;
                                madoituong.SelectedValue = _madt;
                                madoituong.Update();
                            }
                        }
                        if (bChidinh_thutienlien)
                            upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), 0, int.Parse(r1["id"].ToString()));// decimal.Parse(r1["sotien"].ToString())
                        else
                            upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        if (bvuottamung) break;
                    }
                  
                    if (l_id == 0)
                    {
                        if (bChidinh_thutienlien)
                            upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                        else upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                    }
                }
                else
                {
                    DataRow rvp = m.getrowbyid(dt, "id=" + int.Parse(mavp.Text));
                    if (rvp != null)
                    {
                        if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && rvp["sothe"].ToString().Trim().Trim(',') != "")
                        {
                            string s_loaithe_bn = "";
                            if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                            {
                                s_loaithe_bn = sothe.Text.Substring(2, 1);
                            }
                            else
                            {
                                s_loaithe_bn = sothe.Text.Substring(0, 2);
                            }
                            if (rvp["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                            {
                                _madt = 2;
                                madoituong.SelectedValue = _madt;
                                madoituong.Update();
                            }
                        }
                    }
                    if (bChidinh_thutienlien)
                    {
                        //upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                        if (decimal.Parse(soluong.Text) > 1 && m.bXetnghiem_cdha(mavp.Text))// gam 07/12/2011 nếu chỉ định viện phí thuộc nhóm xét nghiệm hoặc CDHA thì insert số dòng = số lượng
                        {
                            for (int i = 0; i < decimal.Parse(soluong.Text); i++)
                            {
                                upd_data(int.Parse(mavp.Text),1, _madt, 0, 0);
                                l_id = 0;
                                b_cholai = true;
                            }
                            b_cholai = false;
                        }
                        else
                        {
                            upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                        }
                    }
                    else
                    {
                        //upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                        if (decimal.Parse(soluong.Text) > 1 && m.bXetnghiem_cdha(mavp.Text))// gam 07/12/2011 nếu chỉ định viện phí thuộc nhóm xét nghiệm hoặc CDHA thì insert số dòng = số lượng
                        {
                            for (int i = 0; i < decimal.Parse(soluong.Text); i++)
                            {
                                upd_data(int.Parse(mavp.Text),1);
                                l_id = 0;
                                b_cholai = true;
                            }
                            b_cholai = false;
                        }
                        else
                        {
                            upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                        }
                    }

                    ///Begin Dong
                    //i_tutuoi = int.Parse(rvp["tutuoi"].ToString());

                    //i_dentuoi = int.Parse(rvp["dentuoi"].ToString());
                    //s_gtvp = rvp["gioitinh"].ToString();
                    //if (f_Kiemtra_ThemHepa(int.Parse(mavp.Text.Trim())))
                    //{
                    //    //upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                    //    //getTong();
                    //    //load_grid();
                    //    //ena_object(false);
                    //}
                }
                ///End Dong
                //madoituong.SelectedValue=i_madoituong.ToString();
                //ghichu.Text=ma.Text=ten.Text=lydogiam.Text="";soluong.Text="1";
                //tylegiam.Text = stgiam.Text = "0";
			}
            madoituong.SelectedValue = i_madoituong.ToString();
            ghichu.Text = ma.Text = ten.Text = lydogiam.Text = ""; soluong.Text = "1";
            tylegiam.Text = stgiam.Text = "0";
            //
            l_id = 0;
            if (tenbs.Enabled) tenbs.Focus();
            else if (chandoan.Enabled) chandoan.Focus();
            else if (tinhtrang.Enabled) tinhtrang.Focus();
            else if (thuchien.Enabled) thuchien.Focus();
            else if (madoituong.Enabled) madoituong.Focus();
            else ma.Focus();
		}
        private bool f_Kiemtra_ThemHepa(int mavp)
        {
            string s_mavpxungdot = "", s_mabn = "";
            int i_ktraxungdot;
            s_mavpxungdot = m.mavpxungdot(mavp);
            if (s_mavpxungdot != "")
            {
                string[] Arr = s_mavpxungdot.Split(',');
                for (int i = 0; i < Arr.Length; i++)
                {
                    s_mabn = cmbMabn.Text.Trim().ToString();
                    i_ktraxungdot = int.Parse(Arr[i].ToString());
                    foreach (DataRow dr in m.get_data_mmyy(" select a.mavp,b.ten from xxx.v_chidinh a left join " + user + ".v_giavp b on a.mavp=b.id left join " + user + ".v_loaivp c on b.id_loai=c.id where c.id_nhom=2 and a.mavaovien=" + l_mavaovien + " and a.mabn=" + s_mabn, "", "", true).Tables[0].Rows)
                    {
                        int i_mavpxd = int.Parse(dr["mavp"].ToString());
                        string s_tenvpxungdot = dr["ten"].ToString();
                        if (i_ktraxungdot == i_mavpxd)
                        {
                            DialogResult dl = MessageBox.Show(lan.Change_language_MessageText(" Kỹ Thuật Này Xung Đột Với " + s_tenvpxungdot), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (dl == DialogResult.No)
                            {
                                ten.Focus();
                                return false;
                            }
                        }
                    }
                }
            }
            if (s_gtvp != "")
            {
                if (s_gtvp.IndexOf(s_gioitinh) == -1)
                {
                    DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Giới tính không họp lệ so với danh mục giá viện phí đã khai báo."), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dl == DialogResult.No)
                    {
                        ten.Focus();
                        return false;
                    }
                }
            }
            if ((i_tutuoi != 0 && i_dentuoi != 0) && (i_tuoi < i_tutuoi || i_tuoi > i_dentuoi))
            {
                DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Tuổi không họp lệ so với danh mục giá viện phí đã khai báo."), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dl == DialogResult.No)
                {
                    ten.Focus();
                    return false;
                }
            }
            return true;
        }
		private void upd_data(int i_mavp,decimal d_soluong)
		{
            DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
            if (r != null)
            {
                if (r["done"].ToString() == "1" || r["paid"].ToString() == "1")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
			r=m.getrowbyid(dt,"id="+i_mavp);
            tmp_sotienchitiet = 0;
			if (r!=null)
            {
                try
                {
                    tmp_sotienchitiet = decimal.Parse(r["gia_tp"].ToString()) * decimal.Parse(soluong.Text);
                }
                catch { tmp_sotienchitiet = 0; }
                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }              
                string gia = m.field_gia(madoituong.SelectedValue.ToString());
                string giavt = "vattu_" + gia.Substring(4).Trim();
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                string giosrv = m.ngayhienhanh_server.Substring(11);
                //Thuy 11.10.2012
                if (tmp_sotienchitiet > 0)
                {
                    if (bChiPhiVuotTamUngKoChoChiDinh)
                    {
                        if (!thongbao(false, d_dongia, 0)) return;
                    }
                    else if (mnu_thongbaochiphi.Checked)
                    {
                        thongbao(false, d_dongia, 0);
                    }
                }
				if (!v.upd_chidinh(l_id,mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay.Substring(0,10)+" "+giosrv,i_loai,s_makp,int.Parse(madoituong.SelectedValue.ToString()),i_mavp,d_soluong,d_dongia,d_vattu,i_userid,int.Parse(tinhtrang.SelectedValue.ToString()),int.Parse(thuchien.SelectedValue.ToString()),l_idchidinh,maicd.Text,chandoan.Text,mabs.Text,1,ghichu.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"),LibMedi.AccessData.Msg);
					return;
				}
                m.execute_data("update " + m.user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + i_traituyen + ",tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)) + ",stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)) + ",lydogiam='" + lydogiam.Text + "',dachenhlech=0  where id =" + l_id);//gam 16/11/2011
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                m.updrec_chidinh(ds.Tables[0], l_id, s_ngay.Substring(0, 10) + " " + giosrv, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, d_dongia, d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), maicd.Text, chandoan.Text, mabs.Text, 1, ghichu.Text, (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)), (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)), lydogiam.Text);
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0) dr[0]["chon"] = true;
                if (bTinnhan) netsend(r["computer"].ToString());
                if (bTinnhan_sound) m.upd_tinnhan((bChidinh_noitru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_noitru_vienphi) ? "vienphi" : "cls", 1);
			}
        }
        private void upd_data_cholai(int i_mavp, decimal d_soluong)
        {
            DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
            if (r != null)
            {
                if (r["done"].ToString() == "1" || r["paid"].ToString() == "1")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }
                string gia = m.field_gia(madoituong.SelectedValue.ToString());
                string giavt = "vattu_" + gia.Substring(4).Trim();
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                string giosrv = m.ngayhienhanh_server.Substring(11);
                //Thuy 11.10.2012
                if (bChiPhiVuotTamUngKoChoChiDinh)
                {
                    if (!thongbao(false,d_dongia,0)) return;
                }
                else if (mnu_thongbaochiphi.Checked)
                {
                    thongbao(false,d_dongia,0);
                }
                if (!v.upd_chidinh(l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay.Substring(0, 10) + " " + giosrv, i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, d_dongia, d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, maicd.Text, chandoan.Text, mabs.Text, 1, ghichu.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                    return;
                }
                m.execute_data("update " + m.user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + i_traituyen + ",tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)) + ",stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)) + ",lydogiam='" + lydogiam.Text + "',dachenhlech=0  where id =" + l_id);//gam 16/11/2011
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                //m.updrec_chidinh(ds.Tables[0], l_id, s_ngay.Substring(0, 10) + " " + giosrv, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, d_dongia, d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), maicd.Text, chandoan.Text, mabs.Text, 1, ghichu.Text, (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)), (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)), lydogiam.Text);
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0) dr[0]["chon"] = true;
                if (bTinnhan) netsend(r["computer"].ToString());
                if (bTinnhan_sound) m.upd_tinnhan((bChidinh_noitru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_noitru_vienphi) ? "vienphi" : "cls", 1);
            }
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
            string s_id = "";
            
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true"))
            {
                s_id += r1["id"].ToString() + ",";
                if(bChidinh_dain_khongchohuy)m.execute_data("update " + xxx + ".v_chidinh set lan=lan+1 where id=" + decimal.Parse(r1["id"].ToString()));
            }
            if (bChidinh_dain_khongchohuy)
            {
                if (s_id.Trim().Trim(',') == "")
                {
                    foreach (DataRow r1 in ds.Tables[0].Rows)
                        m.execute_data("update " + xxx + ".v_chidinh set lan=lan+1 where id=" + decimal.Parse(r1["id"].ToString()));
                }
                else
                {
                    sql = "update " + xxx + ".v_chidinh set lan=lan+1 where id in (" + s_id.Trim().Trim(',') + ")";
                    m.execute_data(sql);
                }
            }
            if (m.bCapSTT_Chidinh_Loaivp_H20) m.f_get_stt_cls_loaivp(s_ngay, mabn.Text, l_maql.ToString());
            //
            if (m.bInchidinh_dien && s_id != "")
            {                
                DLLPrintchidinh.frmPrintchidinh f1 = new DLLPrintchidinh.frmPrintchidinh();//dllprintchidinh
                f1.f_Print_Chidinh(false, mabn.Text, l_maql.ToString(), "", s_ngay.Substring(0, 10), s_id);
                return;
            }
            //
            
            sql = "select a.mabn,a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia+a.vattu as dongia,a.soluong*(a.dongia+a.vattu) as sotien,a.maql,a.idkhoa,b.ma, ";
            sql += "l.hoten,l.namsinh,case when l.phai=0 then 'Nam' else 'Nữ' end as phai,";
            sql += "trim(l.sonha)||' '||trim(l.thon)||' '||trim(o.tenpxa)||','||trim(n.tenquan)||','||trim(m.tentt) as diachi,";
			sql+="nullif(f.sothe,' ') as sothe,to_char(f.denngay,'dd/mm/yyyy') as denngay,nullif(h.tenbv,' ') as noigioithieu,";
			sql+="nullif(i.tenbv,' ') as noicap,e.giuong as sogiuong,to_char(p.ngay,'dd/mm/yyyy') as ngayvao,";
            sql+="e.maicd,coalesce(a.chandoan,e.chandoan) as chandoan,";
            sql+="k.stt as sttnhom,k.ten as nhom,j.stt as sttloai,j.ten as loai,";
            sql+="a.mabs,q.hoten as tenbs,a.ghichu";
            sql += ", a.loaiba, to_char(f.tungay,'dd/mm/yyyy') as tungay";
            sql += ", case when f.traituyen is null then 0 else f.traituyen end as traituyen";
            sql += ", case when lh.tuoivao is null then '0000' else lh.tuoivao end as tuoivao, l.cholam,p.sovaovien ";
            //sql += ",a.stt as sttcho ,'"+username+"' as nguoiin"; //Khuong 09/12/2011
            sql += ", a.stt as sttcho,a1.hoten as user,s.ten as thuchien,b.stt ";
			sql+=" from "+xxx+".v_chidinh a inner join "+user+".v_giavp b on a.mavp=b.id ";
            sql += " inner join " + user + ".dlogin a1 on a.userid=a1.id ";
            sql+=" inner join "+user+".doituong c on a.madoituong=c.madoituong ";
            sql+=" inner join "+user+".btdkp_bv d on a.makp=d.makp ";
            sql+=" inner join "+user+".nhapkhoa e on a.idkhoa=e.id ";
            sql+=" left join "+user+".bhyt f on a.maql=f.maql ";
            sql+=" left join "+user+".noigioithieu g on a.maql=g.maql ";
            sql+=" left join "+user+".tenvien h on g.mabv=h.mabv ";
            sql+=" left join "+user+".dmnoicapbhyt i on f.mabv=i.mabv ";
            sql+=" inner join "+user+".v_loaivp j on b.id_loai=j.id ";
            sql+=" inner join "+user+".v_nhomvp k on j.id_nhom=k.ma ";
			sql+=" inner join "+user+".btdbn l on a.mabn=l.mabn ";
            sql+=" inner join "+user+".btdtt m on l.matt=m.matt ";
            sql+=" inner join "+user+".btdquan n on l.maqu=n.maqu ";
            sql+=" inner join "+user+".btdpxa o on l.maphuongxa=o.maphuongxa ";
            sql+=" inner join "+user+".benhandt p on a.maql=p.maql ";
            sql += " left join " + user + ".dmbs q on a.mabs=q.ma ";
            if (i_loaiba == 1 || i_loaiba == 2)
            {
                sql += " left join " + user + ".lienhe lh on a.maql=lh.maql ";
            }
            else
            {
                sql += " left join " + xxx + ".lienhe lh on a.maql=lh.maql ";
            }
            sql += " inner join " + user + ".dmthuchien s on a.thuchien=s.id ";
			sql+=" where a.mabn='"+mabn.Text+"' and a.hide=0 and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
            if (s_id != "") sql += " and a.id in (" + s_id.Substring(0, s_id.Length - 1) + ")";
            sql += " and (f.sudung is null or f.sudung=1)";
            if (bChidinh_loaivp) sql += " order by j.ten";
			else sql+=" order by k.ten";          
            sql += ",b.ten";
			DataSet dsxml=v.get_data(sql);
			if (dsxml.Tables[0].Rows.Count>0)
			{
                string s_cdkemtheo = m.f_get_cdkemtheo(s_ngay, l_maql, 2);
                if (bChuky)
                {
                    DataColumn dc = new DataColumn("Image", typeof(byte[]));
                    dsxml.Tables[0].Columns.Add(dc);
                    foreach (DataRow r in dsxml.Tables[0].Rows)
                    {
                        if (s_cdkemtheo.Trim().Trim(',') != "") r["chandoan"] += ((r["chandoan"].ToString().Trim() == "") ? "" : ", ") + s_cdkemtheo;
                        //
                        if (File.Exists("..//..//..//chuky//" + r["mabs"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..//..//..//chuky//" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r["Image"] = image;
                        }
                    }
                }
                else if (s_cdkemtheo.Trim().Trim(',') != "")
                {
                    foreach (DataRow r in dsxml.Tables[0].Rows)
                    {
                        r["chandoan"] += ((r["chandoan"].ToString().Trim() == "") ? "" : ", ") + s_cdkemtheo;
                    }
                }
                dsxml.AcceptChanges();
                if (mnu_writexml.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    dsxml.WriteXml("..//xml//chidinh.xml", XmlWriteMode.WriteSchema);
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "rptChidinh.rpt", true);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void frmChidinh_n_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F6:
					butLietke_Click(sender,e);
					break;
			}
		}

		private void madoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==madoituong && ma.Text!="")
			{
				DataRow r=m.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r!=null)
				{
					mavp.Text=r["id"].ToString();
					s_dvt=r["dvt"].ToString();
					ten.Text=r["ten"].ToString();
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
				}				
			}
		}

        private void chkmadt_def_CheckedChanged(object sender, EventArgs e)
        {
            bMadoituong = !chkmadt_def.Checked;
            madoituong.Enabled = bMadoituong;
        }

        private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void tenbs_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == tenbs)
            {
                Filt_tenbs(tenbs.Text);
                listBS.BrowseToDanhmuc(tenbs, mabs, chandoan);
            }
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
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
                    l_idkhoa = decimal.Parse(cmbMabn.SelectedValue.ToString());
                }
                catch { l_idkhoa = 0; }
                load_head();
            }
        }

        private void ghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void load_congno()
        {
            if (i_vienphi != 4)
            {
                decimal congno = d.congno(i_vienphi, mabn.Text, l_maql, l_idkhoa);
                if (congno == 0) this.Text = s_title;
                else
                {
                    if (congno > 0) this.Text = s_title + ",Thiếu :" + congno.ToString("###,###,###,##0.00");
                    else
                    {
                        congno = Math.Abs(congno);
                        this.Text = s_title + ",Thừa :" + congno.ToString("###,###,###,##0.00");
                    }
                }
            }
        }

        //
        private bool thongbao(bool skip,decimal chiphi_hientai,decimal tienchenhlech)
        {
            decimal tamung = 0;
            string s = m.get_chiphi_mabn1(mabn.Text, (i_loaiba == 2) ? l_mavaovien : l_maql, i_loaiba, false, chiphi_hientai, int.Parse(madoituong.SelectedValue.ToString()));
            string[] a_chiphi = s.Split('~');
            if (decimal.Parse(a_chiphi[0]) == 0)
            {
                tamung = m.get_tamung(mabn.Text, l_maql, s_ngayvao, s_ngay, s_makp, int.Parse(madoituong.SelectedValue.ToString()));
            }
            else
            {
                tamung = decimal.Parse(a_chiphi[1]);
            }
            decimal chiphi = decimal.Parse(a_chiphi[0]) + tienchenhlech;// (s.Substring(0, s.IndexOf("~")));
            decimal bhyttra = decimal.Parse(a_chiphi[2]);//s.Substring(s.IndexOf("~") + 1));
            decimal bntra = decimal.Parse(a_chiphi[3]) +tienchenhlech;
            decimal conlai = tamung - bntra;//chi phi -tamung - bhyttra;
            if (conlai < 0 && !skip)
            {
                s = "Tổng chi phí :" + chiphi.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                s += "Tạm ứng      :" + tamung.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                s += "BHYT Trả      :" + bhyttra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                s += "BN phải Trả      :" + bntra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                conlai = conlai * -1;
                s += "Còn thiếu    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
                s += "Yêu cầu người bệnh đóng tạm ứng !";
                MessageBox.Show(s, LibMedi.AccessData.Msg);
                bvuottamung = true;
                return false;
            }
            else if (chiphi == 0 && tamung == 0 && ((madoituong.SelectedValue.ToString() == "1" && chiphi_hientai > d.ma16_st(m.nhom_duoc)) || (madoituong.SelectedValue.ToString() != "1" && chiphi_hientai > 0)))
            {
                s = "Bệnh nhân chưa có tạm ứng, Yêu cầu người bệnh đóng thêm tạm ứng !";
                MessageBox.Show(s, LibMedi.AccessData.Msg);
                bvuottamung = true;
                return false;
            }
            else
            {
                bvuottamung = false;
                return true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void mnu_thongbaochiphi_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "thongbaochiphi_cd", mnu_thongbaochiphi.Checked ? "1" : "0");
        }

        private void tmn_xemlaichidinh_Click(object sender, EventArgs e)
        {
            iChidinh = 0;
            load_treeView();
        }

        private void enable_giam(bool ena)
        {
            tylegiam.Enabled = ena;
            stgiam.Enabled = ena;
            lydogiam.Enabled = ena;
        }

        private void visibled_giam(bool ena)
        {
            tylegiam.Visible = ena;
            stgiam.Visible = ena;
            lydogiam.Visible = ena;
            label10.Visible = ena;
            label11.Visible = ena;
            label15.Visible = ena;
            label16.Visible = ena;
        }
        private bool get_nhomvp_pttt(int i_mavp)
        {
            bool bln = false;
            string sexp = "id=" + i_mavp;
            if (i_nhomvp_pttt.Trim().Trim(',') != "") sexp += " and id_nhom in(" + i_nhomvp_pttt.Trim().Trim(',') + ")";
            DataRow dr = m.getrowbyid(dt, sexp);// "id=" + i_mavp + " and id_nhom=" + i_nhomvp_pttt);
            bln = dr != null;
            return bln;
        }

        private void f_capnhat_db()
        {
            string xxx = m.user + m.mmyy(s_ngay);
            string asql = "select tylegiam from " + xxx + ".v_chidinh where 1=2";
            DataSet lds = m.get_data(asql);
            bool bln = (lds==null || lds.Tables.Count==0);
            if (bln)
            {
                asql = "alter table " + xxx + ".v_chidinh add tylegiam numeric(5,2) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_chidinh add stgiam numeric(18) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_chidinh add lydogiam text";
                m.execute_data(asql, false);
            }
            asql = "select id from " + xxx + ".v_chidinh_huy where 1=2";
            lds = m.get_data(asql);
            bln = false;
            bln = (lds==null || lds.Tables.Count==0);
            if (bln)
            {
                asql = "create table " + xxx + ".v_chidinh_huy as select * from " + xxx + ".v_chidinh where 1=2";
                m.execute_data(asql, false);
            }
            asql = "select dachenhlech from " + xxx + ".v_chidinh where 1=2";
            lds = m.get_data(asql);
            if (lds != null && lds.Tables.Count <= 0)
            {
                asql = " alter table " + xxx + ".v_chidinh add dachenhlech number(1) default 0";
                m.execute_data(asql);
                asql = " alter table " + xxx + ".v_vpkhoa add dachenhlech number(1) default 0";
                m.execute_data(asql);
            }
        }
        private void get_st_giam(int i_mavp, int i_madoituong, decimal d_tylegiam)
        {
            if (d_tylegiam == 0) { stgiam.Text = "0"; return; }
            else
            {
                string gia = m.field_gia(i_madoituong.ToString());
                DataRow dr = m.getrowbyid(dt, "id=" + i_mavp);
                if (dr != null)
                {
                    decimal dgia = (dr[gia].ToString().Trim() == "") ? 0 : decimal.Parse(dr[gia].ToString());
                    stgiam.Text = Math.Round((dgia * d_tylegiam / 100), 0).ToString();
                }
            }
        }
        private void get_tylegiam_giam(int i_mavp, int i_madoituong, decimal d_stgiam)
        {
            if (d_stgiam == 0) { tylegiam.Text = "0"; return; }
            else
            {
                string gia = m.field_gia(i_madoituong.ToString());
                DataRow dr = m.getrowbyid(dt, "id=" + i_mavp);
                if (dr != null)
                {
                    decimal dgia = (dr[gia].ToString().Trim() == "") ? 0 : decimal.Parse(dr[gia].ToString());
                    tylegiam.Text = Math.Round(((d_stgiam / dgia) * 100), 0).ToString();
                }
            }
        }

        private void tylegiam_Validated(object sender, EventArgs e)
        {
            if (tylegiam.Text.Trim() == "" || tylegiam.Text.Trim() == "0") { stgiam.Text = "0"; return; }
            get_st_giam(int.Parse(mavp.Text), int.Parse(madoituong.SelectedValue.ToString()), decimal.Parse(tylegiam.Text));
        }

        private void stgiam_Validated(object sender, EventArgs e)
        {
            if (stgiam.Text.Trim() == "" || stgiam.Text.Trim() == "0") { tylegiam.Text = "0"; return; }
            get_tylegiam_giam(int.Parse(mavp.Text), int.Parse(madoituong.SelectedValue.ToString()), decimal.Parse(stgiam.Text));
        }

        private void tmn_hienthichenhlech_Click(object sender, EventArgs e)
        {
            load_grid(l_maql, l_idkhoa);
            m.writeXml("thongso", "chidinh_chenhlech", tmn_hienthichenhlech.Checked ? "1" : "0");
        }

        private void butCholai_Click(object sender, EventArgs e)//gam 16/12/2011
        {
            try
            {
                if (ds.Tables[0].Select("chon=true").Length > 0)
                {
                    frmSongaycholai f = new frmSongaycholai();
                    DateTime dt = m.StringToDate(s_ngay);
                    string ngay = s_ngay;
                    f.ShowDialog();
                    if (f.Result != DialogResult.OK)
                    {
                        return;
                    }
                    int isongay = f.ingay;
                    foreach (DataRow r in ds.Tables[0].Select("chon=true"))
                    {
                        for (int i = 0; i < isongay; i++)
                        {
                            s_ngay = m.DateToString("dd/MM/yyyy", dt.AddDays(i + 1));
                            upd_data_cholai(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()));
                            l_id = 0;
                        }
                        s_ngay = ngay;
                    }
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chọn dịch vụ cần cho lại. "));
                    return;
                }
                madoituong.SelectedValue = i_madoituong.ToString();
                ghichu.Text = ma.Text = ten.Text = lydogiam.Text = ""; soluong.Text = "1";
                tylegiam.Text = stgiam.Text = "0";
                //
                l_id = 0;
                if (tenbs.Enabled) tenbs.Focus();
                else if (chandoan.Enabled) chandoan.Focus();
                else if (tinhtrang.Enabled) tinhtrang.Focus();
                else if (thuchien.Enabled) thuchien.Focus();
                else if (madoituong.Enabled) madoituong.Focus();
                else ma.Focus();
                load_treeView();
 
            }
            catch { }

        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            select_list();
        }

        private void mnuSapXepTenTheoABC_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso.xml", "chidinh_sort_ten", mnuSapXepTenTheoABC.Checked ? "1" : "0");
            Cursor = Cursors.WaitCursor;
            dt = m.get_dmvp(s_ngay, s_loaivp, s_mucvp, v.iNgoaitru, b_ApDungQuanLyGiaVienPhiTheoThongTuLienTich15042012, mnuSapXepTenTheoABC.Checked).Tables[0];
            list.DataSource = dt;
            Cursor = Cursors.Default;
        }

        private void f_load_option()
        {
            bchiphi_lonhon_tamung_khongchothuchien_cls_H27 = m.bchiphi_lonhon_tamung_khongchothuchien_cls_H27;
        }
	}
}
