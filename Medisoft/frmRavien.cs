using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmRavien : System.Windows.Forms.Form
	{
        //linh 05062012
        bool bQuanLyPhongGiuongTuDong = false;
        //end linh
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private DataSet dsss=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dsxmlth=new DataSet();
		private DataSet dsth=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtbd=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtvp=new DataTable();
		private DataTable dtmadt=new DataTable(); 
		private DataTable dtdt=new DataTable(); 
		private DataTable dtss=new DataTable();
		private DataSet dsdone=new DataSet();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private decimal l_mavaovien,l_maql,l_idkhoa;
        private int i_loaiba, i_userid, i_maxlength_mabn = 8;
		private string s_makp,sql,s_ngayvao,user,nam,pathImage,FileType,tenuser;
        private bool bVienphi_phongluu, bTress_bame, bInravien_ravien, bThanhtoan_khoa, bSovaovien, bChiphikp_noingoai, bTTRV_Intenhoatchat_Truoc, bQuanly_Theo_Chinhanh;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged,bChitiet;
		int checkCol=0;
		private Brush disabledBackBrush1;
		private Brush disabledTextBrush1;
		private Brush alertBackBrush1;
		private Font alertFont1;
		private Brush alertTextBrush1;
		private Font currentRowFont1;
		private Brush currentRowBackBrush1;
		bool afterCurrentCellChanged1;
		int checkCol1=0;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.CheckedListBox madt;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.ComboBox maphu;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox done;
		private MaskedBox.MaskedBox ngayra;
		private System.Windows.Forms.CheckBox chkTH;
		private System.Windows.Forms.DateTimePicker ngayvv;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.CheckBox chkCT;
        private dllReportM.Print print = new dllReportM.Print();
        private CheckBox chkXML;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private CheckBox chkKhoa;
        private bool bCapve_noitru, bCapcuu_noitru, bThanhtoan_ndot;
        private CheckBox chkbhyttamung;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem tmn_inkem_hangsx;
        private ToolStripMenuItem tmn_Inkem_nuocsx;
        private ToolStripMenuItem tmn_inkem_hangnuocsx;
        private ToolStripMenuItem tmn_thanhtoanhieudot;
        private ToolStripMenuItem tmn_motlanmotBN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRavien(LibMedi.AccessData acc,string makp,int loaiba,string suserid,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; i_loaiba = loaiba; tenuser = suserid; i_userid = userid;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
					if(disabledBackBrush1 != null)
					{
						disabledBackBrush1.Dispose();
						disabledTextBrush1.Dispose();
						alertBackBrush1.Dispose();
						alertFont1.Dispose();
						alertTextBrush1.Dispose();
						currentRowFont1.Dispose();
						currentRowBackBrush1.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRavien));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.TextBox();
            this.madt = new System.Windows.Forms.CheckedListBox();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.maphu = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.ComboBox();
            this.ngayra = new MaskedBox.MaskedBox();
            this.chkTH = new System.Windows.Forms.CheckBox();
            this.ngayvv = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkCT = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.chkKhoa = new System.Windows.Forms.CheckBox();
            this.chkbhyttamung = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmn_inkem_hangsx = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_Inkem_nuocsx = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_inkem_hangnuocsx = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_thanhtoanhieudot = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_motlanmotBN = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(235, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(331, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(539, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(311, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "đến :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(445, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Khoa :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(157, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(421, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 76);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(460, 436);
            this.dataGrid1.TabIndex = 31;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(281, 26);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(68, 21);
            this.mabn.TabIndex = 3;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(394, 26);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 5;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(603, 26);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 7;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(507, 48);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(136, 21);
            this.tenkp.TabIndex = 16;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(481, 71);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(162, 21);
            this.diachi.TabIndex = 22;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(203, 71);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(112, 21);
            this.sothe.TabIndex = 18;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(209, 537);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(60, 25);
            this.butTiep.TabIndex = 25;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(270, 537);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 23;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(331, 537);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 24;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(453, 537);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 27;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(392, 537);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 26;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(514, 537);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 28;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(482, 48);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 15;
            // 
            // madt
            // 
            this.madt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madt.CheckOnClick = true;
            this.madt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madt.Location = new System.Drawing.Point(647, 25);
            this.madt.Name = "madt";
            this.madt.Size = new System.Drawing.Size(140, 68);
            this.madt.TabIndex = 30;
            this.madt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(68, 48);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(92, 21);
            this.ngayvao.TabIndex = 9;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // maphu
            // 
            this.maphu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maphu.Enabled = false;
            this.maphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphu.Items.AddRange(new object[] {
            "Đúng tuyến",
            "Trái tuyến"});
            this.maphu.Location = new System.Drawing.Point(316, 71);
            this.maphu.Name = "maphu";
            this.maphu.Size = new System.Drawing.Size(122, 21);
            this.maphu.TabIndex = 20;
            this.maphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphu_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-3, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tình trạng :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // done
            // 
            this.done.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.done.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.done.Location = new System.Drawing.Point(68, 25);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(157, 21);
            this.done.TabIndex = 1;
            this.done.SelectedIndexChanged += new System.EventHandler(this.done_SelectedIndexChanged);
            this.done.KeyDown += new System.Windows.Forms.KeyEventHandler(this.done_KeyDown);
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(340, 48);
            this.ngayra.Mask = "##/##/#### ##:##";
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(99, 21);
            this.ngayra.TabIndex = 13;
            this.ngayra.Text = "  /  /       :  ";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
            // 
            // chkTH
            // 
            this.chkTH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTH.Location = new System.Drawing.Point(424, 515);
            this.chkTH.Name = "chkTH";
            this.chkTH.Size = new System.Drawing.Size(112, 18);
            this.chkTH.TabIndex = 29;
            this.chkTH.Text = "In tổng hợp";
            this.chkTH.CheckedChanged += new System.EventHandler(this.chkTH_CheckedChanged);
            // 
            // ngayvv
            // 
            this.ngayvv.CalendarMonthBackground = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.CustomFormat = "dd/MM/yyyy HH:mm";
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayvv.Location = new System.Drawing.Point(203, 49);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(112, 21);
            this.ngayvv.TabIndex = 11;
            this.ngayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvv_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(160, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 23);
            this.label11.TabIndex = 10;
            this.label11.Text = "Từ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(2, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Đối tượng :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(68, 71);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(92, 21);
            this.madoituong.TabIndex = 33;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(480, 76);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.Size = new System.Drawing.Size(304, 435);
            this.dataGrid2.TabIndex = 34;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            this.dataGrid2.Click += new System.EventHandler(this.dataGrid2_Click);
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXem.Location = new System.Drawing.Point(238, 515);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 18);
            this.chkXem.TabIndex = 35;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkCT
            // 
            this.chkCT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCT.Checked = true;
            this.chkCT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCT.Location = new System.Drawing.Point(348, 515);
            this.chkCT.Name = "chkCT";
            this.chkCT.Size = new System.Drawing.Size(70, 18);
            this.chkCT.TabIndex = 36;
            this.chkCT.Text = "In chi tiết";
            this.chkCT.CheckedChanged += new System.EventHandler(this.chkCT_CheckedChanged);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.Location = new System.Drawing.Point(5, 515);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 18);
            this.chkXML.TabIndex = 37;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(714, 492);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 256;
            this.pic.TabStop = false;
            // 
            // chkKhoa
            // 
            this.chkKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKhoa.Location = new System.Drawing.Point(99, 515);
            this.chkKhoa.Name = "chkKhoa";
            this.chkKhoa.Size = new System.Drawing.Size(137, 18);
            this.chkKhoa.TabIndex = 257;
            this.chkKhoa.Text = "Thanh toán theo khoa";
            this.chkKhoa.CheckedChanged += new System.EventHandler(this.chkKhoa_CheckedChanged);
            // 
            // chkbhyttamung
            // 
            this.chkbhyttamung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkbhyttamung.Location = new System.Drawing.Point(5, 537);
            this.chkbhyttamung.Name = "chkbhyttamung";
            this.chkbhyttamung.Size = new System.Drawing.Size(155, 18);
            this.chkbhyttamung.TabIndex = 258;
            this.chkbhyttamung.Text = "Tạm ứng gom về BHYT";
            this.chkbhyttamung.Click += new System.EventHandler(this.chkbhyttamung_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 259;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmn_inkem_hangsx,
            this.tmn_Inkem_nuocsx,
            this.tmn_inkem_hangnuocsx,
            this.tmn_thanhtoanhieudot,
            this.tmn_motlanmotBN});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(64, 22);
            this.toolStripDropDownButton1.Text = "Tùy chọn";
            // 
            // tmn_inkem_hangsx
            // 
            this.tmn_inkem_hangsx.CheckOnClick = true;
            this.tmn_inkem_hangsx.Name = "tmn_inkem_hangsx";
            this.tmn_inkem_hangsx.Size = new System.Drawing.Size(281, 22);
            this.tmn_inkem_hangsx.Text = "Thuốc, In kèm tên hãng sản xuất";
            this.tmn_inkem_hangsx.Click += new System.EventHandler(this.tmn_inkem_hangsx_Click);
            // 
            // tmn_Inkem_nuocsx
            // 
            this.tmn_Inkem_nuocsx.CheckOnClick = true;
            this.tmn_Inkem_nuocsx.Name = "tmn_Inkem_nuocsx";
            this.tmn_Inkem_nuocsx.Size = new System.Drawing.Size(281, 22);
            this.tmn_Inkem_nuocsx.Text = "Thuốc, In kèm Nước sản xuất";
            this.tmn_Inkem_nuocsx.Click += new System.EventHandler(this.tmn_Inkem_nuocsx_Click);
            // 
            // tmn_inkem_hangnuocsx
            // 
            this.tmn_inkem_hangnuocsx.CheckOnClick = true;
            this.tmn_inkem_hangnuocsx.Name = "tmn_inkem_hangnuocsx";
            this.tmn_inkem_hangnuocsx.Size = new System.Drawing.Size(281, 22);
            this.tmn_inkem_hangnuocsx.Text = "Thuốc In kèm cả nước, và hãng sản xuất";
            this.tmn_inkem_hangnuocsx.Click += new System.EventHandler(this.tmn_inkem_hangnuocsx_Click);
            // 
            // tmn_thanhtoanhieudot
            // 
            this.tmn_thanhtoanhieudot.CheckOnClick = true;
            this.tmn_thanhtoanhieudot.Name = "tmn_thanhtoanhieudot";
            this.tmn_thanhtoanhieudot.Size = new System.Drawing.Size(281, 22);
            this.tmn_thanhtoanhieudot.Text = "Thanh toán nhiều đợt";
            this.tmn_thanhtoanhieudot.Click += new System.EventHandler(this.tmn_thanhtoanhieudot_Click);
            // 
            // tmn_motlanmotBN
            // 
            this.tmn_motlanmotBN.CheckOnClick = true;
            this.tmn_motlanmotBN.Name = "tmn_motlanmotBN";
            this.tmn_motlanmotBN.Size = new System.Drawing.Size(281, 22);
            this.tmn_motlanmotBN.Text = "Mỗi lần chỉ in một Bệnh nhân";
            this.tmn_motlanmotBN.Click += new System.EventHandler(this.tmn_motlanmotBN_Click);
            // 
            // frmRavien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chkbhyttamung);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.chkKhoa);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkCT);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkTH);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.done);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maphu);
            this.Controls.Add(this.madt);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.dataGrid2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRavien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu thanh toán ra viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRavien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmRavien_Load(object sender, System.EventArgs e)
		{
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            bQuanLyPhongGiuongTuDong = m.bPhonggiuong;
            bInravien_ravien = m.bInravien_ravien;
            bTTRV_Intenhoatchat_Truoc = m.bTTRV_Intenhoatchat_Truoc;
            bSovaovien = m.bInsovaovien_ravien;
            pic.Visible = m.bHinh || m.bChonhinh;
            pathImage = m.pathImage;
            FileType = m.FileType;
            s_makp = ""; user = m.user;
			bTress_bame=m.bTress_bame;
            bCapve_noitru=m.bCapve_noitru;
            bCapcuu_noitru = m.bCapcuu_noitru;
            bChiphikp_noingoai = m.bChiphikp_noingoai;
            tmn_motlanmotBN.Checked = m.Thongso("ttrv_motlan1benhnhan") == "1";
            string s_inkem = m.Thongso("ttrv_inkem");
            if (s_inkem == "1") tmn_inkem_hangsx.Checked = true;
            else if (s_inkem == "2") tmn_Inkem_nuocsx.Checked = true;
            else if (s_inkem == "3") tmn_inkem_hangnuocsx.Checked = true;
			if (!bTress_bame)
			{
				this.dataGrid1.Size = new System.Drawing.Size(772, 384);
				dataGrid2.Visible=false;
			}
            tmn_thanhtoanhieudot.Enabled = true;
            bThanhtoan_ndot = tmn_thanhtoanhieudot.Checked;
			chkXem.Checked=m.bPreview;
			bVienphi_phongluu=m.bCapcuu_noitru;
			bChitiet=m.bInthanhtoanchitiet;
            bThanhtoan_khoa = m.bThanhtoan_khoa;
            chkKhoa.Visible = bThanhtoan_khoa;
            if (bThanhtoan_khoa) chkKhoa.Checked = true;
			ngayvv.Enabled=bThanhtoan_ndot || bThanhtoan_khoa;            
			dtkp=m.get_data("select * from "+user+".d_duockp where nhom like '%"+m.nhom_duoc+",%'").Tables[0];
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
            load_dmbd();//
            sql="select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom,a.bhyt";
			sql+=",a.gia_th,a.gia_bh,a.gia_cs,a.gia_dv,a.gia_nn,a.vattu_th,a.vattu_bh,a.vattu_cs,a.vattu_dv,a.vattu_nn,a.chenhlech,a.kythuat,c.ma as manhomvp ";
            sql += ", a.kcct, a.bhyt_tt, a.sothe ";
            sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
			sql+=" where a.id_loai=b.id and b.id_nhom=c.ma";
			dtvp=m.get_data(sql).Tables[0];
            dtmadt = m.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madt.DataSource=dtmadt;
            madt.DisplayMember = "DOITUONG";
            madt.ValueMember = "MADOITUONG";
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
			madoituong.DataSource=dtdt;
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            chkbhyttamung.Checked = m.Thongso("gomtamung_bhyt") == "1";
			dsdone.ReadXml("..//..//..//xml//m_ttrang.xml");
            DataRow r = dsdone.Tables[0].NewRow();
            if (m.bAdmin_hethong(i_userid))
            {
                r["ma"] = 3;
                r["ten"] = "In tất cả";
                dsdone.Tables[0].Rows.Add(r);
            }
			done.DisplayMember="ten";
			done.ValueMember="ma";
			done.DataSource=dsdone.Tables[0];

			dsth.ReadXml("..//..//..//xml//v_bienlaidoc.xml");
			dsxmlth.ReadXml("..//..//..//xml//v_bienlaidoc.xml");
			dsngay.ReadXml("..//..//..//xml//m_ngayvao.xml");
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("tenbs");
            dsngay.Tables[0].Columns.Add("cholam");
            try
            {
                dsngay.Tables[0].Columns.Add("MAVAOVIEN", typeof(decimal));
            }
            catch { }
            dsngay.Tables[0].Columns.Add("traituyen", typeof(decimal));

			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];
			dsxml.ReadXml("..//..//..//xml//m_inravien.xml");
            dsxml.Tables[0].Columns.Add("Image", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("mabs");
            dsxml.Tables[0].Columns.Add("tenbs");
            dsxml.Tables[0].Columns.Add("makprv");
            dsxml.Tables[0].Columns.Add("cholam");
            dsxml.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("idttrv", typeof(string));
            dsxml.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsxml.Tables[0].Columns.Add("traituyen", typeof(decimal));
            dsxml.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("loaikythuat", typeof(string));
            dsxml.Tables[0].Columns.Add("quyenso_tt", typeof(string));
            dsxml.Tables[0].Columns.Add("sobienlai_tt", typeof(string));
            try { dsxml.Tables[0].Columns.Add("id_ktcao", typeof(decimal)); }
            catch { }
            try { dsxml.Tables[0].Columns.Add("id_vpkhoa", typeof(decimal)); }
            catch { }

			ds.ReadXml("..//..//..//xml//m_ravien.xml");
			ds.Tables[0].Columns.Add("chon",typeof(bool));
            ds.Tables[0].Columns.Add("mabs");
            ds.Tables[0].Columns.Add("tenbs");
            ds.Tables[0].Columns.Add("makprv");
            ds.Tables[0].Columns.Add("cholam");
            ds.Tables[0].Columns.Add("gianovat", typeof(decimal));
            ds.Tables[0].Columns.Add("idttrv", typeof(string));
            ds.Tables[0].Columns.Add("sotientra", typeof(decimal));
            ds.Tables[0].Columns.Add("traituyen", typeof(decimal));
            ds.Tables[0].Columns.Add("kythuat", typeof(decimal));
            ds.Tables[0].Columns.Add("loaikythuat", typeof(string));
            ds.Tables[0].Columns.Add("quyenso_tt", typeof(string));
            ds.Tables[0].Columns.Add("sobienlai_tt", typeof(string));
            try
            {
                ds.Tables[0].Columns.Add("MAVAOVIEN", typeof(decimal));
            }
            catch { }

			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

            this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));

			dsss.ReadXml("..//..//..//xml//m_ravienss.xml");
			dsss.Tables[0].Columns.Add("chon",typeof(bool));
            dsss.Tables[0].Columns.Add("mabs");
            dsss.Tables[0].Columns.Add("tenbs");
            dsss.Tables[0].Columns.Add("makprv");
            dsss.Tables[0].Columns.Add("cholam");
            dsss.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsss.Tables[0].Columns.Add("idttrv", typeof(decimal));
            dsss.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsss.Tables[0].Columns.Add("traituyen", typeof(decimal));
            dsss.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsss.Tables[0].Columns.Add("loaikythuat", typeof(string));


			dataGrid2.DataSource=dsss.Tables[0];
			CurrencyManager cm1 = (CurrencyManager)BindingContext[dataGrid2.DataSource];
			DataView dv1 = (DataView) cm1.List; 
			dv1.AllowNew = false; 
			AddGridTableStyle1();
			lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());

			this.disabledBackBrush1 = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush1 = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush1 = new SolidBrush(SystemColors.HotTrack);
			this.alertFont1 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Bold);
			this.alertTextBrush1 = new SolidBrush(Color.White);
			
			this.currentRowFont1 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush1 = new SolidBrush(Color.FromArgb(0,255, 255));
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0,traituyen=0;string s_chandoan,s_maicd,s_giuong,s_cont="",s_sothe="",s_denngay="^",s_tenbv="";decimal o_maql;
            int iDone = done.SelectedIndex;//0: chuyen so lieu; 1: da thanh toan; 2: kiem tra so lieu; 3: in tat ca
            string s_idttrv = "";
            DataSet lds;
            hoten.Text = ""; l_mavaovien = 0; l_maql = 0; l_idkhoa = 0; dsngay.Clear();
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
            //if (mabn.Text.Trim().Length != 8)
            //{
            //    if (bQuanly_Theo_Chinhanh)
            //    {
            //        mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(i_maxlength_mabn - 2, '0');
            //    }
            //    else
            //    {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
            //    }
            //}
            if (ngayvv.Enabled && i_loaiba == 1 && bThanhtoan_khoa)//thanh toan theo khoa
            {
                if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") s_cont = user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id";
                else if (done.SelectedValue.ToString() == "2" || ngayvv.Enabled) s_cont = user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id";
                else s_cont = user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id";
                sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,h.mavaovien,a.maql,a.id,a.giuong,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                sql += "a.makp,d.tenkp,coalesce(b.chandoan,a.chandoan) as chandoan,coalesce(b.maicd,a.maicd) as maicd,e.tentt,f.tenquan,g.tenpxa,";
                sql += "case when b.ketqua is null then 0 else b.ketqua end as ketqua,";
                sql += "case when b.ttlucrk is null then 0 else b.ttlucrk end as ttlucrv,";
                if (bSovaovien) sql += "'^'||nvl(h.sovaovien,'') as soluutru,";
                else sql += "' ^' as soluutru,";
                sql += "h.madoituong,case when b.mabs is null then a.mabs else b.mabs end as mabs,";
                sql += "case when b.mabs is null then i.hoten else j.hoten end as tenbs,c.cholam, k.ten as nhantu ";
                sql += "from " + s_cont + " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += "inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                sql += "inner join " + user + ".benhandt h on a.maql=h.maql ";
                sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                sql += "left join " + user + ".dmbs j on b.mabs=j.ma ";
                sql += "left join " + user + ".nhantu k on h.nhantu=k.ma ";

                sql += "where a.mabn='" + mabn.Text + "' and h.tuchoi=0 ";
                if (s_makp != "") sql += " and a.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ") ";
                sql+="order by a.id desc";
            }
            else//thanh toan 1 hay nhieu dot
            {
                if (i_loaiba == 1)
                {
                    if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") s_cont = user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id";
                    else if (done.SelectedValue.ToString() == "2" || ngayvv.Enabled) s_cont = user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql ";
                    else s_cont = user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                    sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") sql += "a.makp,d.tenkp,";
                    else
                    {
                        sql += "case when b.makp is null then a.makp else b.makp end as makp,";
                        sql += "case when b.makp is null then h.tenkp else d.tenkp end as tenkp,";
                    }
                    sql += "b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,case when b.ketqua is null then 0 else b.ketqua end as ketqua,";
                    sql += "case when b.ttlucrv is null then 0 else b.ttlucrv end as ttlucrv,";
                    if (bSovaovien) sql += "nvl(b.soluutru,'')||'^'||nvl(a.sovaovien,'') as soluutru,";
                    else sql += "nvl(b.soluutru,'')||'^' as soluutru,";
                    sql += "a.madoituong,case when b.mabs is null then a.mabs else b.mabs end as mabs,";
                    sql += "case when b.mabs is null then i.hoten else j.hoten end as tenbs,c.cholam";
                    if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") sql += ", null as nhantu ";
                    else sql += ", k.ten as nhantu ";
                    sql += " from " + s_cont + " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    if (chkKhoa.Checked && done.SelectedValue.ToString() == "0")
                        sql += "left join " + user + ".btdkp_bv d on a.makp=d.makp ";
                    else
                        sql += "left join " + user + ".btdkp_bv d on b.makp=d.makp ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                    sql += "left join " + user + ".dmbs j on b.mabs=j.ma ";
                    if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") sql += "";
                    else sql += "left join " + user + ".nhantu k on a.nhantu=k.ma ";
                    sql += "where a.mabn='" + mabn.Text + "'";
                    if (chkKhoa.Checked == false) sql += " and a.tuchoi=0";
                    sql += " order by a.maql desc";
                }
                else if (i_loaiba == 2)
                {
                    sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "a.makp,h.tenkp,a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,a.ketqua,";
                    sql += "a.ttlucrv,";
                    if (bSovaovien) sql += "a.soluutru||'^'||nvl(a.sovaovien,'') as soluutru,";
                    else sql += "nvl(a.soluutru,'')||'^' as soluutru,";
                    sql += "a.madoituong,a.mabs,i.hoten as tenbs,c.cholam, k.ten as nhantu ";
                    sql += "from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    if (done.SelectedValue.ToString() == "2" || (bThanhtoan_ndot && done.SelectedValue.ToString()=="0")) sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                    else sql += "inner join " + user + ".dmbs i on a.mabs=i.ma ";
                    sql += "left join " + user + ".nhantu k on a.nhantu=k.ma ";
                    sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                }
                else
                {
                    nam = m.get_mabn_nam(mabn.Text);
                    if (nam == "") nam = m.mmyy(m.Ngaygio_hienhanh)+"+";
                    sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,a.giuong,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "a.makp,h.tenkp,a.chandoan||'; '||a.chandoanrv as chandoan,a.maicd||'; '||a.maicdrv as maicd,e.tentt,f.tenquan,g.tenpxa,a.ketqua,";
                    sql += "a.ttlucrv,";
                    if (bSovaovien) sql += "nvl(a.soluutru,'')||'^'||a.sovaovien as soluutru,";
                    else sql += "nvl(a.soluutru,'')||'^' as soluutru,";
                    sql += "a.madoituong,a.mabs,i.hoten as tenbs,c.cholam, k.ten as nhantu ";
                    sql += "from xxx.benhancc a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                    sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                    sql += "left join " + user + ".nhantu k on a.nhantu=k.ma ";
                    sql += "where a.mabn='" + mabn.Text + "'";
                    if (done.SelectedValue.ToString() == "0" && !bThanhtoan_ndot) sql += " and a.ngayrv is not null ";
                    sql += "order by a.maql desc";
                }
            }
            DataSet m_ds = (i_loaiba == 4) ? m.get_data_nam_all_dec(nam, sql) : m.get_data(sql);
            foreach (DataRow r in m_ds.Tables[0].Select("","maql desc"))//.Rows)
            {
                //if (i == 0)
                //{
                    hoten.Text = r["hoten"].ToString();
                    namsinh.Text = r["namsinh"].ToString();
                    s_ngayvao = r["ngayvao"].ToString();
                    ngayra.Text = r["ngayra"].ToString();
                    //diachi.Text = r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim();
                    if (r["sonha"].ToString().Trim() != null)
                    {
                        diachi.Text += r["sonha"].ToString().Trim() + ",";// +" " + r["thon"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString().Trim();
                    }
                    if (r["thon"].ToString().Trim() != null)
                    {
                        diachi.Text += r["thon"].ToString().Trim() + ",";
                    }
                    if (r["tenpxa"].ToString().Trim() != null)
                    {
                        diachi.Text +=  r["tenpxa"].ToString().Trim() + ",";
                    }
                    if (r["tenquan"].ToString().Trim() != null)
                    {
                        diachi.Text +=  r["tenquan"].ToString().Trim() + ",";
                    }
                    if (r["tentt"].ToString().Trim() != null)
                    {
                        diachi.Text += r["tentt"].ToString().Trim() + ",";
                    }
                //
                    makp.Text = r["makp"].ToString();
                    tenkp.Text = r["tenkp"].ToString();
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                    l_maql = decimal.Parse(r["maql"].ToString());
                    l_idkhoa = decimal.Parse(r["id"].ToString());
                    sothe.Text = m.get_sothe_thanhtoan(l_maql).ToString();
                    s_sothe = sothe.Text;
                    madoituong.SelectedValue = r["madoituong"].ToString();
                    int dd = int.Parse(s_ngayvao.Substring(0, 2));
                    int mm = int.Parse(s_ngayvao.Substring(3, 2));
                    int yyyy = int.Parse(s_ngayvao.Substring(6, 4));
                    int hh = int.Parse(s_ngayvao.Substring(11, 2));
                    int mi = int.Parse(s_ngayvao.Substring(14, 2));
                    if (!ngayvv.Enabled) ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
                    if (ngayvv.Enabled && ngayra.Text != "")
                    {
                        if (m.bNgaygio(m.ngayhienhanh_server, s_ngayvao))
                            ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
                    }
                    string sql_the = "select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv,a.traituyen, a.mabv from " + user + ".bhyt a left join " + user + ".dmnoicapbhyt b on a.mabv=b.mabv where a.maql=" + l_maql;
                    //if (bThanhtoan_ndot) sql_the += " and to_date(to_char(a.denngay,'dd/mm/yyyy'),'dd/mm/yyyy')>to_date('" + ngayra.Text.Substring(0, 10) + "','dd/mm/yyyy') order by to_char(a.denngay,'yymmdd')";
                    string s_nhieuthe = "";
                    int i_the = 0;
                    foreach (DataRow r1 in m.get_data(sql_the).Tables[0].Rows)
                    {
                        i_the += 1;
                        if (i_the == 1)
                        {
                            s_sothe = r1["sothe"].ToString(); s_denngay = r1["tungay"].ToString() + "^" + r1["denngay"].ToString();
                            s_tenbv = r1["tenbv"].ToString() + "^" + r1["mabv"].ToString(); traituyen = int.Parse(r1["traituyen"].ToString());
                            maphu.SelectedIndex = traituyen;
                            maphu.Enabled = traituyen == 0;
                            sothe.Text = s_sothe;
                        }
                        s_nhieuthe += r1["sothe"].ToString() + " [HSD: " + r1["tungay"].ToString() + " - " + r1["denngay"].ToString() + "]; ";
                    }
                    //
                    if (s_nhieuthe.Trim().Trim(';').Split(';').Length > 1 && tmn_thanhtoanhieudot.Enabled)//&& tmn_thanhtoanhieudot.Checked == false)
                    {
                        bThanhtoan_ndot = true;
                        tmn_thanhtoanhieudot.Checked = true;
                        tmn_thanhtoanhieudot_Click(null, null);
                        if (done.SelectedIndex == 0) MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này có '" + s_nhieuthe.Trim().Trim(';').Split(';').Length + "' thẻ.\n" + s_nhieuthe.Trim().Trim(';') + "\nBạn nhớ chuyển số liệu theo đợt."));
                    }
                    //binh
                    if (s_sothe == "")
                    {
                        string _mmyy = mm.ToString().PadLeft(2, '0') + yyyy.ToString().Substring(2, 2);
                        if (m.bMmyy(_mmyy))
                        {
                            foreach (DataRow r1 in m.get_data("select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv,a.traituyen, a.mabv from " + user + _mmyy + ".bhyt a left join " + user + ".dmnoicapbhyt b on a.mabv=b.mabv where a.maql=" + l_maql).Tables[0].Rows)
                            {
                                s_sothe = r1["sothe"].ToString(); s_denngay = r1["tungay"].ToString() + "^" + r1["denngay"].ToString();
                                sothe.Text = s_sothe; traituyen = int.Parse(r1["traituyen"].ToString());
                                maphu.SelectedIndex = traituyen;
                                maphu.Enabled = traituyen == 0;
                                s_tenbv = r1["tenbv"].ToString() + "^" + r1["mabv"].ToString();
                                break;
                            }
                        }
                    }
                    if (pic.Visible)
                    {
                        bool error = false;
                        try
                        {
                            if (pathImage != "")
                            {
                                error = true;
                                pic.Tag = (System.IO.File.Exists(pathImage + "//" + mabn.Text + "." + FileType)) ? pathImage + "//" + mabn.Text + "." + FileType : "0000.bmp";
                            }
                            else
                            {
                                image = new byte[0];
                                image = (byte[])(r["image"]);
                                memo = new MemoryStream(image);
                                map = new Bitmap(Image.FromStream(memo));
                                pic.Image = (Bitmap)map;
                                pic.Tag = image;
                            }
                        }
                        catch
                        {
                            error = true;
                            pic.Tag = "0000.bmp";
                        }
                        if (error)
                        {
                            fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            map = new Bitmap(Image.FromStream(fstr));
                            pic.Image = (Bitmap)map;
                        }
                    }
                //}
                o_maql = decimal.Parse(r["maql"].ToString());
                s_giuong = r["giuong"].ToString().Trim();
                if (s_giuong == "") s_giuong = m.get_giuong(o_maql, r["makp"].ToString());
                s_chandoan = r["chandoan"].ToString();
                s_maicd = r["maicd"].ToString();
                //if (int.Parse(m.sothe(int.Parse(r["madoituong"].ToString())).Substring(0,2))>0)
                //{
                //
                string maso = l_maql.ToString() + ",";
                if (i_loaiba == 1)
                {
                    //_ngayvv = m.get_ngay_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                    maso += m.get_maql_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                    if (m.bBHYTngtr_noitru || bChiphikp_noingoai) maso += m.get_maql_ngoaitru(ngayvv.Text.Substring(0, 10), (ngayra.Text != "") ? ngayra.Text.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), l_mavaovien);//ngoai tru chuyen vao noi tru: G24 chọn hay G54: chọn
                    //maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
                }
                else if (i_loaiba == 2)
                {
                    maso += m.get_maql_ngoaitru(ngayvv.Text.Substring(0, 10), (ngayra.Text != "") ? ngayra.Text.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), l_mavaovien);//l_maql
                    maso += m.get_maql_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                }
                maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
                maso += l_mavaovien.ToString() + ",";
                //lay chan doan trong nhapkhoa, xuatkhoa
                s_chandoan += (s_chandoan == "") ? "" : "; "; s_maicd += (s_maicd == "") ? "" : "; ";
                //
                
                //
                lds = m.get_data("select chandoan,maicd from " + user + ".cdkemtheo where loai<>1 and maql in (" + maso.Trim().Trim(',') + ")"); //Khuong 17/11/2011 khong lay chan doan kem theo cua phong kham loai=1 la cd kem theo cua pk
                if (lds != null && lds.Tables.Count > 0)
                {
                    foreach (DataRow r1 in lds.Tables[0].Rows)
                    {
                        if (s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0)
                        {
                            s_chandoan += r1["chandoan"].ToString().Trim() + ";";
                            s_maicd += r1["maicd"].ToString().Trim() + ";";
                        }
                    }
                }
                if (i_loaiba == 4)//Khuong 11/11/2011 Neu la benh an cap cuu thi in chan doan kem theo, con noi tru thi ko lay cd cua phong kham va phong luu
                {
                    lds = m.get_data("select chandoan,maicd from " + user + m.mmyy(s_ngayvao) + ".cdkemtheo where maql in (" + maso.Trim().Trim(',') + ")");
                    if (lds != null && lds.Tables.Count > 0)
                    {
                        foreach (DataRow r1 in lds.Tables[0].Rows)
                        {
                            if (s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0)
                            {
                                s_chandoan += r1["chandoan"].ToString().Trim() + "; ";
                                s_maicd += r1["maicd"].ToString().Trim() + "; ";
                            }
                        }
                    }
                }
                lds = m.get_data("select a.chandoan,a.maicd, b.chandoan as chandoan1, b.maicd as maicd1 from " + user + ".nhapkhoa a," + user + ".xuatkhoa b where a.id=b.id and a.maql in (" + maso.Trim().Trim(',') + ")");
                if (lds != null && lds.Tables.Count > 0)
                {
                    int itmp = 1;
                    foreach (DataRow r1 in lds.Tables[0].Rows)
                    {
                        if (s_maicd.IndexOf(r1["maicd"].ToString().Trim() + ";") < 0)
                        {
                            s_chandoan += r1["chandoan"].ToString().Trim() + "; ";
                            s_maicd += r1["maicd"].ToString().Trim() + "; ";
                        }

                        if (s_maicd.IndexOf(r1["maicd1"].ToString().Trim() + ";") < 0)
                        {
                            if (m.bHienChandoan_cuoicung)
                            {
                                s_chandoan = "";
                                s_maicd = "";
                            }
                            s_chandoan += r1["chandoan1"].ToString().Trim() + "; ";
                            s_maicd += r1["maicd1"].ToString().Trim() + "; ";
                        }
                        if (itmp == lds.Tables[0].Rows.Count && m.bHienChandoan_cuoicung)
                        {
                            s_chandoan = "";
                            s_maicd = "";
                            s_chandoan += r1["chandoan1"].ToString().Trim() + "; ";
                            s_maicd += r1["maicd1"].ToString().Trim() + "; ";
                            DataSet ads_cdktheo = m.get_data("select chandoan,maicd from " + user + ".cdkemtheo where loai=4 and maql in (" + maso.Trim().Trim(',') + ")");
                            if (lds != null && ads_cdktheo.Tables.Count > 0)
                            {
                                foreach (DataRow r_r in ads_cdktheo.Tables[0].Rows)
                                {
                                    if (s_maicd.IndexOf(r_r["maicd"].ToString().Trim() + ";") < 0)
                                    {
                                        s_chandoan += r_r["chandoan"].ToString().Trim() + ";";
                                        s_maicd += r_r["maicd"].ToString().Trim() + ";";
                                    }
                                }
                            }
                        }
                        itmp++;
                    }
                }
                m.updrec_ravien(dsngay, mabn.Text, l_mavaovien, o_maql, decimal.Parse(r["id"].ToString()),
                    hoten.Text, r["namsinh"].ToString(), (r["phai"].ToString() == "0") ? "Nam" : "Nữ", r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + ", " + r["tenpxa"].ToString().Trim() + ", " + r["tenquan"].ToString().Trim() + ", " + r["tentt"].ToString().Trim(),
                    int.Parse(r["madoituong"].ToString()), "", s_sothe, s_denngay, ((i_loaiba == 4) ? m.get_noigioithieu(r["ngayvao"].ToString(), o_maql) : m.get_noigioithieu(o_maql)) + "^" + r["nhantu"].ToString(), s_tenbv, s_giuong, r["makp"].ToString(), r["tenkp"].ToString(), r["ngayvao"].ToString(), r["ngayra"].ToString(),
                    s_chandoan, s_maicd, (i_loaiba == 4) ? m.get_nguoinha(m.mmyy(r["ngayvao"].ToString()), mabn.Text, o_maql) : m.get_nguoinha(mabn.Text, o_maql), 2,
                    m.phuongphapdieutri(r["makp"].ToString()), m.ketquadieutri(int.Parse(r["ketqua"].ToString()),
                    int.Parse(r["ttlucrv"].ToString())), r["soluutru"].ToString(), r["tenbs"].ToString(), r["mabs"].ToString(), r["cholam"].ToString(), traituyen);
                i++;
            }
            if (l_maql == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
            else
            {
                ngayvao.SelectedIndex = 0;// ngayvao.SelectedValue = s_ngayvao;
                f_loaid_ttbn();
            }
            //if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(l_maql);
            maphu.Enabled = sothe.Text != "" && maphu.SelectedIndex <= 0 && bThanhtoan_ndot;
            if (bThanhtoan_khoa)
            {
                DataRow r1=m.getrowbyid(dtdt,"sothe=1 and mien=1 and madoituong="+int.Parse(madoituong.SelectedValue.ToString()));
                if (r1 != null) chkKhoa.Enabled = true;
                else
                {
                    chkKhoa.Checked = true;
                    chkKhoa.Enabled = false;
                }
            }            
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			butTiep.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butExit.Enabled=!ena;
            done.Enabled = ena;//binh
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			mabn.Text="";
			hoten.Text="";
			namsinh.Text="";
			ngayra.Text=m.Ngaygio_hienhanh;
			tenkp.Text="";
			makp.Text="";
			sothe.Text="";
			diachi.Text="";
			l_maql=0;l_idkhoa=0;
			for(int i=0;i<madt.Items.Count;i++) madt.SetItemCheckState(i,CheckState.Unchecked);
            if (tmn_motlanmotBN.Checked) butHuy_Click(null, null);
			ena_but(true);
            tmn_thanhtoanhieudot.Checked = false;
            m.writeXml("thongso", "ttrv_ndot", tmn_thanhtoanhieudot.Checked ? "1" : "0");
            dsngay.Clear();
			done.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		
        {
            string s_idttrv = "", s_quyenso = "", s_sobienlai = "";
            int iDone = done.SelectedIndex;
            if (done.SelectedIndex==0 && bCapcuu_noitru && i_loaiba == 4 && Capcuu_dachuyen_noitru(l_mavaovien.ToString()))
            {
                DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã xử trí nhập viện.") + "\n" + lan.Change_language_MessageText("Bạn có muốn chuyển số liệu xuống viện phí không?"), "TTRV", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.No)
                {
                    done.SelectedIndex = 2;
                    done.Focus();
                    return;
                }
            }
            if (m.bNgay(ngayra.Text) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập ngày ra."));
                ngayra.Focus();
            }
            DateTime dtvv = m.StringToDateTime(ngayvao.Text);
            DateTime dtrv = m.StringToDateTime(ngayra.Text);
            if (dtvv > dtrv)
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày giờ ra phải lớn hơn ngày giờ vào."), "TTRV");
                ngayra.Focus();
                return ;
            }
            if (bThanhtoan_ndot || bThanhtoan_khoa)
            {
                dtvv = m.StringToDateTime(ngayvv.Text);
                dtrv = m.StringToDateTime(ngayra.Text);
                if (dtvv > dtrv)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày giờ ra phải lớn hơn ngày giờ vào."), "TTRV");
                    ngayvv.Focus();
                    return;
                }
            }
			if (hoten.Text!="")
			{
				if (m.getrowbyid(ds.Tables[0],"mabn='"+mabn.Text+"'")!=null)
				{
					butBoqua_Click(sender,e);
					return;
				}
				if (done.SelectedValue.ToString()=="0")
				{
                    try
                    {
                        string s1 = "", stime = "'" + m.f_ngay + "'";
                        sql = "select distinct to_char(ngay,'dd/mm/yyyy') as ngay from xxx.d_thuocbhytll where done=0 and mabn='" + mabn.Text + "'";
                        sql += " and " + m.for_ngay("ngay", stime) + " between to_date('" + ngayvv.Text.Substring(0,10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0,10) + "'," + stime + ")";
                        foreach (DataRow r in m.get_data_mmyy(sql, ngayvv.Text.Substring(0, 10), ngayra.Text.Substring(0, 10), false).Tables[0].Rows) s1 += r["ngay"].ToString() + "\n";
                        if (s1 != "")
                            if (MessageBox.Show(lan.Change_language_MessageText("Đơn thuốc ngày :")+"\n" + s1 + lan.Change_language_MessageText("Dược chưa phát, Bạn có muốn in ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                done.Focus();
                                return;
                            }
                    }
                    catch { }
					if (v.get_done_thvp(ngayra.Text,mabn.Text,l_maql,l_idkhoa,ngayvv.Text,i_loaiba==4))
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh \n")+hoten.Text+"\n"+ngayvv.Text+lan.Change_language_MessageText("\nđã thanh toán !"),LibMedi.AccessData.Msg);
						done.Focus();
						return;
					}
				}
				string s_cont="";
                if (ngayvv.Enabled && i_loaiba == 1)
                {
                    if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") s_cont = user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id";
                    else if (done.SelectedValue.ToString() == "2" || ngayvv.Enabled) s_cont = user + ".nhapkhoa a left join " + user + ".xuatkhoa b on a.id=b.id";
                    else s_cont = user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id";
                    sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,h.mavaovien,a.maql,a.id,a.giuong,";
                    sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                    sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                    sql += "a.makp,d.tenkp,b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,";
                    sql += "case when b.ketqua is null then 0 else b.ketqua end as ketqua,";
                    sql += "case when b.ttlucrk is null then 0 else b.ttlucrk end as ttlucrv, ' ^' as soluutru,";                    
                    sql += "h.madoituong,case when b.mabs is null then a.mabs else b.mabs end as mabs,";
                    sql += "case when b.mabs is null then i.hoten else j.hoten end as tenbs ";
                    sql += "from " + s_cont + " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                    sql += "inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                    sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                    sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                    sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                    sql += "inner join " + user + ".benhandt h on a.maql=h.maql ";
                    sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                    sql += "left join " + user + ".dmbs j on b.mabs=j.ma ";
                    sql += "where a.mabn='" + mabn.Text + "'";
                    if (s_makp != "") sql += " and a.makp in (" + s_makp.Substring(0, s_makp.Length - 1) + ") ";
                    sql += "order by a.id desc";
                }
                else
                {
                    if (i_loaiba == 1)
                    {
                        if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") s_cont = user + ".nhapkhoa a inner join " + user + ".xuatkhoa b on a.id=b.id";
                        else if (done.SelectedValue.ToString() == "2" || ngayvv.Enabled) s_cont = user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql ";
                        else s_cont = user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                        sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
                        sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                        sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                        sql += "case when b.makp is null then a.makp else b.makp end as makp,";
                        sql += "case when b.makp is null then h.tenkp else d.tenkp end as tenkp,";
                        sql += "b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,case when b.ketqua is null then 0 else b.ketqua end as ketqua,";
                        sql += "case when b.ttlucrv is null then 0 else b.ttlucrv end as ttlucrv";
                        if (chkKhoa.Checked && done.SelectedValue.ToString() == "0") sql+=",b.soluutru||'^' as soluutru,";
                        else if (done.SelectedValue.ToString() == "2" || ngayvv.Enabled) sql+=",b.soluutru||'^'||a.sovaovien as soluutru,";
                        else sql += ",b.soluutru||'^'||a.sovaovien as soluutru,";                        
                        sql += "a.madoituong,case when b.mabs is null then a.mabs else b.mabs end as mabs,";
                        sql += "case when b.mabs is null then i.hoten else j.hoten end as tenbs ";
                        sql += " from " + s_cont + " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                        sql += "left join " + user + ".btdkp_bv d on b.makp=d.makp ";
                        sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                        sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                        sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                        sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                        sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                        sql += "left join " + user + ".dmbs j on b.mabs=j.ma ";
                        sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                    }
                    else if (i_loaiba == 2)
                    {
                        sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
                        sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                        sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                        sql += "a.makp,h.tenkp,a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,a.ketqua,";
                        sql += "a.ttlucrv,' ^'||a.sovaovien as soluutru,a.madoituong,a.mabs,i.hoten as tenbs ";
                        sql += "from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                        sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                        sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                        sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                        sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                        sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                        sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                    }
                    else
                    {
                        nam = m.get_mabn_nam(mabn.Text);
                        sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,a.giuong,";
                        sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                        sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                        sql += "a.makp,h.tenkp,a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,a.ketqua,";
                        sql += "a.ttlucrv,a.soluutru||'^'||a.sovaovien as soluutru,a.madoituong,a.mabs,i.hoten as tenbs ";
                        sql += "from xxx.benhancc a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                        sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                        sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                        sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                        sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                        sql += "left join " + user + ".dmbs i on a.mabs=i.ma ";
                        sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                    }
                }
                DataTable tmp=(i_loaiba == 4) ? m.get_data_nam_dec(nam, sql).Tables[0] : m.get_data(sql).Tables[0];
				if (tmp.Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
					done.Focus();
					return;
				}
                if (bQuanLyPhongGiuongTuDong)//linh 04012013
                {
                    string _tungay = "", _denngay = "";
                    string[] s_ngaysudungthe = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["denngay"].ToString().Split('^');
                    _tungay = s_ngaysudungthe[0];
                    _denngay = s_ngaysudungthe[1];
                    m.TongHopTienGiuong(mabn.Text, l_mavaovien, l_maql, int.Parse(madoituong.SelectedValue.ToString()), ngayvv.Text, ngayvv.Text, ngayra.Text, _tungay, _denngay, dtvp, bThanhtoan_ndot, i_loaiba);
                }
                //Application.DoEvents();
				DataRow dr;
				string s="";
				if (madt.CheckedItems.Count==0)
				{
                    s = m.get_doituong(mabn.Text, l_maql, l_idkhoa, ngayvv.Text, ngayra.Text, (s_makp != "" || chkKhoa.Checked) ? makp.Text : "", dtkp, int.Parse(done.SelectedValue.ToString()), bVienphi_phongluu, i_loaiba, (bChiphikp_noingoai)?decimal.Parse(tmp.Rows[0]["mavaovien"].ToString()):0);
					for(int i=0;i<madt.Items.Count;i++) 
						if (s.IndexOf(dtmadt.Rows[i]["madoituong"].ToString().Trim()+",")!=-1) madt.SetItemCheckState(i,CheckState.Checked);
				}
				int tresosinh=0;
				string hotenme="";
				if (bTress_bame)
				{
                    dtss = m.get_data("select mabn from " + user + ".hcsosinh where mame='" + mabn.Text + "'").Tables[0];
					tresosinh=(dtss.Rows.Count>0)?1:0;
					if (tresosinh==0)
					{
						foreach(DataRow r in m.get_data("select a.hoten from "+user+".btdbn a,"+user+".hcsosinh b where a.mabn=b.mame and b.mabn='"+mabn.Text+"'").Tables[0].Rows)
						{
							hotenme=r["hoten"].ToString();
							break;
						}
					}
				}
                string maso = l_maql.ToString()+",",_ngayvv=ngayvv.Text;
                if (i_loaiba==1)
                {
                    _ngayvv = m.get_ngay_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                    maso += m.get_maql_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                    if (m.bBHYTngtr_noitru || bChiphikp_noingoai) maso += m.get_maql_ngoaitru(ngayvv.Text.Substring(0, 10), (ngayra.Text != "") ? ngayra.Text.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), l_mavaovien);
                    //maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
                }
                else if (i_loaiba == 2)
                {
                    maso += m.get_maql_ngoaitru(ngayvv.Text.Substring(0, 10), (ngayra.Text != "") ? ngayra.Text.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), l_mavaovien);//l_maql                    
                    maso += m.get_maql_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                }
                maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
                maso += l_mavaovien.ToString() + ",";
                //
                //}
                if (iDone == 1)
                {
                    s_idttrv = v.get_thvp_idttrv(ngayra.Text, mabn.Text, l_maql, l_idkhoa, ngayvv.Text, i_loaiba == 4);
                    if (s_idttrv.Trim().Trim(',') != "")
                    {
                        DataSet lds1 = new DataSet();
                        lds1 = v.get_sobienlai_ttrv(s_idttrv, ngayra.Text, ngayra.Text);
                        foreach (DataRow ldr3 in lds1.Tables[0].Rows)
                        {
                            if (s_quyenso.IndexOf(ldr3["quyenso"].ToString() + ",") < 0) s_quyenso += ldr3["quyenso"].ToString() + ",";
                            if (s_sobienlai.IndexOf(ldr3["sobienlai"].ToString() + ",") < 0) s_sobienlai += ldr3["sobienlai"].ToString() + ",";
                        }
                        s_sobienlai = s_sobienlai.Trim().Trim(',');
                        s_quyenso = s_quyenso.Trim().Trim(',');
                    }
                }
                else { s_idttrv = ""; s_quyenso = ""; s_sobienlai = ""; }
                //
                //
				for(int i=0;i<madt.Items.Count;i++)
				{
					#region updrec
					if (madt.GetItemChecked(i))
					{
						dr=ds.Tables[0].NewRow();
						dr["madoituongvao"]=madoituong.SelectedValue.ToString();
						dr["mabn"]=mabn.Text;
						dr["hoten"]=hoten.Text;
						dr["namsinh"]=namsinh.Text;
                        dr["ngayvao"] = tmn_thanhtoanhieudot.Checked ? ngayvv.Text : _ngayvv;//linh 16112012
						dr["ngayra"]=ngayra.Text;
						dr["madoituong"]=dtmadt.Rows[i]["madoituong"].ToString();
						dr["doituong"]=dtmadt.Rows[i]["doituong"].ToString();
						dr["sothe"]=sothe.Text;
                        dr["maphu"] = 0;// maphu.SelectedIndex;
						dr["makp"]=makp.Text;
						dr["tenkp"]=tenkp.Text;
                        dr["mavaovien"] = l_mavaovien;
						dr["maql"]=l_maql;
						dr["idkhoa"]=l_idkhoa;
						dr["phai"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["phai"].ToString();
						dr["diachi"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["diachi"].ToString();
						dr["denngay"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["denngay"].ToString();
						dr["noigioithieu"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noigioithieu"].ToString();
						dr["noicap"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["noicap"].ToString();
						dr["giuong"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["giuong"].ToString();
						dr["chandoan"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["chandoan"].ToString();
						dr["maicd"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maicd"].ToString();
						dr["nguoinha"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["nguoinha"].ToString();
						dr["hinhthuc"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["hinhthuc"].ToString();
						dr["phuongphap"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["phuongphap"].ToString();
						dr["ketqua"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ketqua"].ToString();
						dr["soluutru"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["soluutru"].ToString();
                        dr["mabs"] = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mabs"].ToString();
                        dr["tenbs"] = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenbs"].ToString();
                        dr["cholam"] = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["cholam"].ToString();
						dr["done"]=done.SelectedValue.ToString();
						dr["chon"]=true;
						dr["tresosinh"]=tresosinh;
						dr["hotenme"]=hotenme;
                        dr["maso"] = maso;
                        dr["traituyen"] = (maphu.Enabled) ? maphu.SelectedIndex.ToString() : dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["traituyen"].ToString();
                        dr["idttrv"] = s_idttrv;
                        dr["sobienlai_tt"] = s_sobienlai;
                        dr["quyenso_tt"] = s_quyenso;
						ds.Tables[0].Rows.Add(dr);
					}
					#endregion
				}
               
				d.upd_laitienthuoc(mabn.Text,l_maql,ngayvv.Text,ngayra.Text,true);
				if (tresosinh==1)
				{
					s_cont="";
					foreach(DataRow r1 in dtss.Rows)
					{
                        if (i_loaiba == 1)
                        {
                            if (done.SelectedValue.ToString() == "2" || ngayvv.Enabled) s_cont = user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql ";
                            else s_cont = user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                            sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
                            sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                            sql += "case when b.ngay is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(b.ngay,'dd/mm/yyyy hh24:mi') end as ngayra,";
                            sql += "case when b.makp is null then a.makp else b.makp end as makp,";
                            sql += "case when b.makp is null then h.tenkp else d.tenkp end as tenkp,";
                            sql += "b.chandoan,b.maicd,e.tentt,f.tenquan,g.tenpxa,case when b.ketqua is null then 0 else b.ketqua end as ketqua,";
                            sql += "case when b.ttlucrv is null then 0 else b.ttlucrv end as ttlucrv,b.soluutru,a.madoituong ";
                            sql += " from " + s_cont + " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                            sql += "left join " + user + ".btdkp_bv d on b.makp=d.makp ";
                            sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                            sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                            sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                            sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                            sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                        }
                        else
                        {
                            sql = "select c.hoten,case when c.ngaysinh is null then c.namsinh else to_char(c.ngaysinh,'dd/mm/yyyy') end as namsinh,c.phai,c.sonha,c.thon,a.mavaovien,a.maql,0 as id,' ' as giuong,";
                            sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                            sql += "case when a.ngayrv is null then to_char(now(),'dd/mm/yyyy hh24:mi') else to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') end as ngayra,";
                            sql += "a.makp,h.tenkp,a.chandoan,a.maicd,e.tentt,f.tenquan,g.tenpxa,a.ketqua,";
                            sql += "a.ttlucrv,' ' as soluutru,a.madoituong ";
                            sql += "from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                            sql += "inner join " + user + ".btdtt e on c.matt=e.matt ";
                            sql += "inner join " + user + ".btdquan f on c.maqu=f.maqu ";
                            sql += "inner join " + user + ".btdpxa g on c.maphuongxa=g.maphuongxa ";
                            sql += "inner join " + user + ".btdkp_bv h on a.makp=h.makp ";
                            sql += "where a.mabn='" + mabn.Text + "' order by a.maql desc";
                        }
						foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
						{
							s=m.get_doituong(r1["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),decimal.Parse(r["id"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString(),"",dtkp,int.Parse(done.SelectedValue.ToString()),bVienphi_phongluu,i_loaiba,(bChiphikp_noingoai)?decimal.Parse(r["mavaovien"].ToString()):0);
							for(int i=0;i<madt.Items.Count;i++) 
								if (s.IndexOf(dtmadt.Rows[i]["madoituong"].ToString().Trim()+",")!=-1) 
								{
									dr=dsss.Tables[0].NewRow();
									dr["mame"]=mabn.Text;
									dr["hotenme"]=hoten.Text;
									dr["maqlme"]=l_maql;
									dr["idkhoame"]=l_idkhoa;
                                    dr["ngayvaome"] = _ngayvv;
									dr["madoituongvao"]=r["madoituong"].ToString();
									dr["mabn"]=r1["mabn"].ToString();
									dr["hoten"]=r["hoten"].ToString();
									dr["namsinh"]=r["namsinh"].ToString();
									dr["ngayvao"]=r["ngayvao"].ToString();
									dr["ngayra"]=r["ngayra"].ToString();
									dr["ngayrame"]=ngayra.Text;
									dr["madoituong"]=dtmadt.Rows[i]["madoituong"].ToString();
									dr["doituong"]=dtmadt.Rows[i]["doituong"].ToString();
									dr["sothe"]=sothe.Text;
									dr["maphu"]=0;
									dr["makp"]=r["makp"].ToString();
									dr["makpme"]=makp.Text;
									dr["tenkp"]=r["tenkp"].ToString();
                                    dr["mavaovien"] = r["mavaovien"].ToString();
									dr["maql"]=r["maql"].ToString();
									dr["idkhoa"]=r["id"].ToString();
									dr["phai"]=(r["phai"].ToString()=="0")?"Nam":"Nữ";
                                    if (r["sonha"].ToString().Trim() != null)
                                    {
                                        dr["diachi"] += r["sonha"].ToString().Trim() + ",";// +" " + r["thon"].ToString().Trim() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString().Trim();
                                    }
                                    if (r["thon"].ToString().Trim() != null)
                                    {
                                        dr["diachi"] += r["thon"].ToString().Trim() + ",";
                                    }
                                    if (r["tenpxa"].ToString().Trim() != null)
                                    {
                                        dr["diachi"] += " " + r["tenpxa"].ToString().Trim() + ",";
                                    }
                                    if (r["tenquan"].ToString().Trim() != null)
                                    {
                                        dr["diachi"] += " " + r["tenquan"].ToString().Trim()+ ",";
                                    }
                                    if (r["tentt"].ToString().Trim() != null)
                                    {
                                        dr["diachi"] += " " + r["tentt"].ToString().Trim()+ ",";
                                    }
									dr["denngay"]="";
									dr["noigioithieu"]="";
									dr["noicap"]="";
									dr["giuong"]=r["giuong"].ToString();
									dr["chandoan"]=r["chandoan"].ToString();
									dr["maicd"]=r["maicd"].ToString();
									dr["chandoanme"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["chandoan"].ToString();
									dr["maicdme"]=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maicd"].ToString();
									dr["nguoinha"]=hoten.Text;
									dr["hinhthuc"]=2;
									dr["phuongphap"]=m.phuongphapdieutri(r["makp"].ToString());
									dr["ketqua"]=m.ketquadieutri(int.Parse(r["ketqua"].ToString()),int.Parse(r["ttlucrv"].ToString()));
									dr["soluutru"]=r["soluutru"].ToString();
									dr["done"]=done.SelectedValue.ToString();
									dr["chon"]=true;
                                    dr["maso"] = maso;
                                    dr["cholam"] = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["cholam"].ToString();
                                    dr["traituyen"] = (maphu.Enabled) ? maphu.SelectedIndex.ToString() : dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["traituyen"].ToString();
                                    dr["idttrv"] = s_idttrv;
                                    dr["sobienlai_tt"] = s_sobienlai;
                                    dr["quyenso_tt"] = s_quyenso;
									dsss.Tables[0].Rows.Add(dr);
								}
                           // DataTable tst = dsss.Tables[0];
							d.upd_laitienthuoc(r1["mabn"].ToString(),decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString(),true);
						}
					}
				}
			}
			ena_but(false);
            try { butIn.Focus(); }
            catch { }

		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_rpt="rptTtravien.rpt",title=tenkp.Text;
			if (bChitiet) s_rpt=(chkTH.Checked)?"rpt_ttravien_vp.rpt":"rpt_ttravien_kp.rpt";
            //if (ds.Tables[0].Rows.Count > 0) upd_madoituong_tu(mabn.Text);
            string tmp_mabn="";
            foreach(DataRow rtu in ds.Tables[0].Select("chon=true","mabn"))
            {
                if (tmp_mabn != rtu["mabn"].ToString())
                {
                    tmp_mabn = rtu["MABN"].ToString();
                    upd_madoituong_tu(tmp_mabn, rtu["ngayvao"].ToString(), rtu["ngayra"].ToString());
                }
            }
            //binh 070611: duyet qua tat ca doi tuong, do khi chon chuyen sl xuong vp, neu chi chon 1 dt in --> khi do sl chuyen xuong vp thieu
            try
            {
                dsxml.Tables[0].Columns.Add("mabsct",typeof(string));//gam 27/02/2012
            }
            catch { }
            dsxml = m.get_ttravien_ct(dsxml, ds.Tables[0].Select("", "mabn"), dsss.Tables[0].Select("chon=true", "mame,mabn"), dtkp, dtbd, dtvp, (s_makp != "" || chkKhoa.Checked) ? makp.Text : "", bVienphi_phongluu, i_loaiba, (chkKhoa.Visible) ? chkKhoa.Checked : false, tenuser, i_userid, bThanhtoan_ndot); 
            //
            //tan:start
            //add chenhlech
            f_add_giachenhlech(dsxml);
            //tan:end
            //
			if (dsxml.Tables[0].Rows.Count>0)
			{
                if (i_loaiba == 1)
                {
                    decimal tc;
                    foreach (DataRow r in ds.Tables[0].Select("chon=true and done=0"))
                    {
                        tc = 0;
                        foreach (DataRow r1 in dsxml.Tables[0].Select("maql=" + decimal.Parse(r["maql"].ToString())))
                            tc += decimal.Parse(r1["sotien"].ToString());
                        m.execute_data("update "+user+".xuatvien set sotien=" + tc + " where maql=" + decimal.Parse(r["maql"].ToString()));
                    }
                }
                //Tu:23/08/2011 lay len ten benh vien chuyen di khi xu tri benh nhan chuyen vien
                string s_mabv = "", s_tenbv = "", s_nhantu = "", s_tuoi = "", s_ngaysinh = "",s_tuoivao="";
                DataTable dtcv = m.get_data("select c.mabv,d.tenbv,b.ten," + int.Parse(s_ngayvao.Substring(6, 4)) + "-to_number(e.namsinh,'0000') as tuoi,e.ngaysinh,lh.tuoivao from " + user + ".benhandt a left join " + user + ".nhantu b on a.nhantu=b.ma left join " + user + ".chuyenvien c " +
                    " on a.maql = c.maql left join " + user + ".tenvien d on c.mabv=d.mabv inner join " + user + ".btdbn e on a.mabn=e.mabn left join "+user+".lienhe lh on a.maql=lh.maql where  a.maql=" + l_maql + "").Tables[0];
                foreach (DataRow row in dtcv.Rows)
                {
                    s_mabv = row["mabv"].ToString();
                    s_tenbv = row["tenbv"].ToString();
                    s_nhantu = row["ten"].ToString();
                    s_tuoi = row["tuoi"].ToString();
                    s_ngaysinh = row["ngaysinh"].ToString();
                    s_tuoivao = row["tuoivao"].ToString();
                    break;
                }
                try
                {
                    dsxml.Tables[0].Columns.Add("mabv", typeof(string));
                    dsxml.Tables[0].Columns.Add("thangtuoi", typeof(String));
                    dsxml.Tables[0].Columns.Add("tenbv", typeof(string));
                    try
                    {
                        dsxml.Tables[0].Columns.Add("tuoivao", typeof(string));
                    }
                    catch { }
                    //thêm số tháng
                    if (int.Parse(s_tuoi) <= 6 && s_ngaysinh != "")
                    {
                        long songay = m.songay(m.StringToDateTime(s_ngayvao), DateTime.Parse(s_ngaysinh), 0);
                        long sothang = songay / 30;
                        foreach (DataRow r in dsxml.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
                    }
                }
                catch { }
                foreach (DataRow row in dsxml.Tables[0].Rows)
                {
                    row["mabv"] = s_mabv;
                    row["tenbv"] = s_tenbv;
                    row["tuoivao"] = s_tuoivao;
                }
                //end Tu
                int idone = 0;
				if (chkCT.Checked)
				{
                    idone = 0;
                    if (bInravien_ravien) idone = (ds.Tables[0].Select("done=2 and chon=true").Length == 0) ? 0 : 2;
                    if (idone == 2 && !chkXem.Checked)
                    {
                        chkXem.Checked = true;
                        chkXem.Update();
                    }
					if (chkXem.Checked)
					{
                        if (chkXML.Checked)
                        {
                            if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                            dsxml.WriteXml("..//xml//ravienct.xml",XmlWriteMode.WriteSchema);
                        }
						dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,title,s_rpt,true,idone);
						f.ShowDialog();
					}
					else if (idone==0) print.Printer(m,dsxml,s_rpt,title,1);
				}
				if (chkTH.Checked)
				{
					#region tonghop
					dsth.Clear();
					dsxmlth.Clear();
					DataRow r2,r3,r4,r5,r6;
					DataRow [] dr;
					decimal tamung=0;
					foreach(DataRow r in ds.Tables[0].Select("chon=true","mabn"))
					{
						r2=m.getrowbyid(dsth.Tables[0],"mabn='"+r["mabn"].ToString()+"'");
						if (r2==null)
						{
							tamung=0;
							foreach(DataRow r7 in ds.Tables[0].Select("mabn='"+r["mabn"].ToString()+"'"))
							{
								r6=m.getrowbyid(dsxml.Tables[0],"mabn='"+r7["mabn"].ToString()+"' and tamung >0 and madoituong="+int.Parse(r7["madoituong"].ToString()));
								if (r6!=null) tamung+=decimal.Parse(r6["tamung"].ToString());
							}
							if (bTress_bame)
							{
								foreach(DataRow r7 in dsss.Tables[0].Select("mame='"+r["mabn"].ToString()+"'"))
								{
									r6=m.getrowbyid(dsxml.Tables[0],"mabn='"+r7["mabn"].ToString()+"' and madoituong="+int.Parse(r7["madoituong"].ToString()));
									if (r6!=null) tamung+=decimal.Parse(r6["tamung"].ToString());
								}
							}
                            decimal d_tyletraituyen = decimal.Parse(m.iTraituyen_bhyt.ToString());
							foreach(DataRow r1 in dsxml.Tables[0].Select("matt='"+r["mabn"].ToString()+"'","sttnhom,bntra desc"))
							{
								sql="mabn='"+r["mabn"].ToString()+"' and sttnhom="+int.Parse(r1["sttnhom"].ToString());
								r3=m.getrowbyid(dsth.Tables[0],sql);
								r5=m.getrowbyid(dtdt,"madoituong="+int.Parse(r1["madoituong"].ToString()));
                                decimal d_tylebhyttra = decimal.Parse(r1["tlchitra"].ToString());
								if (r5!=null)
								{
									if (r3==null)
									{
										r4=dsth.Tables[0].NewRow();
										r4["mabn"]=r["mabn"].ToString();
										r4["hoten"]=r["hoten"].ToString();
										r4["hotenme"]=r["hotenme"].ToString();
										r4["tenkp"]=r["tenkp"].ToString();
										r4["diachi"]=r["diachi"].ToString();
										r4["namsinh"]=r["namsinh"].ToString();
										r4["chandoan"]=r["chandoan"].ToString();
										r4["maicd"]=r["maicd"].ToString();
										r4["ngayvao"]=r["ngayvao"].ToString();
										r4["ngayra"]=r["ngayra"].ToString();
										r4["sodt"]=m.songay(m.StringToDate(r["ngayra"].ToString().Substring(0,10)),m.StringToDate(r["ngayvao"].ToString().Substring(0,10)),1).ToString();
										r4["sttnhom"]=r1["sttnhom"].ToString();
										r4["stt"]=0;r4["so"]=0;r4["c01"]="";r4["c02"]="";
										r4["c0"]="";r4["st0"]=0;r4["c1"]="";r4["st1"]=0;
										r4["tamung"]=0;r4["bhyt"]=0;r4["mien"]=0;r4["chiphi"]=0;
										r4["noidung"]=r1["nhom"].ToString().Trim()+" :";
										r4["sotien"]=0;
										if (r5["mien"].ToString()=="1" && r5["madoituong"].ToString()!="1") r4["mien"]=r1["sotien"].ToString();
                                        else if (r1["madoituong"].ToString() == "1") 
                                        {
                                            if (r1["traituyen"].ToString() == "0")
                                            {
                                                r4["bhyt"] = decimal.Parse(r1["sotien"].ToString())*(d_tylebhyttra/100);
                                                r4["sotien"] = decimal.Parse(r1["sotien"].ToString()) * ((100 - d_tylebhyttra) / 100);
                                            }
                                            else
                                            {
                                                r4["bhyt"] = decimal.Parse(r1["sotien"].ToString()) * (d_tyletraituyen / 100);
                                                r4["sotien"] = decimal.Parse(r1["sotien"].ToString()) * ((100 - d_tyletraituyen) / 100);
                                            }
                                        }
                                        else r4["sotien"] = r1["sotien"].ToString();
										r4["tamung"]=tamung;
										r4["chiphi"]=r1["sotien"].ToString();
										dsth.Tables[0].Rows.Add(r4);
									}
									else
									{
										dr=dsth.Tables[0].Select(sql);
										if (dr.Length>0)
										{
                                            if (r5["mien"].ToString() == "1" && r5["madoituong"].ToString() != "1") dr[0]["mien"] = decimal.Parse(dr[0]["mien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                            else if (r1["madoituong"].ToString() == "1")
                                            {
                                                if (r1["traituyen"].ToString() == "0")
                                                {
                                                    dr[0]["bhyt"] = decimal.Parse(dr[0]["bhyt"].ToString()) + decimal.Parse(r1["sotien"].ToString())*(d_tylebhyttra/100);
                                                    dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + (decimal.Parse(r1["sotien"].ToString()) * ((100 - d_tylebhyttra) / 100));
                                                }
                                                else
                                                {
                                                    dr[0]["bhyt"] = decimal.Parse(dr[0]["bhyt"].ToString()) + (decimal.Parse(r1["sotien"].ToString()) * (d_tyletraituyen / 100));
                                                    dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + (decimal.Parse(r1["sotien"].ToString()) * ((100 - d_tyletraituyen) / 100));
                                                }
                                            }
                                            else dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
											dr[0]["chiphi"]=decimal.Parse(dr[0]["chiphi"].ToString())+decimal.Parse(r1["sotien"].ToString());
										}
									}
								}
							}
						}
					}
					//
					int i=0,rec;
					foreach(DataRow r in ds.Tables[0].Select("chon=true","mabn"))
					{
						r2=m.getrowbyid(dsxmlth.Tables[0],"mabn='"+r["mabn"].ToString()+"'");
						if (r2==null)
						{
							dr=dsth.Tables[0].Select("mabn='"+r["mabn"].ToString()+"'","sttnhom");
							i=0;rec=dr.Length;
							while (i<rec)
							{
								r3=dsxmlth.Tables[0].NewRow();
								for(int j=0;j<dsth.Tables[0].Columns.Count;j++) r3[j]=dr[i][j].ToString();
								r3["c0"]=dr[i]["noidung"].ToString();
								r3["st0"]=dr[i]["sotien"].ToString();
								i++;
								if (i<rec)
								{
									r3["c1"]=dr[i]["noidung"].ToString();
									r3["st1"]=dr[i]["sotien"].ToString();
									r3["bhyt"]=decimal.Parse(r3["bhyt"].ToString())+decimal.Parse(dr[i]["bhyt"].ToString());
									r3["mien"]=decimal.Parse(r3["mien"].ToString())+decimal.Parse(dr[i]["mien"].ToString());
									r3["chiphi"]=decimal.Parse(r3["chiphi"].ToString())+decimal.Parse(dr[i]["chiphi"].ToString());
									i++;
								}
								dsxmlth.Tables[0].Rows.Add(r3);
							}
						}
					}
					if (chkXem.Checked)
					{
                        if (chkXML.Checked)
                        {
                            if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                            dsxmlth.WriteXml("..//xml//ravienth.xml",XmlWriteMode.WriteSchema);
                        }
                        idone = 0;
                        if (bInravien_ravien) idone = (ds.Tables[0].Select("done<>0 and chon=true").Length == 0) ? 0 : 2;
						dllReportM.frmReport f=new dllReportM.frmReport(m,dsxmlth,"","rpt_ttravienth.rpt",true,idone);
						f.ShowDialog();
					}
					else print.Printer(m,dsxmlth,"rpt_ttravienth.rpt","",1);
					//
					#endregion
				}
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			dsss.Clear();
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
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
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 35;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hotenme";
			TextCol.HeaderText = (bTress_bame)?"Họ tên mẹ":"";
			TextCol.Width = (bTress_bame)?120:0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "diachi";
			TextCol.HeaderText = (bTress_bame)?"":"Địa chỉ";
			TextCol.Width = (bTress_bame)?0:120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
	
		// Provides the format for the given cell.
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				//conditionally set properties in e depending upon e.Row and e.Col
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				//check is discontinued
				if(e.Column > 0 && !(bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
            if (pic.Visible)
            {
                string _mabn = dataGrid1[dataGrid1.CurrentCell.RowNumber, 1].ToString();
                foreach (DataRow r in d.get_data("select * from " + d.user + ".btdbn where mabn='" + _mabn + "'").Tables[0].Rows)
                {
                    try
                    {
                        image = new byte[0];
                        image = (byte[])(r["image"]);
                        memo = new MemoryStream(image);
                        map = new Bitmap(Image.FromStream(memo));
                        pic.Image = (Bitmap)map;
                    }
                    catch
                    {
                        pic.Tag = "0000.bmp";
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new Bitmap(Image.FromStream(fstr));
                        pic.Image = (Bitmap)map;
                    }
                    break;
                }
            }
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
			afterCurrentCellChanged = false;
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsss.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 35;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged1);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid2.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
			
			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hotenme";
			TextCol.HeaderText = "Họ tên mẹ";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayvao";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayra";
			TextCol.HeaderText = "Ngày ra";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat1);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}
	
		// Provides the format for the given cell.
		private void SetCellFormat1(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				//conditionally set properties in e depending upon e.Row and e.Col
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
				//check is discontinued
				if(e.Column > 0 && !(bool)(this.dataGrid2[e.Row, 0]))//discontinued)
				{
					e.ForeBrush = this.disabledTextBrush1;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush1;
					e.TextFont = this.currentRowFont1;
				}
			}
			catch{}
		}

		private void BoolValueChanged1(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow1(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow1(int row)
		{
			Rectangle rect = this.dataGrid2.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid2.Width, rect.Height);
			this.dataGrid2.Invalidate(rect);
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid2[this.dataGrid2.CurrentRowIndex, checkCol1])
				this.dataGrid2.CurrentCell = new DataGridCell(this.dataGrid2.CurrentRowIndex, checkCol1);
			afterCurrentCellChanged1 = true;
		}

		private void dataGrid2_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid2.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid2.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
			if(afterCurrentCellChanged1 && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol1 )
			{	
				this.dataGrid2[hti.Row, checkCol1] = !(bool)this.dataGrid2[hti.Row, checkCol1];
				RefreshRow1(hti.Row);
			}
			afterCurrentCellChanged1 = false;
		}

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao && ngayvao.SelectedIndex!=-1)
			{
				ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
				sothe.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
				makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
				tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
				madoituong.SelectedValue=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["madoituong"].ToString();
                l_mavaovien = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mavaovien"].ToString());
				l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
				l_idkhoa=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
                //if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(sothe.Text);
				int dd=int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(0,2));
				int mm=int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(3,2));
				int yyyy=int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(6,4));
				int hh=int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(11,2));
				int mi=int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(14,2));
                ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi,0); 
			}
		}

		private void maphu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (maphu.SelectedIndex==-1) maphu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void done_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (done.SelectedIndex==-1) done.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ngayra_Validated(object sender, System.EventArgs e)
		{
			if (ngayra.Text=="")
			{
				ngayra.Focus();
				return;
			}
			ngayra.Text=ngayra.Text.Trim();
			if (ngayra.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ !"),LibMedi.AccessData.Msg);
				ngayra.Focus();
				return;
			}
			if (!m.bNgay(ngayra.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayra.Focus();
				return;
			}
            //
			ngayra.Text=m.Ktngaygio(ngayra.Text,16);
            // 
            if (bThanhtoan_ndot)
            {
                string sql_the = "select a.sothe,to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv,a.traituyen, a.mabv from " + user + ".bhyt a left join " + user + ".dmnoicapbhyt b on a.mabv=b.mabv where a.maql=" + l_maql;
                sql_the += " and to_date(to_char(a.denngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + ngayra.Text.Substring(0, 10) + "','dd/mm/yyyy') order by to_char(a.denngay,'yyyymmdd')";                
                string s_sothe = "", s_denngay = "", s_tenbv = "";
                int traituyen = 0;
                foreach (DataRow r1 in m.get_data(sql_the).Tables[0].Rows)
                {
                    s_sothe = r1["sothe"].ToString(); s_denngay = r1["tungay"].ToString() + "^" + r1["denngay"].ToString();
                    s_tenbv = r1["tenbv"].ToString() + "^" + r1["mabv"].ToString(); 
                    //traituyen = int.Parse(r1["traituyen"].ToString());
                    traituyen = (r1["traituyen"].ToString() == "") ? 0 : int.Parse(r1["traituyen"].ToString());
                    maphu.SelectedIndex = traituyen;
                    //
                    foreach (DataRow dr0 in dsngay.Tables[0].Rows)
                    {
                        dr0["traituyen"] = maphu.SelectedIndex;
                        dr0["sothe"] = s_sothe;                        
                    }
                    dsngay.AcceptChanges();
                    //
                    break;
                }
                if (s_sothe.Trim() != "") sothe.Text = s_sothe;
                
            }
            //
		}

		private void ngayvv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chkCT_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!chkCT.Checked && !chkTH.Checked) chkTH.Checked=true;
		}

		private void chkTH_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!chkCT.Checked && !chkTH.Checked) chkCT.Checked=true;
		}

        private void chkKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkKhoa)
                ngayvv.Enabled = m.bThanhtoan_ndot || chkKhoa.Checked;
        }

        private void done_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (done.SelectedIndex== 2 && bInravien_ravien)
            {
                chkXem.Checked = true;
                chkXem.Enabled = false;
            }
            else chkXem.Enabled = true;            
        }
        private bool Capcuu_dachuyen_noitru(string smavaovien)
        {
            bool bln = false;
            sql = "select * from " + m.user + ".benhandt where mavaovien=" + smavaovien;
            DataSet lds = m.get_data(sql);
            if (lds.Tables.Count > 0)
            {
                if (lds.Tables[0].Rows.Count > 0) bln = true;
                else bln = false;
            }
            else
            {
                bln = false;
            }
            return bln;
        }

        private void upd_madoituong_tu(string mabn, string s_ngayvao, string s_ngayra)
        {
            if (mabn.Trim() == "") return;
            string s_madt = "2";
            //Thuy 25.02.2012 nếu uncheck tạm ứng gom về bhyt thì không update madoituong trong v_tamung
            if (chkbhyttamung.Checked)
            {
                s_madt = "1";
                DataRow r = m.getrowbyid(ds.Tables[0], "madoituong=" + s_madt);
                if (r == null) s_madt = ds.Tables[0].Rows[0]["madoituong"].ToString();

                sql = "update xxx.v_tamung set madoituong=" + s_madt + " where mabn='" + mabn + "'";
                if (l_mavaovien != 0) sql += " and mavaovien in(" + l_mavaovien + ")";
                else if (l_maql != 0) sql += " and maql in(" + l_maql + ")";
                m.execute_data_mmyy(sql, s_ngayvao.Substring(0, 10), s_ngayvao.Substring(0, 10), true);
            }
        }

        private void chkbhyttamung_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "gomtamung_bhyt", chkbhyttamung.Checked ? "1" : "0");
        }

        private void tmn_inkem_hangsx_Click(object sender, EventArgs e)
        {
            if (tmn_inkem_hangsx.Checked) { tmn_Inkem_nuocsx.Checked = false; tmn_inkem_hangnuocsx.Checked = false; }
            string s_inkem = tmn_inkem_hangsx.Checked ? "1" : tmn_Inkem_nuocsx.Checked ? "2" : tmn_inkem_hangnuocsx.Checked ? "3" : "0";
            m.writeXml("thongso", "ttrv_inkem", s_inkem);
            load_dmbd();
        }

        private void load_dmbd()
        {
            string s_inkem = m.Thongso("ttrv_inkem");
            string s_tenbd = (bTTRV_Intenhoatchat_Truoc) ? "case when trim(a.tenhc)!=trim(a.ten) then trim(a.tenhc||' ['||a.ten||']') else trim(a.ten) end" : "case when trim(a.tenhc)!=trim(a.ten) then trim(a.ten||' ['||a.tenhc||']') else trim(a.ten) end ";
            string s_hangnuoc = (s_inkem == "1" || s_inkem == "") ? "||' ['||trim(b.ten)||']'" : (s_inkem == "2") ? "||' ['||trim(e.ten)||']'" : (s_inkem == "3") ? "||' ['||case when b.ten=e.ten then trim(b.ten) else trim(b.ten||', '||e.ten) end||']'" : "";            
            //
            sql = "select a.id,a.ma," + s_tenbd + "||' '||trim(a.hamluong)" + s_hangnuoc + " as ten,";
            sql += "a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom,a.bhyt,a.gia_bh,a.kythuat,d.ma as manhomvp";
            if (m.bChenhlech_thuoc_dannhmuc) sql += ",a.chenhlech ";
            sql += ", a.kcct, a.bhyt as bhyt_tt, a.sothe ";
            sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d, " + user + ".d_dmnuoc e ";
            sql += " where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma and a.manuoc=e.id ";
            dtbd = m.get_data(sql).Tables[0];
        }

        private void tmn_Inkem_nuocsx_Click(object sender, EventArgs e)
        {
            if (tmn_Inkem_nuocsx.Checked) { tmn_inkem_hangsx.Checked = false; tmn_inkem_hangnuocsx.Checked = false; }
            string s_inkem = tmn_inkem_hangsx.Checked ? "1" : tmn_Inkem_nuocsx.Checked ? "2" : tmn_inkem_hangnuocsx.Checked ? "3" : "0";
            m.writeXml("thongso", "ttrv_inkem", s_inkem);
            load_dmbd();
        }

        private void tmn_inkem_hangnuocsx_Click(object sender, EventArgs e)
        {
            if (tmn_inkem_hangnuocsx.Checked) { tmn_inkem_hangsx.Checked = false; tmn_Inkem_nuocsx.Checked = false; }
            string s_inkem = tmn_inkem_hangsx.Checked ? "1" : tmn_Inkem_nuocsx.Checked ? "2" : tmn_inkem_hangnuocsx.Checked ? "3" : "0";
            m.writeXml("thongso", "ttrv_inkem", s_inkem);
            load_dmbd();
        }

        private void tmn_thanhtoanhieudot_Click(object sender, EventArgs e)
        {
            bThanhtoan_ndot = tmn_thanhtoanhieudot.Checked;
            ngayvv.Enabled = bThanhtoan_ndot || bThanhtoan_khoa;
            maphu.Enabled = bThanhtoan_ndot && sothe.Text != "" && mabn.Text != "";
            m.writeXml("thongso", "ttrv_ndot", tmn_thanhtoanhieudot.Checked ? "1" : "0");
        }

        private void tmn_motlanmotBN_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "ttrv_motlan1benhnhan", tmn_motlanmotBN.Checked ? "1" : "0");
        }

        //tan:start
        private void f_add_giachenhlech(DataSet v_ds)
        {
            try
            {
                if (v_ds.Tables[0].Columns["giachenhlech"].ToString() == "giachenhlech")
                {
                }
            }
            catch
            {
                v_ds.Tables[0].Columns.Add("giachenhlech", typeof(decimal)).DefaultValue = 0;
            }
            try
            {
                if (v_ds.Tables[0].Columns["giaban"].ToString() == "giaban")
                {
                }
            }
            catch
            {
                v_ds.Tables[0].Columns.Add("giaban", typeof(decimal)).DefaultValue = 0;
            }

            try
            {
                int aiTunguyen = m.iTunguyen;
                foreach (DataRow r in v_ds.Tables[0].Select("madoituong=1"))
                {
                    try
                    {
                        foreach (DataRow r1 in v_ds.Tables[0].Select("madoituong=" + aiTunguyen.ToString() + " and ma=" + r["ma"].ToString()))// + " and dongia<>" + r["dongia"].ToString()))
                        {
                            r["giachenhlech"] = r1["dongia"].ToString();
                            break;
                        }
                    }
                    catch
                    {
                    }
                }

                foreach (DataRow r in v_ds.Tables[0].Rows)
                {
                    r["giaban"] = decimal.Parse(r["dongia"].ToString());
                    try
                    {
                        foreach (DataRow r1 in v_ds.Tables[0].Select("madoituong=1 and ma=" + r["ma"].ToString() + " and giachenhlech>0"))
                        {
                            r["giaban"] = decimal.Parse(r1["dongia"].ToString()) + decimal.Parse(r1["giachenhlech"].ToString());
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        //tan:end

        private string f_get_maql(string m_mavaovien,decimal m_maql, int m_loaiba, string m_ngayvv, string m_ngayra)
        {
            string maso = l_maql.ToString() + ",";
            if (m_loaiba == 1)
            {
                maso += m.get_maql_Capcuu_noitru(m_ngayvv, decimal.Parse(m_mavaovien));
                if (m.bBHYTngtr_noitru || bChiphikp_noingoai) maso += m.get_maql_ngoaitru(m_ngayvv.Substring(0, 10), (m_ngayra != "") ? m_ngayra.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), decimal.Parse(m_mavaovien));//ngoai tru chuyen vao noi tru: G24 chọn hay G54: chọn
            }
            else if (m_loaiba == 2)
                maso += m.get_maql_ngoaitru(m_ngayvv.Substring(0, 10), (m_ngayra != "") ? m_ngayra.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), m_maql);
            maso += m.get_maql_Capve_noitru(m_ngayvv, decimal.Parse(m_mavaovien));
            maso += m_mavaovien.ToString() + ",";
            //
            return maso;
        }

        private void f_loaid_ttbn()
        {
            if (ngayvao.SelectedIndex != -1)
            {
                ngayra.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
                sothe.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
                makp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
                tenkp.Text = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
                madoituong.SelectedValue = dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["madoituong"].ToString();
                l_mavaovien = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["mavaovien"].ToString());
                l_maql = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
                l_idkhoa = decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["idkhoa"].ToString());
                //if (sothe.Text!="") maphu.SelectedIndex=d.get_maphu(sothe.Text);
                int dd = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(0, 2));
                int mm = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(3, 2));
                int yyyy = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(6, 4));
                int hh = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(11, 2));
                int mi = int.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayvao"].ToString().Substring(14, 2));
                ngayvv.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
            }
        }
	}
}
