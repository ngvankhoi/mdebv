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
	/// Summary description for frmTkvaovien.
	/// </summary>
	public class frmTimkiem : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maphuongxa;
		private MaskedTextBox.MaskedTextBox mabn;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox sonha;
		private MaskedTextBox.MaskedTextBox thon;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataSet dstt=new DataSet();
		private AccessData m;
        private bool bClear = true;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private MaskedTextBox.MaskedTextBox coquan;
		private MaskedTextBox.MaskedTextBox didong;
		private MaskedTextBox.MaskedTextBox email;
		private MaskedTextBox.MaskedTextBox nha;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.Label label6;
        private string user,sUserid, sMaDoiTuong;
        public string sMabn="";
        private bool bChon = false,bSoVaoVien,bSoLuuTru,bRight;
        private Button butOk;
        private int iUserid,iMabv ;
        private Label label1;
        private Label label2;
        private MaskedBox.MaskedBox den;
        private MaskedBox.MaskedBox tu;
        private TextBox txtTim;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTimkiem(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);tv.GanBogo(this, textBox111);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmTimkiem(AccessData acc, string hoten, int userid, int mabv, bool sovaovien, bool soluutru, string _madoituong, bool _right, bool chon)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            bChon = chon; sUserid = hoten; iUserid = userid; iMabv = mabv; bSoVaoVien = sovaovien;
            bSoLuuTru = soluutru; sMaDoiTuong = _madoituong; bRight = _right;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimkiem));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mann = new System.Windows.Forms.ComboBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maphuongxa = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.thon = new MaskedTextBox.MaskedTextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.coquan = new MaskedTextBox.MaskedTextBox();
            this.didong = new MaskedTextBox.MaskedTextBox();
            this.email = new MaskedTextBox.MaskedTextBox();
            this.nha = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.madantoc = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(31, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(221, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(432, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Năm sinh :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(15, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giới tính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(198, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số nhà :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(424, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Thôn, phố :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mann
            // 
            this.mann.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(672, 70);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(112, 21);
            this.mann.TabIndex = 13;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(79, 70);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(128, 21);
            this.maqu.TabIndex = 10;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(672, 48);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(112, 21);
            this.matt.TabIndex = 9;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(267, 70);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(161, 21);
            this.maphuongxa.TabIndex = 11;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(199, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Ph/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(-1, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(618, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(595, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "N. nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(79, 26);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(128, 21);
            this.mabn.TabIndex = 2;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.TextChanged += new System.EventHandler(this.mabn_TextChanged);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(267, 26);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(161, 21);
            this.hoten.TabIndex = 3;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(79, 48);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(128, 21);
            this.phai.TabIndex = 6;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(267, 48);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(161, 21);
            this.sonha.TabIndex = 7;
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(494, 48);
            this.thon.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thon.MaxLength = 50;
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(115, 21);
            this.thon.TabIndex = 8;
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 118);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(416, 343);
            this.dataGrid1.TabIndex = 18;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(355, 488);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 18;
            this.butTim.Text = "    &Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(425, 488);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(494, 26);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(115, 21);
            this.namsinh.TabIndex = 4;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(436, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 23);
            this.label15.TabIndex = 94;
            this.label15.Text = "Cơ quan :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(612, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Di động :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(23, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 23);
            this.label21.TabIndex = 96;
            this.label21.Text = "Email :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // coquan
            // 
            this.coquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.coquan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.coquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coquan.Location = new System.Drawing.Point(494, 92);
            this.coquan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.coquan.MaxLength = 50;
            this.coquan.Name = "coquan";
            this.coquan.Size = new System.Drawing.Size(115, 21);
            this.coquan.TabIndex = 16;
            this.coquan.TextChanged += new System.EventHandler(this.coquan_TextChanged);
            // 
            // didong
            // 
            this.didong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.didong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.didong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.didong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.didong.Location = new System.Drawing.Point(672, 92);
            this.didong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.didong.MaxLength = 50;
            this.didong.Name = "didong";
            this.didong.Size = new System.Drawing.Size(112, 21);
            this.didong.TabIndex = 17;
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(79, 92);
            this.email.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.email.MaxLength = 50;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(128, 21);
            this.email.TabIndex = 14;
            // 
            // nha
            // 
            this.nha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nha.Location = new System.Drawing.Point(267, 92);
            this.nha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nha.MaxLength = 50;
            this.nha.Name = "nha";
            this.nha.Size = new System.Drawing.Size(161, 21);
            this.nha.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(211, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 23);
            this.label14.TabIndex = 93;
            this.label14.Text = "ĐT nhà :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid2.Location = new System.Drawing.Point(432, 97);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(352, 364);
            this.dataGrid2.TabIndex = 19;
            this.dataGrid2.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid2_Navigate);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(494, 70);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(115, 21);
            this.madantoc.TabIndex = 12;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(440, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 103;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dotuoi
            // 
            this.dotuoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(672, 26);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(64, 21);
            this.dotuoi.TabIndex = 5;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(632, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 23);
            this.label6.TabIndex = 105;
            this.label6.Text = "Tuổi :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butOk
            // 
            this.butOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(285, 488);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 106;
            this.butOk.Text = "     &Chọn";
            this.butOk.Visible = false;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(230, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(268, 3);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(79, 3);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(87, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(8, 116);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(418, 20);
            this.txtTim.TabIndex = 107;
            this.txtTim.Text = "Tìm kiếm";
            this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // frmTimkiem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.email);
            this.Controls.Add(this.didong);
            this.Controls.Add(this.coquan);
            this.Controls.Add(this.nha);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimkiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm thông tin người bệnh";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTimkiem_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTimkiem_KeyDown);
            this.Load += new System.EventHandler(this.frmTimkiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTimkiem_Load(object sender, System.EventArgs e)
		{
			if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			DataSet dsd=new DataSet();
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dsd.ReadXml("..//..//..//xml//dotuoi.xml");
			dotuoi.DataSource=dsd.Tables[0];

			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
			mann.DataSource=m.get_data("select * from "+user+".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
            madantoc.DataSource = m.get_data("select * from " + user + ".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + user + ".btdtt order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();

			dstt.ReadXml("..//..//..//xml//m_ttnguoibenh.xml");
            ds = m.get_data("select * from " + user + ".capid where ma=0");
			dataGrid2.DataSource=dstt.Tables[0];
			AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
		            AddGridTableStyle1();
			lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
			//
            tu.Text = DateTime.Now.Date.AddDays(-90).ToString("dd/MM/yyyy");// m.Ngayhienhanh;
            den.Text = m.ngayhienhanh_server.Substring(0, 10);
            if (bChon)
            {
                butOk.Visible = true;
            }
		}


		private void emp_text()
		{
			madantoc.SelectedIndex=-1;
			mann.SelectedIndex=-1;
			matt.SelectedIndex=-1;
			maqu.SelectedIndex=-1;
			maphuongxa.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
                maqu.DataSource = m.get_data("select * from " + user + ".btdquan where matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
                maphuongxa.DataSource = m.get_data("select * from " + user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
			}
			catch{}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void mann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maqu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maphuongxa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
            //if (tu.Text=="") 
            //{
            //    den.Text="";
            //    return;
            //}
            //tu.Text=tu.Text.Trim();
            //if (!m.bNgay(tu.Text))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
            //    tu.Focus();
            //    return;
            //}
            //tu.Text=m.Ktngaygio(tu.Text,10);
            //den.Text=tu.Text;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
            //if (den.Text=="") 
            //{
            //    tu.Text="";
            //    return;
            //}
            //den.Text=den.Text.Trim();
            //if (!m.bNgay(den.Text))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
            //    den.Focus();
            //    return;
            //}
            //den.Text=m.Ktngaygio(den.Text,10);
            //if (tu.Text=="")
            //{
            //    tu.Focus();
            //    return;
            //}
            //if (!m.bNgay(den.Text,tu.Text))
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
            //    den.Focus();
            //    return;
            //}
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			dataGrid1.DataSource=null;
			dataGrid2.DataSource=null;
            ds = m.get_Timkiem(mabn.Text, hoten.Text, "", namsinh.Text, phai.SelectedIndex, sonha.Text, thon.Text,
                (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" : dotuoi.SelectedValue.ToString(), nha.Text, coquan.Text, didong.Text, email.Text, tu.Text, den.Text);
			dataGrid1.DataSource=ds.Tables[0];
			if (ds.Tables[0].Rows.Count==1) load_chitiet();
			Cursor=Cursors.Default;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
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
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "N.Sinh";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sonha";
			TextCol.HeaderText = "Số nhà";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thon";
			TextCol.HeaderText = "Thôn đường";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpxa";
			TextCol.HeaderText = "Phường/Xã";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenquan";
			TextCol.HeaderText = "Quận/Huyện";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tentt";
			TextCol.HeaderText = "Tỉnh/Thành phố";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennn";
			TextCol.HeaderText = "Nghề nghiệp";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nha";
			TextCol.HeaderText = "ĐT nhà";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "coquan";
			TextCol.HeaderText = "ĐT Cơ quan";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "didong";
			TextCol.HeaderText = "ĐT Di động";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "email";
			TextCol.HeaderText = "Email";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nam";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dstt.Tables[0].TableName;
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
			TextCol.MappingName = "tinhtrang";
			TextCol.HeaderText = "Tình trạng";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa/phòng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giuong";
			TextCol.HeaderText = "Ph/Gi";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sỹ";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_quan();
		}

		private void maqu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			load_pxa();
		}

		private void frmTimkiem_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTimkiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="" &&namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
            if (this.ActiveControl == dataGrid1)
            {
                load_chitiet();
                sMabn = dataGrid1[dataGrid1.CurrentCell.RowNumber, 0].ToString();
            }
		}

		private void load_chitiet()
		{
			Cursor=Cursors.WaitCursor;
			try
			{
				dstt=m.get_chitiet(dstt,dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString(),dataGrid1[dataGrid1.CurrentCell.RowNumber,13].ToString(),tu.Text,den.Text);
				dataGrid2.DataSource=dstt.Tables[0];
			}
			catch{}
			Cursor=Cursors.Default;
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
            string sql = "select * from " + user + ".btdbn where mabn='" + mabn.Text + "'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				//sonha.Text=r["sonha"].ToString();
				//thon.Text=r["thon"].ToString();
				mann.SelectedValue=r["mann"].ToString();
				madantoc.SelectedValue=r["madantoc"].ToString();
				matt.SelectedValue=r["matt"].ToString();
				load_quan();
				maqu.SelectedValue=r["maqu"].ToString();
				load_pxa();
				maphuongxa.SelectedValue=r["maphuongxa"].ToString();
				break;
			}
		}

        private void dataGrid2_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void phai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void coquan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void mabn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (sMabn == "")
            {
                return;
            }
            else
            {
                m.close(); this.Close();
                
                //frmKhambenh f = new frmKhambenh(m, "", sUserid, iUserid, iMabv, bSoVaoVien, bSoLuuTru, sMaDoiTuong, "", "", bRight, 0, sMabn.Substring(0, 2), sMabn.Substring(2));
                //f.ShowDialog();
            }
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text == "") txtTim.Text = "Tìm kiếm";
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtTim)
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    if (txtTim.Text != "")
                        dv.RowFilter = "hoten like '%" + txtTim.Text.Trim() + "%' or mabn like '%" + txtTim.Text.Trim() + "%'";
                    else
                        dv.RowFilter = "";
                }
                catch { }
            }	
        }

	}
}
