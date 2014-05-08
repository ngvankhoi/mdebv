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
	public class frmTkvaokhoa : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox madantoc;
		private System.Windows.Forms.ComboBox mann;
		private System.Windows.Forms.ComboBox maqu;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maphuongxa;
		private MaskedTextBox.MaskedTextBox mabn;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox sonha;
		private MaskedTextBox.MaskedTextBox thon;
		private System.Windows.Forms.ComboBox dentu;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.ComboBox nhantu;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox makp;
		private MaskedTextBox.MaskedTextBox sovaovien;
		private MaskedTextBox.MaskedTextBox maicd;
		private DataSet ds=new DataSet();
		private AccessData m;
		private bool bClear=true;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkmaicd;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.ComboBox noichuyen;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox nguoidung;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox time;
        private Label label2;
        private Label label4;
        private MaskedTextBox.MaskedTextBox sothe;
		private System.ComponentModel.IContainer components;

		public frmTkvaokhoa(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkvaokhoa));
            this.label3 = new System.Windows.Forms.Label();
            this.madantoc = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.ComboBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maphuongxa = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.ComboBox();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.thon = new MaskedTextBox.MaskedTextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.dentu = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.nhantu = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkmaicd = new System.Windows.Forms.CheckBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.noichuyen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nguoidung = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(24, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(69, 86);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(111, 21);
            this.madantoc.TabIndex = 10;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(673, 62);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(113, 21);
            this.mann.TabIndex = 9;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(251, 110);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(142, 21);
            this.maqu.TabIndex = 15;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(67, 110);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(113, 21);
            this.matt.TabIndex = 14;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(251, 134);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(143, 21);
            this.maphuongxa.TabIndex = 19;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(673, 110);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(113, 21);
            this.makp.TabIndex = 17;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(69, 39);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(111, 21);
            this.mabn.TabIndex = 2;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(251, 39);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(143, 21);
            this.hoten.TabIndex = 3;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(69, 62);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(111, 21);
            this.phai.TabIndex = 6;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(251, 62);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(143, 21);
            this.sonha.TabIndex = 7;
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(467, 62);
            this.thon.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thon.MaxLength = 50;
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(132, 21);
            this.thon.TabIndex = 8;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(467, 110);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(132, 21);
            this.sovaovien.TabIndex = 16;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(69, 134);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(93, 21);
            this.maicd.TabIndex = 18;
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(467, 134);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(132, 21);
            this.dentu.TabIndex = 20;
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(251, 86);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(143, 21);
            this.madoituong.TabIndex = 11;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(251, 158);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(143, 21);
            this.nhantu.TabIndex = 22;
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 181);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 344);
            this.dataGrid1.TabIndex = 24;
            // 
            // butTim
            // 
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(291, 536);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 23;
            this.butTim.Text = "     &Tìm";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(361, 536);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 24;
            this.butIn.Text = "     &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(431, 536);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 25;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(8, 536);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(232, 23);
            this.lbl.TabIndex = 65;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(174, 86);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 23);
            this.label22.TabIndex = 63;
            this.label22.Text = "Đối tượng :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(16, 86);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 23);
            this.label23.TabIndex = 56;
            this.label23.Text = "Dân tộc :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(397, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 23);
            this.label24.TabIndex = 8;
            this.label24.Text = "Thôn, phố :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(8, 62);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 6;
            this.label25.Text = "Giới tính :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(601, 110);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(74, 23);
            this.label26.TabIndex = 57;
            this.label26.Text = "Khoa :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(275, 15);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 23);
            this.label27.TabIndex = 1;
            this.label27.Text = "đến :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(389, 110);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(75, 23);
            this.label28.TabIndex = 59;
            this.label28.Text = "Số vào viện :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(174, 15);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 23);
            this.label29.TabIndex = 0;
            this.label29.Text = "Từ ngày :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(174, 62);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(80, 23);
            this.label30.TabIndex = 7;
            this.label30.Text = "Số nhà :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(16, 134);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 23);
            this.label31.TabIndex = 60;
            this.label31.Text = "Mã ICD :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(596, 86);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 23);
            this.label32.TabIndex = 53;
            this.label32.Text = "Khoa chuyển :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(174, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 23);
            this.label34.TabIndex = 3;
            this.label34.Text = "Họ tên :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(390, 132);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 23);
            this.label35.TabIndex = 61;
            this.label35.Text = "Nơi giới thiệu :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(174, 158);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 23);
            this.label37.TabIndex = 62;
            this.label37.Text = "Trực tiếp vào :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(601, 62);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(74, 23);
            this.label38.TabIndex = 49;
            this.label38.Text = "Nghề nghiệp :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkmaicd
            // 
            this.chkmaicd.Location = new System.Drawing.Point(164, 138);
            this.chkmaicd.Name = "chkmaicd";
            this.chkmaicd.Size = new System.Drawing.Size(16, 16);
            this.chkmaicd.TabIndex = 67;
            this.toolTip1.SetToolTip(this.chkmaicd, "Chọn thống kê theo danh sách ICD10");
            this.chkmaicd.CheckStateChanged += new System.EventHandler(this.chkmaicd_CheckStateChanged);
            this.chkmaicd.CheckedChanged += new System.EventHandler(this.chkmaicd_CheckedChanged);
            // 
            // ngaysinh
            // 
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(467, 39);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(132, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(347, 15);
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
            this.tu.Location = new System.Drawing.Point(251, 15);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // noichuyen
            // 
            this.noichuyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noichuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noichuyen.Location = new System.Drawing.Point(673, 86);
            this.noichuyen.Name = "noichuyen";
            this.noichuyen.Size = new System.Drawing.Size(113, 21);
            this.noichuyen.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(397, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(174, 134);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "P/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(196, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Q/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(-5, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dotuoi
            // 
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(673, 39);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(113, 21);
            this.dotuoi.TabIndex = 5;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(601, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 23);
            this.label6.TabIndex = 83;
            this.label6.Text = "Tuổi :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nguoidung
            // 
            this.nguoidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoidung.Location = new System.Drawing.Point(673, 134);
            this.nguoidung.Name = "nguoidung";
            this.nguoidung.Size = new System.Drawing.Size(113, 21);
            this.nguoidung.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(601, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 96;
            this.label1.Text = "Người nhập :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.WindowText;
            this.time.Location = new System.Drawing.Point(69, 21);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(53, 16);
            this.time.TabIndex = 94;
            this.time.Text = "checkBox1";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(-1, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 97;
            this.label2.Text = "Giờ báo cáo :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(407, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 110;
            this.label4.Text = "Số thẻ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(467, 86);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(132, 21);
            this.sothe.TabIndex = 12;
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            // 
            // frmTkvaokhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dentu);
            this.Controls.Add(this.nguoidung);
            this.Controls.Add(this.nhantu);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkmaicd);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.noichuyen);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label38);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkvaokhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bệnh nhân vào khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTkvaokhoa_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkvaokhoa_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTkvaokhoa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkvaokhoa_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			time.Text=m.sGiobaocao;
			nguoidung.DisplayMember="HOTEN";
			nguoidung.ValueMember="ID";
			nguoidung.DataSource=m.get_data("select * from "+m.user+".dlogin").Tables[0];
			DataSet dsd=new DataSet();
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dsd.ReadXml("..//..//..//xml//dotuoi.xml");
			dotuoi.DataSource=dsd.Tables[0];

			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            makp.DataSource = m.get_data("select * from " + m.user + ".btdkp_bv where loai=0 order by makp").Tables[0];

			noichuyen.DisplayMember="TENKP";
			noichuyen.ValueMember="MAKP";
            noichuyen.DataSource = m.get_data("select * from " + m.user + ".btdkp_bv where loai=0 order by makp").Tables[0];

			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
            mann.DataSource = m.get_data("select * from " + m.user + ".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
            madantoc.DataSource = m.get_data("select * from " + m.user + ".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
            matt.DataSource = m.get_data("select * from " + m.user + ".btdtt order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + m.user + ".doituong order by madoituong").Tables[0];

			nhantu.DisplayMember="TEN";
			nhantu.ValueMember="MA";
            nhantu.DataSource = m.get_data("select * from " + m.user + ".nhantu order by ma").Tables[0];

			dentu.DisplayMember="TEN";
			dentu.ValueMember="MA";
            dentu.DataSource = m.get_data("select * from " + m.user + ".dentu order by ma").Tables[0];

            ds = m.get_data("select * from " + m.user + ".capid where ma=0");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
		}


		private void emp_text()
		{
			nguoidung.SelectedIndex=-1;
			makp.SelectedIndex=-1;
			mann.SelectedIndex=-1;
			madantoc.SelectedIndex=-1;
			matt.SelectedIndex=-1;
			maqu.SelectedIndex=-1;
			maphuongxa.SelectedIndex=-1;
			madoituong.SelectedIndex=-1;
			nhantu.SelectedIndex=-1;
			dentu.SelectedIndex=-1;
			noichuyen.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
                maqu.DataSource = m.get_data("select * from " + m.user + ".btdquan where matt='" + matt.SelectedValue.ToString() + "'" + " order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
                maphuongxa.DataSource = m.get_data("select * from " + m.user + ".btdpxa where maqu='" + maqu.SelectedValue.ToString() + "'" + " order by maphuongxa").Tables[0];
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

		private void madantoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nhantu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dentu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (tu.Text=="")
			{
				den.Text="";
				return;
			}
			tu.Text=tu.Text.Trim();
			if (!m.bNgay(tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tu.Focus();
				return;
			}
			tu.Text=m.Ktngaygio(tu.Text,10);
			if (den.Text=="") den.Text=tu.Text;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="")
			{
				tu.Text="";
				return;
			}
			den.Text=den.Text.Trim();
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,10);
			if (tu.Text=="")
			{
				tu.Focus();
				return;
			}
			if (!m.bNgay(den.Text,tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
				den.Focus();
				return;
			}
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
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			int i_userid=(nguoidung.SelectedIndex==-1)?-1:int.Parse(nguoidung.SelectedValue.ToString());
			ds=m.get_Vaokhoa(tu.Text,den.Text,mabn.Text,hoten.Text,ngaysinh.Text,phai.SelectedIndex,sonha.Text,thon.Text,
				(mann.SelectedIndex==-1)?"":mann.SelectedValue.ToString(),(madantoc.SelectedIndex==-1)?"":madantoc.SelectedValue.ToString(),
				(matt.SelectedIndex==-1)?"":matt.SelectedValue.ToString(),(maqu.SelectedIndex==-1)?"":maqu.SelectedValue.ToString(),
				(maphuongxa.SelectedIndex==-1)?"":maphuongxa.SelectedValue.ToString(),(makp.SelectedIndex==-1)?"":makp.SelectedValue.ToString(),
				(noichuyen.SelectedIndex==-1)?"":noichuyen.SelectedValue.ToString(),sovaovien.Text,maicd.Text,(madoituong.SelectedIndex==-1)?"":madoituong.SelectedValue.ToString(),
				(dentu.SelectedIndex==-1)?"":dentu.SelectedValue.ToString(),
				(nhantu.SelectedIndex==-1)?"":nhantu.SelectedValue.ToString(),(dotuoi.SelectedIndex==-1)?"":dotuoi.SelectedValue.ToString(),chkmaicd.Checked,i_userid,time.Checked,sothe.Text);
            dataGrid1.DataSource = ds.Tables[0]; int i_counttongso = 0;
            string s_id = "";
            foreach (DataRow dr in ds.Tables[0].Select("", "id"))
            {
                if (s_id != dr["id"].ToString())
                {
                    i_counttongso += 1;
                    s_id = dr["id"].ToString();
                }
            }
            lbl.Text = lan.Change_language_MessageText("TỔNG SỐ : ") + i_counttongso.ToString();// +ds.Tables[0].Rows.Count.ToString();
			
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
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
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

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngaysinh";
            TextCol.HeaderText = "Ngày sinh";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tuoi";
			TextCol.HeaderText = "Tuổi";
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
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày giờ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "sothe";
            TextCol.HeaderText = "Số thẻ";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 250;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "ICD";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhantu";
			TextCol.HeaderText = "Trực tiếp vào";
			TextCol.Width =80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dentu";
			TextCol.HeaderText = "Nơi giới thiệu";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "noichuyen";
			TextCol.HeaderText = "Khoa chuyển đến";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giuong";
			TextCol.HeaderText = "Giường";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenuser";
			TextCol.HeaderText = "Người nhập";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
					return;
				}
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,this.Text.ToUpper(),"rptTkvaokhoa.rpt");
				f.ShowDialog();
			}
			catch{}

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

		private void frmTkvaokhoa_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTkvaokhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void chkmaicd_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (chkmaicd.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách ICD10 không ?"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmmaicd f=new frmDmmaicd(m);
					f.ShowDialog();
				}
			}
		}

		private void dotuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chkmaicd_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

        private void sothe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void madoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (madoituong.SelectedValue != null)
            {
                if (madoituong.SelectedValue.ToString() == "1")
                {
                    sothe.Enabled = true;
                }
                else
                {
                    sothe.Enabled = false;
                }
            }
        }
	}
}
