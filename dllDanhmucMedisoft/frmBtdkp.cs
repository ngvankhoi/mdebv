using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmDm.
	/// </summary>
	public class frmBtdkp : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_makp = 2;
        private bool bKhudt = false, bChinhanh = false, b_New=true;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox kehoach;
		private MaskedTextBox.MaskedTextBox thucke;
		private System.Windows.Forms.CheckedListBox dmba;
        private int itable, i_userid, i_khu = 0, i_chinhanh = 0;
        private long l_idkp = 0;
        private string user, s_maba, s_loaivp = "", s_mucvp = "", s_loaicd = "", s_muccd = "", s_khudt="";
		private System.Windows.Forms.Button butMavp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox viettat;
        private Button butMacd;
        private Label label1;
        private bool bKhoan;
        private MaskedTextBox.MaskedTextBox giavtth;
        private ComboBox khudt;
        private Label label7;
        private ComboBox chinhanh;
        private Label label8;
        private TextBox tim;
        private ComboBox cbloai;
        private Label label9;
        private CheckBox chkkhonghiendien_choChidinh;
        private CheckBox chkkhonghiendien_chodutru;
        private ToolTip toolTip1;
        private IContainer components;

		public frmBtdkp(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            i_userid = userid;            
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            s_khudt = m.f_get_khudt(i_userid);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmBtdkp(AccessData acc, int userid, int _chinhanh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_userid = userid;
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            s_khudt = m.f_get_khudt(i_userid);
            i_chinhanh = _chinhanh;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBtdkp));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.ma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.kehoach = new MaskedTextBox.MaskedTextBox();
            this.thucke = new MaskedTextBox.MaskedTextBox();
            this.dmba = new System.Windows.Forms.CheckedListBox();
            this.butMavp = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.viettat = new System.Windows.Forms.TextBox();
            this.butMacd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.giavtth = new MaskedTextBox.MaskedTextBox();
            this.khudt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chinhanh = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.cbloai = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkkhonghiendien_choChidinh = new System.Windows.Forms.CheckBox();
            this.chkkhonghiendien_chodutru = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 7);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(560, 417);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(658, 525);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 16;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(40, 416);
            this.ma.MaxLength = 2;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(24, 21);
            this.ma.TabIndex = 0;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(123, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Khoa :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(175, 453);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(189, 21);
            this.ten.TabIndex = 2;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(339, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Theo bộ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(420, 453);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(188, 21);
            this.makp.TabIndex = 3;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(84, 525);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 11;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(154, 525);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(224, 525);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(294, 525);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(364, 525);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 13;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-26, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Giường kế họach :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(143, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Giường thực kê :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kehoach
            // 
            this.kehoach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kehoach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kehoach.Enabled = false;
            this.kehoach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kehoach.Location = new System.Drawing.Point(88, 475);
            this.kehoach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.kehoach.Name = "kehoach";
            this.kehoach.Size = new System.Drawing.Size(48, 21);
            this.kehoach.TabIndex = 5;
            this.kehoach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kehoach.Validated += new System.EventHandler(this.kehoach_Validated);
            // 
            // thucke
            // 
            this.thucke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thucke.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thucke.Enabled = false;
            this.thucke.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucke.Location = new System.Drawing.Point(232, 475);
            this.thucke.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.thucke.Name = "thucke";
            this.thucke.Size = new System.Drawing.Size(45, 21);
            this.thucke.TabIndex = 6;
            this.thucke.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.thucke.Validated += new System.EventHandler(this.thucke_Validated);
            // 
            // dmba
            // 
            this.dmba.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dmba.CheckOnClick = true;
            this.dmba.Enabled = false;
            this.dmba.Location = new System.Drawing.Point(576, 3);
            this.dmba.Name = "dmba";
            this.dmba.Size = new System.Drawing.Size(208, 424);
            this.dmba.TabIndex = 17;
            // 
            // butMavp
            // 
            this.butMavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMavp.Enabled = false;
            this.butMavp.Image = ((System.Drawing.Image)(resources.GetObject("butMavp.Image")));
            this.butMavp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMavp.Location = new System.Drawing.Point(434, 525);
            this.butMavp.Name = "butMavp";
            this.butMavp.Size = new System.Drawing.Size(114, 25);
            this.butMavp.TabIndex = 14;
            this.butMavp.Text = "&Giới hạn viện phí";
            this.butMavp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMavp.Click += new System.EventHandler(this.butMavp_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(8, 453);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 30;
            this.label6.Text = "Viết tắt :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viettat
            // 
            this.viettat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viettat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.viettat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.viettat.Enabled = false;
            this.viettat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viettat.Location = new System.Drawing.Point(88, 453);
            this.viettat.MaxLength = 8;
            this.viettat.Name = "viettat";
            this.viettat.Size = new System.Drawing.Size(48, 21);
            this.viettat.TabIndex = 1;
            this.viettat.Validated += new System.EventHandler(this.viettat_Validated);
            this.viettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butMacd
            // 
            this.butMacd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMacd.Enabled = false;
            this.butMacd.Image = ((System.Drawing.Image)(resources.GetObject("butMacd.Image")));
            this.butMacd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMacd.Location = new System.Drawing.Point(548, 525);
            this.butMacd.Name = "butMacd";
            this.butMacd.Size = new System.Drawing.Size(110, 25);
            this.butMacd.TabIndex = 15;
            this.butMacd.Text = "&Giới hạn chỉ định";
            this.butMacd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMacd.Click += new System.EventHandler(this.butMacd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(286, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 23);
            this.label1.TabIndex = 32;
            this.label1.Text = "Định mức vật tư tiêu hao :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giavtth
            // 
            this.giavtth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.giavtth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giavtth.Enabled = false;
            this.giavtth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giavtth.Location = new System.Drawing.Point(420, 475);
            this.giavtth.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.giavtth.Name = "giavtth";
            this.giavtth.Size = new System.Drawing.Size(131, 21);
            this.giavtth.TabIndex = 7;
            this.giavtth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giavtth.Validated += new System.EventHandler(this.giavtth_Validated);
            // 
            // khudt
            // 
            this.khudt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.khudt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khudt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khudt.Enabled = false;
            this.khudt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khudt.Location = new System.Drawing.Point(605, 475);
            this.khudt.Name = "khudt";
            this.khudt.Size = new System.Drawing.Size(179, 21);
            this.khudt.TabIndex = 8;
            this.khudt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khudt_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(558, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 23);
            this.label7.TabIndex = 34;
            this.label7.Text = "Khu :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chinhanh
            // 
            this.chinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chinhanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chinhanh.Enabled = false;
            this.chinhanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chinhanh.Location = new System.Drawing.Point(88, 430);
            this.chinhanh.Name = "chinhanh";
            this.chinhanh.Size = new System.Drawing.Size(696, 21);
            this.chinhanh.TabIndex = 0;
            this.chinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khudt_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(8, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 23);
            this.label8.TabIndex = 37;
            this.label8.Text = "Chi nhánh :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(8, 3);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(560, 21);
            this.tim.TabIndex = 38;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Validated += new System.EventHandler(this.tim_Validated);
            this.tim.Leave += new System.EventHandler(this.tim_Leave);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // cbloai
            // 
            this.cbloai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbloai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbloai.Enabled = false;
            this.cbloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbloai.Items.AddRange(new object[] {
            "Khoa lâm sàng",
            "Phòng khám",
            "Khoa CLS",
            "Hánh chính",
            "Phòng lưu",
            "Khác"});
            this.cbloai.Location = new System.Drawing.Point(658, 452);
            this.cbloai.Name = "cbloai";
            this.cbloai.Size = new System.Drawing.Size(126, 21);
            this.cbloai.TabIndex = 4;
            this.cbloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khudt_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(614, 452);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 23);
            this.label9.TabIndex = 40;
            this.label9.Text = "Loại :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkkhonghiendien_choChidinh
            // 
            this.chkkhonghiendien_choChidinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkkhonghiendien_choChidinh.AutoSize = true;
            this.chkkhonghiendien_choChidinh.Enabled = false;
            this.chkkhonghiendien_choChidinh.Location = new System.Drawing.Point(88, 500);
            this.chkkhonghiendien_choChidinh.Name = "chkkhonghiendien_choChidinh";
            this.chkkhonghiendien_choChidinh.Size = new System.Drawing.Size(261, 17);
            this.chkkhonghiendien_choChidinh.TabIndex = 41;
            this.chkkhonghiendien_choChidinh.Text = "Không hiện diện trong khoa cho chỉ định Chỉ định";
            this.toolTip1.SetToolTip(this.chkkhonghiendien_choChidinh, "Nhưng BN chưa ra viện, đang hiện diện khoa khác: dùng cho phòng mỗ, VLTL...");
            this.chkkhonghiendien_choChidinh.UseVisualStyleBackColor = true;
            this.chkkhonghiendien_choChidinh.Visible = false;
            // 
            // chkkhonghiendien_chodutru
            // 
            this.chkkhonghiendien_chodutru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkkhonghiendien_chodutru.AutoSize = true;
            this.chkkhonghiendien_chodutru.Enabled = false;
            this.chkkhonghiendien_chodutru.Location = new System.Drawing.Point(421, 501);
            this.chkkhonghiendien_chodutru.Name = "chkkhonghiendien_chodutru";
            this.chkkhonghiendien_chodutru.Size = new System.Drawing.Size(286, 17);
            this.chkkhonghiendien_chodutru.TabIndex = 42;
            this.chkkhonghiendien_chodutru.Text = "Không hiện diện trong khoa cho Dự trù thuốc + Tủ trực";
            this.toolTip1.SetToolTip(this.chkkhonghiendien_chodutru, "Nhưng BN chưa ra viện, đang hiện diện khoa khác: dùng cho phòng mỗ, VLTL");
            this.chkkhonghiendien_chodutru.UseVisualStyleBackColor = true;
            this.chkkhonghiendien_chodutru.Visible = false;
            // 
            // frmBtdkp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkkhonghiendien_chodutru);
            this.Controls.Add(this.chkkhonghiendien_choChidinh);
            this.Controls.Add(this.cbloai);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.chinhanh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.khudt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.giavtth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.butMacd);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.viettat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butMavp);
            this.Controls.Add(this.dmba);
            this.Controls.Add(this.thucke);
            this.Controls.Add(this.kehoach);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBtdkp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBtdkp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBtdkp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBtdkp_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bKhoan = m.bKhoan_vtth;
            user = m.user; itable = m.tableid("", "btdkp_bv");
            i_maxlength_makp = LibMedi.AccessData.i_maxlength_makp;
            //
            bKhudt = m.bQuanly_theokhu;
            //visble_khudt(bKhudt);
            bChinhanh = m.bQuanly_Theo_Chinhanh;
            //visble_chinhanh(bChinhanh);
            //
			dmba.DataSource=m.get_data("select * from "+user+".dmbenhan where loaiba<>3 order by maba").Tables[0];
            dmba.DisplayMember = "TEN";
            dmba.ValueMember = "MABA";


            string sql = "select * from " + user + ".dmkhudt ";
            if (s_khudt.Trim().Trim(',') != "") sql += " where  id in(" + s_khudt.Trim().Trim(',') + ")";
            khudt.DataSource = m.get_data(sql).Tables[0];
            khudt.DisplayMember = "TEN";
            khudt.ValueMember = "ID";
            //khudt.Enabled = khudt.Items.Count > 0;

            sql = "select * from " + user + ".dmchinhanh ";
            if (i_chinhanh > 0) sql += " where id=" + i_chinhanh;
            chinhanh.DataSource = m.get_data(sql).Tables[0];
            chinhanh.DisplayMember = "TEN";
            chinhanh.ValueMember = "ID";

            //
            sql = " select * from medibv.dmloaikp where id<>1 order by id ";
            DataTable dtloaikp = m.get_data(sql).Tables[0];
            cbloai.DataSource = dtloaikp;
            cbloai.DisplayMember = "TEN";
            cbloai.ValueMember = "ID";
            //
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + user + ".btdkp order by makp").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
		}

		private void load_grid()
		{
            string sql = "select a.makp,a.tenkp,b.tenkp as tenkpbo,a.makpbo,a.kehoach,a.thucke,a.maba,a.loaivp,a.mucvp,a.viettat,a.loaicd,a.muccd,a.giavtth, a.khu, a.chinhanh, a.loai, c.ten as tenloaikp ";
            sql += ", a.khonghiendien_chodutru, a.khonghiendien_chochidinh ";
            sql += " from " + user + ".btdkp_bv a left join " + user + ".btdkp b on a.makpbo=b.makp ";
            sql += " left join medibv.dmloaikp c on a.loai=c.id ";
            sql += " where 1=1 ";
            if (s_khudt.Trim().Trim(',') != "") sql += " and (a.khu=0 or a.khu in(" + s_khudt.Trim().Trim(',') + "))";
            if (i_chinhanh > 0) sql += " and chinhanh in(0," + i_chinhanh + ")";
            sql += " and a.loai <> 1 ";// " and a.loai in (0,4) ";//
            sql += " order by a.makp";
            dt = m.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "Mã";
			TextCol.Width = (i_maxlength_makp==2)?27:40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "viettat";
			TextCol.HeaderText = "Viết tắt";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkpbo";
			TextCol.HeaderText = "Khoa theo bộ";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "kehoach";
			TextCol.HeaderText = "Kế hoạch";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thucke";
			TextCol.HeaderText = "Thực kê";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makpbo";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maba";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loaivp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "mucvp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loaicd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "muccd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giavtth";
            TextCol.HeaderText = (bKhoan)?"ĐM VTTH":"";
            TextCol.Width = (bKhoan)?100:0;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Format = "### ### ### ###";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "khu";
            TextCol.HeaderText = "Khu";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chinhanh";
            TextCol.HeaderText = "CN";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenloaikp";
            TextCol.HeaderText = "Loại KP";
            TextCol.Width = 130;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ena_object(bool ena)
		{
            if (bKhoan) giavtth.Enabled = ena;
            tim.Enabled = !ena;
            if (m.bAdmin_hethong(i_userid))
                viettat.Enabled = ena;
            else viettat.Enabled = false;// ena;
			ten.Enabled=ena;
			makp.Enabled=ena;
			thucke.Enabled=ena;
			kehoach.Enabled=ena;
			dmba.Enabled=ena;
            khudt.Enabled = (khudt.Items.Count > 0) ? ena : false;
            chinhanh.Enabled = (bChinhanh && chinhanh.Items.Count > 0) ? ena : false;
            cbloai.Enabled = ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMavp.Enabled=ena;
            butMacd.Enabled = ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            dataGrid1.Enabled = !ena;
            //
            chkkhonghiendien_choChidinh.Enabled = ena;
            chkkhonghiendien_chodutru.Enabled = ena;
            //
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            empty_obj();
            int i = 1;
            b_New = true;
            DataRow r;
            string tmp_ma = "";
            if (bChinhanh==false)
            {
                dtkp = m.get_data("select makp from " + user + ".btdkp_bv order by makp").Tables[0];
                int imax = (i_maxlength_makp == 2) ? 100 : 1000;
                for (i = 1; i < imax; i++)
                {
                    tmp_ma = i.ToString().PadLeft(2, '0');
                    r = m.getrowbyid(dtkp, "makp='" + tmp_ma + "'");
                    if (r == null) break;
                }
            }
            ma.Text = tmp_ma;
            viettat.Text = ma.Text;
			for(int k=0;k<dmba.Items.Count;k++)	dmba.SetItemCheckState(k,CheckState.Unchecked);
            giavtth.Text=s_loaivp=s_mucvp=ten.Text = ""; thucke.Text = "0"; kehoach.Text = "0"; s_loaicd = s_muccd = "";
			ena_object(true);
			ma.Enabled=false;
            if (bChinhanh && chinhanh.Items.Count > 0) chinhanh.Focus();
            else ten.Focus();// viettat.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
            b_New = false;
		}

		private bool kiemtra()
		{
			if (viettat.Text=="")
			{
				viettat.Focus();
				return false;
			}
			if (ten.Text=="")
			{
				ten.Focus();
				return false;
			}
            else
            {
                ten.Text = ten.Text.Replace("(", "[");
                ten.Text = ten.Text.Replace(")", "]");
            }
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			if (kehoach.Text=="") kehoach.Text="0";
			if (thucke.Text=="") thucke.Text="0";
			s_maba="";
			int j;
			for(int i=0;i<dmba.Items.Count;i++)
			{
				if (dmba.GetItemChecked(i))
				{
					j=i+1;
					s_maba+=j.ToString().PadLeft(2,'0')+",";
				}
			}
			if (s_maba=="" && ma.Text!="99" && ma.Text!="999")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn bệnh án sử dụng trong khoa !"),LibMedi.AccessData.Msg);
				dmba.Focus();
				return false;
			}
			else s_maba=(s_maba=="")?"01":s_maba.Substring(0,s_maba.Length-1);

            if (khudt.Items.Count>0 && khudt.SelectedIndex<0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn cơ sở!"), LibMedi.AccessData.Msg);
                khudt.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{

            //
            if (bChinhanh && chinhanh.Items.Count > 0 && chinhanh.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn chi nhánh."));
                chinhanh.Focus();
                return;
            }
            if (cbloai.SelectedIndex < 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn loại khoa phòng."));
                cbloai.Focus();
                return;
            }
            if (b_New == false && cbloai.Tag.ToString() != cbloai.SelectedValue.ToString())
            {
                DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có chắc là muốn thay đổi loại khoa phòng?"), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.No)
                {
                    if (cbloai.Tag != null) cbloai.SelectedValue = cbloai.Tag.ToString();
                    cbloai.Focus();
                    return;
                }

            }
            //
            DataRow r;
            dtkp = m.get_data("select makp from " + user + ".btdkp_bv order by makp").Tables[0];
            int i = 0, imax = 99;// (i_maxlength_makp == 2) ? 100 : 1000;
            r = m.getrowbyid(dtkp, "makp='" + ma.Text + "'");
            int m_loai = (cbloai.SelectedIndex < 0) ? 0 : int.Parse(cbloai.SelectedValue.ToString());
            if (m_loai == -1) m_loai = 0;
            string tmp_ma = ma.Text;
            if (r == null || tmp_ma=="")
            {
                //MessageBox.Show(lan.Change_language_MessageText("Mã khoa này đã tồn tại, chương trình sẽ tự cấp mã mới."));
                for (i = 1; i < imax; i++)
                {
                    if (bChinhanh)
                    {
                        i_chinhanh = (chinhanh.SelectedIndex < 0) ? 0 : int.Parse(chinhanh.SelectedValue.ToString());
                        if (i_chinhanh > 0)
                        {
                            tmp_ma = i_chinhanh.ToString() + i.ToString().PadLeft(i_maxlength_makp - 1, '0');
                        }
                        else
                        {
                            tmp_ma = i.ToString().PadLeft(i_maxlength_makp - 1, '0');
                        }
                    }
                    else tmp_ma = i.ToString().PadLeft(2, '0');
                    r = m.getrowbyid(dtkp, "makp='" + tmp_ma + "'");
                    if (r == null) break;
                }
                ma.Text = tmp_ma;
                viettat.Text = ma.Text;
            }
            //
			if (!kiemtra()) return ;
           
            if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + kehoach.Text.ToString() + "^" + thucke.Text.ToString() + "^" + makp.SelectedValue.ToString() + "^" + s_maba + "^" + "0" + "^" + "0" + "^" + s_loaivp + "^" + s_mucvp + "^" + viettat.Text+"^"+s_loaicd+"^"+s_muccd);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            i_khu = (khudt.Enabled == false || khudt.SelectedIndex < 0) ? 0 : int.Parse(khudt.SelectedValue.ToString());
            int tmp_chinhanh = (chinhanh.Enabled == false || chinhanh.SelectedIndex < 0) ? 0 : int.Parse(chinhanh.SelectedValue.ToString());
            if (!m.upd_btdkp_bv("btdkp_bv", ma.Text, ten.Text, int.Parse(kehoach.Text.ToString()), int.Parse(thucke.Text.ToString()), makp.SelectedValue.ToString(), s_maba, m_loai, 0, s_loaivp, s_mucvp, viettat.Text, s_loaicd, s_muccd, i_khu, tmp_chinhanh,b_New))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin khoa !"));
				return;
			}

            m.upd_btdkp_bv("btdkp_add", ma.Text, ten.Text, int.Parse(kehoach.Text.ToString()), int.Parse(thucke.Text.ToString()), makp.SelectedValue.ToString(), s_maba, m_loai, 0, s_loaivp, s_mucvp, viettat.Text, s_loaicd, s_muccd, i_khu, tmp_chinhanh,b_New);
			m.upd_dm01(int.Parse(ma.Text.ToString())+51,"-",ten.Text,"C",2,int.Parse(makp.SelectedValue.ToString())+12);
            if (bKhoan) m.execute_data("update " + user + ".btdkp_bv set giavtth=" + ((giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0) + " where makp='" + ma.Text + "'");
            m.execute_data("update medibv.btdkp_bv set khonghiendien_chochidinh=" + (chkkhonghiendien_choChidinh.Checked ? "1" : "0") + ",khonghiendien_chodutru=" + (chkkhonghiendien_chodutru.Checked ? "1" : "0") + " where makp='" + ma.Text + "'");
			load_grid();
			ena_object(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ma.Text=="01")
			{
				MessageBox.Show(lan.Change_language_MessageText("Không được hủy mã này !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".benhandt where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Khoa đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".bieu_01 where ma-51=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Khoa đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".bieu_031 where ma-2=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Khoa đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                m.upd_eve_tables(itable, i_userid, "del");
                m.upd_eve_upd_del(itable, i_userid, "del", m.fields(user + ".btdkp_bv", "makp='" + ma.Text + "'"));
                m.execute_data("delete from " + user + ".btdkp_bv where makp='" + ma.Text + "'");
                m.execute_data("delete from " + user + ".btdkp_add where makp='" + ma.Text + "'");
                m.execute_data("delete from " + user + ".dm_01 where ma-51=" + int.Parse(ma.Text.ToString()));
				load_grid();
			}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			try
			{
                if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
					ma.Focus();
					return;
				}
			}
			catch{}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString();
				viettat.Text=dataGrid1[i,1].ToString();
				ten.Text=dataGrid1[i,2].ToString();
				kehoach.Text=dataGrid1[i,4].ToString();
				thucke.Text=dataGrid1[i,5].ToString();
				makp.SelectedValue=dataGrid1[i,6].ToString();
				s_maba=dataGrid1[i,7].ToString().Trim()+",";
				s_loaivp=dataGrid1[i,8].ToString();
				s_mucvp=dataGrid1[i,9].ToString();
                s_loaicd = dataGrid1[i, 10].ToString();
                s_muccd = dataGrid1[i, 11].ToString();
				int j;
				for(int k=0;k<dmba.Items.Count;k++)
				{
					j=k+1;
					if (s_maba.IndexOf(j.ToString().PadLeft(2,'0')+",")!=-1)
						dmba.SetItemCheckState(k,CheckState.Checked);
					else
						dmba.SetItemCheckState(k,CheckState.Unchecked);
				}
                decimal gia = (dataGrid1[i, 12].ToString() != "") ? decimal.Parse(dataGrid1[i, 12].ToString()) : 0;
                giavtth.Text = gia.ToString("###,###,###,###");
                i_khu = (dataGrid1[i, 13].ToString().Trim() == "") ? 0 : int.Parse(dataGrid1[i, 13].ToString());
                i_chinhanh = (dataGrid1[i, 14].ToString().Trim() == "") ? 0 : int.Parse(dataGrid1[i, 14].ToString());
                if (i_khu > 0) khudt.SelectedValue = i_khu;
                else khudt.SelectedIndex = -1;
                if (i_chinhanh > 0) chinhanh.SelectedValue = i_chinhanh;
                else chinhanh.SelectedIndex = -1;
                //cbloai.SelectedIndex = int.Parse(dataGrid1[i, 15].ToString());
                DataRow dr;
                dr = m.getrowbyid(dt, "makp='" + ma.Text + "'");
                if (dr != null)
                {
                    cbloai.SelectedValue = dr["loai"].ToString();
                    cbloai.Tag = dr["loai"].ToString();

                    chkkhonghiendien_chodutru.Checked = dr["khonghiendien_chodutru"].ToString() == "1";
                    chkkhonghiendien_choChidinh.Checked = dr["khonghiendien_chochidinh"].ToString() == "1";
                }
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			ten.Text=m.Caps(ten.Text);
		}

		private void kehoach_Validated(object sender, System.EventArgs e)
		{
			if (kehoach.Text=="") kehoach.Text="0";
		}

		private void thucke_Validated(object sender, System.EventArgs e)
		{
			if (thucke.Text=="") thucke.Text="0";
		}

		private void frmBtdkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.F10) butKetthuc_Click(sender, e);
            else if (e.KeyCode==Keys.A && e.Control && e.Shift && e.Alt )
            {
                chkkhonghiendien_choChidinh.Visible = !chkkhonghiendien_choChidinh.Visible;
                chkkhonghiendien_chodutru.Visible = !chkkhonghiendien_chodutru.Visible;
            }
		}

		private void butMavp_Click(object sender, System.EventArgs e)
		{
			frmChonvp f=new frmChonvp(m,s_loaivp,s_mucvp);
			f.ShowDialog();
            if (f.bOk)
			{
				s_loaivp=f.s_loaivp;s_mucvp=f.s_mucvp;
			}
		}

		private void viettat_Validated(object sender, System.EventArgs e)
		{
            if (m.get_data("select * from " + user + ".btdkp_bv where viettat='" + viettat.Text + "'").Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"));
				viettat.Focus();
				return;
			}
		}

        private void butMacd_Click(object sender, EventArgs e)
        {
            frmChonvp f = new frmChonvp(m, s_loaicd, s_muccd);
            f.ShowDialog();
            if (f.bOk)
            {
                s_loaicd = f.s_loaivp; s_muccd = f.s_mucvp;
            }
        }

        private void giavtth_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal gia = (giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0;
                giavtth.Text = gia.ToString("###,###,###,###");
            }
            catch { }
        }

        private void khudt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void visble_chinhanh(bool vis)
        {
            chinhanh.Visible = vis;
            label8.Visible = vis;
        }

        private void visble_khudt(bool vis)
        {
            khudt.Visible = vis;
            label7.Visible = vis;
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tim.Text.Trim() == "Tìm kiếm") { tim.Text = ""; return; }
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "tenkp like '%" + tim.Text.Trim() + "%'";
            }
            catch { }
        }

        private void tim_Validated(object sender, EventArgs e)
        {
            
        }

        private void tim_Leave(object sender, EventArgs e)
        {
            if (tim.Text.Trim() == "") { tim.Text = "Tìm kiếm"; }
        }

        private void empty_obj()
        {
            ma.Text = "";
            viettat.Text = "";
            ten.Text = "";
            chinhanh.SelectedIndex = -1;
            khudt.SelectedIndex = -1;
            makp.SelectedIndex = -1;
            cbloai.SelectedIndex = 0;
            cbloai.Tag = "0";

            chkkhonghiendien_chodutru.Checked = false;
            chkkhonghiendien_choChidinh.Checked = false;
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            if (tim.Text.Trim() == "Tìm kiếm") { tim.Text = ""; return; }
        }
	}
}
