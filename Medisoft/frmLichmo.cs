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
	/// Summary description for frmPttt.
	/// </summary>
	public class frmLichmo : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.TextBox phuongphap;
		private System.Windows.Forms.ComboBox tenphuongphap;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private MaskedTextBox.MaskedTextBox icd_t;
		private AccessData m;
		private string m_makp,s_msg,sql,user;
		private string s_mabn,m_tuoivao,m_loaituoi,s_ngay;
		private int m_userid,songay;
		private decimal l_maql,l_id,l_idkhoa;
		private bool bStatus=false,bAdmin;
		private LibList.List listpttt;
		private System.ComponentModel.IContainer components=null;
		private string s_icd_t="",s_tenkp="";
		private System.Windows.Forms.TextBox cd_t;
		private LibList.List listICD;
		private DataTable dticd=new DataTable();
		private LibList.List listBS;
		private DataTable dtmau=new DataTable();
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox phu1;
		private System.Windows.Forms.TextBox tenphu1;
		private System.Windows.Forms.TextBox tenbsgayme;
		private System.Windows.Forms.TextBox bsgayme;
		private MaskedTextBox.MaskedTextBox mamau;
		private System.Windows.Forms.TextBox tenmau; 
		private DataTable dtbs=new DataTable();
		private System.Windows.Forms.NumericUpDown sophieu;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel1;
		private LibList.List listHoten;
		private DataTable dthoten=new DataTable();
		private DataTable dtpt=new DataTable();
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataSet ds=new DataSet();

		public frmLichmo(AccessData acc,string makp,string tenkp,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m_makp = makp; s_tenkp = tenkp;
			m_userid=userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLichmo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.icd_t = new MaskedTextBox.MaskedTextBox();
            this.phuongphap = new System.Windows.Forms.TextBox();
            this.tenphuongphap = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.listpttt = new LibList.List();
            this.cd_t = new System.Windows.Forms.TextBox();
            this.listICD = new LibList.List();
            this.listBS = new LibList.List();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.phu1 = new System.Windows.Forms.TextBox();
            this.tenphu1 = new System.Windows.Forms.TextBox();
            this.tenbsgayme = new System.Windows.Forms.TextBox();
            this.bsgayme = new System.Windows.Forms.TextBox();
            this.mamau = new MaskedTextBox.MaskedTextBox();
            this.tenmau = new System.Windows.Forms.TextBox();
            this.sophieu = new System.Windows.Forms.NumericUpDown();
            this.butTim = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.listHoten = new LibList.List();
            ((System.ComponentModel.ISupportInitialize)(this.sophieu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(128, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Thứ tự :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(136, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(411, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tuổi :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(24, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ngày :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(224, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "CĐ Trước phẫu thủ thuật :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(0, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "Phương pháp vô cảm :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(-8, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 21;
            this.label10.Text = "Phương pháp phẫu thủ thuật :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(408, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 23);
            this.label14.TabIndex = 27;
            this.label14.Text = "Phẫu thủ thuật viên :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(506, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 6;
            this.label15.Text = "Giới tính :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(8, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 10;
            this.label16.Text = "Địa chỉ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(608, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 8;
            this.label17.Text = "Số thẻ :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(600, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 12;
            this.label18.Text = "Số giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(184, 9);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(232, 21);
            this.hoten.TabIndex = 3;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(65, 9);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(64, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(450, 9);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(56, 21);
            this.tuoi.TabIndex = 5;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(562, 8);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(38, 21);
            this.phai.TabIndex = 7;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(65, 32);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(535, 21);
            this.diachi.TabIndex = 11;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(664, 8);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(120, 21);
            this.sothe.TabIndex = 9;
            // 
            // giuong
            // 
            this.giuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(664, 32);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(120, 21);
            this.giuong.TabIndex = 13;
            // 
            // ngay
            // 
            this.ngay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(65, 56);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 15;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // icd_t
            // 
            this.icd_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_t.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_t.Enabled = false;
            this.icd_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_t.Location = new System.Drawing.Point(360, 56);
            this.icd_t.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.icd_t.MaxLength = 9;
            this.icd_t.Name = "icd_t";
            this.icd_t.Size = new System.Drawing.Size(54, 21);
            this.icd_t.TabIndex = 19;
            this.icd_t.Validated += new System.EventHandler(this.icd_t_Validated);
            // 
            // phuongphap
            // 
            this.phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phuongphap.Enabled = false;
            this.phuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phuongphap.Location = new System.Drawing.Point(184, 103);
            this.phuongphap.MaxLength = 2;
            this.phuongphap.Name = "phuongphap";
            this.phuongphap.Size = new System.Drawing.Size(24, 21);
            this.phuongphap.TabIndex = 25;
            this.phuongphap.Validated += new System.EventHandler(this.phuongphap_Validated);
            this.phuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phuongphap_KeyDown);
            // 
            // tenphuongphap
            // 
            this.tenphuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphuongphap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenphuongphap.Enabled = false;
            this.tenphuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphuongphap.Location = new System.Drawing.Point(210, 103);
            this.tenphuongphap.Name = "tenphuongphap";
            this.tenphuongphap.Size = new System.Drawing.Size(214, 21);
            this.tenphuongphap.TabIndex = 26;
            this.tenphuongphap.SelectedIndexChanged += new System.EventHandler(this.tenphuongphap_SelectedIndexChanged);
            this.tenphuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenphuongphap_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(528, 103);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 28;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.BackColor = System.Drawing.Color.Transparent;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(145, 488);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 38;
            this.butMoi.Text = "    &Mới";
            this.butMoi.UseVisualStyleBackColor = false;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.BackColor = System.Drawing.Color.Transparent;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(215, 488);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 39;
            this.butSua.Text = "    &Sửa";
            this.butSua.UseVisualStyleBackColor = false;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(285, 488);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 36;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(355, 488);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 37;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.BackColor = System.Drawing.Color.Transparent;
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(425, 488);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 40;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.UseVisualStyleBackColor = false;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(565, 488);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 42;
            this.butIn.Text = "    &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(635, 488);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 43;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(184, 544);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 39;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            // 
            // cd_t
            // 
            this.cd_t.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cd_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_t.Enabled = false;
            this.cd_t.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_t.Location = new System.Drawing.Point(416, 56);
            this.cd_t.Name = "cd_t";
            this.cd_t.Size = new System.Drawing.Size(368, 21);
            this.cd_t.TabIndex = 20;
            this.cd_t.TextChanged += new System.EventHandler(this.cd_t_TextChanged);
            this.cd_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_t_KeyDown);
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(104, 544);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 223;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(24, 544);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 224;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(568, 103);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(216, 21);
            this.tenbs.TabIndex = 29;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(8, 126);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(176, 23);
            this.label29.TabIndex = 30;
            this.label29.Text = "Phụ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(432, 126);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 23);
            this.label31.TabIndex = 33;
            this.label31.Text = "Bác sĩ gây mê :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phu1
            // 
            this.phu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phu1.Enabled = false;
            this.phu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu1.Location = new System.Drawing.Point(184, 126);
            this.phu1.MaxLength = 4;
            this.phu1.Name = "phu1";
            this.phu1.Size = new System.Drawing.Size(38, 21);
            this.phu1.TabIndex = 31;
            this.phu1.Validated += new System.EventHandler(this.phu1_Validated);
            this.phu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenphu1
            // 
            this.tenphu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphu1.Enabled = false;
            this.tenphu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphu1.Location = new System.Drawing.Point(224, 126);
            this.tenphu1.Name = "tenphu1";
            this.tenphu1.Size = new System.Drawing.Size(200, 21);
            this.tenphu1.TabIndex = 32;
            this.tenphu1.TextChanged += new System.EventHandler(this.tenphu1_TextChanged);
            this.tenphu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // tenbsgayme
            // 
            this.tenbsgayme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsgayme.Enabled = false;
            this.tenbsgayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsgayme.Location = new System.Drawing.Point(568, 126);
            this.tenbsgayme.Name = "tenbsgayme";
            this.tenbsgayme.Size = new System.Drawing.Size(216, 21);
            this.tenbsgayme.TabIndex = 35;
            this.tenbsgayme.TextChanged += new System.EventHandler(this.tenbsgayme_TextChanged);
            this.tenbsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bsgayme
            // 
            this.bsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsgayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bsgayme.Enabled = false;
            this.bsgayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsgayme.Location = new System.Drawing.Point(528, 126);
            this.bsgayme.MaxLength = 4;
            this.bsgayme.Name = "bsgayme";
            this.bsgayme.Size = new System.Drawing.Size(38, 21);
            this.bsgayme.TabIndex = 34;
            this.bsgayme.Validated += new System.EventHandler(this.bsgayme_Validated);
            this.bsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // mamau
            // 
            this.mamau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mamau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mamau.Enabled = false;
            this.mamau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mamau.Location = new System.Drawing.Point(184, 79);
            this.mamau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mamau.MaxLength = 10;
            this.mamau.Name = "mamau";
            this.mamau.Size = new System.Drawing.Size(70, 21);
            this.mamau.TabIndex = 22;
            this.mamau.Validated += new System.EventHandler(this.mamau_Validated);
            // 
            // tenmau
            // 
            this.tenmau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenmau.Enabled = false;
            this.tenmau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmau.Location = new System.Drawing.Point(256, 79);
            this.tenmau.Name = "tenmau";
            this.tenmau.Size = new System.Drawing.Size(528, 21);
            this.tenmau.TabIndex = 23;
            this.tenmau.TextChanged += new System.EventHandler(this.tenmau_TextChanged);
            this.tenmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(184, 56);
            this.sophieu.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(48, 21);
            this.sophieu.TabIndex = 17;
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(495, 488);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 41;
            this.butTim.Text = "     &Tìm";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(72, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 259;
            this.label5.Text = "Lịch mỗ từ ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(184, 3);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 260;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(328, 3);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 261;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(264, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 23);
            this.label8.TabIndex = 262;
            this.label8.Text = "đến ngày :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tu);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.den);
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Location = new System.Drawing.Point(0, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 328);
            this.panel1.TabIndex = 44;
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
            this.dataGrid1.Location = new System.Drawing.Point(4, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(784, 312);
            this.dataGrid1.TabIndex = 263;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(272, 544);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 264;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // frmLichmo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.tenmau);
            this.Controls.Add(this.mamau);
            this.Controls.Add(this.tenbsgayme);
            this.Controls.Add(this.tenphu1);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.bsgayme);
            this.Controls.Add(this.phu1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_t);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.tenphuongphap);
            this.Controls.Add(this.phuongphap);
            this.Controls.Add(this.icd_t);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLichmo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch phẫu thủ thuật";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLichmo_KeyDown);
            this.Load += new System.EventHandler(this.frmLichmo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sophieu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLichmo_Load(object sender, System.EventArgs e)
		{
            this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            user = m.user;
			this.Text=lan.Change_language_MessageText("Lịch phẫu thủ thuật > ")+s_tenkp;
			bAdmin=m.bAdmin(m_userid);

            dtmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung from " + user + ".pttt_mau order by ma").Tables[0];
            dtmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung from "+user+".dmpttt order by mapt").Tables[0]);

            dtpt = m.get_data("select * from " + user + ".dmpttt").Tables[0];
			listpttt.DisplayMember="MA";
			listpttt.ValueMember="TEN";
			listpttt.DataSource=dtmau;

			tenphuongphap.DisplayMember="TEN";
			tenphuongphap.ValueMember="MA";
            tenphuongphap.DataSource = m.get_data("select * from " + user + ".dmmete order by ma").Tables[0];

            sql = "select a.mabn,b.hoten,a.id,a.maql from " + user + ".hiendien a," + user + ".btdbn b where a.mabn=b.mabn and a.nhapkhoa=1 and a.xuatkhoa=0 and a.makp='" + m_makp + "'";
			sql+=" order by a.id";
			dthoten=m.get_data(sql).Tables[0];
			listHoten.DisplayMember="MABN";
			listHoten.ValueMember="HOTEN";
			listHoten.DataSource=dthoten;

            dtbs = m.get_data("select * from " + user + ".dmbs order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			s_msg=LibMedi.AccessData.Msg;
			songay=m.Ngaylv_Ngayht;
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void icd_t_Validated(object sender, System.EventArgs e)
		{
			if (icd_t.Text!=s_icd_t)
			{
				if (icd_t.Text=="") cd_t.Text="";
				else cd_t.Text=m.get_vviet(icd_t.Text).Trim();
				if (cd_t.Text=="" && icd_t.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_t.Text, cd_t.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_t.Text=f.mTen;
						icd_t.Text=f.mICD;
					}
				}
				s_icd_t=icd_t.Text;
			}
		}

		private void cd_t_Validated(object sender, System.EventArgs e)
		{
			if (icd_t.Text=="") icd_t.Text=m.get_cicd10(cd_t.Text);
			if (!m.bMaicd(icd_t.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_t.Text="";
				icd_t.Focus();
			}
		}

		private void phuongphap_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenphuongphap.SelectedValue=phuongphap.Text;
			}
			catch{}
		}

		private void phuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenphuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenphuongphap.SelectedIndex==-1) tenphuongphap.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenphuongphap_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				phuongphap.Text=tenphuongphap.SelectedValue.ToString();
			}
			catch{}
		}


		private void ena_object(bool ena)
		{
			dataGrid1.Enabled=!ena;
			mabn.Enabled=ena;
			hoten.Enabled=ena;
			sophieu.Enabled=ena;
			ngay.Enabled=ena;
			cd_t.Enabled=ena;
			icd_t.Enabled=ena;
			phuongphap.Enabled=ena;
			tenphuongphap.Enabled=ena;
			mamau.Enabled=ena;
			tenmau.Enabled=ena;
			phu1.Enabled=ena;
			tenphu1.Enabled=ena;
			bsgayme.Enabled=ena;
			tenbsgayme.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butTim.Enabled=!ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void emp_text()
		{
			l_id=0;l_maql=0;l_idkhoa=0;
			sophieu.Value=0;
			mabn.Text="";
			cd_t.Text="";
			icd_t.Text="";
			mamau.Text="";
			tenmau.Text="";
			mabs.Text="";
			tenbs.Text="";
			phu1.Text="";
			tenphu1.Text="";
			bsgayme.Text="";
			tenbsgayme.Text="";
			tenphuongphap.SelectedIndex=-1;
			hoten.Text="";
			tuoi.Text="";
			phai.Text="";
			diachi.Text="";
			sothe.Text="";
			giuong.Text="";
			int dd=DateTime.Now.Day;
			int mm=DateTime.Now.Month;
			int yyyy=DateTime.Now.Year;
			int hh=DateTime.Now.Hour;
			int mi=DateTime.Now.Minute;
			ngay.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
			s_ngay=ngay.Text;
			s_icd_t="";
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			bStatus=true;
			mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") return;
			bStatus=false;
			ena_object(true);
			sophieu.Focus();
		}

		private bool kiemtra()
		{
			if (hoten.Text=="")
			{
				mabn.Focus();
				return false;
			}
			
			if (cd_t.Text=="" || icd_t.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán trước phẫu thuật / thủ thuật !"),s_msg);
				icd_t.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,icd_t.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				icd_t.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,cd_t.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
				cd_t.Focus();
				return false;
			}
			if (mamau.Text=="" || tenmau.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Phương pháp phẫu thuật / thủ thuật !"),s_msg);
				mamau.Focus();
				return false;
			}

			if (!m.Kiemtra_mapt(dtpt,mamau.Text.Substring(0,6)))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				mamau.Focus();
				return false;
			}
			if (tenphuongphap.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phương pháp vô cảm !"),s_msg);
				phuongphap.Focus();
				return false;
			}

			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Phẫu thuật / thủ thuật viên !"),s_msg);
				mabs.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            if (bStatus) l_id = m.getidyymmddhhmiss_stt_computer;//m.get_capid(6);
            string xxx = user + m.mmyy(ngay.Text);
			if (!bAdmin)
			{
				if (m.get_data("select * from "+xxx+".pttt_lichmo where id="+l_id).Tables[0].Rows.Count!=0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"),LibMedi.AccessData.Msg);
					return;
				}
			}
			if (!m.upd_pttt_lichmo(l_id,mabn.Text,l_maql,l_idkhoa,m_makp,ngay.Text,Convert.ToInt16(sophieu.Value),icd_t.Text,mamau.Text,phuongphap.Text,mabs.Text,bsgayme.Text,phu1.Text,m_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phẩu thuật / thủ thuật !"),s_msg);
				return;
			}
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+user+m.mmyy(ngay.Text)+".pttt_lichmo where id="+l_id);
                butTim_Click(sender, e);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count>0)
			{
				string s=s_tenkp.ToUpper()+", ";
				s+=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text;
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,s,"rptLichpttt.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),s_msg);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void gan_text(string s,TextBox ma,TextBox ten)
		{
			if (s!="")
			{
				ma.Text=s;
				DataRow r=m.getrowbyid(dtbs,"ma='"+s+"'");
				if (r!=null) ten.Text=r["hoten"].ToString();
				else ten.Text="";
			}
			else 
			{
				ma.Text="";
				ten.Text="";
			}
		}

		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmLichmo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void tenpt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten LIKE '%"+ten.Trim()+"%'";
			}
			catch{}
		}


		private void cd_t_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void cd_t_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_t)
			{
				Filt_ICD(cd_t.Text);
				listICD.BrowseToICD10(cd_t,icd_t,mamau,icd_t.Location.X,icd_t.Location.Y+icd_t.Height,icd_t.Width+cd_t.Width+2,icd_t.Height);
			}		
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}{Home}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				listBS.BrowseToICD10(tenbs,mabs,phu1,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			gan_text(mabs.Text,mabs,tenbs);
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void phu1_Validated(object sender, System.EventArgs e)
		{
			gan_text(phu1.Text,phu1,tenphu1);
		}

		private void bsgayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(bsgayme.Text,bsgayme,tenbsgayme);
		}

		private void tenphu1_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenphu1)
			{
				Filt_tenbs(tenphu1.Text);
				listBS.BrowseToICD10(tenphu1,phu1,bsgayme,phu1.Location.X,phu1.Location.Y+phu1.Height,phu1.Width+tenphu1.Width+2,phu1.Height);
			}		
		}

		private void tenbsgayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsgayme)
			{
				Filt_tenbs(tenbsgayme.Text);
				listBS.BrowseToICD10(tenbsgayme,bsgayme,butLuu,bsgayme.Location.X,bsgayme.Location.Y+bsgayme.Height,bsgayme.Width+tenbsgayme.Width+2,bsgayme.Height);
			}		
		}

		private void mamau_Validated(object sender, System.EventArgs e)
		{
			if (mamau.Text!="")
			{
				DataRow r=m.getrowbyid(dtmau,"ma='"+mamau.Text+"'");
				if (r!=null) tenmau.Text=r["ten"].ToString();
			}
		}

		private void tenmau_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenmau)
			{
				Filt_pttt(tenmau.Text);
				listpttt.BrowseToPTTT(tenmau,mamau,phuongphap,mamau.Location.X,mamau.Location.Y+mamau.Height,mamau.Width+tenmau.Width+2,mamau.Height);
			}
		}

		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,ngay,55);
			}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listHoten.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listHoten.Visible) listHoten.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void Filt_hoten(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listHoten.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				mabn_Validated(null,null);
			}
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
			DataRow r=m.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["id"].ToString());
				load_mabn();
			}
			else{hoten.Text="";l_maql=0;l_idkhoa=0;}
		}

		private int load_mabn()
		{
			s_mabn=mabn.Text;
			int ret=1;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString();
				ret=0;
				break;
			}
			if (ret==0) load_vv();
			return ret;
		}

		private void load_vv()
		{
			sothe.Text=m.get_sothe(l_maql).ToString();
            foreach (DataRow r in m.get_data("select * from " + user + ".nhapkhoa where id=" + l_idkhoa).Tables[0].Rows)
			{
				m_tuoivao=r["tuoivao"].ToString();
				cd_t.Text=r["chandoan"].ToString();
				icd_t.Text=r["maicd"].ToString();
				giuong.Text=r["giuong"].ToString();
				break;
			}
			try
			{
				m_tuoivao=m.get_tuoivao(l_maql).Trim();
				switch (int.Parse(m_tuoivao.Substring(3,1)))
				{
					case 0: m_loaituoi="TU";
						break;
					case 1: m_loaituoi="TH";
						break;
					case 2: m_loaituoi="NG";
						break;
					default: m_loaituoi="GI";
						break;
				}
				tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
			}
			catch{}
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "STT";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 70;
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
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán trước phẫu thủ thuật";
			TextCol.Width = 300;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpt";
			TextCol.HeaderText = "Phương pháp phẫu thủ thuật";
			TextCol.Width = 300;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vocam";
			TextCol.HeaderText = "Phương pháp vô cảm";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenptv";
			TextCol.HeaderText = "Phẫu thủ thuật viên";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenphu";
			TextCol.HeaderText = "Phụ phẫu thủ thuật";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tengayme";
			TextCol.HeaderText = "Bác sĩ gây mê";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void load_grid()
		{
			sql="select a.stt,a.mabn,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay,";
            sql += "d.vviet as chandoan,coalesce(e.ten,i.noi_dung) as tenpt,c.ten as vocam,f.hoten as tenptv,coalesce(g.hoten,' ') as tengayme,coalesce(h.hoten,' ') as tenphu,";
			sql+="a.id,a.maql,a.idkhoa,a.maicd,a.mamau,a.phuongphap,a.ptv,a.gayme,a.phu";
            sql += " from xxx.pttt_lichmo a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql += " inner join " + user + ".dmmete c on a.phuongphap=c.ma ";
            sql += " inner join " + user + ".icd10 d on a.maicd=d.cicd10 ";
            sql += " left join " + user + ".pttt_mau  e on a.mamau=e.ma ";
            sql += " inner join "+user+".dmbs f on a.ptv=f.ma ";
            sql += " left join " + user + ".dmbs g on a.gayme=g.ma ";
            sql += " left join " + user + ".dmbs h on a.phu=h.ma ";
            sql += " left join " + user + ".dmpttt i  on a.mamau=i.mapt ";
			sql+=" where a.ngay between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (m_makp!="") sql+=" and a.makp='"+m_makp+"'";
			sql+=" order by a.ngay,a.stt";
            ds = m.get_data_mmyy(sql,tu.Text,den.Text,false);
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i,0].ToString());
				DataRow r=m.getrowbyid(ds.Tables[0],"id="+l_id);
				if (r!=null)
				{
					mabn.Text=r["mabn"].ToString();
					mabn_Validated(null,null);
					s_ngay=r["ngay"].ToString();
					int dd=int.Parse(s_ngay.Substring(0,2));
					int mm=int.Parse(s_ngay.Substring(3,2));
					int yyyy=int.Parse(s_ngay.Substring(6,4));
					ngay.Value=new DateTime(yyyy,mm,dd,0,0,0);
					sophieu.Value=decimal.Parse(r["stt"].ToString());
					cd_t.Text=r["chandoan"].ToString();
					icd_t.Text=r["maicd"].ToString();
					tenphuongphap.SelectedValue=r["phuongphap"].ToString();
					mamau.Text=r["mamau"].ToString();
					tenmau.Text=r["tenpt"].ToString();
					gan_text(r["ptv"].ToString(),mabs,tenbs);
					gan_text(r["gayme"].ToString(),bsgayme,tenbsgayme);
					gan_text(r["phu"].ToString(),phu1,tenphu1);
					l_maql=decimal.Parse(r["maql"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
				}
			}
			catch{}
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			load_grid();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		} 
	}
}
