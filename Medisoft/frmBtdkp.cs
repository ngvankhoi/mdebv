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
	/// Summary description for frmDm.
	/// </summary>
	public class frmBtdkp : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
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
        private int itable, i_userid;
        private string user, s_maba, s_loaivp = "", s_mucvp = "", s_loaicd = "", s_muccd = "";
		private System.Windows.Forms.Button butMavp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox viettat;
        private Button butMacd;
        private Label label1;
        private bool bKhoan;
        private MaskedTextBox.MaskedTextBox giavtth;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
            this.dataGrid1.Location = new System.Drawing.Point(8, -15);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(560, 492);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(627, 525);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
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
            this.label2.Location = new System.Drawing.Point(118, 475);
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
            this.ten.Location = new System.Drawing.Point(164, 476);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(200, 21);
            this.ten.TabIndex = 1;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(339, 477);
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
            this.makp.Location = new System.Drawing.Point(420, 476);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(364, 21);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(96, 525);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 8;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(157, 525);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 9;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(218, 525);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(279, 525);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(340, 525);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 10;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-21, 499);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Kế họach :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(113, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Thực kê :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kehoach
            // 
            this.kehoach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kehoach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kehoach.Enabled = false;
            this.kehoach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kehoach.Location = new System.Drawing.Point(59, 499);
            this.kehoach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.kehoach.Name = "kehoach";
            this.kehoach.Size = new System.Drawing.Size(48, 21);
            this.kehoach.TabIndex = 3;
            this.kehoach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kehoach.Validated += new System.EventHandler(this.kehoach_Validated);
            // 
            // thucke
            // 
            this.thucke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thucke.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thucke.Enabled = false;
            this.thucke.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucke.Location = new System.Drawing.Point(164, 499);
            this.thucke.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.thucke.Name = "thucke";
            this.thucke.Size = new System.Drawing.Size(116, 21);
            this.thucke.TabIndex = 4;
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
            this.dmba.Size = new System.Drawing.Size(208, 469);
            this.dmba.TabIndex = 28;
            // 
            // butMavp
            // 
            this.butMavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMavp.Enabled = false;
            this.butMavp.Image = ((System.Drawing.Image)(resources.GetObject("butMavp.Image")));
            this.butMavp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMavp.Location = new System.Drawing.Point(401, 525);
            this.butMavp.Name = "butMavp";
            this.butMavp.Size = new System.Drawing.Size(114, 25);
            this.butMavp.TabIndex = 11;
            this.butMavp.Text = "&Giới hạn viện phí";
            this.butMavp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMavp.Click += new System.EventHandler(this.butMavp_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(11, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
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
            this.viettat.Location = new System.Drawing.Point(59, 476);
            this.viettat.MaxLength = 8;
            this.viettat.Name = "viettat";
            this.viettat.Size = new System.Drawing.Size(48, 21);
            this.viettat.TabIndex = 0;
            this.viettat.Validated += new System.EventHandler(this.viettat_Validated);
            this.viettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butMacd
            // 
            this.butMacd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMacd.Enabled = false;
            this.butMacd.Image = ((System.Drawing.Image)(resources.GetObject("butMacd.Image")));
            this.butMacd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMacd.Location = new System.Drawing.Point(516, 525);
            this.butMacd.Name = "butMacd";
            this.butMacd.Size = new System.Drawing.Size(110, 25);
            this.butMacd.TabIndex = 12;
            this.butMacd.Text = "&Giới hạn chỉ định";
            this.butMacd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMacd.Click += new System.EventHandler(this.butMacd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(286, 499);
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
            this.giavtth.Location = new System.Drawing.Point(420, 499);
            this.giavtth.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.giavtth.Name = "giavtth";
            this.giavtth.Size = new System.Drawing.Size(364, 21);
            this.giavtth.TabIndex = 5;
            this.giavtth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giavtth.Validated += new System.EventHandler(this.giavtth_Validated);
            // 
            // frmBtdkp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
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
            this.Name = "frmBtdkp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBtdkp_KeyDown);
            this.Load += new System.EventHandler(this.frmBtdkp_Load);
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
			dmba.DataSource=m.get_data("select * from "+user+".dmbenhan where loaiba<>3 order by maba").Tables[0];
            dmba.DisplayMember = "TEN";
            dmba.ValueMember = "MABA";

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
            dt = m.get_data("select a.makp,a.tenkp,b.tenkp as tenkpbo,a.makpbo,a.kehoach,a.thucke,a.maba,a.loaivp,a.mucvp,a.viettat,a.loaicd,a.muccd,a.giavtth from " + user + ".btdkp_bv a left join " + user + ".btdkp b on a.makpbo=b.makp where a.loai in (0,4) order by a.makp").Tables[0];
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
			TextCol.Width = 27;
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
			viettat.Enabled=ena;
			ten.Enabled=ena;
			makp.Enabled=ena;
			thucke.Enabled=ena;
			kehoach.Enabled=ena;
			dmba.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMavp.Enabled=ena;
            butMacd.Enabled = ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            dataGrid1.Enabled = !ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			int i=1;
			DataRow r;
            dtkp = m.get_data("select * from " + user + ".btdkp_bv order by makp").Tables[0];
			for(i=1;i<100;i++)
			{
				r=m.getrowbyid(dtkp,"makp='"+i.ToString().PadLeft(2,'0')+"'");
				if (r==null) break;
			}
			ma.Text=i.ToString().PadLeft(2,'0');
			viettat.Text=ma.Text;
			for(int k=0;k<dmba.Items.Count;k++)	dmba.SetItemCheckState(k,CheckState.Unchecked);
            giavtth.Text=s_loaivp=s_mucvp=ten.Text = ""; thucke.Text = "0"; kehoach.Text = "0"; s_loaicd = s_muccd = "";
			ena_object(true);
			ma.Enabled=false;
			viettat.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
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
			if (s_maba=="" && ma.Text!="99")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn bệnh án sử dụng trong khoa !"),LibMedi.AccessData.Msg);
				dmba.Focus();
				return false;
			}
			else s_maba=(s_maba=="")?"01":s_maba.Substring(0,s_maba.Length-1);
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return ;
            if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + kehoach.Text.ToString() + "^" + thucke.Text.ToString() + "^" + makp.SelectedValue.ToString() + "^" + s_maba + "^" + "0" + "^" + "0" + "^" + s_loaivp + "^" + s_mucvp + "^" + viettat.Text+"^"+s_loaicd+"^"+s_muccd);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
			if (!m.upd_btdkp_bv("btdkp_bv",ma.Text,ten.Text,int.Parse(kehoach.Text.ToString()),int.Parse(thucke.Text.ToString()),makp.SelectedValue.ToString(),s_maba,0,0,s_loaivp,s_mucvp,viettat.Text,s_loaicd,s_muccd))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin khoa !"));
				return;
			}
			m.upd_btdkp_bv("btdkp_add",ma.Text,ten.Text,int.Parse(kehoach.Text.ToString()),int.Parse(thucke.Text.ToString()),makp.SelectedValue.ToString(),s_maba,0,0,s_loaivp,s_mucvp,viettat.Text,s_loaicd,s_muccd);
			m.upd_dm01(int.Parse(ma.Text.ToString())+51,"-",ten.Text,"C",2,int.Parse(makp.SelectedValue.ToString())+12);
            if (bKhoan) m.execute_data("update " + user + ".btdkp_bv set giavtth=" + ((giavtth.Text != "") ? decimal.Parse(giavtth.Text) : 0) + " where makp='" + ma.Text + "'");
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
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
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
	}
}
