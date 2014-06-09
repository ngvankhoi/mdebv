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
	public class frmTkravien : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
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
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label19;
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
		private System.Windows.Forms.ComboBox makp;
		private MaskedTextBox.MaskedTextBox maicd;
		private DataSet ds=new DataSet();
		private AccessData m;
		private bool bClear=true;
		private System.Windows.Forms.ComboBox ttlucrk;
		private System.Windows.Forms.ComboBox ketqua;
		private MaskedTextBox.MaskedTextBox soluutru;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.CheckBox chkmaicd;
		private System.Windows.Forms.ToolTip toolTip1;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.ComboBox dotuoi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkpt;
		private MaskedTextBox.MaskedTextBox mapt;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.CheckBox chknn;
		private MaskedTextBox.MaskedTextBox maicdnn;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.CheckBox time;
		private System.Windows.Forms.ComboBox nguoidung;
		private System.Windows.Forms.Label label23;
        private GroupBox groupBox1;
        private RadioButton rb3;
        private RadioButton rb2;
        private RadioButton rb1;
        private Label label24;
        private CheckBox chkXML;
        private CheckBox chkPhatQua;
        private MaskedBox.MaskedBox txtDenNgayPhatQua;
        private Label lblden;
        private MaskedBox.MaskedBox txtTuNgayPhatQua;
        private Label lbltu;
        private ComboBox cmbNoiGioiThieu;
        private Label label25;
        private MaskedTextBox.MaskedTextBox madstt;
        private TextBox tendstt;
        private Label label26;
        private System.ComponentModel.IContainer components;
        private Label label27;
        private MaskedTextBox.MaskedTextBox sothe;
        private GroupBox groupBox2;
        private RadioButton chkChuaDuyet;
        private RadioButton chkDaDuyet;
        private RadioButton rdTatCa;
        private GroupBox groupBox3;
        private RadioButton radKhong_phim;
        private RadioButton radCo_phim;
        private RadioButton radTatCa_Phim;
        private GroupBox groupBox4;
        private RadioButton radChuathanhtoan;
        private RadioButton radDathanhtoan;
        private RadioButton radthanhtoan_all;
        private LibList.List listdstt;

		public frmTkravien(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTkravien));
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
            this.label12 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.phai = new System.Windows.Forms.ComboBox();
            this.sonha = new MaskedTextBox.MaskedTextBox();
            this.thon = new MaskedTextBox.MaskedTextBox();
            this.soluutru = new MaskedTextBox.MaskedTextBox();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.ttlucrk = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.ketqua = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.chkmaicd = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkpt = new System.Windows.Forms.CheckBox();
            this.chknn = new System.Windows.Forms.CheckBox();
            this.chkPhatQua = new System.Windows.Forms.CheckBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.dotuoi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mapt = new MaskedTextBox.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.maicdnn = new MaskedTextBox.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.CheckBox();
            this.nguoidung = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.txtDenNgayPhatQua = new MaskedBox.MaskedBox();
            this.lblden = new System.Windows.Forms.Label();
            this.txtTuNgayPhatQua = new MaskedBox.MaskedBox();
            this.lbltu = new System.Windows.Forms.Label();
            this.cmbNoiGioiThieu = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.listdstt = new LibList.List();
            this.label27 = new System.Windows.Forms.Label();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkChuaDuyet = new System.Windows.Forms.RadioButton();
            this.chkDaDuyet = new System.Windows.Forms.RadioButton();
            this.rdTatCa = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radKhong_phim = new System.Windows.Forms.RadioButton();
            this.radCo_phim = new System.Windows.Forms.RadioButton();
            this.radTatCa_Phim = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radChuathanhtoan = new System.Windows.Forms.RadioButton();
            this.radDathanhtoan = new System.Windows.Forms.RadioButton();
            this.radthanhtoan_all = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(242, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(446, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(633, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(-2, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(205, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sinh ngày :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(625, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giới tính :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(-2, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số nhà :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(205, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Thôn, phố :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madantoc
            // 
            this.madantoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(687, 50);
            this.madantoc.Name = "madantoc";
            this.madantoc.Size = new System.Drawing.Size(101, 21);
            this.madantoc.TabIndex = 10;
            this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
            // 
            // mann
            // 
            this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mann.Location = new System.Drawing.Point(477, 50);
            this.mann.Name = "mann";
            this.mann.Size = new System.Drawing.Size(136, 21);
            this.mann.TabIndex = 9;
            this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
            // 
            // maqu
            // 
            this.maqu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maqu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maqu.Location = new System.Drawing.Point(298, 74);
            this.maqu.Name = "maqu";
            this.maqu.Size = new System.Drawing.Size(108, 21);
            this.maqu.TabIndex = 12;
            this.maqu.SelectedIndexChanged += new System.EventHandler(this.maqu_SelectedIndexChanged);
            this.maqu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(58, 74);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(147, 21);
            this.matt.TabIndex = 11;
            this.matt.SelectedIndexChanged += new System.EventHandler(this.matt_SelectedIndexChanged);
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maphuongxa
            // 
            this.maphuongxa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maphuongxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphuongxa.Location = new System.Drawing.Point(477, 74);
            this.maphuongxa.Name = "maphuongxa";
            this.maphuongxa.Size = new System.Drawing.Size(136, 21);
            this.maphuongxa.TabIndex = 13;
            this.maphuongxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphuongxa_KeyDown);
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(401, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 23);
            this.label18.TabIndex = 55;
            this.label18.Text = "Phường/Xã :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(205, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 23);
            this.label17.TabIndex = 54;
            this.label17.Text = "Quận/Huyện :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(-2, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 23);
            this.label16.TabIndex = 53;
            this.label16.Text = "Tỉnh/TP :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(401, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 23);
            this.label10.TabIndex = 49;
            this.label10.Text = "Nghề nghiệp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(625, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 23);
            this.label11.TabIndex = 56;
            this.label11.Text = "Dân tộc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(-2, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 23);
            this.label12.TabIndex = 57;
            this.label12.Text = "Khoa :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(58, 97);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(147, 21);
            this.makp.TabIndex = 15;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(625, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 23);
            this.label13.TabIndex = 59;
            this.label13.Text = "Số lưu trữ :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(205, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 23);
            this.label14.TabIndex = 60;
            this.label14.Text = "Mã ICD :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(625, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Tình trạng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(401, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 23);
            this.label19.TabIndex = 62;
            this.label19.Text = "Kêt quả :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(-2, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 23);
            this.label20.TabIndex = 63;
            this.label20.Text = "Đối tượng :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(687, 4);
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
            this.hoten.Location = new System.Drawing.Point(58, 27);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.MaxLength = 50;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(147, 21);
            this.hoten.TabIndex = 3;
            // 
            // phai
            // 
            this.phai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(687, 27);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(101, 21);
            this.phai.TabIndex = 6;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // sonha
            // 
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(58, 50);
            this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sonha.MaxLength = 10;
            this.sonha.Name = "sonha";
            this.sonha.Size = new System.Drawing.Size(147, 21);
            this.sonha.TabIndex = 7;
            this.sonha.TextChanged += new System.EventHandler(this.sonha_TextChanged);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(298, 50);
            this.thon.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.thon.MaxLength = 50;
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(108, 21);
            this.thon.TabIndex = 8;
            // 
            // soluutru
            // 
            this.soluutru.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(687, 74);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(101, 21);
            this.soluutru.TabIndex = 14;
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(298, 97);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(89, 21);
            this.maicd.TabIndex = 16;
            // 
            // ttlucrk
            // 
            this.ttlucrk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ttlucrk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ttlucrk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttlucrk.Location = new System.Drawing.Point(687, 97);
            this.ttlucrk.Name = "ttlucrk";
            this.ttlucrk.Size = new System.Drawing.Size(101, 21);
            this.ttlucrk.TabIndex = 18;
            this.ttlucrk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ttlucrk_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(58, 121);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(147, 21);
            this.madoituong.TabIndex = 19;
            this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(477, 97);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(136, 21);
            this.ketqua.TabIndex = 17;
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ketqua_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 207);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 286);
            this.dataGrid1.TabIndex = 23;
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.BackColor = System.Drawing.Color.Transparent;
            this.butTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTim.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(291, 533);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 32;
            this.butTim.Text = "     &Tìm";
            this.butTim.UseVisualStyleBackColor = false;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(361, 533);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 33;
            this.butIn.Text = "     &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(431, 533);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 34;
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
            this.lbl.Location = new System.Drawing.Point(12, 533);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(162, 23);
            this.lbl.TabIndex = 64;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkmaicd
            // 
            this.chkmaicd.Location = new System.Drawing.Point(391, 97);
            this.chkmaicd.Name = "chkmaicd";
            this.chkmaicd.Size = new System.Drawing.Size(16, 24);
            this.chkmaicd.TabIndex = 65;
            this.toolTip1.SetToolTip(this.chkmaicd, "Chọn thống kê theo danh sách ICD10");
            this.chkmaicd.CheckStateChanged += new System.EventHandler(this.chkmaicd_CheckStateChanged);
            // 
            // chkpt
            // 
            this.chkpt.Location = new System.Drawing.Point(543, 125);
            this.chkpt.Name = "chkpt";
            this.chkpt.Size = new System.Drawing.Size(16, 16);
            this.chkpt.TabIndex = 84;
            this.toolTip1.SetToolTip(this.chkpt, "Chọn thống kê theo danh sách phẫu thủ thuật");
            this.chkpt.CheckedChanged += new System.EventHandler(this.chkpt_CheckedChanged);
            // 
            // chknn
            // 
            this.chknn.Location = new System.Drawing.Point(206, 147);
            this.chknn.Name = "chknn";
            this.chknn.Size = new System.Drawing.Size(16, 16);
            this.chknn.TabIndex = 82;
            this.toolTip1.SetToolTip(this.chknn, "Chọn thống kê theo danh sách ICD10");
            this.chknn.CheckedChanged += new System.EventHandler(this.chknn_CheckedChanged);
            // 
            // chkPhatQua
            // 
            this.chkPhatQua.Location = new System.Drawing.Point(128, 168);
            this.chkPhatQua.Name = "chkPhatQua";
            this.chkPhatQua.Size = new System.Drawing.Size(72, 16);
            this.chkPhatQua.TabIndex = 27;
            this.chkPhatQua.Text = "Phát quà";
            this.toolTip1.SetToolTip(this.chkPhatQua, "Chọn thống kê theo danh sách phẫu thủ thuật");
            this.chkPhatQua.CheckedChanged += new System.EventHandler(this.chkPhatQua_CheckedChanged);
            // 
            // ngaysinh
            // 
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(298, 27);
            this.ngaysinh.Mask = "##/##/####";
            this.ngaysinh.Name = "ngaysinh";
            this.ngaysinh.Size = new System.Drawing.Size(108, 21);
            this.ngaysinh.TabIndex = 4;
            this.ngaysinh.Text = "  /  /    ";
            this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(477, 4);
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
            this.tu.Location = new System.Drawing.Point(298, 4);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // dotuoi
            // 
            this.dotuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotuoi.Location = new System.Drawing.Point(477, 27);
            this.dotuoi.Name = "dotuoi";
            this.dotuoi.Size = new System.Drawing.Size(136, 21);
            this.dotuoi.TabIndex = 5;
            this.dotuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dotuoi_KeyDown);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(401, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 23);
            this.label6.TabIndex = 72;
            this.label6.Text = "Tuổi :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapt
            // 
            this.mapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapt.Location = new System.Drawing.Point(477, 121);
            this.mapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapt.MaxLength = 6;
            this.mapt.Name = "mapt";
            this.mapt.Size = new System.Drawing.Size(64, 21);
            this.mapt.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(401, 121);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 23);
            this.label22.TabIndex = 86;
            this.label22.Text = "Mã  PTTT :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicdnn
            // 
            this.maicdnn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicdnn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicdnn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicdnn.Location = new System.Drawing.Point(113, 143);
            this.maicdnn.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicdnn.MaxLength = 9;
            this.maicdnn.Name = "maicdnn";
            this.maicdnn.Size = new System.Drawing.Size(92, 21);
            this.maicdnn.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(18, 143);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 23);
            this.label21.TabIndex = 85;
            this.label21.Text = "Mã nguyên nhân :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.WindowText;
            this.time.Location = new System.Drawing.Point(75, 8);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(130, 16);
            this.time.TabIndex = 87;
            this.time.Text = "checkBox1";
            // 
            // nguoidung
            // 
            this.nguoidung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoidung.Location = new System.Drawing.Point(687, 121);
            this.nguoidung.Name = "nguoidung";
            this.nguoidung.Size = new System.Drawing.Size(101, 21);
            this.nguoidung.TabIndex = 22;
            this.nguoidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nguoidung_KeyDown);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(620, 121);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 23);
            this.label23.TabIndex = 90;
            this.label23.Text = "Người nhập :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(532, 523);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 35);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort by";
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(172, 16);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(73, 17);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Mã BN";
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(92, 16);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(85, 17);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Số vào viện";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(9, 16);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(82, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Số lưu trữ";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(-3, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 23);
            this.label24.TabIndex = 92;
            this.label24.Text = "Giờ báo cáo :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(701, 500);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(76, 17);
            this.chkXML.TabIndex = 35;
            this.chkXML.Text = "Xuất XML.";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // txtDenNgayPhatQua
            // 
            this.txtDenNgayPhatQua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenNgayPhatQua.Location = new System.Drawing.Point(477, 166);
            this.txtDenNgayPhatQua.Mask = "##/##/####";
            this.txtDenNgayPhatQua.Name = "txtDenNgayPhatQua";
            this.txtDenNgayPhatQua.Size = new System.Drawing.Size(64, 21);
            this.txtDenNgayPhatQua.TabIndex = 30;
            this.txtDenNgayPhatQua.Text = "  /  /    ";
            this.txtDenNgayPhatQua.Validated += new System.EventHandler(this.txtDenNgayPhatQua_Validated);
            this.txtDenNgayPhatQua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDenNgayPhatQua_KeyDown);
            // 
            // lblden
            // 
            this.lblden.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblden.Location = new System.Drawing.Point(367, 167);
            this.lblden.Name = "lblden";
            this.lblden.Size = new System.Drawing.Size(111, 23);
            this.lblden.TabIndex = 111;
            this.lblden.Text = "đến ngày phát quà :";
            this.lblden.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTuNgayPhatQua
            // 
            this.txtTuNgayPhatQua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuNgayPhatQua.Location = new System.Drawing.Point(298, 167);
            this.txtTuNgayPhatQua.Mask = "##/##/####";
            this.txtTuNgayPhatQua.Name = "txtTuNgayPhatQua";
            this.txtTuNgayPhatQua.Size = new System.Drawing.Size(64, 21);
            this.txtTuNgayPhatQua.TabIndex = 29;
            this.txtTuNgayPhatQua.Text = "  /  /    ";
            this.txtTuNgayPhatQua.Validated += new System.EventHandler(this.txtTuNgayPhatQua_Validated);
            this.txtTuNgayPhatQua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTuNgayPhatQua_KeyDown);
            // 
            // lbltu
            // 
            this.lbltu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltu.Location = new System.Drawing.Point(191, 166);
            this.lbltu.Name = "lbltu";
            this.lbltu.Size = new System.Drawing.Size(107, 23);
            this.lbltu.TabIndex = 28;
            this.lbltu.Text = "Từ ngày phát quà:";
            this.lbltu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNoiGioiThieu
            // 
            this.cmbNoiGioiThieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbNoiGioiThieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNoiGioiThieu.Location = new System.Drawing.Point(298, 144);
            this.cmbNoiGioiThieu.Name = "cmbNoiGioiThieu";
            this.cmbNoiGioiThieu.Size = new System.Drawing.Size(104, 21);
            this.cmbNoiGioiThieu.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(221, 142);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 23);
            this.label25.TabIndex = 115;
            this.label25.Text = "Nơi giới thiệu :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(477, 144);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 10;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(62, 21);
            this.madstt.TabIndex = 25;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendstt
            // 
            this.tendstt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(541, 144);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(247, 21);
            this.tendstt.TabIndex = 26;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(400, 143);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 23);
            this.label26.TabIndex = 118;
            this.label26.Text = "Cơ quan y tế :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listdstt
            // 
            this.listdstt.BackColor = System.Drawing.SystemColors.Info;
            this.listdstt.ColumnCount = 0;
            this.listdstt.Location = new System.Drawing.Point(616, 0);
            this.listdstt.MatchBufferTimeOut = 1000;
            this.listdstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listdstt.Name = "listdstt";
            this.listdstt.Size = new System.Drawing.Size(75, 17);
            this.listdstt.TabIndex = 222;
            this.listdstt.TextIndex = -1;
            this.listdstt.TextMember = null;
            this.listdstt.ValueIndex = -1;
            this.listdstt.Visible = false;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(240, 119);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 23);
            this.label27.TabIndex = 224;
            this.label27.Text = "Số thẻ :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(298, 121);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(110, 21);
            this.sothe.TabIndex = 20;
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkChuaDuyet);
            this.groupBox2.Controls.Add(this.chkDaDuyet);
            this.groupBox2.Controls.Add(this.rdTatCa);
            this.groupBox2.Location = new System.Drawing.Point(539, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 35);
            this.groupBox2.TabIndex = 226;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thủ tục xuất viện";
            // 
            // chkChuaDuyet
            // 
            this.chkChuaDuyet.Location = new System.Drawing.Point(172, 16);
            this.chkChuaDuyet.Name = "chkChuaDuyet";
            this.chkChuaDuyet.Size = new System.Drawing.Size(73, 17);
            this.chkChuaDuyet.TabIndex = 2;
            this.chkChuaDuyet.Text = "Chưa";
            this.chkChuaDuyet.UseVisualStyleBackColor = true;
            // 
            // chkDaDuyet
            // 
            this.chkDaDuyet.Location = new System.Drawing.Point(92, 16);
            this.chkDaDuyet.Name = "chkDaDuyet";
            this.chkDaDuyet.Size = new System.Drawing.Size(85, 17);
            this.chkDaDuyet.TabIndex = 1;
            this.chkDaDuyet.Text = "Đã làm";
            this.chkDaDuyet.UseVisualStyleBackColor = true;
            // 
            // rdTatCa
            // 
            this.rdTatCa.Checked = true;
            this.rdTatCa.Location = new System.Drawing.Point(9, 16);
            this.rdTatCa.Name = "rdTatCa";
            this.rdTatCa.Size = new System.Drawing.Size(82, 17);
            this.rdTatCa.TabIndex = 0;
            this.rdTatCa.TabStop = true;
            this.rdTatCa.Text = "Tất cả";
            this.rdTatCa.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radKhong_phim);
            this.groupBox3.Controls.Add(this.radCo_phim);
            this.groupBox3.Controls.Add(this.radTatCa_Phim);
            this.groupBox3.Location = new System.Drawing.Point(12, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 35);
            this.groupBox3.TabIndex = 227;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bệnh án có phim";
            // 
            // radKhong_phim
            // 
            this.radKhong_phim.Location = new System.Drawing.Point(146, 16);
            this.radKhong_phim.Name = "radKhong_phim";
            this.radKhong_phim.Size = new System.Drawing.Size(98, 17);
            this.radKhong_phim.TabIndex = 2;
            this.radKhong_phim.Text = "Không có phim";
            this.radKhong_phim.UseVisualStyleBackColor = true;
            // 
            // radCo_phim
            // 
            this.radCo_phim.Location = new System.Drawing.Point(72, 16);
            this.radCo_phim.Name = "radCo_phim";
            this.radCo_phim.Size = new System.Drawing.Size(85, 17);
            this.radCo_phim.TabIndex = 1;
            this.radCo_phim.Text = "Có phim";
            this.radCo_phim.UseVisualStyleBackColor = true;
            // 
            // radTatCa_Phim
            // 
            this.radTatCa_Phim.Checked = true;
            this.radTatCa_Phim.Location = new System.Drawing.Point(9, 16);
            this.radTatCa_Phim.Name = "radTatCa_Phim";
            this.radTatCa_Phim.Size = new System.Drawing.Size(82, 17);
            this.radTatCa_Phim.TabIndex = 0;
            this.radTatCa_Phim.TabStop = true;
            this.radTatCa_Phim.Text = "Tất cả";
            this.radTatCa_Phim.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radChuathanhtoan);
            this.groupBox4.Controls.Add(this.radDathanhtoan);
            this.groupBox4.Controls.Add(this.radthanhtoan_all);
            this.groupBox4.Location = new System.Drawing.Point(267, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 35);
            this.groupBox4.TabIndex = 228;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bệnh án đã thanh toán";
            // 
            // radChuathanhtoan
            // 
            this.radChuathanhtoan.Location = new System.Drawing.Point(161, 16);
            this.radChuathanhtoan.Name = "radChuathanhtoan";
            this.radChuathanhtoan.Size = new System.Drawing.Size(105, 17);
            this.radChuathanhtoan.TabIndex = 2;
            this.radChuathanhtoan.Text = "Chưa thanh toán";
            this.radChuathanhtoan.UseVisualStyleBackColor = true;
            // 
            // radDathanhtoan
            // 
            this.radDathanhtoan.Location = new System.Drawing.Point(69, 16);
            this.radDathanhtoan.Name = "radDathanhtoan";
            this.radDathanhtoan.Size = new System.Drawing.Size(96, 17);
            this.radDathanhtoan.TabIndex = 1;
            this.radDathanhtoan.Text = "Đã thanh toán";
            this.radDathanhtoan.UseVisualStyleBackColor = true;
            // 
            // radthanhtoan_all
            // 
            this.radthanhtoan_all.Checked = true;
            this.radthanhtoan_all.Location = new System.Drawing.Point(9, 16);
            this.radthanhtoan_all.Name = "radthanhtoan_all";
            this.radthanhtoan_all.Size = new System.Drawing.Size(82, 17);
            this.radthanhtoan_all.TabIndex = 0;
            this.radthanhtoan_all.TabStop = true;
            this.radthanhtoan_all.Text = "Tất cả";
            this.radthanhtoan_all.UseVisualStyleBackColor = true;
            // 
            // frmTkravien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tendstt);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.madstt);
            this.Controls.Add(this.cmbNoiGioiThieu);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtDenNgayPhatQua);
            this.Controls.Add(this.lblden);
            this.Controls.Add(this.txtTuNgayPhatQua);
            this.Controls.Add(this.lbltu);
            this.Controls.Add(this.chknn);
            this.Controls.Add(this.nguoidung);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.chkPhatQua);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.madantoc);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkpt);
            this.Controls.Add(this.mapt);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.maicdnn);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.dotuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.chkmaicd);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.ttlucrk);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.sonha);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.mann);
            this.Controls.Add(this.maqu);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.maphuongxa);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listdstt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTkravien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách bệnh nhân ra viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTkravien_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmTkravien_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTkravien_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTkravien_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
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

            chkPhatQua.Visible = m.bPhatQuaKhiXuatKhoa;//gam 11042012
            lbltu.Visible = chkPhatQua.Checked;
            lblden.Visible = chkPhatQua.Checked;
            txtTuNgayPhatQua.Visible = chkPhatQua.Checked;
            txtDenNgayPhatQua.Visible = chkPhatQua.Checked;

			load_quan();
			load_pxa();

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + m.user + ".doituong order by madoituong").Tables[0];

			ketqua.DisplayMember="TEN";
			ketqua.ValueMember="MA";
            ketqua.DataSource = m.get_data("select * from " + m.user + ".ketqua order by ma").Tables[0];

			ttlucrk.DisplayMember="TEN";
			ttlucrk.ValueMember="MA";
            ttlucrk.DataSource = m.get_data("select * from " + m.user + ".ttxk where rakhoa=0 order by ma").Tables[0];

            cmbNoiGioiThieu.DisplayMember = "TEN";
            cmbNoiGioiThieu.ValueMember = "MA";
            cmbNoiGioiThieu.DataSource = m.get_data("select * from " + m.user + ".dentu order by ma").Tables[0];

            listdstt.DisplayMember = "MABV";
            listdstt.ValueMember = "TENBV";
            listdstt.DataSource = m.get_data("select MABV,TENBV,DIACHI from " + m.user + ".dstt where mabv<>'" + m.Mabv + "'" + " order by mabv").Tables[0];

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
			ketqua.SelectedIndex=-1;
			ttlucrk.SelectedIndex=-1;
			dotuoi.SelectedIndex=-1;
            cmbNoiGioiThieu.SelectedIndex = -1;
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

		private void ketqua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ttlucrk_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
            if (den.Text == "") den.Text = tu.Text;
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
            ds = m.get_Ravien(tu.Text, den.Text, mabn.Text, hoten.Text.Replace("'", "''"), ngaysinh.Text, phai.SelectedIndex, sonha.Text, thon.Text.Replace("'", "''"),
                (mann.SelectedIndex == -1) ? "" : mann.SelectedValue.ToString(), (madantoc.SelectedIndex == -1) ? "" : madantoc.SelectedValue.ToString(),
                (matt.SelectedIndex == -1) ? "" : matt.SelectedValue.ToString(), (maqu.SelectedIndex == -1) ? "" : maqu.SelectedValue.ToString(),
                (maphuongxa.SelectedIndex == -1) ? "" : maphuongxa.SelectedValue.ToString(), (makp.SelectedIndex == -1) ? "" : makp.SelectedValue.ToString(),
                soluutru.Text, maicd.Text, (madoituong.SelectedIndex == -1) ? "" : madoituong.SelectedValue.ToString(), (ketqua.SelectedIndex == -1) ? "" : ketqua.SelectedValue.ToString(),
                (ttlucrk.SelectedIndex == -1) ? "" : ttlucrk.SelectedValue.ToString(), (dotuoi.SelectedIndex == -1) ? "" :
                dotuoi.SelectedValue.ToString(), chkmaicd.Checked, maicdnn.Text, chknn.Checked, mapt.Text,
                chkpt.Checked, i_userid, time.Checked, (rb1.Checked) ? 1 : (rb2.Checked) ? 2 : 3, chkPhatQua.Checked,
                txtTuNgayPhatQua.Text.Length < 10 ? txtTuNgayPhatQua.Text : "", txtDenNgayPhatQua.Text, chkDaDuyet.Checked ? 1 : (chkChuaDuyet.Checked ? 0 : 2),
                (cmbNoiGioiThieu.SelectedIndex == -1) ? "" : cmbNoiGioiThieu.SelectedValue.ToString(), madstt.Text, sothe.Text, (radCo_phim.Checked ? 1 : (radKhong_phim.Checked) ? 0 : 2), (radDathanhtoan.Checked ? 1 : (radChuathanhtoan.Checked) ? 0 : 2));
            dataGrid1.DataSource=ds.Tables[0];
			lbl.Text=lan.Change_language_MessageText("TỔNG SỐ : ")+ds.Tables[0].Rows.Count.ToString();
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
			TextCol.MappingName = "soluutru";
			TextCol.HeaderText = "Số lưu trữ";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sovaovien";
			TextCol.HeaderText = "Số vào viện";
			TextCol.Width = 80;
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
			TextCol.MappingName = "tuoi";
			TextCol.HeaderText = "Tuổi";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gioitinh";
            TextCol.HeaderText = "Giới tính";
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
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "cholam";
            TextCol.HeaderText = "Nơi làm việc";
            TextCol.Width = 150;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngayvk";
			TextCol.HeaderText = "Ngày giờ vào";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngayrk";
			TextCol.HeaderText = "Ngày giờ ra";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngaydt";
			TextCol.HeaderText = "Ngày ĐT";
			TextCol.Width = 50;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            if (chkPhatQua.Visible)
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "ngaythoinoi";
                TextCol.HeaderText = "Ngày thôi nôi";
                TextCol.Width = 100;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid1.TableStyles.Add(ts);
            }

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "chandoanvao";
            TextCol.HeaderText = "Chẩn đoán vào";
            TextCol.Width = 250;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "maicdvao";
            TextCol.HeaderText = "ICD vào";
            TextCol.Width = 50;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoanra";
			TextCol.HeaderText = "Chẩn đoán ra";
			TextCol.Width = 250;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maicdra";
			TextCol.HeaderText = "ICD ra";
			TextCol.Width = 50;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ketqua";
			TextCol.HeaderText = "Kết quả";
			TextCol.Width = 80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ttlucrk";
			TextCol.HeaderText = "Tình trạng";
			TextCol.Width =80;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "chandoannn";
			TextCol.HeaderText = "Chẩn đoán nguyên nhân";
			TextCol.Width = 250;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenpt";
			TextCol.HeaderText = "Phương pháp phẫu thủ thuật";
			TextCol.Width = 250;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenuser";
			TextCol.HeaderText = "Người nhập";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "stt";
            TextCol.HeaderText = "STT (B.11)";
            TextCol.Width = 100;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dentu";
            TextCol.HeaderText = "Nơi Giới Thiệu";
            TextCol.Width = 100;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "coquanytegioithieu";
            TextCol.HeaderText = "Cơ quan y tế giới thiệu";
            TextCol.Width = 200;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				string title="";
				if (tu.Text!="" && den.Text!="")
					title=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến ngày "+den.Text;
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
					return;
                }
                //Thuy 02.04.2012
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    ds.WriteXml("..//xml//tkravien.xml", XmlWriteMode.WriteSchema);
                }
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title,"rptTkravien.rpt");
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

		private void frmTkravien_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				bClear=false;
				emp_text();
			}
		}

		private void frmTkravien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chknn_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chknn.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách ICD10 không ?"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmbcicd f=new frmDmbcicd(m);
					f.ShowDialog();
				}
			}		
		}

		private void chkpt_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkpt.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách PTTT không ?"),AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmbcpttt f=new frmDmbcpttt(m);
					f.ShowDialog();		
				}
			}		
		}

        private void sonha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void nguoidung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtTuNgayPhatQua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void txtDenNgayPhatQua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkPhatQua_CheckedChanged(object sender, EventArgs e)
        {
            lbltu.Visible = chkPhatQua.Checked;
            lblden.Visible = chkPhatQua.Checked;
            txtTuNgayPhatQua.Visible = chkPhatQua.Checked;
            txtDenNgayPhatQua.Visible = chkPhatQua.Checked;
        }

        private void txtTuNgayPhatQua_Validated(object sender, EventArgs e)
        {
            if (txtTuNgayPhatQua.Text == "")
            {
                txtTuNgayPhatQua.Text = "";
                return;
            }
            txtTuNgayPhatQua.Text = txtTuNgayPhatQua.Text.Trim();
            if (!m.bNgay(txtTuNgayPhatQua.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                txtTuNgayPhatQua.Focus();
                return;
            }
            txtTuNgayPhatQua.Text = m.Ktngaygio(txtTuNgayPhatQua.Text, 10);
            if (txtTuNgayPhatQua.Text == "") txtTuNgayPhatQua.Text = txtTuNgayPhatQua.Text;
            txtDenNgayPhatQua.Focus();
        }

        private void txtDenNgayPhatQua_Validated(object sender, EventArgs e)
        {
            if (txtTuNgayPhatQua.Text == "")
            {
                txtDenNgayPhatQua.Text = "";
                return;
            }
            txtDenNgayPhatQua.Text = txtDenNgayPhatQua.Text.Trim();
            if (!m.bNgay(txtDenNgayPhatQua.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                den.Focus();
                return;
            }
            txtDenNgayPhatQua.Text = m.Ktngaygio(txtDenNgayPhatQua.Text, 10);
            if (txtTuNgayPhatQua.Text == "")
            {
                txtTuNgayPhatQua.Focus();
                return;
            }
            if (!m.bNgay(txtDenNgayPhatQua.Text, txtTuNgayPhatQua.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
                txtDenNgayPhatQua.Focus();
                return;
            }
        }

        private void Filt_dstt(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listdstt.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "TENBV LIKE '%" + ten.Trim().Replace("'", "''") + "%'";
        }

        private void tendstt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listdstt.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listdstt.Visible)
                {
                    listdstt.Focus();
                    SendKeys.Send("{Down}");
                }
                else SendKeys.Send("{Tab}");
            }
        }

        private void tendstt_TextChanged(object sender, System.EventArgs e)
        {
            Filt_dstt(tendstt.Text);
            listdstt.BrowseToText(tendstt, madstt,butTim, madstt.Location.X, madstt.Location.Y + madstt.Height - 2, madstt.Width + tendstt.Width + 1, madstt.Height);

        }

        private void tendstt_Validated(object sender, System.EventArgs e)
        {
            //madstt.Text=m.get_madstt(tendstt.Text);
            if (!listdstt.Focused)
            {
                listdstt.Hide();
            }
        }

        private void madstt_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (madstt.Text == m.Mabv)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ vì trùng với mã bệnh viện !"));
                    madstt.Text = "";
                    return;
                }
                tendstt.Text = m.get_data("select tenbv from " + m.user + ".dstt where mabv='" + madstt.Text + "'").Tables[0].Rows[0][0].ToString();
            }
            catch { }
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
