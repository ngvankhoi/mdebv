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
	/// Summary description for frmRavien.
	/// </summary>
	public class frmGiayxn : System.Windows.Forms.Form
	{
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
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox ngayra;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butExit;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private AccessData m;
		private decimal l_maql;
		private int i_userid,soluongle;
		private string s_makp,sql,s_ngayvao,nam,ngaysrv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
		int checkCol=0;
        private string user;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox lydo;
		private System.Windows.Forms.TextBox sotien;
        private RichTextBox thuoc;
        private ComboBox loaibn;
        private Label label36;
        private DataSet dsloaibn = new DataSet();
        private string s_mabn;
        private int i_loai;
        private CheckBox chkXml;
        private RichTextBox phuongphap;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGiayxn(AccessData acc,string makp,int userid,string _mabn,int _loai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; i_userid = userid; s_mabn = _mabn; i_loai = _loai;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiayxn));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.ngayra = new System.Windows.Forms.TextBox();
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
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.TextBox();
            this.sotien = new System.Windows.Forms.TextBox();
            this.thuoc = new System.Windows.Forms.RichTextBox();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.phuongphap = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(184, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(300, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(478, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(167, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ngày ra :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(319, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Khoa / phòng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(572, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 31;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(572, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(233, 8);
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(71, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(345, 8);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(169, 21);
            this.hoten.TabIndex = 21;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(538, 9);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(36, 21);
            this.namsinh.TabIndex = 23;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(233, 31);
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(95, 21);
            this.ngayra.TabIndex = 27;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(404, 31);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(170, 21);
            this.tenkp.TabIndex = 30;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(619, 9);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(165, 21);
            this.diachi.TabIndex = 25;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(619, 31);
            this.sothe.MaxLength = 16;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 32;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(206, 538);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 16;
            this.butTiep.Text = "    &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(276, 538);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 14;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(346, 538);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 15;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(486, 538);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 18;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(416, 538);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 17;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(556, 538);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 19;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(584, 299);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 29;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Enabled = false;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(65, 31);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(112, 21);
            this.ngayvao.TabIndex = 3;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 37);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(164, 448);
            this.dataGrid1.TabIndex = 33;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(184, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 23);
            this.label9.TabIndex = 34;
            this.label9.Text = "- Lý do vào viện :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(184, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 23);
            this.label10.TabIndex = 35;
            this.label10.Text = "- Phương pháp điều trị :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(184, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 23);
            this.label12.TabIndex = 37;
            this.label12.Text = "- Thuốc đã dùng :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(180, 510);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 23);
            this.label13.TabIndex = 38;
            this.label13.Text = "- Số tiền đã nộp :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(303, 55);
            this.lydo.Multiline = true;
            this.lydo.Name = "lydo";
            this.lydo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lydo.Size = new System.Drawing.Size(480, 51);
            this.lydo.TabIndex = 4;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(303, 512);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(481, 21);
            this.sotien.TabIndex = 7;
            this.sotien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // thuoc
            // 
            this.thuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(303, 229);
            this.thuoc.Name = "thuoc";
            this.thuoc.Size = new System.Drawing.Size(482, 281);
            this.thuoc.TabIndex = 6;
            this.thuoc.Text = "";
            // 
            // loaibn
            // 
            this.loaibn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Enabled = false;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.Location = new System.Drawing.Point(65, 8);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(111, 21);
            this.loaibn.TabIndex = 0;
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label36.Location = new System.Drawing.Point(-6, 6);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 23);
            this.label36.TabIndex = 72;
            this.label36.Text = "Người bệnh :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXml
            // 
            this.chkXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(1, 545);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 73;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // phuongphap
            // 
            this.phuongphap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phuongphap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phuongphap.Enabled = false;
            this.phuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phuongphap.Location = new System.Drawing.Point(303, 107);
            this.phuongphap.Name = "phuongphap";
            this.phuongphap.Size = new System.Drawing.Size(482, 121);
            this.phuongphap.TabIndex = 5;
            this.phuongphap.Text = "";
            // 
            // frmGiayxn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.phuongphap);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.loaibn);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiayxn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In giấy xác nhận";
            this.Load += new System.EventHandler(this.frmGiayxn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiayxn_Load(object sender, System.EventArgs e)
		{
            if (s_mabn == "") this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            user = m.user;
            dsloaibn.ReadXml("..//..//..//xml//m_loaibn.xml");
            m.delrec(dsloaibn.Tables[0], "id=4");
			dsngay.ReadXml("..//..//..//xml//m_giaycv.xml");
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];
			dsxml.ReadXml("..//..//..//xml//m_giaycv.xml");
            dsxml.Tables[0].Columns.Add("loaibn", typeof(decimal));
            dsxml.Tables[0].Columns.Add("lanin", typeof(decimal));
			ds.ReadXml("..//..//..//xml//m_giaycv.xml");
			ds.Tables[0].Columns.Add("chon",typeof(bool));
            ds.Tables[0].Columns.Add("loaibn", typeof(decimal));
            ds.Tables[0].Columns.Add("lanin", typeof(decimal));
            dsngay.Tables[0].Columns.Add("loaibn", typeof(decimal));
            dsngay.Tables[0].Columns.Add("lanin", typeof(decimal));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));//SystemColors.Info
			//this.disabledTextBrush = new SolidBrush(SystemColors.GrayText);
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));

            loaibn.DisplayMember = "TEN";
            loaibn.ValueMember = "ID";
            loaibn.DataSource = dsloaibn.Tables[0];
            soluongle = d.d_soluong_le(m.nhom_duoc);
            nam = m.mmyy(ngaysrv) + "+";
            if (s_mabn != "")
            {
                loaibn.SelectedIndex = i_loai;
                load_data("", 3,0);
            }
            else for (int i = 0; i < 4; i++) load_data("", i,0);
		}

        private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			hoten.Text="";dsngay.Clear();
			l_maql=0;
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
            nam = "";
            if (loaibn.SelectedIndex > 1)
            {
                foreach (DataRow r in m.get_data("select nam from " + user + ".btdbn where mabn='" + mabn.Text + "'").Tables[0].Rows)
                    nam = r["nam"].ToString().Trim();
            }
            if (loaibn.SelectedIndex > 1 && nam == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                return;
            }
            load_data(mabn.Text,loaibn.SelectedIndex,0);
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			else ngayvao.SelectedValue=s_ngayvao;
		}

        private void load_data(string ma,int loai,decimal maql)
        {
            string s = "";
            string s_chandoan = "", s_maicd = "";
            if (loai == 0)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,'' as tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "b.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,b.chandoan,b.maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "a.sovaovien,date(to_char(b.ngay,'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+1 as ngaydt, ";
                sql += "j.lydo,phuongphap,j.thuoc,j.sotien,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,j.lanin";
                sql += " from " + user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on b.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".giayxacnhan j on b.maql=j.maql ";
                sql += " left join " + user + ".bhyt l on b.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on b.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " where a.loaiba=1";
                if (s_makp != "")
                {
                    s = s_makp.Replace(",", "','");
                    sql += " and b.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                sql += " order by a.maql desc";
            }
            else if (loai == 1)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,'' as tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,a.chandoanrv as chandoan,a.maicdrv as maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "a.sovaovien,date(to_char(a.ngayrv,'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+1 as ngaydt, ";
                sql += "j.lydo,j.phuongphap,j.thuoc,j.sotien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngay,j.lanin";
                sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".giayxacnhan j on a.maql=j.maql ";
                sql += " left join " + user + ".bhyt l on a.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " where true";
                if (s_makp != "")
                {
                    s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                sql += " order by a.maql desc";
            }
            else if (loai == 2)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,'' as tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,a.chandoanrv as chandoan,a.maicdrv as maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "a.sovaovien,date(to_char(a.ngayrv,'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+1 as ngaydt, ";
                sql += "j.lydo,j.phuongphap,j.thuoc,j.sotien,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngay,j.lanin";
                sql += " from xxx.benhancc a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".giayxacnhan j on a.maql=j.maql ";
                sql += " left join xxx.bhyt l on a.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " where true";
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                sql += " order by a.maql desc";
            }
            else
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,c.cholam,'' as tenbv,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayvao,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc,g.tentt,l.sothe,to_char(l.denngay,'dd/mm/yyyy') as denngay,gg.hoten as tenbs,hh.doituong,";
                sql += "h.tenquan,i.tenpxa,a.chandoan as chandoan,a.maicd,";
                sql += "x.tenbv as noigioithieu,y.tenbv as noidkkcb,";
                sql += "a.sovaovien,date(to_char(a.ngay,'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+1 as ngaydt, ";
                sql += "j.lydo,j.phuongphap,j.thuoc,j.sotien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,j.lanin";
                sql += " from xxx.benhanpk a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".giayxacnhan j on a.maql=j.maql ";
                sql += " left join xxx.bhyt l on a.maql=l.maql ";
                sql += " left join " + user + ".dmbs gg on a.mabs=gg.ma ";
                sql += " inner join " + user + ".doituong hh on a.madoituong=hh.madoituong ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on l.mabv=y.mabv ";
                sql += " where true";
                if (s_makp != "")
                {
                    s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                if (ma != "") sql += " and a.mabn='" + ma + "'";
                else sql += " and to_char(j.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (maql != 0) sql += " and j.maql=" + maql;
                sql += "  order by a.maql desc";
            }
            foreach (DataRow r in (nam != "") ? m.get_data_nam_dec(nam, sql).Tables[0].Rows : m.get_data(sql).Tables[0].Rows)
            {
                l_maql = decimal.Parse(r["maql"].ToString());
                mabn.Text = r["mabn"].ToString();
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                s_ngayvao = r["ngayvao"].ToString();
                ngayra.Text = r["ngayra"].ToString();
                diachi.Text = r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + " ," + r["tenpxa"].ToString().Trim() + " ," + r["tenquan"].ToString().Trim() + " ," + r["tentt"].ToString().Trim();
                makp.Text = r["makp"].ToString();
                tenkp.Text = r["tenkp"].ToString();
                sothe.Text = r["sothe"].ToString();
                phuongphap.Text = r["phuongphap"].ToString();
                thuoc.Text = r["thuoc"].ToString();
                if (thuoc.Text == "" && loaibn.SelectedIndex == 0) getThuoc(s_ngayvao);
                getSotien(s_ngayvao);
                //sotien.Text = r["sotien"].ToString();
                lydo.Text = r["lydo"].ToString();
                updrec(dsngay, r["doituong"].ToString(), mabn.Text, hoten.Text, namsinh.Text, r["phai"].ToString(), r["ngayvao"].ToString(),
                    r["ngayra"].ToString(), r["sothe"].ToString(), r["denngay"].ToString(), tenkp.Text, r["tennn"].ToString(), r["dantoc"].ToString(),
                    r["sonha"].ToString().Trim() + " " + r["thon"].ToString().Trim() + " ," + r["tenpxa"].ToString().Trim() + " ," + r["tenquan"].ToString().Trim() + " ," + r["tentt"].ToString().Trim(),
                    r["cholam"].ToString(), s_chandoan, s_maicd, r["tenbs"].ToString(), r["tenbv"].ToString(), r["noidkkcb"].ToString(), r["noigioithieu"].ToString(),
                    "", r["phuongphap"].ToString(), r["thuoc"].ToString(), r["sotien"].ToString(), r["lydo"].ToString(),
                    "", "","", l_maql, false,loai, 1);
                if (ma == "")
                {
                    int i = ngayvao.SelectedIndex;
                    updrec(ds, dsngay.Tables[0].Rows[i]["doituong"].ToString(), mabn.Text, hoten.Text, namsinh.Text,
                        dsngay.Tables[0].Rows[i]["phai"].ToString(), ngayvao.Text, ngayra.Text, sothe.Text, dsngay.Tables[0].Rows[i]["denngay"].ToString(), tenkp.Text,
                        dsngay.Tables[0].Rows[i]["tennn"].ToString(), dsngay.Tables[0].Rows[i]["dantoc"].ToString(),
                        dsngay.Tables[0].Rows[i]["diachi"].ToString(), dsngay.Tables[0].Rows[i]["noilamviec"].ToString(),
                        dsngay.Tables[0].Rows[i]["chandoan"].ToString(), dsngay.Tables[0].Rows[i]["maicd"].ToString(),
                        dsngay.Tables[0].Rows[i]["tenbs"].ToString(), dsngay.Tables[0].Rows[i]["tenbv"].ToString(), dsngay.Tables[0].Rows[i]["noidkkcb"].ToString(), dsngay.Tables[0].Rows[i]["noigioithieu"].ToString(),
                        "", phuongphap.Text, thuoc.Text, sotien.Text, lydo.Text, "", "", "", l_maql, true, int.Parse(dsngay.Tables[0].Rows[i]["loaibn"].ToString()), 1);
                }
            }
        }

        private void getSotien(string _ngayvao)
        {
            sql = "select b.sotien+b.bhyt as sotien from xxx.v_ttrvds a,xxx.v_ttrvll b ";
            sql += " where a.id=b.id ";
            sql += " and a.maql=" + l_maql;
            DataSet tmp = m.get_data_mmyy(sql, _ngayvao.Substring(0, 10), ngayra.Text.Substring(0, 10), true);
            decimal st = 0;
            foreach (DataRow r in tmp.Tables[0].Rows)
                st += decimal.Parse(r["sotien"].ToString());
            sotien.Text = st.ToString("###,###,###,###.00");
        }

		private void getThuoc(string _ngayvao)
		{
			sql="select b.mabd,trim(d.ten)||' '||d.hamluong as tenbd,d.dang,trunc(sum(b.slyeucau),"+soluongle+") as soluong ";
			sql+=" from xxx.d_dutrull a,xxx.d_dutruct b,xxx.d_duyet c,"+user+".d_dmbd d,"+user+".d_dmnhom e ";
            sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and d.manhom=e.id and e.nhomin in (1,2,3,4)";
			sql+=" and a.maql="+l_maql;
			sql+=" group by b.mabd,trim(d.ten)||' '||d.hamluong,d.dang";
            DataSet tmp = m.get_data_mmyy(sql, _ngayvao.Substring(0, 10), ngayra.Text.Substring(0, 10), true);
			sql=" select b.mabd,trim(d.ten)||' '||d.hamluong as tenbd,d.dang,trunc(sum(b.slyeucau),"+soluongle+") as soluong ";
			sql+=" from xxx.d_xtutrucll a,xxx.d_xtutrucct b,xxx.d_duyet c,"+user+".d_dmbd d,"+user+".d_dmnhom e ";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and d.manhom=e.id and e.nhomin in (1,2,3,4)";
			sql+=" and a.maql="+l_maql;
			sql+=" group by b.mabd,trim(d.ten)||' '||d.hamluong,d.dang";
			DataRow r1,r2;
			DataRow [] dr;
            foreach (DataRow r in m.get_data_mmyy(sql,_ngayvao.Substring(0,10), ngayra.Text.Substring(0,10), true).Tables[0].Rows)
			{
				r1=m.getrowbyid(tmp.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=tmp.Tables[0].NewRow();
					r2["mabd"]=r["mabd"].ToString();
					r2["tenbd"]=r["tenbd"].ToString();
					r2["dang"]=r["dang"].ToString();
					r2["soluong"]=r["soluong"].ToString();
					tmp.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=tmp.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			string s="";
			foreach(DataRow r in tmp.Tables[0].Rows)
				s+=r["tenbd"].ToString().Trim()+" "+r["soluong"].ToString().Trim()+" "+r["dang"].ToString()+";\n";
			thuoc.Text=s;
		}

		private void updrec(DataSet ds,string doituong,string mabn,string hoten,string namsinh,string phai,
			string ngayvao,string ngayra,string sothe,string denngay,string tenkp,string tennn,string dantoc,string diachi,
			string cholam,string chandoan,string maicd,string tenbs,string tenbv,string noidkkcb,string noigioithieu,
			string lamsang,string xn,string thuoc,string tinhtrang,string lydo,string ngay,string vanchuyen,string nguoidua,
			decimal maql,bool chon,int loaibn,int lanin)
		{
            DataRow r = m.getrowbyid(ds.Tables[0], "maql=" + maql);
            if (r == null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["maql"] = maql;
                dr["mabn"] = mabn;
                dr["hoten"] = hoten;
                dr["namsinh"] = namsinh;
                dr["phai"] = (phai.Trim() == "0") ? "Nam" : ((phai.Trim() == "Nam") ? "Nam" : "Nữ");
                dr["tennn"] = tennn;
                dr["dantoc"] = dantoc;
                dr["ngayvao"] = ngayvao;
                dr["ngayra"] = ngayra;
                dr["tenkp"] = tenkp;
                dr["doituong"] = doituong;
                dr["sothe"] = sothe;
                dr["denngay"] = denngay;
                dr["noilamviec"] = cholam;
                dr["diachi"] = diachi;
                dr["chandoan"] = chandoan;
                dr["maicd"] = maicd;
                dr["tenbs"] = tenbs;
                dr["tenbv"] = tenbv;
                dr["noidkkcb"] = noidkkcb;
                dr["noigioithieu"] = noigioithieu;
                dr["lamsang"] = lamsang;
                dr["xn"] = xn;
                dr["thuoc"] = thuoc;
                dr["tinhtrang"] = tinhtrang;
                dr["lydo"] = lydo;
                dr["ngay"] = ngay;
                dr["vanchuyen"] = vanchuyen;
                dr["nguoidua"] = nguoidua;
                if (chon) dr["chon"] = chon;
                dr["loaibn"] = loaibn;
                dr["lanin"] = lanin;
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                DataRow[] dr1 = ds.Tables[0].Select("maql=" + maql);
                if (dr1.Length > 0)
                {
                    dr1[0]["maql"] = maql;
                    dr1[0]["mabn"] = mabn;
                    dr1[0]["hoten"] = hoten;
                    dr1[0]["namsinh"] = namsinh;
                    dr1[0]["phai"] = (phai.Trim() == "0") ? "Nam" : ((phai.Trim() == "Nam") ? "Nam" : "Nữ");
                    dr1[0]["tennn"] = tennn;
                    dr1[0]["dantoc"] = dantoc;
                    dr1[0]["ngayvao"] = ngayvao;
                    dr1[0]["ngayra"] = ngayra;
                    dr1[0]["tenkp"] = tenkp;
                    dr1[0]["doituong"] = doituong;
                    dr1[0]["sothe"] = sothe;
                    dr1[0]["denngay"] = denngay;
                    dr1[0]["noilamviec"] = cholam;
                    dr1[0]["diachi"] = diachi;
                    dr1[0]["chandoan"] = chandoan;
                    dr1[0]["maicd"] = maicd;
                    dr1[0]["tenbs"] = tenbs;
                    dr1[0]["tenbv"] = tenbv;
                    dr1[0]["noidkkcb"] = noidkkcb;
                    dr1[0]["noigioithieu"] = noigioithieu;
                    dr1[0]["lamsang"] = lamsang;
                    dr1[0]["xn"] = xn;
                    dr1[0]["thuoc"] = thuoc;
                    dr1[0]["tinhtrang"] = tinhtrang;
                    dr1[0]["lydo"] = lydo;
                    dr1[0]["ngay"] = ngay;
                    dr1[0]["vanchuyen"] = vanchuyen;
                    dr1[0]["nguoidua"] = nguoidua;
                    if (chon) dr1[0]["chon"] = chon;
                    dr1[0]["loaibn"] = loaibn;
                    dr1[0]["lanin"] = lanin;
                }
            }
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_but(bool ena)
		{
			mabn.Enabled=ena;
			ngayvao.Enabled=ena;
			phuongphap.Enabled=ena;
            loaibn.Enabled = ena;
			thuoc.Enabled=ena;
			sotien.Enabled=ena;
			lydo.Enabled=ena;
			butTiep.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butExit.Enabled=!ena;
		}

        private void emp_text()
        {
            mabn.Text = ""; hoten.Text = ""; namsinh.Text = "";
            ngayra.Text = ""; tenkp.Text = ""; makp.Text = "";
            sothe.Text = ""; diachi.Text = ""; phuongphap.Text = ""; thuoc.Text = "";
            sotien.Text = ""; lydo.Text = ""; 
            l_maql = 0;
            ena_but(true);
        }

		private void butTiep_Click(object sender, System.EventArgs e)
		{
            emp_text();
            if (s_mabn != "")
            {
                loaibn.SelectedIndex = i_loai;
                mabn.Text = s_mabn;
                mabn_Validated(sender, e);
                ngayvao.Focus();
            }
			else loaibn.Focus();
		}

		private bool kiemtra()
		{
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text!="")
			{
				int i=ngayvao.SelectedIndex;
				updrec(ds,dsngay.Tables[0].Rows[i]["doituong"].ToString(),mabn.Text,hoten.Text,namsinh.Text,
					dsngay.Tables[0].Rows[i]["phai"].ToString(),ngayvao.Text,ngayra.Text,sothe.Text,dsngay.Tables[0].Rows[i]["denngay"].ToString(),tenkp.Text,
					dsngay.Tables[0].Rows[i]["tennn"].ToString(),dsngay.Tables[0].Rows[i]["dantoc"].ToString(),
					dsngay.Tables[0].Rows[i]["diachi"].ToString(),dsngay.Tables[0].Rows[i]["noilamviec"].ToString(),
					dsngay.Tables[0].Rows[i]["chandoan"].ToString(),dsngay.Tables[0].Rows[i]["maicd"].ToString(),
					dsngay.Tables[0].Rows[i]["tenbs"].ToString(),dsngay.Tables[0].Rows[i]["tenbv"].ToString(),dsngay.Tables[0].Rows[i]["noidkkcb"].ToString(),dsngay.Tables[0].Rows[i]["noigioithieu"].ToString(),
					"",phuongphap.Text,thuoc.Text,sotien.Text,lydo.Text,"","","",l_maql,true,int.Parse(dsngay.Tables[0].Rows[i]["loaibn"].ToString()),1);
				m.upd_giayxacnhan(mabn.Text,l_maql,lydo.Text,phuongphap.Text,thuoc.Text,(sotien.Text!="")?decimal.Parse(sotien.Text):0,i_userid);
			}
			ena_but(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			dsxml.Clear();
			DataRow [] r=ds.Tables[0].Select("chon=true");
            int lanin = 0;
            string _sovaovien, chandoanv, chandoanr,chandoank,tenpt,ngaypt,tentt,ngaytt;
            decimal _mavaovien, ngaydt;
			for(int i=0;i<r.Length;i++)
			{
                foreach (DataRow r1 in m.get_data("select * from " + user + ".giayxacnhan where maql=" + decimal.Parse(r[i]["maql"].ToString())).Tables[0].Rows)
                    lanin = int.Parse(r1["lanin"].ToString());                
                _sovaovien=chandoanv=chandoanr=chandoank=tenpt=ngaypt=tentt=ngaytt="";
                _mavaovien=ngaydt=0;
                sql = "select a.mavaovien,a.sovaovien,date(to_char(b.ngay,'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+1 as ngaydt, ";
                sql += "a.chandoan as chandoanv,b.chandoan as chandoanr";
                sql += " from " + user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                sql += " where a.maql="+decimal.Parse(r[i]["maql"].ToString());
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                {
                    _mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                    ngaydt = decimal.Parse(r1["ngaydt"].ToString());
                    chandoanv = r1["chandoanv"].ToString();
                    chandoanr = r1["chandoanr"].ToString();
                    _sovaovien = r1["sovaovien"].ToString();
                }
                if (_mavaovien != 0)
                {
                    sql = "select tenpt,mapt,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.pttt where mavaovien=" + _mavaovien;
                    foreach (DataRow r1 in m.get_data_mmyy(sql, r[i]["ngayvao"].ToString().Substring(0, 10), r[i]["ngayra"].ToString().Substring(0, 10), false).Tables[0].Rows)
                    {
                        if (r1["mapt"].ToString().Substring(0, 1) == "P")
                        {
                            tenpt += r1["tenpt"].ToString().Trim() + ",";
                            ngaypt += r1["ngay"].ToString().Trim() + ",";
                        }
                        else
                        {
                            tentt += r1["tenpt"].ToString().Trim() + ",";
                            ngaytt += r1["ngay"].ToString().Trim() + ",";
                        }
                    }
                    foreach (DataRow r1 in m.get_data("select chandoan from " + user + m.mmyy(r[i]["ngayvao"].ToString()) + ".benhanpk where mavaovien=" + _mavaovien).Tables[0].Rows)
                        chandoank = r1["chandoan"].ToString();
                }
				updrec(dsxml,r[i]["doituong"].ToString(),r[i]["mabn"].ToString(),r[i]["hoten"].ToString(),r[i]["namsinh"].ToString(),r[i]["phai"].ToString(),r[i]["ngayvao"].ToString(),
					r[i]["ngayra"].ToString(),r[i]["sothe"].ToString(),r[i]["denngay"].ToString(),r[i]["tenkp"].ToString(),r[i]["tennn"].ToString(),r[i]["dantoc"].ToString(),r[i]["diachi"].ToString(),r[i]["noilamviec"].ToString(),
					chandoank,r[i]["maicd"].ToString(),r[i]["tenbs"].ToString(),_sovaovien,chandoanv,chandoanr,tenpt,r[i]["xn"].ToString(),
					r[i]["thuoc"].ToString(),r[i]["tinhtrang"].ToString(),r[i]["lydo"].ToString(),ngaypt,tentt,
					ngaytt,decimal.Parse(r[i]["maql"].ToString()),false,Int16.Parse(ngaydt.ToString()),lanin);
				m.execute_data("update "+user+".giayxacnhan set lanin=lanin+1 where maql="+decimal.Parse(r[i]["maql"].ToString()));
			}
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                dsxml.WriteXml("..//xml//giayxn.xml", XmlWriteMode.WriteSchema);
            }
			if (dsxml.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"GIẤY XÁC NHẬN","rptGiayxn.rpt",true);
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
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
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
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
					//				e.BackBrush = this.disabledBackBrush;
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
            try
            {
                //if (butTiep.Enabled)
                //{                    
                    emp_text();
                    int irow = dataGrid1.CurrentCell.RowNumber;
                    DataRow r = m.getrowbyid(ds.Tables[0], "mabn='" + dataGrid1[irow, 1].ToString() + "'");
                    if (r != null)
                    {
                        loaibn.SelectedIndex = int.Parse(r["loaibn"].ToString());
                        mabn.Text = r["mabn"].ToString();
                        l_maql = decimal.Parse(r["maql"].ToString());
                        load_data(mabn.Text,loaibn.SelectedIndex, l_maql);
                    }
                //}
            }
            catch { }
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

		private void ngayvao_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ngayvao && ngayvao.SelectedIndex!=-1)
			{
				ngayra.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["ngayra"].ToString();
				sothe.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["sothe"].ToString();
				//makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
				tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
				l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
			}
		}
	}
}
