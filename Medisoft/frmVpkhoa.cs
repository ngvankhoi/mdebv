using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibVienphi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmChidinh.
	/// </summary>
	public class frmVpkhoa : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		//
		long o_id=0;//binh: de giu lai IDkhoa cua BN, khi kich nut bo qua thi lay lai ngay BN do
		//
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
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
		private LibDuoc.AccessData d;
        private string s_ngay, s_makp, s_tenkp, sql, s_dvt, s_loaivp, s_mucvp, s_title, user, nam, s_ngayvao, xxx, s_denngay;
        private int i_madoituong, i_tong = -1, i_done, i_paid, i_row = 0, i_userid, i_vienphi, i_buoi, v1, v2, i_nhomvp_pttt=0;
		private long l_maql=0,l_idkhoa=0,l_id,l_mavaovien;
        private decimal d_soluong, d_dongia, d_vattu, d_soluongcu, Tamung_min=0, chiphi=0, tamung=0;
        private bool bNew, bNhapten, bMadoituong, bTTngay, bHansd_thuoc, bChidinh_thutienlien, bChenhlech_doituong, bNhapPTTT_chidinh_vpkhoa_miengiam;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtngay=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtll=new DataTable();
        private DataTable dtdt = new DataTable();
		private LibList.List listHoten;
		private System.Windows.Forms.ComboBox cmbMabn;
		private DataRow r;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.CheckBox chkTree;
		private MaskedTextBox.MaskedTextBox dongia;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Label label8;
        private TextBox tim;
        private CheckBox chkmadt_def;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private string sothe_jl;
        private int vitri_jl,i_tunguyen;
        private bool bLocdichvu;
        private MaskedTextBox.MaskedTextBox stgiam;
        private MaskedTextBox.MaskedTextBox tylegiam;
        private TextBox lydogiam;
        private Label label16;
        private Label label15;
        private Label label11;
        private Label label10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmVpkhoa(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid,int buoi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			v=new LibVienphi.AccessData();
			d=new LibDuoc.AccessData();
			s_ngay=ngay;s_makp=makp;s_tenkp=tenkp;
			i_userid=userid;i_buoi=buoi;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVpkhoa));
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
            this.listHoten = new LibList.List();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.butThem = new System.Windows.Forms.Button();
            this.chkTree = new System.Windows.Forms.CheckBox();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ma = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.chkmadt_def = new System.Windows.Forms.CheckBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.stgiam = new MaskedTextBox.MaskedTextBox();
            this.tylegiam = new MaskedTextBox.MaskedTextBox();
            this.lydogiam = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
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
            this.mabn.Location = new System.Drawing.Point(56, 8);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 8);
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
            this.hoten.Location = new System.Drawing.Point(184, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(232, 21);
            this.hoten.TabIndex = 3;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(658, 55);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(129, 240);
            this.treeView1.TabIndex = 19;
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(648, 376);
            this.dataGrid1.TabIndex = 70;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(557, 488);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 20;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(64, 395);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(91, 21);
            this.madoituong.TabIndex = 4;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(151, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dịch vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(268, 395);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(296, 21);
            this.ten.TabIndex = 6;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(554, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Số lượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(618, 395);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(46, 21);
            this.soluong.TabIndex = 7;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(403, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Khoa/phòng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(496, 8);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(136, 21);
            this.tenkp.TabIndex = 16;
            // 
            // mavp
            // 
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(104, 224);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(24, 21);
            this.mavp.TabIndex = 17;
            // 
            // butLietke
            // 
            this.butLietke.Enabled = false;
            this.butLietke.Image = ((System.Drawing.Image)(resources.GetObject("butLietke.Image")));
            this.butLietke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLietke.Location = new System.Drawing.Point(146, 451);
            this.butLietke.Name = "butLietke";
            this.butLietke.Size = new System.Drawing.Size(65, 25);
            this.butLietke.TabIndex = 14;
            this.butLietke.Text = "     Liệt kê";
            this.butLietke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLietke.Click += new System.EventHandler(this.butLietke_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(212, 451);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 15;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(334, 451);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 16;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(395, 451);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(456, 451);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(517, 451);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 17;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(578, 451);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(489, 488);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 18;
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
            this.cmbMabn.Location = new System.Drawing.Point(56, 8);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(80, 21);
            this.cmbMabn.TabIndex = 2;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(273, 451);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 25);
            this.butThem.TabIndex = 11;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // chkTree
            // 
            this.chkTree.Location = new System.Drawing.Point(660, 32);
            this.chkTree.Name = "chkTree";
            this.chkTree.Size = new System.Drawing.Size(143, 24);
            this.chkTree.TabIndex = 22;
            this.chkTree.Text = "Liệt kê các ngày nhập";
            this.chkTree.CheckedChanged += new System.EventHandler(this.chkTree_CheckedChanged);
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(712, 395);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(74, 21);
            this.dongia.TabIndex = 23;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(649, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Đơn giá :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(210, 395);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(56, 21);
            this.ma.TabIndex = 5;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(680, 8);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(104, 21);
            this.sothe.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(632, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 72;
            this.label8.Text = "Số thẻ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(658, 370);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(129, 21);
            this.tim.TabIndex = 137;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // chkmadt_def
            // 
            this.chkmadt_def.Enabled = false;
            this.chkmadt_def.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkmadt_def.Location = new System.Drawing.Point(668, 418);
            this.chkmadt_def.Name = "chkmadt_def";
            this.chkmadt_def.Size = new System.Drawing.Size(127, 24);
            this.chkmadt_def.TabIndex = 138;
            this.chkmadt_def.Text = "Đối tượng khi vào";
            this.chkmadt_def.CheckedChanged += new System.EventHandler(this.chkmadt_def_CheckedChanged);
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(659, 296);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 256;
            this.pic.TabStop = false;
            // 
            // stgiam
            // 
            this.stgiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stgiam.Enabled = false;
            this.stgiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stgiam.Location = new System.Drawing.Point(210, 417);
            this.stgiam.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.stgiam.Name = "stgiam";
            this.stgiam.Size = new System.Drawing.Size(105, 21);
            this.stgiam.TabIndex = 9;
            this.stgiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stgiam.Validated += new System.EventHandler(this.stgiam_Validated);
            // 
            // tylegiam
            // 
            this.tylegiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tylegiam.Enabled = false;
            this.tylegiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tylegiam.Location = new System.Drawing.Point(64, 417);
            this.tylegiam.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tylegiam.Name = "tylegiam";
            this.tylegiam.Size = new System.Drawing.Size(37, 21);
            this.tylegiam.TabIndex = 8;
            this.tylegiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tylegiam.Validated += new System.EventHandler(this.tylegiam_Validated);
            // 
            // lydogiam
            // 
            this.lydogiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydogiam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lydogiam.Enabled = false;
            this.lydogiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydogiam.Location = new System.Drawing.Point(372, 417);
            this.lydogiam.Name = "lydogiam";
            this.lydogiam.Size = new System.Drawing.Size(292, 21);
            this.lydogiam.TabIndex = 10;
            this.lydogiam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydogiam_KeyDown);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(300, 417);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 23);
            this.label16.TabIndex = 285;
            this.label16.Text = "Lý do giảm";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(129, 417);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 23);
            this.label15.TabIndex = 284;
            this.label15.Text = "Số tiền giảm :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(101, 417);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 23);
            this.label11.TabIndex = 283;
            this.label11.Text = "%";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-8, 417);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 23);
            this.label10.TabIndex = 282;
            this.label10.Text = "Tỷ lệ giảm :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmVpkhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 527);
            this.Controls.Add(this.stgiam);
            this.Controls.Add(this.tylegiam);
            this.Controls.Add(this.lydogiam);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.chkmadt_def);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkTree);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butLietke);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.mavp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVpkhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viện phí tại khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVpkhoa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVpkhoa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmVpkhoa_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            pic.Visible = m.bHinh;
            bHansd_thuoc = m.bHansd_thuoc;
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            bLocdichvu = m.bLocdichvu_doituong;
            bChenhlech_doituong = m.bChenhlech_doituong;
            Tamung_min = m.Tamung_min;
            i_nhomvp_pttt = m.iNhompttt;
            sothe_jl = m.sSothe_jl.Trim(); vitri_jl = m.iSothe_jl_vitri;
            if (!pic.Visible) this.treeView1.Size = new System.Drawing.Size(129, 314);
            v1 = 4; v2 = 2; i_tunguyen = m.iTunguyen;
			string vitri=d.thetunguyen_vitri_ora(m.nhom_duoc);
			if (vitri.Length==3)
			{
				v1=int.Parse(vitri.Substring(0,1))-1;v2=int.Parse(vitri.Substring(2,1));
			}
            user = m.user; xxx = user + m.mmyy(s_ngay);
            //
            f_capnhat_db();
            bNhapPTTT_chidinh_vpkhoa_miengiam = m.bNhapPTTT_chidinh_vpkhoa_miengiam;
            visibled_giam(bNhapPTTT_chidinh_vpkhoa_miengiam);
            //
			bTTngay=(m.bChieu_sang && i_buoi==0)?d.get_ttngay(s_ngay,s_makp):false;
			tenkp.Text=s_tenkp;
			s_title=this.Text;
			i_vienphi=m.iVienphi;
			bNhapten=m.bNhapthuoc_ten;
			bMadoituong=m.bSuadt_thuoc_vp;
            chkmadt_def.Checked = !bMadoituong;
            //
          
			sql="select a.mabn,b.hoten,a.id,c.mavaovien,a.maql,c.madoituong,d.sothe as sothe,b.nam,to_char(c.ngay,'dd/mm/yyyy') as ngay,to_char(d.denngay,'dd/mm/yyyy') as denngay ";
            sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql+=" inner join " + user + ".benhandt c on a.maql=c.maql ";
            sql+=" left join " + user + ".bhyt d on a.maql=d.maql ";
            sql+=" where a.nhapkhoa=1 and a.xuatkhoa=0 ";
            if (!m.ma_phongmo(s_makp)) sql += " and a.makp='" + s_makp + "'"; 
			sql+=" and substr(a.ngay,1,10)<=to_date('"+s_ngay+"','"+m.f_ngay+"')";
            sql+= " and (d.sudung is null or d.sudung=1)";
			sql+=" order by a.id desc";
			dthoten=m.get_data(sql).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;
            dtdt = d.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where sothe>0 and ngay>0 order by madoituong").Tables[0];
            dtkp = m.get_data("select * from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0];
			if (dtkp.Rows.Count==1)
			{
				s_loaivp=dtkp.Rows[0]["loaivp"].ToString().Trim();
				s_mucvp=dtkp.Rows[0]["mucvp"].ToString().Trim();
				if (s_loaivp!="") s_loaivp=s_loaivp.Substring(0,s_loaivp.Length-1);
				if (s_mucvp!="") s_mucvp=s_mucvp.Substring(0,s_mucvp.Length-1);
			}
            sql = "select a.id,a.ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,a.vattu_nn,a.locthe,a.trongoi,a.gia_cs,a.vattu_cs, b.id_nhom, a.chenhlech from " + user + ".v_giavp a," + user + ".v_loaivp b ";
			sql+="where a.id_loai=b.id and a.hide=0";
			if (s_loaivp!="") sql+=" and a.id_loai in ("+s_loaivp+")";
			if (s_mucvp!="") sql+=" and a.id not in ("+s_mucvp+")";
			sql+=" and (a.loaibn=0 or a.loaibn="+v.iNoitru+")";
            if (bChidinh_thutienlien) sql += " and a.chenhlech=0";
			sql+=" order by b.stt,a.stt";
			dt=m.get_data(sql).Tables[0];
			list.DisplayMember="TEN";
			list.ValueMember="ID";
			list.DataSource=dt;

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
			//ref_text();
		}

		private void load_mabn()
		{
			sql="select distinct a.mabn,b.hoten,a.mavaovien,a.maql,a.idkhoa from "+xxx+".v_vpkhoa a,"+user+".btdbn b where a.mabn=b.mabn and a.makp='"+s_makp+"' and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"' and a.buoi="+i_buoi;
			dtll=m.get_data(sql).Tables[0];
			cmbMabn.DataSource=dtll;
			if (cmbMabn.Items.Count>0) l_idkhoa=long.Parse(cmbMabn.SelectedValue.ToString());
			else l_idkhoa=0;
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "tenkp";
			TextCol1.HeaderText = "Khoa/phòng";
			TextCol1.Width = 80;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "doituong";
			TextCol1.HeaderText = "Đối tượng";
			TextCol1.Width = 58;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Mã số";
			TextCol1.Width = 50;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Dịch vụ";
			TextCol1.Width = 170;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "dvt";
			TextCol1.HeaderText = "ĐVT";
			TextCol1.Width = 30;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "soluong";
			TextCol1.HeaderText = "Số lượng";
			TextCol1.Width = 50;
			TextCol1.Format="### ###.00";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "makp";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 9);
			TextCol1.MappingName = "madoituong";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 10);
			TextCol1.MappingName = "mavp";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 11);
			TextCol1.MappingName = "dongia";
			TextCol1.HeaderText = "Đơn gía";
			TextCol1.Width = 60;
			TextCol1.Format="### ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 12);
			TextCol1.MappingName = "paid";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 13);
			TextCol1.MappingName = "done";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 14);
			TextCol1.MappingName = "maql";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 15);
			TextCol1.MappingName = "idkhoa";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 16);
			TextCol1.MappingName = "vattu";
			TextCol1.HeaderText = "Vật tư";
			TextCol1.Width = 60;
			TextCol1.Format="### ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 17);
			TextCol1.MappingName = "readonly";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 18);
            TextCol1.MappingName = "tylegiam";
            TextCol1.HeaderText = "Giảm %";
            TextCol1.Width = 40;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 19);
            TextCol1.MappingName = "stgiam";
            TextCol1.HeaderText = "ST Giảm";
            TextCol1.Width = 70;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new DataGridColoredTextBoxColumn(de, 20);
            TextCol1.MappingName = "lydogiam";
            TextCol1.HeaderText = "Lý do giảm";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			if (this.dataGrid1[row,11].ToString().Trim()=="1" || this.dataGrid1[row,12].ToString().Trim()=="1" || this.dataGrid1[row,16].ToString().Trim()=="1")
			{
				c=Color.Red;
				i_tong=row;
			}
			if (row==i_tong) c=Color.Red;
			return c;
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
		private void load_grid()
		{
			sql="select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,0 as paid,a.done,a.maql,a.idkhoa,a.vattu,0 as tinhtrang,0 as thuchien,b.ma,a.readonly";
            sql += ", a.tylegiam, a.stgiam, a.lydogiam ";
			sql+=" from "+xxx+".v_vpkhoa a,"+user+".v_giavp b,"+user+".doituong c,"+user+".btdkp_bv d ";
			sql+=" where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp ";
			sql+=" and a.mabn='"+mabn.Text+"' and a.makp='"+s_makp+"'";
			sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
			if (l_idkhoa!=0) sql+=" and a.idkhoa="+l_idkhoa;
			sql+=" and a.buoi="+i_buoi;
			sql+=" order by a.ngay";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				DataRow r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					if (int.Parse(madoituong.SelectedValue.ToString())!=int.Parse(r["madoituong"].ToString()))
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Không đúng so với đối tượng ban đầu\nBạn có muốn lấy đối tượng ban đầu ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							madoituong.SelectedValue=r["madoituong"].ToString();
					}
				}
				SendKeys.Send("{Tab}");
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (soluong.Text=="") soluong.Text="1";
				d_soluong=decimal.Parse(soluong.Text);
				soluong.Text=d_soluong.ToString("###,##0.00");
			}
			catch{soluong.Text="1";}
		}

		private void ref_text()
		{
			try
			{							
				i_row=dataGrid1.CurrentCell.RowNumber;
				l_id=long.Parse(dataGrid1[i_row,0].ToString());
				DataRow r=m.getrowbyid(ds.Tables[0],"id="+l_id);
				if (r!=null)
				{
					madoituong.SelectedValue=r["madoituong"].ToString();
					mavp.Text=r["mavp"].ToString();
					ten.Text=r["ten"].ToString();
					ma.Text=r["ma"].ToString();
					s_dvt=r["dvt"].ToString();
					d_dongia=decimal.Parse(r["dongia"].ToString());
					d_vattu=decimal.Parse(r["vattu"].ToString());
					i_paid=int.Parse(r["paid"].ToString());
					i_done=int.Parse(r["done"].ToString());
					d_soluong=decimal.Parse(r["soluong"].ToString());
					soluong.Text=d_soluong.ToString("###,###.00");
					dongia.Text=d_dongia.ToString("###,###,###");
                    if (r["maql"].ToString().Trim() != "") l_maql = long.Parse(r["maql"].ToString());
                    if (r["idkhoa"].ToString().Trim() != "") l_idkhoa = long.Parse(r["idkhoa"].ToString());
					d_soluongcu=d_soluong;
                    tylegiam.Text = r["tylegiam"].ToString();
                    stgiam.Text = r["stgiam"].ToString();
                    lydogiam.Text = r["lydogiam"].ToString();
                    if (butLuu.Enabled) enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
                    else enable_giam(false);
				}
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void Filter(string ten,int loai)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				if (loai==1) sql="ma like '%"+ten.Trim()+"%'";
				else sql="ten like '%"+ten.Trim()+"%'";
				if (madoituong.SelectedValue.ToString()=="1" && bLocdichvu)
				{
                    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (sothe.Text.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%')";
                    }
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false;
			cmbMabn.Visible=!ena;
			mabn.Enabled=ena;
			if (bNhapten) hoten.Enabled=ena;
            if (bMadoituong) madoituong.Enabled = ena;
            chkmadt_def.Enabled = ena;
			ma.Enabled=ena;
			ten.Enabled=ena;
            tim.Enabled = !ena;
            enable_giam(false);
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLietke.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butThem.Enabled=ena;
			if (ena && l_id==0)
			{
				ten.Text="";ma.Text=lydogiam.Text="";
                stgiam.Text = tylegiam.Text = "0";
				s_dvt="";i_paid=0;i_done=0;
                l_maql = 0; l_idkhoa = 0; l_mavaovien = 0;
				soluong.Text="1";
				hoten.Text="";sothe.Text="";
				mabn.Text="";ds.Clear();
                CurrencyManager cm1 = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                DataView dv1 = (DataView)cm1.List;
                dv1.RowFilter = "";
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
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			o_id=(cmbMabn.SelectedIndex<0)?0:long.Parse(cmbMabn.SelectedValue.ToString());
			l_id=0;
			bNew=true;
			ena_object(true);
            try
            {
                mabn.Focus();
            }
            catch { }
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			try
			{
				if (m.bRavien(l_maql))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"),LibMedi.AccessData.Msg);
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
					return;
				}
                i_madoituong = d.get_madoituong(l_maql);
                /*
				i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,11].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1" || dataGrid1[i_row,17].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !"),LibMedi.AccessData.Msg);
					return;
				}
                 * */
                i_row = dataGrid1.CurrentCell.RowNumber;
                if (dataGrid1[i_row, 11].ToString() == "1" || dataGrid1[i_row, 13].ToString() == "1")
                {
                    if (ds.Tables[0].Rows.Count == 1 && dataGrid1[i_row, 17].ToString() == "1") d_soluongcu = 0;
                    else
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }
				l_id=long.Parse(dataGrid1[i_row,0].ToString());
			}
			catch{l_id=0;}
			
			bNew=false;
			ena_object(true);d_soluongcu=0;
            mabn.Enabled = hoten.Enabled = bNew;
			o_id=(cmbMabn.SelectedIndex<0)?0:long.Parse(cmbMabn.SelectedValue.ToString());
            butThem_Click(sender, e);
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				if (!madoituong.Enabled) madoituong.Enabled=true;
				madoituong.Focus();
				return false;
			}
			if (soluong.Text=="")
			{
				soluong.Focus();
				return false;
			}
			if (bNew)
			{
                r = d.getrowbyid(dtll, "idkhoa=" + l_idkhoa);
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
			l_maql=long.Parse(r["maql"].ToString());
			l_idkhoa=long.Parse(r["id"].ToString());
            l_mavaovien = long.Parse(r["mavaovien"].ToString());
            s_denngay = r["denngay"].ToString();
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
            if (bHansd_thuoc && s_denngay != "")
            {
                r = d.getrowbyid(dtdt, "madoituong=" + int.Parse(madoituong.SelectedValue.ToString()));
                if (r != null)
                {
                    if (m.songay(m.StringToDate(s_denngay), m.StringToDate(s_ngay), 0) < 0)
                    {
                        MessageBox.Show("Đối tượng " + madoituong.Text + " hết hạn sử dụng {" + s_denngay + "}", d.Msg);
                        if (madoituong.Enabled) madoituong.Focus();
                        else ma.Focus();
                        return false;
                    }
                }
            }
			if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (ten.Text!="" && mavp.Text!="")
			{
                bool bFound = false;
                DataRow[] dr = dt.Select("trongoi=1 and id=" + int.Parse(mavp.Text));
                if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                {
                    sql = "id=" + long.Parse(mavp.Text) + " and bhyt<>0";
                    if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%')";
                    if (m.getrowbyid(dt, sql) == null)
                    {
                        madoituong.SelectedValue = i_tunguyen.ToString();
                        madoituong.Update();
                    }
                }
                if (dr.Length > 0)
                {
                    bFound = false;
                    sql = "select a.* from "+user+".v_trongoi a,"+user+".v_giavp b ";
                    sql+=" where a.id_gia=b.id and a.id=" + int.Parse(mavp.Text);
                    if (madoituong.SelectedValue.ToString() == "1") sql += " and b.bhyt>0";
                    sql += " order by a.stt";
                    foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                    {
                        l_id = 0;
                        upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        bFound = true;
                    }
                    if (!bFound) upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                }
                else upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
			}
			m.updrec_vpkhoa(dtll,mabn.Text,hoten.Text,l_mavaovien,l_maql,l_idkhoa);
			cmbMabn.Refresh();
			cmbMabn.SelectedValue=l_idkhoa.ToString();
			ena_object(false);
            if (Tamung_min != 0) thongbao(false);
		}

        private void upd_data(int i_mavp, decimal sl)
        {
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                string gia = m.field_gia(madoituong.SelectedValue.ToString());
                string giavt = "vattu_" + gia.Substring(4).Trim();
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                int itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                if (l_id == 0)
                {
                    l_id = v.get_id_vpkhoa;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + sl.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + i_buoi.ToString());
                    foreach (DataRow r1 in v.get_data("select * from " + xxx + ".v_vpkhoa where id=" + l_id).Tables[0].Rows)
                        d.upd_theodoicongno(d.delete, r1["mabn"].ToString(), long.Parse(r1["mavaovien"].ToString()), long.Parse(r1["maql"].ToString()), long.Parse(r1["idkhoa"].ToString()), int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["soluong"].ToString()) * (decimal.Parse(r1["dongia"].ToString()) + decimal.Parse(r1["vattu"].ToString())), "vienphi");
                }

                v.upd_vpkhoa(l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp,sl, d_dongia, d_vattu, i_userid, i_buoi);
                m.execute_data("update " + xxx + ".v_vpkhoa set tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)) + ", stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)) + ", lydogiam='" + lydogiam.Text + "' where id=" + l_id);
                d.upd_theodoicongno(d.insert, mabn.Text, l_mavaovien, l_maql, l_idkhoa, int.Parse(madoituong.SelectedValue.ToString()), sl * (d_dongia + d_vattu), "vienphi");
                m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), sl, d_dongia, d_vattu, i_paid, i_done, 0, 0, "", (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text)), (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text)), lydogiam.Text);                
                //
                l_id = 0;
            }
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			load_mabn();
			if(o_id>0)
			{
				cmbMabn.SelectedValue=o_id;	
				l_idkhoa =o_id;
			}
			load_head();
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
			try
			{
				if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
					return;
				}
				if (m.bRavien(l_maql))
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra viện !"),LibMedi.AccessData.Msg);
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
					return;
				}
				i_row=dataGrid1.CurrentCell.RowNumber;
				if (dataGrid1[i_row,11].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1" || dataGrid1[i_row,17].ToString()=="1")
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"),LibMedi.AccessData.Msg);
					return;
				}
                DataRow r1 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r1 == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã ra khỏi khoa !"), LibMedi.AccessData.Msg);
                    return;
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    int itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".v_vpkhoa", "id=" + l_id));
					d.upd_theodoicongno(d.delete,mabn.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(madoituong.SelectedValue.ToString()),decimal.Parse(soluong.Text)*(d_dongia+d_vattu),"vienphi");
					m.execute_data("delete from "+xxx+".v_vpkhoa where id="+l_id);
                    m.execute_data("delete from " + xxx + ".v_vpkhoa where id=-" + l_id);
					m.delrec(ds.Tables[0],"id="+l_id);
                    m.delrec(ds.Tables[0], "id=-" + l_id);
					ds.AcceptChanges();
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
			if (!kiemtra()) return;		
			if (d.get_paid(mabn.Text,l_mavaovien,l_maql,l_idkhoa,s_ngay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
                try
                {
                    mabn.Focus();
                }
                catch { }
				return;
			}			
			if (bTTngay)
			{
				MessageBox.Show("Ngày "+s_ngay+" viện phí đã in danh sách thu tiền\nYêu cầu chọn phiếu buổi chiều !",LibMedi.AccessData.Msg);
				return;
			}
			if(madoituong.SelectedIndex<0)madoituong.SelectedIndex=0;
			i_madoituong=int.Parse(madoituong.SelectedValue.ToString());//d.get_madoituong(l_maql);
            int itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
			frmChonchidinh f=new frmChonchidinh(m,mabn.Text,i_madoituong,s_loaivp,s_mucvp,v.iNoitru,sothe.Text,v1,v2,true);
			f.ShowDialog(this);
			if (f.dt.Rows.Count>0)
			{
                bool bFound = false;
                madoituong.SelectedValue = i_madoituong.ToString(); l_id = 0;
                if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                {
                    sql = "id=" + long.Parse(r["mavp"].ToString()) + " and bhyt<>0";
                    if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%')";
                    if (m.getrowbyid(dt, sql) == null)
                    {
                        madoituong.SelectedValue = i_tunguyen.ToString();
                        madoituong.Update();
                    }
                }
				foreach(DataRow r in f.dt.Rows)
				{
                    if (l_id == 0) l_id = v.get_id_vpkhoa;
                    DataRow[] dr = dt.Select("trongoi=1 and id=" + int.Parse(r["mavp"].ToString()));
                    if (dr.Length > 0)
                    {
                        bFound = false;
                        sql = "select a.* from v_trongoi a,v_giavp b ";
                        sql+=" where a.id_gia=b.id and a.id=" + int.Parse(r["mavp"].ToString());
                        if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu) sql += " and b.bhyt>0";
                        sql += " order by a.stt";
                        foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                        {
                            l_id = 0;
                            upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                            bFound = true;
                        }
                        if (!bFound) upd_data(int.Parse(r["mavp"].ToString()), 1);
                    }
                    else upd_data(int.Parse(r["mavp"].ToString()), 1);
				}
				m.updrec_vpkhoa(dtll,mabn.Text,hoten.Text,l_mavaovien,l_maql,l_idkhoa);
			}
			cmbMabn.Refresh();
			cmbMabn.SelectedValue=l_idkhoa.ToString();
			load_head();
			ref_text();
			ena_object(false);
            if (Tamung_min != 0) thongbao(false);
		}

		private void load_treeView()
		{
			treeView1.Nodes.Clear();
            if (nam == "" || s_ngayvao == "") return;
			TreeNode node;
			int iChidinh=m.iChidinh;
			sql="select distinct b.ngay,a.maql,a.id as idkhoa from "+user+".nhapkhoa a,"+xxx+".v_vpkhoa b where a.id=b.idkhoa";
			sql+=" and b.makp='"+s_makp+"'";
			sql+=" and a.mabn='"+mabn.Text+"'";
			if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
			else if (iChidinh==3) sql+=" and a.id='"+l_idkhoa+"'";
			sql+=" order by b.ngay desc";
            dtngay = (iChidinh > 1) ? m.get_data_mmyy(sql,s_ngayvao,s_ngay,false).Tables[0] : m.get_data_nam(nam, sql).Tables[0];
			foreach(DataRow r in dtngay.Rows)
			{
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_vpkhoa a," + user + ".v_giavp b where a.mavp=b.id";
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay"].ToString())) + "'";
                sql += " and a.makp='" + s_makp + "'";
                sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    node.Nodes.Add(r1["ten"].ToString());
                r["ngay"] = m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				try
				{
					DataRow r=m.getrowbyid(dt,"id="+int.Parse(mavp.Text));
					if (r!=null)
					{
                        if(bNhapPTTT_chidinh_vpkhoa_miengiam)enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
						s_dvt=r["dvt"].ToString();
						ten.Text=r["ten"].ToString();
						ma.Text=r["ma"].ToString();
                        if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                        {
                            sql = "id=" + long.Parse(mavp.Text) + " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%')";
                            if (m.getrowbyid(dt, sql) == null)
                            {
                                madoituong.SelectedValue = i_tunguyen.ToString();
                                madoituong.Update();
                            }
                        }
                        string gia = m.field_gia(madoituong.SelectedValue.ToString());
                        string giavt = "vattu_" + gia.Substring(4).Trim();
                        decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                        d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
						dongia.Text=d_dongia.ToString("###,###,###");
					}
				}
				catch{s_dvt="";d_dongia=0;d_vattu=0;}
			}
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
            nam = ""; s_ngayvao = "";
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
                nam = r["nam"].ToString();
                s_ngayvao = r["ngay"].ToString();
				hoten.Text=r["hoten"].ToString();
                l_mavaovien=long.Parse(r["mavaovien"].ToString());
				l_maql=long.Parse(r["maql"].ToString());
				l_idkhoa=long.Parse(r["id"].ToString());
				i_madoituong=d.get_madoituong(l_maql);
				madoituong.SelectedValue=i_madoituong.ToString();                
				sothe.Text=r["sothe"].ToString();
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
			else{hoten.Text="";l_maql=0;l_idkhoa=0;ma.Text="";sothe.Text="";}
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"mabn='"+mabn.Text+"'");
				if (r!=null)
				{
					DialogResult dlg=MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập, Bạn có muốn sửa không?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question);//,MessageBoxDefaultButton.Button2);
					if(dlg==DialogResult.No)
					{
						//mabn.Focus();
						return;
					}
					else
					{
                        l_mavaovien = long.Parse(r["mavaovien"].ToString());
						l_idkhoa=long.Parse(r["idkhoa"].ToString());
						cmbMabn.SelectedValue=l_idkhoa.ToString();
						load_head();
						butSua_Click(null,null);
						ten.Text="";soluong.Text="1";ma.Text="";
						ten.Enabled=true;
						ma.Enabled=true;
						l_id=0;
					}
				}
			}
			catch{}
			load_congno();
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
				listHoten.BrowseToDanhmuc(hoten,mabn,madoituong);
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

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn)
			{
				try
				{
					l_idkhoa=long.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_idkhoa=0;}
				load_head();
			}
		}

		private void load_head()
		{
            if (l_idkhoa != 0)
                r = m.getrowbyid(dtll, "idkhoa=" + l_idkhoa);
            else
                r = m.getrowbyid(dtll, "mabn='" + cmbMabn.Text + "'");

			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
				l_maql=long.Parse(r["maql"].ToString());
                l_mavaovien = long.Parse(r["mavaovien"].ToString());
                DataRow r1 = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r1 != null)
                {
                    nam = r1["nam"].ToString();
                    s_ngayvao = r1["ngay"].ToString();
                    sothe.Text = r1["sothe"].ToString();
                }
				if (chkTree.Checked) load_treeView();
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
			load_grid();
			ref_text();
			load_congno();
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (ten.Text!="" && mavp.Text!="")
			{
                if (l_id == 0) l_id = v.get_id_vpkhoa;
                DataRow[] dr = dt.Select("trongoi=1 and id=" + int.Parse(mavp.Text));
                bool bFound = false;
                if (dr.Length > 0)
                {
                    sql = "select a.* from v_trongoi a,v_giavp b ";
                    sql+=" where a.id_gia=b.id and a.id=" + int.Parse(mavp.Text);
                    if (madoituong.SelectedValue.ToString() == "1") sql += " and b.bhyt>0";
                    sql += " order by a.stt";
                    foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                    {
                        if (l_id == 0) l_id = v.get_id_vpkhoa;
                        upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        bFound = true;
                    }
                    if (!bFound) upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                }
                else upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text));
                ma.Enabled = true; ten.Enabled = true; ten.Text = ""; soluong.Text = "1"; ma.Text = ""; lydogiam.Text = "";                
                stgiam.Text = tylegiam.Text = "0";
			}
			l_id=0;
            if (madoituong.Enabled) madoituong.Focus();
            else if (ma.Enabled) ma.Focus();
            else ten.Focus();
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void load_congno()
		{
			if (i_vienphi!=4)
			{
				decimal congno=d.congno(i_vienphi,mabn.Text,l_maql,l_idkhoa);
				if (congno==0) this.Text=s_title;
				else
				{
					if (congno>0) this.Text=s_title+",Thiếu :"+congno.ToString("###,###,###,##0.00");
					else
					{
						congno=Math.Abs(congno);
						this.Text=s_title+",Thừa :"+congno.ToString("###,###,###,##0.00");
					}
				}	
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
				Filter(ten.Text,2);
				list.BrowseToDanhmuc(ten,mavp,soluong,0);
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
            if (ma.Text != "")
            {
                sql = "ma='" + ma.Text + "'";
                if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu)
                {
                    sql += " and bhyt<>0";
                    if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%')";
                }
                DataRow r = m.getrowbyid(dt, sql);
                if (r != null)
                {
                    if(bNhapPTTT_chidinh_vpkhoa_miengiam)enable_giam(get_nhomvp_pttt(int.Parse(mavp.Text)));
                    s_dvt = r["dvt"].ToString();
                    ten.Text = r["ten"].ToString();
                    mavp.Text = r["id"].ToString();
                    if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + long.Parse(mavp.Text) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                    dongia.Text = d_dongia.ToString("###,###,###");
                }
            }
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmVpkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F6) butLietke_Click(sender,e);
		}

		private void madoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==madoituong && ma.Text!="")
			{
				DataRow r=m.getrowbyid(dt,"ma='"+ma.Text+"'");
				if (r!=null)
				{
					s_dvt=r["dvt"].ToString();
					ten.Text=r["ten"].ToString();
					ma.Text=r["ma"].ToString();
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
					dongia.Text=d_dongia.ToString("###,###,###");	
				}
			}
		}

        private void chkTree_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkTree)
            {
                if (chkTree.Checked && mabn.Text != "") load_treeView();
                else treeView1.Nodes.Clear();
            }
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
                    l_idkhoa = long.Parse(cmbMabn.SelectedValue.ToString());
                }
                catch { l_idkhoa = 0; }
                load_head();
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void chkmadt_def_CheckedChanged(object sender, EventArgs e)
        {
            bMadoituong = !chkmadt_def.Checked;
            madoituong.Enabled = bMadoituong;
        }

        private void thongbao(bool skip)
        {
            if (Tamung_min != 0)
            {
                string s = m.get_chiphi_mabn(mabn.Text,l_maql, 1, false);
                chiphi = decimal.Parse(s.Substring(0, s.IndexOf("~")));
                tamung = decimal.Parse(s.Substring(s.IndexOf("~") + 1));
                decimal conlai = chiphi - tamung;
                if (conlai < Tamung_min && !skip)
                {
                    s = "Tổng chi phí :" + chiphi.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "Tạm ứng      :" + tamung.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
                    s += "Còn thiếu    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
                    s += "Yêu cầu người bệnh đóng tạm ứng !";
                    MessageBox.Show(s, LibMedi.AccessData.Msg);
                }
            }
        }

        private bool get_nhomvp_pttt(int i_mavp)
        {
            bool bln = false;
            DataRow dr = m.getrowbyid(dt, "id=" + i_mavp + " and id_nhom=" + i_nhomvp_pttt);
            bln = dr != null;
            return bln;
        }

        private void f_capnhat_db()
        {            
            string asql = "alter table " + xxx + ".v_vpkhoa add tylegiam numeric(5,2) default 0";
            m.execute_data(asql, false);
            asql = "alter table " + xxx + ".v_vpkhoa add stgiam numeric(18) default 0";
            m.execute_data(asql, false);
            asql = "alter table " + xxx + ".v_vpkhoa add lydogiam text";
            m.execute_data(asql, false);
        }

        private void lydogiam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
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

        private void enable_giam(bool ena)
        {
            tylegiam.Enabled = ena;
            stgiam.Enabled = ena;
            lydogiam.Enabled = ena;
        }

        private void visibled_giam(bool ena)
        {
            tylegiam.Visible  = ena;
            stgiam.Visible = ena;
            lydogiam.Visible = ena;
            label10.Visible = ena;
            label1.Visible = ena;
            label15.Visible = ena;
            label16.Visible = ena;
        }
    }
}
