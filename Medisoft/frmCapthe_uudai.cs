using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmCapthe_uudai : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
        private FingerApp.FrmNhanDang fnhandang;
		private string nam,user,s_userid,s_mabn,s_msg,sql="",s_sothe="",ss;
		public string m_mabn;
        decimal id = 0;
        private int i_userid, i_maxlength_mabn = 10, iCapso = 0,iKhudt=0;
        private bool add_soltru, bVantay = false, bMabn_tudong, bMabn_tudong_theomay = false, bMabn_tudong_tu_ServerInterNet_D24 = false,bDocmavach=false,bThem = true;
        DataTable dtthe = new DataTable();
        DataTable dttyle = new DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox mabn2;
		private MaskedTextBox.MaskedTextBox mabn3;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox loaituoi;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private int iTreem6,iTreem15;
		private bool b_Hoten=false;
		private System.ComponentModel.IContainer components=null;
		private System.Windows.Forms.ComboBox tennuoc;
		private System.Windows.Forms.ComboBox tendantoc;
		private System.Windows.Forms.ComboBox tentqx;
		private System.Windows.Forms.TextBox cholam;
		private System.Windows.Forms.TextBox thon;
		private System.Windows.Forms.TextBox mapxa2;
		private System.Windows.Forms.TextBox maqu2;
		private System.Windows.Forms.TextBox matt;
		private System.Windows.Forms.TextBox tqx;
		private System.Windows.Forms.TextBox manuoc;
		private System.Windows.Forms.TextBox madantoc;
		private System.Windows.Forms.TextBox mann;
		private System.Windows.Forms.ComboBox tennn;
		private System.Windows.Forms.ComboBox tenquan;
		private System.Windows.Forms.ComboBox tentinh;
		private System.Windows.Forms.ComboBox tenpxa;
		private MaskedTextBox.MaskedTextBox mapxa1;
		private MaskedTextBox.MaskedTextBox maqu1;
		private System.Windows.Forms.Label lcholam;
		private MaskedTextBox.MaskedTextBox sonha;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.Label lphai;
		private System.Windows.Forms.Label lmann;
		private System.Windows.Forms.Label lsonha;
		private System.Windows.Forms.Label lmanuoc;
		private System.Windows.Forms.Label lmadantoc;
		private System.Windows.Forms.Label lthon;
		private System.Windows.Forms.Label lmatt;
		private System.Windows.Forms.Label ltqx;
		private System.Windows.Forms.Label lmaphuongxa;
		private System.Windows.Forms.Label lmaqu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox soluutru;
        private Panel pdienthoai;
        private TextBox dt_email;
        private TextBox dt_didong;
        private TextBox dt_coquan;
        private Label label31;
        private Label label22;
        private TextBox dt_nha;
        private Label label21;
        private Label label20;
        private PictureBox ptb;
        private Label label2;
        private ComboBox cmdLoaithe;
        private MaskedBox.MaskedBox tungay;
        private Label label8;
        private Label label9;
        private MaskedBox.MaskedBox denngay;
        private DataGrid dataGrid1;
        private DataGrid dataGrid2;
        private Label label10;
        private Label label11;
        private Button butThem;
        private Button butSua;
        private Button butXoa;
        private Label label12;
        private MaskedBox.MaskedBox ngaycap;
        private Button butIn;
		private MaskedBox.MaskedBox ngaysinh;
		public frmCapthe_uudai(LibMedi.AccessData acc,int userid,int khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            iKhudt = khudt;
			i_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapthe_uudai));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loaituoi = new System.Windows.Forms.ComboBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tennuoc = new System.Windows.Forms.ComboBox();
            this.manuoc = new System.Windows.Forms.TextBox();
            this.lmanuoc = new System.Windows.Forms.Label();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.tendantoc = new System.Windows.Forms.ComboBox();
            this.tentqx = new System.Windows.Forms.ComboBox();
            this.cholam = new System.Windows.Forms.TextBox();
            this.thon = new System.Windows.Forms.TextBox();
            this.mapxa2 = new System.Windows.Forms.TextBox();
            this.maqu2 = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.TextBox();
            this.tqx = new System.Windows.Forms.TextBox();
            this.madantoc = new System.Windows.Forms.TextBox();
            this.mann = new System.Windows.Forms.TextBox();
            this.tennn = new System.Windows.Forms.ComboBox();
            this.tenquan = new System.Windows.Forms.ComboBox();
            this.tentinh = new System.Windows.Forms.ComboBox();
            this.tenpxa = new System.Windows.Forms.ComboBox();
            this.mapxa1 = new MaskedTextBox.MaskedTextBox();
            this.lmaphuongxa = new System.Windows.Forms.Label();
            this.maqu1 = new MaskedTextBox.MaskedTextBox();
            this.lmaqu = new System.Windows.Forms.Label();
            this.lmatt = new System.Windows.Forms.Label();
            this.ltqx = new System.Windows.Forms.Label();
            this.lcholam = new System.Windows.Forms.Label();
            this.lthon = new System.Windows.Forms.Label();
            this.lsonha = new System.Windows.Forms.Label();
            this.lmadantoc = new System.Windows.Forms.Label();
            this.lmann = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.label1 = new System.Windows.Forms.Label();
            this.soluutru = new System.Windows.Forms.TextBox();
            this.pdienthoai = new System.Windows.Forms.Panel();
            this.dt_email = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.dt_didong = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dt_coquan = new System.Windows.Forms.TextBox();
            this.dt_nha = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdLoaithe = new System.Windows.Forms.ComboBox();
            this.tungay = new MaskedBox.MaskedBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.denngay = new MaskedBox.MaskedBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ngaycap = new MaskedBox.MaskedBox();
            this.butIn = new System.Windows.Forms.Button();
            this.pdienthoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(0, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(145, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(490, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(64, 16);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(22, 21);
            this.mabn2.TabIndex = 0;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(88, 16);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(61, 21);
            this.mabn3.TabIndex = 1;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(610, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(674, 16);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 4;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(688, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "Tuổi",
            "Tháng",
            "Ngày",
            "Giờ"});
            this.loaituoi.Location = new System.Drawing.Point(767, 15);
            this.loaituoi.Name = "loaituoi";
            this.loaituoi.Size = new System.Drawing.Size(76, 21);
            this.loaituoi.TabIndex = 7;
            this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
            // 
            // tuoi
            // 
            this.tuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(738, 16);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(28, 21);
            this.tuoi.TabIndex = 6;
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
            // 
            // hoten
            // 
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(190, 16);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(301, 21);
            this.hoten.TabIndex = 2;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(281, 364);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 36;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(491, 364);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 39;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(701, 364);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 41;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(771, 364);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 42;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(593, 38);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(250, 21);
            this.tennuoc.TabIndex = 14;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(567, 38);
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 13;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmanuoc.Location = new System.Drawing.Point(503, 40);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(63, 61);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(70, 21);
            this.sonha.TabIndex = 15;
            // 
            // tendantoc
            // 
            this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendantoc.Location = new System.Drawing.Point(442, 38);
            this.tendantoc.Name = "tendantoc";
            this.tendantoc.Size = new System.Drawing.Size(65, 21);
            this.tendantoc.TabIndex = 12;
            this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
            this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
            // 
            // tentqx
            // 
            this.tentqx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentqx.Location = new System.Drawing.Point(650, 61);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(193, 21);
            this.tentqx.TabIndex = 18;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(63, 107);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(265, 21);
            this.cholam.TabIndex = 27;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(190, 61);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(355, 21);
            this.thon.TabIndex = 16;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(542, 84);
            this.mapxa2.Name = "mapxa2";
            this.mapxa2.Size = new System.Drawing.Size(23, 21);
            this.mapxa2.TabIndex = 25;
            this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
            this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
            // 
            // maqu2
            // 
            this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu2.Location = new System.Drawing.Point(305, 84);
            this.maqu2.Name = "maqu2";
            this.maqu2.Size = new System.Drawing.Size(23, 21);
            this.maqu2.TabIndex = 22;
            this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
            this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(63, 84);
            this.matt.MaxLength = 3;
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(27, 21);
            this.matt.TabIndex = 19;
            this.matt.Validated += new System.EventHandler(this.matt_Validated);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // tqx
            // 
            this.tqx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqx.Location = new System.Drawing.Point(600, 61);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 17;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(416, 38);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(24, 21);
            this.madantoc.TabIndex = 11;
            this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(189, 38);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(22, 21);
            this.mann.TabIndex = 9;
            this.mann.Validated += new System.EventHandler(this.mann_Validated);
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // tennn
            // 
            this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennn.Location = new System.Drawing.Point(212, 38);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(155, 21);
            this.tennn.TabIndex = 10;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(329, 84);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(111, 21);
            this.tenquan.TabIndex = 23;
            this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
            this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
            // 
            // tentinh
            // 
            this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentinh.Location = new System.Drawing.Point(92, 84);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(136, 21);
            this.tentinh.TabIndex = 20;
            this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
            this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
            // 
            // tenpxa
            // 
            this.tenpxa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpxa.Location = new System.Drawing.Point(567, 84);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(276, 21);
            this.tenpxa.TabIndex = 26;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(502, 84);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(38, 21);
            this.mapxa1.TabIndex = 24;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaphuongxa.Location = new System.Drawing.Point(433, 85);
            this.lmaphuongxa.Name = "lmaphuongxa";
            this.lmaphuongxa.Size = new System.Drawing.Size(72, 23);
            this.lmaphuongxa.TabIndex = 77;
            this.lmaphuongxa.Text = "Phường/Xã :";
            this.lmaphuongxa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maqu1
            // 
            this.maqu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu1.Enabled = false;
            this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu1.Location = new System.Drawing.Point(277, 84);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 21;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaqu.Location = new System.Drawing.Point(199, 82);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmatt.Location = new System.Drawing.Point(8, 82);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltqx.Location = new System.Drawing.Point(529, 61);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcholam.Location = new System.Drawing.Point(-17, 104);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(85, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lthon.Location = new System.Drawing.Point(120, 62);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lsonha.Location = new System.Drawing.Point(8, 62);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(56, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmadantoc.Location = new System.Drawing.Point(360, 40);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 16);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmann.Location = new System.Drawing.Point(112, 40);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 58;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(63, 38);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(53, 21);
            this.phai.TabIndex = 8;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lphai.Location = new System.Drawing.Point(0, 40);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(64, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysinh
            // 
            this.ngaysinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(554, 16);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(64, 21);
            this.ngaysinh.TabIndex = 3;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(569, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 162;
            this.label1.Text = "Số lưu trữ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // soluutru
            // 
            this.soluutru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.Enabled = false;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.ForeColor = System.Drawing.Color.Red;
            this.soluutru.Location = new System.Drawing.Point(632, 430);
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(89, 21);
            this.soluutru.TabIndex = 28;
            this.soluutru.Visible = false;
            this.soluutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.soluutru_KeyDown);
            // 
            // pdienthoai
            // 
            this.pdienthoai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pdienthoai.BackColor = System.Drawing.SystemColors.Control;
            this.pdienthoai.Controls.Add(this.dt_email);
            this.pdienthoai.Controls.Add(this.label31);
            this.pdienthoai.Location = new System.Drawing.Point(5, 129);
            this.pdienthoai.Name = "pdienthoai";
            this.pdienthoai.Size = new System.Drawing.Size(274, 25);
            this.pdienthoai.TabIndex = 31;
            // 
            // dt_email
            // 
            this.dt_email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_email.Location = new System.Drawing.Point(58, 2);
            this.dt_email.Name = "dt_email";
            this.dt_email.Size = new System.Drawing.Size(211, 21);
            this.dt_email.TabIndex = 0;
            this.dt_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label31.Location = new System.Drawing.Point(25, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(38, 13);
            this.label31.TabIndex = 247;
            this.label31.Text = "Email :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_didong
            // 
            this.dt_didong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_didong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_didong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_didong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_didong.Location = new System.Drawing.Point(384, 107);
            this.dt_didong.Name = "dt_didong";
            this.dt_didong.Size = new System.Drawing.Size(121, 21);
            this.dt_didong.TabIndex = 28;
            this.dt_didong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label22.Location = new System.Drawing.Point(337, 110);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 13);
            this.label22.TabIndex = 246;
            this.label22.Text = "Di động :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_coquan
            // 
            this.dt_coquan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_coquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_coquan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_coquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_coquan.Location = new System.Drawing.Point(739, 106);
            this.dt_coquan.Name = "dt_coquan";
            this.dt_coquan.Size = new System.Drawing.Size(104, 21);
            this.dt_coquan.TabIndex = 30;
            this.dt_coquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // dt_nha
            // 
            this.dt_nha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_nha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_nha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dt_nha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_nha.Location = new System.Drawing.Point(567, 106);
            this.dt_nha.Name = "dt_nha";
            this.dt_nha.Size = new System.Drawing.Size(101, 21);
            this.dt_nha.TabIndex = 29;
            this.dt_nha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label21.Location = new System.Drawing.Point(676, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 242;
            this.label21.Text = "Đt cơ quan :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label20.Location = new System.Drawing.Point(513, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 241;
            this.label20.Text = "ĐT nhà :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptb
            // 
            this.ptb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.Image = ((System.Drawing.Image)(resources.GetObject("ptb.Image")));
            this.ptb.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptb.InitialImage")));
            this.ptb.Location = new System.Drawing.Point(3, 389);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(10, 10);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 258;
            this.ptb.TabStop = false;
            this.ptb.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 259;
            this.label2.Text = "Loại thẻ: ";
            // 
            // cmdLoaithe
            // 
            this.cmdLoaithe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoaithe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdLoaithe.Enabled = false;
            this.cmdLoaithe.FormattingEnabled = true;
            this.cmdLoaithe.Location = new System.Drawing.Point(340, 132);
            this.cmdLoaithe.Name = "cmdLoaithe";
            this.cmdLoaithe.Size = new System.Drawing.Size(102, 21);
            this.cmdLoaithe.TabIndex = 32;
            this.cmdLoaithe.SelectedIndexChanged += new System.EventHandler(this.cmdLoaithe_SelectedIndexChanged);
            this.cmdLoaithe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // tungay
            // 
            this.tungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Enabled = false;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(493, 132);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(64, 21);
            this.tungay.TabIndex = 33;
            this.tungay.Text = "  /  /    ";
            this.tungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(443, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 262;
            this.label8.Text = "Từ ngày :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(563, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 264;
            this.label9.Text = "Đến ngày :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denngay
            // 
            this.denngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Enabled = false;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(620, 132);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(64, 21);
            this.denngay.TabIndex = 34;
            this.denngay.Text = "  /  /    ";
            this.denngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 153);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(461, 194);
            this.dataGrid1.TabIndex = 284;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(478, 153);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(365, 194);
            this.dataGrid2.TabIndex = 285;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 286;
            this.label10.Text = "Thẻ đã cấp";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 287;
            this.label11.Text = "Tỷ lệ miễn giảm";
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThem.BackColor = System.Drawing.Color.Transparent;
            this.butThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(351, 364);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 37;
            this.butThem.Text = "     &Thêm";
            this.butThem.UseVisualStyleBackColor = false;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.BackColor = System.Drawing.Color.Transparent;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(421, 364);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 38;
            this.butSua.Text = "    &Sửa";
            this.butSua.UseVisualStyleBackColor = false;
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butXoa.BackColor = System.Drawing.Color.Transparent;
            this.butXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(631, 364);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 40;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.UseVisualStyleBackColor = false;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(721, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 292;
            this.label12.Text = "Ngày cấp :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaycap
            // 
            this.ngaycap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaycap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaycap.Enabled = false;
            this.ngaycap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaycap.Location = new System.Drawing.Point(779, 131);
            this.ngaycap.Mask = "##/##/####";
            this.ngaycap.Name = "ngaycap";
            this.ngaycap.Size = new System.Drawing.Size(64, 21);
            this.ngaycap.TabIndex = 35;
            this.ngaycap.Text = "  /  /    ";
            this.ngaycap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdLoaithe_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(561, 364);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 293;
            this.butIn.Text = "    &In thẻ";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // frmCapthe_uudai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(854, 401);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.ngaycap);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.dt_didong);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dt_coquan);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dt_nha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdLoaithe);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.pdienthoai);
            this.Controls.Add(this.mapxa1);
            this.Controls.Add(this.tentinh);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.tentqx);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.cholam);
            this.Controls.Add(this.maqu1);
            this.Controls.Add(this.tqx);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.tennn);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.tendantoc);
            this.Controls.Add(this.manuoc);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lmann);
            this.Controls.Add(this.lmadantoc);
            this.Controls.Add(this.lmanuoc);
            this.Controls.Add(this.lsonha);
            this.Controls.Add(this.lthon);
            this.Controls.Add(this.ltqx);
            this.Controls.Add(this.lmatt);
            this.Controls.Add(this.lmaqu);
            this.Controls.Add(this.maqu2);
            this.Controls.Add(this.tenquan);
            this.Controls.Add(this.lmaphuongxa);
            this.Controls.Add(this.mapxa2);
            this.Controls.Add(this.tenpxa);
            this.Controls.Add(this.lcholam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.dataGrid2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(792, 409);
            this.Name = "frmCapthe_uudai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấp thẻ ưu đãi";
            this.Load += new System.EventHandler(this.frmCapthe_uudai_Load);
            this.pdienthoai.ResumeLayout(false);
            this.pdienthoai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCapthe_uudai_Load(object sender, System.EventArgs e)
		{
            //user = m.user;
            m_mabn = "";
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlength_mabn;
            if (m.Mabv_so == 701641) lcholam.Text = "Điện thoại :";
            pdienthoai.Visible = m.bDienthoai;
           load_dm();
           s_msg = LibMedi.AccessData.Msg;
           iTreem6 = m.iTreem6;
           iTreem15 = m.iTreem15;
           b_Hoten = m.bHoten_gioitinh;
           butTiep.Enabled = m_mabn == "";
           nam = ""; ngaysinh.Text = "";
           bMabn_tudong = m.bMabn_tudong_tiepdon;
           bVantay = m.bVantay;
           bMabn_tudong_tu_ServerInterNet_D24 = m.bMabn_tudong_tu_ServerInterNet_D24;
           bMabn_tudong_theomay = m.bMSBN_Tudong_Theomay;
           bDocmavach = m.bDocmavach;
           ptb.Visible = bVantay && m.bAdminHethong(i_userid);
           if (m_mabn != "")
           {
               nam = m.get_mabn_nam(m_mabn);
               mabn2.Text = m_mabn.Substring(0, 2);
               mabn3.Text = m_mabn.Substring(2);
               mabn2.Enabled = false;
               mabn3.Enabled = false;
               butLuu.Enabled = true;
           }
           
           sql = "select * from "+m.user+".v_dmloaithe_uudai where sudung=1";
           dtthe = m.get_data(sql).Tables[0];
           cmdLoaithe.DataSource = dtthe;
           cmdLoaithe.DisplayMember = "TEN";
           cmdLoaithe.ValueMember = "ID";
           if (cmdLoaithe.Items.Count > 0) cmdLoaithe.SelectedValue = 1;

           load_grid_tyle_null();
           //sql = "select 0 id,'' ten,0 tyle from dual";
           //dttyle = m.get_data(sql).Tables[0];
           //dataGrid2.DataSource = dttyle;
           AddGridTableStyle();

           sql = "select 0 id,'' loaithe,'' sothe,'' machinhanh,'' chinhanh,'' ngaycap,'' tungay,'' denngay from dual";
           dtthe = m.get_data(sql).Tables[0];
           dataGrid1.DataSource = dtthe;
           
           AddGridTableStyle2();
		}

		private void load_dm()
		{
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);

			tennn.DisplayMember="TENNN";
			tennn.ValueMember="MANN";
			load_btdnn(0);			

			tendantoc.DisplayMember="DANTOC";
			tendantoc.ValueMember="MADANTOC";
			tendantoc.DataSource=m.get_data("select * from "+m.user+".btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
			tentinh.DataSource=m.get_data("select * from "+m.user+".btdtt order by tentt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
			tennuoc.DataSource=m.get_data("select * from "+m.user+".dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";
		}

		private void load_tqx()
		{
			tentqx.DataSource=m.Tqx(tqx.Text).Tables[0];
		}

		private void ena_tuoi(bool ena)
		{
			tuoi.Enabled=ena;
			loaituoi.Enabled=ena;
		}

		private void ena_namsinh(bool ena)
		{
			namsinh.Enabled=ena;
		}

		private void load_quan()
		{
			tenquan.DataSource=m.get_data("select * from "+m.user+".btdquan where matt='"+tentinh.SelectedValue.ToString()+"'"+" order by maqu").Tables[0];
		}

		private void load_pxa()
		{
            tenpxa.DataSource = m.get_data("select * from " + m.user + ".btdpxa where maqu='" + tenquan.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") mabn2.Focus();
		}

		private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaituoi.SelectedIndex==-1) loaituoi.SelectedIndex=0;
				namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{F4}");
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phai.SelectedIndex==-1) phai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private bool load_tim_mabn()
		{
			string s_mann=mann.Text;
			load_btdnn(1);
			tennn.SelectedValue=s_mann;
			s_mabn=mabn2.Text+mabn3.Text;
            DataTable dt = m.get_Timmabn(hoten.Text.Trim().ToUpper(), ngaysinh.Text, namsinh.Text, s_mabn).Tables[0];
			if (dt.Rows.Count>0)
			{
				frmTimMabn f=new frmTimMabn(dt);
				f.ShowDialog();
				if (f.m_mabn!="")
				{
					mabn2.Text=f.m_mabn.Substring(0,2);
					mabn3.Text=f.m_mabn.Substring(2,6);
					s_mabn=mabn2.Text+mabn3.Text;
					load_mabn();
					return true;
				}
			}
			return false;
		}

		private void tennn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennn.SelectedIndex==-1) tennn.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ena_nuoc(bool ena)
		{
			manuoc.Enabled=ena;
			tennuoc.Enabled=ena;
		}

		private void tennn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mann.Text=tennn.SelectedValue.ToString();
			}
			catch{mann.Text="";}
		}

		private void tendantoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				madantoc.Text=tendantoc.SelectedValue.ToString();
				if (madantoc.Text=="55") ena_nuoc(true);			
				else
				{
					ena_nuoc(false);
					tennuoc.SelectedValue="VN";
				}
			}
			catch{madantoc.Text="";}
		}

		private void tendantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tendantoc.SelectedIndex==-1) tendantoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tennuoc.SelectedIndex==-1) tennuoc.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tennuoc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				manuoc.Text=tennuoc.SelectedValue.ToString();
			}
			catch{manuoc.Text="";}
		}

		private void tentqx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				tentinh.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,3);
				tenquan.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,5);
				tenpxa.SelectedValue=tentqx.SelectedValue.ToString();
			}
			catch{tqx.Text="";}
		}

		private void tentqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					if (tentqx.SelectedIndex==-1) tentqx.SelectedIndex=0;
					tentinh.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,3);
					tenquan.SelectedValue=tentqx.SelectedValue.ToString().Substring(0,5);
					tenpxa.SelectedValue=tentqx.SelectedValue.ToString();
					cholam.Focus();
					return;
				}
				catch{}
				SendKeys.Send("{Tab}");
			}
		}

		private void tentinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) 
			{
				if (tentinh.SelectedIndex==-1) tentinh.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tentinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				matt.Text=tentinh.SelectedValue.ToString();
				load_quan();
			}
			catch{matt.Text="";}
		}

		private void tenquan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				maqu1.Text=tenquan.SelectedValue.ToString().Substring(0,3);
				maqu2.Text=tenquan.SelectedValue.ToString().Substring(3,2);
				load_pxa();
			}
			catch
			{
				maqu1.Text="";
				maqu2.Text="";
			}
		}

		private void tenquan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenquan.SelectedIndex==-1) tenquan.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenpxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenpxa.SelectedIndex==-1) tenpxa.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenpxa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mapxa1.Text=tenpxa.SelectedValue.ToString().Substring(0,5);
				mapxa2.Text=tenpxa.SelectedValue.ToString().Substring(5,2);
			}
			catch
			{
				mapxa1.Text="";
				mapxa2.Text="";
			}
		}

		private void tuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void manuoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tentinh.SelectedValue=matt.Text;
			}
			catch{}
		}

		private void mann_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennn.SelectedValue=mann.Text;
			}
			catch{}
		}

		private void madantoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendantoc.SelectedValue=madantoc.Text;
			}
			catch{}
		}

		private void manuoc_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennuoc.SelectedValue=manuoc.Text;
			}
			catch{}
		}

		private void maqu2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenquan.SelectedValue=maqu1.Text+maqu2.Text;
			}
			catch{}
		}

		private void maqu2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenpxa.SelectedValue=mapxa1.Text+mapxa2.Text;
			}
			catch{}
		}

		private void tqx_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tqx.Text=="") matt.Focus();
				else
				{
					load_tqx();
					if (tentqx.Items.Count==1)
					{
						try
						{
							string s=tentqx.SelectedValue.ToString();
							tentinh.SelectedValue=s.Substring(0,3);
							tenquan.SelectedValue=s.Substring(0,5);
							tenpxa.SelectedValue=s;
							cholam.Focus();
						}
						catch{}
					}
					else SendKeys.Send("{Tab}{F4}");
				}
			}
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			mabn2.Text=mabn2.Text.PadLeft(2,'0');		
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			load_btdnn(0);
			//if (mabn3.Text=="") return;
			mabn3.Text=mabn3.Text.PadLeft(i_maxlength_mabn-2,'0');//(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
			if (m_mabn=="")
			{
				if (!load_mabn())
				{
                    //cap mabn
                    nam = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2)+"+";
                    decimal stt = 0;
                    if ((bMabn_tudong || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text.Trim('0') == "")
                    {
                        for (; ; )
                        {
                            stt = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true);
                            if(i_maxlength_mabn>8)
                                mabn3.Text = iKhudt.ToString().PadLeft(2,'0')+ stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');
                            else
                                mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 2, '0');
                            s_mabn = mabn2.Text + mabn3.Text;
                            if (m.get_data("select mabn from " + m.user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                        }
                    }
                    else if ((bMabn_tudong_theomay || bMabn_tudong_tu_ServerInterNet_D24) && mabn3.Text.Trim('0') == "")
                    {
                        if (mabn2.Text == "")
                        {
                            mabn2.Focus();
                            return;
                        }

                        for (; ; )
                        {
                            //stt = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true);
                            //mabn3.Text = stt.ToString().PadLeft(6, '0');
                            //s_mabn = mabn2.Text + mabn3.Text;
                            //if (m.get_data("select * from "+user+".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                            iCapso = 0;
                            stt = m.get_mabns(int.Parse(mabn2.Text), 0, 0);
                            if (stt != 0)
                            {
                                if (i_maxlength_mabn > 8)
                                    mabn3.Text = iKhudt.ToString().PadLeft(2, '0') +  stt.ToString().PadLeft(i_maxlength_mabn - 4, '0');//6,'0');
                                mabn3.Text =  stt.ToString().PadLeft(i_maxlength_mabn - 2, '0');//6,'0');
                                iCapso = 2;
                            }
                            else
                            {
                                if (i_maxlength_mabn > 8)
                                {
                                    mabn3.Text = iKhudt.ToString().PadLeft(2, '0') + m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(i_maxlength_mabn - 4, '0');//(6, '0');
                                    m.upd_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text.Substring(2)));
                                }
                                else
                                {
                                    mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 0, 0, true).ToString().PadLeft(i_maxlength_mabn - 2, '0');//(6, '0');
                                    m.upd_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                                }
                                iCapso = 1;
                            }
                            s_mabn = mabn2.Text + mabn3.Text;
                            if (m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                            else if (iCapso != 0) m.del_mabns(int.Parse(mabn2.Text), 0, 0, decimal.Parse(mabn3.Text));
                        }
                        //if (barcode.Visible) barcode.Text = s_mabn;
                        emp_text(true);
                        return;
                    }
                    else if (mabn3.Text.Trim('0') == "") return;
                    
                    if (bDocmavach)
                    {
                        string s = mabn3.Text;
                        if (s.Length == 10)
                        {
                            mabn2.Text = s.Substring(0, 2);
                            mabn3.Text = s.Substring(2);
                        }
                    }
                    mabn3.Text = mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');//(6,'0');
                    s_mabn = mabn2.Text + mabn3.Text;
					//MessageBox.Show(lan.Change_language_MessageText("Mã người bệnh không tìm thấy !"),s_msg);
					//mabn2.Focus();
				}
					// cập nhật số lưu trữ
                //else
                //{
                //    if(add_soltru)
                //    {
                //        soluutru.Enabled=true;
                //        DataTable tb= new DataTable();
                //        string sql = "select a.soluutru from " + m.user + ".lienhe a, " + m.user + ".benhandt b where b.maql=(select max(maql) from " + m.user + ".benhandt where mabn='" + s_mabn + "') and a.maql =b.maql";
                //        tb=m.get_data(sql).Tables[0];
                //        if(tb.Rows.Count <=0 && nam!="")
                //        {
                //            sql = "select a.soluutru from " + m.user + nam.Substring(nam.Length - 5, 4) + ".lienhe a," + m.user + nam.Substring(nam.Length - 5, 4) + ".tiepdon b where b.maql=(select max(maql) from " + m.user + nam.Substring(nam.Length - 5, 4) + ".tiepdon where mabn='" + s_mabn + "') and a.maql=b.maql";
                //            tb=m.get_data(sql).Tables[0];
                //            if(tb.Rows.Count > 0) soluutru.Text=tb.Rows[0]["SOLUUTRU"].ToString();						
                //        }
                //        else
                //        {
                //            soluutru.Text=tb.Rows[0]["SOLUUTRU"].ToString();						
                //        }					
                //    }
                //    else
                //    {
                //        soluutru.Enabled=false;
                //    }
                //}
				// end cập nhật số lưu trữ
			}
            cmdLoaithe.Enabled = true;
            tungay.Enabled = true;
            denngay.Enabled = true;
            tungay.Text="";
            denngay.Text = "";
            ngaycap.Text = DateTime.Now.ToString("dd/MM/yyyy");
		}

		private bool load_mabn()
		{
			bool ret=false;
			foreach(DataRow r in m.get_data("select * from "+m.user+".btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				if (r["ngaysinh"].ToString()!="")
				{
					ngaysinh.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["ngaysinh"].ToString()));
					string tuoivao=m.Tuoivao("",ngaysinh.Text);
					tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
					loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				}
				else
				{
					tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
					loaituoi.SelectedIndex=0;
				}
                nam = r["nam"].ToString().Trim();
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				tennn.SelectedValue=r["mann"].ToString();
				tendantoc.SelectedValue=r["madantoc"].ToString();
				sonha.Text=r["sonha"].ToString();
				thon.Text=r["thon"].ToString();
				cholam.Text=r["cholam"].ToString();
				tentinh.SelectedValue=r["matt"].ToString();
				load_quan();
				tenquan.SelectedValue=r["maqu"].ToString();
				load_pxa();
				tenpxa.SelectedValue=r["maphuongxa"].ToString();
				ret=true;
				break;
			}
            if (pdienthoai.Visible && ret)
            {
                foreach (DataRow r1 in m.get_data("select * from " + m.user + ".dienthoai where mabn='" + s_mabn + "'").Tables[0].Rows)
                {
                    dt_nha.Text = r1["nha"].ToString();
                    dt_coquan.Text = r1["coquan"].ToString();
                    dt_didong.Text = r1["didong"].ToString();
                    dt_email.Text = r1["email"].ToString();
                }
            }
			if (ret && manuoc.Enabled) tennuoc.SelectedValue=m.get_data("select id_nuoc from "+m.user+".nuocngoai where mabn='"+s_mabn+"'").Tables[0].Rows[0][0].ToString();
            load_grid_the();
			return ret;
		}

		private void ngaysinh_Validated(object sender, System.EventArgs e)
		{
			if (ngaysinh.Text=="") return;
			ngaysinh.Text=ngaysinh.Text.Trim();
			if (!m.bNgay(ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			ngaysinh.Text=m.Ktngaygio(ngaysinh.Text,10);
			if (!m.bNgay("",ngaysinh.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"));
				ngaysinh.Focus();
				return;
			}
			try
			{
				string tuoivao=m.Tuoivao("",ngaysinh.Text);
				tuoi.Text=tuoivao.Substring(2).PadLeft(3,'0');
				loaituoi.SelectedIndex=int.Parse(tuoivao.Substring(0,1));
				namsinh.Text=m.Namsinh(ngaysinh.Text).ToString();
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh && loaituoi.SelectedIndex==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					ngaysinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),s_msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled)
					{
						phai.Focus();
						SendKeys.Send("{F4}");
					}
					else mann.Focus();
				}
			}
			catch{}
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="")
			{
				if (int.Parse(namsinh.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
				if (int.Parse(tuoi.Text)>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (tuoi.Text=="000")
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tuổi vào !"),s_msg);
					tuoi.Focus();
					return;
				}
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{Tab}");
					else mann.Focus();
				}
			}
		}

		private void tuoi_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (int.Parse(tuoi.Text)==0) ngaysinh.Focus();
			}
			catch{ngaysinh.Focus();}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				hoten.Text=m.Viettat(hoten.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void thon_Validated(object sender, System.EventArgs e)
		{
			thon.Text=m.Caps(thon.Text);
		}

		private void thon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				thon.Text=m.Viettat(thon.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cholam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				cholam.Text=m.Viettat(cholam.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
			cholam.Text=m.Caps(cholam.Text);		
		}

		private void frmCapthe_uudai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F10:
					butKetthuc_Click(sender,e);
					break;
                case Keys.F5:
                    if (bVantay && m.bAdminHethong(i_userid)) lay_mabn_vantay();
                    break;
			}
		}

        private void lay_mabn_vantay()
        {
            string ma_vantay = "";
            string s_mabn = mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');//(6, '0');
            //string asql = "delete from " + m.user + ".vantay where mabn='" + s_mabn + "'";
            //m.execute_data(asql);            
            //if (fnhandang == null) 
            fnhandang = new FingerApp.FrmNhanDang(ptb);
            fnhandang.ShowDialog();
            ma_vantay = fnhandang.mabn;
        }
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m_mabn="";
			m.close();this.Close();
		}

		private void emp_text(bool skip)
		{
			ena_but(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
			loaituoi.SelectedIndex=0;
			hoten.Text="";
			ngaysinh.Text="";
			namsinh.Text="";
			tuoi.Text="";
			sonha.Text="";
			thon.Text="";
			cholam.Text="";
			soluutru.Text="";
			tentqx.SelectedIndex=-1;
			tqx.Text="";
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			load_quan();
			load_pxa();
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			emp_text(false);
            cmdLoaithe.Enabled = true;
            tungay.Enabled = true;
            denngay.Enabled = true;
			mabn2.Focus();
            bThem = true;
		}

		private bool kiemtra()
		{
            if (tungay.Text.Trim().Trim('/').Trim() == "" || !m.bNgay(tungay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), s_msg);
                tungay.Focus();
                return false;
            }
            if (denngay.Text.Trim().Trim('/').Trim() == ""||!m.bNgay(tungay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), s_msg);
                denngay.Focus();
                return false;
            }
            if (ngaycap.Text.Trim().Trim('/').Trim() == "" || !m.bNgay(tungay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), s_msg);
                ngaycap.Focus();
                return false;
            }
            if (mabn2.Text == "" || mabn3.Text == "" )
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return false;
			}

			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"),s_msg);
				hoten.Focus();
				return false;
			}

			if (namsinh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
				ngaysinh.Focus();
				return false;
			}
            if (m.StringToDate(tungay.Text) > m.StringToDate(denngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Từ ngày đến ngày không hợp lệ!"), s_msg);
                tungay.Focus();
                return false;
            }
			
			if (tennuoc.Enabled)
			{
				if (tennuoc.SelectedValue.ToString()=="VN" && tendantoc.SelectedValue.ToString()=="55")
				{
					MessageBox.Show(lan.Change_language_MessageText("Quốc tịch không hợp lệ !"),LibMedi.AccessData.Msg);
					tennuoc.Focus();
					return false;
				}
			}

			if (b_Hoten)
			{
				if ((hoten.Text.Trim().IndexOf(" VĂN ")!=-1 && phai.SelectedIndex==1) || (hoten.Text.Trim().IndexOf(" THỊ ")!=-1 && phai.SelectedIndex==0))
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên và giới tính không hợp lệ !"),LibMedi.AccessData.Msg);
					if (phai.Enabled) phai.Focus();
					else hoten.Focus();
					return false;
				}
			}

			if (tuoi.Text=="" || loaituoi.SelectedIndex==-1)
			{
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				tuoi.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text)).PadLeft(3,'0');
				loaituoi.SelectedIndex=0;
			}
			else
			{
				if (namsinh.Text!=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString())
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Tuổi và năm sinh không hợp lệ\nBạn có muốn chương trình tính lại không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						ngaysinh.Text="";
                        namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
					}
					else
					{
						if (ngaysinh.Text!="") ngaysinh.Focus();
						else namsinh.Focus();
						return false;
					}
				}
			}

			if (mann.Text=="" || tennn.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập nghề nghiệp !"),s_msg);
				mann.Focus();
				return false;
			}

			if (tentinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn tỉnh/thành phố !"),s_msg);
				tentinh.Focus();
				return false;
			}

			if (tenquan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quận/huyện !"),s_msg);
				tenquan.Focus();
				return false;
			}

			if (tenpxa.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phường xã !"),s_msg);
				tenpxa.Focus();
				return false;
			}

			if (madantoc.Text=="" || tendantoc.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn dân tộc !"),s_msg);
				tendantoc.Focus();
				return false;
			}

			if (tennuoc.SelectedIndex==-1 && tennuoc.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn quốc tịch !"),s_msg);
				tennuoc.Focus();
				return false;
			}

			if (namsinh.Text!="" && mann.Text!="")
			{
				if (!m.Kiemtra_mann(mann.Text,DateTime.Now.Year-int.Parse(namsinh.Text),iTreem6,iTreem15))
				{
					MessageBox.Show(lan.Change_language_MessageText("Nghề nghiệp và độ tuổi không hợp lệ !"),LibMedi.AccessData.Msg);
					mann.Focus();
					return false;
				}
			}
			s_mabn=mabn2.Text+mabn3.Text;
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (!kiemtra()) return;
            //// cập nhật số lưu trữ Uông Bí
            //if(soluutru.TextLength >0) upd_slt();
            //// end cập nhật số lưu trữ Uông Bí
            foreach (DataRow r in dttyle.Rows)
            { 
                if(int.Parse(r["tyle"].ToString())>100 ||int.Parse(r["tyle"].ToString())<0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Tỷ lệ không hợp lệ!"), s_msg);
                    return;
                }
            }
            int itable = m.tableid("", "btdbn");
            if (bThem)
            {
                id = m.get_id_21;
                s_sothe = m.get_mathe_uudai(iKhudt, nam.Substring(2, 2));
            }

            if (m.get_data("select * from " + m.user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + hoten.Text + "^" + ngaysinh.Text + "^" + namsinh.Text + "^" + phai.SelectedIndex.ToString() + "^" + mann.Text + "^" + madantoc.Text + "^" + sonha.Text + "^" + thon.Text + "^" + sonha.Text + "^" + matt.Text + "^" + maqu1.Text + maqu2.Text + "^" + mapxa1.Text + mapxa2.Text + "^" + i_userid.ToString() + "^" + nam);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            //if (nam.IndexOf(DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2) + "+") == -1) nam = nam + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2) + "+";
            if (!m.upd_btdbn(s_mabn, hoten.Text, ngaysinh.Text, namsinh.Text, phai.SelectedIndex, mann.Text, madantoc.Text, sonha.Text, thon.Text, cholam.Text, matt.Text, maqu1.Text + maqu2.Text, mapxa1.Text + mapxa2.Text, i_userid, nam))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"), s_msg);
                return;
            }

            if (!m.upd_btdbn_uudai(id, s_mabn, int.Parse(cmdLoaithe.SelectedValue.ToString()), tungay.Text, denngay.Text, ngaycap.Text, i_userid, s_sothe))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin thẻ ưu đãi !"), s_msg);
                return;
            }

            foreach (DataRow r in dttyle.Rows)
            {
                if (!m.upd_btdbn_uudaict(id, int.Parse(r["tyle"].ToString()), int.Parse(r["id"].ToString())))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin tỷ lệ ưu đãi !"), s_msg);
                    return;
                }
            }
            ena_but(false);
            load_grid_the();
            dataGrid1_CurrentCellChanged(null, null);
            bThem = false;
            //if (pdienthoai.Visible)
            //{
            //    if (dt_nha.Text != "" || dt_coquan.Text != "" || dt_didong.Text != "" || dt_email.Text != "")
            //        m.upd_dienthoai(s_mabn, dt_nha.Text, dt_coquan.Text, dt_didong.Text, dt_email.Text);
            //}
            ////cap nhat tuoi vao
            //decimal l_maql = m.get_maql_noitru_saucung(s_mabn);
            //if (l_maql>0)
            //{                
            //       m.f_upd_tuoivao(l_maql.ToString(), tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString());               
            //}
            //if (bVantay && m.bAdminHethong(i_userid)) luu_vantay();
            //ena_but(false);
            //if (m_mabn != "")
            //{
            //    m.close(); this.Close();
            //}
            //else butTiep.Focus();
		}

        private void upd_slt()
		{
			string sql = "update "+m.user+".lienhe set soluutru='"+soluutru.Text.ToString()+"' where lienhe.maql=(select max(maql) from "+m.user+".benhandt where mabn='"+s_mabn+"' and loaiba=1)";
            m.execute_data(sql);
		}

		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            butThem.Enabled = !ena;
            butXoa.Enabled = !ena;
            butSua.Enabled = !ena;
            tungay.Enabled = ena;
            denngay.Enabled = ena;
            ngaycap.Enabled = ena;
            cmdLoaithe.Enabled = ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			//butTiep_Click(null,null);
            ena_but(false);
            bThem = false;
            dataGrid1_CurrentCellChanged(null, null);
		}

		private void load_btdnn(int i)
		{
			if (i==0) tennn.DataSource=m.get_data("select * from "+m.user+".btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
						tennn.DataSource=m.get_data("select * from "+m.user+".btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
						tennn.DataSource=m.get_data("select * from "+m.user+".btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
					else tennn.DataSource=m.get_data("select * from "+m.user+".btdnn_bv where mannbo<>'01' order by mann").Tables[0];
				}
			}
		}

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void soluutru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) butLuu.Focus();
		}

        private void luu_vantay()
        {
            try
            {
                string asql = "delete from " + m.user + ".vantay where mabn='" + s_mabn + "'";
                m.execute_data(asql); 
                string ma = mabn2.Text + mabn3.Text;
                fnhandang.save_orac(ma);
            }
            catch { }
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            bThem = true;
            id = 0;
            tungay.Text = "";
            denngay.Text = "";
            ngaycap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ena_but(true);
            load_grid_tyle_null();
        }

        private void AddGridTableStyle()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dttyle.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;


            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = lan.Change_language_MessageText("Nhóm miễn giảm");
            TextCol.Width = 300;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tyle";
            TextCol.HeaderText = lan.Change_language_MessageText("Tỷ lệ miễn giảm");
            TextCol.Width = 50;
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);


        }

        private void AddGridTableStyle2()
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dtthe.TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;


            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            //ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 10;


            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "id";
            TextCol.HeaderText = "id";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loaithe";
            TextCol.HeaderText = lan.Change_language_MessageText("Loại thẻ");
            TextCol.Width = 130;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sothe";
            TextCol.HeaderText = lan.Change_language_MessageText("Số thẻ");
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chinhanh";
            TextCol.HeaderText = lan.Change_language_MessageText("Nơi cấp");
            TextCol.Width = 150;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngaycap";
            TextCol.HeaderText = lan.Change_language_MessageText("Ngày cấp");
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tungay";
            TextCol.HeaderText = lan.Change_language_MessageText("Từ ngày");
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "denngay";
            TextCol.HeaderText = lan.Change_language_MessageText("Đến ngày");
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void load_grid_the()
        {
            sql = "select a.id,b.ten loaithe,a.sothe,substr(lpad(sothe,10,'0'),0,2) machinhanh,c.ten chinhanh,to_char(a.ngaycap,'dd/mm/yyyy') ngaycap,to_char(a.tungay,'dd/mm/yyyy') tungay,to_char(a.denngay,'dd/mm/yyyy') denngay from " + m.user + ".btdbn_uudai a left join  " + m.user + ".dmchinhanh c on to_number(substr(lpad(sothe,10,'0'),0,2))=c.id, " + m.user + ".v_dmloaithe_uudai b where a.idthe=b.id and a.mabn='" + s_mabn + "' ";
            dtthe = m.get_data(sql).Tables[0];
           
            dataGrid1.DataSource = dtthe;
        }

        private void load_grid_tyle_null()
        {
            try
            {
                
                sql = "select a.id,a.ten,nvl(b.tyle,0) tyle from " + m.user + ".v_nhommien a left join " + m.user + ".v_dmloaithe_tyleuudai b on a.id=b.id_nhommien inner join " + m.user + ".v_dmloaithe_uudai c on b.idthe=c.id ";
                if (cmdLoaithe.SelectedIndex >= 0) sql += " where b.idthe=" + cmdLoaithe.SelectedValue.ToString();//binh 190611
                dttyle = m.get_data(sql).Tables[0];
                dataGrid2.DataSource = dttyle;
            }
            catch { }
        }

        private void load_grid_tyle()
        {
            try
            {
                sql = "select a.id,a.ten,nvl(b.tyle,0) tyle from " + m.user + ".v_nhommien a left join " + m.user + ".btdbn_uudaict b on a.id=b.id_nhommien, " + m.user + ".btdbn_uudai c where b.id=c.id and b.id="+id;
                dttyle = m.get_data(sql).Tables[0];
                dataGrid2.DataSource = dttyle;
            }
            catch { }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (!bThem)
                {
                    int i = dataGrid1.CurrentCell.RowNumber;
                    tungay.Text = dataGrid1[i, 5].ToString();
                    denngay.Text = dataGrid1[i, 6].ToString();
                    ngaycap.Text = dataGrid1[i, 4].ToString();
                    id = decimal.Parse(dataGrid1[i, 0].ToString());
                    cmdLoaithe.Text = dataGrid1[i, 1].ToString();
                    load_grid_tyle();
                }
            }
            catch { }
        }

        private void cmdLoaithe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmdLoaithe) load_grid_tyle_null();
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lan.Change_language_MessageText("Bạn muốn xóa thẻ ưu đãi?"), s_msg, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                m.execute_data("delete from " + m.user + ".btdbn_uudaict where id=" + dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
                m.execute_data("delete from " + m.user + ".btdbn_uudai where id=" + dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
                load_grid_the();
                dataGrid1_CurrentCellChanged(null, null);
                bThem = false;
            }
        }

        private void cmdLoaithe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            DataSet dstemp;
            if (dtthe.Rows.Count != 0 && id != 0)
            {
                sql = "select e.hoten,e.mabn,e.namsinh,a.id,b.ten loaithe,lpad(a.sothe,10,'0') sothe,substr(lpad(a.sothe,10,'0'),0,2) machinhanh,c.ten chinhanh,to_char(a.ngaycap,'dd/mm/yyyy') ngaycap,to_char(a.tungay,'dd/mm/yyyy') tungay, ";
                sql += " to_char(a.denngay,'dd/mm/yyyy') denngay, d.hoten nguoicap";
                sql += " from " + m.user + ".btdbn_uudai a left join " + m.user + ".dmchinhanh c on to_number(substr(lpad(sothe,10,'0'),0,2))=c.id, ";
                sql += " " + m.user + ".v_dmloaithe_uudai b," + m.user + ".dlogin d," + m.user + ".btdbn e where a.idthe=b.id and a.mabn='"+s_mabn+"' and a.userid=d.id and a.mabn=e.mabn and a.id="+id;
                dstemp = m.get_data(sql);
                dstemp.WriteXml("..\\xml\\rptTheuudai.xml");
                if (dstemp.Tables[0].Rows.Count != 0)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dstemp.Tables[0],"rptTheuudai.rpt","","","","","","","","","","",1);
                    f.ShowDialog();
                }
            }
        }
	}
}
