using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;

namespace DllPhonggiuong
{
	public class frmChuyenphong : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butMoi;
		private LibMedi.AccessData m;
		private DataSet dsin=new DataSet();
		private Process pc=new Process();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string s_ngay,s_makp,sql,user,xxx,s_mabn;
		private int i_madoituong,i_userid,itable, iChange=0;
        private long l_maql, l_idkhoa, l_id, l_mavaovien=0;
		private bool bNgayra_ngayvao,bSkip=true;
		public int i_idgiuong=0;
		private int i_giuong_old=0;
		private DataRow r;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dthoten=new DataTable();
		private DataTable dtdt=new DataTable();
		private LibList.List listHoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox giuongold;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox giuongnew;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox dongia;
		private System.Windows.Forms.TextBox tu;
		private MaskedBox.MaskedBox den;
		private System.Windows.Forms.Panel pButton;
		private System.Windows.Forms.Panel pThongtin;
		private PinkieControls.ButtonXP butLuu;
		private PinkieControls.ButtonXP butKetthuc;
		private PinkieControls.ButtonXP butHuy;
		private PinkieControls.ButtonXP butPhong;
		private System.Windows.Forms.Panel pTitle;
		private System.Windows.Forms.Panel p;
		private System.Windows.Forms.Panel pGrid;
		private System.Windows.Forms.Label lbThongtinhanhchanh;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Panel pTim;
		private System.Windows.Forms.ComboBox cboKhoa;
		private System.Windows.Forms.Label label14;
		private PinkieControls.ButtonXP butBoqua;
		private PinkieControls.ButtonXP butSua;
		private PinkieControls.ButtonXP butDoi;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private PinkieControls.ButtonXP butIn;
		private PinkieControls.ButtonXP butTra;
		private System.Windows.Forms.Panel pBut;
		private System.ComponentModel.Container components = null;

		public frmChuyenphong(LibMedi.AccessData acc,string ngay,string makp,string tenkp,int userid,string _mabn,long _idkhoa)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_ngay=ngay;s_makp=makp;i_userid=userid;s_mabn=_mabn;l_idkhoa=_idkhoa;
//			this.Text="Chuyển phòng giường khoa "+tenkp.Trim();
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChuyenphong));
			this.label1 = new System.Windows.Forms.Label();
			this.mabn = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.hoten = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label4 = new System.Windows.Forms.Label();
			this.madoituong = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.butMoi = new System.Windows.Forms.Button();
			this.listHoten = new LibList.List();
			this.label3 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.namsinh = new System.Windows.Forms.TextBox();
			this.giuongold = new System.Windows.Forms.TextBox();
			this.den = new MaskedBox.MaskedBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.giuongnew = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.dongia = new System.Windows.Forms.TextBox();
			this.pButton = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.butTra = new PinkieControls.ButtonXP();
			this.butIn = new PinkieControls.ButtonXP();
			this.butLuu = new PinkieControls.ButtonXP();
			this.butHuy = new PinkieControls.ButtonXP();
			this.butSua = new PinkieControls.ButtonXP();
			this.butKetthuc = new PinkieControls.ButtonXP();
			this.butBoqua = new PinkieControls.ButtonXP();
			this.butDoi = new PinkieControls.ButtonXP();
			this.pThongtin = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.butPhong = new PinkieControls.ButtonXP();
			this.pTitle = new System.Windows.Forms.Panel();
			this.lbThongtinhanhchanh = new System.Windows.Forms.Label();
			this.p = new System.Windows.Forms.Panel();
			this.pGrid = new System.Windows.Forms.Panel();
			this.pTim = new System.Windows.Forms.Panel();
			this.cboKhoa = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tim = new System.Windows.Forms.TextBox();
			this.pBut = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.pButton.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pThongtin.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.pTitle.SuspendLayout();
			this.p.SuspendLayout();
			this.pGrid.SuspendLayout();
			this.pTim.SuspendLayout();
			this.pBut.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 10);
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
			this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn.Location = new System.Drawing.Point(64, 10);
			this.mabn.Name = "mabn";
			this.mabn.Size = new System.Drawing.Size(64, 21);
			this.mabn.TabIndex = 0;
			this.mabn.Text = "";
			this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
			this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(125, 10);
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
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(173, 10);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(173, 21);
			this.hoten.TabIndex = 1;
			this.hoten.Text = "";
			this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
			this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.SkyBlue;
			this.dataGrid1.BackgroundColor = System.Drawing.Color.LightBlue;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(800, 384);
			this.dataGrid1.TabIndex = 19;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 19);
			this.label4.TabIndex = 27;
			this.label4.Text = "Đối tượng :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// madoituong
			// 
			this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.madoituong.Enabled = false;
			this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madoituong.Location = new System.Drawing.Point(64, 34);
			this.madoituong.Name = "madoituong";
			this.madoituong.Size = new System.Drawing.Size(144, 21);
			this.madoituong.TabIndex = 5;
			this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(609, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 28;
			this.label5.Text = "Giường :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(32, 472);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(58, 28);
			this.butMoi.TabIndex = 12;
			this.butMoi.Text = "&Mới";
			this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butMoi.Visible = false;
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// listHoten
			// 
			this.listHoten.BackColor = System.Drawing.SystemColors.Info;
			this.listHoten.ColumnCount = 0;
			this.listHoten.Location = new System.Drawing.Point(600, 416);
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
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(433, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 74;
			this.label3.Text = "Ngày giờ vào :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tu
			// 
			this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tu.Enabled = false;
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Location = new System.Drawing.Point(512, 10);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(96, 21);
			this.tu.TabIndex = 3;
			this.tu.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(337, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 75;
			this.label6.Text = "Năm sinh :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(400, 10);
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(39, 21);
			this.namsinh.TabIndex = 2;
			this.namsinh.Text = "";
			// 
			// giuongold
			// 
			this.giuongold.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.giuongold.BackColor = System.Drawing.SystemColors.HighlightText;
			this.giuongold.Enabled = false;
			this.giuongold.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.giuongold.Location = new System.Drawing.Point(657, 10);
			this.giuongold.Name = "giuongold";
			this.giuongold.Size = new System.Drawing.Size(137, 21);
			this.giuongold.TabIndex = 4;
			this.giuongold.Text = "";
			// 
			// den
			// 
			this.den.BackColor = System.Drawing.SystemColors.HighlightText;
			this.den.Enabled = false;
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Location = new System.Drawing.Point(308, 34);
			this.den.Mask = "##/##/#### ##:##";
			this.den.Name = "den";
			this.den.TabIndex = 6;
			this.den.Text = "";
			this.den.Validated += new System.EventHandler(this.den_Validated);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(212, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 19);
			this.label7.TabIndex = 79;
			this.label7.Text = "Ngày giờ chuyển :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(400, 37);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 17);
			this.label8.TabIndex = 80;
			this.label8.Text = "Sang giường :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// giuongnew
			// 
			this.giuongnew.BackColor = System.Drawing.SystemColors.HighlightText;
			this.giuongnew.Enabled = false;
			this.giuongnew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.giuongnew.Location = new System.Drawing.Point(480, 34);
			this.giuongnew.Name = "giuongnew";
			this.giuongnew.Size = new System.Drawing.Size(128, 21);
			this.giuongnew.TabIndex = 7;
			this.giuongnew.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(638, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 19);
			this.label9.TabIndex = 82;
			this.label9.Text = "Đơn giá :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dongia
			// 
			this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dongia.Enabled = false;
			this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dongia.Location = new System.Drawing.Point(694, 34);
			this.dongia.Name = "dongia";
			this.dongia.TabIndex = 9;
			this.dongia.Text = "";
			this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// pButton
			// 
			this.pButton.BackColor = System.Drawing.Color.SkyBlue;
			this.pButton.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.groupBox1,
																				  this.butDoi});
			this.pButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pButton.Location = new System.Drawing.Point(0, 496);
			this.pButton.Name = "pButton";
			this.pButton.Size = new System.Drawing.Size(800, 96);
			this.pButton.TabIndex = 85;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.pBut});
			this.groupBox1.Location = new System.Drawing.Point(1, -5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(798, 50);
			this.groupBox1.TabIndex = 92;
			this.groupBox1.TabStop = false;
			// 
			// butTra
			// 
			this.butTra.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butTra.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butTra.DefaultScheme = true;
			this.butTra.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butTra.Hint = "";
			this.butTra.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTra.Image")));
			this.butTra.Location = new System.Drawing.Point(72, 3);
			this.butTra.Name = "butTra";
			this.butTra.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butTra.Size = new System.Drawing.Size(104, 33);
			this.butTra.TabIndex = 93;
			this.butTra.Text = "&Trả giường";
			this.butTra.Click += new System.EventHandler(this.butTra_Click);
			// 
			// butIn
			// 
			this.butIn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butIn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butIn.DefaultScheme = true;
			this.butIn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butIn.Hint = "";
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.Location = new System.Drawing.Point(539, 3);
			this.butIn.Name = "butIn";
			this.butIn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butIn.Size = new System.Drawing.Size(78, 33);
			this.butIn.TabIndex = 92;
			this.butIn.Text = "&In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butLuu
			// 
			this.butLuu.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butLuu.DefaultScheme = true;
			this.butLuu.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butLuu.Hint = "";
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.Location = new System.Drawing.Point(295, 3);
			this.butLuu.Name = "butLuu";
			this.butLuu.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butLuu.Size = new System.Drawing.Size(79, 33);
			this.butLuu.TabIndex = 85;
			this.butLuu.Text = "&Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butHuy
			// 
			this.butHuy.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butHuy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butHuy.DefaultScheme = true;
			this.butHuy.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butHuy.Enabled = false;
			this.butHuy.Hint = "";
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.Location = new System.Drawing.Point(458, 3);
			this.butHuy.Name = "butHuy";
			this.butHuy.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butHuy.Size = new System.Drawing.Size(81, 33);
			this.butHuy.TabIndex = 88;
			this.butHuy.Text = "&Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butSua
			// 
			this.butSua.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butSua.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butSua.DefaultScheme = true;
			this.butSua.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butSua.Hint = "";
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.Location = new System.Drawing.Point(176, 3);
			this.butSua.Name = "butSua";
			this.butSua.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butSua.Size = new System.Drawing.Size(119, 33);
			this.butSua.TabIndex = 87;
			this.butSua.Text = "&Chuyển giường";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butKetthuc.DefaultScheme = true;
			this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butKetthuc.Hint = "";
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.Location = new System.Drawing.Point(617, 3);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butKetthuc.Size = new System.Drawing.Size(88, 33);
			this.butKetthuc.TabIndex = 91;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butBoqua.DefaultScheme = true;
			this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butBoqua.Hint = "";
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.Location = new System.Drawing.Point(374, 3);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butBoqua.Size = new System.Drawing.Size(84, 33);
			this.butBoqua.TabIndex = 89;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butDoi
			// 
			this.butDoi.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(135)), ((System.Byte)(206)), ((System.Byte)(235)));
			this.butDoi.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butDoi.DefaultScheme = true;
			this.butDoi.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butDoi.Hint = "";
			this.butDoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butDoi.Image")));
			this.butDoi.Location = new System.Drawing.Point(391, -80);
			this.butDoi.Name = "butDoi";
			this.butDoi.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butDoi.Size = new System.Drawing.Size(77, 42);
			this.butDoi.TabIndex = 86;
			this.butDoi.Text = "&Sửa";
			this.butDoi.Visible = false;
			this.butDoi.Click += new System.EventHandler(this.butDoi_Click);
			// 
			// pThongtin
			// 
			this.pThongtin.BackColor = System.Drawing.Color.SkyBlue;
			this.pThongtin.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.groupBox2});
			this.pThongtin.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pThongtin.Location = new System.Drawing.Point(0, 440);
			this.pThongtin.Name = "pThongtin";
			this.pThongtin.Size = new System.Drawing.Size(800, 56);
			this.pThongtin.TabIndex = 86;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.madoituong,
																					this.tu,
																					this.hoten,
																					this.dongia,
																					this.giuongold,
																					this.label5,
																					this.mabn,
																					this.namsinh,
																					this.den,
																					this.giuongnew,
																					this.butPhong,
																					this.label3,
																					this.label8,
																					this.label6,
																					this.label2,
																					this.label1,
																					this.label4,
																					this.label7,
																					this.label9});
			this.groupBox2.Location = new System.Drawing.Point(2, -3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(797, 58);
			this.groupBox2.TabIndex = 93;
			this.groupBox2.TabStop = false;
			// 
			// butPhong
			// 
			this.butPhong.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(236)), ((System.Byte)(233)), ((System.Byte)(216)));
			this.butPhong.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butPhong.DefaultScheme = true;
			this.butPhong.DialogResult = System.Windows.Forms.DialogResult.None;
			this.butPhong.Hint = "";
			this.butPhong.Location = new System.Drawing.Point(609, 33);
			this.butPhong.Name = "butPhong";
			this.butPhong.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butPhong.Size = new System.Drawing.Size(32, 23);
			this.butPhong.TabIndex = 92;
			this.butPhong.Text = "...";
			this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
			// 
			// pTitle
			// 
			this.pTitle.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lbThongtinhanhchanh});
			this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTitle.Name = "pTitle";
			this.pTitle.Size = new System.Drawing.Size(800, 27);
			this.pTitle.TabIndex = 87;
			// 
			// lbThongtinhanhchanh
			// 
			this.lbThongtinhanhchanh.BackColor = System.Drawing.Color.SteelBlue;
			this.lbThongtinhanhchanh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbThongtinhanhchanh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbThongtinhanhchanh.Font = new System.Drawing.Font("Times New Roman", 14F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbThongtinhanhchanh.ForeColor = System.Drawing.Color.White;
			this.lbThongtinhanhchanh.Image = ((System.Drawing.Bitmap)(resources.GetObject("lbThongtinhanhchanh.Image")));
			this.lbThongtinhanhchanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbThongtinhanhchanh.Name = "lbThongtinhanhchanh";
			this.lbThongtinhanhchanh.Size = new System.Drawing.Size(800, 27);
			this.lbThongtinhanhchanh.TabIndex = 9;
			this.lbThongtinhanhchanh.Text = "    CHUYỂN GIƯỜNG";
			this.lbThongtinhanhchanh.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// p
			// 
			this.p.Controls.AddRange(new System.Windows.Forms.Control[] {
																			this.pGrid,
																			this.pTim});
			this.p.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p.Location = new System.Drawing.Point(0, 27);
			this.p.Name = "p";
			this.p.Size = new System.Drawing.Size(800, 413);
			this.p.TabIndex = 88;
			// 
			// pGrid
			// 
			this.pGrid.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.dataGrid1});
			this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pGrid.Location = new System.Drawing.Point(0, 29);
			this.pGrid.Name = "pGrid";
			this.pGrid.Size = new System.Drawing.Size(800, 384);
			this.pGrid.TabIndex = 85;
			// 
			// pTim
			// 
			this.pTim.BackColor = System.Drawing.Color.SkyBlue;
			this.pTim.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.cboKhoa,
																			   this.label14,
																			   this.tim});
			this.pTim.Dock = System.Windows.Forms.DockStyle.Top;
			this.pTim.Name = "pTim";
			this.pTim.Size = new System.Drawing.Size(800, 29);
			this.pTim.TabIndex = 84;
			// 
			// cboKhoa
			// 
			this.cboKhoa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cboKhoa.Location = new System.Drawing.Point(48, 4);
			this.cboKhoa.Name = "cboKhoa";
			this.cboKhoa.Size = new System.Drawing.Size(264, 21);
			this.cboKhoa.TabIndex = 85;
			this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(5, 7);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 16);
			this.label14.TabIndex = 84;
			this.label14.Text = "Khoa :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tim
			// 
			this.tim.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tim.ForeColor = System.Drawing.Color.Red;
			this.tim.Location = new System.Drawing.Point(313, 4);
			this.tim.Name = "tim";
			this.tim.Size = new System.Drawing.Size(485, 21);
			this.tim.TabIndex = 83;
			this.tim.Text = "Tìm kiếm";
			this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
			this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
			this.tim.Enter += new System.EventHandler(this.tim_Enter);
			// 
			// pBut
			// 
			this.pBut.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.butLuu,
																			   this.butTra,
																			   this.butBoqua,
																			   this.butHuy,
																			   this.butSua,
																			   this.butKetthuc,
																			   this.butIn});
			this.pBut.Location = new System.Drawing.Point(7, 7);
			this.pBut.Name = "pBut";
			this.pBut.Size = new System.Drawing.Size(784, 40);
			this.pBut.TabIndex = 94;
			// 
			// frmChuyenphong
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Lavender;
			this.ClientSize = new System.Drawing.Size(800, 592);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.p,
																		  this.pTitle,
																		  this.pThongtin,
																		  this.pButton,
																		  this.listHoten,
																		  this.butMoi});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmChuyenphong";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chuyển phòng/giường";
			this.SizeChanged += new System.EventHandler(this.frmChuyenphong_SizeChanged);
			this.Load += new System.EventHandler(this.frmChuyenphong_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.pButton.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.pThongtin.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.pTitle.ResumeLayout(false);
			this.p.ResumeLayout(false);
			this.pGrid.ResumeLayout(false);
			this.pTim.ResumeLayout(false);
			this.pBut.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmChuyenphong_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			cboKhoa.DisplayMember="TENKP";
			cboKhoa.ValueMember="MAKP";
            cboKhoa.DataSource = m.get_data("select makp,tenkp from " + user + ".btdkp_bv where loai=0").Tables[0];
			//
			itable=m.tableid("","theodoigiuong");
			user=m.user;xxx=user+m.mmyy(s_ngay);
			bNgayra_ngayvao=m.bNgayra_ngayvao_1;

            dt = m.get_data("select * from " + user + ".dmgiuong").Tables[0];
			dsin=m.get_data("select '' mabn,'' hoten,'' namsinh,'' diachi,'' ngaygio,'' khoaphong,'' giuong,0 dongia from dual");

            dtdt = m.get_data("select * from " + user + ".doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdt;
			
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ena_object(false);
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
			TextCol1.MappingName = "mabn";
			TextCol1.HeaderText = "Mã BN";
			TextCol1.Width = 80+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "hoten";
			TextCol1.HeaderText = "Họ tên";
			TextCol1.Width =200+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "namsinh";
			TextCol1.HeaderText = "Năm sinh";
			TextCol1.Width =80+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "doituong";
			TextCol1.HeaderText = "Đối tượng";
			TextCol1.Width = 80+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "sothe";
			TextCol1.HeaderText = "Số thẻ";
			TextCol1.Width = 120+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "Giường";
			TextCol1.Width = 100+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "tu";
			TextCol1.HeaderText = "Ngày giờ đến";
			TextCol1.Width = 100+iChange;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "den";
			TextCol1.HeaderText = "Ngày đi";
			TextCol1.Width =0;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
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
			sql="select a.id,a.mabn,a.maql,a.idkhoa,c.hoten,c.namsinh,a.madoituong,e.doituong,f.sothe,";
			sql+="a.idgiuong,b.ma,b.ten,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,to_char(a.den,'dd/mm/yyyy hh24:mi') as den,a.dongia";
            sql += " from " + user + ".theodoigiuong a," + user + ".hiendien a1," + user + ".dmgiuong b," + user + ".btdbn c," + user + ".doituong e," + user + ".bhyt f";
			sql+=" where a.maql=a1.maql and a.idgiuong=b.id and a.mabn=c.mabn and a.madoituong=e.madoituong and a.maql=f.maql(+) and a.den is null";
			if (s_mabn!="") sql+=" and a.mabn='"+s_mabn+"' and a.idkhoa="+l_idkhoa;
			else if(cboKhoa.SelectedIndex!=-1) sql+=" and a.makp='"+cboKhoa.SelectedValue.ToString()+"'";
			sql+=" order by a.tu";
			ds=m.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
			if(bSkip)
			{
				AddGridTableStyle();
				bSkip=false;
			}
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

		private void ref_text()
		{
			try
			{
				i_giuong_old=0;
				l_id=long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				DataRow r1=m.getrowbyid(ds.Tables[0],"id="+l_id);
				if (r1!=null)
				{
					l_maql=long.Parse(r1["maql"].ToString());
					l_idkhoa=long.Parse(r1["idkhoa"].ToString());
					mabn.Text=r1["mabn"].ToString();
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					tu.Text=r1["tu"].ToString();
					den.Text=r1["den"].ToString();
					madoituong.SelectedValue=r1["madoituong"].ToString();
					giuongold.Text=r1["ma"].ToString();
					i_giuong_old=int.Parse(r1["idgiuong"].ToString());
					giuongnew.Text="";
					dongia.Text=r1["dongia"].ToString();
				}
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ena_object(bool ena)
		{
			madoituong.Enabled=ena;
			den.Enabled=ena;
			butPhong.Enabled=ena;
			butDoi.Enabled=!ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			tim.Enabled=!ena;
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_maql=0;
			ena_object(true);
			mabn.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (den.Text!="")
			{
				MessageBox.Show("Đã chuyển phòng giường không được thay đổi !",LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			den.Text=m.ngayhienhanh_server;
			madoituong.Focus();
		}
		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				madoituong.Focus();
				return false;
			}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
				if (mabn.Text=="") mabn.Focus();
				else if (hoten.Text=="") hoten.Focus();
				return false;
			}
			if (den.Text=="")
			{
				MessageBox.Show("Yêu cầu nhập ngày giờ chuyển !",LibMedi.AccessData.Msg);
				den.Focus();
				return false;
			}
			if (giuongnew.Text=="")
			{
				MessageBox.Show("Chọn phòng giường chuyển !",LibMedi.AccessData.Msg);
				butPhong.Focus();
				return false;
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			decimal songay=0;
			string s_stt="",tt="";
			int idex1,idex2;
            foreach (DataRow r1 in m.get_data("select a.id,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,a.dongia,a.idgiuong,a.madoituong,b.ma,b.idphong from " + user + ".theodoigiuong a," + user + ".dmgiuong b where a.idgiuong=b.id and a.id=" + l_id).Tables[0].Rows)
			{
                tt = m.get_data("select ghichu from " + user + ".dmgiuong where id=" + int.Parse(r1["idgiuong"].ToString())).Tables[0].Rows[0][0].ToString();
				songay=(bNgayra_ngayvao)?pc.songaygiuong(m.StringToDateTime(den.Text),m.StringToDateTime(r1["tu"].ToString()),1,int.Parse(r1["idgiuong"].ToString())):m.songay(m.StringToDate(den.Text),m.StringToDate(r1["tu"].ToString()),0);
				m.upd_theodoigiuong(long.Parse(r1["id"].ToString()),den.Text,int.Parse(r1["madoituong"].ToString()),songay);
				if(songay!=0) v.upd_vpkhoa(l_id,mabn.Text,l_mavaovien, l_maql,l_idkhoa,den.Text,cboKhoa.SelectedValue.ToString(),int.Parse(r1["madoituong"].ToString()),int.Parse(r1["idgiuong"].ToString()),Convert.ToDecimal(songay),decimal.Parse(r1["dongia"].ToString()),0,i_userid,0);
				if(r1["ma"].ToString().IndexOf("TG")!=-1)//Tron goi
				{
					idex1=r1["ma"].ToString().IndexOf("TG")+2;
					idex2=r1["ma"].ToString().IndexOf("/");
					s_stt=r1["ma"].ToString().Substring(idex1,idex2-idex1)+","+r1["ma"].ToString().Substring(idex2+1);
					foreach(DataRow row in get_giuong_trongoi(int.Parse(r1["idphong"].ToString()),s_stt).Rows)
					{
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,ghichu='',soluong=soluong-1 where id=" + int.Parse(row["id"].ToString()));
					}
				}
                m.execute_data("update " + user + ".dmgiuong set soluong=soluong-1,tinhtrang=0,ghichu='' where id=" + int.Parse(r1["idgiuong"].ToString()));
				break;
			}
			m.upd_eve_tables(itable,i_userid,"upd");
			m.upd_eve_upd_del(itable,i_userid,"upd",m.fields(user+".theodoigiuong","id="+l_id));
			DataRow r2,r3=m.getrowbyid(dt,"ma='"+giuongnew.Text+"'");
			string fie="gia_th";
			l_id=v.get_id_vpkhoa;
			if (r3!=null)
			{
				r2=m.getrowbyid(dtdt,"madoituong="+int.Parse(madoituong.SelectedValue.ToString()));
				if (r2!=null) fie=r2["field_gia"].ToString().Trim();
				decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
				int idgiuong=int.Parse(r3["id"].ToString());
				m.upd_theodoigiuong(l_id,cboKhoa.SelectedValue.ToString(),mabn.Text,l_maql,l_idkhoa,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(r3["id"].ToString()),den.Text,decimal.Parse(r3[fie].ToString())*tygia,i_userid,l_mavaovien);
				pc.upd_dmgiuong(int.Parse(r3["id"].ToString()),tt,2);
                m.execute_data("update " + user + ".dmgiuong set soluong=soluong+1 where id=" + int.Parse(r3["id"].ToString()));
                m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_idkhoa);
                m.execute_data("update " + user + ".nhapkhoa set giuong='" + giuongnew.Text + "' where id=" + l_idkhoa);
				i_idgiuong=idgiuong;
				if(r3["ma"].ToString().IndexOf("TG")!=-1)//Tron goi
				{
					s_stt="";
					idex1=r3["ma"].ToString().IndexOf("TG")+2;
					idex2=r3["ma"].ToString().IndexOf("/");
					s_stt=r3["ma"].ToString().Substring(idex1,idex2-idex1)+","+r3["ma"].ToString().Substring(idex2+1);
					foreach(DataRow row1 in get_giuong_trongoi(int.Parse(r3["idphong"].ToString()),s_stt).Rows)
					{
						pc.upd_dmgiuong(int.Parse(row1["id"].ToString()),tt,2);
                        m.execute_data("update " + user + ".dmgiuong set soluong=soluong+1 where id=" + int.Parse(row1["id"].ToString()));
					}
				}
				m.upd_eve_tables(itable,i_userid,"ins");
				m.upd_eve_upd_del(itable,i_userid,"ins",m.fields(user+".theodoigiuong","id="+l_id));
			}
			load_grid();
			ena_object(false);
		}
		private DataTable get_giuong_trongoi(int idphong,string s_stt)
		{
            sql = "select * from " + user + ".dmgiuong where idphong=" + idphong + " and stt in(" + s_stt + ")";
			DataTable dtmp=m.get_data(sql).Tables[0];
			return dtmp;
		}
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			den.Text="";
			ena_object(false);
		}
		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			try
			{
				if (den.Text!="")
				{
					MessageBox.Show("Đã chuyển phòng giường không được hủy !",LibMedi.AccessData.Msg);
					return;
				}
				if (ds.Tables[0].Select("idkhoa="+l_idkhoa).Length==1)
				{
					MessageBox.Show("Không được hủy !",LibMedi.AccessData.Msg);
					return;
				}
				int i_row=dataGrid1.CurrentCell.RowNumber;
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=long.Parse(dataGrid1[i_row,0].ToString());					
					int idgiuong=0;
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".theodoigiuong where idkhoa=" + l_idkhoa + " and to_char(den,'dd/mm/yyyy hh24:mi')='" + tu.Text + "'").Tables[0].Rows)
					{
						idgiuong=int.Parse(r1["idgiuong"].ToString());
                        m.execute_data("update " + user + ".dmgiuong set tinhtrang=2,soluong=soluong+1 where id=" + idgiuong);
                        m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_id);
                        m.execute_data("update " + user + ".theodoigiuong set soluong=0,den=null where id=" + long.Parse(r1["id"].ToString()));
                        m.execute_data("delete from " + user + m.mmyy(tu.Text) + ".v_vpkhoa where id=" + long.Parse(r1["id"].ToString()));
					}
					if (idgiuong!=0)
					{
						m.upd_eve_tables(itable,i_userid,"del");
						m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".theodoigiuong","id="+l_id));
						DataRow r=m.getrowbyid(dt,"ma='"+giuongold.Text+"'");
                        if (r != null) m.execute_data("update " + user + ".dmgiuong set tinhtrang=0,soluong=soluong-1 where id=" + int.Parse(r["id"].ToString()));
						r=m.getrowbyid(dt,"id="+idgiuong);
                        if (r != null) m.execute_data("update " + user + ".nhapkhoa set giuong='" + r["ma"].ToString() + "' where id=" + l_idkhoa);
                        m.execute_data("delete from " + user + ".theodoigiuong where id=" + l_id);
						load_grid();
					}
				}
			}
			catch{}
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
				listHoten.BrowseToDanhmuc(hoten,mabn,madoituong);
			}
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				i_madoituong=int.Parse(r["madoituong"].ToString());
				madoituong.SelectedValue=i_madoituong.ToString();
                l_mavaovien=long.Parse(r["mavaovien"].ToString());
                l_maql=long.Parse(r["maql"].ToString());
                l_idkhoa = long.Parse(r["idkhoa"].ToString());
			}
			else{hoten.Text="";l_maql=0;namsinh.Text="";}
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) mabn_Validated(null,null);
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			RefreshChildren(tim.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="mabn like '%"+text.Trim()+"%'"+" or hoten like '%"+text.Trim()+"%'"+" or ma like '%"+text.Trim()+"%'"+" or ten like '%"+text.Trim()+"%'"+" or sothe like '%"+text.Trim()+"%'";
				ref_text();
			}
			catch{}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butSua.Focus();
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="")
			{
				den.Focus();
				return;
			}
			den.Text=den.Text.Trim();
			if (den.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ chuyển !"),LibMedi.AccessData.Msg);
				den.Focus();
				return;
			}
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,16);
		}
		private void butPhong_Click(object sender, System.EventArgs e)
		{
			frmDsgiuong f=new frmDsgiuong(m,cboKhoa.SelectedValue.ToString()+"_3",int.Parse(madoituong.SelectedValue.ToString()),true,i_giuong_old);
			f.ShowDialog();
			if (f.ma!="")
			{
				giuongnew.Text=f.ma;
				string fie="gia_th";
				DataRow r1=m.getrowbyid(dtdt,"madoituong="+int.Parse(madoituong.SelectedValue.ToString()));
				if (r1!=null) fie=r1["field_gia"].ToString().Trim();
				r1=m.getrowbyid(dt,"ma='"+giuongnew.Text+"'");
				if (r1!=null) dongia.Text=r1[fie].ToString();
				butLuu.Focus();
			}
		}
		private void butDoi_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (den.Text!="")
			{
				MessageBox.Show("Đã chuyển phòng giường không được thay đổi !",LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			den.Enabled=false;
			madoituong.Enabled=false;
			butPhong.Focus();
		}

		private void cboKhoa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(!bSkip)
					load_grid();
			}
			catch{}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if(ds.Tables[0].Rows.Count==0) return;
			dsin.Clear();
			try
			{
				DataRow r=dsin.Tables[0].NewRow();
				r["mabn"]=mabn.Text;
				r["hoten"]=hoten.Text;
				r["namsinh"]=namsinh.Text;
				r["diachi"]=get_diachi(mabn.Text).Trim();
				r["ngaygio"]=tu.Text;
				r["khoaphong"]=cboKhoa.Text;
				r["giuong"]=m.getrowbyid(dt,"ma='"+giuongold.Text+"'")["ten"].ToString();
				r["dongia"]=dongia.Text;
				dsin.Tables[0].Rows.Add(r);
			}
			catch{}
			frmReport f=new frmReport(m,dsin,"","rPhieudatgiuong.rpt");
			f.ShowDialog();
		}
		private string get_diachi(string mabn)
		{
			string s_diachi="";
			try
			{
                sql = "select ltrim(trim(a.sonha||' '||a.thon||' - '||b.tenpxa||' - '||c.tenquan||' - '||d.tentt),'-') as diachi from " + user + ".btdbn a," + user + ".btdpxa b," + user + ".btdquan c," + user + ".btdtt d where a.matt=d.matt and a.maqu=c.maqu and a.maphuongxa=b.maphuongxa and a.mabn='" + mabn + "'";
				s_diachi=m.get_data(sql).Tables[0].Rows[0]["diachi"].ToString();
			}
			catch{}
			return s_diachi;
		}
		private void butTra_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (den.Text!="")
			{
				MessageBox.Show("Đã chuyển phòng giường không được thay đổi !",LibMedi.AccessData.Msg);
				return;
			}
			if(giuongold.Text.IndexOf("TG")==-1)
			{
				MessageBox.Show("Bệnh nhân chỉ nằm 1 giường, muốn chuyển giường thì bấm vào nút Chuyển Giường !",LibMedi.AccessData.Msg);
				return;
			}
			frmTragiuong f=new frmTragiuong(get_giuong_tra(giuongold.Text));
			f.ShowDialog();
			if(f.giuongnew!="")
			{
				giuongnew.Text=f.giuongnew;
				decimal _dongia=f.dongia;
				dongia.Text=_dongia.ToString();
				ena_object(true);
				den.Text=m.ngayhienhanh_server;
				madoituong.Focus();
				butDoi.Enabled=false;
				butPhong.Enabled=false;
			}
		}
		private DataTable get_giuong_tra(string ma)
		{
			int idex1=ma.IndexOf("TG")+2;
			int idex2=ma.IndexOf("/");
			string s_stt=ma.Substring(idex1,idex2-idex1)+","+ma.Substring(idex2+1);
            sql = "select a.id,a.ma,a.ten,a.gia_th dongia from " + user + ".dmgiuong a," + user + ".dmphong b where a.idphong=b.id and a.idphong=" + get_idphong(ma) + " and a.stt in(" + s_stt + ")";
			return m.get_data(sql).Tables[0];
		}
		private int get_idphong(string ma)
		{
			int _id=0;
			try
			{
                sql = "select idphong from " + user + ".dmgiuong where ma='" + ma + "'";
				_id=int.Parse(m.get_data(sql).Tables[0].Rows[0][0].ToString());
			}
			catch{}
			return _id;
		}

		private void frmChuyenphong_SizeChanged(object sender, System.EventArgs e)
		{
			iChange=(this.Width-800)/7;		
			pBut.Location=new Point(7+(this.Width-800)/2,7);
			cboKhoa.Width=264+(this.Width-800)/2;
			tim.Width=485+(this.Width-800)/2;
			tim.Location=new Point(313+(this.Width-800)/2,4);
			if(iChange!=0)
			{
				if(bSkip)
					load_grid();
			}
		}
	}
}
