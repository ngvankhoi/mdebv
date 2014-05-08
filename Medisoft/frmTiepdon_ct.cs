using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibVienphi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmTiepdon_ct : System.Windows.Forms.Form
	{
		Language lan = new Language();
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
		private DataSet ds=new DataSet();
		private DataSet dsdt=new DataSet();
        private DataSet dsbarcode = new DataSet();
		private string user,nam,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,sql,s_matt,s_madantoc,s_mann;
        private int i_userid, iChidinh;
		private long l_maql=0,l_id=0;
		private decimal d_dongia,d_vattu;
		private DataTable dt=new DataTable();
		private DataTable dtgia=new DataTable();
        private DataTable dtmavp = new DataTable();
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox mabn2;
		private MaskedTextBox.MaskedTextBox mabn3;
		private System.Windows.Forms.Label label6;
        private MaskedTextBox.MaskedTextBox namsinh;
        private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private int songay=30,i_sokham;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bInphieudieutri, bNew, bInmavach, bChuongtrinh,bCapso = false;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox thon;
		private System.Windows.Forms.ComboBox phai;
        private System.Windows.Forms.Label lphai;
        private System.Windows.Forms.Label lthon;
		private MaskedTextBox.MaskedTextBox sovaovien;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label19;
        private MaskedBox.MaskedBox ngayvv;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripLabel tlbl;
		private Print print=new Print();
        private Label label37;
        private MaskedBox.MaskedBox giovv;
        private CheckBox chkXem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private Button butInbarcode;
        private FileStream fstr;
        private byte[] imagedata;
        private LibList.List listtenvp;
        private TextBox mavp;
        private Label label11;
        private TextBox tenvp;
        private AxBARCODELib.AxBarcode barcode;
        private DataTable dtletet = new DataTable();

		public frmTiepdon_ct(LibMedi.AccessData acc,string hoten,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;s_userid=hoten;i_userid=userid;
			v=new LibVienphi.AccessData();            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiepdon_ct));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.mabn3 = new MaskedTextBox.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.namsinh = new MaskedTextBox.MaskedTextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.thon = new System.Windows.Forms.TextBox();
            this.lthon = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.mavp = new System.Windows.Forms.TextBox();
            this.tenvp = new System.Windows.Forms.TextBox();
            this.listtenvp = new LibList.List();
            this.label11 = new System.Windows.Forms.Label();
            this.butInbarcode = new System.Windows.Forms.Button();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.giovv = new MaskedBox.MaskedBox();
            this.label37 = new System.Windows.Forms.Label();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbl = new System.Windows.Forms.ToolStripLabel();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.barcode = new AxBARCODELib.AxBarcode();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(25, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(197, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(70, 30);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(34, 23);
            this.mabn2.TabIndex = 1;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(107, 30);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(67, 23);
            this.mabn3.TabIndex = 2;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(9, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(70, 56);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 23);
            this.namsinh.TabIndex = 6;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(260, 30);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(220, 23);
            this.hoten.TabIndex = 4;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(214, 234);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 20;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(338, 234);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(60, 25);
            this.butKetthuc.TabIndex = 23;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(260, 55);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(220, 23);
            this.thon.TabIndex = 10;
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lthon.Location = new System.Drawing.Point(189, 56);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 9;
            this.lthon.Text = "Cơ quan :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(158, 55);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(49, 24);
            this.phai.TabIndex = 8;
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lphai.Location = new System.Drawing.Point(101, 56);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 7;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavp
            // 
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(70, 106);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(104, 23);
            this.mavp.TabIndex = 17;
            this.mavp.Validated += new System.EventHandler(this.mavp_Validated);
            this.mavp.TextChanged += new System.EventHandler(this.mavp_TextChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // tenvp
            // 
            this.tenvp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenvp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenvp.Location = new System.Drawing.Point(175, 106);
            this.tenvp.Name = "tenvp";
            this.tenvp.Size = new System.Drawing.Size(305, 23);
            this.tenvp.TabIndex = 18;
            this.tenvp.TextChanged += new System.EventHandler(this.tenvp_TextChanged);
            this.tenvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenvp_KeyDown);
            // 
            // listtenvp
            // 
            this.listtenvp.BackColor = System.Drawing.SystemColors.Info;
            this.listtenvp.ColumnCount = 0;
            this.listtenvp.Location = new System.Drawing.Point(331, 208);
            this.listtenvp.MatchBufferTimeOut = 1000;
            this.listtenvp.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listtenvp.Name = "listtenvp";
            this.listtenvp.Size = new System.Drawing.Size(75, 17);
            this.listtenvp.TabIndex = 26;
            this.listtenvp.TextIndex = -1;
            this.listtenvp.TextMember = null;
            this.listtenvp.ValueIndex = -1;
            this.listtenvp.Visible = false;
            this.listtenvp.Validated += new System.EventHandler(this.listtenvp_Validated);
            this.listtenvp.DoubleClick += new System.EventHandler(this.listtenvp_DoubleClick);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(-19, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 23);
            this.label11.TabIndex = 16;
            this.label11.Text = "Chương trình :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butInbarcode
            // 
            this.butInbarcode.BackColor = System.Drawing.Color.Transparent;
            this.butInbarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInbarcode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butInbarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInbarcode.Location = new System.Drawing.Point(164, 200);
            this.butInbarcode.Name = "butInbarcode";
            this.butInbarcode.Size = new System.Drawing.Size(160, 25);
            this.butInbarcode.TabIndex = 25;
            this.butInbarcode.Text = "In mã &vạch";
            this.butInbarcode.UseVisualStyleBackColor = false;
            this.butInbarcode.Click += new System.EventHandler(this.butInbarcode_Click);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(70, 81);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(74, 23);
            this.ngayvv.TabIndex = 11;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(165, 81);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(40, 23);
            this.giovv.TabIndex = 13;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label37.Location = new System.Drawing.Point(137, 82);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 23);
            this.label37.TabIndex = 12;
            this.label37.Text = "giờ :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(260, 81);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(72, 23);
            this.sovaovien.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label30.Location = new System.Drawing.Point(205, 82);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 23);
            this.label30.TabIndex = 14;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(-39, 82);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.tlbl});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(488, 23);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton1.Text = "F7";
            this.toolStripButton1.ToolTipText = "Chỉ định dịch vụ";
            this.toolStripButton1.Click += new System.EventHandler(this.l_chidinh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(42, 20);
            this.toolStripButton3.Text = "^D";
            this.toolStripButton3.ToolTipText = "Dị ứng thuốc";
            this.toolStripButton3.Click += new System.EventHandler(this.l_diungthuoc_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(40, 20);
            this.toolStripButton4.Text = "^L";
            this.toolStripButton4.ToolTipText = "Lịch hẹn";
            this.toolStripButton4.Click += new System.EventHandler(this.l_lichhen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // tlbl
            // 
            this.tlbl.ForeColor = System.Drawing.Color.Red;
            this.tlbl.Name = "tlbl";
            this.tlbl.Size = new System.Drawing.Size(0, 0);
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkXem.Location = new System.Drawing.Point(371, 3);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 28;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(152, 234);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 19;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butTiep
            // 
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(90, 234);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(60, 25);
            this.butTiep.TabIndex = 21;
            this.butTiep.Text = "       &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(276, 234);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 22;
            this.butIn.Text = "        &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // barcode
            // 
            this.barcode.Enabled = true;
            this.barcode.Location = new System.Drawing.Point(159, 135);
            this.barcode.Name = "barcode";
            this.barcode.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("barcode.OcxState")));
            this.barcode.Size = new System.Drawing.Size(171, 59);
            this.barcode.TabIndex = 24;
            // 
            // frmTiepdon_ct
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(488, 278);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.tenvp);
            this.Controls.Add(this.listtenvp);
            this.Controls.Add(this.butInbarcode);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.thon);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.lthon);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.giovv);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label30);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTiepdon_ct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft 2007";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTiepdon_ct_KeyDown);
            this.Load += new System.EventHandler(this.frmTiepdon_ct_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTiepdon_ct_Load(object sender, System.EventArgs e)
		{
            user = m.user; bInmavach = v.bInmavach; s_makp = "01";
            bChuongtrinh = m.bDangky_chuongtrinh;
            s_matt = m.vodanh_tinh; s_mann = m.vodanh_nghenghiep; s_madantoc = m.vodanh_dantoc;
            if (bChuongtrinh)
            {
                dtmavp = m.get_data("select ma,ten,id from " + user + ".v_giavp where trongoi<>0 order by stt").Tables[0];
                listtenvp.DisplayMember = "TEN";
                listtenvp.ValueMember = "MA";
                listtenvp.DataSource = dtmavp;
            }
            else
            {
                label11.Visible = false; mavp.Visible = false; tenvp.Visible = false;
            }
            if (bInmavach)
            {
                mabn2.MaxLength = 8;
                mabn3.MaxLength = 8;
            }
            dsbarcode.ReadXml("..\\..\\..\\xml\\barcode.xml");
			tlbl.Text="";
			iChidinh=m.iChidinh;
            barcode.Visible = m.bMavach || bInmavach;
			butInbarcode.Visible=m.bMavach;
			bAdmin=m.bAdmin(i_userid);
			chkXem.Checked=m.bPreview;
			i_sokham=m.iSokham;
			bInphieudieutri=m.bPhieudieutri;
			if (i_sokham!=3) sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			load_dm();
			phai.SelectedIndex=0;
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			b_Hoten=m.bHoten_gioitinh;
			butIn.Enabled=(bInphieudieutri);
            chkXem.Visible = butIn.Enabled;
			if (bInphieudieutri) dsdt.ReadXml("..\\..\\..\\xml\\m_phieudieutri.xml");
			dtgia=m.get_data("select * from "+user+".v_giavp").Tables[0];
		}

		private void load_diungthuoc()
		{
			tlbl.Text="";
			foreach(DataRow r in m.get_data("select distinct b.ten from "+user+".diungthuoc a,"+user+".d_dmhoatchat b where a.mahc=b.ma and a.mabn='"+mabn2.Text+mabn3.Text+"'").Tables[0].Rows) tlbl.Text+=r["ten"].ToString().Trim()+";";
			//diungthuoc.Checked=tlbl.Text!="";
			//if (diungthuoc.Checked) 
            if (tlbl.Text!="") tlbl.Text="DỊ ỨNG THUỐC :"+tlbl.Text;
			//l_diungthuoc.ForeColor=(diungthuoc.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
			mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
		}

		private void ena_namsinh(bool ena)
		{
			namsinh.Enabled=ena;
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") mabn2.Focus();
			else
			{
				if (m.bvodanh(hoten.Text))
				{
					hoten.Text=m.vodanh;
                    int _namsinh = DateTime.Now.Year - m.vodanh_tuoi;
                    namsinh.Text = _namsinh.ToString();
					phai.SelectedIndex=m.vodanh_gioitinh;
					ngayvv.Focus();
				}
			}
		}

		private void phai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (phai.SelectedIndex==-1) phai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private bool load_tim_mabn()
		{
			if (!b_Edit)
			{
				s_ngayvv="";
				s_mabn=mabn2.Text+mabn3.Text;
				DataTable dt=m.get_Timmabn(hoten.Text.Trim().ToUpper(),namsinh.Text,s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
						mabn2.Text=f.m_mabn.Substring(0,2);
						mabn3.Text=f.m_mabn.Substring(2,6);
						s_mabn=mabn2.Text+mabn3.Text;
						load_mabn();
						ngayvv.Focus();
						SendKeys.Send("{Home}");
						return true;
					}
				}
			}
			return false;
		}

		private void maqu2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mapxa2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}


		private void mabn2_Validated(object sender, System.EventArgs e)
		{
            if (bInmavach)
            {
                string s = mabn2.Text;
                if (s.Length == 8)
                {
                    mabn2.Text = s.Substring(0, 2);
                    mabn3.Text = s.Substring(2);
                    mabn3_Validated(sender, e);
                }
            }
			mabn2.Text=mabn2.Text.PadLeft(2,'0');
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
            nam = "";
            bCapso = false;
            if (mabn3.Text == "")
            {
                if (mabn2.Text == "")
                {
                    mabn2.Focus();
                    return;
                }
                bCapso = true;
                mabn3.Text = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true).ToString().PadLeft(6, '0');
            }
            if (bInmavach)
            {
                string s = mabn3.Text;
                if (s.Length == 8)
                {
                    mabn2.Text = s.Substring(0,2);
                    mabn3.Text = s.Substring(2);
                }
            }
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			if (barcode.Visible) barcode.Text=s_mabn;
			emp_text(true);
			if (load_mabn())
			{
				if (ngayvv.Text=="")
				{
					if (load_vv_mabn() && !bAdmin) ena_but(false);
				}
				if (bAdmin && !bInmavach)
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Bạn có sửa thông tin hành chính không ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
					{
						b_Edit=true;
						hoten.Focus();
					}
					else 
					{
						ngayvv.Focus();
						SendKeys.Send("{Home}");
					}
				}
				else
				{
					ngayvv.Focus();
					SendKeys.Send("{Home}");
				}
			}
		}

		private bool load_mabn()
		{
			bool ret=false;
			foreach(DataRow r in m.get_data("select * from "+user+".btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
                nam = r["nam"].ToString();
				phai.SelectedIndex=int.Parse(r["phai"].ToString());
				thon.Text=r["thon"].ToString();
				ret=true;
				break;
			}
			load_diungthuoc();
			return ret;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
            if (ngayvv.Text == "") return;
			foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".tiepdon where maql="+l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
				sovaovien.Text=r["sovaovien"].ToString();
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
			l_maql=0;
			emp_vv();
            if (nam == "") return false;
			foreach(DataRow r in m.get_data("select * from "+user+nam.Substring(nam.Length-5,4)+".tiepdon where noitiepdon=0 and mabn='"+s_mabn+"'"+" order by ngay desc").Tables[0].Rows)
			{
				l_maql=long.Parse(r["maql"].ToString());
                s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				sovaovien.Text=r["sovaovien"].ToString();
				break;
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
            string xxx = user + m.mmyy(ngayvv.Text);
            if (bChuongtrinh)
            {
                foreach (DataRow r in m.get_data("select b.ma,b.ten from " + xxx + ".tiepdon_ct a," + user + ".v_giavp b where a.mavp=b.id and a.maql=" + l_maql).Tables[0].Rows)
                {
                    mavp.Text = r["ma"].ToString();
                    tenvp.Text = r["ten"].ToString();
                    break;
                }
            }
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if(namsinh.Text!="")
			{
				if (int.Parse(namsinh.Text)>DateTime.Now.Year)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
				if (namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
				if (!load_tim_mabn())
				{
					if (phai.Enabled) SendKeys.Send("{Tab}{Tab}");
					else thon.Focus();
				}
			}
		}

		private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				hoten.Text=m.Viettat(hoten.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void thon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				thon.Text=m.Viettat(thon.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmTiepdon_ct_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F3: butTiep_Click(sender, e); break;
                case Keys.F6: butLuu_Click(sender, e); break;
                case Keys.F8: butIn_Click(sender, e); break;
				case Keys.F7:
					l_chidinh_Click(sender,e);
					break;
				case Keys.F10:
					butKetthuc_Click(sender,e);
					break;
			}
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.D:
						l_diungthuoc_Click(sender,e);
						break;
					case Keys.L:
						l_lichhen_Click(sender,e);
						break;
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void emp_text(bool skip)
		{
			ena_but(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
			hoten.Text="";namsinh.Text="";
			bNew=true;
			b_Edit=false;
			emp_vv();
		}

		private void emp_vv()
		{
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            s_ngayvv = "";
			sovaovien.Text="";
            mavp.Text = ""; tenvp.Text = "";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			emp_text(false);
			mabn2.Focus();
		}

		private bool kiemtra()
		{
			if (mabn2.Text=="" || mabn3.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return false;
			}

			if (hoten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên bệnh nhân !"),s_msg);
				hoten.Focus();
				return false;
			}

			if (namsinh.Text=="")
			{
                MessageBox.Show(lan.Change_language_MessageText("Nhập năm sinh !"), s_msg);
				namsinh.Focus();
				return false;
			}
			
			if (b_Hoten)
			{
				if ((hoten.Text.Trim().IndexOf(" VĂN ")!=-1 && phai.SelectedIndex==1) || (hoten.Text.Trim().IndexOf(" THỊ ")!=-1 && phai.SelectedIndex==0))
				{
					MessageBox.Show(lan.Change_language_MessageText("Họ tên và giới tính không hợp lệ !"),LibMedi.AccessData.Msg);
					if (phai.Enabled) phai.Focus();
					else hoten.Focus();
					return false;
				}
			}

			if (ngayvv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày vào khám bệnh !"),s_msg);
				ngayvv.Focus();
				return false;
			}

            if (mavp.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập chương trình !"), s_msg);
                mavp.Focus();
                return false;
            }
            else
            {
                DataRow r = m.getrowbyid(dtmavp, "ma='" + mavp.Text + "'");
                if (r == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập chương trình không hợp lệ !"), s_msg);
                    mavp.Focus();
                    return false;
                }
            }
			s_mabn=mabn2.Text+mabn3.Text;
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
			l_maql=m.get_maql_tiepdon(s_mabn,ngayvv.Text+" "+giovv.Text);
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            int tuoi = DateTime.Now.Year - int.Parse(namsinh.Text);
			if (i_sokham!=3 && bNew)
				sovaovien.Text=m.get_sokham(ngayvv.Text.Substring(0,10),s_makp,i_sokham).ToString();
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
            if (!m.upd_btdbn(s_mabn, hoten.Text, "", namsinh.Text, phai.SelectedIndex, s_mann, s_madantoc, "", thon.Text, "", s_matt, s_matt + "00", s_matt + "0000", i_userid, nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (!m.upd_lienhe(ngayvv.Text,l_maql,"",thon.Text,"",s_matt,s_matt+"00",s_matt+"0000",tuoi.ToString().PadLeft(3,'0')+"0",0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            int itable = m.tableid(m.mmyy(ngayvv.Text), "tiepdon");
            if (m.get_maql_tiepdon(s_mabn, s_makp, ngayvv.Text + " " + giovv.Text) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd", s_mabn + "^" + l_maql.ToString() + "^" + s_makp + "^" + ngayvv.Text + " " + giovv.Text + "^" + "2" + "^" + sovaovien.Text + "^" + tuoi.ToString().PadLeft(3, '0') + "0" + "^" + "0^" + i_userid.ToString() + "^0^" + "0");
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            if (!m.upd_tiepdon(s_mabn, l_maql,s_makp, ngayvv.Text+" "+giovv.Text,2, sovaovien.Text, tuoi.ToString().PadLeft(3, '0') + "0", i_userid, 0,0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"),s_msg);
				return;
			}
			m.upd_sukien(s_mabn,l_maql,LibMedi.AccessData.Tiepdon,l_maql);
			if (bChuongtrinh || bInphieudieutri) butIn_Click(null,null);
			ena_but(false);			
			butTiep.Focus();
		}     

		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (ena) butIn.Enabled=(bInphieudieutri);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			butTiep_Click(null,null);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			butIn.Enabled=false;
			#region phieudieutri
			if (bInphieudieutri)
			{
                int tuoi = DateTime.Now.Year - int.Parse(namsinh.Text);
				dsdt.Tables[0].Rows[0]["syt"]=m.Syte;
				dsdt.Tables[0].Rows[0]["bv"]=m.Tenbv;
				dsdt.Tables[0].Rows[0]["diachibv"]=m.Diachi;
				dsdt.Tables[0].Rows[0]["ngayin"]=m.Ngayhienhanh;
				dsdt.Tables[0].Rows[0]["nguoiin"]=s_userid;
				dsdt.Tables[0].Rows[0]["ghichu"]="PHÒNG SỐ : "+sovaovien.Text;
				dsdt.Tables[0].Rows[0]["lien"]="SỐ : "+sovaovien.Text;
				dsdt.Tables[0].Rows[0]["mabn"]=mabn2.Text+mabn3.Text;
				dsdt.Tables[0].Rows[0]["hoten"]=hoten.Text;
				dsdt.Tables[0].Rows[0]["namsinh"]=namsinh.Text;
                dsdt.Tables[0].Rows[0]["tuoi"] = tuoi.ToString() + " tuổi ";
				dsdt.Tables[0].Rows[0]["gioitinh"]=phai.SelectedIndex.ToString();
				dsdt.Tables[0].Rows[0]["diachi"]=thon.Text.Trim();
				dsdt.Tables[0].Rows[0]["ngaykham"]=ngayvv.Text+" "+giovv.Text;
                dsdt.Tables[0].Rows[0]["lydokham"] = tenvp.Text;
				dsdt.Tables[0].Rows[0]["nghenghiep"]="";
				dsdt.Tables[0].Rows[0]["doituong"]="";
				dsdt.Tables[0].Rows[0]["sothe"]="";
				dsdt.Tables[0].Rows[0]["tungay"]="";
				dsdt.Tables[0].Rows[0]["denngay"]="";
				dsdt.Tables[0].Rows[0]["dantoc"]="";
                dsdt.Tables[0].Rows[0]["dienthoai"] ="";
                dsdt.Tables[0].Rows[0]["bacsy"] = "";
                dsdt.Tables[0].Rows[0]["benhvien"] = "";
                dsdt.Tables[0].Rows[0]["kythuat"] = "";
				if (chkXem.Checked)
				{
					frmReport f=new frmReport(dsdt,"","","m_phieudieutri.rpt");
					f.ShowDialog(this);
				}
				else print.Printer(dsdt,"m_phieudieutri.rpt","","",0);
			}
			#endregion
			#region vienphi
            int i_mavp = 0;
            DataRow r1 = m.getrowbyid(dtmavp, "ma='" + mavp.Text + "'");
            if (r1!=null)
            {
                i_mavp = int.Parse(r1["id"].ToString());
                foreach (DataRow r2 in v.get_data("select * from "+user+".v_trongoi where id=" + i_mavp + " order by stt").Tables[0].Rows)
                        upd_data(ngayvv.Text+" "+giovv.Text, int.Parse(r2["id_gia"].ToString()),s_makp);
            }
			#endregion
			butTiep.Focus();
		}

        private void upd_data(string ngay, int _mavp, string _makp)
        {
            d_dongia = 0; d_vattu = 0; 
            string mmyy = m.mmyy(ngay);
            DataRow r = m.getrowbyid(dtgia, "id=" + _mavp);
            if (r != null)
            {
                l_id = m.get_id_chidinh(ngay, l_maql, _mavp, v.iNgoaitru);
                if (l_id == 0) l_id = v.get_id_chidinh;
                if (m.bNuocngoai(mabn2.Text + mabn3.Text))
                {
                    d_dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                    d_vattu = decimal.Parse(r["vattu_nn"].ToString()) * m.dTygia;
                }
                else
                {
                    string gia = m.field_gia("2");
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    d_dongia = decimal.Parse(r[gia].ToString());
                    d_vattu = decimal.Parse(r[giavt].ToString());
                }
                v.upd_chidinh(l_id, mabn2.Text + mabn3.Text,l_maql,l_maql, 0, ngay, v.iNgoaitru, _makp, 2, _mavp, 1, d_dongia, d_vattu, i_userid, 0, 0);
            }
        }

		private void l_chidinh_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql_tiepdon(s_mabn,s_makp,ngayvv.Text+" "+giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmChidinh f=new frmChidinh(m,s_mabn,hoten.Text,namsinh.Text,ngayvv.Text+" "+giovv.Text,s_makp,"Phòng khám",2,v.iNgoaitru,l_maql,l_maql,0,i_userid,"xxx.tiepdon","",nam);
			f.ShowDialog(this);			
		}

		private void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_tiepdon(s_mabn, s_makp, ngayvv.Text + " " + giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,namsinh.Text,thon.Text.Trim());
			f.ShowDialog(this);
			load_diungthuoc();
		}

		private void butInbarcode_Click(object sender, System.EventArgs e)
		{
			if (mabn2.Text+mabn3.Text=="" || hoten.Text=="") return;
            barcode.Picture.Save("..\\..\\..\\xml\\barcode.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            fstr = new FileStream("..\\..\\..\\xml\\barcode.bmp", FileMode.Open, FileAccess.Read);
            imagedata = new byte[fstr.Length];
            fstr.Read(imagedata, 0, System.Convert.ToInt32(fstr.Length));
            fstr.Close();
            dsbarcode.Clear();
            DataRow r1 = dsbarcode.Tables[0].NewRow();
            r1["mabn"] = mabn2.Text + mabn3.Text;
            r1["image"] = imagedata;
            dsbarcode.Tables[0].Rows.Add(r1);
			frmReport f=new frmReport(m,dsbarcode,"rptbarcode.rpt",mabn2.Text+mabn3.Text,hoten.Text,namsinh.Text,phai.Text,thon.Text,"");
			f.ShowDialog(this);
		}

		private void l_lichhen_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql_tiepdon(s_mabn,s_makp, ngayvv.Text + " " + giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
		}

        private void ngayvv_Validated(object sender, System.EventArgs e)
        {
            if (ngayvv.Text == "")
            {
                ngayvv.Focus();
                return;
            }
            ngayvv.Text = ngayvv.Text.Trim();
            if (ngayvv.Text.Length == 6) ngayvv.Text = ngayvv.Text + DateTime.Now.Year.ToString();
            if (ngayvv.Text.Length < 10)
            {
                MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày khám bệnh !"), s_msg);
                ngayvv.Focus();
                return;
            }
            if (!m.bNgay(ngayvv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                ngayvv.Focus();
                return;
            }
            l_maql = m.get_maql_tiepdon_ngay(s_mabn, ngayvv.Text);
            if (l_maql != 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã được đăng ký,") + "\n" + lan.Change_language_MessageText("Bạn có muốn xem lại !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    load_vv_maql(false);
                    if (!bAdmin) ena_but(false);
                    s_ngayvv = ngayvv.Text;
                    return;
                }
            }
            if (s_ngayvv != "")
                if (ngayvv.Text != s_ngayvv.Substring(0, 10))
                    s_ngayvv = ngayvv.Text;
        }

        private void giovv_Validated(object sender, EventArgs e)
        {
            string sgio = (giovv.Text.Trim() == "") ? "00:00" : giovv.Text.Trim();
            giovv.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giovv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giovv.Focus();
                return;
            }
            string s = ngayvv.Text + " " + giovv.Text;
            s_mabn = mabn2.Text + mabn3.Text;
            if (s != s_ngayvv)
            {
                l_maql = m.get_maql(s_mabn, "??", s);
                bNew = l_maql == 0;
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    if (!bAdmin) ena_but(false);
                }
                else
                {
                    ena_but(true);
                    emp_vv();
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                }
                s_ngayvv = s;
            }
            if (i_sokham != 3 && sovaovien.Text == "")
                sovaovien.Text = m.get_sokham(ngayvv.Text.Substring(0, 10),s_makp, i_sokham).ToString();
        }

        private void tenvp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listtenvp.Focus();
            else if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                if (listtenvp.Visible) listtenvp.Focus();
                else butLuu.Focus();
            }
        }

        private void mavp_Validated(object sender, EventArgs e)
        {
            DataRow r = v.getrowbyid(dtmavp, "ma='" + mavp.Text + "'");
            if (r != null)
                tenvp.Text = r["ten"].ToString();
            else
                tenvp.Text = "";
            if (!listtenvp.Focused) listtenvp.Hide();
        }

        private void mavp_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == mavp)
            {
                Filt_mavp(mavp.Text);
                listtenvp.Browse_mavp(mavp, tenvp, butLuu, mavp.Location.X, mavp.Location.Y + mavp.Height, mavp.Width + tenvp.Width + 4, mavp.Height);
            }
        }

        private void Filt_mavp(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listtenvp.DataSource];
            DataView dv = (DataView)cm.List;
            sql = "ma like '" + ten.Trim() + "%'";
            dv.RowFilter = sql;
        }

        private void tenvp_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tenvp)
            {
                Filt_tenvp(tenvp.Text);
                listtenvp.Browse_mavp(tenvp, mavp, butLuu, mavp.Location.X, mavp.Location.Y + mavp.Height, mavp.Width + tenvp.Width + 4, mavp.Height);
            }
        }

        private void Filt_tenvp(string ten)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[listtenvp.DataSource];
            DataView dv = (DataView)cm.List;
            sql = "TEN like '%" + ten.Trim() + "%'";
            dv.RowFilter = sql;
        }

        private void listtenvp_Validated(object sender, EventArgs e)
        {
            mavp_Validated(sender, e);
        }

        private void listtenvp_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                mavp.Text = listtenvp.Text.ToString();
                listtenvp.Hide();
                mavp_Validated(sender, e);
            }
            catch { }
        }

        private void mavp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listtenvp.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listtenvp.Visible)
                {
                    listtenvp.Focus();
                }
                else SendKeys.Send("{Tab}");
            }
        }
	}
}
