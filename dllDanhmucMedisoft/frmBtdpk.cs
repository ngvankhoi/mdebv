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
	public class frmBtdpk : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
        private bool bChinhanh = false;
        private int itable, i_userid, i_khu=0,i_chinhanh=0;
        private int i_maxlength_makp = 2;
		private DataTable dt=new DataTable();
		private DataTable dtkp=new DataTable();
		private System.Windows.Forms.Label label1;
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
		private System.Windows.Forms.ComboBox mavp;
		private System.Windows.Forms.Button butMavp;
        private string s_loaivp = "", s_mucvp = "", user, s_loaicd = "", s_muccd = "", s_khudt = "";
		private System.Windows.Forms.CheckedListBox maba;
		private System.Windows.Forms.Label label5;
		private DataTable dtba=new DataTable();
        private DataTable dtdmkho = new DataTable();
		private System.Windows.Forms.TextBox viettat;
        private bool bMoi_cu;
        private ComboBox mavptk;
        private Label label6;
        private Button butMacd;
        private TextBox mavp_tk;
        private TextBox mavp_k;
        private ComboBox khudt;
        private Label label7;
        private TextBox tim;
        private ComboBox chinhanh;
        private Label label8;
        private CheckBox chkTiemchung;
        private Label label9;
        private CheckedListBox dmkho;
        private CheckBox chkDichVu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBtdpk(AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            i_userid = userid; m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            s_khudt = m.f_get_khudt(i_userid);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmBtdpk(AccessData acc, int userid, int _chinhanh)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_userid = userid; m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBtdpk));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.mavp = new System.Windows.Forms.ComboBox();
            this.butMavp = new System.Windows.Forms.Button();
            this.maba = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.viettat = new System.Windows.Forms.TextBox();
            this.mavptk = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butMacd = new System.Windows.Forms.Button();
            this.mavp_tk = new System.Windows.Forms.TextBox();
            this.mavp_k = new System.Windows.Forms.TextBox();
            this.khudt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.chinhanh = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkTiemchung = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dmkho = new System.Windows.Forms.CheckedListBox();
            this.chkDichVu = new System.Windows.Forms.CheckBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(586, 320);
            this.dataGrid1.TabIndex = 18;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(714, 447);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(-1, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Viết tắt :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(12, 451);
            this.ma.MaxLength = 2;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(24, 21);
            this.ma.TabIndex = 0;
            this.ma.Visible = false;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(99, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Phòng khám :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(176, 358);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(160, 21);
            this.ten.TabIndex = 3;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(311, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
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
            this.makp.Location = new System.Drawing.Point(383, 358);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(211, 21);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(124, 447);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 13;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            this.butMoi.Enter += new System.EventHandler(this.butMoi_Enter);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(194, 447);
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
            this.butLuu.Location = new System.Drawing.Point(264, 447);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 10;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(334, 447);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 11;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(404, 447);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 14;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-4, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Giá khám :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavp
            // 
            this.mavp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(116, 381);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(478, 21);
            this.mavp.TabIndex = 6;
            this.mavp.SelectedIndexChanged += new System.EventHandler(this.mavp_SelectedIndexChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // butMavp
            // 
            this.butMavp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMavp.Enabled = false;
            this.butMavp.Image = ((System.Drawing.Image)(resources.GetObject("butMavp.Image")));
            this.butMavp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMavp.Location = new System.Drawing.Point(474, 447);
            this.butMavp.Name = "butMavp";
            this.butMavp.Size = new System.Drawing.Size(120, 25);
            this.butMavp.TabIndex = 15;
            this.butMavp.Text = "    &Giới hạn viện phí";
            this.butMavp.Click += new System.EventHandler(this.butMavp_Click);
            // 
            // maba
            // 
            this.maba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maba.CheckOnClick = true;
            this.maba.Enabled = false;
            this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maba.Location = new System.Drawing.Point(600, 237);
            this.maba.Name = "maba";
            this.maba.Size = new System.Drawing.Size(189, 164);
            this.maba.TabIndex = 9;
            this.maba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maba_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(600, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Bệnh án :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viettat
            // 
            this.viettat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viettat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.viettat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.viettat.Enabled = false;
            this.viettat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viettat.Location = new System.Drawing.Point(54, 358);
            this.viettat.MaxLength = 8;
            this.viettat.Name = "viettat";
            this.viettat.Size = new System.Drawing.Size(56, 21);
            this.viettat.TabIndex = 2;
            this.viettat.Validated += new System.EventHandler(this.viettat_Validated);
            this.viettat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // mavptk
            // 
            this.mavptk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mavptk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavptk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mavptk.Enabled = false;
            this.mavptk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavptk.Location = new System.Drawing.Point(116, 404);
            this.mavptk.Name = "mavptk";
            this.mavptk.Size = new System.Drawing.Size(270, 21);
            this.mavptk.TabIndex = 8;
            this.mavptk.SelectedIndexChanged += new System.EventHandler(this.mavptk_SelectedIndexChanged);
            this.mavptk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavptk_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(-4, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 30;
            this.label6.Text = "Tái khám :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butMacd
            // 
            this.butMacd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMacd.Enabled = false;
            this.butMacd.Image = ((System.Drawing.Image)(resources.GetObject("butMacd.Image")));
            this.butMacd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMacd.Location = new System.Drawing.Point(594, 447);
            this.butMacd.Name = "butMacd";
            this.butMacd.Size = new System.Drawing.Size(120, 25);
            this.butMacd.TabIndex = 16;
            this.butMacd.Text = "    &Giới hạn chỉ định";
            this.butMacd.Click += new System.EventHandler(this.butMacd_Click);
            // 
            // mavp_tk
            // 
            this.mavp_tk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mavp_tk.Enabled = false;
            this.mavp_tk.Location = new System.Drawing.Point(54, 404);
            this.mavp_tk.Name = "mavp_tk";
            this.mavp_tk.Size = new System.Drawing.Size(56, 20);
            this.mavp_tk.TabIndex = 7;
            this.mavp_tk.Validated += new System.EventHandler(this.mavp_tk_Validated);
            this.mavp_tk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // mavp_k
            // 
            this.mavp_k.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mavp_k.Enabled = false;
            this.mavp_k.Location = new System.Drawing.Point(54, 381);
            this.mavp_k.Name = "mavp_k";
            this.mavp_k.Size = new System.Drawing.Size(56, 20);
            this.mavp_k.TabIndex = 5;
            this.mavp_k.Validated += new System.EventHandler(this.mavp_k_Validated);
            this.mavp_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // khudt
            // 
            this.khudt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.khudt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khudt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khudt.DropDownWidth = 120;
            this.khudt.Enabled = false;
            this.khudt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khudt.Location = new System.Drawing.Point(383, 335);
            this.khudt.Name = "khudt";
            this.khudt.Size = new System.Drawing.Size(211, 21);
            this.khudt.TabIndex = 1;
            this.khudt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khudt_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(324, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 23);
            this.label7.TabIndex = 36;
            this.label7.Text = "Khu :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(8, 4);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(776, 21);
            this.tim.TabIndex = 39;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Leave += new System.EventHandler(this.tim_Leave);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // chinhanh
            // 
            this.chinhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chinhanh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chinhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chinhanh.DropDownWidth = 120;
            this.chinhanh.Enabled = false;
            this.chinhanh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chinhanh.Location = new System.Drawing.Point(54, 335);
            this.chinhanh.Name = "chinhanh";
            this.chinhanh.Size = new System.Drawing.Size(282, 21);
            this.chinhanh.TabIndex = 0;
            this.chinhanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khudt_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(-14, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 23);
            this.label8.TabIndex = 41;
            this.label8.Text = "Chi nhánh";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTiemchung
            // 
            this.chkTiemchung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTiemchung.AutoSize = true;
            this.chkTiemchung.Location = new System.Drawing.Point(509, 407);
            this.chkTiemchung.Name = "chkTiemchung";
            this.chkTiemchung.Size = new System.Drawing.Size(112, 17);
            this.chkTiemchung.TabIndex = 42;
            this.chkTiemchung.Text = "Phòng tiêm chủng";
            this.chkTiemchung.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(600, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 23);
            this.label9.TabIndex = 43;
            this.label9.Text = "Kho :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dmkho
            // 
            this.dmkho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dmkho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dmkho.CheckOnClick = true;
            this.dmkho.Enabled = false;
            this.dmkho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dmkho.Location = new System.Drawing.Point(600, 48);
            this.dmkho.Name = "dmkho";
            this.dmkho.Size = new System.Drawing.Size(189, 164);
            this.dmkho.TabIndex = 44;
            // 
            // chkDichVu
            // 
            this.chkDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDichVu.AutoSize = true;
            this.chkDichVu.Location = new System.Drawing.Point(404, 406);
            this.chkDichVu.Name = "chkDichVu";
            this.chkDichVu.Size = new System.Drawing.Size(95, 17);
            this.chkDichVu.TabIndex = 45;
            this.chkDichVu.Text = "Phòng dịch vụ";
            this.chkDichVu.UseVisualStyleBackColor = true;
            // 
            // frmBtdpk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 484);
            this.Controls.Add(this.chkDichVu);
            this.Controls.Add(this.dmkho);
            this.Controls.Add(this.chkTiemchung);
            this.Controls.Add(this.chinhanh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.khudt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mavp_k);
            this.Controls.Add(this.mavp_tk);
            this.Controls.Add(this.butMacd);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.mavptk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.viettat);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butMavp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBtdpk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục phòng khám";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBtdpk_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBtdpk_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBtdpk_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            i_maxlength_makp = LibMedi.AccessData.i_maxlength_makp;
            bChinhanh = m.bQuanly_Theo_Chinhanh;
            bMoi_cu = m.bMoi_cu;
            user = m.user; itable = m.tableid("", "btdkp_bv");
			dtba=m.get_data("select * from "+user+".dmbenhan where loaiba=2 order by maba").Tables[0];
			maba.DataSource=dtba;
            maba.ValueMember = "MABA";
            maba.DisplayMember = "TENVT";

            //gam 22/09/2011
            dtdmkho = m.get_data("select * from " + user + ".d_dmkho order by ten").Tables[0];
            dmkho.DataSource = dtdmkho;
            dmkho.ValueMember = "ID";
            dmkho.DisplayMember = "TEN";
            //end gam

            mavp.DisplayMember="TEN";
			mavp.ValueMember="ID";
            mavp.DataSource = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

            mavptk.DisplayMember = "TEN";
            mavptk.ValueMember = "ID";
            mavptk.DataSource = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id order by b.stt,a.stt").Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + user + ".btdkp order by makp").Tables[0];//where makp<>'01' 

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

			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
		}

		private void load_grid()
		{
            string sql = "select a.makp,a.tenkp,b.tenkp as tenkpbo,a.makpbo,c.ten as tenvp,a.mavp,a.loaivp,a.mucvp,a.maba,a.viettat,d.ten as tenvptk,a.mavptk,a.loaicd,a.muccd, a.khu,a.tiemchung,a.kho,a.phongdv from " + user + ".btdkp_bv a inner join " + user + ".btdkp b on a.makpbo=b.makp left join " + user + ".v_giavp c on a.mavp=c.id left join " + user + ".v_giavp d on a.mavptk=d.id where a.loai=1 ";
            if (s_khudt.Trim().Trim(',') != "") sql += " and (a.khu=0 or a.khu in(" + s_khudt.Trim().Trim(',') + "))";
            if (i_chinhanh > 0) sql += " and chinhanh in(0," + i_chinhanh + ")";
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
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();//0
			TextCol.MappingName = "makp";
			TextCol.HeaderText = lan.Change_language_MessageText("Mã");
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//1
			TextCol.MappingName = "viettat";
			TextCol.HeaderText = lan.Change_language_MessageText("Viết tắt");
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//2
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = lan.Change_language_MessageText("Phòng khám");
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//3
			TextCol.MappingName = "tenkpbo";
			TextCol.HeaderText = lan.Change_language_MessageText("Khoa theo bộ");
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//4
			TextCol.MappingName = "makpbo";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//5
			TextCol.MappingName = "tenvp";
			TextCol.HeaderText = lan.Change_language_MessageText("Khám bệnh");
			TextCol.Width = 140;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//6
			TextCol.MappingName = "mavp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//7
			TextCol.MappingName = "loaivp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//8
			TextCol.MappingName = "mucvp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//9
			TextCol.MappingName = "maba";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//10
            TextCol.MappingName = "tenvptk";
            TextCol.HeaderText = lan.Change_language_MessageText("Tái khám");
            TextCol.Width = 140;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//11
            TextCol.MappingName = "mavptk";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//12
            TextCol.MappingName = "loaicd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//13
            TextCol.MappingName = "muccd";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//14
            TextCol.MappingName = "khu";
            TextCol.HeaderText = lan.Change_language_MessageText("CS");
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//15
            TextCol.MappingName = "tiemchung";
            TextCol.HeaderText = "tiemchung";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//16
            TextCol.MappingName = "kho";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();//17
            TextCol.MappingName = "phongdv";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
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
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ena_object(bool ena)
		{
			maba.Enabled=ena;
            dmkho.Enabled = ena;//gam 22/09/2011
            chkTiemchung.Enabled = ena;
			mavp.Enabled=ena;
            mavp_k.Enabled = ena;
            if (bMoi_cu) { mavptk.Enabled = ena; mavp_tk.Enabled = ena; }
            //if(m.bAdmin_hethong(i_userid))
            //    viettat.Enabled = ;
            viettat.Enabled = ena;//false;//
			ten.Enabled=ena;
			makp.Enabled=ena;
            khudt.Enabled = (khudt.Items.Count > 0) ? ena : false;
            chinhanh.Enabled = (chinhanh.Items.Count > 0) ? ena : false;
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
            int i = 1;
            DataRow r;
            string tmp_ma = "";
            if (bChinhanh == false)
            {
                dtkp = m.get_data("select * from " + user + ".btdkp_bv order by makp").Tables[0];                
                int imax = (i_maxlength_makp == 2) ? 100 : 1000;
                for (i = 1; i < imax; i++)
                {
                    tmp_ma = i.ToString().PadLeft(2, '0');
                    r = m.getrowbyid(dtkp, "makp='" + tmp_ma + "'");
                    if (r == null) break;
                }
            }
            //ma.Text = i.ToString().PadLeft(i_maxlength_makp, '0');
            ma.Text = tmp_ma;
            viettat.Text = ma.Text;
            s_loaivp = ""; s_mucvp = ""; ten.Text = ""; s_loaicd = ""; s_muccd = "";
			for(i=0;i<maba.Items.Count;i++) maba.SetItemCheckState(i,CheckState.Unchecked);
			ena_object(true);
            if (bChinhanh && chinhanh.Enabled && chinhanh.Items.Count > 0) chinhanh.Focus();
            else ten.Focus();
            chkTiemchung.Checked = false;
            // viettat.Focus();
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
            if (ten.Text == "")
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
			if (mavp.SelectedIndex==-1)
			{
				mavp.Focus();
				return false;
			}
            if (khudt.Items.Count > 0 && khudt.SelectedIndex < 0)
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
            //
            DataRow r;
            dtkp = m.get_data("select makp from " + user + ".btdkp_bv order by makp").Tables[0];
            int ii = 0, imax = 99;// (i_maxlength_makp == 2) ? 100 : 1000;
            r = m.getrowbyid(dtkp, "makp='" + ma.Text + "'");
            string tmp_ma = ma.Text.Trim() ;
            if (r == null || tmp_ma == "")
            {
                //MessageBox.Show(lan.Change_language_MessageText("Mã khoa này đã tồn tại, chương trình sẽ tự cấp mã mới."));
                for (ii = 1; ii < imax; ii++)
                {
                    if (bChinhanh)
                    {
                        i_chinhanh = (chinhanh.SelectedIndex < 0) ? 0 : int.Parse(chinhanh.SelectedValue.ToString());
                        if (i_chinhanh > 0)
                        {
                            tmp_ma = i_chinhanh.ToString() + ii.ToString().PadLeft(i_maxlength_makp - 1, '0');
                        }
                        else
                        {
                            tmp_ma = ii.ToString().PadLeft(i_maxlength_makp - 1, '0');
                        }
                        
                    }
                    else tmp_ma = ii.ToString().PadLeft(2, '0');
                    r = m.getrowbyid(dtkp, "makp='" + tmp_ma + "'");
                    if (r == null) break;
                }
                ma.Text = tmp_ma;
                viettat.Text = ma.Text;
            }
            //
			if (!kiemtra()) return ;
			string s_maba="";
			for(int i=0;i<maba.Items.Count;i++)
				if (maba.GetItemChecked(i)) s_maba+=dtba.Rows[i]["maba"].ToString().Trim()+",";
			if (s_maba!="") s_maba=s_maba.Substring(0,s_maba.Length-1);
            //gam 22/09/2011
            string s_dmkho = "";
            for (int i = 0; i < dmkho.Items.Count; i++)
                if (dmkho.GetItemChecked(i)) s_dmkho += dtdmkho.Rows[i]["id"].ToString().Trim() + ",";
            if (s_dmkho != "") s_dmkho = s_dmkho.Trim(',');
            //end gam

            i_khu = (khudt.Enabled == false || khudt.SelectedIndex < 0) ? 0 : int.Parse(khudt.SelectedValue.ToString());
            int tmp_chinhanh = (chinhanh.Enabled == false || chinhanh.SelectedIndex < 0) ? 0 : int.Parse(chinhanh.SelectedValue.ToString());
            if (!m.upd_btdkp_bv("btdkp_bv", ma.Text, ten.Text, 0, 0, makp.SelectedValue.ToString(), s_maba, 1, int.Parse(mavp.SelectedValue.ToString()), s_loaivp, s_mucvp, viettat.Text, s_loaicd, s_muccd, i_khu, tmp_chinhanh,chkTiemchung.Checked?1:0,s_dmkho,chkDichVu.Checked?1:0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật thông tin phòng khám !"));
				return;
			}
            if (bMoi_cu) m.execute_data("update " + user + ".btdkp_bv set mavptk=" + int.Parse(mavptk.SelectedValue.ToString()) + " where makp='" + ma.Text + "'");
            if (m.get_data("select * from " + user + ".btdkp_bv where makp='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + "0" + "^" + "0" + "^" + makp.SelectedValue.ToString() + "^" + s_maba + "^" + "1" + "^" + mavp.SelectedValue.ToString() + "^" + s_loaivp + "^" + s_mucvp + "^" + viettat.Text);
            }
            else m.upd_eve_tables(itable, i_userid, "ins");

            m.upd_btdkp_bv("btdkp_add", ma.Text, ten.Text, 0, 0, makp.SelectedValue.ToString(), s_maba, 1, int.Parse(mavp.SelectedValue.ToString()), s_loaivp, s_mucvp, viettat.Text, s_loaicd, s_muccd, i_khu, tmp_chinhanh, chkTiemchung.Checked ? 1 : 0, s_dmkho, chkDichVu.Checked ? 1 : 0);
            if (bMoi_cu) m.execute_data("update " + user + ".btdkp_add set mavptk=" + int.Parse(mavptk.SelectedValue.ToString()) + " where makp='" + ma.Text + "'");
			m.upd_dm01(int.Parse(ma.Text.ToString())+51,"-",ten.Text,"C",1,int.Parse(makp.SelectedValue.ToString())+12);
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
				MessageBox.Show(lan.Change_language_MessageText("Phòng khám đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".bieu_01 where ma-51=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Khoa đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_data("select * from " + user + ".bieu_02 where ma=" + int.Parse(ma.Text)).Tables[0].Rows.Count != 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phòng khám đã sử dụng không thể huỷ !"),LibMedi.AccessData.Msg);
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
				makp.SelectedValue=dataGrid1[i,4].ToString();
				mavp.SelectedValue=dataGrid1[i,6].ToString();
                
                mavp_k.Text = dataGrid1[i, 6].ToString();
				s_loaivp=dataGrid1[i,7].ToString();
				s_mucvp=dataGrid1[i,8].ToString();
				string s_maba=dataGrid1[i,9].ToString()+",";
                
				for(int j=0;j<maba.Items.Count;j++)
					if (s_maba.IndexOf(dtba.Rows[j]["maba"].ToString()+",")!=-1) maba.SetItemCheckState(j,CheckState.Checked);
					else maba.SetItemCheckState(j,CheckState.Unchecked);
                //gam 22/09/2011
                string s_dmkho = dataGrid1[i, 16].ToString() + ",";
                for (int j = 0; j < dmkho.Items.Count; j++)
                    if (s_dmkho.IndexOf(dtdmkho.Rows[j]["id"].ToString() + ",") != -1) dmkho.SetItemCheckState(j, CheckState.Checked);
                    else dmkho.SetItemCheckState(j, CheckState.Unchecked);
                //end gam

                mavptk.SelectedValue = dataGrid1[i, 11].ToString();
                mavp_tk.Text = dataGrid1[i, 11].ToString();
                s_loaicd = dataGrid1[i,12].ToString();
                s_muccd = dataGrid1[i, 13].ToString();
                chkTiemchung.Checked = dataGrid1[i, 15].ToString() == "0" ? false : true;
                chkDichVu.Checked = dataGrid1[i, 17].ToString() == "0" ? false : true;
                i_khu = (dataGrid1[i, 14].ToString().Trim() == "") ? 0 : int.Parse(dataGrid1[i, 14].ToString());
                khudt.SelectedValue = i_khu;
			}
			catch(Exception ex){}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			ten.Text=m.Caps(ten.Text);
		}

		private void frmBtdpk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mavp.SelectedIndex==-1) mavp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
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

		private void maba_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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

        private void mavptk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (mavptk.SelectedIndex == -1) mavptk.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
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

        private void mavptk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mavptk.SelectedIndex>=0)mavp_tk.Text = mavptk.SelectedValue.ToString();
        }

        private void mavp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mavp.SelectedIndex >= 0) mavp_k.Text = mavp.SelectedValue.ToString();
        }

        private void mavp_tk_Validated(object sender, EventArgs e)
        {
            try
            {
                mavptk.SelectedValue = mavp_tk.Text;
            }
            catch { }
        }

        private void mavp_k_Validated(object sender, EventArgs e)
        {
            try
            {
                mavp.SelectedValue = mavp_k.Text;
            }
            catch { }
        }

        private void khudt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
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

        private void butMoi_Enter(object sender, EventArgs e)
        {

        }

        private void tim_Enter(object sender, EventArgs e)
        {
            if (tim.Text.Trim() == "Tìm kiếm") { tim.Text = ""; return; }
        }
       
	}
}
