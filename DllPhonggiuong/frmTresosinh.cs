using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace DllPhonggiuong
{
	public class frmTresosinh : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private System.ComponentModel.Container components = null;
		private string m_ngay,m_mabn,m_hoten,m_tuoi,sql,s_msg,s_ngay,m_mann,m_matt="",m_maqu="",m_mapxa="";
		private long m_maql,m_id;
		private int m_userid,songay;
		private bool bAdmin;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox cannang;
		private System.Windows.Forms.ComboBox phai;
		private System.Windows.Forms.ComboBox tinhtrang;
		private System.Windows.Forms.ComboBox ditat;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox ngayde;
		private DataTable dt=new DataTable();
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.Label label39;
		private MaskedTextBox.MaskedTextBox vongdau;
		private MaskedTextBox.MaskedTextBox cao;
		private MaskedTextBox.MaskedTextBox apgar10;
		private MaskedTextBox.MaskedTextBox apgar5;
		private MaskedTextBox.MaskedTextBox apgar1;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox madt;
		private System.Windows.Forms.ComboBox tendt;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox hotentre;
		private System.Windows.Forms.CheckBox duthang;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown conthu;
		private System.Windows.Forms.NumericUpDown thang;
		private System.Windows.Forms.NumericUpDown tuan;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox manv1;
		private System.Windows.Forms.TextBox manv2;
		private System.Windows.Forms.ComboBox tennv1;
		private System.Windows.Forms.ComboBox tennv2;
		private System.Windows.Forms.ComboBox ngoithai;
		private System.Windows.Forms.Label label18;
		private MaskedTextBox.MaskedTextBox mass;
		private System.Windows.Forms.ComboBox cachthucde;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox xuly;
		private AccessData m;

		public frmTresosinh(AccessData acc,string mabn,string hoten,string tuoi,long maql,string ngay,int userid,string matt,string maqu,string mapxa)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			m_mabn=mabn;m_hoten=hoten;
			m_tuoi=tuoi;m_maql=maql;
			m_ngay=ngay;m_userid=userid;m_matt=matt;m_maqu=maqu;m_mapxa=mapxa;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTresosinh));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cannang = new MaskedTextBox.MaskedTextBox();
			this.phai = new System.Windows.Forms.ComboBox();
			this.tinhtrang = new System.Windows.Forms.ComboBox();
			this.ditat = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.butThem = new System.Windows.Forms.Button();
			this.butSua = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butHuy = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.hoten = new System.Windows.Forms.TextBox();
			this.tuoi = new System.Windows.Forms.TextBox();
			this.ngayde = new System.Windows.Forms.TextBox();
			this.ngay = new MaskedBox.MaskedBox();
			this.label39 = new System.Windows.Forms.Label();
			this.vongdau = new MaskedTextBox.MaskedTextBox();
			this.cao = new MaskedTextBox.MaskedTextBox();
			this.apgar10 = new MaskedTextBox.MaskedTextBox();
			this.apgar5 = new MaskedTextBox.MaskedTextBox();
			this.apgar1 = new MaskedTextBox.MaskedTextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.ngoithai = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.madt = new System.Windows.Forms.TextBox();
			this.tendt = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.hotentre = new System.Windows.Forms.TextBox();
			this.duthang = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.conthu = new System.Windows.Forms.NumericUpDown();
			this.thang = new System.Windows.Forms.NumericUpDown();
			this.tuan = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.manv1 = new System.Windows.Forms.TextBox();
			this.manv2 = new System.Windows.Forms.TextBox();
			this.tennv1 = new System.Windows.Forms.ComboBox();
			this.tennv2 = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.mass = new MaskedTextBox.MaskedTextBox();
			this.cachthucde = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.xuly = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.conthu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thang)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tuan)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, 11);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(760, 157);
			this.dataGrid1.TabIndex = 200;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(21, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 210;
			this.label1.Text = "Ngày sinh :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(432, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 23;
			this.label2.Text = "Ngôi thai :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(432, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 25;
			this.label3.Text = "Giới tính :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(635, 271);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 26;
			this.label4.Text = "Tình trạng :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(216, 223);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 23);
			this.label5.TabIndex = 27;
			this.label5.Text = "Dị tật :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(424, 247);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 28;
			this.label6.Text = "Cân nặng :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cannang
			// 
			this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cannang.Enabled = false;
			this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cannang.Location = new System.Drawing.Point(488, 247);
			this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.cannang.MaxLength = 4;
			this.cannang.Name = "cannang";
			this.cannang.Size = new System.Drawing.Size(40, 21);
			this.cannang.TabIndex = 16;
			this.cannang.Text = "";
			this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
			// 
			// phai
			// 
			this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.phai.Enabled = false;
			this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.phai.Items.AddRange(new object[] {
													  "Nam",
													  "Nữ"});
			this.phai.Location = new System.Drawing.Point(488, 200);
			this.phai.Name = "phai";
			this.phai.Size = new System.Drawing.Size(160, 21);
			this.phai.TabIndex = 6;
			this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
			// 
			// tinhtrang
			// 
			this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tinhtrang.Enabled = false;
			this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tinhtrang.Items.AddRange(new object[] {
														   "Sống",
														   "Chết"});
			this.tinhtrang.Location = new System.Drawing.Point(714, 271);
			this.tinhtrang.Name = "tinhtrang";
			this.tinhtrang.Size = new System.Drawing.Size(56, 21);
			this.tinhtrang.TabIndex = 23;
			this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
			// 
			// ditat
			// 
			this.ditat.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ditat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ditat.Enabled = false;
			this.ditat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ditat.Items.AddRange(new object[] {
													   "Không",
													   "Có"});
			this.ditat.Location = new System.Drawing.Point(256, 223);
			this.ditat.Name = "ditat";
			this.ditat.Size = new System.Drawing.Size(64, 21);
			this.ditat.TabIndex = 10;
			this.ditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ditat_KeyDown);
			this.ditat.SelectedIndexChanged += new System.EventHandler(this.ditat_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(518, 247);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 23);
			this.label7.TabIndex = 33;
			this.label7.Text = "gram";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butThem
			// 
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(132, 334);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(75, 28);
			this.butThem.TabIndex = 27;
			this.butThem.Text = "     &Thêm";
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(210, 334);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(75, 28);
			this.butSua.TabIndex = 28;
			this.butSua.Text = "     &Sửa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(288, 334);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 25;
			this.butLuu.Text = "     &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(366, 334);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(75, 28);
			this.butBoqua.TabIndex = 26;
			this.butBoqua.Text = "     &Bỏ qua";
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(444, 334);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(75, 28);
			this.butHuy.TabIndex = 29;
			this.butHuy.Text = "    &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(522, 334);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 30;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(8, 5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 23);
			this.label8.TabIndex = 40;
			this.label8.Text = "Họ tên mẹ :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(208, 5);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 23);
			this.label9.TabIndex = 41;
			this.label9.Text = "Tuổi :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(336, 5);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 23);
			this.label10.TabIndex = 42;
			this.label10.Text = "Ngày để (mổ đẻ) :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(72, 5);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(152, 21);
			this.hoten.TabIndex = 43;
			this.hoten.Text = "";
			// 
			// tuoi
			// 
			this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tuoi.Enabled = false;
			this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tuoi.Location = new System.Drawing.Point(272, 5);
			this.tuoi.Name = "tuoi";
			this.tuoi.Size = new System.Drawing.Size(48, 21);
			this.tuoi.TabIndex = 44;
			this.tuoi.Text = "";
			// 
			// ngayde
			// 
			this.ngayde.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayde.Enabled = false;
			this.ngayde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayde.Location = new System.Drawing.Point(429, 5);
			this.ngayde.Name = "ngayde";
			this.ngayde.Size = new System.Drawing.Size(94, 21);
			this.ngayde.TabIndex = 45;
			this.ngayde.Text = "";
			// 
			// ngay
			// 
			this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngay.Enabled = false;
			this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngay.Location = new System.Drawing.Point(86, 176);
			this.ngay.Mask = "##/##/#### ##:##";
			this.ngay.Name = "ngay";
			this.ngay.Size = new System.Drawing.Size(94, 21);
			this.ngay.TabIndex = 0;
			this.ngay.Text = "";
			this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
			// 
			// label39
			// 
			this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label39.Location = new System.Drawing.Point(552, 247);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(40, 23);
			this.label39.TabIndex = 210;
			this.label39.Text = "Cao";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// vongdau
			// 
			this.vongdau.BackColor = System.Drawing.SystemColors.HighlightText;
			this.vongdau.Enabled = false;
			this.vongdau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.vongdau.Location = new System.Drawing.Point(714, 247);
			this.vongdau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.vongdau.MaxLength = 5;
			this.vongdau.Name = "vongdau";
			this.vongdau.Size = new System.Drawing.Size(32, 21);
			this.vongdau.TabIndex = 18;
			this.vongdau.Text = "";
			// 
			// cao
			// 
			this.cao.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cao.Enabled = false;
			this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cao.Location = new System.Drawing.Point(596, 247);
			this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.cao.MaxLength = 5;
			this.cao.Name = "cao";
			this.cao.Size = new System.Drawing.Size(32, 21);
			this.cao.TabIndex = 17;
			this.cao.Text = "";
			// 
			// apgar10
			// 
			this.apgar10.BackColor = System.Drawing.SystemColors.HighlightText;
			this.apgar10.Enabled = false;
			this.apgar10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.apgar10.Location = new System.Drawing.Point(317, 247);
			this.apgar10.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.apgar10.MaxLength = 3;
			this.apgar10.Name = "apgar10";
			this.apgar10.Size = new System.Drawing.Size(40, 21);
			this.apgar10.TabIndex = 15;
			this.apgar10.Text = "";
			// 
			// apgar5
			// 
			this.apgar5.BackColor = System.Drawing.SystemColors.HighlightText;
			this.apgar5.Enabled = false;
			this.apgar5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.apgar5.Location = new System.Drawing.Point(202, 249);
			this.apgar5.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.apgar5.MaxLength = 3;
			this.apgar5.Name = "apgar5";
			this.apgar5.Size = new System.Drawing.Size(40, 21);
			this.apgar5.TabIndex = 14;
			this.apgar5.Text = "";
			// 
			// apgar1
			// 
			this.apgar1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.apgar1.Enabled = false;
			this.apgar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.apgar1.Location = new System.Drawing.Point(86, 249);
			this.apgar1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.apgar1.MaxLength = 3;
			this.apgar1.Name = "apgar1";
			this.apgar1.Size = new System.Drawing.Size(40, 21);
			this.apgar1.TabIndex = 13;
			this.apgar1.Text = "";
			// 
			// label47
			// 
			this.label47.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label47.Location = new System.Drawing.Point(743, 247);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(32, 23);
			this.label47.TabIndex = 214;
			this.label47.Text = "cm";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label44
			// 
			this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label44.Location = new System.Drawing.Point(628, 247);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(24, 23);
			this.label44.TabIndex = 213;
			this.label44.Text = "cm";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label40
			// 
			this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label40.Location = new System.Drawing.Point(643, 247);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(64, 23);
			this.label40.TabIndex = 211;
			this.label40.Text = "Vòng đầu";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label37
			// 
			this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label37.Location = new System.Drawing.Point(357, 247);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(32, 23);
			this.label37.TabIndex = 208;
			this.label37.Text = "điểm";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label48
			// 
			this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label48.Location = new System.Drawing.Point(277, 247);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(48, 23);
			this.label48.TabIndex = 206;
			this.label48.Text = "10 phút";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label50
			// 
			this.label50.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label50.Location = new System.Drawing.Point(241, 248);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(32, 23);
			this.label50.TabIndex = 205;
			this.label50.Text = "điểm";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label51
			// 
			this.label51.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label51.Location = new System.Drawing.Point(165, 250);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(42, 23);
			this.label51.TabIndex = 203;
			this.label51.Text = "5 phút";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label54
			// 
			this.label54.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label54.Location = new System.Drawing.Point(127, 250);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(32, 23);
			this.label54.TabIndex = 202;
			this.label54.Text = "điểm";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label65
			// 
			this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label65.Location = new System.Drawing.Point(48, 250);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(42, 23);
			this.label65.TabIndex = 200;
			this.label65.Text = "1 phút :";
			this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label66
			// 
			this.label66.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label66.Location = new System.Drawing.Point(-4, 247);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(44, 23);
			this.label66.TabIndex = 199;
			this.label66.Text = "Apgar ";
			this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngoithai
			// 
			this.ngoithai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngoithai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ngoithai.Enabled = false;
			this.ngoithai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngoithai.Location = new System.Drawing.Point(488, 176);
			this.ngoithai.Name = "ngoithai";
			this.ngoithai.Size = new System.Drawing.Size(160, 21);
			this.ngoithai.TabIndex = 2;
			this.ngoithai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngoithai_KeyDown);
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(400, 223);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 23);
			this.label11.TabIndex = 47;
			this.label11.Text = "Dị tật bẩm sinh :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// madt
			// 
			this.madt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.madt.Enabled = false;
			this.madt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madt.Location = new System.Drawing.Point(488, 223);
			this.madt.Name = "madt";
			this.madt.Size = new System.Drawing.Size(46, 21);
			this.madt.TabIndex = 11;
			this.madt.Text = "";
			this.madt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madt_KeyDown);
			this.madt.Validated += new System.EventHandler(this.madt_Validated);
			// 
			// tendt
			// 
			this.tendt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tendt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tendt.Enabled = false;
			this.tendt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tendt.Location = new System.Drawing.Point(536, 223);
			this.tendt.Name = "tendt";
			this.tendt.Size = new System.Drawing.Size(232, 21);
			this.tendt.TabIndex = 12;
			this.tendt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendt_KeyDown);
			this.tendt.SelectedIndexChanged += new System.EventHandler(this.tendt_SelectedIndexChanged);
			// 
			// label12
			// 
			this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label12.Location = new System.Drawing.Point(655, 176);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 23);
			this.label12.TabIndex = 50;
			this.label12.Text = "Con thứ :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(200, 200);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 51;
			this.label13.Text = "Họ tên :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hotentre
			// 
			this.hotentre.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hotentre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hotentre.Enabled = false;
			this.hotentre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hotentre.Location = new System.Drawing.Point(256, 200);
			this.hotentre.Name = "hotentre";
			this.hotentre.Size = new System.Drawing.Size(176, 21);
			this.hotentre.TabIndex = 5;
			this.hotentre.Text = "";
			this.hotentre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			// 
			// duthang
			// 
			this.duthang.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.duthang.Enabled = false;
			this.duthang.ForeColor = System.Drawing.SystemColors.ControlText;
			this.duthang.Location = new System.Drawing.Point(655, 200);
			this.duthang.Name = "duthang";
			this.duthang.Size = new System.Drawing.Size(72, 24);
			this.duthang.TabIndex = 7;
			this.duthang.Text = "Đủ tháng";
			this.duthang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.duthang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			this.duthang.CheckedChanged += new System.EventHandler(this.duthang_CheckedChanged);
			// 
			// label14
			// 
			this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label14.Location = new System.Drawing.Point(29, 224);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 23);
			this.label14.TabIndex = 222;
			this.label14.Text = "Tháng :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label15.Location = new System.Drawing.Point(119, 224);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 23);
			this.label15.TabIndex = 223;
			this.label15.Text = "Tuần";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// conthu
			// 
			this.conthu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.conthu.Enabled = false;
			this.conthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.conthu.Location = new System.Drawing.Point(714, 176);
			this.conthu.Maximum = new System.Decimal(new int[] {
																   99,
																   0,
																   0,
																   0});
			this.conthu.Name = "conthu";
			this.conthu.Size = new System.Drawing.Size(54, 21);
			this.conthu.TabIndex = 3;
			this.conthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			// 
			// thang
			// 
			this.thang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.thang.Enabled = false;
			this.thang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.thang.Location = new System.Drawing.Point(86, 225);
			this.thang.Maximum = new System.Decimal(new int[] {
																  99,
																  0,
																  0,
																  0});
			this.thang.Name = "thang";
			this.thang.Size = new System.Drawing.Size(40, 21);
			this.thang.TabIndex = 8;
			this.thang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			this.thang.ValueChanged += new System.EventHandler(this.thang_ValueChanged);
			// 
			// tuan
			// 
			this.tuan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tuan.Enabled = false;
			this.tuan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tuan.Location = new System.Drawing.Point(167, 225);
			this.tuan.Maximum = new System.Decimal(new int[] {
																 99,
																 0,
																 0,
																 0});
			this.tuan.Name = "tuan";
			this.tuan.Size = new System.Drawing.Size(40, 21);
			this.tuan.TabIndex = 9;
			this.tuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			// 
			// label16
			// 
			this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label16.Location = new System.Drawing.Point(8, 271);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(80, 23);
			this.label16.TabIndex = 227;
			this.label16.Text = "Người đỡ 1 :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label17.Location = new System.Drawing.Point(348, 271);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(72, 23);
			this.label17.TabIndex = 228;
			this.label17.Text = "Người đỡ 2 :";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// manv1
			// 
			this.manv1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manv1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.manv1.Enabled = false;
			this.manv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manv1.Location = new System.Drawing.Point(86, 271);
			this.manv1.Name = "manv1";
			this.manv1.Size = new System.Drawing.Size(48, 21);
			this.manv1.TabIndex = 19;
			this.manv1.Text = "";
			this.manv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			this.manv1.Validated += new System.EventHandler(this.manv1_Validated);
			// 
			// manv2
			// 
			this.manv2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manv2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.manv2.Enabled = false;
			this.manv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manv2.Location = new System.Drawing.Point(420, 271);
			this.manv2.Name = "manv2";
			this.manv2.Size = new System.Drawing.Size(48, 21);
			this.manv2.TabIndex = 21;
			this.manv2.Text = "";
			this.manv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			this.manv2.Validated += new System.EventHandler(this.manv2_Validated);
			// 
			// tennv1
			// 
			this.tennv1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennv1.Enabled = false;
			this.tennv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennv1.Location = new System.Drawing.Point(135, 271);
			this.tennv1.Name = "tennv1";
			this.tennv1.Size = new System.Drawing.Size(175, 21);
			this.tennv1.TabIndex = 20;
			this.tennv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			this.tennv1.SelectedIndexChanged += new System.EventHandler(this.tennv1_SelectedIndexChanged);
			// 
			// tennv2
			// 
			this.tennv2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennv2.Enabled = false;
			this.tennv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennv2.Location = new System.Drawing.Point(469, 271);
			this.tennv2.Name = "tennv2";
			this.tennv2.Size = new System.Drawing.Size(175, 21);
			this.tennv2.TabIndex = 22;
			this.tennv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			this.tennv2.SelectedIndexChanged += new System.EventHandler(this.tennv2_SelectedIndexChanged);
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(37, 200);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 23);
			this.label18.TabIndex = 229;
			this.label18.Text = "Mã số :";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mass
			// 
			this.mass.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mass.Enabled = false;
			this.mass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mass.Location = new System.Drawing.Point(86, 200);
			this.mass.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.mass.MaxLength = 8;
			this.mass.Name = "mass";
			this.mass.Size = new System.Drawing.Size(64, 21);
			this.mass.TabIndex = 4;
			this.mass.Text = "";
			this.mass.Validated += new System.EventHandler(this.mass_Validated);
			// 
			// cachthucde
			// 
			this.cachthucde.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cachthucde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cachthucde.Enabled = false;
			this.cachthucde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cachthucde.Location = new System.Drawing.Point(256, 176);
			this.cachthucde.Name = "cachthucde";
			this.cachthucde.Size = new System.Drawing.Size(176, 21);
			this.cachthucde.TabIndex = 1;
			this.cachthucde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachthucde_KeyDown);
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(176, 176);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(80, 23);
			this.label19.TabIndex = 231;
			this.label19.Text = "Cách thức đẻ :";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label20.Location = new System.Drawing.Point(-16, 295);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(104, 23);
			this.label20.TabIndex = 232;
			this.label20.Text = "Xử lý và kết quả :";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// xuly
			// 
			this.xuly.BackColor = System.Drawing.SystemColors.HighlightText;
			this.xuly.Enabled = false;
			this.xuly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xuly.Location = new System.Drawing.Point(86, 295);
			this.xuly.Name = "xuly";
			this.xuly.Size = new System.Drawing.Size(682, 21);
			this.xuly.TabIndex = 24;
			this.xuly.Text = "";
			this.xuly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
			// 
			// frmTresosinh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tendt,
																		  this.ngay,
																		  this.xuly,
																		  this.label20,
																		  this.label19,
																		  this.cachthucde,
																		  this.mass,
																		  this.conthu,
																		  this.label18,
																		  this.phai,
																		  this.duthang,
																		  this.ditat,
																		  this.label37,
																		  this.apgar10,
																		  this.apgar5,
																		  this.apgar1,
																		  this.ngoithai,
																		  this.tennv2,
																		  this.tennv1,
																		  this.manv2,
																		  this.manv1,
																		  this.label17,
																		  this.label16,
																		  this.tuan,
																		  this.thang,
																		  this.label15,
																		  this.label14,
																		  this.hotentre,
																		  this.label13,
																		  this.label12,
																		  this.madt,
																		  this.label11,
																		  this.ngayde,
																		  this.tuoi,
																		  this.hoten,
																		  this.label10,
																		  this.label9,
																		  this.label8,
																		  this.butKetthuc,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butSua,
																		  this.butThem,
																		  this.cannang,
																		  this.label7,
																		  this.tinhtrang,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1,
																		  this.dataGrid1,
																		  this.label66,
																		  this.label65,
																		  this.label54,
																		  this.label51,
																		  this.label50,
																		  this.label48,
																		  this.label39,
																		  this.cao,
																		  this.label44,
																		  this.label40,
																		  this.vongdau,
																		  this.label47});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTresosinh";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thông tin trẻ sơ sinh";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTresosinh_KeyDown);
			this.Load += new System.EventHandler(this.frmTresosinh_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.conthu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thang)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tuan)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmTresosinh_Load(object sender, System.EventArgs e)
		{
			m_mann="";
			foreach(DataRow r in m.get_data("select * from btdnn_bv where mannbo='01' order by mann").Tables[0].Rows)
			{
				m_mann=r["mann"].ToString();
				break;
			}
			ngoithai.DisplayMember="TEN";
			ngoithai.ValueMember="MA";
			ngoithai.DataSource=m.get_data("select * from dmngoithai order by stt").Tables[0];

			tendt.DisplayMember="TEN";
			tendt.ValueMember="MA";
			tendt.DataSource=m.get_data("select * from dmditat order by stt").Tables[0];

			tennv1.DisplayMember="HOTEN";
			tennv1.ValueMember="MA";
			tennv1.DataSource=m.get_data("select * from dmbs where nhom not in ("+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];

			tennv2.DisplayMember="HOTEN";
			tennv2.ValueMember="MA";
			tennv2.DataSource=m.get_data("select * from dmbs where nhom not in ("+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];

			cachthucde.DisplayMember="TEN";
			cachthucde.ValueMember="ID";
			cachthucde.DataSource=m.get_data("select * from dmkieusanh order by stt").Tables[0];

			bAdmin=m.bAdmin(m_userid);
			s_msg=LibMedi.AccessData.Msg;
			songay=m.Ngaylv_Ngayht;
			hoten.Text=m_hoten;
			tuoi.Text=m_tuoi;
			ngayde.Text=m_ngay;
			s_ngay=ngayde.Text;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
			if (dt.Rows.Count==0) butThem_Click(null,null);
		}

		private void load_grid()
		{
			sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten as tenngoithai,b.ma,";
			sql+="decode(a.phai,0,'Nam','Nu') as t_phai,decode(a.tinhtrang,0,'Song','Chet') as t_tinhtrang,";
			sql+="decode(a.ditat,0,'Không','Có') as t_ditat,a.cannang,a.phai,a.tinhtrang,a.ditat,a.id_ss,d.ten as tencachthucde,";
			sql+="c.apgar1,c.apgar5,c.apgar10,c.conthu,c.mass,c.hoten,c.duthang,c.thang,c.tuan,c.manv1,c.manv2,c.cachthucde,c.xuly,";
			sql+="c.cao,c.vongdau,c.ditatbs,e.ten as tenditat,a.ngoithai ";
			sql+=" from tresosinh a,dmngoithai b,ddsosinh c,dmkieusanh d,dmditat e ";
			sql+=" where a.ngoithai=b.ma and a.id_ss=c.maql and c.cachthucde=d.id and c.ditatbs=e.ma(+) and a.maql="+m_maql+" order by a.id_ss";
			dt=m.get_data(sql).Tables[0];
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
			TextCol.MappingName = "id_ss";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày sinh";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenngoithai";
			TextCol.HeaderText = "Ngôi thai";
			TextCol.Width = 85;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_phai";
			TextCol.HeaderText = "Giới tính";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tencachthucde";
			TextCol.HeaderText = "Cách thức đẻ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cao";
			TextCol.HeaderText = "Cao";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vongdau";
			TextCol.HeaderText = "Vòng đầu";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_tinhtrang";
			TextCol.HeaderText = "Tình trạng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_ditat";
			TextCol.HeaderText = "Dị tật";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenditat";
			TextCol.HeaderText = "Tật bẩm sinh";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			if (ngay.Text=="")
			{
				ngay.Focus();
				return;
			}
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ sinh !"),s_msg);
				ngay.Focus();
				return;
			}
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngay.Focus();
				return;
			}
			ngay.Text=m.Ktngaygio(ngay.Text,16);
			if (ngay.Text!=s_ngay)
			{
				if (!m.bNgaygio(ngay.Text,ngayde.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không được nhỏ hơn ngày đẻ (mổ đẻ) !"),s_msg);
					ngay.Focus();
					return;
				}

				if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
					ngay.Focus();
					return;
				}
			}
			SendKeys.Send("{F4}");
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (phai.SelectedIndex==-1) phai.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tinhtrang.SelectedIndex==-1) tinhtrang.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void ditat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (ditat.SelectedIndex==-1) ditat.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}	
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
            ngoithai.Enabled=ena;
			cachthucde.Enabled=ena;
			phai.Enabled=ena;
			tinhtrang.Enabled=ena;
			ditat.Enabled=ena;
			cannang.Enabled=ena;
			apgar1.Enabled=ena;apgar5.Enabled=ena;apgar10.Enabled=ena;
			cannang.Enabled=ena;cao.Enabled=ena;vongdau.Enabled=ena;
			duthang.Enabled=ena;
			mass.Enabled=ena;
			hotentre.Enabled=ena;
			conthu.Enabled=ena;
			manv1.Enabled=ena;
			tennv1.Enabled=ena;
			manv2.Enabled=ena;
			tennv2.Enabled=ena;
			xuly.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butThem.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void emp_text()
		{
			ngay.Text=m_ngay;
			ngoithai.SelectedIndex=-1;
			cachthucde.SelectedIndex=-1;
			mass.Text="";
			hotentre.Text="";
			conthu.Value=1;
			duthang.Checked=true;
			thang.Value=0;
			tuan.Value=0;
			madt.Text="";
			tendt.SelectedIndex=-1;
			tennv1.SelectedIndex=-1;
			tennv2.SelectedIndex=-1;
			manv1.Text="";
			manv2.Text="";
			phai.SelectedIndex=0;
			tinhtrang.SelectedIndex=0;
			ditat.SelectedIndex=0;
			cannang.Text="";
			apgar1.Text="";apgar5.Text="";apgar10.Text="";
			cannang.Text="";cao.Text="";vongdau.Text="";xuly.Text="";
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			m_id=m.get_capid(3);
			emp_text();
			ena_object(true);
			ngay.Focus();
			SendKeys.Send("{Home}");
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			m_id=long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
			ena_object(true);
			ngay.Focus();
			SendKeys.Send("{Home}");	
		}

		private bool kiemtra()
		{
			if (ngay.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày sinh !"),s_msg);
				ngay.Focus();
				return false;
			}
			if (ngoithai.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngôi thai !"),s_msg);
				ngoithai.Focus();
				return false;
			}

			if (cachthucde.SelectedIndex==-1)
			{
				cachthucde.Focus();
				return false;
			}
			if (phai.SelectedIndex==-1)
			{
				phai.Focus();
				return false;
			}

			if (tinhtrang.SelectedIndex==-1)
			{
				tinhtrang.Focus();
				return false;
			}

			if (ditat.SelectedIndex==-1)
			{
				ditat.Focus();
				return false;
			}
			else if (ditat.SelectedIndex==1 && madt.Text=="")
			{
				madt.Focus();
				return false;
			}

			if (cannang.Text=="" || cannang.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập cân nặng !"),s_msg);
				cannang.Focus();
				return false;
			}
			if (conthu.Value==0)
			{
				conthu.Focus();
				return false;
			}
			if (manv1.Text!="" && manv2.Text!="" && manv1.Text==manv2.Text)
			{
				MessageBox.Show("Người đỡ 1 & người đỡ 2 không được trùng nhau !",LibMedi.AccessData.Msg);
				manv1.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			if (!bAdmin)
			{
				if (m.get_data("select * from tresosinh where id_ss="+m_id).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
			m.upd_ddsosinh(m_mabn,m_id,(apgar1.Text!="")?int.Parse(apgar1.Text):0,(apgar5.Text!="")?int.Parse(apgar5.Text):0,(apgar10.Text!="")?int.Parse(apgar10.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,(cao.Text!="")?int.Parse(cao.Text):0,(vongdau.Text!="")?int.Parse(vongdau.Text):0,manv1.Text,manv2.Text,Convert.ToInt16(conthu.Value),hotentre.Text,(duthang.Checked)?1:0,Convert.ToInt16(thang.Value),Convert.ToInt16(tuan.Value),(ditat.SelectedIndex==1)?madt.Text:"",mass.Text,int.Parse(cachthucde.SelectedValue.ToString()),xuly.Text);
			if (!m.upd_tresosinh(m_id,m_maql,ngay.Text,ngoithai.SelectedValue.ToString(),phai.SelectedIndex,tinhtrang.SelectedIndex,ditat.SelectedIndex,int.Parse(cannang.Text),m_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin trẻ sơ sinh !"),s_msg);
				return;
			}
			if (mass.Text!="") m.upd_btdbn(mass.Text,hotentre.Text,ngay.Text.Substring(0,10),ngay.Text.Substring(6,4),phai.SelectedIndex,m_mann,"25","","","",m_matt,m_maqu,m_mapxa,m_userid);
			load_grid();
			ena_object(false);
			butThem.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			butThem.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_id=long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					m.execute_data("delete from tresosinh where id_ss="+m_id);
					m.execute_data("delete from ddsosinh where maql="+m_id);
					load_grid();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ngoithai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (ngoithai.SelectedIndex==-1 && ngoithai.Items.Count>0) ngoithai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				m_id=long.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				DataRow r=m.getrowbyid(dt,"id_ss="+m_id);
				if (r!=null)
				{
					ngay.Text=r["ngay"].ToString();
					ngoithai.SelectedValue=r["ngoithai"].ToString();
					phai.SelectedIndex=int.Parse(r["phai"].ToString());
					tinhtrang.SelectedIndex=int.Parse(r["tinhtrang"].ToString());
					ditat.SelectedIndex=int.Parse(r["ditat"].ToString());
					apgar1.Text=(r["apgar1"].ToString()=="0")?"":r["apgar1"].ToString();
					apgar5.Text=(r["apgar5"].ToString()=="0")?"":r["apgar5"].ToString();
					apgar10.Text=(r["apgar10"].ToString()=="0")?"":r["apgar10"].ToString();
					cannang.Text=(r["cannang"].ToString()=="0")?"":r["cannang"].ToString();
					cao.Text=(r["cao"].ToString()=="0")?"":r["cao"].ToString();
					vongdau.Text=(r["vongdau"].ToString()=="0")?"":r["vongdau"].ToString();
					conthu.Value=int.Parse(r["conthu"].ToString());
					mass.Text=r["mass"].ToString();
					hotentre.Text=r["hoten"].ToString();
					duthang.Checked=r["duthang"].ToString()=="1";
					thang.Value=int.Parse(r["thang"].ToString());
					tuan.Value=int.Parse(r["tuan"].ToString());
					manv1.Text=r["manv1"].ToString();
					tennv1.SelectedValue=manv1.Text;
					manv2.Text=r["manv2"].ToString();
					tennv2.SelectedValue=manv2.Text;
					madt.Text=r["ditatbs"].ToString();
					tendt.SelectedValue=madt.Text;
					cachthucde.SelectedValue=r["cachthucde"].ToString();
					xuly.Text=r["xuly"].ToString();
				}
			}
			catch{}
		}

		private void cannang_Validated(object sender, System.EventArgs e)
		{
			if (cannang.Text=="" || cannang.Text=="0") cannang.Focus();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void frmTresosinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void conthu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madt_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tendt.SelectedValue=madt.Text;
			}
			catch{}
		}

		private void tendt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendt) madt.Text=tendt.SelectedValue.ToString();
		}

		private void tendt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tendt.SelectedIndex==-1 && tendt.Items.Count>0) tendt.SelectedIndex=0;
				madt.Text=tendt.SelectedValue.ToString();
				SendKeys.Send("{Tab}");
			}
		}

		private void ditat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ditat)
			{
				madt.Enabled=ditat.SelectedIndex==1;
				tendt.Enabled=madt.Enabled;
			}
		}

		private void manv1_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennv1.SelectedValue=manv1.Text;
			}
			catch{}
		}

		private void manv2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tennv2.SelectedValue=manv2.Text;
			}
			catch{}
		}

		private void tennv1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennv1 && tennv1.SelectedIndex!=-1) manv1.Text=tennv1.SelectedValue.ToString();
		}

		private void tennv2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennv2 && tennv2.SelectedIndex!=-1) manv2.Text=tennv2.SelectedValue.ToString();
		}

		private void duthang_CheckedChanged(object sender, System.EventArgs e)
		{
			thang.Enabled=!duthang.Checked;
			tuan.Enabled=thang.Enabled;
		}

		private void thang_ValueChanged(object sender, System.EventArgs e)
		{
			tuan.Enabled=thang.Value==0;
		}

		private void madt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");		
		}

		private void mass_Validated(object sender, System.EventArgs e)
		{
			if (mass.Text=="") return;
			if (mass.Text.Trim().Length!=8) mass.Text=mass.Text.Substring(0,2)+mass.Text.Substring(2).PadLeft(6,'0');
			foreach(DataRow r in m.get_data("select * from btdbn where mabn='"+mass.Text+"'").Tables[0].Rows)
			{
				hotentre.Text=r["hoten"].ToString();
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				break;
			}
		}

		private void cachthucde_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (cachthucde.SelectedIndex==-1 && cachthucde.Items.Count>0) cachthucde.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}
	}
}
