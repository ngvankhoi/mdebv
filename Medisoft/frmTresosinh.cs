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
	/// Summary description for frmTresosinh.
	/// </summary>
	public class frmTresosinh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string nam,user,m_ngay,m_mabn,m_hoten,m_tuoi,sql,s_msg,s_ngay,m_mann,m_matt="",m_maqu="",m_mapxa="";
		private decimal m_maql,m_id;
		private int m_userid,songay;
		private bool bAdmin;
        private System.Data.DataTable dtbs = new System.Data.DataTable();
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
		private System.Windows.Forms.ComboBox ngoithai;
		private System.Windows.Forms.Label label18;
		private MaskedTextBox.MaskedTextBox mass;
        private ComboBox cachthucde;
        private Label label19;
        private MaskedBox.MaskedBox gio;
        private Label label20;
        private TextBox tennv1;
        private LibList.List listBS;
        private TextBox tennv2;
        private Button butIn;
        private NumericUpDown numSoChungSinh;
        private Label label21;
        private Label label22;
        private TextBox txtQuyenSo;
        private Label label23;
        private NumericUpDown numLanSinh;
        private Label label24;
        private NumericUpDown numSoConSong;
        private Label label25;
        private TextBox txtSucKhoeCon;
        private Label label26;
        private NumericUpDown numSoCon;
		private AccessData m;

		public frmTresosinh(AccessData acc,string mabn,string hoten,string tuoi,decimal maql,string ngay,int userid,string matt,string maqu,string mapxa)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTresosinh));
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
            this.label18 = new System.Windows.Forms.Label();
            this.mass = new MaskedTextBox.MaskedTextBox();
            this.cachthucde = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.gio = new MaskedBox.MaskedBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tennv1 = new System.Windows.Forms.TextBox();
            this.tennv2 = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.listBS = new LibList.List();
            this.numSoChungSinh = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtQuyenSo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.numLanSinh = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.numSoConSong = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.txtSucKhoeCon = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numSoCon = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conthu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoChungSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLanSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoConSong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoCon)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(712, 165);
            this.dataGrid1.TabIndex = 200;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(-2, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 210;
            this.label1.Text = "Ngày sinh :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(544, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ngôi thai :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(543, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 25;
            this.label3.Text = "Giới tính :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tình trạng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(242, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Dị tật :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(375, 246);
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
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(439, 246);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cannang.MaxLength = 4;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 17;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(596, 199);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(120, 21);
            this.phai.TabIndex = 7;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Items.AddRange(new object[] {
            "Sống",
            "Chết",
            "Thai chết lưu"});
            this.tinhtrang.Location = new System.Drawing.Point(80, 293);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(134, 21);
            this.tinhtrang.TabIndex = 24;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // ditat
            // 
            this.ditat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ditat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ditat.Enabled = false;
            this.ditat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ditat.Items.AddRange(new object[] {
            "Không",
            "Có"});
            this.ditat.Location = new System.Drawing.Point(280, 222);
            this.ditat.Name = "ditat";
            this.ditat.Size = new System.Drawing.Size(99, 21);
            this.ditat.TabIndex = 11;
            this.ditat.SelectedIndexChanged += new System.EventHandler(this.ditat_SelectedIndexChanged);
            this.ditat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ditat_KeyDown);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(471, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 23);
            this.label7.TabIndex = 33;
            this.label7.Text = "gram";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butThem
            // 
            this.butThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(92, 347);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 34;
            this.butThem.Text = "     &Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butSua
            // 
            this.butSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(162, 347);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 35;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(232, 347);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 31;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(427, 347);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 33;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(497, 347);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 36;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(567, 347);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 37;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(8, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 40;
            this.label8.Text = "Họ tên mẹ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(208, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 41;
            this.label9.Text = "Tuổi :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
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
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(72, 5);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 43;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(272, 5);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(48, 21);
            this.tuoi.TabIndex = 44;
            // 
            // ngayde
            // 
            this.ngayde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayde.Enabled = false;
            this.ngayde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayde.Location = new System.Drawing.Point(429, 5);
            this.ngayde.Name = "ngayde";
            this.ngayde.Size = new System.Drawing.Size(94, 21);
            this.ngayde.TabIndex = 45;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(58, 178);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(70, 21);
            this.ngay.TabIndex = 0;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(505, 246);
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
            this.vongdau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vongdau.Location = new System.Drawing.Point(662, 246);
            this.vongdau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vongdau.MaxLength = 5;
            this.vongdau.Name = "vongdau";
            this.vongdau.Size = new System.Drawing.Size(32, 21);
            this.vongdau.TabIndex = 19;
            // 
            // cao
            // 
            this.cao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cao.Enabled = false;
            this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cao.Location = new System.Drawing.Point(549, 246);
            this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cao.MaxLength = 5;
            this.cao.Name = "cao";
            this.cao.Size = new System.Drawing.Size(32, 21);
            this.cao.TabIndex = 18;
            // 
            // apgar10
            // 
            this.apgar10.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apgar10.Enabled = false;
            this.apgar10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar10.Location = new System.Drawing.Point(296, 246);
            this.apgar10.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.apgar10.MaxLength = 3;
            this.apgar10.Name = "apgar10";
            this.apgar10.Size = new System.Drawing.Size(40, 21);
            this.apgar10.TabIndex = 16;
            // 
            // apgar5
            // 
            this.apgar5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apgar5.Enabled = false;
            this.apgar5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar5.Location = new System.Drawing.Point(189, 248);
            this.apgar5.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.apgar5.MaxLength = 3;
            this.apgar5.Name = "apgar5";
            this.apgar5.Size = new System.Drawing.Size(40, 21);
            this.apgar5.TabIndex = 15;
            // 
            // apgar1
            // 
            this.apgar1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.apgar1.Enabled = false;
            this.apgar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apgar1.Location = new System.Drawing.Point(80, 248);
            this.apgar1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.apgar1.MaxLength = 3;
            this.apgar1.Name = "apgar1";
            this.apgar1.Size = new System.Drawing.Size(40, 21);
            this.apgar1.TabIndex = 14;
            // 
            // label47
            // 
            this.label47.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label47.Location = new System.Drawing.Point(696, 246);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(32, 23);
            this.label47.TabIndex = 214;
            this.label47.Text = "cm";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(581, 246);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(24, 23);
            this.label44.TabIndex = 213;
            this.label44.Text = "cm";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(596, 246);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 23);
            this.label40.TabIndex = 211;
            this.label40.Text = "Vòng đầu";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(336, 246);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 23);
            this.label37.TabIndex = 208;
            this.label37.Text = "điểm";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(256, 246);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 23);
            this.label48.TabIndex = 206;
            this.label48.Text = "10 phút";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label50.Location = new System.Drawing.Point(228, 247);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(32, 23);
            this.label50.TabIndex = 205;
            this.label50.Text = "điểm";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label51.Location = new System.Drawing.Point(152, 249);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(42, 23);
            this.label51.TabIndex = 203;
            this.label51.Text = "5 phút";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label54.Location = new System.Drawing.Point(120, 249);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(32, 23);
            this.label54.TabIndex = 202;
            this.label54.Text = "điểm";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(40, 249);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(42, 23);
            this.label65.TabIndex = 200;
            this.label65.Text = "1 phút";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label66.Location = new System.Drawing.Point(-8, 248);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(50, 23);
            this.label66.TabIndex = 199;
            this.label66.Text = "Apgar ";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngoithai
            // 
            this.ngoithai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngoithai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngoithai.Enabled = false;
            this.ngoithai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoithai.Location = new System.Drawing.Point(596, 177);
            this.ngoithai.Name = "ngoithai";
            this.ngoithai.Size = new System.Drawing.Size(120, 21);
            this.ngoithai.TabIndex = 3;
            this.ngoithai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngoithai_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(376, 223);
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
            this.madt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madt.Location = new System.Drawing.Point(464, 223);
            this.madt.Name = "madt";
            this.madt.Size = new System.Drawing.Size(46, 21);
            this.madt.TabIndex = 12;
            this.madt.Validated += new System.EventHandler(this.madt_Validated);
            this.madt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madt_KeyDown);
            // 
            // tendt
            // 
            this.tendt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendt.Enabled = false;
            this.tendt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendt.Location = new System.Drawing.Point(512, 222);
            this.tendt.Name = "tendt";
            this.tendt.Size = new System.Drawing.Size(204, 21);
            this.tendt.TabIndex = 13;
            this.tendt.SelectedIndexChanged += new System.EventHandler(this.tendt_SelectedIndexChanged);
            this.tendt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendt_KeyDown);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(5, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 23);
            this.label12.TabIndex = 50;
            this.label12.Text = "Con thứ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(204, 198);
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
            this.hotentre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotentre.Location = new System.Drawing.Point(257, 199);
            this.hotentre.Name = "hotentre";
            this.hotentre.Size = new System.Drawing.Size(288, 21);
            this.hotentre.TabIndex = 6;
            this.hotentre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // duthang
            // 
            this.duthang.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.duthang.Enabled = false;
            this.duthang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.duthang.Location = new System.Drawing.Point(0, 225);
            this.duthang.Name = "duthang";
            this.duthang.Size = new System.Drawing.Size(72, 24);
            this.duthang.TabIndex = 8;
            this.duthang.Text = "Đủ tháng";
            this.duthang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.duthang.CheckedChanged += new System.EventHandler(this.duthang_CheckedChanged);
            this.duthang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(77, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 23);
            this.label14.TabIndex = 222;
            this.label14.Text = "Tháng ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(148, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 23);
            this.label15.TabIndex = 223;
            this.label15.Text = "Tuần";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // conthu
            // 
            this.conthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.conthu.Enabled = false;
            this.conthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conthu.Location = new System.Drawing.Point(58, 201);
            this.conthu.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.conthu.Name = "conthu";
            this.conthu.Size = new System.Drawing.Size(32, 21);
            this.conthu.TabIndex = 4;
            this.conthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // thang
            // 
            this.thang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thang.Enabled = false;
            this.thang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thang.Location = new System.Drawing.Point(118, 224);
            this.thang.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(40, 21);
            this.thang.TabIndex = 9;
            this.thang.ValueChanged += new System.EventHandler(this.thang_ValueChanged);
            this.thang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // tuan
            // 
            this.tuan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuan.Enabled = false;
            this.tuan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuan.Location = new System.Drawing.Point(198, 224);
            this.tuan.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.tuan.Name = "tuan";
            this.tuan.Size = new System.Drawing.Size(40, 21);
            this.tuan.TabIndex = 10;
            this.tuan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(8, 270);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 23);
            this.label16.TabIndex = 227;
            this.label16.Text = "Người đỡ 1 :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(367, 270);
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
            this.manv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv1.Location = new System.Drawing.Point(80, 270);
            this.manv1.Name = "manv1";
            this.manv1.Size = new System.Drawing.Size(48, 21);
            this.manv1.TabIndex = 20;
            this.manv1.Validated += new System.EventHandler(this.manv1_Validated);
            this.manv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // manv2
            // 
            this.manv2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manv2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manv2.Enabled = false;
            this.manv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv2.Location = new System.Drawing.Point(439, 270);
            this.manv2.Name = "manv2";
            this.manv2.Size = new System.Drawing.Size(48, 21);
            this.manv2.TabIndex = 22;
            this.manv2.Validated += new System.EventHandler(this.manv2_Validated);
            this.manv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(80, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 23);
            this.label18.TabIndex = 229;
            this.label18.Text = "Mã số con :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mass
            // 
            this.mass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mass.Enabled = false;
            this.mass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mass.Location = new System.Drawing.Point(158, 201);
            this.mass.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mass.MaxLength = 8;
            this.mass.Name = "mass";
            this.mass.Size = new System.Drawing.Size(56, 21);
            this.mass.TabIndex = 5;
            this.mass.Validated += new System.EventHandler(this.mass_Validated);
            // 
            // cachthucde
            // 
            this.cachthucde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cachthucde.Enabled = false;
            this.cachthucde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachthucde.Location = new System.Drawing.Point(257, 177);
            this.cachthucde.Name = "cachthucde";
            this.cachthucde.Size = new System.Drawing.Size(288, 21);
            this.cachthucde.TabIndex = 2;
            this.cachthucde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachthucde_KeyDown);
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(193, 176);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 231;
            this.label19.Text = "Cách thức :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(158, 178);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(36, 21);
            this.gio.TabIndex = 1;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(128, 176);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 23);
            this.label20.TabIndex = 254;
            this.label20.Text = "giờ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennv1
            // 
            this.tennv1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv1.Enabled = false;
            this.tennv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv1.Location = new System.Drawing.Point(129, 270);
            this.tennv1.Name = "tennv1";
            this.tennv1.Size = new System.Drawing.Size(207, 21);
            this.tennv1.TabIndex = 21;
            this.tennv1.TextChanged += new System.EventHandler(this.tennv1_TextChanged);
            this.tennv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennv1_KeyDown);
            // 
            // tennv2
            // 
            this.tennv2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennv2.Enabled = false;
            this.tennv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennv2.Location = new System.Drawing.Point(488, 270);
            this.tennv2.Name = "tennv2";
            this.tennv2.Size = new System.Drawing.Size(228, 21);
            this.tennv2.TabIndex = 23;
            this.tennv2.TextChanged += new System.EventHandler(this.tennv2_TextChanged);
            this.tennv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennv2_KeyDown);
            // 
            // butIn
            // 
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(302, 347);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(125, 25);
            this.butIn.TabIndex = 32;
            this.butIn.Text = "In giấy chứng sinh";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(45, 301);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 269;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // numSoChungSinh
            // 
            this.numSoChungSinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numSoChungSinh.Enabled = false;
            this.numSoChungSinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoChungSinh.Location = new System.Drawing.Point(291, 294);
            this.numSoChungSinh.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numSoChungSinh.Name = "numSoChungSinh";
            this.numSoChungSinh.Size = new System.Drawing.Size(47, 21);
            this.numSoChungSinh.TabIndex = 25;
            this.numSoChungSinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numSoChungSinh_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(210, 293);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 23);
            this.label21.TabIndex = 272;
            this.label21.Text = "Sổ chứng sinh:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(385, 294);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 23);
            this.label22.TabIndex = 274;
            this.label22.Text = "Quyển sổ:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuyenSo
            // 
            this.txtQuyenSo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtQuyenSo.Enabled = false;
            this.txtQuyenSo.Location = new System.Drawing.Point(439, 294);
            this.txtQuyenSo.Name = "txtQuyenSo";
            this.txtQuyenSo.Size = new System.Drawing.Size(277, 20);
            this.txtQuyenSo.TabIndex = 26;
            this.txtQuyenSo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuyenSo_KeyDown);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(20, 318);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 23);
            this.label23.TabIndex = 276;
            this.label23.Text = "Lần sinh:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numLanSinh
            // 
            this.numLanSinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numLanSinh.Enabled = false;
            this.numLanSinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLanSinh.Location = new System.Drawing.Point(79, 319);
            this.numLanSinh.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numLanSinh.Name = "numLanSinh";
            this.numLanSinh.Size = new System.Drawing.Size(47, 21);
            this.numLanSinh.TabIndex = 27;
            this.numLanSinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numLanSinh_KeyDown);
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(216, 316);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 23);
            this.label24.TabIndex = 278;
            this.label24.Text = "Số con sống:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numSoConSong
            // 
            this.numSoConSong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numSoConSong.Enabled = false;
            this.numSoConSong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoConSong.Location = new System.Drawing.Point(291, 318);
            this.numSoConSong.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numSoConSong.Name = "numSoConSong";
            this.numSoConSong.Size = new System.Drawing.Size(47, 21);
            this.numSoConSong.TabIndex = 29;
            this.numSoConSong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numSoConSong_KeyDown);
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(357, 315);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 23);
            this.label25.TabIndex = 280;
            this.label25.Text = "Sức khỏe con:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSucKhoeCon
            // 
            this.txtSucKhoeCon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSucKhoeCon.Enabled = false;
            this.txtSucKhoeCon.Location = new System.Drawing.Point(439, 317);
            this.txtSucKhoeCon.Name = "txtSucKhoeCon";
            this.txtSucKhoeCon.Size = new System.Drawing.Size(277, 20);
            this.txtSucKhoeCon.TabIndex = 30;
            this.txtSucKhoeCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSucKhoeCon_KeyDown);
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(126, 317);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 23);
            this.label26.TabIndex = 281;
            this.label26.Text = "Số con :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numSoCon
            // 
            this.numSoCon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.numSoCon.Enabled = false;
            this.numSoCon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSoCon.Location = new System.Drawing.Point(177, 319);
            this.numSoCon.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numSoCon.Name = "numSoCon";
            this.numSoCon.Size = new System.Drawing.Size(37, 21);
            this.numSoCon.TabIndex = 28;
            this.numSoCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numSoCon_KeyDown);
            // 
            // frmTresosinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(728, 389);
            this.Controls.Add(this.numSoCon);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtSucKhoeCon);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.numSoConSong);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.numLanSinh);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtQuyenSo);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.numSoChungSinh);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tennv2);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.tennv1);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cachthucde);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.mass);
            this.Controls.Add(this.conthu);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.duthang);
            this.Controls.Add(this.ditat);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.apgar10);
            this.Controls.Add(this.apgar5);
            this.Controls.Add(this.apgar1);
            this.Controls.Add(this.ngoithai);
            this.Controls.Add(this.manv2);
            this.Controls.Add(this.manv1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tuan);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.hotentre);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tendt);
            this.Controls.Add(this.madt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.ngayde);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.cannang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.cao);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.vongdau);
            this.Controls.Add(this.label47);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTresosinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin trẻ sơ sinh";
            this.Load += new System.EventHandler(this.frmTresosinh_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTresosinh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conthu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoChungSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLanSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoConSong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoCon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTresosinh_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			m_mann="";
			foreach(DataRow r in m.get_data("select * from "+user+".btdnn_bv where mannbo='01' order by mann").Tables[0].Rows)
			{
				m_mann=r["mann"].ToString();
				break;
			}
            cachthucde.DisplayMember = "TEN";
            cachthucde.ValueMember = "ID";
            cachthucde.DataSource = m.get_data("select * from " + user + ".dmkieusanh order by stt").Tables[0];

			ngoithai.DisplayMember="TEN";
			ngoithai.ValueMember="MA";
            ngoithai.DataSource = m.get_data("select * from " + user + ".dmngoithai order by stt").Tables[0];

			tendt.DisplayMember="TEN";
			tendt.ValueMember="MA";
            tendt.DataSource = m.get_data("select * from " + user + ".dmditat order by stt").Tables[0];

			
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            dtbs = m.get_data("select ma, hoten from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by ma").Tables[0];
            listBS.DataSource = dtbs;

			//tennv21.DisplayMember="HOTEN";
			//tennv21.ValueMember="MA";
            //tennv21.DataSource = m.get_data("select ma, hoten from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by ma").Tables[0];

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
			sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten as ngoithai,b.ma,";
            sql += "case when a.phai=0 then 'Nam' else 'Nữ' end as t_phai,case when a.tinhtrang=0 then 'Sống' else 'Chết' end as t_tinhtrang,";
			sql+="case when a.ditat=0 then 'Không' else 'Có' end as t_ditat,a.cannang,a.phai,a.tinhtrang,a.ditat,a.id_ss ";
            sql += " from " + user + ".tresosinh a," + user + ".dmngoithai b where a.ngoithai=b.ma and a.maql=" + m_maql + " order by a.id_ss";
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
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày sinh";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngoithai";
			TextCol.HeaderText = "Ngôi thai";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_phai";
			TextCol.HeaderText = "Phái";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_tinhtrang";
			TextCol.HeaderText = "Tình trạng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "t_ditat";
			TextCol.HeaderText = "Dị tật";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 90;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "phai";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tinhtrang";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ditat";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "id_ss";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
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
            cachthucde.Enabled = ena;
            gio.Enabled = ena;
			ngay.Enabled=ena;
            ngoithai.Enabled=ena;
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
			butLuu.Enabled=ena;
            butIn.Enabled=!ena;
			butBoqua.Enabled=ena;
			butThem.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            numSoChungSinh.Enabled = ena;
            txtQuyenSo.Enabled = ena;
            numLanSinh.Enabled = ena;
            numSoCon.Enabled = ena;
            numSoConSong.Enabled = ena;
            txtSucKhoeCon.Enabled = ena;
		}

		private void emp_text()
		{
            ngay.Text = m_ngay.Substring(0, 10);
            gio.Text = m_ngay.Substring(11);
			ngoithai.SelectedIndex=-1;
            cachthucde.SelectedIndex = -1;
			mass.Text="";
			hotentre.Text="";
			conthu.Value=1;
			duthang.Checked=true;
			thang.Value=0;
			tuan.Value=0;
			madt.Text="";
			tendt.SelectedIndex=-1;
            tennv1.Text = "";
            tennv2.Text = "";
			manv1.Text="";
			manv2.Text="";
			phai.SelectedIndex=0;
			tinhtrang.SelectedIndex=0;
			ditat.SelectedIndex=0;
			cannang.Text="";
			apgar1.Text="";apgar5.Text="";apgar10.Text="";
			cannang.Text="";cao.Text="";vongdau.Text="";
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
            nam = "";
            m_id = m.getidyymmddhhmiss_stt_computer;//m.get_capid(3);
			emp_text();
			ena_object(true);
			ngay.Focus();
			SendKeys.Send("{Home}");
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dt.Rows.Count==0) return;
			m_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,9].ToString());
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
            if (cachthucde.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập cách thức !"), s_msg);
                cachthucde.Focus();
                return false;
            }
			if (ngoithai.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngôi thai !"),s_msg);
				ngoithai.Focus();
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
				MessageBox.Show(lan.Change_language_MessageText("Người đỡ 1 & người đỡ 2 không được trùng nhau !"),LibMedi.AccessData.Msg);
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
                if (m.get_data("select * from " + user + ".tresosinh where id_ss=" + m_id).Tables[0].Rows.Count != 0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
            m.upd_ddsosinh(m_mabn, m_id, (apgar1.Text != "") ? int.Parse(apgar1.Text) : 0, (apgar5.Text != "") ? int.Parse(apgar5.Text) : 0, (apgar10.Text != "") ? int.Parse(apgar10.Text) : 0, (cannang.Text != "") ? int.Parse(cannang.Text) : 0, (cao.Text != "") ? int.Parse(cao.Text) : 0, (vongdau.Text != "") ? int.Parse(vongdau.Text) : 0, manv1.Text, manv2.Text, Convert.ToInt16(conthu.Value), hotentre.Text, (duthang.Checked) ? 1 : 0, Convert.ToInt16(thang.Value), Convert.ToInt16(tuan.Value), (ditat.SelectedIndex == 1) ? madt.Text : "", mass.Text, int.Parse(cachthucde.SelectedValue.ToString()),Convert.ToInt16(numSoChungSinh.Value),txtQuyenSo.Text, Convert.ToInt16(numLanSinh.Value),Convert.ToInt16(numSoConSong.Value),txtSucKhoeCon.Text,Convert.ToInt16(numSoCon.Value));
			if (!m.upd_tresosinh(m_id,m_maql,ngay.Text+" "+gio.Text,ngoithai.SelectedValue.ToString(),phai.SelectedIndex,tinhtrang.SelectedIndex,ditat.SelectedIndex,int.Parse(cannang.Text),m_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin trẻ sơ sinh !"),s_msg);
				return;
			}
            if (mass.Text != "")
            {
                if (m.get_data("select * from " + user + ".btdbn where mabn='" + mass.Text + "'").Tables[0].Rows.Count == 0)
                {
                    if (nam == "") nam = m.get_mabn_nam(mass.Text);
                    m.upd_btdbn(mass.Text, hotentre.Text, ngay.Text.Substring(0, 10), ngay.Text.Substring(6, 4), phai.SelectedIndex, m_mann, "25", "", "", "", m_matt, m_maqu, m_mapxa, m_userid, nam);
                }
            }
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
				m_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,9].ToString());
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    m.execute_data("delete from " + user + ".tresosinh where id_ss=" + m_id);
                    m.execute_data("delete from " + user + ".ddsosinh where maql=" + m_id);
					load_grid();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
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
                ngay.Text = dataGrid1[i, 0].ToString().Substring(0, 10);
                gio.Text = dataGrid1[i, 0].ToString().Substring(11);
				ngoithai.SelectedValue=dataGrid1[i,10].ToString();
				cannang.Text=dataGrid1[i,5].ToString();
				phai.SelectedIndex=int.Parse(dataGrid1[i,6].ToString());
				tinhtrang.SelectedIndex=int.Parse(dataGrid1[i,7].ToString());
				ditat.SelectedIndex=int.Parse(dataGrid1[i,8].ToString());
				m_id=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,9].ToString());
                foreach (DataRow r in m.get_data("select * from " + user + ".ddsosinh where maql=" + m_id).Tables[0].Rows)
				{
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
                    manv1_Validated(null, null);
					
					manv2.Text=r["manv2"].ToString();
                    manv2_Validated(null, null);
					madt.Text=r["ditatbs"].ToString();
					tendt.SelectedValue=madt.Text;
                    cachthucde.SelectedValue = r["cachthucde"].ToString();
                    numSoChungSinh.Value = int.Parse(r["sochungsinh"].ToString());
                    txtQuyenSo.Text = r["quyensochungsinh"].ToString();
                    numLanSinh.Value = int.Parse(r["lansinh"].ToString());
                    numSoCon.Value = int.Parse(r["socon"].ToString());
                    numSoConSong.Value = int.Parse(r["soconsong"].ToString());
                    txtSucKhoeCon.Text = r["suckhoe"].ToString();
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
				//tennv11.SelectedValue=manv1.Text;
                if (manv1.Text != "")
                {
                    manv1.Text = manv1.Text.PadLeft(4, '0');
                    DataRow r = m.getrowbyid(dtbs, "ma='" + manv1.Text + "'");
                    if (r != null) tennv1.Text = r["hoten"].ToString();
                    else tennv1.Text = "";
                }
			}
			catch{}
		}

		private void manv2_Validated(object sender, System.EventArgs e)
		{
			try
			{				
                if (manv2.Text != "")
                {
                    manv2.Text = manv2.Text.PadLeft(4, '0');
                    DataRow r = m.getrowbyid(dtbs, "ma='" + manv2.Text + "'");
                    if (r != null) tennv2.Text = r["hoten"].ToString();
                    else tennv2.Text = "";
                }
			}
			catch{}
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
            if (mass.Text == m_mabn)
            {
                MessageBox.Show(lan.Change_language_MessageText("Mã số con không được trùng mã số mẹ " + m_mabn + " !"), LibMedi.AccessData.Msg);
                return;
            }
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + mass.Text + "'").Tables[0].Rows)
			{
                nam = r["nam"].ToString();
				hotentre.Text=r["hoten"].ToString();
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				break;
			}
		}

        private void cachthucde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (cachthucde.SelectedIndex == -1 && cachthucde.Items.Count > 0) cachthucde.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void ngay_Validated(object sender, System.EventArgs e)
        {
            if (ngay.Text == "")
            {
                ngay.Focus();
                return;
            }
            ngay.Text = ngay.Text.Trim();
            if (ngay.Text.Length == 6) ngay.Text = ngay.Text + DateTime.Now.Year.ToString();
            if (ngay.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ sinh !"), s_msg);
                ngay.Focus();
                return;
            }
            if (!m.bNgay(ngay.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                ngay.Focus();
                return;
            }
            if (s_ngay != "")
            {
                if (ngay.Text != s_ngay.Substring(0,10))
                {
                    if (!m.ngay(m.StringToDate(ngay.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                        ngay.Focus();
                        return;
                    }
                }
            }
        }

        private void gio_Validated(object sender, EventArgs e)
        {
            string sgio = (gio.Text.Trim() == "") ? "00:00" : gio.Text.Trim();
            gio.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(gio.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                gio.Focus();
                return;
            }
            if (ngay.Text+" "+gio.Text!= s_ngay)
            {
                if (!m.bNgaygio(ngay.Text+" "+gio.Text, ngayde.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày sinh không được nhỏ hơn ngày đẻ (mổ đẻ) !"), s_msg);
                    ngay.Focus();
                    return;
                }
                s_ngay = ngay.Text + " " + gio.Text;
            }
            SendKeys.Send("{F4}");
        }

        private void tennv1_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tennv1)
            {
                Filt_tenbs(tennv1.Text);
                listBS.BrowseToICD10(tennv1, manv1, manv2, manv1.Location.X, manv1.Location.Y + manv1.Height, manv1.Width + tennv1.Width + 2, manv1.Height);
            }
        }

        private void Filt_tenbs(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listBS.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void tennv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void tennv2_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tennv2)
            {
                Filt_tenbs(tennv2.Text);
                listBS.BrowseToICD10(tennv2, manv2, tinhtrang, manv2.Location.X, manv2.Location.Y + manv2.Height, manv2.Width + tennv2.Width + 2, manv2.Height);
            }
        }

        private void tennv2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            DataSet dsxml = new DataSet();
            sql = "select a.hoten as hotenme, a.namsinh,a.sonha ||' - '|| a.thon||b.tenpxa||' - '||c.tenquan ||' - '||d.tentt as diachi,a.cmnd,"+
            "e.dantoc,to_char(g.ngay,'dd/mm/yyyy hh24:mi') as ngaysinh,to_char(sysdate,'dd/mm/yyyy') as ngay,f.conthu solansinh,f.socon,f.soconsong,"+
            "f.lansinh soconsinh,case when g.phai=0 then 'Nam' else 'Nữ' end as phai,g.cannang,f.suckhoe,f.hoten as tencon,f.manv1,f.manv2,"+
            "f.sochungsinh,f.quyensochungsinh";
            sql += " from " + user + ".btdbn a," + user + ".btdpxa b," + user + ".btdquan c," + user + ".btdtt d," + user + ".btddt e," + user + ".ddsosinh f," + user + ".tresosinh g";
            sql += " where a.maphuongxa=b.maphuongxa and a.maqu=c.maqu and a.matt=d.matt and a.madantoc=e.madantoc and a.mabn=f.mabn and f.maql=g.id_ss";
            sql += " and a.mabn='" + m_mabn + "'";
            if (m_maql != 0) sql += " and g.maql=" + m_maql;
            sql += " order by g.maql desc";
            dsxml = m.get_data(sql);
            DataTable dtbs = new DataTable();
            dtbs = m.get_data("select ma,hoten from " + user + ".dmbs").Tables[0];
            if (dsxml.Tables[0].Rows.Count > 0 && dsxml != null)
            {
                try { dsxml.Tables[0].Columns.Add("NGUOIDO1"); }
                catch { }
                try { dsxml.Tables[0].Columns.Add("NGUOIDO2"); }
                catch { }
                foreach (DataRow dr in dsxml.Tables[0].Rows)
                {
                    DataRow r1 = m.getrowbyid(dtbs, "ma='" + dr["manv1"].ToString() + "'");
                    dr["nguoido1"] = r1["hoten"].ToString();
                    DataRow r2 = m.getrowbyid(dtbs, "ma='" + dr["manv2"].ToString() + "'");
                    dr["nguoido2"] = r2["hoten"].ToString();
                }
                dsxml.AcceptChanges();
                if (!System.IO.Directory.Exists("..\\xml")) { System.IO.Directory.CreateDirectory("..\\xml"); }
                dsxml.WriteXml("..\\xml\\giaychungsinh.xml", XmlWriteMode.WriteSchema);
                frmReport f = new frmReport(dsxml, m.Syte, m.Tenbv, "rptGiaychungsinh.rpt");
                f.ShowDialog();
            }
        }

        private void numSoChungSinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void numLanSinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void numSoCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtQuyenSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void numSoConSong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void txtSucKhoeCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}{F4}");
            }
        }
	}
}
