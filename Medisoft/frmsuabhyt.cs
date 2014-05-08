using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmsuabhyt.
	/// </summary>
	public class frmsuabhyt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m=new LibMedi.AccessData ();
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
        decimal l_maql = 0, maql_phongluu = 0, l_idkhoa=0;
        private int i_maxlength_mabn = 8;
        private bool bKhoa_suadoituong = false, bThanhtoan_khoa = false, bVienphi_phongluu = false, bHansd_thuoc = true, bSothe_mabn=false;
        private int i_userid, i_madoituong = 0, _dai = 18, _vitri = 14, i_loaiba = 1, i_traituyen = 0;
        private string sql, s_mabn = "", nam, user, xxx, _sothe = "08001", stime = "dd/mm/yyyy", s_chenhlech = "", gia, giavt;
		private DataTable dtbv;
        private DataTable dtgia = new DataTable();
        private DataSet ds;
        private decimal d_dongia, d_vattu;
        private bool bFound = false, bTinhchenhlech, bChenhlech_doituong, bChidinh_thutienlien;
        private bool bSuadt_auto_dichvu = false, bnKhamBHYTmotlantrongngay = false;
		//
		private MaskedTextBox.MaskedTextBox mabv;
		private MaskedBox.MaskedBox denngay;
		private MaskedTextBox.MaskedTextBox sothe;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.TextBox hoten;
		private MaskedTextBox.MaskedTextBox mabn3;
		private MaskedTextBox.MaskedTextBox mabn2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butLuu;
		private LibList.List list;
		private DataSet lds=new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dtdt = new DataTable();
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox madoituong;
        private Label label5;
        private ComboBox thongtin;
        private bool bPhonggiuong, bChenhlech, bTraituyen, bDuyet_congdondoituong=false;
        private MaskedBox.MaskedBox tungay;
        private Label label7;
        private MaskedBox.MaskedBox tungay1;
        private Label label9;
        private MaskedTextBox.MaskedTextBox mabv1;
        private Label label10;
        private MaskedBox.MaskedBox denngay1;
        private MaskedTextBox.MaskedTextBox sothe1;
        private Label label11;
        private Label label12;
        private TextBox tenbv1;
        private Label label13;
        private bool bSothe_ngay_huong;
        private ToolTip toolTip1;
        private MaskedBox.MaskedBox ngay3;
        private MaskedBox.MaskedBox ngay2;
        private MaskedBox.MaskedBox ngay1;
        private MaskedBox.MaskedBox ngay31;
        private MaskedBox.MaskedBox ngay21;
        private MaskedBox.MaskedBox ngay11;
        private IContainer components;
        private CheckBox sudung;
        private CheckBox sudung1;
        private Label label14;
        private MaskedBox.MaskedBox ngaytrinh;
        private MaskedBox.MaskedBox ngayduyet;
        private Label label15;
        private MaskedBox.MaskedBox ngaygiahan;
        private Label label16;
        private MaskedBox.MaskedBox ngaygiahan1;
        private Label label17;
        private MaskedBox.MaskedBox ngayduyet1;
        private Label label18;
        private MaskedBox.MaskedBox ngaytrinh1;
        private Label label19;
        private bool bAdmin,bSothe_dkkcb;
        private ComboBox traituyen;
        private ComboBox traituyen1;

		public frmsuabhyt(int userid,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            i_userid = userid;bAdmin=admin;
            if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public frmsuabhyt(string mabn)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			s_mabn=mabn;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsuabhyt));
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.list = new LibList.List();
            this.label8 = new System.Windows.Forms.Label();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.thongtin = new System.Windows.Forms.ComboBox();
            this.tungay = new MaskedBox.MaskedBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tungay1 = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mabv1 = new MaskedTextBox.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.denngay1 = new MaskedBox.MaskedBox();
            this.sothe1 = new MaskedTextBox.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tenbv1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ngay3 = new MaskedBox.MaskedBox();
            this.ngay2 = new MaskedBox.MaskedBox();
            this.ngay1 = new MaskedBox.MaskedBox();
            this.ngay31 = new MaskedBox.MaskedBox();
            this.ngay21 = new MaskedBox.MaskedBox();
            this.ngay11 = new MaskedBox.MaskedBox();
            this.sudung = new System.Windows.Forms.CheckBox();
            this.sudung1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ngaytrinh = new MaskedBox.MaskedBox();
            this.ngayduyet = new MaskedBox.MaskedBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ngaygiahan = new MaskedBox.MaskedBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ngaygiahan1 = new MaskedBox.MaskedBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ngayduyet1 = new MaskedBox.MaskedBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ngaytrinh1 = new MaskedBox.MaskedBox();
            this.label19 = new System.Windows.Forms.Label();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.traituyen1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(79, 123);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(60, 21);
            this.mabv.TabIndex = 23;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            this.mabv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(175, 100);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(64, 21);
            this.denngay.TabIndex = 18;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            this.denngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(78, 77);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(357, 21);
            this.sothe.TabIndex = 14;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(140, 100);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 23);
            this.label25.TabIndex = 17;
            this.label25.Text = "Đến :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(17, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 23);
            this.label24.TabIndex = 13;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(140, 123);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(231, 21);
            this.tenbv.TabIndex = 24;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(78, 31);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(200, 21);
            this.hoten.TabIndex = 6;
            // 
            // mabn3
            // 
            this.mabn3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(368, 8);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(68, 21);
            this.mabn3.TabIndex = 4;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            this.mabn3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(343, 8);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(22, 21);
            this.mabn2.TabIndex = 3;
            this.mabn2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(35, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(277, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(342, 31);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(94, 21);
            this.namsinh.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(278, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(221, 339);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 52;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(149, 339);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 51;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(332, 200);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 56;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(1, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "ĐKKCB :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Location = new System.Drawing.Point(78, 54);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(200, 21);
            this.ngayvao.TabIndex = 10;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày vào :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(279, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đối tượng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Location = new System.Drawing.Point(342, 54);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(94, 21);
            this.madoituong.TabIndex = 12;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thông tin :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thongtin
            // 
            this.thongtin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thongtin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongtin.FormattingEnabled = true;
            this.thongtin.Items.AddRange(new object[] {
            "Đăng ký khám bệnh",
            "Khám bệnh",
            "Điều trị ngoại trú",
            "Phòng lưu",
            "Điều trị nội trú"});
            this.thongtin.Location = new System.Drawing.Point(78, 8);
            this.thongtin.Name = "thongtin";
            this.thongtin.Size = new System.Drawing.Size(200, 21);
            this.thongtin.TabIndex = 1;
            this.thongtin.SelectedIndexChanged += new System.EventHandler(this.thongtin_SelectedIndexChanged);
            this.thongtin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thongtin_KeyDown);
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(79, 100);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(64, 21);
            this.tungay.TabIndex = 16;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(14, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Từ ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tungay1
            // 
            this.tungay1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay1.Location = new System.Drawing.Point(79, 242);
            this.tungay1.Mask = "##/##/####";
            this.tungay1.Name = "tungay1";
            this.tungay1.Size = new System.Drawing.Size(64, 21);
            this.tungay1.TabIndex = 35;
            this.tungay1.Text = "  /  /    ";
            this.tungay1.Validated += new System.EventHandler(this.tungay1_Validated);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(15, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 34;
            this.label9.Text = "Từ ngày :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabv1
            // 
            this.mabv1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv1.Location = new System.Drawing.Point(79, 265);
            this.mabv1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabv1.Name = "mabv1";
            this.mabv1.Size = new System.Drawing.Size(59, 21);
            this.mabv1.TabIndex = 42;
            this.mabv1.Validated += new System.EventHandler(this.mabv1_Validated);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(2, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "ĐKKCB :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // denngay1
            // 
            this.denngay1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay1.Location = new System.Drawing.Point(175, 242);
            this.denngay1.Mask = "##/##/####";
            this.denngay1.Name = "denngay1";
            this.denngay1.Size = new System.Drawing.Size(64, 21);
            this.denngay1.TabIndex = 37;
            this.denngay1.Text = "  /  /    ";
            this.denngay1.Validated += new System.EventHandler(this.denngay1_Validated);
            // 
            // sothe1
            // 
            this.sothe1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe1.Location = new System.Drawing.Point(79, 219);
            this.sothe1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe1.MaxLength = 20;
            this.sothe1.Name = "sothe1";
            this.sothe1.Size = new System.Drawing.Size(357, 21);
            this.sothe1.TabIndex = 33;
            this.sothe1.Validated += new System.EventHandler(this.sothe1_Validated);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(112, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 36;
            this.label11.Text = "Đến :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(18, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 32;
            this.label12.Text = "Số thẻ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbv1
            // 
            this.tenbv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv1.Location = new System.Drawing.Point(140, 265);
            this.tenbv1.Name = "tenbv1";
            this.tenbv1.Size = new System.Drawing.Size(231, 21);
            this.tenbv1.TabIndex = 43;
            this.tenbv1.TextChanged += new System.EventHandler(this.tenbv1_TextChanged);
            this.tenbv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(15, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "Thêm số thẻ mới";
            // 
            // ngay3
            // 
            this.ngay3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngay3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay3.Location = new System.Drawing.Point(371, 100);
            this.ngay3.Mask = "##/##/####";
            this.ngay3.Name = "ngay3";
            this.ngay3.Size = new System.Drawing.Size(64, 21);
            this.ngay3.TabIndex = 21;
            this.ngay3.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay3, "Ngày hưởng thêm các thuốc điều trị ung thư, thuốc chống thải ghép ngoài danh mục");
            this.ngay3.Validated += new System.EventHandler(this.ngay3_Validated);
            // 
            // ngay2
            // 
            this.ngay2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay2.Location = new System.Drawing.Point(306, 100);
            this.ngay2.Mask = "##/##/####";
            this.ngay2.Name = "ngay2";
            this.ngay2.Size = new System.Drawing.Size(64, 21);
            this.ngay2.TabIndex = 20;
            this.ngay2.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay2, "Ngày hưởng thêm quyền lợi chăm sóc thai sản, sinh đẻ");
            this.ngay2.Validated += new System.EventHandler(this.ngay2_Validated);
            // 
            // ngay1
            // 
            this.ngay1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay1.Location = new System.Drawing.Point(240, 100);
            this.ngay1.Mask = "##/##/####";
            this.ngay1.Name = "ngay1";
            this.ngay1.Size = new System.Drawing.Size(64, 21);
            this.ngay1.TabIndex = 19;
            this.ngay1.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay1, "Ngày hưởng dịch vụ kỹ thuật cao, chi phí lớn");
            this.ngay1.Validated += new System.EventHandler(this.ngay1_Validated);
            // 
            // ngay31
            // 
            this.ngay31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngay31.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay31.Location = new System.Drawing.Point(372, 242);
            this.ngay31.Mask = "##/##/####";
            this.ngay31.Name = "ngay31";
            this.ngay31.Size = new System.Drawing.Size(64, 21);
            this.ngay31.TabIndex = 40;
            this.ngay31.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay31, "Ngày hưởng thêm các thuốc điều trị ung thư, thuốc chống thải ghép ngoài danh mục");
            this.ngay31.Validated += new System.EventHandler(this.ngay31_Validated);
            // 
            // ngay21
            // 
            this.ngay21.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay21.Location = new System.Drawing.Point(307, 242);
            this.ngay21.Mask = "##/##/####";
            this.ngay21.Name = "ngay21";
            this.ngay21.Size = new System.Drawing.Size(64, 21);
            this.ngay21.TabIndex = 39;
            this.ngay21.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay21, "Ngày hưởng thêm quyền lợi chăm sóc thai sản, sinh đẻ");
            this.ngay21.Validated += new System.EventHandler(this.ngay21_Validated);
            // 
            // ngay11
            // 
            this.ngay11.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay11.Location = new System.Drawing.Point(241, 242);
            this.ngay11.Mask = "##/##/####";
            this.ngay11.Name = "ngay11";
            this.ngay11.Size = new System.Drawing.Size(64, 21);
            this.ngay11.TabIndex = 38;
            this.ngay11.Text = "  /  /    ";
            this.toolTip1.SetToolTip(this.ngay11, "Ngày hưởng dịch vụ kỹ thuật cao, chi phí lớn");
            this.ngay11.Validated += new System.EventHandler(this.ngay11_Validated);
            // 
            // sudung
            // 
            this.sudung.AutoSize = true;
            this.sudung.Location = new System.Drawing.Point(78, 170);
            this.sudung.Name = "sudung";
            this.sudung.Size = new System.Drawing.Size(93, 17);
            this.sudung.TabIndex = 53;
            this.sudung.Text = "Đang sử dụng";
            this.sudung.UseVisualStyleBackColor = true;
            this.sudung.CheckedChanged += new System.EventHandler(this.sudung_CheckedChanged);
            this.sudung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // sudung1
            // 
            this.sudung1.AutoSize = true;
            this.sudung1.Location = new System.Drawing.Point(79, 313);
            this.sudung1.Name = "sudung1";
            this.sudung1.Size = new System.Drawing.Size(93, 17);
            this.sudung1.TabIndex = 54;
            this.sudung1.Text = "Đang sử dụng";
            this.sudung1.UseVisualStyleBackColor = true;
            this.sudung1.CheckedChanged += new System.EventHandler(this.sudung1_CheckedChanged);
            this.sudung1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(17, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "Ngày trình :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaytrinh
            // 
            this.ngaytrinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaytrinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaytrinh.Location = new System.Drawing.Point(79, 146);
            this.ngaytrinh.Mask = "##/##/####";
            this.ngaytrinh.Name = "ngaytrinh";
            this.ngaytrinh.Size = new System.Drawing.Size(64, 21);
            this.ngaytrinh.TabIndex = 27;
            this.ngaytrinh.Text = "  /  /    ";
            this.ngaytrinh.Validated += new System.EventHandler(this.ngaytrinh_Validated);
            // 
            // ngayduyet
            // 
            this.ngayduyet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayduyet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayduyet.Location = new System.Drawing.Point(204, 146);
            this.ngayduyet.Mask = "##/##/#### ##:##";
            this.ngayduyet.Name = "ngayduyet";
            this.ngayduyet.Size = new System.Drawing.Size(100, 21);
            this.ngayduyet.TabIndex = 29;
            this.ngayduyet.Text = "  /  /       :  ";
            this.ngayduyet.Validated += new System.EventHandler(this.ngayduyet_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(132, 146);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 23);
            this.label15.TabIndex = 28;
            this.label15.Text = "Ngày duyệt :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaygiahan
            // 
            this.ngaygiahan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaygiahan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaygiahan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaygiahan.Location = new System.Drawing.Point(372, 146);
            this.ngaygiahan.Mask = "##/##/####";
            this.ngaygiahan.Name = "ngaygiahan";
            this.ngaygiahan.Size = new System.Drawing.Size(64, 21);
            this.ngaygiahan.TabIndex = 31;
            this.ngaygiahan.Text = "  /  /    ";
            this.ngaygiahan.Validated += new System.EventHandler(this.ngaygiahan_Validated);
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(291, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 23);
            this.label16.TabIndex = 30;
            this.label16.Text = "Ngày gia hạn :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaygiahan1
            // 
            this.ngaygiahan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaygiahan1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaygiahan1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaygiahan1.Location = new System.Drawing.Point(372, 288);
            this.ngaygiahan1.Mask = "##/##/####";
            this.ngaygiahan1.Name = "ngaygiahan1";
            this.ngaygiahan1.Size = new System.Drawing.Size(64, 21);
            this.ngaygiahan1.TabIndex = 50;
            this.ngaygiahan1.Text = "  /  /    ";
            this.ngaygiahan1.Validated += new System.EventHandler(this.ngaygiahan1_Validated);
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(291, 288);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 23);
            this.label17.TabIndex = 49;
            this.label17.Text = "Ngày gia hạn :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayduyet1
            // 
            this.ngayduyet1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayduyet1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayduyet1.Location = new System.Drawing.Point(204, 288);
            this.ngayduyet1.Mask = "##/##/####";
            this.ngayduyet1.Name = "ngayduyet1";
            this.ngayduyet1.Size = new System.Drawing.Size(100, 21);
            this.ngayduyet1.TabIndex = 48;
            this.ngayduyet1.Text = "  /  /    ";
            this.ngayduyet1.Validated += new System.EventHandler(this.ngayduyet1_Validated);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(133, 288);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 23);
            this.label18.TabIndex = 47;
            this.label18.Text = "Ngày duyệt :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaytrinh1
            // 
            this.ngaytrinh1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaytrinh1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaytrinh1.Location = new System.Drawing.Point(79, 288);
            this.ngaytrinh1.Mask = "##/##/####";
            this.ngaytrinh1.Name = "ngaytrinh1";
            this.ngaytrinh1.Size = new System.Drawing.Size(64, 21);
            this.ngaytrinh1.TabIndex = 46;
            this.ngaytrinh1.Text = "  /  /    ";
            this.ngaytrinh1.Validated += new System.EventHandler(this.ngaytrinh1_Validated);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(17, 288);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 45;
            this.label19.Text = "Ngày trình :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // traituyen
            // 
            this.traituyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.traituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.traituyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traituyen.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.traituyen.Location = new System.Drawing.Point(372, 123);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(64, 21);
            this.traituyen.TabIndex = 25;
            this.traituyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // traituyen1
            // 
            this.traituyen1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.traituyen1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.traituyen1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.traituyen1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traituyen1.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.traituyen1.Location = new System.Drawing.Point(372, 265);
            this.traituyen1.Name = "traituyen1";
            this.traituyen1.Size = new System.Drawing.Size(64, 21);
            this.traituyen1.TabIndex = 44;
            this.traituyen1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn2_KeyDown);
            // 
            // frmsuabhyt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(440, 378);
            this.Controls.Add(this.ngaytrinh1);
            this.Controls.Add(this.ngayduyet1);
            this.Controls.Add(this.ngaytrinh);
            this.Controls.Add(this.ngayduyet);
            this.Controls.Add(this.traituyen1);
            this.Controls.Add(this.traituyen);
            this.Controls.Add(this.ngaygiahan1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ngaygiahan);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.sudung1);
            this.Controls.Add(this.sudung);
            this.Controls.Add(this.ngay31);
            this.Controls.Add(this.ngay21);
            this.Controls.Add(this.ngay11);
            this.Controls.Add(this.tenbv1);
            this.Controls.Add(this.ngay3);
            this.Controls.Add(this.ngay2);
            this.Controls.Add(this.ngay1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tungay1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mabv1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.denngay1);
            this.Controls.Add(this.sothe1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.thongtin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.list);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tenbv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmsuabhyt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa đối tượng";
            this.Load += new System.EventHandler(this.frmsuabhyt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private bool load_mabn()
		{
			bool ret=false;
			s_mabn=mabn2.Text+mabn3.Text.PadLeft(6,'0');
            i_madoituong = 0;
			foreach(DataRow r in m.get_data("select * from "+user+".btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
				nam=r["nam"].ToString().Trim();
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();				
				break;
			}						
			return ret;
		}
		private void Load_BHYT()
		{
            sothe.Text = ""; mabv.Text = ""; tenbv.Text = ""; denngay.Text = ""; tungay.Text = "";
            sothe1.Text = ""; mabv1.Text = ""; tenbv1.Text = ""; denngay1.Text = ""; tungay1.Text = "";
            ngay1.Text = ngay2.Text = ngay3.Text = ngay11.Text = ngay21.Text = ngay31.Text = "";
            ngaytrinh.Text = ngayduyet.Text = ngaygiahan.Text = ngaytrinh1.Text = ngayduyet1.Text = ngaygiahan1.Text = "";
            if (ngayvao.SelectedIndex != -1)
            {
                string ngay = lds.Tables[0].Rows[ngayvao.SelectedIndex]["ngayv"].ToString();
                xxx = user + m.mmyy(ngay);
                if (thongtin.SelectedIndex == 2 || thongtin.SelectedIndex == 4) sql = "select * from " + user + ".bhyt where maql=" + l_maql+" order by tungay,denngay";
                else sql = "select * from " + xxx + ".bhyt where maql=" + l_maql;
                DataTable tmp=m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    sothe.Text = tmp.Rows[0]["sothe"].ToString();
                    if (tmp.Rows[0]["tungay"].ToString() != "")
                        tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["tungay"].ToString()));
                    if (tmp.Rows[0]["denngay"].ToString() != "")
                        denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["denngay"].ToString()));
                    mabv.Text = tmp.Rows[0]["mabv"].ToString();
                    sudung.Checked = tmp.Rows[0]["sudung"].ToString() == "1";
                    if (bSothe_ngay_huong)
                    {
                        if (tmp.Rows[0]["ngay1"].ToString() != "")
                            ngay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngay1"].ToString()));
                        if (tmp.Rows[0]["ngay2"].ToString() != "")
                            ngay2.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngay2"].ToString()));
                        if (tmp.Rows[0]["ngay3"].ToString() != "")
                            ngay3.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngay3"].ToString()));
                    }
                    if (bTraituyen) traituyen.SelectedIndex = int.Parse(tmp.Rows[0]["traituyen"].ToString());
                    if (ngaytrinh.Enabled)
                    {
                        try
                        {
                            if (tmp.Rows[0]["ngaytrinh"].ToString() != "")
                                ngaytrinh.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngaytrinh"].ToString()));
                            if (tmp.Rows[0]["ngayduyet"].ToString() != "")
                                ngayduyet.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngayduyet"].ToString()));
                            if (tmp.Rows[0]["ngaygiahan"].ToString() != "")
                                ngaygiahan.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngaygiahan"].ToString()));
                        }
                        catch { }
                    }
                    try
                    {
                        tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                    catch { }
                }
                else
                {
                    sudung.Checked = true;
                }
                if (tmp.Rows.Count > 1)
                {
                    sothe1.Text = tmp.Rows[1]["sothe"].ToString();
                    if (tmp.Rows[1]["tungay"].ToString() != "")
                        tungay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[1]["tungay"].ToString()));
                    if (tmp.Rows[1]["denngay"].ToString() != "")
                        denngay1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[1]["denngay"].ToString()));
                    sudung1.Checked=tmp.Rows[1]["sudung"].ToString()=="1";
                    if (bSothe_ngay_huong)
                    {
                        if (tmp.Rows[1]["ngay1"].ToString() != "")
                            ngay11.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[1]["ngay1"].ToString()));
                        if (tmp.Rows[1]["ngay2"].ToString() != "")
                            ngay21.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[1]["ngay2"].ToString()));
                        if (tmp.Rows[1]["ngay3"].ToString() != "")
                            ngay31.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[1]["ngay3"].ToString()));
                    }
                    if (bTraituyen) traituyen1.SelectedIndex = int.Parse(tmp.Rows[1]["traituyen"].ToString());
                    if (ngaytrinh1.Enabled)
                    {
                        try
                        {
                            if (tmp.Rows[0]["ngaytrinh1"].ToString() != "")
                                ngaytrinh1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngaytrinh1"].ToString()));
                            if (tmp.Rows[0]["ngayduyet1"].ToString() != "")
                                ngayduyet1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngayduyet1"].ToString()));
                            if (tmp.Rows[0]["ngaygiahan1"].ToString() != "")
                                ngaygiahan1.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(tmp.Rows[0]["ngaygiahan1"].ToString()));
                        }
                        catch{}
                    }
                    mabv1.Text = tmp.Rows[1]["mabv"].ToString();
                    try
                    {
                        tenbv1.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv1.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                    catch { }
                }
                else if (tmp.Rows.Count == 1)
                {
                    sudung1.Checked = true;
                }
            }
		}

		private void tenbv_TextChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == tenbv)
            {
                Filt_noicap(tenbv.Text);
                if (traituyen.Enabled) list.BrowseToText(tenbv, mabv, traituyen, mabv.Location.X, mabv.Location.Y + mabv.Height, mabv.Width + tenbv.Width + 2, mabv.Height);  
                if (ngaytrinh.Enabled) list.BrowseToText(tenbv, mabv, ngaytrinh, mabv.Location.X, mabv.Location.Y + mabv.Height, mabv.Width + tenbv.Width + 2, mabv.Height);  
                else list.BrowseToText(tenbv, mabv, sothe1, mabv.Location.X, mabv.Location.Y + mabv.Height, mabv.Width + tenbv.Width + 2, mabv.Height);
            }			
		}
		private void Filt_noicap(string ten)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
		}
		private void load_dm()
		{			
			list.DisplayMember="MABV";
			list.ValueMember="TENBV";
			dtbv=m.get_data("select MABV,TENBV,DIACHI from "+user+".dmnoicapbhyt order by mabv").Tables[0].Copy();
			list.DataSource=dtbv; 
		}

		private void mabn2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible)
				{
					list.Focus();
					SendKeys.Send("{Down}");
				}
				else SendKeys.Send("{Tab}");
			}
		}
		private void denngay_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!m.bNgay(denngay.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					denngay.Focus();
					return;
				}
				denngay.Text=m.Ktngaygio(denngay.Text,10);
                string s_ngay = (tungay.Text != "") ? tungay.Text : ngayvao.Text.Substring(0, 10);
				if (!m.bNgay(denngay.Text,s_ngay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không hợp lệ !"),lan.Change_language_MessageText("BHYT"));
					denngay.Focus();
					return;
				}
				SendKeys.Send("{Home}");
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if(kiemtra())
			{
                butLuu.Enabled = false;
                int itableid;
				s_mabn=mabn2.Text+mabn3.Text;
				string ngay=lds.Tables[0].Rows[ngayvao.SelectedIndex]["ngayv"].ToString();
				xxx=user+m.mmyy(ngay);
                int i_loai= thongtin.SelectedIndex;
                switch (thongtin.SelectedIndex)
                {
                    case 0: sql = "update " + xxx + ".tiepdon set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where maql=" + l_maql;
                            itableid = m.tableid(m.mmyy(ngay), "tiepdon");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "upd", m.fields(xxx + ".tiepdon", "maql=" + l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid, "upd");                            
                            if (sothe.Enabled && sothe.Text != "")
                            {
                                itableid = m.tableid(m.mmyy(ngay), "bhyt");
                                m.upd_eve_upd_del(ngay, itableid, i_userid, "upd", m.fields(xxx + ".bhyt", "maql=" + l_maql));
                                m.upd_eve_tables(ngay, itableid, i_userid, "upd");
                                m.upd_bhyt(ngay, s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text,0,tungay.Text,ngay1.Text,ngay2.Text,ngay3.Text,traituyen.SelectedIndex);
                            }
                            break;
                    case 1: sql = "update " + xxx + ".benhanpk set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where maql=" + l_maql;
                            itableid = m.tableid(m.mmyy(ngay), "benhanpk");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "upd", m.fields(xxx + ".benhanpk", "maql=" + l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid, "upd");
                            if (sothe.Enabled && sothe.Text != "")
                            {
                                itableid = m.tableid(m.mmyy(ngay), "bhyt");
                                m.upd_eve_upd_del(ngay, itableid, i_userid, "upd", m.fields(xxx + ".bhyt", "maql=" + l_maql));
                                m.upd_eve_tables(ngay, itableid, i_userid, "upd");
                                m.upd_bhyt(ngay, s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text,0,tungay.Text,ngay1.Text,ngay2.Text,ngay3.Text,traituyen.SelectedIndex);
                            }
                            m.execute_data("update " + xxx + ".bhytkb set sothe='" + sothe.Text + "',mabv='" + mabv.Text + "' where maql=" + l_maql);
                            break;
                   case 2: sql = "update " + user + ".benhanngtr set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where maql=" + l_maql;
                            itableid = m.tableid("", "benhanngtr");
                            m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(user + ".benhanngtr", "maql=" + l_maql));
                            m.upd_eve_tables(itableid, i_userid, "upd");
                            m.execute_data("delete from " + user + ".bhyt where maql=" + l_maql);
                            if (sothe.Enabled && sothe.Text != "")
                            {
                                itableid = m.tableid("", "bhyt");
                                m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(user + ".bhyt", "maql=" + l_maql+" and sothe='"+sothe.Text+"'"));
                                m.upd_eve_tables(itableid, i_userid, "upd");
                                m.upd_bhyt(s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text,ngay1.Text,ngay2.Text,ngay3.Text,ngaytrinh.Text,ngayduyet.Text,ngaygiahan.Text,traituyen.SelectedIndex);
                                m.execute_data("update "+user+".bhyt set sudung="+((sudung.Checked)?1:0)+" where maql="+l_maql+" and sothe='"+sothe.Text+"'");
                            }
                            if (sothe1.Enabled && sothe1.Text.Trim() != "")
                            {
                                itableid = m.tableid("", "bhyt");
                                m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(user + ".bhyt", "maql=" + l_maql+" and sothe='"+sothe1.Text+"'"));
                                m.upd_eve_tables(itableid, i_userid, "upd");
                                m.upd_bhyt(s_mabn, l_maql, sothe1.Text, denngay1.Text, mabv1.Text, 0, tungay1.Text,ngay11.Text,ngay21.Text,ngay31.Text,ngaytrinh1.Text,ngayduyet1.Text,ngaygiahan1.Text,traituyen1.SelectedIndex);
                                m.execute_data("update "+user+".bhyt set sudung="+((sudung1.Checked)?1:0)+" where maql="+l_maql+" and sothe='"+sothe1.Text+"'");
                            }
                            break;
                    case 3: sql = "update " + xxx + ".benhancc set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where maql=" + l_maql;
                            itableid = m.tableid(m.mmyy(ngay), "benhancc");
                            m.upd_eve_upd_del(ngay, itableid, i_userid, "upd", m.fields(xxx + ".benhancc", "maql=" + l_maql));
                            m.upd_eve_tables(ngay, itableid, i_userid, "upd");
                            if (sothe.Enabled && sothe.Text != "")
                            {
                                itableid = m.tableid(m.mmyy(ngay), "bhyt");
                                m.upd_eve_upd_del(ngay, itableid, i_userid, "upd", m.fields(xxx + ".bhyt", "maql=" + l_maql));
                                m.upd_eve_tables(ngay, itableid, i_userid, "upd");
                                m.upd_bhyt(ngay, s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text,0,tungay.Text,ngay1.Text,ngay2.Text,ngay3.Text,traituyen.SelectedIndex);
                                m.execute_data("update "+xxx+".bhyt set sudung="+((sudung.Checked)?1:0)+" where maql="+l_maql+" and sothe='"+sothe.Text+"'");
                            }
                            if (sothe1.Enabled && sothe1.Text.Trim() != "")
                            {
                                itableid = m.tableid("", "bhyt");
                                m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(xxx + ".bhyt", "maql=" + l_maql + " and sothe='" + sothe1.Text + "'"));
                                m.upd_eve_tables(itableid, i_userid, "upd");
                                m.upd_bhyt(ngay,s_mabn, l_maql, sothe1.Text, denngay1.Text, mabv1.Text, 0, tungay1.Text,ngay11.Text,ngay21.Text,ngay31.Text,traituyen1.SelectedIndex);
                                m.execute_data("update "+xxx+".bhyt set sudung="+((sudung1.Checked)?1:0)+" where maql="+l_maql+" and sothe='"+sothe1.Text+"'");
                            }
                            break;
                    case 4: sql = "update " + user + ".benhandt set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where maql=" + l_maql;
                            itableid = m.tableid("", "benhandt");
                            m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(user + ".benhandt", "maql=" + l_maql));
                            m.upd_eve_tables(itableid, i_userid, "upd");
                            m.execute_data("delete from " + user + ".bhyt where maql=" + l_maql);
                            if (sothe.Enabled && sothe.Text != "")
                            {
                                itableid = m.tableid("", "bhyt");
                                m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(user + ".bhyt", "maql=" + l_maql));
                                m.upd_eve_tables(itableid, i_userid, "upd");
                                m.upd_bhyt(s_mabn, l_maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text,ngay1.Text,ngay2.Text,ngay3.Text,ngaytrinh.Text,ngayduyet.Text,ngaygiahan.Text,traituyen.SelectedIndex);
                                m.execute_data("update "+user+".bhyt set sudung="+((sudung.Checked)?1:0)+" where maql="+l_maql+" and sothe='"+sothe.Text+"'");
                            }
                            if (sothe1.Enabled && sothe1.Text.Trim() != "")
                            {
                                itableid = m.tableid("", "bhyt");
                                m.upd_eve_upd_del(itableid, i_userid, "upd", m.fields(user + ".bhyt", "maql=" + l_maql + " and sothe='" + sothe1.Text + "'"));
                                m.upd_eve_tables(itableid, i_userid, "upd");
                                m.upd_bhyt(s_mabn, l_maql, sothe1.Text, denngay1.Text, mabv1.Text, 0, tungay1.Text,ngay11.Text,ngay21.Text,ngay31.Text,ngaytrinh1.Text,ngayduyet1.Text,ngaygiahan1.Text,traituyen1.SelectedIndex);
                                m.execute_data("update "+user+".bhyt set sudung="+((sudung1.Checked)?1:0)+" where maql="+l_maql+" and sothe='"+sothe1.Text+"'");
                            }
                            break;
                }
				m.execute_data(sql);
                if ((thongtin.SelectedIndex == 3 || thongtin.SelectedIndex == 4) && bPhonggiuong && i_madoituong!=int.Parse(madoituong.SelectedValue.ToString()))
                {
                    string s_ngay = m.ngayhienhanh_server, fie = "gia_th";
                    if (ngayduyet.Text != "") s_ngay = ngayduyet.Text;
                    if (sothe1.Text!="" && ngayduyet1.Text!="") s_ngay = ngayduyet1.Text;
                    decimal songay = 0,l_idkhoa=0,l_mavaovien=0,l_id=0;
                    int _madoituong;
                    bool Khoakb=false;
                    bool bPhongluuc = m.get_phongluu_nhapkhoa(l_maql);
                    DataRow r2, r3;
                    int itable = m.tableid("", "theodoigiuong");
                    sql = "select id,mabn,idkhoa,mavaovien,makp,to_char(tu,'dd/mm/yyyy hh24:mi') as tu,dongia,idgiuong,madoituong ";
                    sql+=" from " + user + ".theodoigiuong where maql=" + l_maql + " and den is null";
                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    {
                        l_id = decimal.Parse(r1["id"].ToString());
                        l_idkhoa = decimal.Parse(r1["idkhoa"].ToString());
                        l_mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                        if (!bPhongluuc) Khoakb = m.get_data("select * from " + user + ".nhapkhoa where khoachuyen='01' and id=" + l_idkhoa).Tables[0].Rows.Count > 0;
                        songay = Math.Max(0, m.songay(m.StringToDateTime(s_ngay), m.StringToDateTime(r1["tu"].ToString()),(Khoakb) ? 1 : 0));                        
                        m.upd_theodoigiuong(decimal.Parse(r1["id"].ToString()), s_ngay, int.Parse(r1["madoituong"].ToString()), songay);
                        songay = Math.Max(0, songay - 1);//
                        if (songay>0) v.upd_vpkhoa(l_id, r1["mabn"].ToString(), l_mavaovien, l_maql, l_idkhoa, s_ngay, r1["makp"].ToString(), int.Parse(r1["madoituong"].ToString()), int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), decimal.Parse(r1["dongia"].ToString()), 0, i_userid, 0);                        r3 = m.getrowbyid(dt, "id=" + int.Parse(r1["idgiuong"].ToString()));
                        l_id = v.get_id_vpkhoa;
                        if (r3 != null)
                        {
                            _madoituong = int.Parse(madoituong.SelectedValue.ToString());
                            if (_madoituong == 1 && r3["chenhlech"].ToString() == "1" && bChenhlech && r3["bhyt"].ToString() != "0") _madoituong = m.iTunguyen;
                            r2 = m.getrowbyid(dtdt, "madoituong=" + _madoituong);
                            if (r2 != null) fie = r2["field_gia"].ToString().Trim();
                            decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
                            int idgiuong = int.Parse(r3["id"].ToString());
                            m.upd_theodoigiuong(l_id, r1["makp"].ToString(), r1["mabn"].ToString(), l_mavaovien, l_maql, l_idkhoa, _madoituong, int.Parse(r3["id"].ToString()), s_ngay, decimal.Parse(r3[fie].ToString()) * tygia, i_userid);
                            m.execute_data("update " + user + ".hiendien set idgiuong=" + idgiuong + " where id=" + l_idkhoa);
                            m.upd_eve_tables(itable, i_userid, "ins");
                            m.upd_eve_upd_del(itable, i_userid, "ins", m.fields(user + ".theodoigiuong", "id=" + l_id));
                            m.execute_data("update " + user + ".nhapkhoa set giuong='" + r3["ma"].ToString() + "' where id=" + l_idkhoa);
                        }
                        break;
                    }
                }
                //
                if (bSuadt_auto_dichvu)
                {
                    Cursor = Cursors.WaitCursor;
                    if (i_loai == 3 || i_loai == 2 || i_loai == 4)//2: ngoai tru, 3: cap cuu, 4: noi tru
                    {
                        //thuoc
                        m.execute_data("delete from " + m.user + ".d_suamadt where mabn='" + s_mabn + "'");
                        load_thuoc();
                        ds = m.get_data("select * from " + m.user + ".d_suamadt order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
                        rep_madoituong(0);
                        m.upd_dasuamadt(l_maql, 0);
                        //
                        d.execute_data("delete from " + m.user + ".d_suamadt where mabn='" + s_mabn + "'");
                        load_tamung();
                        ds = d.get_data("select * from " + m.user + ".d_suamadt order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");//Tu: 11/08/2011
                        ref_moidoituong_tamung();
                    }
                    //vienphi						
                    m.execute_data("delete from " + m.user + ".d_suamadt where mabn='" + s_mabn + "'");
                    load_vienphi();
                    ds = m.get_data("select * from " + m.user + ".d_suamadt order by substr(ngay,7,4),substr(ngay,4,2),substr(ngay,1,2),ten");
                    rep_madoituong(1);
                    Cursor = Cursors.Default;
                }
                i_madoituong = int.Parse(madoituong.SelectedValue.ToString());
                MessageBox.Show(lan.Change_language_MessageText("Đã xong"));
                butLuu.Enabled = true;
				mabn2.Focus();
			}
		}
        private void f_load_option()
        {
         bnKhamBHYTmotlantrongngay = m.bnKhamBHYTmotlantrongngay;// E34
        }
        
		private bool kiemtra()
		{
			if (mabn2.Text=="" || mabn3.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),lan.Change_language_MessageText("BHYT"));
				mabn2.Focus();
				return false;
			}
            if (sothe.Enabled)                
            {
                if (sothe.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập số thẻ !"), LibMedi.AccessData.Msg);
                    sothe.Focus();
                    return false;
                }
                else if (sothe.Text != "")
                {
                    if (!m.sothe(int.Parse(madoituong.SelectedValue.ToString()), sothe.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }
            if (denngay.Enabled && denngay.Text.Trim().Length != 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập ngày hết hạn !"), LibMedi.AccessData.Msg);
                denngay.Focus();
                return false;
            }
            if ((mabv.Enabled && mabv.Text == "") || (tenbv.Enabled && tenbv.Text == ""))
            {
                MessageBox.Show(lan.Change_language_MessageText("Nơi đăng ký khám chữa bệnh !"), LibMedi.AccessData.Msg);
                if (mabv.Enabled) mabv.Focus();
                else if (tenbv.Enabled) tenbv.Focus();
                return false;
            }
            if (sothe1.Enabled && sothe1.Text != "")
            {
                if (sothe1.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập số thẻ !"), LibMedi.AccessData.Msg);
                    sothe1.Focus();
                    return false;
                }
                else if (sothe1.Text != "")
                {
                    if (!m.sothe(int.Parse(madoituong.SelectedValue.ToString()), sothe1.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :" + sothe.Text.Length.ToString()), LibMedi.AccessData.Msg);
                        sothe1.Focus();
                        return false;
                    }
                }
                if (denngay1.Enabled && denngay1.Text.Trim().Length != 10)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập ngày hết hạn !"), LibMedi.AccessData.Msg);
                    denngay1.Focus();
                    return false;
                }
            }
            if (ngaytrinh.Enabled)
            {
                if ((ngaytrinh.Text != "" && ngayduyet.Text == "") || (ngaytrinh.Text == "" && ngayduyet.Text != ""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày trình, ngày duyệt không hợp lệ !"), LibMedi.AccessData.Msg);
                    if (ngaytrinh.Text == "") ngaytrinh.Focus();
                    else ngayduyet.Focus();
                    return false;
                }
            }
            if (ngaytrinh1.Enabled)
            {
                if ((ngaytrinh1.Text != "" && ngayduyet1.Text == "") || (ngaytrinh1.Text == "" && ngayduyet1.Text != ""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày trình, ngày duyệt không hợp lệ !"), LibMedi.AccessData.Msg);
                    if (ngaytrinh1.Text == "") ngaytrinh1.Focus();
                    else ngayduyet1.Focus();
                    return false;
                }
            }
            string ngay = lds.Tables[0].Rows[ngayvao.SelectedIndex]["ngayv"].ToString();
            xxx = user + m.mmyy(ngay);
            if (thongtin.SelectedIndex == 0)//Thủy 28.05.2013
            {
                sql = " select mabn from " + xxx + ".tiepdon where done='c' and maql=" + l_maql;
                if (m.get_data(sql).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng qua quầy tiếp đón sửa lại đối tượng đăng kí khám bệnh!"), LibMedi.AccessData.Msg);
                    butKetthuc.Focus();
                    return false;
                }

            }
            if (thongtin.SelectedIndex == 1 || thongtin.SelectedIndex == 3)
            {
                sql = "select b.doituong from "+xxx+".bhytkb a,"+user+".doituong b where a.maphu=b.madoituong and a.maql="+l_maql+" and a.maphu<>"+int.Parse(madoituong.SelectedValue.ToString());
                sql += " and a.mabn='" + mabn2.Text + mabn3.Text + "'";
                DataTable tmp = m.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đơn thuốc ngoại trú đã duyệt đối tượng :"+tmp.Rows[0]["doituong"].ToString()), LibMedi.AccessData.Msg);
                    madoituong.Focus();
                    return false;
                }
            }
            if (sothe.Enabled && ngayvao.SelectedIndex != -1)
            {
                if (bPhonggiuong)
                {
                    string tu = "";
                    foreach (DataRow r in m.get_data("select to_char(tu,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".theodoigiuong where den is null and maql=" + decimal.Parse(ngayvao.SelectedValue.ToString())).Tables[0].Rows)
                        tu = r["ngay"].ToString();
                    if (tu != "" && ngayduyet.Text != "")
                    {
                        if (!m.bNgaygio(ngayduyet.Text,tu))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày duyệt không được nhỏ hơn ")+tu,LibMedi.AccessData.Msg);
                            ngayduyet.Text = tu;
                            ngayduyet.Focus();
                            return false;
                        }
                    }
                }
            }
            if (bSuadt_auto_dichvu==false && int.Parse(madoituong.SelectedValue.ToString()) == 2)
            {
                string dk=" a.maql=" + decimal.Parse(ngayvao.SelectedValue.ToString()) + " and a.madoituong=1 and a.mabn='" + mabn2.Text + mabn3.Text + "' and a.madoituong=b.madoituong ";
                sql = "select b.doituong,a.maql from " + xxx + ".d_tienthuoc a,"+user+".doituong b where " + dk;
                sql += " union all select b.doituong,a.maql from " + xxx + ".v_vpkhoa a," + user + ".doituong b where " + dk;
                sql += " union all select b.doituong,a.maql from " + xxx + ".v_chidinh a," + user + ".doituong b where " + dk;
                DataTable dttemp = m.get_data(sql).Tables[0];
                if (dttemp.Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã phát sinh chi phí bhyt của đối tượng :" + dttemp.Rows[0]["doituong"].ToString()), LibMedi.AccessData.Msg);
                    madoituong.Focus();
                    return false;
                }
            }
            if (bSothe_mabn)
            {
                if (sothe.Enabled && sothe1.Text.Trim() != "")
                {
                    string s = m.mabn_bhyt(nam, mabn2.Text + mabn3.Text, sothe1.Text); // m.mabn_bhyt(nam, mabn2.Text + mabn3.Text, sothe.Text);
                    if (s != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ ") + " " + sothe1.Text + "\n " + lan.Change_language_MessageText("Đã có mã người bệnh :") + s + "\n" + lan.Change_language_MessageText("Sử dụng !"), LibMedi.AccessData.Msg);
                        sothe1.Focus();
                        return false;
                    }
                }
            }
            //kiem tra bn xuat khoa trong ngay ko cho dki kham benh trong ngay vi bhyt ko chi tra 2 lần dk khám trong ngày
            if (madoituong.SelectedValue.ToString() == "1")
            {
                sql = "select mabn from " + user + ".xuatvien where mabn='" + s_mabn + "' and to_timestamp(to_char(ngay,'" + d.f_ngay + "'),'" + d.f_ngay + "') = to_timestamp('" + ngayvao.Text.Substring(0, 10) + "','" + d.f_ngay + "')";
                DataTable dttemp = m.get_data(sql).Tables[0];
                if (dttemp.Rows.Count > 0)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này mới ra viện trong ngày, bạn có muốn cho Bệnh nhân tiếp tục sửa đối tượng không?") + "\n", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dlg == DialogResult.No) return false;
                }
            }
            if (sothe1.Text.Trim() != "" && m.songay(m.StringToDate(denngay1.Text), m.StringToDate(denngay.Text), 0) > 0)
            {
                sudung.Checked = false;
                sudung1.Checked = true;
            }
            else
            {
                sudung.Checked = true;
                sudung1.Checked = false;
            }
            //truong thuy kiem tra doi BHYT dang ky lan dau BHYT lan sau doi tuong thu phi trong cung 1 ngay  khong cho đổi đối tượng thành BHYT 
            if (bnKhamBHYTmotlantrongngay && madoituong.Text == "2")
            {
                int i_dakham = f_kiemtrabndakhamtrongngay(s_mabn, ngayvao.Text);
                if (i_dakham == 1)
                {
                    MessageBox.Show("Bệnh nhân vừa mới khám xong không cho đăng ký  BHYT thêm. Muốn khám thêm thì phải chuyển sang thu phí  ");
                    return false;
                }
                else if (i_dakham == 2)
                {
                    MessageBox.Show("Bệnh nhân vừa mới ra viện trong ngày( hay chưa ra) không cho đăng ký BHYT thêm. Muốn khám thêm thì phải chuyển sang thu phí  ");
                    return false;
                }
            }
			return true;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_mabn"></param>
        /// <param name="m_ngay"></param>
        /// <returns>1 Vua kham xong trong ngay, 2 vua ra cung ngay dieu tri noi tru, ngoai tru ,</returns>
        private int f_kiemtrabndakhamtrongngay(string m_mabn, string m_ngay)
        {
            string s_sql = "";
            s_sql = " select  mabn from xxx.bhytkb where mabn='" + m_mabn + "' and to_char(ngay,'dd/mm/yyyy')='" + m_ngay + "'";
            DataSet ds1 = new DataSet();
            ds1 = m.get_data_mmyy(s_sql, m_ngay, m_ngay, true);
            int i_trangthaikham = 0;
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                i_trangthaikham = 1;
            }
            else
            {
                s_sql = " select  to_number('2') as trangthai ,mabn from medibv.benhandt a left join  medibv.xuatvien b on a.maql=b.maql  where a.mabn='" + m_mabn + "' and (to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay + "' or b.ngay is null) ";
                s_sql += " union all ";
                s_sql += " select  to_number('2') as trangthai ,mabn from medibv.benhanngtr a left join  medibv.xuatvien b on a.maql=b.maql  where a.mabn='" + m_mabn + "' and (to_char(b.ngay,'dd/mm/yyyy')='" + m_ngay + "' or b.ngay is null) ";
                ds1 = m.get_data(s_sql);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    i_trangthaikham = 2;
                }
                else
                    i_trangthaikham = 0;
            }
            return i_trangthaikham;

        }
		private void Load_ngayvao(string smabn)
		{
			lds.Clear();
            switch (thongtin.SelectedIndex)
            {
                case 0: sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayv, maql,madoituong, 5 as loaiba from xxx.tiepdon where mabn='" + smabn + "' order by maql desc";
                    lds = m.get_data_nam_all_dec(nam, sql);
                    break;
                case 1: sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayv, maql,madoituong, 3 as loaiba from xxx.benhanpk where mabn='" + smabn + "' order by maql desc";
                    lds = m.get_data_nam_all_dec(nam, sql);
                    break;
                case 2: sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayv, maql,madoituong, 2 as loaiba from "+user+".benhanngtr where mabn='" + smabn + "' order by maql desc";
                    lds = m.get_data(sql);
                    break;
                case 3: sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayv, maql,madoituong, 4 as loaiba from xxx.benhancc where mabn='" + smabn + "' order by maql desc";
                    lds = m.get_data_nam_all_dec(nam, sql);
                    break;
                case 4: sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayv, maql,madoituong, 1 as loaiba from " + user + ".benhandt where mabn='" + smabn + "' order by maql desc";
                    lds = m.get_data(sql);
                    break;
            }
			ngayvao.DataSource=lds.Tables[0];
			load_data();
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.ActiveControl==ngayvao) load_data();
		}

		private void load_data()
		{
			l_maql=(ngayvao.SelectedIndex<0)?0:decimal.Parse(ngayvao.SelectedValue.ToString());
            if (l_maql != 0)
            {
                madoituong.SelectedValue = lds.Tables[0].Rows[ngayvao.SelectedIndex]["madoituong"].ToString();
                i_madoituong = int.Parse(lds.Tables[0].Rows[ngayvao.SelectedIndex]["madoituong"].ToString());
                i_loaiba  = int.Parse(lds.Tables[0].Rows[ngayvao.SelectedIndex]["loaiba"].ToString());
            }
			Load_BHYT();				
		}

		private void frmsuabhyt_Load(object sender, System.EventArgs e)
		{
            bTraituyen = m.bTraituyen;
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn3.MaxLength  = i_maxlength_mabn - 2;

            stime = "'" + m.f_ngay + "'";
            traituyen.Enabled = traituyen1.Enabled = bTraituyen;
            traituyen.SelectedIndex = traituyen1.SelectedIndex = 0;
            user = m.user; nam = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year.ToString().Substring(2, 2) + "+";
			if(s_mabn!=""){mabn2.Text=s_mabn.Substring(0,2);mabn3.Text=s_mabn.Substring(2);}
			else mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
            bSothe_ngay_huong = m.bSothe_ngay_huong;
            bKhoa_suadoituong = m.bKhoa_suadoituong;
            bThanhtoan_khoa = m.bThanhtoan_khoa;
            bVienphi_phongluu = m.bCapcuu_noitru;
            bHansd_thuoc = m.bHansd_thuoc;
            bSothe_dkkcb = m.bSothe_dkkcb;
			ngayvao.DisplayMember="NGAYV";
			ngayvao.ValueMember="MAQL";
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            dtdt = m.get_data("select * from " + user + ".doituong order by madoituong").Tables[0];
            madoituong.DataSource = dtdt;
            thongtin.SelectedIndex = 0;
			load_dm();
            dt = m.get_data("select a.*,b.chenhlech from " + user + ".dmgiuong a," + user + ".v_giavp b where a.id=b.id").Tables[0];
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            bPhonggiuong = m.bPhonggiuong;
            bChenhlech = m.bChenhlech;
            sothe.Text = ""; mabv.Text = ""; tenbv.Text = ""; denngay.Text = ""; tungay.Text = "";
            sothe1.Text = ""; mabv1.Text = ""; tenbv1.Text = ""; denngay1.Text = ""; tungay1.Text = "";
            ngay1.Text = ngay2.Text = ngay3.Text = ngay11.Text = ngay21.Text = ngay31.Text = "";
            ngaytrinh.Text = ngayduyet.Text = ngaygiahan.Text = ngaytrinh1.Text = ngayduyet1.Text = ngaygiahan1.Text = "";
            sudung.Enabled=sudung1.Enabled=bAdmin;
            //
            bDuyet_congdondoituong = d.bPhattron_congdondoituong(m.nhom_duoc);
            bKhoa_suadoituong = m.bKhoa_suadoituong;
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            s_chenhlech = "";
            bSuadt_auto_dichvu = m.bSuadt_auto_dichvu;
            bSothe_mabn = m.bsothe_mabn;
            if (bSuadt_auto_dichvu)
            {
                foreach (DataRow row in this.m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + this.user + ".doituong a where chenhlech=1").Tables[0].Rows)
                {
                    s_chenhlech = s_chenhlech + row["madoituong"].ToString().Trim().PadLeft(2, '0') + ",";
                }
                sql = "select 0 as loai,id,gia_th,gia_bh,gia_cs,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_cs,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay, chenhlech,0 as kcct from " + user + ".v_giavp_luu";
                sql += " union all ";
                sql += "select 1 as loai,id,gia_th,gia_bh,gia_cs,gia_dv,gia_nn,vattu_th,vattu_bh,vattu_cs,vattu_dv,vattu_nn,bhyt,to_char(ngayud,'yyyymmddhh24mi') as ngaygio,to_char(ngayud,'yyyymmdd') as ngay, chenhlech, kcct from " + user + ".v_giavp";
                dtgia = m.get_data(sql).Tables[0];
            }
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			mabn3.Text=mabn3.Text.Trim().PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
            lds.Clear();
			load_mabn();
			Load_ngayvao(s_mabn);
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			if(mabv.Text!="")
			{
				list.SelectedValue=mabv.Text;
				string s_exp="mabv='"+mabv.Text+"'";
				DataRow r=m.getrowbyid(dtbv,s_exp);
				if(r!=null)
					tenbv.Text=r["tenbv"].ToString();
				else
					tenbv.Text="";
			}
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				string so=m.sothe(int.Parse(madoituong.SelectedValue.ToString()));
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
                tungay.Enabled = denngay.Enabled;
				mabv.Enabled=so.Substring(3,1)=="1";
                ngay1.Enabled = ngay2.Enabled = ngay3.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
				tenbv.Enabled=mabv.Enabled;
                sothe1.Enabled = sothe.Enabled;
                tungay1.Enabled = tungay.Enabled;
                denngay1.Enabled = denngay.Enabled;
                mabv1.Enabled = mabv.Enabled;
                tenbv1.Enabled = tenbv.Enabled;
                ngay11.Enabled = ngay21.Enabled = ngay31.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
                if (bTraituyen) traituyen.Enabled = traituyen1.Enabled = mabv.Enabled;
				SendKeys.Send("{Tab}");
			}
		}

        private void thongtin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (thongtin.SelectedIndex == -1) thongtin.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void thongtin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == thongtin)
            {
                ngaytrinh.Enabled = ngayduyet.Enabled = ngaygiahan.Enabled = ngaytrinh1.Enabled = ngayduyet1.Enabled = ngaygiahan1.Enabled = thongtin.SelectedIndex == 2 || thongtin.SelectedIndex == 4;
                if (mabn2.Text != "" && mabn3.Text != "") mabn3_Validated(sender, e);
            }
        }

        private void madoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == madoituong && madoituong.SelectedIndex!=-1)
            {
                string so = m.sothe(int.Parse(madoituong.SelectedValue.ToString()));
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                denngay.Enabled = so.Substring(2, 1) == "1";
                tungay.Enabled = denngay.Enabled;
                mabv.Enabled = so.Substring(3, 1) == "1";
                tenbv.Enabled = mabv.Enabled;
                ngay1.Enabled = ngay2.Enabled = ngay3.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
                sothe1.Enabled = sothe.Enabled;
                tungay1.Enabled = tungay.Enabled;
                denngay1.Enabled = denngay.Enabled;
                mabv1.Enabled = mabv.Enabled;
                tenbv1.Enabled = tenbv.Enabled;
                ngay11.Enabled = ngay21.Enabled = ngay31.Enabled = so.Substring(2, 1) == "1" && bSothe_ngay_huong;
                //
                if (sothe.Enabled && ngayvao.SelectedIndex!=-1)
                {
                    if (bPhonggiuong)
                    {
                        foreach (DataRow r in m.get_data("select to_char(tu,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".theodoigiuong where den is null and maql=" + decimal.Parse(ngayvao.SelectedValue.ToString())).Tables[0].Rows)
                        {
                            ngaytrinh.Text = (ngaytrinh.Text.Trim() != "" && ngaytrinh.Text.Trim() != "/  /") ? ngaytrinh.Text.Trim() : r["ngay"].ToString().Substring(0,10);//ngayvao.Text.Substring(0, 10);
                            ngayduyet.Text = (ngayduyet.Text.Trim() != "" && ngayduyet.Text.Trim() != "/  /") ? ngayduyet.Text.Trim() : r["ngay"].ToString();//ngayvao.Text.Substring(0, 10);
                        }
                    }
                }
                else
                {
                    ngaytrinh.Text = "";
                    ngayduyet.Text = "";
                }
                //
                if (bTraituyen) traituyen.Enabled = traituyen1.Enabled = mabv.Enabled;
            }
        }

        private void tungay_Validated(object sender, EventArgs e)
        {
            try
            {
                if (tungay.Text.Trim() == "") return;
                if (!m.bNgay(tungay.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    tungay.Focus();
                    return;
                }
                tungay.Text = m.Ktngaygio(tungay.Text, 10);
                SendKeys.Send("{Home}");
            }
            catch { }
        }

        private void sothe1_Validated(object sender, EventArgs e)
        {
            if (sothe1.Text == "") butLuu.Focus();
        }

        private void denngay1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!m.bNgay(denngay1.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    denngay1.Focus();
                    return;
                }
                denngay1.Text = m.Ktngaygio(denngay1.Text, 10);
                string s_ngay = (tungay1.Text != "") ? tungay1.Text : ngayvao.Text.Substring(0, 10);
                if (!m.bNgay(denngay1.Text, s_ngay))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không hợp lệ !"), lan.Change_language_MessageText("BHYT"));
                    denngay1.Focus();
                    return;
                }
                SendKeys.Send("{Home}");
            }
            catch { }
        }

        private void tungay1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (tungay1.Text.Trim() == "") return;
                if (!m.bNgay(tungay1.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    tungay1.Focus();
                    return;
                }
                tungay1.Text = m.Ktngaygio(tungay1.Text, 10);
                SendKeys.Send("{Home}");
            }
            catch { }
        }

        private void mabv1_Validated(object sender, EventArgs e)
        {
            if (mabv1.Text != "")
            {
                list.SelectedValue = mabv1.Text;
                string s_exp = "mabv='" + mabv1.Text + "'";
                DataRow r = m.getrowbyid(dtbv, s_exp);
                if (r != null)
                    tenbv1.Text = r["tenbv"].ToString();
                else
                    tenbv1.Text = "";
            }
        }

        private void tenbv1_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tenbv1)
            {
                Filt_noicap(tenbv1.Text);
                if (traituyen1.Enabled) list.BrowseToText(tenbv1, mabv1, traituyen1, mabv1.Location.X, mabv1.Location.Y + mabv1.Height, mabv1.Width + tenbv1.Width + 2, mabv1.Height);
                if (ngaytrinh1.Enabled)  list.BrowseToText(tenbv1, mabv1,ngaytrinh1, mabv1.Location.X, mabv1.Location.Y + mabv1.Height, mabv1.Width + tenbv1.Width + 2, mabv1.Height);
                else  list.BrowseToText(tenbv1, mabv1, butLuu, mabv1.Location.X, mabv1.Location.Y + mabv1.Height, mabv1.Width + tenbv1.Width + 2, mabv1.Height);
            }
        }

        private void ngay1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngay1.Text == "") return;
                if (sothe.Text != "")
                {
                    ngay1.Text = ngay1.Text.Trim();
                    if (ngay1.Text.Length == 6) ngay1.Text = ngay1.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay1.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay1.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay2_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngay2.Text == "") return;
                if (sothe.Text != "")
                {
                    ngay2.Text = ngay2.Text.Trim();
                    if (ngay2.Text.Length == 6) ngay2.Text = ngay2.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay2.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay2.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay3_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngay3.Text == "") return;
                if (sothe.Text != "")
                {
                    ngay3.Text = ngay3.Text.Trim();
                    if (ngay3.Text.Length == 6) ngay3.Text = ngay3.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay3.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay3.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay11_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngay11.Text == "") return;
                if (sothe.Text != "")
                {
                    ngay11.Text = ngay11.Text.Trim();
                    if (ngay11.Text.Length == 6) ngay11.Text = ngay11.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay1.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay11.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay21_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngay21.Text == "") return;
                if (sothe.Text != "")
                {
                    ngay21.Text = ngay21.Text.Trim();
                    if (ngay21.Text.Length == 6) ngay21.Text = ngay21.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay21.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay21.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void ngay31_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngay31.Text == "") return;
                if (sothe.Text != "")
                {
                    ngay31.Text = ngay31.Text.Trim();
                    if (ngay31.Text.Length == 6) ngay31.Text = ngay31.Text + DateTime.Now.Year.ToString();
                    if (!m.bNgay(ngay31.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                        ngay31.Focus();
                        return;
                    }
                    SendKeys.Send("{Home}");
                }
            }
            catch { }
        }

        private void sudung_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == sudung)  sudung1.Checked = !sudung.Checked;
        }

        private void sudung1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == sudung1) sudung.Checked = !sudung1.Checked;
        }

        private void ngayduyet_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngayduyet.Text == "" || !sothe.Enabled || sothe.Text=="") return;
                if (!m.bNgay(ngayduyet.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    ngayduyet.Focus();
                    return;
                }
                ngayduyet.Text = m.Ktngaygio(ngayduyet.Text, 16);
                //string s_ngay = (ngaytrinh.Text != "") ? ngaytrinh.Text : ngayvao.Text.Substring(0, 10);
                string s_ngay = ngayvao.Text;
                if (!m.bNgay(ngayduyet.Text, s_ngay))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày duyệt không hợp lệ !"), lan.Change_language_MessageText("BHYT"));
                    ngayduyet.Focus();
                    return;
                }
                SendKeys.Send("{Home}");
            }
            catch { }
        }

        private void ngayduyet1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngayduyet1.Text == "") return;
                if (!m.bNgay(ngayduyet1.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    ngayduyet1.Focus();
                    return;
                }
                ngayduyet1.Text = m.Ktngaygio(ngayduyet1.Text, 10);
                string s_ngay = (ngaytrinh1.Text != "") ? ngaytrinh1.Text : ngayvao.Text.Substring(0, 10);
                if (!m.bNgay(ngayduyet1.Text, s_ngay))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày duyệt không hợp lệ !"), lan.Change_language_MessageText("BHYT"));
                    ngayduyet1.Focus();
                    return;
                }
                SendKeys.Send("{Home}");
            }
            catch { }
        }

        private void ngaytrinh_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngaytrinh.Text == "" || !sothe.Enabled || sothe.Text=="") return;
                if (!m.bNgay(ngaytrinh.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    ngaytrinh.Focus();
                    return;
                }
                ngaytrinh.Text = m.Ktngaygio(ngaytrinh.Text, 10);
                if (ngayduyet.Text == "") ngayduyet.Text = ngaytrinh.Text;
            }
            catch { }
        }

        private void ngaygiahan_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngaygiahan.Text.Trim() == "") return;
                if (!m.bNgay(ngaygiahan.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    ngaygiahan.Focus();
                    return;
                }
                ngaygiahan.Text = m.Ktngaygio(ngaygiahan.Text, 10);
            }
            catch { }
        }

        private void ngaytrinh1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngaytrinh1.Text.Trim() == "") return;
                if (!m.bNgay(ngaytrinh1.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    ngaytrinh1.Focus();
                    return;
                }
                ngaytrinh1.Text = m.Ktngaygio(ngaytrinh1.Text, 10);
                if (ngayduyet1.Text == "") ngayduyet1.Text = ngaytrinh1.Text;
            }
            catch { }
        }

        private void ngaygiahan1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (ngaygiahan1.Text.Trim() == "") return;
                if (!m.bNgay(ngaygiahan1.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                    ngaygiahan1.Focus();
                    return;
                }
                ngaygiahan1.Text = m.Ktngaygio(ngaygiahan1.Text, 10);
            }
            catch { }
        }

        private void sothe_Validated(object sender, EventArgs e)
        {
            if (sothe.Text != "")
            {
                //Tu:22/08/2011 kiểm tra số thẻ hợp lệ theo qui định của BHYT dựa vào option E28(true)
                if (!m.bKiemtrasothehople(sothe.Text))
                {
                    MessageBox.Show("Số thẻ không hợp lệ. Đề nghị kiểm tra kĩ lại !");
                    sothe.Focus();
                    return;
                }
                //
                if (bSothe_dkkcb)
                {
                    if (sothe.Text.Trim().Length == _dai && _vitri != 0 && _sothe != "")
                    {
                        mabv.Text = sothe.Text.Substring(_vitri - 1, _sothe.Length);
                        mabv_Validated(sender, e);
                    }
                }
            }
        }

        private void load_thuoc()
        {
            DateTime dt1 = d.StringToDate(ngayvao.Text.Substring(0, 10)).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(ngayvao.Text.Substring(0, 10)).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            string s_ngayra = m.ngayhienhanh_server;
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (d.bMmyy(mmyy))
                    {
                        xxx = user + mmyy;
                        sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.makp,a.madoituong,a.mabd as ma,trim(b.ten)||' '||trim(b.hamluong)||'['||trim(c.ten)||']' as ten,b.dang as dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*a.giamua as sotien,a.giaban,e.ten as kp,a.giamua,a.gianovat,e.ten as kpmoi,a.traituyen,a.traituyen as traituyencu, a.gia_bh ";
                        sql += " from " + xxx + ".d_tienthuoc a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_doituong d," + user + ".d_duockp e ";
                        sql += " where a.mabd=b.id and b.mahang=c.id and a.madoituong=d.madoituong and a.makp=e.id";
                        if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                        sql += " and a.mabn='" + s_mabn + "'";
                        if (l_idkhoa != 0)
                        {
                            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                            if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
                        }
                        sql += " and a.maql=" + l_maql;
                        d.execute_data("insert into " + user + ".d_suamadt " + sql);
                        if (bVienphi_phongluu && i_loaiba != 4 && i_loaiba!=3)
                        {
                            maql_phongluu = m.get_maql_phongluu(ngayvao.Text, l_maql);
                            if (maql_phongluu != 0)
                            {
                                sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.makp,a.madoituong,a.mabd as ma,trim(b.ten)||' '||trim(b.hamluong)||'['||trim(c.ten)||']' as ten,b.dang as dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*a.giamua as sotien,a.giaban,e.ten as kp,a.giamua,a.gianovat,e.ten as kpmoi,a.traituyen,a.traituyen as traituyencu, a.gia_bh ";
                                sql += " from " + xxx + ".d_tienthuoc a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_doituong d," + user + ".d_duockp e ";
                                sql += " where a.mabd=b.id and b.mahang=c.id and a.madoituong=d.madoituong and a.makp=e.id";
                                if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                                sql += " and a.mabn='" + s_mabn + "'";
                                sql += " and a.maql=" + maql_phongluu;
                                if (ngaytrinh.Text.Trim() != "" && ngaytrinh.Text.Trim() != "/  /") sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                                d.execute_data("insert into " + user + ".d_suamadt " + sql);
                            }
                        }
                    }
                }
            }
        }

        private void load_vienphi()
        {
            string s_ngayra = m.ngayhienhanh_server;
            DateTime dt1 = d.StringToDate(ngayvao.Text.Substring(0, 10));
            DateTime dt2 = d.StringToDate(s_ngayra.Substring(0, 10));
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m.bMmyy(mmyy))
                    {
                        xxx = user + mmyy;
                        sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi,a.traituyen,a.traituyen as traituyencu,a.dongia as gia_bh ";
                        sql += " from " + xxx + ".v_vpkhoa a," + user + ".v_giavp b," + user + ".d_doituong d," + user + ".btdkp_bv e";
                        sql += " where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                        if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                        sql += " and a.mabn='" + s_mabn + "'";
                        if (l_idkhoa != 0)
                        {
                            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                            if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
                        }
                        if (ngaytrinh.Text.Trim() != "" && ngaytrinh.Text.Trim() != "/  /") sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngaytrinh.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + m.DateToString("dd/mm/yyyy", DateTime.Now.Date).Substring(0, 10) + "'," + stime + ")";
                        sql += " and a.maql=" + l_maql;
                        sql += " order by to_char(a.ngay,'yyyymmdd'),b.ten";
                        d.execute_data("insert into " + user + ".d_suamadt " + sql);
                        if (bVienphi_phongluu && i_loaiba != 4 && i_loaiba != 3)
                        {
                            maql_phongluu = m.get_maql_phongluu(ngayvao.Text, l_maql);
                            if (maql_phongluu != 0)
                            {
                                sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi,a.traituyen,a.traituyen as traituyencu,a.dongia as gia_bh  ";
                                sql += " from " + xxx + ".v_vpkhoa a," + user + ".v_giavp b," + user + ".d_doituong d," + user + ".btdkp_bv e";
                                sql += " where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                                if (!bKhoa_suadoituong) sql += " and a.done=0 ";
                                sql += " and a.mabn='" + s_mabn + "'";
                                sql += " and a.maql=" + maql_phongluu;
                                if (ngaytrinh.Text.Trim() != "" && ngaytrinh.Text.Trim() != "/  /") sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                                sql += " order by to_char(a.ngay,'yyyymmdd'),b.ten";
                                d.execute_data("insert into " + user + ".d_suamadt " + sql);
                            }
                        }
                        if (m.bChidinh_vienphi)
                        {
                            sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi,a.traituyen,a.traituyen as traituyencu,a.dongia as gia_bh  ";
                            sql += " from " + xxx + ".v_chidinh a," + user + ".v_giavp b," + user + ".d_doituong d," + user + ".btdkp_bv e";
                            sql += " where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                            if (!bKhoa_suadoituong) sql += " and a.paid=0 ";
                            sql += " and a.mabn='" + s_mabn + "'";
                            if (l_idkhoa != 0)
                            {
                                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                                if (bThanhtoan_khoa) sql += " and a.idkhoa=" + l_idkhoa;
                            }
                            if (ngaytrinh.Text.Trim() != "" && ngaytrinh.Text.Trim() != "/  /") sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                            sql += " and a.maql=" + l_maql;
                            sql += " order by to_char(a.ngay,'yyyymmdd'),b.ten";
                            d.execute_data("insert into " + user + ".d_suamadt " + sql);
                            if (bVienphi_phongluu && i_loaiba != 4 && i_loaiba != 3)
                            {
                                maql_phongluu = m.get_maql_phongluu(ngayvao.Text, l_maql);
                                if (maql_phongluu != 0)
                                {
                                    sql = "select '" + mmyy + "' as mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') as ngay,0 as makp,a.madoituong,a.mavp as ma,b.ten,b.dvt,a.soluong,d.doituong as doituongcu,d.doituong,b.bhyt,a.soluong*(a.dongia+a.vattu) as sotien,0 as giaban,e.tenkp as kp,a.dongia+a.vattu as giamua,a.dongia+a.vattu as gianovat,e.tenkp as kpmoi,a.traituyen,a.traituyen as traituyencu,a.dongia as gia_bh  ";
                                    sql += " from " + xxx + ".v_chidinh a," + user + ".v_giavp b," + user + ".d_doituong d," + user + ".btdkp_bv e";
                                    sql += " where a.mavp=b.id and a.madoituong=d.madoituong and a.makp=e.makp";
                                    if (!bKhoa_suadoituong) sql += " and a.paid=0 ";
                                    sql += " and a.mabn='" + s_mabn + "'";
                                    sql += " and a.maql=" + maql_phongluu;
                                    if (ngaytrinh.Text.Trim() != "" && ngaytrinh.Text.Trim() != "/  /") sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + s_ngayra.Substring(0, 10) + "'," + stime + ")";
                                    sql += " order by to_char(a.ngay,'yyyymmdd'),b.ten";
                                    d.execute_data("insert into " + user + ".d_suamadt " + sql);
                                }
                            }
                        }
                    }
                }
            }
        }
        //

        private void rep_madoituong(int loai)
        {
            string s_ngay = m.ngayhienhanh_server;
            bool bNhapPTTT_chenhlech_miengiamtheo_I08 = m.bNhapPTTT_chenhlech_miengiamtheo_I08;
            decimal v_idchidinh = 0;
            int i_madt = int.Parse(madoituong.SelectedValue.ToString());
            int i_tunguyen = m.iTunguyen;
            decimal d_giabhyt = 0;
            DataRow row;
            DataRow r4 = m.getrowbyid(dtdt, "madoituong=" + int.Parse(madoituong.SelectedValue.ToString()));
            if (loai == 0)
            {
                #region Thuoc

                foreach (DataRow r1 in ds.Tables[0].Select("madoituong=" + i_madoituong))
                {
                    xxx = user + r1["mmyy"].ToString();
                    if (madoituong.SelectedValue.ToString() == "1" && int.Parse(r1["bhyt"].ToString()) == 0)
                    {
                        //nothing
                    }
                    else
                    {
                        if (bDuyet_congdondoituong)
                        {
                            d.execute_data("update " + xxx + ".d_xuatsdct set madoituong=" + madoituong.SelectedValue.ToString() + " where id=" + r1["id"].ToString() + " and madoituong=" + i_madoituong + " and mabd=" + r1["ma"].ToString());
                            d.execute_data("update " + xxx + ".d_hoantract set madoituong=" + madoituong.SelectedValue.ToString() + " where idx=" + r1["id"].ToString() + " and madoituong=" + i_madoituong + " and mabd=" + r1["ma"].ToString());
                        }
                        d.execute_data("delete from " + xxx + ".d_tienthuoc where mabn='" + r1["mabn"].ToString() + "' and maql=" + decimal.Parse(r1["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r1["idkhoa"].ToString()) + " and to_char(ngay,'dd/mm/yyyy')='" + r1["ngay"].ToString() + "' and makp=" + int.Parse(r1["makp"].ToString()) + " and madoituong=" + i_madoituong + " and mabd=" + int.Parse(r1["ma"].ToString()));
                        d.upd_tienthuoc(r1["mmyy"].ToString().PadLeft(4, '0'), decimal.Parse(r1["id"].ToString()), r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), r1["ngay"].ToString(), int.Parse(r1["makp"].ToString()), int.Parse(madoituong.SelectedValue.ToString()), int.Parse(r1["ma"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), decimal.Parse(r1["gia_bh"].ToString()),"");
                        d.upd_theodoicongno(d.delete, r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), i_madoituong, decimal.Parse(r1["sotien"].ToString()), "thuoc");
                        d.upd_theodoicongno(d.insert, r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), int.Parse(madoituong.SelectedValue.ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
                    }
                }
            }
            else
            {
                #region Vienphi
                foreach (DataRow r1 in ds.Tables[0].Select("madoituong=" + i_madoituong)) 
                {
                    xxx = user + r1["mmyy"].ToString();
                    if (madoituong.SelectedValue.ToString() == "1" && int.Parse(r1["bhyt"].ToString()) == 0)
                    {
                        //nothing
                    }
                    else
                    {
                        d.upd_theodoicongno(d.delete, r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), i_madoituong, decimal.Parse(r1["sotien"].ToString()), "vienphi");
                        foreach (DataRow r2 in v.get_data("select a.*, to_char(ngay,'yyyymmdd') as ngay1, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay2 from " + xxx + ".v_vpkhoa a where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
                        {
                            if (bChidinh_thutienlien)
                            {
                                sql = "delete from " + xxx + ".v_vpkhoa where id=-" + r2["id"].ToString();
                                v.execute_data(sql);
                                sql = "delete from " + xxx + ".v_vpkhoa where id=" + r2["id"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString()) + " and hide=1 and mavp=" + r2["mavp"].ToString();
                                v.execute_data(sql);
                            }
                            get_dongia(decimal.Parse(r2["mavp"].ToString()), madoituong.SelectedValue.ToString(), r2["ngay1"].ToString());
                            d_giabhyt = d_dongia;
                            if (bFound)
                            {
                                sql = "update " + xxx + ".v_vpkhoa set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + ",dongia=" + d_dongia + ",vattu=" + d_vattu + ", stgiam=((tylegiam*" + d_dongia + ")/100) where id=" + decimal.Parse(r2["id"].ToString());
                                v.execute_data(sql);
                            }
                            else
                            {
                                v.execute_data("update " + xxx + ".v_vpkhoa set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where id=" + decimal.Parse(r2["id"].ToString()));
                            }
                            //
                            //
                            
                            row = m.getrowbyid(dtgia, "chenhlech=1 and id=" + int.Parse(r2["mavp"].ToString()));
                            if (row != null && i_madt == 1)
                            {
                                bTinhchenhlech = ((s_chenhlech.IndexOf(i_madt.ToString().Trim().PadLeft(2, '0') + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(row[m.field_gia(i_madt.ToString())].ToString()));
                                if (bChenhlech_doituong)
                                {
                                    bTinhchenhlech = bTinhchenhlech && (i_madt == i_tunguyen);
                                }
                                if (i_madt == 1)
                                {
                                    bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0);
                                }
                                else
                                {
                                    bTinhchenhlech = bTinhchenhlech && (s_chenhlech.IndexOf(i_madt.ToString()) != -1);
                                }
                                sql = "select id from " + xxx + ".v_vpkhoa where id=" + decimal.Parse(r2["idchidinh"].ToString()) + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mavp=" + decimal.Parse(r2["mavp"].ToString()) + " and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString());
                                if (bTinhchenhlech && (v.get_data(sql).Tables[0].Rows.Count == 1))
                                {
                                    v.execute_data("update " + xxx + ".v_vpkhoa set dachenhlech=1 where id=" + v_idchidinh);
                                    get_dongia(decimal.Parse(r2["mavp"].ToString()), i_tunguyen.ToString(), r2["ngay1"].ToString());//linh
                                    d_dongia = d_dongia - d_giabhyt;
                                    v_idchidinh = -1 * decimal.Parse(r2["id"].ToString());// v.get_id_chidinh;
                                    v.upd_vpkhoa(v_idchidinh, r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay2"].ToString(), r2["makp"].ToString(), i_tunguyen, int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), d_dongia, d_vattu, int.Parse(r2["userid"].ToString()), 0);

                                    decimal d_tylegiam = decimal.Parse(r2["tylegiam"].ToString());
                                    decimal d_stgiam = (d_tylegiam / 100) * d_dongia;
                                    if (bNhapPTTT_chenhlech_miengiamtheo_I08 == false) { d_tylegiam = 0; d_stgiam = 0; };
                                    v.execute_data("update " + xxx + ".v_vpkhoa set tylegiam=" + d_tylegiam + ", stgiam=" + d_stgiam + ", dachenhlech=1 where id=" + v_idchidinh);
                                }
                            }
                            //
                        }
                        if (m.bChidinh_vienphi)
                        {
                            foreach (DataRow r2 in v.get_data("select a.*,to_char(ngay,'yyyymmdd') as ngay1, to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay2 from " + xxx + ".v_chidinh a where id=" + decimal.Parse(r1["id"].ToString())).Tables[0].Rows)
                            {
                                if (bChidinh_thutienlien)
                                {
                                    sql = "delete from " + xxx + ".v_chidinh where id=-" + r2["id"].ToString();
                                    v.execute_data(sql);
                                    sql = "delete from " + xxx + ".v_chidinh where idchidinh=" + r2["idchidinh"].ToString() + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString()) + " and hide=1 and mavp=" + r2["mavp"].ToString();
                                    v.execute_data(sql);
                                }
                                get_dongia(decimal.Parse(r2["mavp"].ToString()), madoituong.SelectedValue.ToString(), r2["ngay1"].ToString());
                                d_giabhyt = d_dongia;
                                if (bFound)
                                {
                                    sql = "update " + xxx + ".v_chidinh set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + ",dongia=" + d_dongia + ",vattu=" + d_vattu + ", stgiam=((tylegiam*" + d_dongia + ")/100) where id=" + decimal.Parse(r2["id"].ToString());
                                    v.execute_data(sql);
                                }
                                else v.execute_data("update " + xxx + ".v_chidinh set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where id=" + decimal.Parse(r2["id"].ToString()));
                                //

                                //chenh lech
                                i_madt = int.Parse(madoituong.SelectedValue.ToString());
                                row = m.getrowbyid(dtgia, "chenhlech=1 and id=" + int.Parse(r2["mavp"].ToString()));
                                if (row != null && i_madt == 1)
                                {
                                    bTinhchenhlech = ((s_chenhlech.IndexOf(i_madt.ToString().Trim().PadLeft(2, '0') + ",") != -1) && (row["chenhlech"].ToString().Trim() == "1")) && (decimal.Parse(row[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(row[m.field_gia(i_madt.ToString())].ToString()));
                                    if (bChenhlech_doituong)
                                    {
                                        bTinhchenhlech = bTinhchenhlech && (i_madt == i_tunguyen);
                                    }
                                    if (i_madt == 1)
                                    {
                                        bTinhchenhlech = bTinhchenhlech && (decimal.Parse(row["bhyt"].ToString()) > 0);
                                    }
                                    else
                                    {
                                        bTinhchenhlech = bTinhchenhlech && (s_chenhlech.IndexOf(i_madt.ToString()) != -1);
                                    }
                                    sql = "select id from " + xxx + ".v_chidinh where idchidinh=" + decimal.Parse(r2["idchidinh"].ToString()) + " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + r2["ngay2"].ToString() + "' and mavp=" + decimal.Parse(r2["mavp"].ToString()) + " and mabn='" + r2["mabn"].ToString() + "' and maql=" + decimal.Parse(r2["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r2["idkhoa"].ToString());
                                    if (bTinhchenhlech && (v.get_data(sql).Tables[0].Rows.Count == 1))
                                    {
                                        v.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + v_idchidinh);
                                        get_dongia(decimal.Parse(r2["mavp"].ToString()), i_tunguyen.ToString(), r2["ngay1"].ToString());//linh
                                        d_dongia = d_dongia - d_giabhyt;
                                        v_idchidinh = -1 * decimal.Parse(r2["id"].ToString());// v.get_id_chidinh;
                                        v.upd_chidinh(v_idchidinh, r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay2"].ToString(), int.Parse(r2["loai"].ToString()), r2["makp"].ToString(), i_tunguyen, int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), d_dongia, d_vattu, int.Parse(r2["userid"].ToString()), int.Parse(r2["tinhtrang"].ToString()), int.Parse(r2["thuchien"].ToString()), decimal.Parse(r2["idchidinh"].ToString()), r2["maicd"].ToString(), r2["chandoan"].ToString(), r2["mabs"].ToString(), int.Parse(r2["loaiba"].ToString()), r2["ghichu"].ToString());

                                        decimal d_tylegiam = decimal.Parse(r2["tylegiam"].ToString());
                                        decimal d_stgiam = (d_tylegiam / 100) * d_dongia;
                                        if (bNhapPTTT_chenhlech_miengiamtheo_I08 == false) { d_tylegiam = 0; d_stgiam = 0; };
                                        v.execute_data("update " + xxx + ".v_chidinh set hide=1,done=1,tylegiam=" + d_tylegiam + ", stgiam=" + d_stgiam + " where id=" + v_idchidinh);
                                    }
                                }
                            }
                        }
                        d.upd_theodoicongno(d.insert, r1["mabn"].ToString(), decimal.Parse(r1["mavaovien"].ToString()), decimal.Parse(r1["maql"].ToString()), decimal.Parse(r1["idkhoa"].ToString()), int.Parse(madoituong.SelectedValue.ToString()), decimal.Parse(r1["sotien"].ToString()), "vienphi");
                    }
                }
                #endregion Vienphi
            }
            #endregion thuoc
        }
        private void get_dongia(decimal mavp, string s_madoituong, string ngay)
        {
            gia = m.field_gia(s_madoituong);
            giavt = "vattu_" + gia.Substring(4).Trim();
            d_dongia = 0; d_vattu = 0;
            sql = "id=" + mavp + " and loai=1 and ngay<=" + ngay;
            DataRow[] dr = dtgia.Select(sql, "ngaygio");
            if (dr.Length > 0)
            {
                d_dongia = decimal.Parse(dr[0][gia].ToString());
                d_vattu = decimal.Parse(dr[0][giavt].ToString());
                bFound = true;
            }
            else
            {
                sql = "id=" + mavp + " and loai=0";
                dr = dtgia.Select(sql, "ngaygio desc");
                for (int i = 0; i < dr.Length; i++)
                {
                    if (decimal.Parse(dr[i]["ngay"].ToString()) <= decimal.Parse(ngay))
                    {
                        d_dongia = decimal.Parse(dr[i][gia].ToString());
                        d_vattu = decimal.Parse(dr[i][giavt].ToString());
                        bFound = true;
                        break;
                    }
                }
            }
            if (bFound == false)
            {
                sql = "id=" + mavp + " and loai=1 "; ;
                dr = dtgia.Select(sql, "ngaygio");
                if (dr.Length > 0)
                {
                    d_dongia = decimal.Parse(dr[0][gia].ToString());
                    d_vattu = decimal.Parse(dr[0][giavt].ToString());
                    bFound = true;
                }
            }
        }

        private void load_tamung()
        {
            DateTime dt1 = d.StringToDate(ngayvao.Text.Substring(0, 10));
            DateTime dt2 = d.StringToDate(ngayvao.Text.Substring(0, 10));
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string s_user = m.user;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m.bMmyy(mmyy))
                    {
                        sql = "select '" + mmyy + "' mmyy,a.id,a.mabn,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay,0 makp,a.madoituong,0 ma,to_char(a.sotien,'999,999,999,999') as ten,'' as dvt,a.sotien soluong,d.doituong doituongcu,d.doituong,0 bhyt,a.sotien,0 giaban,e.tenkp kp,a.sotien giamua, a.sotien as gia_bh ";
                        sql += " from " + s_user + mmyy + ".v_tamung a," + s_user + ".d_doituong d," + s_user + ".btdkp_bv e";
                        sql += " where a.madoituong=d.madoituong and a.makp=e.makp";
                        sql += " and a.done=0 and a.mabn='" + s_mabn + "'";
                        //sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+ngayvao.Text.Substring(0,10)+"','dd/mm/yy') and to_date('"+m.Ngayhienhanh.Substring(0,10)+"','dd/mm/yy')";						
                        //if(l_mavaovien>0) sql+=" and a.mavaovien="+l_mavaovien;
                    }
                    sql += " and a.maql=" + l_maql;
                    sql += " order by to_char(a.ngay,'yyyymmdd')";
                }
            }
            m.execute_data("insert into " + s_user + ".d_suamadt " + sql);
            if (bVienphi_phongluu && i_loaiba != 4)
            {
                maql_phongluu = m.get_maql_phongluu(ngayvao.Text, l_maql);
                if (maql_phongluu != 0)
                {
                    sql = "select '" + mmyy + "' mmyy,a.id,a.mabn,a.mavaovien, a.maql,a.idkhoa,to_char(a.ngay,'dd/mm/yyyy') ngay,0 makp,a.madoituong,0 ma,to_char(a.sotien,'999,999,999,999') ten,'' dvt,a.sotien soluong,d.doituong doituongcu,d.doituong,0 bhyt,a.sotien,0 giaban,e.tenkp kp,a.sotien giamua ";
                    sql += " from " + s_user + mmyy + ".v_tamung a," + s_user + ".d_doituong d," + s_user + ".btdkp_bv e";
                    sql += " where a.madoituong=d.madoituong and a.makp=e.makp";
                    sql += " and a.done=0 and a.mabn='" + s_mabn + "'";
                    sql += " and a.maql=" + maql_phongluu;
                    sql += " order by to_char(a.ngay,'yyyymmdd')";
                    m.execute_data("insert into " + s_user + ".d_suamadt " + sql);
                }
            }
        }
        private void ref_moidoituong_tamung()
        {
            foreach (DataRow r1 in ds.Tables[0].Select("madoituong=" + i_madoituong))
            {
                string s_xxx = m.user + r1["mmyy"].ToString().PadLeft(4, '0');
                m.execute_data(r1["mmyy"].ToString().PadLeft(4, '0'), "update " + s_xxx + ".v_tamung set madoituong=" + int.Parse(madoituong.SelectedValue.ToString()) + " where id=" + decimal.Parse(r1["id"].ToString()));
            }
        }
	}
}
