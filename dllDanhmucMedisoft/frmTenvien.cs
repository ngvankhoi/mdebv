using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllDanhmucMedisoft
{
	public class frmTenvien : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private MaskedTextBox.MaskedTextBox ma;
		private MaskedTextBox.MaskedTextBox ten;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedTextBox.MaskedTextBox diachi;
		private System.Windows.Forms.ComboBox mavung;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox matuyen;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox mahang;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox maloai;
		private MaskedTextBox.MaskedTextBox sodt;
		private System.Windows.Forms.Label label9;
		private string user,sql;
        private int itable, i_userid;
        private decimal l_id=0;
        private bool bHang = true, bTuyen = true, bLoai=true;
        private System.Windows.Forms.Button butIn;
        private MaskedTextBox.MaskedTextBox manoidk;
        private Label label10;
        private LibList.List list;
        private TextBox tennoidk;
        private CheckBox chkngoaidm;
		private System.ComponentModel.Container components = null;

		public frmTenvien(AccessData acc,int userid)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTenvien));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ma = new MaskedTextBox.MaskedTextBox();
            this.ten = new MaskedTextBox.MaskedTextBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.matt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.diachi = new MaskedTextBox.MaskedTextBox();
            this.mavung = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.matuyen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mahang = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maloai = new System.Windows.Forms.ComboBox();
            this.sodt = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.manoidk = new MaskedTextBox.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.list = new LibList.List();
            this.tennoidk = new System.Windows.Forms.TextBox();
            this.chkngoaidm = new System.Windows.Forms.CheckBox();
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
            this.dataGrid1.Location = new System.Drawing.Point(10, 12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(774, 397);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(-1, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(95, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(39, 417);
            this.ma.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ma.MaxLength = 8;
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(56, 21);
            this.ma.TabIndex = 5;
            this.ma.Validated += new System.EventHandler(this.ma_Validated);
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(143, 417);
            this.ten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(216, 21);
            this.ten.TabIndex = 6;
            this.ten.Validated += new System.EventHandler(this.ten_Validated);
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(177, 493);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 11;
            this.butThem.Text = "      &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(247, 493);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 12;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(317, 493);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 13;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(387, 493);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(527, 493);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 16;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(597, 493);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 17;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tỉnh/thành phố :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matt
            // 
            this.matt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(280, 5);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(104, 21);
            this.matt.TabIndex = 1;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(360, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(423, 417);
            this.diachi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(200, 21);
            this.diachi.TabIndex = 7;
            this.diachi.Validated += new System.EventHandler(this.diachi_Validated);
            // 
            // mavung
            // 
            this.mavung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mavung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavung.Location = new System.Drawing.Point(48, 5);
            this.mavung.Name = "mavung";
            this.mavung.Size = new System.Drawing.Size(144, 21);
            this.mavung.TabIndex = 0;
            this.mavung.SelectedIndexChanged += new System.EventHandler(this.mavung_SelectedIndexChanged);
            this.mavung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavung_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "&Vùng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(376, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tuyến :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // matuyen
            // 
            this.matuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matuyen.Location = new System.Drawing.Point(424, 5);
            this.matuyen.Name = "matuyen";
            this.matuyen.Size = new System.Drawing.Size(104, 21);
            this.matuyen.TabIndex = 2;
            this.matuyen.SelectedIndexChanged += new System.EventHandler(this.matuyen_SelectedIndexChanged);
            this.matuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matuyen_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(520, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hạng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // mahang
            // 
            this.mahang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mahang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mahang.Location = new System.Drawing.Point(568, 5);
            this.mahang.Name = "mahang";
            this.mahang.Size = new System.Drawing.Size(80, 21);
            this.mahang.TabIndex = 3;
            this.mahang.SelectedIndexChanged += new System.EventHandler(this.mahang_SelectedIndexChanged);
            this.mahang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mahang_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(632, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Loại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // maloai
            // 
            this.maloai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(680, 5);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(104, 21);
            this.maloai.TabIndex = 4;
            this.maloai.SelectedIndexChanged += new System.EventHandler(this.maloai_SelectedIndexChanged);
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maloai_KeyDown);
            // 
            // sodt
            // 
            this.sodt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sodt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sodt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sodt.Enabled = false;
            this.sodt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sodt.Location = new System.Drawing.Point(687, 417);
            this.sodt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sodt.Name = "sodt";
            this.sodt.Size = new System.Drawing.Size(96, 21);
            this.sodt.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(615, 417);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Điện thoại :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(457, 493);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // manoidk
            // 
            this.manoidk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manoidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manoidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manoidk.Location = new System.Drawing.Point(143, 439);
            this.manoidk.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manoidk.MaxLength = 8;
            this.manoidk.Name = "manoidk";
            this.manoidk.Size = new System.Drawing.Size(56, 21);
            this.manoidk.TabIndex = 9;
            this.manoidk.Validated += new System.EventHandler(this.manoidk_Validated);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(2, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 23);
            this.label10.TabIndex = 26;
            this.label10.Text = "Tên Nơi ĐK KCB (BHYT):";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(713, 501);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(24, 17);
            this.list.TabIndex = 220;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // tennoidk
            // 
            this.tennoidk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennoidk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennoidk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennoidk.Location = new System.Drawing.Point(201, 439);
            this.tennoidk.Name = "tennoidk";
            this.tennoidk.Size = new System.Drawing.Size(479, 21);
            this.tennoidk.TabIndex = 10;
            this.tennoidk.Visible = false;
            this.tennoidk.TextChanged += new System.EventHandler(this.tennoidk_TextChanged);
            this.tennoidk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennoidk_KeyDown);
            // 
            // chkngoaidm
            // 
            this.chkngoaidm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkngoaidm.AutoSize = true;
            this.chkngoaidm.Location = new System.Drawing.Point(711, 442);
            this.chkngoaidm.Name = "chkngoaidm";
            this.chkngoaidm.Size = new System.Drawing.Size(80, 17);
            this.chkngoaidm.TabIndex = 221;
            this.chkngoaidm.Text = "Cùng tuyến";
            this.chkngoaidm.UseVisualStyleBackColor = true;
            // 
            // frmTenvien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkngoaidm);
            this.Controls.Add(this.tennoidk);
            this.Controls.Add(this.list);
            this.Controls.Add(this.manoidk);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.sodt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mahang);
            this.Controls.Add(this.matuyen);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mavung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTenvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục bệnh viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTenvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTenvien_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; itable = m.tableid("", "tenvien");
            f_capnhat_db();//
            if (m.get_data("select * from "+user+".thongso where id=117").Tables[0].Rows.Count == 0) m.execute_data("insert into thongso(id,ten) values (117," + "0" + ")");
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
			mavung.DisplayMember="TEN";
			mavung.ValueMember="MA";
            mavung.DataSource = m.get_data("select * from " + user + ".dmvungbv order by ma").Tables[0];

			matuyen.DisplayMember="TEN";
			matuyen.ValueMember="MA";
            matuyen.DataSource = m.get_data("select * from " + user + ".dmtuyenbv order by ma").Tables[0];

			mahang.DisplayMember="TEN";
			mahang.ValueMember="MA";
            mahang.DataSource = m.get_data("select * from " + user + ".dmhangbv order by ma").Tables[0];

			maloai.DisplayMember="TEN";
			maloai.ValueMember="MA";
            maloai.DataSource = m.get_data("select * from " + user + ".dmloaibv order by ma").Tables[0];

			try
			{
                mavung.SelectedValue = m.get_data("select mavung from " + user + ".btdtt where matt='" + m.Mabv.Substring(0, 3) + "'").Tables[0].Rows[0][0].ToString();
				matt.SelectedValue=m.Mabv.Substring(0,3);
			}
			catch{}

            list.DisplayMember = "MABV";
            list.ValueMember = "TENBV";
            list.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + user + ".dmnoicapbhyt where hide=0 order by mabv").Tables[0];

			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void load_tinh()
		{
            matt.DataSource = m.get_data("select * from " + user + ".btdtt where mavung='" + mavung.SelectedValue.ToString() + "'").Tables[0];
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
			TextCol.MappingName = "mabv";
			TextCol.HeaderText = "Mã";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbv";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 300;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "diachi";
			TextCol.HeaderText = "Địa chỉ";
			TextCol.Width = 270;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sodt";
			TextCol.HeaderText = "Điện thoại";
			TextCol.Width = 120;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "matuyen";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "mahang";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            TextCol = new DataGridTextBoxColumn();

            TextCol.MappingName = "maloai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tentuyen";
            TextCol.HeaderText = "Tuyến";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenhang";
            TextCol.HeaderText = "Hạng";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenloai";
            TextCol.HeaderText = "Loại";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ID";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ma_cskcb";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ten_cskcb";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cungtuyen";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void load_grid()
		{
			if (butThem.Enabled)
			{
                sql = "select a.*, b.ten tentuyen, c.ten as tenhang, d.ten as tenloai, e.tenbv as ten_cskcb ";
                sql += " from " + user + ".tenvien a left join " + user + ".dmtuyenbv b on a.matuyen=b.ma ";
                sql += " left join " + user + ".dmhangbv c on a.mahang= c.ma ";
                sql += " left join " + user + ".dmloaibv d on a.maloai= d.ma ";
                sql += " left join " + user + ".dmnoicapbhyt e on a.ma_cskcb=e.mabv";
                sql+=" where a.matinh='" + matt.SelectedValue.ToString() + "'";
                if(bTuyen) sql+=" and a.matuyen='"+matuyen.SelectedValue.ToString()+"'";
                if (bHang) sql += " and a.mahang='" + mahang.SelectedValue.ToString() + "'";
                if(bLoai)sql+=" and a.maloai='"+maloai.SelectedValue.ToString()+"'";
				sql+=" order by a.mabv";
				ds=m.get_data(sql);
				dataGrid1.DataSource=ds.Tables[0];
			}
		}

		private void ena_object(bool ena)
		{
			ma.Enabled=ena;
			ten.Enabled=ena;
			diachi.Enabled=ena;
			sodt.Enabled=ena;
			butThem.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;

            manoidk.Enabled = ena;
            tennoidk.Enabled = ena;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			ma.Text="";
			ten.Text="";
			diachi.Text="";
			sodt.Text="";
            manoidk.Text = "";
            tennoidk.Text = "";
            manoidk.Text = tennoidk.Text = "";
			ena_object(true);
			ma.Focus();
            chkngoaidm.Checked = false;
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{	
			ena_object(true);
			ma.Enabled=false;
			ten.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (ma.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mã !"),LibMedi.AccessData.Msg);
				ma.Focus();
				return;
			}
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập tên !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return;
			}
            if (manoidk.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập mã nơi đăng ký khám chữa bệnh !"), LibMedi.AccessData.Msg);
                manoidk.Focus();
                return;
            }
            if (m.get_data("select * from " + user + ".tenvien where mabv='" + ma.Text + "'").Tables[0].Rows.Count != 0)
            {
                m.upd_eve_tables(itable, i_userid, "upd");
                m.upd_eve_upd_del(itable, i_userid, "upd", ma.Text + "^" + ten.Text + "^" + diachi.Text + "^" + sodt.Text + "^" + matuyen.SelectedValue.ToString() + "^" + maloai.SelectedValue.ToString() + "^" + mahang.SelectedValue.ToString() + "^" + mavung.SelectedValue.ToString() + "^" + matt.SelectedValue.ToString());
            }
            else m.upd_eve_tables(itable, i_userid, "ins");
            if (l_id == 0) l_id = f_get_id_icd10("tenvien");
            if (l_id == 0)
            {
                m.upd_tenvien("tenvien", ma.Text, ten.Text, diachi.Text, sodt.Text, matuyen.SelectedValue.ToString(), maloai.SelectedValue.ToString(), mahang.SelectedValue.ToString(), mavung.SelectedValue.ToString(), matt.SelectedValue.ToString());
            }
            else m.upd_tenvien("tenvien", ma.Text, ten.Text, diachi.Text, sodt.Text, matuyen.SelectedValue.ToString(), maloai.SelectedValue.ToString(), mahang.SelectedValue.ToString(), mavung.SelectedValue.ToString(), matt.SelectedValue.ToString(), l_id);
			m.upd_tenvien("tenvien_add",ma.Text,ten.Text,diachi.Text,sodt.Text,matuyen.SelectedValue.ToString(),maloai.SelectedValue.ToString(),mahang.SelectedValue.ToString(),mavung.SelectedValue.ToString(),matt.SelectedValue.ToString());
			if (ma.Text==m.Mabv) m.upd_thongso(117,"ten",(maloai.SelectedValue.ToString().Trim()=="2.912")?"1":"0");
            if (manoidk.Text.Trim() != "") m.execute_data("update " + m.user + ".tenvien set ma_cskcb='" + manoidk.Text + "' where mabv='" + ma.Text + "'");
            //Tu:06/06/2011
            int i_cungtuyen = chkngoaidm.Checked ? 1 : 0;
            m.execute_data("update " + m.user + ".tenvien set cungtuyen=" + i_cungtuyen + " where mabv='" + ma.Text + "'");
            //end Tu
			ena_object(false);
			load_grid();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    m.upd_eve_tables(itable, i_userid, "del");
                    m.upd_eve_upd_del(itable,i_userid,"del",m.fields(user+".tenvien","mabv='"+ma.Text+"'"));
					m.execute_data("delete from "+user+".tenvien where mabv='"+ma.Text+"'");
                    m.execute_data("delete from " + user + ".tenvien_add where mabv='" + ma.Text + "'");
					load_grid();
				}
			}
			catch{}

		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();		
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				ma.Text=dataGrid1[i,0].ToString();
				ten.Text=dataGrid1[i,1].ToString();
				diachi.Text=dataGrid1[i,2].ToString();
				sodt.Text=dataGrid1[i,3].ToString();

                matuyen.SelectedValue = dataGrid1[i, 4].ToString();
                mahang.SelectedValue = dataGrid1[i, 5].ToString();
                maloai.SelectedValue = dataGrid1[i, 6].ToString();

                l_id = dataGrid1[i, 10].ToString() == "" ? 0 : decimal.Parse(dataGrid1[i, 10].ToString());

                manoidk.Text = dataGrid1[i, 11].ToString();
                tennoidk.Text = dataGrid1[i, 12].ToString();
                if(dataGrid1[i, 13].ToString() == "1")chkngoaidm.Checked=true;
                else chkngoaidm.Checked=false;
			}
			catch{}
		}

		private void ma_Validated(object sender, System.EventArgs e)
		{
			if (ma.Text!="")
			{
				if (ma.Text.Length!=8)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chiều dài chưa đủ !"),LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
				if (ma.Text.Substring(0,3)!=matt.SelectedValue.ToString())
				{
					MessageBox.Show(lan.Change_language_MessageText("Ba ký tự đầu phải là (")+matt.SelectedValue.ToString()+")",LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
				DataRow r=m.getrowbyid(ds.Tables[0],"mabv='"+ma.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã này đã có !"),LibMedi.AccessData.Msg);
					ma.Focus();
					return;
				}
			}
		}

		private void ten_Validated(object sender, System.EventArgs e)
		{
			if (ten.Text!="") ten.Text=m.Caps(ten.Text);
		}

		private void matt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
			}
			catch{}
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void diachi_Validated(object sender, System.EventArgs e)
		{
			if (diachi.Text!="") diachi.Text=m.Caps(diachi.Text);	
		}

		private void mavung_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_tinh();
			}
			catch{}
		}

		private void mavung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void matuyen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
			}
			catch{}
		}

		private void mahang_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
			}
			catch{}	
		}

		private void mahang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void maloai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void maloai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_grid();
			}
			catch{}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmIntenvien f=new frmIntenvien(m);
			f.ShowDialog();
		}

        private void label6_Click(object sender, System.EventArgs e)
        {
            bTuyen = !bTuyen;
            if (bTuyen == false) bHang = bLoai = false;
            load_grid();
        }

        private void label7_Click(object sender, System.EventArgs e)
        {
            bHang  = !bHang;
            load_grid();
        }

        private void label8_Click(object sender, System.EventArgs e)
        {
            bLoai  = !bLoai;
            load_grid();
        }

        private void ten_TextChanged(object sender, EventArgs e)
        {

        }

        private decimal f_get_id_icd10(string m_table)
        {
            sql = "select max(id) as id from " + m.user + "." + m_table;
            decimal m_id = 0;
            DataSet lds = m.get_data(sql);
            if (lds != null && lds.Tables.Count > 0)
            {
                if (lds.Tables[0].Rows[0]["id"].ToString() == "")
                    m_id = 0;
                else m_id = decimal.Parse(lds.Tables[0].Rows[0]["id"].ToString()) + 1;
            }
            return m_id;
        }

        private void tennoidk_TextChanged(object sender, EventArgs e)
        {
            Filt_noicap(tennoidk.Text);
            list.BrowseToText(tennoidk, manoidk, butLuu, tennoidk.Location.X, tennoidk.Location.Y + tennoidk.Height - 2, tennoidk.Width + 128, tennoidk.Height);
        }
        private void Filt_noicap(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim() + "%'";
        }

        private void tennoidk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) list.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (list.Visible)
                {
                    list.Focus();
                    SendKeys.Send("{Down}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void manoidk_Validated(object sender, EventArgs e)
        {
            try
            {               
                tennoidk.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + manoidk.Text + "'").Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void f_capnhat_db()
        {
            string suser=m.user;
            sql = "select id from " + suser + ".tenvien where id=0";
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + suser + ".tenvien add id serial;\n ";
                sql += "alter table " + suser + ".tenvien add ma_cskcb varchar2(10);";
                m.execute_data(sql);

            }

            sql = "select cungtuyen from " + suser + ".tenvien where 1=0";
            DataSet lds1 = m.get_data(sql);
            if (lds1 == null || lds1.Tables.Count <= 0)
            {
                sql = "alter table " + suser + ".tenvien add cungtuyen numeric(1) default 0";
                m.execute_data(sql);
            }
        }
	}
}
