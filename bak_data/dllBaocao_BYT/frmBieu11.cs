using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace dllBaocao_BYT
{
	/// <summary>
	/// Summary description for frmBieu01.
	/// </summary>
	public class frmBieu11 : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string s_userid,sql;
		private int i_userid,i_mabv,i_tong,i_col,i_row=0;
		private long l_id=0;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dt=new DataTable();
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.TextBox dk;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butHuy;
		private bool bPhatsinh;
		private LibList.List list;
		private System.Windows.Forms.TextBox tenbenh;
		private System.Windows.Forms.TextBox icd;
		private MaskedTextBox.MaskedTextBox c01;
		private MaskedTextBox.MaskedTextBox c02;
		private MaskedTextBox.MaskedTextBox c03;
		private MaskedTextBox.MaskedTextBox c04;
		private MaskedTextBox.MaskedTextBox c05;
		private MaskedTextBox.MaskedTextBox c06;
		private MaskedTextBox.MaskedTextBox c07;
		private MaskedTextBox.MaskedTextBox c08;
		private MaskedTextBox.MaskedTextBox c09;
		private MaskedTextBox.MaskedTextBox c10;
		private MaskedTextBox.MaskedTextBox c11;
		private MaskedTextBox.MaskedTextBox c12;
		private MaskedTextBox.MaskedTextBox stt;
		private DataTable dtdm=new DataTable();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBieu11(AccessData acc,string hoten,int userid,int mabv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_userid=hoten;
			i_userid=userid;
			i_mabv=mabv;
			this.Text+="//"+s_userid;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmBieu11( string hoten, int userid, int mabv)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
            s_userid = hoten;
            i_userid = userid;
            i_mabv = mabv;
            this.Text += "//" + s_userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBieu11));
            this.label1 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ten = new System.Windows.Forms.TextBox();
            this.dk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butHuy = new System.Windows.Forms.Button();
            this.list = new LibList.List();
            this.tenbenh = new System.Windows.Forms.TextBox();
            this.icd = new System.Windows.Forms.TextBox();
            this.c01 = new MaskedTextBox.MaskedTextBox();
            this.c02 = new MaskedTextBox.MaskedTextBox();
            this.c03 = new MaskedTextBox.MaskedTextBox();
            this.c04 = new MaskedTextBox.MaskedTextBox();
            this.c05 = new MaskedTextBox.MaskedTextBox();
            this.c06 = new MaskedTextBox.MaskedTextBox();
            this.c07 = new MaskedTextBox.MaskedTextBox();
            this.c08 = new MaskedTextBox.MaskedTextBox();
            this.c09 = new MaskedTextBox.MaskedTextBox();
            this.c10 = new MaskedTextBox.MaskedTextBox();
            this.c11 = new MaskedTextBox.MaskedTextBox();
            this.c12 = new MaskedTextBox.MaskedTextBox();
            this.stt = new MaskedTextBox.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(56, 4);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(88, 20);
            this.ngay.TabIndex = 2;
            this.ngay.Visible = false;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // cmbNgay
            // 
            this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgay.Location = new System.Drawing.Point(56, 4);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(88, 21);
            this.cmbNgay.TabIndex = 3;
            this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
            this.cmbNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNgay_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(213, 500);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 6;
            this.butMoi.Text = "   &Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(274, 500);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 7;
            this.butSua.Text = "     &Sửa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(335, 500);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(396, 500);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 5;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::dllBaocao_BYT.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(519, 500);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(76, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 454);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(147, 4);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(310, 21);
            this.ten.TabIndex = 42;
            // 
            // dk
            // 
            this.dk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dk.Enabled = false;
            this.dk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dk.Location = new System.Drawing.Point(474, 4);
            this.dk.Name = "dk";
            this.dk.Size = new System.Drawing.Size(310, 21);
            this.dk.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "=";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(457, 500);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 8;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(416, 552);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 45;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // tenbenh
            // 
            this.tenbenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbenh.Enabled = false;
            this.tenbenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbenh.Location = new System.Drawing.Point(47, 467);
            this.tenbenh.Name = "tenbenh";
            this.tenbenh.Size = new System.Drawing.Size(190, 21);
            this.tenbenh.TabIndex = 11;
            this.tenbenh.TextChanged += new System.EventHandler(this.tenbenh_TextChanged);
            this.tenbenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbenh_KeyDown);
            this.tenbenh.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // icd
            // 
            this.icd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd.Enabled = false;
            this.icd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd.Location = new System.Drawing.Point(238, 467);
            this.icd.Name = "icd";
            this.icd.Size = new System.Drawing.Size(48, 21);
            this.icd.TabIndex = 12;
            this.icd.TextChanged += new System.EventHandler(this.icd_TextChanged);
            this.icd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbenh_KeyDown);
            this.icd.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c01
            // 
            this.c01.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c01.Enabled = false;
            this.c01.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c01.Location = new System.Drawing.Point(287, 467);
            this.c01.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c01.Name = "c01";
            this.c01.Size = new System.Drawing.Size(39, 21);
            this.c01.TabIndex = 13;
            this.c01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c01.Validated += new System.EventHandler(this.c01_Validated);
            this.c01.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c02
            // 
            this.c02.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c02.Enabled = false;
            this.c02.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c02.Location = new System.Drawing.Point(327, 467);
            this.c02.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c02.Name = "c02";
            this.c02.Size = new System.Drawing.Size(39, 21);
            this.c02.TabIndex = 14;
            this.c02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c02.Validated += new System.EventHandler(this.c02_Validated);
            this.c02.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c03
            // 
            this.c03.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c03.Enabled = false;
            this.c03.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c03.Location = new System.Drawing.Point(367, 467);
            this.c03.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c03.Name = "c03";
            this.c03.Size = new System.Drawing.Size(39, 21);
            this.c03.TabIndex = 15;
            this.c03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c03.Validated += new System.EventHandler(this.c03_Validated);
            this.c03.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c04
            // 
            this.c04.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c04.Enabled = false;
            this.c04.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c04.Location = new System.Drawing.Point(407, 467);
            this.c04.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c04.Name = "c04";
            this.c04.Size = new System.Drawing.Size(39, 21);
            this.c04.TabIndex = 16;
            this.c04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c04.Validated += new System.EventHandler(this.c04_Validated);
            this.c04.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c05
            // 
            this.c05.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c05.Enabled = false;
            this.c05.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c05.Location = new System.Drawing.Point(447, 467);
            this.c05.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c05.Name = "c05";
            this.c05.Size = new System.Drawing.Size(39, 21);
            this.c05.TabIndex = 17;
            this.c05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c05.Validated += new System.EventHandler(this.c05_Validated);
            this.c05.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c06
            // 
            this.c06.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c06.Enabled = false;
            this.c06.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c06.Location = new System.Drawing.Point(487, 467);
            this.c06.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c06.Name = "c06";
            this.c06.Size = new System.Drawing.Size(39, 21);
            this.c06.TabIndex = 18;
            this.c06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c06.Validated += new System.EventHandler(this.c06_Validated);
            this.c06.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c07
            // 
            this.c07.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c07.Enabled = false;
            this.c07.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c07.Location = new System.Drawing.Point(527, 467);
            this.c07.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c07.Name = "c07";
            this.c07.Size = new System.Drawing.Size(39, 21);
            this.c07.TabIndex = 19;
            this.c07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c07.Validated += new System.EventHandler(this.c07_Validated);
            this.c07.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c08
            // 
            this.c08.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c08.Enabled = false;
            this.c08.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c08.Location = new System.Drawing.Point(567, 467);
            this.c08.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c08.Name = "c08";
            this.c08.Size = new System.Drawing.Size(39, 21);
            this.c08.TabIndex = 20;
            this.c08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c08.Validated += new System.EventHandler(this.c08_Validated);
            this.c08.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c09
            // 
            this.c09.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c09.Enabled = false;
            this.c09.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c09.Location = new System.Drawing.Point(607, 467);
            this.c09.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c09.Name = "c09";
            this.c09.Size = new System.Drawing.Size(39, 21);
            this.c09.TabIndex = 21;
            this.c09.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c09.Validated += new System.EventHandler(this.c09_Validated);
            this.c09.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c10
            // 
            this.c10.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c10.Enabled = false;
            this.c10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c10.Location = new System.Drawing.Point(647, 467);
            this.c10.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(39, 21);
            this.c10.TabIndex = 22;
            this.c10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c10.Validated += new System.EventHandler(this.c10_Validated);
            this.c10.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c11
            // 
            this.c11.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c11.Enabled = false;
            this.c11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c11.Location = new System.Drawing.Point(687, 467);
            this.c11.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(39, 21);
            this.c11.TabIndex = 23;
            this.c11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c11.Validated += new System.EventHandler(this.c11_Validated);
            this.c11.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // c12
            // 
            this.c12.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c12.Enabled = false;
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(727, 467);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(39, 21);
            this.c12.TabIndex = 24;
            this.c12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c12.Validated += new System.EventHandler(this.c12_Validated);
            this.c12.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // stt
            // 
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(22, 467);
            this.stt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.stt.MaxLength = 3;
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 21);
            this.stt.TabIndex = 10;
            this.stt.Validated += new System.EventHandler(this.stt_Validated);
            this.stt.Leave += new System.EventHandler(this.c01_Leave);
            // 
            // frmBieu11
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.c12);
            this.Controls.Add(this.c11);
            this.Controls.Add(this.c10);
            this.Controls.Add(this.c09);
            this.Controls.Add(this.c08);
            this.Controls.Add(this.c07);
            this.Controls.Add(this.c06);
            this.Controls.Add(this.c05);
            this.Controls.Add(this.c04);
            this.Controls.Add(this.c03);
            this.Controls.Add(this.c02);
            this.Controls.Add(this.c01);
            this.Controls.Add(this.icd);
            this.Controls.Add(this.tenbenh);
            this.Controls.Add(this.list);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dk);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBieu11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tình hình bệnh tật, tử vong tại bệnh viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBieu11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBieu11_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			dtdm=m.get_data("select stt,ten,icd10 from "+m.user+".dm_11 where substr(stt,1,1)<>'C' order by ma").Tables[0];
			list.DisplayMember="TEN";
			list.ValueMember="STT";
			list.DataSource=dtdm;

			bPhatsinh=m.bSolieu;
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			load_ngay();
			dt=m.get_data("select * from "+m.user+".dm_11_dk").Tables[0];
			load_grid(false);
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dataGrid1.Visible=false;
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			dataGrid1.Visible=true;
			dataGrid1.ReadOnly=true;
		}
		
		private void load_grid(bool dm)
		{
			if (dm)	ds=m.get_data("select * from "+m.user+".dm_11 order by ma");
			else load_data();
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void load_data()
		{
			if (bPhatsinh)
			{
				sql="select a.*,b.stt,b.ten,b.icd10 from "+m.user+".bieu_11 a,"+m.user+".dm_11 b where a.ma=b.ma and a.id="+l_id+" order by a.ma";
				ds=m.get_data(sql);
			}
			else
			{
				load_value(false);
			}
		}

		private void load_value(bool load)
		{
			ds=m.get_data("select * from "+m.user+".dm_11 order by ma");
			DataRow[] dr;
			foreach(DataRow r in m.get_data("select * from "+m.user+".bieu_11 where id="+l_id).Tables[0].Rows)
			{
				dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
				if (dr!=null)
				{
					dr[0]["c01"]=r["c01"].ToString();
					dr[0]["c02"]=r["c02"].ToString();
					dr[0]["c03"]=r["c03"].ToString();
					dr[0]["c04"]=r["c04"].ToString();
					dr[0]["c05"]=r["c05"].ToString();
					dr[0]["c06"]=r["c06"].ToString();
					dr[0]["c07"]=r["c07"].ToString();
					dr[0]["c08"]=r["c08"].ToString();
					dr[0]["c09"]=r["c09"].ToString();
					dr[0]["c10"]=r["c10"].ToString();
					dr[0]["c11"]=r["c11"].ToString();
					dr[0]["c12"]=r["c12"].ToString();
				}
			}
			if (load) dataGrid1.DataSource=ds.Tables[0];
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (ds.HasChanges()) Tongcong();
				if (ds.HasChanges())
				{
					m.execute_data("delete from "+m.user+".bieu_11 where id="+l_id);
					string exp="c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12>0";
					DataRow[] r=ds.Tables[0].Select(exp);
					Int16 iRec=Convert.ToInt16(r.Length);
					for(Int16 i=0;i<iRec;i++)
					{
						m.upd_bieu11(l_id,int.Parse(r[i]["ma"].ToString()),ngay.Text,int.Parse(r[i]["c01"].ToString()),
							int.Parse(r[i]["c02"].ToString()),int.Parse(r[i]["c03"].ToString()),int.Parse(r[i]["c04"].ToString()),
							int.Parse(r[i]["c05"].ToString()),int.Parse(r[i]["c06"].ToString()),int.Parse(r[i]["c07"].ToString()),
							int.Parse(r[i]["c08"].ToString()),int.Parse(r[i]["c09"].ToString()),
							int.Parse(r[i]["c10"].ToString()),int.Parse(r[i]["c11"].ToString()),
							int.Parse(r[i]["c12"].ToString()),i_userid);
					}
				}
				ena_object(false);
				long id=l_id;
				load_ngay();
				cmbNgay.SelectedValue=id.ToString();
				l_id=id;
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
			load_grid(false);
			butMoi.Focus();
		}

		private void load_ngay()
		{
			cmbNgay.DataSource=m.get_data("select ID,to_char(ngay,'dd/mm/yyyy') as NGAY from "+m.user+".bieu_11 group by id,ngay order by ngay").Tables[0];
		}

		private void ena_object(bool ena)
		{
			stt.Enabled=ena;
			tenbenh.Enabled=ena;
			//icd.Enabled=ena;
			c01.Enabled=ena;
			c02.Enabled=ena;
			c03.Enabled=ena;
			c04.Enabled=ena;
			c05.Enabled=ena;
			c06.Enabled=ena;
			c07.Enabled=ena;
			c08.Enabled=ena;
			c09.Enabled=ena;
			c10.Enabled=ena;
			c11.Enabled=ena;
			c12.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butKetthuc.Enabled=!ena;
			butHuy.Enabled=!ena;
			dataGrid1.ReadOnly=!ena;
			ngay.Visible=ena;
			cmbNgay.Visible=!ena;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			l_id=m.get_capid(24);
			load_grid(true);
			ena_object(true);
			emp_text();
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.Items.Count==0) return;
			try
			{
				l_id=long.Parse(cmbNgay.SelectedValue.ToString());
				int dd=int.Parse(cmbNgay.Text.Substring(0,2));
				int mm=int.Parse(cmbNgay.Text.Substring(3,2));
				int yyyy=int.Parse(cmbNgay.Text.Substring(6,4));
				ngay.Value=new DateTime(yyyy,mm,dd,0,0,0);
				load_value(true);
				ena_object(true);
				dataGrid1.Focus();
			}
			catch{}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			try
			{
				l_id=long.Parse(cmbNgay.SelectedValue.ToString());
			}
			catch{l_id=0;}
			load_grid(false);
			butMoi.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.Items.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				l_id=long.Parse(cmbNgay.SelectedValue.ToString());
				m.execute_data("delete from "+m.user+".bieu_11 where id="+l_id);
				load_ngay();
				load_grid(false);
			}
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				l_id=long.Parse(cmbNgay.SelectedValue.ToString());
				load_grid(false);
			}
			catch{l_id=0;}
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
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
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "ma";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "STT";
			TextCol1.Width = 24;
			TextCol1.ReadOnly=true;
			TextCol1.Alignment=HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Bệnh tật";
			TextCol1.Width = 190;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "icd10";
			TextCol1.HeaderText = "ICD10";
			TextCol1.Width = 50;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "C01";
			TextCol1.HeaderText = "C01";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 5);
			TextCol1.MappingName = "C02";
			TextCol1.HeaderText = "C02";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 6);
			TextCol1.MappingName = "C03";
			TextCol1.HeaderText = "C03";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 7);
			TextCol1.MappingName = "C04";
			TextCol1.HeaderText = "C04";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 8);
			TextCol1.MappingName = "C05";
			TextCol1.HeaderText = "C05";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 9);
			TextCol1.MappingName = "C06";
			TextCol1.HeaderText = "C06";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 10);
			TextCol1.MappingName = "C07";
			TextCol1.HeaderText = "C07";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 11);
			TextCol1.MappingName = "C08";
			TextCol1.HeaderText = "C08";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 12);
			TextCol1.MappingName = "C09";
			TextCol1.HeaderText = "C09";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 13);
			TextCol1.MappingName = "C10";
			TextCol1.HeaderText = "C10";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);


			TextCol1=new DataGridColoredTextBoxColumn(de, 14);
			TextCol1.MappingName = "C11";
			TextCol1.HeaderText = "C11";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 15);
			TextCol1.MappingName = "C12";
			TextCol1.HeaderText = "C12";
			TextCol1.Width = 40;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

		}

		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
            if (this.dataGrid1[row,1].ToString().Trim().Substring(0,1)=="C")
			{
				c=Color.Red;
				i_tong=row;
			}
			if (row==i_tong) c=Color.Red;
			return c;
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
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			i_col=dataGrid1.CurrentCell.ColumnNumber-3;
			//i_row=dataGrid1.CurrentCell.RowNumber;
			DataRow r1=m.getrowbyid(dt,"ma='"+"C"+i_col.ToString().PadLeft(2,'0')+"'");
			if (r1!=null)
			{
				ten.Text=r1[1].ToString();
				dk.Text=r1[2].ToString();
			}
			else
			{
				ten.Text="";
				dk.Text="";
			}

			#region gan
			int row=dataGrid1.CurrentCell.RowNumber;
			r1=m.getrowbyid(ds.Tables[0],"stt='"+dataGrid1[row,1].ToString()+"'");
			if (r1!=null)
			{
				stt.Text=r1["stt"].ToString();
				tenbenh.Text=r1["ten"].ToString();
				icd.Text=r1["icd10"].ToString();
				c01.Text=r1["c01"].ToString();
				c02.Text=r1["c02"].ToString();
				c03.Text=r1["c03"].ToString();
				c04.Text=r1["c04"].ToString();
				c05.Text=r1["c05"].ToString();
				c06.Text=r1["c06"].ToString();
				c07.Text=r1["c07"].ToString();
				c08.Text=r1["c08"].ToString();
				c09.Text=r1["c09"].ToString();
				c10.Text=r1["c10"].ToString();
				c11.Text=r1["c11"].ToString();
				c12.Text=r1["c12"].ToString();
			}
			#endregion

			if (butMoi.Enabled) return;
			try
			{
				long l_tong=0;
				i_col=dataGrid1.CurrentCell.ColumnNumber;
				//i_row=dataGrid1.CurrentCell.RowNumber;
				if (i_col<4) return;
				if (dataGrid1[i_row,i_col].ToString().IndexOf("-")!=-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
					dataGrid1[i_row,i_col]=0;
				}
				string exp="",stt="";
				if ((i_row>=1 && i_row<=58) || (dataGrid1[i_row,1].ToString()=="C01"))
				{
					exp="ma>=2 and ma<=58";
					stt="C01";
				}
				else if ((i_row>=58 && i_row<=98) || (dataGrid1[i_row,1].ToString()=="C02"))
				{
					exp="ma>=60 and ma<=98";
					stt="C02";
				}
				else if ((i_row>=98 && i_row<=103) || (dataGrid1[i_row,1].ToString()=="C03"))
				{
					exp="ma>=100 and ma<=103";
					stt="C03";
				}
				else if ((i_row>=103 && i_row<=115) || (dataGrid1[i_row,1].ToString()=="C04"))
				{
					exp="ma>=105 and ma<=115";
					stt="C04";
				}
				else if ((i_row>=115 && i_row<=124) || (dataGrid1[i_row,1].ToString()=="C05"))
				{
					exp="ma>=117 and ma<=124";
					stt="C05";
				}
				else if ((i_row>=124 && i_row<=135) || (dataGrid1[i_row,1].ToString()=="C06"))
				{
					exp="ma>=126 and ma<=135";
					stt="C06";
				}
				else if ((i_row>=135 && i_row<=146) || (dataGrid1[i_row,1].ToString()=="C07"))
				{
					exp="ma>=137 and ma<=146";
					stt="C07";
				}
				else if ((i_row>=146 && i_row<=150) || (dataGrid1[i_row,1].ToString()=="C08"))
				{
					exp="ma>=148 and ma<=150";
					stt="C08";
				}
				else if ((i_row>=150 && i_row<=173) || (dataGrid1[i_row,1].ToString()=="C09"))
				{
					exp="ma>=152 and ma<=173";
					stt="C09";
				}
				else if ((i_row>=173 && i_row<=189) || (dataGrid1[i_row,1].ToString()=="C10"))
				{
					exp="ma>=175 and ma<=189";
					stt="C10";
				}
				else if ((i_row>=189 && i_row<=208) || (dataGrid1[i_row,1].ToString()=="C11"))
				{
					exp="ma>=191 and ma<=208";
					stt="C11";
				}
				else if ((i_row>=208 && i_row<=211) || (dataGrid1[i_row,1].ToString()=="C12"))
				{
					exp="ma>=210 and ma<=211";
					stt="C12";
				}
				else if ((i_row>=211 && i_row<=223) || (dataGrid1[i_row,1].ToString()=="C13"))
				{
					exp="ma>=213 and ma<=223";
					stt="C13";
				}
				else if ((i_row>=223 && i_row<=247) || (dataGrid1[i_row,1].ToString()=="C14"))
				{
					exp="ma>=225 and ma<=247";
					stt="C14";
				}
				else if ((i_row>=247 && i_row<=259) || (dataGrid1[i_row,1].ToString()=="C15"))
				{
					exp="ma>=249 and ma<=259";
					stt="C15";
				}
				else if ((i_row>=259 && i_row<=269) || (dataGrid1[i_row,1].ToString()=="C16"))
				{
					exp="ma>=261 and ma<=269";
					stt="C16";
				}
				else if ((i_row>=269 && i_row<=283) || (dataGrid1[i_row,1].ToString()=="C17"))
				{
					exp="ma>=271 and ma<=283";
					stt="C17";
				}
				else if ((i_row>=283 && i_row<=288) || (dataGrid1[i_row,1].ToString()=="C18"))
				{
					exp="ma>=285 and ma<=288";
					stt="C18";
				}
				else if ((i_row>=288 && i_row<=308) || (dataGrid1[i_row,1].ToString()=="C19"))
				{
					exp="ma>=290 and ma<=308";
					stt="C19";
				}
				else if ((i_row>=308 && i_row<=323) || (dataGrid1[i_row,1].ToString()=="C20"))
				{
					exp="ma>=310 and ma<=323";
					stt="C20";
				}
				else if ((i_row>=323 && i_row<=333) || (dataGrid1[i_row,1].ToString()=="C21"))
				{
					exp="ma>=325 and ma<=333";
					stt="C21";
				}
				if (exp!="")
				{
                    // code cu hien 26-02-2011
//                    DataRow[] r=ds.Tables[0].Select(exp);
//                    Int16 iRec=Convert.ToInt16(r.Length);
//                    for(Int16 i=0;i<iRec;i++) l_tong+=long.Parse(r[i][i_col].ToString());
//                    m.updrec_02(ds.Tables[0],stt,i_col,l_tong);
//                    if (dataGrid1[i_row,i_col].ToString()!="")
//                    {
//                        long l7=long.Parse(dataGrid1[i_row,7].ToString());
//                        long l8=long.Parse(dataGrid1[i_row,8].ToString());
//                        long l9=long.Parse(dataGrid1[i_row,9].ToString());
//                        long l10=long.Parse(dataGrid1[i_row,10].ToString());
//                        long l12=long.Parse(dataGrid1[i_row,12].ToString());
//                        if (i_col<7 && long.Parse(dataGrid1[i_row,i_col].ToString())>long.Parse(dataGrid1[i_row,4].ToString()))
//                        {
//                            MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                            dataGrid1[i_row,i_col]=0;
//                        }
//                        else if (l8>l7 || l10>l7 || l12>l10 || long.Parse(dataGrid1[i_row,14].ToString())>l9 || long.Parse(dataGrid1[i_row,11].ToString())>l10 || long.Parse(dataGrid1[i_row,13].ToString())>long.Parse(dataGrid1[i_row,12].ToString()) || long.Parse(dataGrid1[i_row,15].ToString())>long.Parse(dataGrid1[i_row,14].ToString()))
//                        {
//                            MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                            dataGrid1[i_row,i_col]=0;
//                        }
//                    }
                    DataRow[] r = ds.Tables[0].Select(exp);
                    Int16 iRec = Convert.ToInt16(r.Length);
                    for (Int16 i = 0; i < iRec; i++) l_tong += long.Parse(r[i][i_col].ToString());
                    m.updrec_02(ds.Tables[0], stt, i_col, l_tong);
                    if (i_col >= 4 && i_col <= 15 && dataGrid1[i_row, i_col].ToString() != "")
                    {
                        kiemtranhap(i_row, i_col);
                    }
				}
				i_row=dataGrid1.CurrentRowIndex;
			}
			catch{}
		}
        #region  kiem tra
        void kiemtranhap(int row, int col)
        {
            if (long.Parse(dataGrid1[row, 4].ToString()) < long.Parse(dataGrid1[row, 5].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 4].ToString()) < long.Parse(dataGrid1[row, 6].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 4].ToString()) < long.Parse(dataGrid1[row, 7].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 8].ToString()) < long.Parse(dataGrid1[row, 9].ToString()) || long.Parse(dataGrid1[row, 8].ToString()) < long.Parse(dataGrid1[row, 10].ToString()) || long.Parse(dataGrid1[row, 8].ToString()) < long.Parse(dataGrid1[row, 12].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 9].ToString()) < long.Parse(dataGrid1[row, 11].ToString()) || long.Parse(dataGrid1[row, 10].ToString()) < long.Parse(dataGrid1[row, 11].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 12].ToString()) < long.Parse(dataGrid1[row, 13].ToString()) || long.Parse(dataGrid1[row, 12].ToString()) < long.Parse(dataGrid1[row, 14].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 13].ToString()) < long.Parse(dataGrid1[row, 15].ToString()) || long.Parse(dataGrid1[row, 14].ToString()) < long.Parse(dataGrid1[row, 15].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
            if (long.Parse(dataGrid1[row, 10].ToString()) < long.Parse(dataGrid1[row, 14].ToString()))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                dataGrid1[i_row, i_col] = 0; return;
            }
        }
        #endregion
		private void cmbNgay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) butMoi.Focus();
		}

		private void Tongcong()
		{
			for(int k=4;k<ds.Tables[0].Columns.Count;k++)
			{
				sum("ma>=2 and ma<=58","C01",k);
				sum("ma>=60 and ma<=98","C02",k);
				sum("ma>=100 and ma<=103","C03",k);
				sum("ma>=105 and ma<=115","C04",k);
				sum("ma>=117 and ma<=124","C05",k);
				sum("ma>=126 and ma<=135","C06",k);
				sum("ma>=137 and ma<=146","C07",k);
				sum("ma>=148 and ma<=150","C08",k);
				sum("ma>=152 and ma<=173","C09",k);
				sum("ma>=175 and ma<=189","C10",k);
				sum("ma>=191 and ma<=208","C11",k);
				sum("ma>=210 and ma<=211","C12",k);
				sum("ma>=213 and ma<=223","C13",k);
				sum("ma>=225 and ma<=247","C14",k);
				sum("ma>=249 and ma<=259","C15",k);
				sum("ma>=261 and ma<=269","C16",k);
				sum("ma>=271 and ma<=283","C17",k);
				sum("ma>=285 and ma<=288","C18",k);
				sum("ma>=290 and ma<=308","C19",k);
				sum("ma>=310 and ma<=323","C20",k);
				sum("ma>=325 and ma<=333","C21",k);
			}
		}
		
		private void sum(string exp,string stt,int k)
		{
			DataRow[] r;
			Int16 iRec;
			long l_tong=0;
			r=ds.Tables[0].Select(exp);
			iRec=Convert.ToInt16(r.Length);
			for(Int16 i=0;i<iRec;i++) l_tong+=long.Parse(r[i][k].ToString());
			m.updrec_02(ds.Tables[0],stt,k,l_tong);
		}

		private void stt_Validated(object sender, System.EventArgs e)
		{
			if (stt.Text=="") return;
			DataRow r=m.getrowbyid(dtdm,"stt='"+stt.Text+"'");		
			if (r!=null)
			{
				tenbenh.Text=r["ten"].ToString();
				icd.Text=r["icd10"].ToString();
			}
		}

		private void Filter_ma(string str)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="icd10 like '%"+str.Trim()+"%'";
			}
			catch{}
		}

		private void Filter_ten(string str)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+str.Trim()+"%'"+" or icd10 like '%"+str.Trim()+"%'";
			}
			catch{}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			stt_Validated(null,null);
		}

		private void tenbenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void icd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==icd)
			{
				Filter_ma(icd.Text);
				list.BrowseToBieu11(tenbenh,stt,icd,stt.Location.X,stt.Location.Y+23,this.Width-60,stt.Height);
			}				
		}

		private void tenbenh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbenh)
			{
				Filter_ten(tenbenh.Text);
				list.BrowseToBieu11(tenbenh,stt,c01,stt.Location.X,stt.Location.Y+23,this.Width-60,stt.Height);
			}		
		}

//        private void c12_Validated(object sender, System.EventArgs e)
//        {
//            if (c12.Text=="") c12.Text="0";
//            if (decimal.Parse(c12.Text)>decimal.Parse(c11.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c12.Focus();
//                return;
//            }
//            if (stt.Text!="")
//            {
//                m.updrec_11(ds.Tables[0],stt.Text.ToString(),c01.Text.ToString(),c02.Text.ToString(),c03.Text.ToString(),c04.Text.ToString(),c05.Text.ToString(),c06.Text.ToString(),c07.Text.ToString(),c08.Text.ToString(),c09.Text.ToString(),c10.Text.ToString(),c11.Text.ToString(),c12.Text.ToString());
//                emp_text();
//                stt.Focus();
//            }
//        }
//        private void emp_text()
//        {
//            stt.Text="";tenbenh.Text="";icd.Text="";c01.Text="0";
//            c02.Text="0";c03.Text="0";c04.Text="0";c05.Text="0";c06.Text="0";
//            c07.Text="0";c08.Text="0";c09.Text="0";c10.Text="0";c11.Text="0";c12.Text="0";
//        }

//        private void c01_Validated(object sender, System.EventArgs e)
//        {
//            if (c01.Text=="") c01.Text="0";
//        }

//        private void c02_Validated(object sender, System.EventArgs e)
//        {
//            if (c02.Text=="") c02.Text="0";
//            if (decimal.Parse(c02.Text)>decimal.Parse(c01.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c02.Focus();
//            }
//        }

//        private void c03_Validated(object sender, System.EventArgs e)
//        {
//            if (c03.Text=="") c03.Text="0";
//            if (decimal.Parse(c03.Text)>decimal.Parse(c01.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c03.Focus();
//            }
//        }

//        private void c04_Validated(object sender, System.EventArgs e)
//        {
//            if (c04.Text=="") c04.Text="0";
//        }

//        private void c05_Validated(object sender, System.EventArgs e)
//        {
//            if (c05.Text=="") c05.Text="0";
//            if (decimal.Parse(c05.Text)>decimal.Parse(c04.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c05.Focus();
//            }
//        }

//        private void c06_Validated(object sender, System.EventArgs e)
//        {
//            if (c06.Text=="") c06.Text="0";
//        }

//        private void c07_Validated(object sender, System.EventArgs e)
//        {
//            if (c07.Text=="") c07.Text="0";
//            if (decimal.Parse(c07.Text)>decimal.Parse(c04.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c07.Focus();
//            }
//        }

//        private void c08_Validated(object sender, System.EventArgs e)
//        {
//            if (c08.Text=="") c08.Text="0";
//            if (decimal.Parse(c08.Text)>decimal.Parse(c07.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c08.Focus();
//            }
//        }

//        private void c09_Validated(object sender, System.EventArgs e)
//        {
//            if (c09.Text=="") c09.Text="0";
//            if (decimal.Parse(c09.Text)>decimal.Parse(c07.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c09.Focus();
//            }
//        }

//        private void c10_Validated(object sender, System.EventArgs e)
//        {
//            if (c10.Text=="") c10.Text="0";
//            if (decimal.Parse(c10.Text)>decimal.Parse(c09.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c10.Focus();
//            }
//        }

//        private void c11_Validated(object sender, System.EventArgs e)
//        {
//            if (c11.Text=="") c11.Text="0";
//            if (decimal.Parse(c11.Text)>decimal.Parse(c06.Text))
//            {
//                MessageBox.Show(
//lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
//                c11.Focus();
//            }
//        }

//        private void c01_Leave(object sender, System.EventArgs e)
//        {
//            DataRow r1=m.getrowbyid(dt,"ma='"+this.ActiveControl.Name.ToString()+"'");
//            if (r1!=null)
//            {
//                ten.Text=r1[1].ToString();
//                dk.Text=r1[2].ToString();
//            }
//            else
//            {
//                ten.Text="";
//                dk.Text="";
//            }
//        }
        private void c12_Validated(object sender, System.EventArgs e)
        {
            if (c12.Text == "") c12.Text = "0";
            if (decimal.Parse(c12.Text) > decimal.Parse(c11.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c12.Focus();
                return;
            }
            if (stt.Text != "")
            {
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
                emp_text();
                stt.Focus();
            }
        }
        private void emp_text()
        {
            stt.Text = ""; tenbenh.Text = ""; icd.Text = ""; c01.Text = "0";
            c02.Text = "0"; c03.Text = "0"; c04.Text = "0"; c05.Text = "0"; c06.Text = "0";
            c07.Text = "0"; c08.Text = "0"; c09.Text = "0"; c10.Text = "0"; c11.Text = "0"; c12.Text = "0";
        }

        private void c01_Validated(object sender, System.EventArgs e)
        {
            if (c01.Text == "") c01.Text = "0";
            m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c02_Validated(object sender, System.EventArgs e)
        {
            if (c02.Text == "") c02.Text = "0";
            if (decimal.Parse(c02.Text) > decimal.Parse(c01.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c02.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c03_Validated(object sender, System.EventArgs e)
        {
            if (c03.Text == "") c03.Text = "0";
            if (decimal.Parse(c03.Text) > decimal.Parse(c01.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c03.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c04_Validated(object sender, System.EventArgs e)
        {
            if (c04.Text == "") c04.Text = "0";
            if (decimal.Parse(c04.Text) > decimal.Parse(c01.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c04.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c05_Validated(object sender, System.EventArgs e)
        {
            if (c05.Text == "") c05.Text = "0";
            if (decimal.Parse(c05.Text) > decimal.Parse(c01.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c05.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c06_Validated(object sender, System.EventArgs e)
        {
            if (c06.Text == "") c06.Text = "0";
            if (decimal.Parse(c06.Text) > decimal.Parse(c05.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c06.Focus();
            }
            else

                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c07_Validated(object sender, System.EventArgs e)
        {
            if (c07.Text == "") c07.Text = "0";
            if (decimal.Parse(c07.Text) > decimal.Parse(c05.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c07.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c08_Validated(object sender, System.EventArgs e)
        {
            if (c08.Text == "") c08.Text = "0";
            if (decimal.Parse(c08.Text) > decimal.Parse(c07.Text) || decimal.Parse(c08.Text) > decimal.Parse(c06.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c08.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c09_Validated(object sender, System.EventArgs e)
        {
            if (c09.Text == "") c09.Text = "0";
            if (decimal.Parse(c09.Text) > decimal.Parse(c05.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c09.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c10_Validated(object sender, System.EventArgs e)
        {
            if (c10.Text == "") c10.Text = "0";
            if (decimal.Parse(c10.Text) > decimal.Parse(c09.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c10.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c11_Validated(object sender, System.EventArgs e)
        {
            if (c11.Text == "") c11.Text = "0";
            if (decimal.Parse(c11.Text) > decimal.Parse(c09.Text) || decimal.Parse(c11.Text) > decimal.Parse(c07.Text))
            {
                MessageBox.Show("Số liệu không hợp lệ !", LibMedi.AccessData.Msg);
                c11.Focus();
            }
            else
                m.updrec_11(ds.Tables[0], stt.Text.ToString(), c01.Text.ToString(), c02.Text.ToString(), c03.Text.ToString(), c04.Text.ToString(), c05.Text.ToString(), c06.Text.ToString(), c07.Text.ToString(), c08.Text.ToString(), c09.Text.ToString(), c10.Text.ToString(), c11.Text.ToString(), c12.Text.ToString());
        }

        private void c01_Leave(object sender, System.EventArgs e)
        {
            DataRow r1 = m.getrowbyid(dt, "ma='" + this.ActiveControl.Name.ToString() + "'");
            if (r1 != null)
            {
                ten.Text = r1[1].ToString();
                dk.Text = r1[2].ToString();
            }
            else
            {
                ten.Text = "";
                dk.Text = "";
            }
        }
	}
}
