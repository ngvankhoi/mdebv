using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
 
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmRavien.
	/// </summary>
	public class frmGiayravien : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
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
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtky=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataTable dtnv=new DataTable();
		private AccessData m;
        private decimal l_maql=0, l_mavaovien=0;
		private int i_userid,i_loaiba,i_maxlength_mabn = 8;
		private string s_makp,sql,s_ngayvao,user;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bTtptttkhoa;
		private int checkCol=0;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox ngayvao;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox loidan;
		private System.Windows.Forms.ComboBox kyravien;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox dieutri;
		private System.Windows.Forms.Button butList;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.TextBox timkiem;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox ngaypt;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox ptv;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tenpt;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox benhly;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox nhommau;
		private System.Windows.Forms.TextBox rh;
		private System.Windows.Forms.Label label19;
		private MaskedBox.MaskedBox ngaytk;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox taikham;
		private System.Windows.Forms.TextBox bskham;
		private System.Windows.Forms.TextBox mabskham;
		private LibList.List listNv;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.Label label22;
        private CheckBox chkMauso;
        private ComboBox kyrakhoa;
        private Label label23;
        private CheckBox chkthuthuat;
        private TextBox ttnguoibenhlucrv;
        private Label label24;
        private bool bChuathanhtoan_khongcho_ingiayravien = false, bQuanly_Theo_Chinhanh = false;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGiayravien(AccessData acc,string makp,int userid,int loaiba)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; i_userid = userid; i_loaiba = loaiba;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiayravien));
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
            this.loidan = new System.Windows.Forms.TextBox();
            this.kyravien = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.butList = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ngaypt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ptv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tenpt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.benhly = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nhommau = new System.Windows.Forms.ComboBox();
            this.rh = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ngaytk = new MaskedBox.MaskedBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.taikham = new System.Windows.Forms.TextBox();
            this.bskham = new System.Windows.Forms.TextBox();
            this.mabskham = new System.Windows.Forms.TextBox();
            this.listNv = new LibList.List();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chkMauso = new System.Windows.Forms.CheckBox();
            this.kyrakhoa = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.chkthuthuat = new System.Windows.Forms.CheckBox();
            this.ttnguoibenhlucrv = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(80, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(202, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(422, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(64, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngày vào :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(224, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ngày ra :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(398, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Khoa xuất viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(624, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(521, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Địa chỉ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(128, 5);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(72, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(251, 5);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(176, 21);
            this.hoten.TabIndex = 3;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(483, 5);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 21);
            this.namsinh.TabIndex = 5;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Enabled = false;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(288, 27);
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(104, 21);
            this.ngayra.TabIndex = 11;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(509, 27);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(117, 21);
            this.tenkp.TabIndex = 14;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(568, 5);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(216, 21);
            this.diachi.TabIndex = 7;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(672, 27);
            this.sothe.MaxLength = 16;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(112, 21);
            this.sothe.TabIndex = 16;
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(204, 539);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 50;
            this.butTiep.Text = "      &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(274, 539);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 48;
            this.butLuu.Text = "       &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(344, 539);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 49;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(484, 539);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 52;
            this.butHuy.Text = "      &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(414, 539);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 51;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExit.Image = ((System.Drawing.Image)(resources.GetObject("butExit.Image")));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(554, 539);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 53;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(483, 27);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 13;
            // 
            // ngayvao
            // 
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(128, 27);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(112, 21);
            this.ngayvao.TabIndex = 9;
            this.ngayvao.SelectedIndexChanged += new System.EventHandler(this.ngayvao_SelectedIndexChanged);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(12, 239);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(768, 272);
            this.dataGrid1.TabIndex = 112;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(401, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 23);
            this.label9.TabIndex = 21;
            this.label9.Text = "Lãnh đạo ký :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(0, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Lời dặn của thầy thuốc :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loidan
            // 
            this.loidan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loidan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loidan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loidan.Location = new System.Drawing.Point(128, 140);
            this.loidan.Name = "loidan";
            this.loidan.Size = new System.Drawing.Size(656, 21);
            this.loidan.TabIndex = 28;
            this.loidan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loidan_KeyDown);
            // 
            // kyravien
            // 
            this.kyravien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kyravien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kyravien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kyravien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kyravien.Location = new System.Drawing.Point(483, 72);
            this.kyravien.Name = "kyravien";
            this.kyravien.Size = new System.Drawing.Size(301, 21);
            this.kyravien.TabIndex = 22;
            this.kyravien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kyravien_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 23);
            this.label11.TabIndex = 23;
            this.label11.Text = "Phương pháp điều trị :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dieutri
            // 
            this.dieutri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(128, 95);
            this.dieutri.Name = "dieutri";
            this.dieutri.Size = new System.Drawing.Size(656, 21);
            this.dieutri.TabIndex = 24;
            this.dieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dieutri_KeyDown);
            // 
            // butList
            // 
            this.butList.Image = ((System.Drawing.Image)(resources.GetObject("butList.Image")));
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(660, 357);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(86, 25);
            this.butList.TabIndex = 43;
            this.butList.Text = "&Danh sách";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Visible = false;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(25, 257);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(24, 21);
            this.chkAll.TabIndex = 79;
            this.chkAll.Text = "In";
            this.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // timkiem
            // 
            this.timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Red;
            this.timkiem.Location = new System.Drawing.Point(7, 513);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(443, 21);
            this.timkiem.TabIndex = 110;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(32, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 23);
            this.label12.TabIndex = 29;
            this.label12.Text = "Bác sĩ điều trị :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(128, 164);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(184, 21);
            this.tenbs.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(312, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 23);
            this.label13.TabIndex = 31;
            this.label13.Text = "Ngày phẫu thuật :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaypt
            // 
            this.ngaypt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaypt.Enabled = false;
            this.ngaypt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaypt.Location = new System.Drawing.Point(408, 164);
            this.ngaypt.Name = "ngaypt";
            this.ngaypt.Size = new System.Drawing.Size(72, 21);
            this.ngaypt.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(473, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 23);
            this.label14.TabIndex = 33;
            this.label14.Text = "Phẫu thuật viên :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptv
            // 
            this.ptv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ptv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptv.Enabled = false;
            this.ptv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptv.Location = new System.Drawing.Point(568, 164);
            this.ptv.Name = "ptv";
            this.ptv.Size = new System.Drawing.Size(216, 21);
            this.ptv.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(-8, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 23);
            this.label15.TabIndex = 35;
            this.label15.Text = "Phương pháp phẫu thuật :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenpt
            // 
            this.tenpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenpt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpt.Enabled = false;
            this.tenpt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpt.Location = new System.Drawing.Point(128, 188);
            this.tenpt.Name = "tenpt";
            this.tenpt.Size = new System.Drawing.Size(656, 21);
            this.tenpt.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(-21, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 23);
            this.label16.TabIndex = 35;
            this.label16.Text = "Kết quả giải phẫu bệnh lý :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhly
            // 
            this.benhly.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhly.Location = new System.Drawing.Point(128, 211);
            this.benhly.Name = "benhly";
            this.benhly.Size = new System.Drawing.Size(528, 21);
            this.benhly.TabIndex = 37;
            this.benhly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loidan_KeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(568, 212);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 23);
            this.label17.TabIndex = 38;
            this.label17.Text = "Nhóm máu :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(56, 234);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 23);
            this.label18.TabIndex = 40;
            this.label18.Text = "Yếu tố Rh :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhommau
            // 
            this.nhommau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhommau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhommau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhommau.Location = new System.Drawing.Point(720, 211);
            this.nhommau.Name = "nhommau";
            this.nhommau.Size = new System.Drawing.Size(64, 21);
            this.nhommau.TabIndex = 39;
            this.nhommau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loidan_KeyDown);
            // 
            // rh
            // 
            this.rh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rh.Location = new System.Drawing.Point(128, 234);
            this.rh.Name = "rh";
            this.rh.Size = new System.Drawing.Size(80, 21);
            this.rh.TabIndex = 41;
            this.rh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loidan_KeyDown);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(192, 234);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 23);
            this.label19.TabIndex = 42;
            this.label19.Text = "Ngày tái khám :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaytk
            // 
            this.ngaytk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaytk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaytk.Location = new System.Drawing.Point(288, 234);
            this.ngaytk.Mask = "##/##/####";
            this.ngaytk.Name = "ngaytk";
            this.ngaytk.Size = new System.Drawing.Size(61, 21);
            this.ngaytk.TabIndex = 43;
            this.ngaytk.Text = "  /  /    ";
            this.ngaytk.Validated += new System.EventHandler(this.ngaytk_Validated);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(344, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 18);
            this.label20.TabIndex = 44;
            this.label20.Text = "Tái khám :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(512, 239);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 16);
            this.label21.TabIndex = 46;
            this.label21.Text = "BS khám :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taikham
            // 
            this.taikham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.taikham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taikham.Location = new System.Drawing.Point(408, 234);
            this.taikham.Name = "taikham";
            this.taikham.Size = new System.Drawing.Size(144, 21);
            this.taikham.TabIndex = 45;
            this.taikham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loidan_KeyDown);
            // 
            // bskham
            // 
            this.bskham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bskham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bskham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bskham.Location = new System.Drawing.Point(608, 234);
            this.bskham.Name = "bskham";
            this.bskham.Size = new System.Drawing.Size(176, 21);
            this.bskham.TabIndex = 47;
            this.bskham.TextChanged += new System.EventHandler(this.bskham_TextChanged);
            this.bskham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bskham_KeyDown);
            // 
            // mabskham
            // 
            this.mabskham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabskham.Enabled = false;
            this.mabskham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabskham.Location = new System.Drawing.Point(616, 248);
            this.mabskham.Name = "mabskham";
            this.mabskham.Size = new System.Drawing.Size(28, 21);
            this.mabskham.TabIndex = 129;
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(70, 558);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 297;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(128, 49);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(656, 21);
            this.chandoan.TabIndex = 18;
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(0, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(128, 23);
            this.label22.TabIndex = 17;
            this.label22.Text = "Chẩn đoán :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkMauso
            // 
            this.chkMauso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMauso.AutoSize = true;
            this.chkMauso.Location = new System.Drawing.Point(456, 517);
            this.chkMauso.Name = "chkMauso";
            this.chkMauso.Size = new System.Drawing.Size(223, 17);
            this.chkMauso.TabIndex = 298;
            this.chkMauso.Text = "Giấy ra viện ra có chứng nhận phẫu thuật";
            this.chkMauso.UseVisualStyleBackColor = true;
            // 
            // kyrakhoa
            // 
            this.kyrakhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kyrakhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kyrakhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kyrakhoa.Location = new System.Drawing.Point(128, 72);
            this.kyrakhoa.Name = "kyrakhoa";
            this.kyrakhoa.Size = new System.Drawing.Size(264, 21);
            this.kyrakhoa.TabIndex = 20;
            this.kyrakhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kyrakhoa_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(67, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 23);
            this.label23.TabIndex = 19;
            this.label23.Text = "Khoa ký :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkthuthuat
            // 
            this.chkthuthuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkthuthuat.AutoSize = true;
            this.chkthuthuat.Checked = true;
            this.chkthuthuat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkthuthuat.Location = new System.Drawing.Point(685, 517);
            this.chkthuthuat.Name = "chkthuthuat";
            this.chkthuthuat.Size = new System.Drawing.Size(95, 17);
            this.chkthuthuat.TabIndex = 299;
            this.chkthuthuat.Text = "In cả thủ thuật";
            this.chkthuthuat.UseVisualStyleBackColor = true;
            // 
            // ttnguoibenhlucrv
            // 
            this.ttnguoibenhlucrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ttnguoibenhlucrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ttnguoibenhlucrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttnguoibenhlucrv.Location = new System.Drawing.Point(128, 117);
            this.ttnguoibenhlucrv.Name = "ttnguoibenhlucrv";
            this.ttnguoibenhlucrv.Size = new System.Drawing.Size(656, 21);
            this.ttnguoibenhlucrv.TabIndex = 26;
            this.ttnguoibenhlucrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kyrakhoa_KeyDown);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(3, 111);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(124, 33);
            this.label24.TabIndex = 25;
            this.label24.Text = "Tình trạng người bệnh lúc ra viện";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmGiayravien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.ttnguoibenhlucrv);
            this.Controls.Add(this.chkthuthuat);
            this.Controls.Add(this.kyrakhoa);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.chkMauso);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.bskham);
            this.Controls.Add(this.taikham);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.ngaytk);
            this.Controls.Add(this.benhly);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.rh);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.nhommau);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.kyravien);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.ngaypt);
            this.Controls.Add(this.tenpt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ptv);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dieutri);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.loidan);
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
            this.Controls.Add(this.mabskham);
            this.Controls.Add(this.butList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiayravien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In giấy ra viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGiayravien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiayravien_Load(object sender, System.EventArgs e)
		{
			//if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            user = m.user; bTtptttkhoa = m.bTtptttkhoa;
            bChuathanhtoan_khongcho_ingiayravien = m.bChuathanhtoan_khongcho_ingiayravien;
            dtky = m.get_data("select * from " + user + ".kyravien order by stt").Tables[0];
			if (dtky.Rows.Count==0)
			{
				int i=1;
                foreach (DataRow r in m.get_data("select * from " + user + ".dmbs where nhom in (" + LibMedi.AccessData.giamdoc + ", " + LibMedi.AccessData.phogiamdoc + ") order by nhom,ma").Tables[0].Rows)
				{
					m.upd_kyravien(i,i,(int.Parse(r["nhom"].ToString())==LibMedi.AccessData.giamdoc)?"Giám đốc":"Phó giám đốc",r["hoten"].ToString());
                    /*
					try
					{
						m.upd_kyravien(i,(byte[])(r["image"]));
					}
					catch{}
                     * */
					i++;
				}
                dtky = m.get_data("select * from " + user + ".kyravien order by stt").Tables[0];
			}

            load_khoaky("");

            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			nhommau.DisplayMember="TEN";
			nhommau.ValueMember="MA";
            nhommau.DataSource = m.get_data("select * from " + user + ".dmnhommau order by ma").Tables[0];

			kyravien.DisplayMember="HOTEN";
			kyravien.ValueMember="ID";
			kyravien.DataSource=dtky;

			dsngay.ReadXml("..//..//..//xml//m_giayravien.xml");
            dsngay.Tables[0].Columns.Add("chon", typeof(bool));
            dsngay.Tables[0].Columns.Add("tuoivao", typeof(string));
            
            //
			ngayvao.DisplayMember="NGAYVAO";
			ngayvao.ValueMember="NGAYVAO";
			ngayvao.DataSource=dsngay.Tables[0];

			dsxml.ReadXml("..//..//..//xml//m_giayravien.xml");
            dsxml.Tables[0].Columns.Add("chon", typeof(bool));
            dsxml.Tables[0].Columns.Add("tuoivao", typeof(string));
            

			ds.ReadXml("..//..//..//xml//m_giayravien.xml");
            ds.Tables[0].Columns.Add("chon", typeof(bool));
            ds.Tables[0].Columns.Add("tuoivao", typeof(string));
           

			load_grid();
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
		}

        private void load_khoaky(string ma)
        {
            sql = "select * from " + user + ".dmbs where nhom in (3,4,7) ";
            if (ma != "") sql += " and makp='" + ma + "'";
            sql+=" order by makp,nhom,hoten";
            dtbs = m.get_data(sql).Tables[0];
            kyrakhoa.DisplayMember = "HOTEN";
            kyrakhoa.ValueMember = "MA";
            kyrakhoa.DataSource = dtbs;
        }

		private void load_grid()
		{
			DataRow r2;
			string tkhoa="",matkhoa="";
			l_maql=0;dsngay.Clear();
            DataSet dst = new DataSet();
            string s_dieutri = "", s_loidan = "", s_kyravien = "", s_chucvu = "", s_tenbs = "", s_ngaypt = "", s_ptv = "", s_tenpt = "", s_benhly = "", s_rh = "", s_ngaytk = "", s_taikham = "", s_mabskham = "", s_bskham = "", s_chandoan = "", s_maicd = "", s_tennhommau = "", s_vocam = "", s_noidung = "", s_ttnguoibenhlucrv="";
			int i_lanin=1,i_kyravien=0,i_nhommau=0;
            string ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
            if (i_loaiba == 1)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "b.makp,d.tenkp,e.tennn,f.dantoc||'^'||coalesce(n2.ten,' ') as dantoc,coalesce(g.tentt,' ') as tentt,";
                sql += "coalesce(h.tenquan,' ') as tenquan,coalesce(i.tenpxa,' ') as tenpxa,b.soluutru,coalesce(w.chandoan,b.chandoan) as chandoan,b.maicd,";
                sql += "j.sothe,to_char(j.tungay,'dd/mm/yyyy')||'^'||to_char(j.denngay,'dd/mm/yyyy') as denngay,x.tenbv as noigioithieu,y.tenbv as noidkkcb,c.cholam,a.sovaovien,";
                sql += "w.benhly,w.nhommau,w.rh,to_char(w.ngaytk,'dd/mm/yyyy') as ngaytk,w.taikham,w.bskham,b.mabs,dt.doituong as makpbo,tt.ten as tinhtrang,nm.ten as tennhommau,w.kyrakhoa,lh.tuoivao ";              
                sql += " from " + user + ".benhandt a inner join " + user + ".xuatvien b on a.maql=b.maql ";
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on b.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".bhyt j on a.maql=j.maql ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on j.mabv=y.mabv ";
                sql += " inner join " + user + ".giayravien w on a.maql=w.maql ";
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong ";
                sql += " left join " + user + ".nuocngoai n1 on a.mabn=n1.mabn ";
                sql += " left join " + user + ".dmquocgia n2 on n1.id_nuoc=n2.ma ";
                sql += " inner join " + user + ".ketqua tt on b.ketqua=tt.ma ";
                sql += " inner join " + user + ".dmnhommau nm on w.nhommau=nm.ma ";
                sql += " left join "+user+".lienhe lh on a.maql=lh.maql ";
                sql += " where a.loaiba in (1,2)";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and b.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " and to_char(w.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                dst = m.get_data(sql);
            }
            else if (i_loaiba == 2)
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc||'^'||coalesce(n2.ten,' ') as dantoc,coalesce(g.tentt,' ') as tentt,";
                sql += "coalesce(h.tenquan,' ') as tenquan,coalesce(i.tenpxa,' ') as tenpxa,a.soluutru,coalesce(w.chandoan,a.chandoanrv) as chandoan,a.maicdrv as maicd,";
                sql += "j.sothe,to_char(j.tungay,'dd/mm/yyyy')||'^'||to_char(j.denngay,'dd/mm/yyyy') as denngay,x.tenbv as noigioithieu,y.tenbv as noidkkcb,c.cholam,a.sovaovien,";
                sql += "w.benhly,w.nhommau,w.rh,to_char(w.ngaytk,'dd/mm/yyyy') as ngaytk,w.taikham,w.bskham,a.mabs,dt.doituong as makpbo,tt.ten as tinhtrang,nm.ten as tennhommau,w.kyrakhoa,lh.tuoivao ";
                sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".bhyt j on a.maql=j.maql ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on j.mabv=y.mabv ";
                sql += " inner join " + user + ".giayravien w on a.maql=w.maql ";
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong ";
                sql += " left join " + user + ".nuocngoai n1 on a.mabn=n1.mabn ";
                sql += " left join " + user + ".dmquocgia n2 on n1.id_nuoc=n2.ma ";
                sql += " inner join " + user + ".ketqua tt on a.ketqua=tt.ma ";
                sql += " inner join " + user + ".dmnhommau nm on w.nhommau=nm.ma ";
                sql += " left join " + user + ".lienhe lh on a.maql=lh.maql ";
                sql += " where a.maql<>0";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " and to_char(w.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                dst = m.get_data(sql);
            }
            else
            {
                sql = "select a.mabn,c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc||'^'||coalesce(n2.ten,' ') as dantoc,coalesce(g.tentt,' ') as tentt,";
                sql += "coalesce(h.tenquan,' ') as tenquan,coalesce(i.tenpxa,' ') as tenpxa,a.soluutru,coalesce(w.chandoan,a.chandoanrv) as chandoan,a.maicdrv as maicd,";
                sql += "j.sothe,to_char(j.tungay,'dd/mm/yyyy')||'^'||to_char(j.denngay,'dd/mm/yyyy') as denngay,x.tenbv as noigioithieu,y.tenbv as noidkkcb,c.cholam,a.sovaovien,";
                sql += "w.benhly,w.nhommau,w.rh,to_char(w.ngaytk,'dd/mm/yyyy') as ngaytk,w.taikham,w.bskham,a.mabs,dt.doituong as makpbo,tt.ten as tinhtrang,nm.ten as tennhommau,w.kyrakhoa,lh.tuoivao ";                
                sql += " from xxx.benhancc a ";
                sql += " inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".bhyt j on a.maql=j.maql ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on j.mabv=y.mabv ";
                sql += " inner join " + user + ".giayravien w on a.maql=w.maql ";
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong ";
                sql += " left join " + user + ".nuocngoai n1 on a.mabn=n1.mabn ";
                sql += " left join " + user + ".dmquocgia n2 on n1.id_nuoc=n2.ma ";
                sql += " inner join " + user + ".ketqua tt on a.ketqua=tt.ma ";
                sql += " inner join " + user + ".dmnhommau nm on w.nhommau=nm.ma ";
                sql += " left join xxx.lienhe lh on a.maql=lh.maql ";
                sql += " where to_char(w.ngayud,'dd/mm/yyyy')='" + ngaysrv + "'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                dst = m.get_data_mmyy(sql, m.DateToString("dd/MM/yyyy", m.StringToDate(ngaysrv).AddYears(-1)), ngaysrv, false);
            }
			foreach(DataRow r in dst.Tables[0].Rows)
			{
                s_chandoan = ""; s_maicd = ""; s_tennhommau = "";
				l_maql=decimal.Parse(r["maql"].ToString());i_lanin=0;
                foreach (DataRow r1 in m.get_data("select a.dieutri,a.loidan,a.lanin,b.chucvu,b.hoten as kyravien,b.id,a.benhly,a.nhommau,a.rh,to_char(a.ngaytk,'dd/mm/yyyy') as ngaytk,a.taikham,a.bskham,c.ten as tennhommau, ttnguoibenhlucrv from " + user + ".giayravien a," + user + ".kyravien b,"+user+".dmnhommau c where a.kyravien=b.id and a.nhommau=c.ma and a.maql=" + l_maql).Tables[0].Rows)
				{
					s_dieutri=r1["dieutri"].ToString();
					s_loidan=r1["loidan"].ToString();
					s_chucvu=r1["chucvu"].ToString();
					s_kyravien=r1["kyravien"].ToString();
					i_lanin=int.Parse(r1["lanin"].ToString())+1;
					i_kyravien=int.Parse(r1["id"].ToString());
					kyravien.SelectedValue=i_kyravien.ToString();
					s_benhly=r1["benhly"].ToString();
					s_rh=r1["rh"].ToString();
					i_nhommau=int.Parse(r1["nhommau"].ToString());
                    s_tennhommau = r1["tennhommau"].ToString();
					s_ngaytk=r1["ngaytk"].ToString();
					s_taikham=r1["taikham"].ToString();
					s_mabskham=r1["bskham"].ToString();
                    s_ttnguoibenhlucrv = r1["ttnguoibenhlucrv"].ToString();//binh 261208
					if (s_mabskham!="")
					{
						r2=m.getrowbyid(dtnv,"ma='"+s_mabskham+"'");
						if (r2!=null) s_bskham=r2["hoten"].ToString();
					}
                    s_ngaypt = s_ptv = s_tenpt = s_vocam = s_noidung = "";
                    DataSet lds = new DataSet();
                    lds = m.get_data_mmyy("select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.hoten as ptv,a.tenpt,a.noidung,c.ten as vocam from xxx.pttt a," + user + ".dmbs b," + user + ".dmmete c where a.ptv=b.ma and a.phuongphap=c.ma and a.maql=" + l_maql + " and substr(a.mapt,1,1)='P'", r["ngayvao"].ToString().Substring(0, 10), r["ngayra"].ToString().Substring(0, 10), false);
                    if (lds != null && lds.Tables.Count > 0)
                    {
                        foreach (DataRow r3 in lds.Tables[0].Rows)
                        {
                            s_ngaypt += r3["ngay"].ToString() + ";";
                            s_ptv += r3["ptv"].ToString().Trim() + ";";
                            s_tenpt += r3["tenpt"].ToString().Trim() + ";";
                            s_vocam += r3["vocam"].ToString().Trim() + ";";
                            s_noidung += r3["noidung"].ToString().Trim() + ";";
                        }
                    }
                    if (s_ngaypt != "" && bTtptttkhoa)
                    {
                        string s_ttpttt = "";
                        foreach (DataRow r3 in m.get_data("select * from " + user + ".ttptttkhoa where maql=" + l_maql).Tables[0].Rows)
                            s_ttpttt += r3["noidung"].ToString() + ";";
                        s_noidung = (s_ttpttt != "") ? s_ttpttt : s_noidung;
                    }
					break;
				}
                
                //load_khoaky(r["kyrakhoa"].ToString());///????
				tkhoa="";matkhoa="";
                if (r["kyrakhoa"].ToString() != "")
                {
                    matkhoa = r["kyrakhoa"].ToString();                    
                    r2 = m.getrowbyid(dtbs, "ma='" + matkhoa + "'");
                    if (r2 != null)
                        tkhoa = r2["hoten"].ToString();
                }
                else
                {
                    r2 = m.getrowbyid(dtbs, "makp='" + r["makp"].ToString() + "'");
                    if (r2 != null)
                    {
                        tkhoa = r2["hoten"].ToString();
                        matkhoa = r2["ma"].ToString();
                    }
                }
				r2=m.getrowbyid(dtnv,"ma='"+r["mabs"].ToString()+"'");
				if (r2!=null) s_tenbs=r2["hoten"].ToString();
				if (s_chandoan.IndexOf(r["chandoan"].ToString().Trim()+";")==-1) s_chandoan+=r["chandoan"].ToString().Trim()+";";
				if (s_maicd.IndexOf(r["maicd"].ToString().Trim()+";")==-1) s_maicd+=r["maicd"].ToString().Trim()+";";
                foreach (DataRow r1 in m.get_data("select distinct maicd,chandoan from " + user + ".cdkemtheo where maql=" + l_maql).Tables[0].Rows)
				{
					if (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim()+";")==-1) s_chandoan+=r1["chandoan"].ToString().Trim()+";";
					if (s_maicd.IndexOf(r1["maicd"].ToString().Trim()+";")==-1) s_maicd+=r1["maicd"].ToString().Trim()+";";
				}
                if (s_chandoan.Substring(s_chandoan.Length - 1, 1) == ";") s_chandoan = s_chandoan.Substring(0, s_chandoan.Length - 1);
                if (s_maicd.Substring(s_maicd.Length - 1, 1) == ";") s_maicd = s_maicd.Substring(0, s_maicd.Length - 1);
                string _ngayvv = r["ngayvao"].ToString();
                if (i_loaiba == 1)
                {
                    l_mavaovien = m.get_mavaovien(l_maql);
                    _ngayvv = m.get_ngay_Capcuu_noitru(_ngayvv, l_mavaovien);
                }
				updrec(ds,r["soluutru"].ToString(),r["mabn"].ToString(),l_maql,r["hoten"].ToString(),r["namsinh"].ToString(),r["phai"].ToString(),_ngayvv,
					r["ngayra"].ToString(),r["sothe"].ToString(),r["makp"].ToString(),r["tenkp"].ToString(),r["tennn"].ToString(),r["dantoc"].ToString(),
					r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+" "+r["tenpxa"].ToString().Trim()+" "+r["tenquan"].ToString().Trim()+
                    " "+r["tentt"].ToString().Trim(),r["cholam"].ToString(),
					r["denngay"].ToString(),s_chandoan,s_maicd,s_dieutri,s_loidan,s_chucvu,s_kyravien,i_kyravien,i_lanin,false,matkhoa,tkhoa,
                    r["noidkkcb"].ToString(),r["noigioithieu"].ToString(),r["sovaovien"].ToString(),s_tenbs,s_ngaypt,s_ptv,s_tenpt,s_benhly,i_nhommau,
                    s_rh,s_ngaytk,s_taikham,s_mabskham,s_bskham,r["makpbo"].ToString(),r["tinhtrang"].ToString(),r["tennhommau"].ToString(),s_vocam,s_noidung,
                    s_ttnguoibenhlucrv,r["tuoivao"].ToString());
			}
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			int i=0;
			DataRow r2;
			string tkhoa="",matkhoa="";emp_text(true);
            hoten.Text = ""; l_maql = 0; dsngay.Clear(); l_mavaovien = 0;
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
            if (mabn.Text.Trim().Length != 8)
            {
                if (bQuanly_Theo_Chinhanh)
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(i_maxlength_mabn-2, '0');
                }
                else
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
                }
            }
            string s_dieutri = "", s_loidan = "", s_kyravien = "", s_chucvu = "", s_tenbs = "", s_ngaypt = "", s_ptv = "", s_tenpt = "", s_chandoan = "", s_maicd = "", s_vocam = "", s_noidung = "", s_ttnguoibenhlucrv="";
			int i_lanin=1,i_kyravien=0;
			decimal o_maql;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
            DataSet dst = new DataSet();
            if (i_loaiba == 1)
            {
                sql = "select c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "b.makp,d.tenkp,e.tennn,f.dantoc||'^'||coalesce(n2.ten,' ') as dantoc,coalesce(g.tentt,' ') as tentt,";
                sql += "coalesce(h.tenquan,' ') as tenquan,coalesce(i.tenpxa,' ') as tenpxa,b.soluutru,b.chandoan,b.maicd,";
                sql += "j.sothe,to_char(j.tungay,'dd/mm/yyyy')||'^'||to_char(j.denngay,'dd/mm/yyyy') as denngay,x.tenbv as noigioithieu,";
                sql += "y.tenbv as noidkkcb,c.cholam,a.sovaovien,b.mabs,dt.doituong as makpbo,tt.ten as tinhtrang,lh.tuoivao ";
                sql += " from " + user + ".benhandt a left join " + user + ".xuatvien b on a.maql=b.maql ";
                sql += " inner join  " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on b.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".bhyt j on b.maql=j.maql ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on j.mabv=y.mabv ";
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong ";
                sql += " left join " + user + ".nuocngoai n1 on a.mabn=n1.mabn ";
                sql += " left join " + user + ".dmquocgia n2 on n1.id_nuoc=n2.ma ";
                sql += " inner join " + user + ".ketqua tt on b.ketqua=tt.ma ";
                sql += " left join "+user+".lienhe lh on a.maql=lh.maql ";
                sql += " where a.mabn='" + mabn.Text + "'";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and b.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " order by a.maql desc";
                dst = m.get_data(sql);
            }
            else if (i_loaiba == 2)
            {
                sql = "select c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc||'^'||coalesce(n2.ten,' ') as dantoc,coalesce(g.tentt,' ') as tentt,";
                sql += "coalesce(h.tenquan,' ') as tenquan,coalesce(i.tenpxa,' ') as tenpxa,a.soluutru,a.chandoanrv as chandoan,a.maicdrv as maicd,";
                sql += "j.sothe,to_char(j.tungay,'dd/mm/yyyy')||'^'||to_char(j.denngay,'dd/mm/yyyy') as denngay,x.tenbv as noigioithieu,";
                sql += "y.tenbv as noidkkcb,c.cholam,a.sovaovien,a.mabs,dt.doituong as makpbo,tt.ten as tinhtrang,lh.tuoivao ";
                sql += " from " + user + ".benhanngtr a inner join  " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".bhyt j on a.maql=j.maql ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on j.mabv=y.mabv ";
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong ";
                sql += " left join " + user + ".nuocngoai n1 on a.mabn=n1.mabn ";
                sql += " left join " + user + ".dmquocgia n2 on n1.id_nuoc=n2.ma ";
                sql += " inner join " + user + ".ketqua tt on a.ketqua=tt.ma ";
                sql += " left join " + user + ".lienhe lh on a.maql=lh.maql ";
                sql += " where a.mabn='" + mabn.Text + "' and (j.sudung is null or j.sudung=1)";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " order by a.maql desc";
                dst = m.get_data(sql);
            }
            else if (i_loaiba==4)
            {
                string nam = m.get_mabn_nam(mabn.Text);
                sql = "select c.hoten,c.namsinh,c.sonha,c.thon,c.phai,a.maql,";
                sql += "to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayra,";
                sql += "a.makp,d.tenkp,e.tennn,f.dantoc||'^'||coalesce(n2.ten,' ') as dantoc,coalesce(g.tentt,' ') as tentt,";
                sql += "coalesce(h.tenquan,' ') as tenquan,coalesce(i.tenpxa,' ') as tenpxa,a.soluutru,a.chandoanrv as chandoan,a.maicdrv as maicd,";
                sql += "j.sothe,to_char(j.tungay,'dd/mm/yyyy')||'^'||to_char(j.denngay,'dd/mm/yyyy') as denngay,x.tenbv as noigioithieu,";
                sql += "y.tenbv as noidkkcb,c.cholam,a.sovaovien,a.mabs,dt.doituong as makpbo,tt.ten as tinhtrang,lh.tuoivao ";                
                sql += " from xxx.benhancc a ";
                sql += " inner join  " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql += " inner join " + user + ".btdnn_bv e on c.mann=e.mann ";
                sql += " inner join " + user + ".btddt f on c.madantoc=f.madantoc ";
                sql += " left join " + user + ".btdtt g on c.matt=g.matt ";
                sql += " left join " + user + ".btdquan h on c.maqu=h.maqu ";
                sql += " left join " + user + ".btdpxa i on c.maphuongxa=i.maphuongxa ";
                sql += " left join " + user + ".bhyt j on a.maql=j.maql ";
                sql += " left join " + user + ".noigioithieu z on a.maql=z.maql ";
                sql += " left join " + user + ".dstt x on z.mabv=x.mabv ";
                sql += " left join " + user + ".dmnoicapbhyt y on j.mabv=y.mabv ";
                sql += " inner join " + user + ".doituong dt on a.madoituong=dt.madoituong ";
                sql += " left join " + user + ".nuocngoai n1 on a.mabn=n1.mabn ";
                sql += " left join " + user + ".dmquocgia n2 on n1.id_nuoc=n2.ma ";
                sql += " inner join " + user + ".ketqua tt on a.ketqua=tt.ma ";
                sql += " left join xxx.lienhe lh on a.maql=lh.maql ";
                sql += " where a.mabn='" + mabn.Text + "' and (j.sudung is null or j.sudung=1)";
                if (s_makp != "")
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
                sql += " order by a.maql desc";
                dst = m.get_data_nam_all_dec(nam,sql);
            }
			foreach(DataRow r in dst.Tables[0].Rows)
			{
				s_chandoan="";s_maicd="";
				o_maql=decimal.Parse(r["maql"].ToString());i_lanin=0;
				s_chandoan=r["chandoan"].ToString().Trim();                
                foreach (DataRow r1 in m.get_data("select a.dieutri,a.loidan,a.lanin,b.chucvu,b.hoten as kyravien,b.id,a.chandoan,a.benhly,a.nhommau,a.rh,to_char(a.ngaytk,'dd/mm/yyyy') as ngaytk,a.bskham,a.taikham, a.ttnguoibenhlucrv, kyrakhoa from " + user + ".giayravien a," + user + ".kyravien b where a.kyravien=b.id and a.maql=" + o_maql).Tables[0].Rows)
				{
					s_dieutri=r1["dieutri"].ToString();
					s_loidan=r1["loidan"].ToString();
					s_chucvu=r1["chucvu"].ToString();
					s_kyravien=r1["kyravien"].ToString();
					i_lanin=int.Parse(r1["lanin"].ToString())+1;
					i_kyravien=int.Parse(r1["id"].ToString());
					kyravien.SelectedValue=i_kyravien.ToString();
                    matkhoa = r1["kyrakhoa"].ToString();
					s_chandoan=r1["chandoan"].ToString().Trim();
                    mabskham.Text = r1["bskham"].ToString();                   
                    r2 = m.getrowbyid(dtnv, "ma='" + r1["bskham"].ToString() + "'");
                    if (r2 != null) bskham.Text = r2["hoten"].ToString();
                    rh.Text = r1["rh"].ToString();
                    nhommau.SelectedValue = r1["nhommau"].ToString();
                    ngaytk.Text = r1["ngaytk"].ToString();
                    taikham.Text = r1["taikham"].ToString();
                    s_ttnguoibenhlucrv = r1["ttnguoibenhlucrv"].ToString();
                    ttnguoibenhlucrv.Text = s_ttnguoibenhlucrv;
					break;
				}
				if (i==0)
				{
                    string s_pttt = (chkthuthuat.Checked==false) ? "'P'" : "'P','T'";
                    foreach (DataRow r3 in m.get_data_mmyy("select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.hoten as ptv,a.tenpt,a.noidung,c.ten as vocam from xxx.pttt a," + user + ".dmbs b," + user + ".dmmete c where a.ptv=b.ma and a.phuongphap=c.ma and a.maql=" + o_maql + " and substr(a.mapt,1,1)in(" + s_pttt + ")", r["ngayvao"].ToString().Substring(0, 10), r["ngayra"].ToString().Substring(0, 10), false).Tables[0].Rows) 
					{
						s_ngaypt+=r3["ngay"].ToString()+";";
						s_ptv+=r3["ptv"].ToString().Trim()+";";
						s_tenpt+=r3["tenpt"].ToString().Trim()+";";
                        s_vocam += r3["vocam"].ToString().Trim() + ";";
                        s_noidung += r3["noidung"].ToString().Trim() + ";";
					}
                    if (s_ngaypt != "" && bTtptttkhoa)
                    {
                        string s_ttpttt = "";
                        foreach (DataRow r3 in m.get_data("select * from " + user + ".ttptttkhoa where maql=" + o_maql).Tables[0].Rows)
                            s_ttpttt += r3["noidung"].ToString() + ";";
                        s_noidung = (s_ttpttt != "") ? s_ttpttt : s_noidung;
                    }
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					s_ngayvao=r["ngayvao"].ToString();
					ngayra.Text=r["ngayra"].ToString();
					diachi.Text=r["sonha"].ToString().Trim()+", "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim();
					makp.Text=r["makp"].ToString();
					tenkp.Text=r["tenkp"].ToString();
					loidan.Text=s_loidan;
					dieutri.Text=s_dieutri;
					l_maql=o_maql;
					sothe.Text=r["sothe"].ToString();
					r2=m.getrowbyid(dtnv,"ma='"+r["mabs"].ToString()+"'");
					if (r2!=null) s_tenbs=r2["hoten"].ToString();
					tenbs.Text=s_tenbs;
					ngaypt.Text=s_ngaypt;
					ptv.Text=s_ptv;
					tenpt.Text=s_tenpt;
					chandoan.Text=s_chandoan;
				}
                load_khoaky(makp.Text);
				tkhoa="";//matkhoa="";
                r2 = m.getrowbyid(dtbs, "ma='" + matkhoa + "'");//"makp='"+makp.Text+"'");
				if (r2!=null) 
				{
					tkhoa=r2["hoten"].ToString();
					matkhoa=r2["ma"].ToString();
                    kyrakhoa.SelectedValue = matkhoa;
				}
				s_chandoan+=";";
				s_maicd=r["maicd"].ToString().Trim()+";";
                foreach (DataRow r1 in m.get_data("select distinct maicd,chandoan from " + user + ".cdkemtheo where maql=" + l_maql).Tables[0].Rows)
				{
					if (s_chandoan.IndexOf(r1["chandoan"].ToString().Trim()+";")==-1) s_chandoan+=r1["chandoan"].ToString().Trim()+";";
					if (s_maicd.IndexOf(r1["maicd"].ToString().Trim()+";")==-1) s_maicd+=r1["maicd"].ToString().Trim()+";";
				}
                if (s_chandoan.Substring(s_chandoan.Length - 1, 1) == ";") s_chandoan = s_chandoan.Substring(0, s_chandoan.Length - 1);
                if (s_maicd.Substring(s_maicd.Length - 1, 1) == ";") s_maicd = s_maicd.Substring(0, s_maicd.Length - 1);
                string s_diachi = "";
                if (r["sonha"].ToString().Trim() != "") s_diachi += r["sonha"].ToString().Trim() + ", ";
                if (r["thon"].ToString().Trim() != "") s_diachi += r["thon"].ToString().Trim() + ", ";
                if (r["tenpxa"].ToString().Trim() != "") s_diachi += r["tenpxa"].ToString().Trim() + ", ";
                if (r["tenquan"].ToString().Trim() != "") s_diachi += r["tenquan"].ToString().Trim() + ", ";
                if (r["tentt"].ToString().Trim() != "") s_diachi += r["tentt"].ToString().Trim();
				updrec_ngay(dsngay,r["soluutru"].ToString(),mabn.Text,o_maql,hoten.Text,namsinh.Text,r["phai"].ToString(),r["ngayvao"].ToString(),
					r["ngayra"].ToString(),r["sothe"].ToString(),r["makp"].ToString(),r["tenkp"].ToString(),r["tennn"].ToString(),r["dantoc"].ToString(),
					s_diachi,r["cholam"].ToString(),
					r["denngay"].ToString(),s_chandoan.Trim(';'),s_maicd.Trim(';'),s_dieutri,s_loidan,s_chucvu,s_kyravien,i_kyravien,i_lanin,false,matkhoa,tkhoa,r["noidkkcb"].ToString(),r["noigioithieu"].ToString(),r["sovaovien"].ToString(),tenbs.Text,s_ngaypt,s_ptv,s_tenpt,r["makpbo"].ToString(),r["tinhtrang"].ToString(),s_vocam,s_noidung,s_ttnguoibenhlucrv,r["tuoivao"].ToString());
				i++;
			}
            chkMauso.Checked = tenpt.Text != "";
			if (l_maql==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa hoàn tất thủ tục !"),LibMedi.AccessData.Msg);
				mabn.Focus();
			}
			else ngayvao.SelectedValue=s_ngayvao;
		}

		private void updrec_ngay(DataSet ds,string soluutru,string mabn,decimal maql,string hoten,string namsinh,string phai,
			string ngayvao,string ngayra,string sothe,string makp,string tenkp,string tennn,string dantoc,string diachi,string cholam,
			string denngay,string chandoan,string maicd,string dieutri,string loidan,string chucvu,string kyravien,int idkyravien,int lanin,
            bool chon,string matkhoa,string truongkhoa,string noidkkcb,string noigioithieu,string sovaovien,string tenbs,string ngaypt,
            string ptv,string tenpt,string mabo,string tinhtrang,string vocam,string noidung, string ttnguoibenhlucrv,string tuoivao)
		{
			diachi=m.Caps(diachi).Replace("Không Xác Định","");
			DataRow r1=ds.Tables[0].NewRow();
			r1["sovaovien"]=sovaovien;
			r1["soluutru"]=soluutru;
			r1["mabn"]=mabn;
			r1["hoten"]=hoten;
			r1["namsinh"]=namsinh;
			r1["phai"]=(phai.Trim()=="0")?"Nam":((phai.Trim()=="Nam")?"Nam":"Nữ");
			r1["tennn"]=tennn;
			r1["dantoc"]=dantoc;
			r1["maql"]=maql;
			r1["ngayvao"]=ngayvao;
			r1["ngayra"]=ngayra;
			r1["makp"]=makp;
			r1["tenkp"]=tenkp;
			r1["sothe"]=sothe;
			r1["denngay"]=denngay;
			r1["diachi"]=diachi;
			r1["cholam"]=cholam;
			r1["chandoan"]=chandoan;
			r1["maicd"]=maicd;
			r1["dieutri"]=dieutri;
			r1["loidan"]=loidan;
			r1["chucvu"]=chucvu;
			r1["kyravien"]=kyravien;
			r1["matruongkhoa"]=matkhoa;
			r1["truongkhoa"]=truongkhoa;
			r1["idkyravien"]=idkyravien;
			r1["lanin"]=lanin;
			r1["noidkkcb"]=noidkkcb;
			r1["noigioithieu"]=noigioithieu;
			if (System.IO.File.Exists("..//..//..//chuky//"+matkhoa+".bmp"))
			{
				FileStream fstr = new FileStream("..//..//..//chuky//"+matkhoa+".bmp", FileMode.Open, FileAccess.Read);
				byte[] image = new byte[fstr.Length];
				fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
				r1["chuky"] = image;
			}
			r1["tenbs"]=tenbs;
			r1["ngaypt"]=ngaypt;
			r1["ptv"]=ptv;
			r1["tenpt"]=tenpt;
			r1["mabo"]=mabo;
			r1["chon"]=chon;
            r1["tinhtrang"] = tinhtrang;
            r1["vocam"] = vocam;
            r1["noidung"] = noidung;
            r1["ttnguoibenhlucrv"] = ttnguoibenhlucrv;
            r1["tuoivao"] = tuoivao;
			ds.Tables[0].Rows.Add(r1);
		}

		private void updrec(DataSet ds,string soluutru,string mabn,decimal maql,string hoten,string namsinh,string phai,
			string ngayvao,string ngayra,string sothe,string makp,string tenkp,string tennn,string dantoc,string diachi,string cholam,
			string denngay,string chandoan,string maicd,string dieutri,string loidan,string chucvu,string kyravien,
			int idkyravien,int lanin,bool chon,string matkhoa,string truongkhoa,string noidkkcb,string noigioithieu,
            string sovaovien,string tenbs,string ngaypt,string ptv,string tenpt,string benhly,int nhommau,string rh,
            string ngaytk,string taikham,string mabskham,string bskham,string mabo,string tinhtrang,string tennhommau,
            string vocam,string noidung,string ttnguoibenhlucrv,string tuoivao)
		{
			diachi=m.Caps(diachi).Replace("Không Xác Định","");
			DataRow r=m.getrowbyid(ds.Tables[0],"mabn='"+mabn+"'");
			if (r==null)
			{
				DataRow r1=ds.Tables[0].NewRow();
				r1["sovaovien"]=sovaovien;
				r1["soluutru"]=soluutru;
				r1["mabn"]=mabn;
				r1["hoten"]=hoten;
				r1["namsinh"]=namsinh;
				r1["phai"]=(phai.Trim()=="0")?"Nam":((phai.Trim()=="Nam")?"Nam":"Nữ");
				r1["tennn"]=tennn;
				r1["dantoc"]=dantoc;
				r1["maql"]=maql;
				r1["ngayvao"]=ngayvao;
				r1["ngayra"]=ngayra;
				r1["makp"]=makp;
				r1["tenkp"]=tenkp;
				r1["sothe"]=sothe;
				r1["denngay"]=denngay;
				r1["diachi"]=diachi;
				r1["cholam"]=cholam;
				r1["chandoan"]=chandoan;
				r1["maicd"]=maicd;
				r1["dieutri"]=dieutri;
				r1["loidan"]=loidan;
				r1["chucvu"]=chucvu;
				r1["kyravien"]=kyravien;
				r1["matruongkhoa"]=matkhoa;
				r1["truongkhoa"]=truongkhoa;
				r1["idkyravien"]=idkyravien;
				r1["lanin"]=lanin;
				r1["noidkkcb"]=noidkkcb;
				r1["noigioithieu"]=noigioithieu;
				if (System.IO.File.Exists("..//..//..//chuky//"+matkhoa+".bmp"))
				{
					FileStream fstr = new FileStream("..//..//..//chuky//"+matkhoa+".bmp", FileMode.Open, FileAccess.Read);
					byte[] image = new byte[fstr.Length];
					fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
					r1["chuky"] = image;
				}
				r1["tenbs"]=tenbs;
				r1["ngaypt"]=ngaypt;
				r1["ptv"]=ptv;
				r1["tenpt"]=tenpt;
				r1["benhly"]=benhly;
				r1["nhommau"]=nhommau;
				r1["rh"]=rh;
				r1["ngaytk"]=ngaytk;
				r1["taikham"]=taikham;
				r1["mabskham"]=mabskham;
				r1["bskham"]=bskham;
				r1["mabo"]=mabo;
				r1["chon"]=chon;
                r1["tinhtrang"] = tinhtrang;
                r1["tennhommau"] = tennhommau;
                r1["vocam"] = vocam;
                r1["noidung"] = noidung;
                r1["ttnguoibenhlucrv"] = ttnguoibenhlucrv;
                r1["tuoivao"] = tuoivao;
				try
				{
					DataRow r2=m.getrowbyid(dtky,"id="+idkyravien);
					if (r2!=null) r1["image"]=(byte[])(r2["image"]);
				}
				catch{}
				ds.Tables[0].Rows.Add(r1);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("mabn='"+mabn+"'");
				if (dr.Length>0)
				{
					dr[0]["sovaovien"]=sovaovien;
					dr[0]["soluutru"]=soluutru;
					dr[0]["mabn"]=mabn;
					dr[0]["hoten"]=hoten;
					dr[0]["namsinh"]=namsinh;
					dr[0]["phai"]=(phai.Trim()=="0")?"Nam":((phai.Trim()=="Nam")?"Nam":"Nữ");
					dr[0]["tennn"]=tennn;
					dr[0]["dantoc"]=dantoc;
					dr[0]["maql"]=maql;
					dr[0]["ngayvao"]=ngayvao;
					dr[0]["ngayra"]=ngayra;
					dr[0]["makp"]=makp;
					dr[0]["tenkp"]=tenkp;
					dr[0]["sothe"]=sothe;
					dr[0]["denngay"]=denngay;
					dr[0]["diachi"]=diachi;
					dr[0]["cholam"]=cholam;
					dr[0]["chandoan"]=chandoan;
					dr[0]["maicd"]=maicd;
					dr[0]["dieutri"]=dieutri;
					dr[0]["loidan"]=loidan;
					dr[0]["chucvu"]=chucvu;
					dr[0]["kyravien"]=kyravien;
					dr[0]["matruongkhoa"]=matkhoa;
					dr[0]["truongkhoa"]=truongkhoa;
					dr[0]["idkyravien"]=idkyravien;
					dr[0]["lanin"]=lanin;
					dr[0]["noidkkcb"]=noidkkcb;
					dr[0]["noigioithieu"]=noigioithieu;
					if (System.IO.File.Exists("..//..//..//chuky//"+matkhoa+".bmp"))
					{
						FileStream fstr = new FileStream("..//..//..//chuky//"+matkhoa+".bmp", FileMode.Open, FileAccess.Read);
						byte[] image = new byte[fstr.Length];
						fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
						dr[0]["chuky"] = image;
					}
					dr[0]["tenbs"]=tenbs;
					dr[0]["ngaypt"]=ngaypt;
					dr[0]["ptv"]=ptv;
					dr[0]["tenpt"]=tenpt;
					dr[0]["benhly"]=benhly;
					dr[0]["nhommau"]=nhommau;
					dr[0]["rh"]=rh;
					dr[0]["ngaytk"]=ngaytk;
					dr[0]["taikham"]=taikham;
					dr[0]["mabskham"]=mabskham;
					dr[0]["bskham"]=bskham;
					dr[0]["mabo"]=mabo;
					dr[0]["chon"]=chon;
                    dr[0]["tennhommau"] = tennhommau;
                    dr[0]["vocam"] = vocam;
                    dr[0]["noidung"] = noidung;
                    dr[0]["ttnguoibenhlucrv"] = ttnguoibenhlucrv;
                    dr[0]["tuoivao"] = tuoivao;
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
		}

		private void emp_text(bool skip)
		{
			if (!skip) mabn.Text="";
			hoten.Text="";namsinh.Text="";ngayra.Text="";
			tenkp.Text="";makp.Text="";sothe.Text="";diachi.Text="";
			tenbs.Text="";ngaypt.Text="";ptv.Text="";tenpt.Text="";benhly.Text="";chandoan.Text="";
			rh.Text="";ngaytk.Text="";taikham.Text="";bskham.Text="";mabskham.Text="";l_maql=0;
            loidan.Text = "";
            ttnguoibenhlucrv.Text = "";
            dieutri.Text = "";
		}
		private void butTiep_Click(object sender, System.EventArgs e)
		{
			clear();
			emp_text(false);	
			ena_but(true);
			mabn.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (kyravien.SelectedIndex==-1 && kyravien.Items.Count>0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn ký giấy ra viện !"),LibMedi.AccessData.Msg);
				kyravien.Focus();
				return;
			}
			if (hoten.Text!="")
			{
                string tkhoa = "", matkhoa = "";
                if (kyrakhoa.SelectedIndex != -1)
                {
                    tkhoa = kyrakhoa.Text; matkhoa = kyrakhoa.SelectedValue.ToString();
                }
                else
                {
                    DataRow r = m.getrowbyid(dtbs, "makp='" + makp.Text + "'");
                    if (r != null)
                    {
                        tkhoa = r["hoten"].ToString();
                        matkhoa = r["ma"].ToString();
                    }
                }
				int i=ngayvao.SelectedIndex;
                string _ngayvv = ngayvao.Text;
                if (i_loaiba == 1)
                {
                    l_mavaovien = m.get_mavaovien(l_maql);
                    _ngayvv = m.get_ngay_Capcuu_noitru(ngayvao.Text, l_mavaovien);
                }
				updrec(ds,dsngay.Tables[0].Rows[i]["soluutru"].ToString(),mabn.Text,l_maql,hoten.Text,namsinh.Text,
					dsngay.Tables[0].Rows[i]["phai"].ToString(),_ngayvv,ngayra.Text,sothe.Text,makp.Text,tenkp.Text,
					dsngay.Tables[0].Rows[i]["tennn"].ToString(),dsngay.Tables[0].Rows[i]["dantoc"].ToString(),
					dsngay.Tables[0].Rows[i]["diachi"].ToString(),dsngay.Tables[0].Rows[i]["cholam"].ToString(),dsngay.Tables[0].Rows[i]["denngay"].ToString(),
					chandoan.Text,dsngay.Tables[0].Rows[i]["maicd"].ToString(),
					dieutri.Text,loidan.Text,(kyravien.SelectedIndex!=-1)?dtky.Rows[kyravien.SelectedIndex]["chucvu"].ToString():"",kyravien.Text,
                    (kyravien.SelectedIndex!=-1)?int.Parse(kyravien.SelectedValue.ToString()):0,int.Parse(dsngay.Tables[0].Rows[i]["lanin"].ToString()),
                    true,matkhoa,tkhoa,dsngay.Tables[0].Rows[i]["noidkkcb"].ToString(),dsngay.Tables[0].Rows[i]["noigioithieu"].ToString(),
                    dsngay.Tables[0].Rows[i]["sovaovien"].ToString(),tenbs.Text,ngaypt.Text,ptv.Text,tenpt.Text,benhly.Text,
                    int.Parse(nhommau.SelectedValue.ToString()),rh.Text,ngaytk.Text,taikham.Text,mabskham.Text,bskham.Text,
                    dsngay.Tables[0].Rows[i]["mabo"].ToString(),dsngay.Tables[0].Rows[i]["tinhtrang"].ToString(),nhommau.Text,
                    dsngay.Tables[0].Rows[i]["vocam"].ToString(), dsngay.Tables[0].Rows[i]["noidung"].ToString(), ttnguoibenhlucrv.Text,dsngay.Tables[0].Rows[i]["tuoivao"].ToString());
				m.upd_giayravien(l_maql,dieutri.Text,loidan.Text,(kyravien.SelectedIndex!=-1)?int.Parse(kyravien.SelectedValue.ToString()):0,
                    i_userid,benhly.Text,int.Parse(nhommau.SelectedValue.ToString()),rh.Text,ngaytk.Text,taikham.Text,
                    mabskham.Text,chandoan.Text,(kyrakhoa.SelectedIndex!=-1)?kyrakhoa.SelectedValue.ToString():"",ttnguoibenhlucrv.Text);
			}
			ena_but(false);
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_but(false);
		}

		private void clear()
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			clear();
			dsxml.Clear();
			DataRow [] r=ds.Tables[0].Select("chon=true");
			for(int i=0;i<r.Length;i++)
			{
                //
                if (bChuathanhtoan_khongcho_ingiayravien)
                {
                    string s_chuathanhtoan = m.f_ngaychuathanhtoan(r[i]["mabn"].ToString());
                    if (s_chuathanhtoan != "")
                    {
                        MessageBox.Show(s_chuathanhtoan + "\nĐề nghị Bệnh nhân thanh toán trước khi in giấy ra viện");
                        return;
                    }
                }
                //
                 updrec(dsxml, r[i]["soluutru"].ToString(), r[i]["mabn"].ToString(), decimal.Parse(r[i]["maql"].ToString()),
                    r[i]["hoten"].ToString(), r[i]["namsinh"].ToString(), r[i]["phai"].ToString(), r[i]["ngayvao"].ToString(),
                    r[i]["ngayra"].ToString(), r[i]["sothe"].ToString(), r[i]["makp"].ToString(), r[i]["tenkp"].ToString(),
                    r[i]["tennn"].ToString(), r[i]["dantoc"].ToString(), r[i]["diachi"].ToString(), r[i]["cholam"].ToString(), r[i]["denngay"].ToString(),
                    r[i]["chandoan"].ToString(), r[i]["maicd"].ToString(), r[i]["dieutri"].ToString(), r[i]["loidan"].ToString(),
                    r[i]["chucvu"].ToString().Trim().ToUpper(), r[i]["kyravien"].ToString().Trim().ToUpper(), int.Parse(r[i]["idkyravien"].ToString()),
                    int.Parse(r[i]["lanin"].ToString()), false, r[i]["matruongkhoa"].ToString(), r[i]["truongkhoa"].ToString().ToUpper(),
                    r[i]["noidkkcb"].ToString(), r[i]["noigioithieu"].ToString(), r[i]["sovaovien"].ToString(),
                    r[i]["tenbs"].ToString(),r[i]["ngaypt"].ToString(),
                    r[i]["ptv"].ToString(), r[i]["tenpt"].ToString(),
                    r[i]["benhly"].ToString(),int.Parse(r[i]["nhommau"].ToString()),
                    r[i]["rh"].ToString(),r[i]["ngaytk"].ToString(),
                    r[i]["taikham"].ToString(),r[i]["mabskham"].ToString(),r[i]["bskham"].ToString(),
                    r[i]["mabo"].ToString(), r[i]["tinhtrang"].ToString(), r[i]["tennhommau"].ToString(), r[i]["vocam"].ToString(), r[i]["noidung"].ToString(), r[i]["ttnguoibenhlucrv"].ToString(),r[i]["tuoivao"].ToString());
                m.upd_giayravien(decimal.Parse(r[i]["maql"].ToString()), r[i]["dieutri"].ToString(), r[i]["loidan"].ToString(), int.Parse(r[i]["idkyravien"].ToString()),
                    i_userid, r[i]["benhly"].ToString(),int.Parse(r[i]["nhommau"].ToString()),r[i]["rh"].ToString(),r[i]["ngaytk"].ToString(),r[i]["taikham"].ToString(),
                    r[i]["bskham"].ToString(), r[i]["chandoan"].ToString(), r[i]["matruongkhoa"].ToString(), r[i]["ttnguoibenhlucrv"].ToString());
			}
            if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
            dsxml.WriteXml("..//xml//ingiayravien.xml", XmlWriteMode.WriteSchema);
            string tenfile = tenpt.Text.Trim() != "" ? "rptGiayravien1.rpt" : "rptGiayravien.rpt";
			if (dsxml.Tables[0].Rows.Count>0)
			{
                string s_tenbenhan = i_loaiba == 2 ? "NGOẠI TRÚ" : "";
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"GIẤY RA VIỆN "+ s_tenbenhan,tenfile,true);
				f.ShowDialog();
			}

			if(dsxml.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
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
			discontinuedCol.HeaderText = "In";
			discontinuedCol.Width = 20;
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

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 40;
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
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sothe";
			TextCol.HeaderText = "Số thẻ";
			TextCol.Width = 115;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "lanin";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;            
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "dieutri";
            TextCol.HeaderText = "Điều trị";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "loidan";
            TextCol.HeaderText = "Lời dặn";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "ngaypt";
            TextCol.HeaderText = "Ngày PT";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "tenpt";
            TextCol.HeaderText = "Phương pháp phẫu thuật";
            TextCol.Width = 150;
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
				if (int.Parse(dataGrid1[e.Row,8].ToString())>1) e.ForeBrush=new SolidBrush(Color.Blue);
				else e.ForeBrush=new SolidBrush(Color.Black);
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
                mabn.Text=dataGrid1[dataGrid1.CurrentCell.RowNumber,1].ToString();
                mabn_Validated(sender, e);
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
				makp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["makp"].ToString();
				tenkp.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["tenkp"].ToString();
				l_maql=decimal.Parse(dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["maql"].ToString());
				loidan.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["loidan"].ToString();
				dieutri.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["dieutri"].ToString();
				kyravien.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["kyravien"].ToString();
				chandoan.Text=dsngay.Tables[0].Rows[ngayvao.SelectedIndex]["chandoan"].ToString();
			}
		}

		private void kyravien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (kyravien.SelectedIndex==-1 && kyravien.Items.Count>0) kyravien.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butList_Click(object sender, System.EventArgs e)
		{
            /*
			clear();
			frmDsravien f=new frmDsravien(m,s_makp,dtbs,(kyravien.SelectedIndex!=-1)?kyravien.Text:"",(kyravien.SelectedIndex!=-1)?int.Parse(kyravien.SelectedValue.ToString()):0,dtnv);
			f.ShowDialog();
			if (f.ds.Tables[0].Rows.Count>0)
			{
				DataRow r1;
				DataRow [] r=f.ds.Tables[0].Select("chon=true");
				for(int i=0;i<r.Length;i++)
				{
					r1=m.getrowbyid(ds.Tables[0],"maql="+decimal.Parse(r[i]["maql"].ToString()));
					if (r1==null)
						updrec(ds,r[i]["soluutru"].ToString(),r[i]["mabn"].ToString(),decimal.Parse(r[i]["maql"].ToString()),
							r[i]["hoten"].ToString(),r[i]["namsinh"].ToString(),r[i]["phai"].ToString(),r[i]["ngayvao"].ToString(),
							r[i]["ngayra"].ToString(),r[i]["sothe"].ToString(),r[i]["makp"].ToString(),r[i]["tenkp"].ToString(),
							r[i]["tennn"].ToString(),r[i]["dantoc"].ToString(),r[i]["diachi"].ToString(),r[i]["cholam"].ToString(),r[i]["denngay"].ToString(),
							r[i]["chandoan"].ToString(),r[i]["maicd"].ToString(),r[i]["dieutri"].ToString(),r[i]["loidan"].ToString(),
							r[i]["chucvu"].ToString().Trim().ToUpper(),r[i]["kyravien"].ToString().Trim().ToUpper(),int.Parse(r[i]["idkyravien"].ToString()),
							int.Parse(r[i]["lanin"].ToString()),true,r[i]["matruongkhoa"].ToString(),r[i]["truongkhoa"].ToString().ToUpper(),
							r[i]["noidkkcb"].ToString(),r[i]["noigioithieu"].ToString(),r[i]["sovaovien"].ToString(),r[i]["tenbs"].ToString(),r[i]["ngaypt"].ToString(),r[i]["ptv"].ToString(),r[i]["tenpt"].ToString(),r[i]["benhly"].ToString(),int.Parse(r[i]["nhommau"].ToString()),
							r[i]["rh"].ToString(),r[i]["ngaytk"].ToString(),r[i]["taikham"].ToString(),r[i]["mabskham"].ToString(),r[i]["bskham"].ToString(),r[i]["mabo"].ToString(),r[i]["tinhtrang"].ToString());
				}
			}
             * */
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkAll)
			{
				if (timkiem.Text!="" && timkiem.Text!="Tìm kiếm")
				{
					string text=timkiem.Text;
					sql="tenkp like '%"+text.Trim()+"%'"+" or hoten like '%"+text.Trim()+"%'"+" or mabn like '%"+text.Trim()+"%'"+" or soluutru like '%"+text.Trim()+"%'"+" or sovaovien like '%"+text.Trim()+"%'"+" or chandoan like '%"+text.Trim()+"%'";
				}
				else sql="true";
				foreach(DataRow r in ds.Tables[0].Select(sql))	r["chon"]=(chkAll.Checked)?true:false;
				ds.AcceptChanges();
			}
		}

		private void dieutri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				dieutri.Text=m.Viettat(dieutri.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void loidan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				loidan.Text=m.Viettat(loidan.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void timkiem_Enter(object sender, System.EventArgs e)
		{
			timkiem.Text="";
		}

		private void timkiem_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==timkiem) RefreshChildren(timkiem.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenkp like '%"+text.Trim()+"%'"+" or hoten like '%"+text.Trim()+"%'"+" or mabn like '%"+text.Trim()+"%'"+" or soluutru like '%"+text.Trim()+"%'"+" or sovaovien like '%"+text.Trim()+"%'"+" or chandoan like '%"+text.Trim()+"%'";
			}
			catch{}
		}

		private void ngaytk_Validated(object sender, System.EventArgs e)
		{
			if (ngaytk.Text!="")
			{
				ngaytk.Text=ngaytk.Text.Trim();
				if (ngaytk.Text.Length==6) ngaytk.Text=ngaytk.Text+DateTime.Now.Year.ToString();
				if (!m.bNgay(ngaytk.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					ngaytk.Focus();
					return;
				}
			}
			else butLuu.Focus();
		}

		private void bskham_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==bskham)
			{
				Filt_dmbs(bskham.Text);
				listNv.BrowseToDanhmuc(bskham,mabskham,butLuu,35);
			}
		}

		private void bskham_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F2)
			{
				chandoan.Text=m.Viettat(chandoan.Text)+" ";
				SendKeys.Send("{END}");
			}
			else if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				SendKeys.Send("{Tab}");
			}
		}

        private void kyrakhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
        }
            
	}
}
