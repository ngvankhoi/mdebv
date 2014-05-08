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
	public class frmTkdangky : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label20;
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
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
		private AccessData m;
        private string user;
        private bool bClear = true, bAdmin_hethong = false;
        private decimal l_maql = 0;
        private int i_userid = 0, i_khudt = 0, i_chinhanh = 0;
        private string s_tenbn = "", sql = "";
		private System.Windows.Forms.Label lbl;
		private DataTable dtkp=new DataTable();
		private MaskedBox.MaskedBox tu;
		private MaskedBox.MaskedBox den;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckedListBox makp;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label12;
		private MaskedTextBox.MaskedTextBox sothe;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox nguoidung;
        private System.Windows.Forms.CheckBox time;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private MaskedTextBox.MaskedTextBox nha;
		private MaskedTextBox.MaskedTextBox coquan;
		private MaskedTextBox.MaskedTextBox didong;
		private MaskedTextBox.MaskedTextBox email;
		private System.Windows.Forms.ComboBox mabs;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ComboBox bnmoi;
		private System.Windows.Forms.Label l_bnmoi;
        private Label label22;
        private ComboBox traituyen;
        private Button butChuyenchuakham;
        private TextBox txtmabn_ck;
        private Label label14;
        private CheckBox chkktrabntrungthe;
        private GroupBox groupBox1;
        private RadioButton rb2;
        private RadioButton rb1;
        private ComboBox cmbBSGT;
        private Label label24;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTkdangky(AccessData acc, int userid,int _khudieutri, int _chinhanh)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            i_userid = userid;
            i_khudt = _khudieutri;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkdangky));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.madantoc = new System.Windows.Forms.ComboBox();
            this.mann = new System.Windows.Forms.ComboBox();
            this.maqu = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maphuongxa = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.thon = new MaskedTextBox.MaskedTextBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.tu = new MaskedBox.MaskedBox();
            this.den = new MaskedBox.MaskedBox();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.nguoidung = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.nha = new MaskedTextBox.MaskedTextBox();
            this.coquan = new MaskedTextBox.MaskedTextBox();
            this.didong = new MaskedTextBox.MaskedTextBox();
            this.email = new MaskedTextBox.MaskedTextBox();
            this.mabs = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.traituyen = new System.Windows.Forms.ComboBox();
            this.butChuyenchuakham = new System.Windows.Forms.Button();
            this.txtmabn_ck = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkktrabntrungthe = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.cmbBSGT = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(-3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(115, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(216, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(318, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(511, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Năm sinh :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(80, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Phái :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(171, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số nhà :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(398, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Thôn, phố :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(242, 73);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(152, 21);
            this.madantoc.TabIndex = 13;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(59, 51);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(118, 21);
            this.mann.TabIndex = 9;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(469, 51);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(139, 21);
            this.maqu.TabIndex = 11;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(242, 51);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(152, 21);
            this.matt.TabIndex = 10;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(59, 73);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(118, 21);
            this.maphuongxa.TabIndex = 12;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(-3, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Ph/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(390, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(188, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(-19, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "N. nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(188, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 56;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(406, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 63;
            this.label20.Text = "Đối tượng :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(264, 5);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 2;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(365, 5);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(154, 21);
            this.hoten.TabIndex = 3;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(137, 29);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(40, 21);
            this.phai.TabIndex = 6;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(242, 29);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(151, 21);
            this.sonha.TabIndex = 7;
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(469, 29);
            this.thon.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thon.MaxLength = 50;
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(139, 21);
            this.thon.TabIndex = 8;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownWidth = 150;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(469, 73);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(85, 21);
            this.madoituong.TabIndex = 14;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 165);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 354);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(240, 538);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 21;
            this.butTim.Text = "    &Tìm";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(313, 538);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 22;
            this.butIn.Text = "    &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(385, 538);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 23;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(5, 538);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(234, 23);
            this.lbl.TabIndex = 65;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(59, 6);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(155, 5);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // dotuoi
            // 
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(59, 29);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(49, 21);
            this.dotuoi.TabIndex = 5;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(8, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 23);
            this.label6.TabIndex = 68;
            this.label6.Text = "Tuổi  :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.HorizontalScrollbar = true;
            this.makp.Location = new System.Drawing.Point(614, 27);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(170, 132);
            this.makp.TabIndex = 69;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(575, 5);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 4;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(16, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 23);
            this.label12.TabIndex = 71;
            this.label12.Text = "Số thẻ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(59, 95);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(118, 21);
            this.sothe.TabIndex = 15;
            // 
            // nguoidung
            // 
            this.nguoidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoidung.Location = new System.Drawing.Point(242, 95);
            this.nguoidung.Name = "nguoidung";
            this.nguoidung.Size = new System.Drawing.Size(152, 21);
            this.nguoidung.TabIndex = 16;
            this.nguoidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(164, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 23);
            this.label13.TabIndex = 73;
            this.label13.Text = "N.dùng :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.time.Location = new System.Drawing.Point(613, 5);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(57, 16);
            this.time.TabIndex = 92;
            this.time.Text = "checkBox1";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(159, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 94;
            this.label15.Text = "Cơ quan :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(407, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Di động :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(5, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 23);
            this.label21.TabIndex = 96;
            this.label21.Text = "Email :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // nha
            // 
            this.nha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nha.Location = new System.Drawing.Point(59, 117);
            this.nha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nha.MaxLength = 50;
            this.nha.Name = "nha";
            this.nha.Size = new System.Drawing.Size(118, 21);
            this.nha.TabIndex = 97;
            // 
            // coquan
            // 
            this.coquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.coquan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.coquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coquan.Location = new System.Drawing.Point(242, 117);
            this.coquan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.coquan.MaxLength = 50;
            this.coquan.Name = "coquan";
            this.coquan.Size = new System.Drawing.Size(152, 21);
            this.coquan.TabIndex = 98;
            // 
            // didong
            // 
            this.didong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.didong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.didong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.didong.Location = new System.Drawing.Point(469, 117);
            this.didong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.didong.MaxLength = 50;
            this.didong.Name = "didong";
            this.didong.Size = new System.Drawing.Size(139, 21);
            this.didong.TabIndex = 99;
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.email.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(59, 139);
            this.email.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.email.MaxLength = 50;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(118, 21);
            this.email.TabIndex = 100;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(469, 95);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(139, 21);
            this.mabs.TabIndex = 102;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(414, 95);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 23);
            this.label23.TabIndex = 101;
            this.label23.Text = "Bác sĩ :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(242, 139);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(152, 21);
            this.loai.TabIndex = 249;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(178, 139);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 23);
            this.label34.TabIndex = 252;
            this.label34.Text = "Khám :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnmoi
            // 
            this.bnmoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bnmoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnmoi.Items.AddRange(new object[] {
            "Mới",
            "Cũ"});
            this.bnmoi.Location = new System.Drawing.Point(469, 139);
            this.bnmoi.Name = "bnmoi";
            this.bnmoi.Size = new System.Drawing.Size(139, 21);
            this.bnmoi.TabIndex = 250;
            // 
            // l_bnmoi
            // 
            this.l_bnmoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_bnmoi.Location = new System.Drawing.Point(382, 139);
            this.l_bnmoi.Name = "l_bnmoi";
            this.l_bnmoi.Size = new System.Drawing.Size(88, 23);
            this.l_bnmoi.TabIndex = 251;
            this.l_bnmoi.Text = "Người bệnh :";
            this.l_bnmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(-18, 115);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 23);
            this.label22.TabIndex = 253;
            this.label22.Text = "ĐT nhà :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // traituyen
            // 
            this.traituyen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.traituyen.DropDownWidth = 100;
            this.traituyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traituyen.Items.AddRange(new object[] {
            "",
            "Đúng tuyến",
            "Trái tuyến"});
            this.traituyen.Location = new System.Drawing.Point(557, 73);
            this.traituyen.Name = "traituyen";
            this.traituyen.Size = new System.Drawing.Size(51, 21);
            this.traituyen.TabIndex = 254;
            // 
            // butChuyenchuakham
            // 
            this.butChuyenchuakham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butChuyenchuakham.BackColor = System.Drawing.Color.Transparent;
            this.butChuyenchuakham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChuyenchuakham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butChuyenchuakham.Location = new System.Drawing.Point(457, 538);
            this.butChuyenchuakham.Name = "butChuyenchuakham";
            this.butChuyenchuakham.Size = new System.Drawing.Size(126, 25);
            this.butChuyenchuakham.TabIndex = 255;
            this.butChuyenchuakham.Text = "Chuyển chưa khám";
            this.butChuyenchuakham.UseVisualStyleBackColor = false;
            this.butChuyenchuakham.Click += new System.EventHandler(this.butChuyenchuakham_Click);
            // 
            // txtmabn_ck
            // 
            this.txtmabn_ck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmabn_ck.Location = new System.Drawing.Point(77, 475);
            this.txtmabn_ck.Name = "txtmabn_ck";
            this.txtmabn_ck.Size = new System.Drawing.Size(100, 20);
            this.txtmabn_ck.TabIndex = 256;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(23, 475);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 23);
            this.label14.TabIndex = 257;
            this.label14.Text = "Mã BN :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkktrabntrungthe
            // 
            this.chkktrabntrungthe.AutoSize = true;
            this.chkktrabntrungthe.Location = new System.Drawing.Point(59, 166);
            this.chkktrabntrungthe.Name = "chkktrabntrungthe";
            this.chkktrabntrungthe.Size = new System.Drawing.Size(159, 17);
            this.chkktrabntrungthe.TabIndex = 258;
            this.chkktrabntrungthe.Text = "Kiểm tra BN trùng thẻ BHYT";
            this.chkktrabntrungthe.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(589, 528);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 35);
            this.groupBox1.TabIndex = 260;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xem theo";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(132, 16);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(58, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Mã BN";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(9, 16);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(117, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Lượt đăng kí khám";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // cmbBSGT
            // 
            this.cmbBSGT.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbBSGT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBSGT.Items.AddRange(new object[] {
            "Mới",
            "Cũ"});
            this.cmbBSGT.Location = new System.Drawing.Point(468, 161);
            this.cmbBSGT.Name = "cmbBSGT";
            this.cmbBSGT.Size = new System.Drawing.Size(139, 21);
            this.cmbBSGT.TabIndex = 261;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(382, 160);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 23);
            this.label24.TabIndex = 262;
            this.label24.Text = "Bác sỹ giới thiệu:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTkdangky
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmbBSGT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkktrabntrungthe);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtmabn_ck);
            this.Controls.Add(this.butChuyenchuakham);
            this.Controls.Add(this.traituyen);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.nha);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.bnmoi);
            this.Controls.Add(this.l_bnmoi);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.email);
            this.Controls.Add(this.didong);
            this.Controls.Add(this.coquan);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.time);
            this.Controls.Add(this.nguoidung);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkdangky";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bệnh nhân đăng ký khám bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTkdangky_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkdangky_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTkdangky_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkdangky_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
			time.Text=m.sGiobaocao;
			DataSet dsd=new DataSet();
			dotuoi.DisplayMember="ten";
			dotuoi.ValueMember="ma";
			dsd.ReadXml("..//..//..//xml//dotuoi.xml");
			dotuoi.DataSource=dsd.Tables[0];

			dsloai.ReadXml("..//..//..//xml//m_loai.xml");
			dsbnmoi.ReadXml("..//..//..//xml//m_bnmoi.xml");
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=dsloai.Tables[0];
			bnmoi.DisplayMember="TEN";
			bnmoi.ValueMember="ID";
			bnmoi.DataSource=dsbnmoi.Tables[0];
            sql = "select * from " + user + ".btdkp_bv where loai=1 ";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            sql += " and chinhanh in(0," + i_chinhanh + ")";
            sql += " order by makp";
			dtkp=m.get_data(sql).Tables[0];
			makp.DataSource=dtkp;
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";

			mabs.DisplayMember="HOTEN";
			mabs.ValueMember="MA";
			mabs.DataSource=m.get_data("select * from "+user+".dmbs order by ma").Tables[0];

			mann.DisplayMember="TENNN";
			mann.ValueMember="MANN";
			mann.DataSource=m.get_data("select * from "+user+".btdnn_bv order by mann").Tables[0];

			madantoc.DisplayMember="DANTOC";
			madantoc.ValueMember="MADANTOC";
			madantoc.DataSource=m.get_data("select * from "+user+".btddt order by madantoc").Tables[0];

			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
			matt.DataSource=m.get_data("select * from "+user+".btdtt order by matt").Tables[0];

			maqu.DisplayMember="TENQUAN";
			maqu.ValueMember="MAQU";
			
			maphuongxa.DisplayMember="TENPXA";
			maphuongxa.ValueMember="MAPHUONGXA";

			load_quan();
			load_pxa();

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=m.get_data("select * from "+user+".doituong order by madoituong").Tables[0];
	
			ds=m.get_data("select * from "+user+".capid where ma=0");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			//
			nguoidung.DisplayMember="HOTEN";
			nguoidung.ValueMember="ID";
			nguoidung.DataSource=m.get_data("select * from "+user+".dlogin").Tables[0];

			tu.Text=m.Ngayhienhanh;
			den.Text=tu.Text;

            bAdmin_hethong = m.bAdminHethong(i_userid);
            visible_bnchokham(false);
		}


		private void emp_text()
		{
			//makp.SelectedIndex=-1;
			nguoidung.SelectedIndex=-1;
			mann.SelectedIndex=-1;
			madantoc.SelectedIndex=-1;
			matt.SelectedIndex=-1;
			maqu.SelectedIndex=-1;
			maphuongxa.SelectedIndex=-1;
			madoituong.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
			mabs.SelectedIndex=-1;
			loai.SelectedIndex=-1;
			bnmoi.SelectedIndex=-1;
		}

		private void load_quan()
		{
			try
			{
				maqu.DataSource=m.get_data("select * from "+user+".btdquan where matt='"+matt.SelectedValue.ToString()+"'"+" order by maqu").Tables[0];
			}
			catch{}
		}

		private void load_pxa()
		{
			try
			{
				maphuongxa.DataSource=m.get_data("select * from "+user+".btdpxa where maqu='"+maqu.SelectedValue.ToString()+"'"+" order by maphuongxa").Tables[0];
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
            if (tu.Text.Length == 6) tu.Text = tu.Text + DateTime.Now.Year.ToString();
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
            den.Text = den.Text.Trim();
            if (den.Text.Length == 6) den.Text = den.Text + DateTime.Now.Year.ToString();
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

		private void butTim_Click(object sender, System.EventArgs e)
		{
            if (tu.Text.Length != 10 || den.Text.Length != 10)
            {
                tu.Focus();
                return;
            }
			string s_makp="'";dataGrid1.DataSource=null;
			for(int i=0;i<makp.Items.Count;i++)
			if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString()+"','";
			if (s_makp.Length>1) s_makp="("+s_makp.Substring(0,s_makp.Length-2)+")";
            else s_makp="";
			int i_userid=(nguoidung.SelectedIndex==-1)?-1:int.Parse(nguoidung.SelectedValue.ToString());
            int i_traituyen = (traituyen.Enabled) ? -1 : (traituyen.SelectedIndex - 1);
            ds = m.get_Tiepdon(tu.Text, den.Text, mabn.Text, hoten.Text.Replace("'", "''"), namsinh.Text, phai.SelectedIndex, sonha.Text, thon.Text.Replace("'", "''"),
                 (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                 (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                 (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), s_makp,
                 (madoituong.SelectedIndex == -1) ? "" : madoituong.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" : dotuoi.SelectedValue.ToString(),
                 sothe.Text.Trim(), i_userid, time.Checked, nha.Text, coquan.Text, didong.Text, email.Text, (mabs.SelectedIndex != -1) ? mabs.SelectedValue.ToString() : "",
                 loai.SelectedIndex, bnmoi.SelectedIndex, i_traituyen, i_chinhanh, chkktrabntrungthe.Checked, (rb1.Checked) ? 1 : 2);
            
            dataGrid1.DataSource = ds.Tables[0];
            lbl.Text = lan.Change_language_MessageText("TỔNG SỐ : ") + ds.Tables[0].Rows.Count.ToString();
            //else
            //{
                //DataSet ds1 = ds.Clone();
                //string s_sothe="",s_mabn="";
                //DataRow dr;
                //foreach (DataRow r in ds.Tables[0].Rows)
                //{
                //    DataRow r1 = m.getrowbyid(ds.Tables[0], "sothe='" + s_sothe + "' and mabn<>'" + s_mabn + "'");
                //    if (r1 != null)
                //    {
                //        ds1.Tables[0].ImportRow(r1);
                //    }
                //    s_sothe = r["sothe"].ToString();
                //    s_mabn = r["mabn"].ToString();
                //}
                //dataGrid1.DataSource = ds1.Tables[0];
                //lbl.Text = lan.Change_language_MessageText("TỔNG SỐ : ") + ds1.Tables[0].Rows.Count.ToString();
            //}
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
			TextCol.HeaderText = "Phòng khám";
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

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "N.Sinh";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 120;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sonha";
			TextCol.HeaderText = "Số nhà";
			TextCol.Width = 50;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thon";
			TextCol.HeaderText = "Thôn đường";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
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
            TextCol.NullText = string.Empty;
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
			TextCol.Width = 60;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sovaovien";
			TextCol.HeaderText = "Số phiếu";
			TextCol.Width = 60;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nha";
			TextCol.HeaderText = "ĐT nhà";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "coquan";
			TextCol.HeaderText = "ĐT Cơ quan";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "didong";
			TextCol.HeaderText = "ĐT Di động";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "email";
			TextCol.HeaderText = "Email";
			TextCol.Width = 150;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sỹ";
			TextCol.Width = 150;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngaysanh";
			TextCol.HeaderText = "Ngày sanh dự đoán";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenuser";
			TextCol.HeaderText = "Người nhập";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "traituyen";
            TextCol.HeaderText = "Trái tuyến";
            TextCol.Width = 40;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "done";
            TextCol.HeaderText = "Đã khám";
            TextCol.Width = 40;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "MaQL";
            TextCol.Width = 100;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string m_title="";
			try
			{
				//ds.WriteXml("..//..//..//xml//dstiepdon.xml",XmlWriteMode.WriteSchema);
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
					return;
				}
				if (tu.Text!="")
				{
					if (DateTime.Compare(m.StringToDate(tu.Text),m.StringToDate(den.Text))==0)
						m_title="( Ngày "+tu.Text+")";
					else
						m_title="( Từ ngày "+tu.Text+" đến ngày "+den.Text+")";
				}
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,m_title,"rptTkdangky.rpt");
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

		private void frmTkdangky_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTkdangky_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void dotuoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="" &&namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
		}

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void madoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                traituyen.Enabled = madoituong.SelectedValue.ToString() == "1";
                if(traituyen.Enabled==false) traituyen.SelectedIndex=0;
            }
            catch { }

        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {            
            

        }

        private void butChuyenchuakham_Click(object sender, EventArgs e)
        {
            if (l_maql == 0) return;
            DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn cập nhật lại danh sách chờ khám cho Bệnh nhân có này không?"), lan.Change_language_MessageText("Khám"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(dlg==DialogResult.Yes)
                upd_chuakham(txtmabn_ck.Text, l_maql, tu.Text, den.Text);
        }
        private void upd_chuakham(string mabn, decimal maql, string tu, string den)
        {
            string sql = "Update xxx.tiepdon set done=null where done='c' and mabn='" + mabn + "' and maql=" + maql;
            m.execute_data_mmyy(sql, tu, den,false);
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (bAdmin_hethong == false) return;
            txtmabn_ck.Text = dataGrid1[dataGrid1.CurrentRowIndex, 1].ToString().Trim();
            //butChuyenchuakham.Visible = dataGrid1[dataGrid1.CurrentRowIndex, 22].ToString().Trim() == "x";
            l_maql = decimal.Parse(dataGrid1[dataGrid1.CurrentRowIndex, 23].ToString().Trim());
            s_tenbn = dataGrid1[dataGrid1.CurrentRowIndex, 2].ToString().Trim();
            visible_bnchokham(bAdmin_hethong && l_maql > 0 && dataGrid1[dataGrid1.CurrentRowIndex, 22].ToString().Trim() == "c");
        }
        private void visible_bnchokham(bool bln)
        {
            butChuyenchuakham.Visible = bln;
            txtmabn_ck.Visible = bln;
            label14.Visible = bln;
        }
	}
}
