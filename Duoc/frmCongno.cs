using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmCongno.
	/// </summary>
	public class frmCongno : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
       // lan.Read_Language_to_Xml(this.Name.ToString(),this);
	//	lan.Changelanguage_to_English(this.Name.ToString(),this);
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.TextBox sophieu;
		private System.Windows.Forms.TextBox sohd;
		private System.Windows.Forms.TextBox madv;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butTonghop;
		private int i_nhom,i_userd;
        private string s_mmyy, sql, s_ngay, format_sotien, s_no = "", s_co = "", s_makho = "", s_sophieu = "", user, stime;
		private AccessData d;
		private DataSet ds=new DataSet();
		private DataSet dsct=new DataSet();
		private DataSet dsxml=new DataSet();
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bChitra_ndot;
		private int checkCol=0,i_makho;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tongcong;
		private System.Windows.Forms.TextBox datra;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox conlai;
		private System.Windows.Forms.Label label8;
		private decimal l_id=0;
		private decimal d_tongcong,d_datra,d_sotien;
		private System.Windows.Forms.Button butKiemtra;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox so;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.TextBox no;
		private System.Windows.Forms.TextBox co;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox sotien;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butInct;
        private TextBox danhdau;
        private Label label16;
        private DateTimePicker ngayct;
        private Label label17;
        private CheckBox chkTraNhacc;
        private CheckBox chkSeeAll;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCongno(AccessData acc,string mmyy,int nhom,int userid,string ngay,string makho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
           // Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        lan.Read_Language_to_Xml(this.Name.ToString(),this);
		lan.Changelanguage_to_English(this.Name.ToString(),this);
			d=acc;s_mmyy=mmyy;i_nhom=nhom;i_userd=userid;s_ngay=ngay;s_makho=makho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongno));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.sophieu = new System.Windows.Forms.TextBox();
            this.sohd = new System.Windows.Forms.TextBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butTonghop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tongcong = new System.Windows.Forms.TextBox();
            this.datra = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.conlai = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butKiemtra = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label9 = new System.Windows.Forms.Label();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.so = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.no = new System.Windows.Forms.TextBox();
            this.co = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.sotien = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.butThem = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butInct = new System.Windows.Forms.Button();
            this.danhdau = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ngayct = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.chkTraNhacc = new System.Windows.Forms.CheckBox();
            this.chkSeeAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tử ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(133, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(225, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Số phiếu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(373, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Số hóa đơn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(533, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Nhà cung cấp :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(55, 3);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.Value = new System.DateTime(2005, 5, 26, 11, 8, 30, 30);
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(165, 3);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // sophieu
            // 
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(298, 3);
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(80, 21);
            this.sophieu.TabIndex = 16;
            this.sophieu.TextChanged += new System.EventHandler(this.sophieu_TextChanged);
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // sohd
            // 
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(445, 3);
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(100, 21);
            this.sohd.TabIndex = 17;
            this.sohd.TextChanged += new System.EventHandler(this.sohd_TextChanged);
            this.sohd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // madv
            // 
            this.madv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(623, 3);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(160, 21);
            this.madv.TabIndex = 18;
            this.madv.TextChanged += new System.EventHandler(this.madv_TextChanged);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 7);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(776, 316);
            this.dataGrid1.TabIndex = 24;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(372, 539);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 14;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(442, 539);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "   &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(512, 539);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 19;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butTonghop
            // 
            this.butTonghop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTonghop.Image = ((System.Drawing.Image)(resources.GetObject("butTonghop.Image")));
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(302, 539);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(70, 25);
            this.butTonghop.TabIndex = 4;
            this.butTonghop.Text = "     &Xem";
            this.butTonghop.Click += new System.EventHandler(this.butTonghop_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(-25, 512);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "T.cộng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tongcong
            // 
            this.tongcong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tongcong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tongcong.Enabled = false;
            this.tongcong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tongcong.Location = new System.Drawing.Point(44, 512);
            this.tongcong.Name = "tongcong";
            this.tongcong.Size = new System.Drawing.Size(160, 23);
            this.tongcong.TabIndex = 34;
            this.tongcong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // datra
            // 
            this.datra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.datra.Enabled = false;
            this.datra.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datra.Location = new System.Drawing.Point(280, 512);
            this.datra.Name = "datra";
            this.datra.Size = new System.Drawing.Size(127, 23);
            this.datra.TabIndex = 36;
            this.datra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(233, 512);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "Đã  :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // conlai
            // 
            this.conlai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.conlai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.conlai.Enabled = false;
            this.conlai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conlai.Location = new System.Drawing.Point(445, 512);
            this.conlai.Name = "conlai";
            this.conlai.Size = new System.Drawing.Size(124, 23);
            this.conlai.TabIndex = 38;
            this.conlai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(399, 512);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 23);
            this.label8.TabIndex = 37;
            this.label8.Text = "Chưa :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKiemtra
            // 
            this.butKiemtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKiemtra.Image = ((System.Drawing.Image)(resources.GetObject("butKiemtra.Image")));
            this.butKiemtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKiemtra.Location = new System.Drawing.Point(232, 539);
            this.butKiemtra.Name = "butKiemtra";
            this.butKiemtra.Size = new System.Drawing.Size(70, 25);
            this.butKiemtra.TabIndex = 39;
            this.butKiemtra.Text = "&Kiểm tra";
            this.butKiemtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKiemtra.Click += new System.EventHandler(this.butKiemtra_Click);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.Location = new System.Drawing.Point(728, 544);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(88, 16);
            this.chkAll.TabIndex = 40;
            this.chkAll.Text = "In tất cả";
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.Red;
            this.dataGrid2.CaptionText = "Hóa đơn";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 328);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 5;
            this.dataGrid2.Size = new System.Drawing.Size(776, 128);
            this.dataGrid2.TabIndex = 25;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(7, 466);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "Đợt :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(44, 466);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(48, 21);
            this.stt.TabIndex = 4;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(86, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Số :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // so
            // 
            this.so.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.so.BackColor = System.Drawing.SystemColors.HighlightText;
            this.so.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.so.Location = new System.Drawing.Point(116, 466);
            this.so.Name = "so";
            this.so.Size = new System.Drawing.Size(88, 21);
            this.so.TabIndex = 5;
            this.so.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(197, 466);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 23);
            this.label11.TabIndex = 28;
            this.label11.Text = "Ngày đề nghị :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(280, 466);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 6;
            this.ngay.Value = new System.DateTime(2009, 8, 29, 0, 0, 0, 0);
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // no
            // 
            this.no.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(392, 466);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(88, 21);
            this.no.TabIndex = 7;
            this.no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // co
            // 
            this.co.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co.Location = new System.Drawing.Point(504, 466);
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(65, 21);
            this.co.TabIndex = 8;
            this.co.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(360, 466);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 29;
            this.label12.Text = "Nợ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(472, 466);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 30;
            this.label13.Text = "Có :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Location = new System.Drawing.Point(588, 466);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 23);
            this.label14.TabIndex = 31;
            this.label14.Text = "Số tiền :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(630, 466);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(94, 21);
            this.sotien.TabIndex = 9;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sotien.Validated += new System.EventHandler(this.sotien_Validated);
            this.sotien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            this.sotien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sotien_KeyPress);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(-17, 489);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 32;
            this.label15.Text = "Ghi chú :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(44, 489);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(525, 21);
            this.ghichu.TabIndex = 10;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(723, 466);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(69, 21);
            this.butThem.TabIndex = 12;
            this.butThem.Text = "&Chi trả";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(723, 490);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(69, 21);
            this.butHuy.TabIndex = 13;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butInct
            // 
            this.butInct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butInct.Image = ((System.Drawing.Image)(resources.GetObject("butInct.Image")));
            this.butInct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInct.Location = new System.Drawing.Point(723, 514);
            this.butInct.Name = "butInct";
            this.butInct.Size = new System.Drawing.Size(69, 21);
            this.butInct.TabIndex = 41;
            this.butInct.Text = "    In";
            this.butInct.Click += new System.EventHandler(this.butInct_Click);
            // 
            // danhdau
            // 
            this.danhdau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.danhdau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.danhdau.Enabled = false;
            this.danhdau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.danhdau.Location = new System.Drawing.Point(630, 512);
            this.danhdau.Name = "danhdau";
            this.danhdau.Size = new System.Drawing.Size(94, 23);
            this.danhdau.TabIndex = 43;
            this.danhdau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Location = new System.Drawing.Point(570, 512);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 23);
            this.label16.TabIndex = 42;
            this.label16.Text = "Đánh dấu :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayct
            // 
            this.ngayct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ngayct.CustomFormat = "dd/MM/yyyy";
            this.ngayct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayct.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayct.Location = new System.Drawing.Point(630, 489);
            this.ngayct.Name = "ngayct";
            this.ngayct.Size = new System.Drawing.Size(94, 21);
            this.ngayct.TabIndex = 11;
            this.ngayct.Value = new System.DateTime(2009, 8, 29, 0, 0, 0, 0);
            this.ngayct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Location = new System.Drawing.Point(560, 489);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 23);
            this.label17.TabIndex = 45;
            this.label17.Text = "Ngày chi trả :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTraNhacc
            // 
            this.chkTraNhacc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTraNhacc.Location = new System.Drawing.Point(4, 544);
            this.chkTraNhacc.Name = "chkTraNhacc";
            this.chkTraNhacc.Size = new System.Drawing.Size(200, 17);
            this.chkTraNhacc.TabIndex = 46;
            this.chkTraNhacc.Text = "Tính cả phiếu trả nhà cung cấp";
            this.chkTraNhacc.Click += new System.EventHandler(this.chkTraNhacc_Click);
            // 
            // chkSeeAll
            // 
            this.chkSeeAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSeeAll.Location = new System.Drawing.Point(623, 544);
            this.chkSeeAll.Name = "chkSeeAll";
            this.chkSeeAll.Size = new System.Drawing.Size(88, 16);
            this.chkSeeAll.TabIndex = 47;
            this.chkSeeAll.Text = "Hiện tất cả";
            this.chkSeeAll.CheckedChanged += new System.EventHandler(this.chkSeeAll_CheckedChanged);
            // 
            // frmCongno
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkSeeAll);
            this.Controls.Add(this.chkTraNhacc);
            this.Controls.Add(this.ngayct);
            this.Controls.Add(this.danhdau);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.conlai);
            this.Controls.Add(this.datra);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tongcong);
            this.Controls.Add(this.butInct);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.no);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.co);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.so);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.butKiemtra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCongno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công nợ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCongno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCongno_Load(object sender, System.EventArgs e)
		{
			//if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; stime = "'" + d.f_ngay + "'";
            f_capnhat_db(s_ngay, s_ngay);
            chkTraNhacc.Checked = d.Thongso("congno_tranhacc") == "1";
            bChitra_ndot = d.bChitra_ndot(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			tu.Value=new DateTime(2000+int.Parse(s_mmyy.Substring(2,2)),int.Parse(s_mmyy.Substring(0,2)),1,0,0,0);
			den.Value=new DateTime(int.Parse(s_ngay.Substring(6,4)),int.Parse(s_ngay.Substring(3,2)),int.Parse(s_ngay.Substring(0,2)),0,0,0);
			butKiemtra_Click(sender,e);
			ds.ReadXml("..\\..\\..\\xml\\d_thanhtoan.xml");
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
            ds.Tables[0].Columns.Add("prn", typeof(bool));
            ds.Tables[0].Columns.Add("ghichu");
            ds.Tables[0].Columns.Add("makho",typeof(decimal));
            ds.Tables[0].Columns.Add("sotiennovat", typeof(decimal)).DefaultValue = 0;
			load_grid();
			AddGridTableStyle();
						
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));		
			AddGridTableStyle1();
            sotien.Enabled = bChitra_ndot;
		}

		private void load_grid()
		{
			ds.Clear();
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="",xxx;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						sql="select a.id,a.sophieu,to_char(a.ngaysp,'dd/mm/yyyy') as ngaysp,a.sohd,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhd,";
						sql +="c.ten as madv,coalesce(b.no,a.no) as no,coalesce(b.co,a.co) as co,b.sotien,b.datra,' ' as ghichu,a.makho, b.sotiennovat";
                        sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_thanhtoan b," + user + ".d_dmnx c";
                        sql += " where a.id=b.id and a.madv=c.id and a.loai='M' and a.nhom=" + i_nhom;
                        sql += " and " + d.for_ngay("a.ngaysp", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
						if (s_makho!="") sql+=" and a.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
                        if (!chkSeeAll.Checked)
                        {
                            sql += " and b.sotien<>0 ";
                        }
                        //sql += " union all ";
                        //sql += "select a.id,a.sophieu,to_char(a.ngay,'dd/mm/yyyy') as ngaysp,a.sophieu as sohd,to_char(a.ngay,'dd/mm/yyyy') as ngayhd,";
                        //sql += "c.ten as madv,' ' as no,' ' as co,b.sotien,b.datra,' ' as ghichu,a.khox as makho, b.sotiennovat";
                        //sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_thanhtoan b," + user + ".d_dmnx c";
                        //sql += " where a.id=b.id and a.idduyet=c.id and a.loai='XK' and a.khon=0 and b.sotien<>0 and a.nhom=" + i_nhom;
                        //sql += " and " + d.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                        //if (s_makho != "") sql += " and a.khox in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
                        //sql += " order by sophieu,sohd";

                        foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                            updrec_congno(ds.Tables[0], mmyy, decimal.Parse(r["id"].ToString()), r["sophieu"].ToString(), r["ngaysp"].ToString(), r["sohd"].ToString(), r["ngayhd"].ToString(), r["madv"].ToString(), r["no"].ToString(), r["co"].ToString(), decimal.Parse(r["sotien"].ToString()), decimal.Parse(r["datra"].ToString()), r["ghichu"].ToString(), int.Parse(r["makho"].ToString()), decimal.Parse(r["sotiennovat"].ToString()));

					}
				}
			}
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			tinh_giatri("true");
			load_gridct(l_id,s_mmyy);
		}

        private void updrec_congno(DataTable dt, string mmyy, decimal id, string sophieu, string ngaysp, string sohd, string ngayhd, string madv,
            string no, string co, decimal sotien, decimal datra, string ghichu,int makho, decimal sotiennovat)
        {
            string exp = "id=" + id;
            DataRow r = d.getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["mmyy"] = mmyy;
                nrow["id"] = id;
                nrow["sophieu"] = sophieu;
                nrow["ngaysp"] = ngaysp;
                nrow["sohd"] = sohd;
                nrow["ngayhd"] = ngayhd;
                nrow["madv"] = madv;
                nrow["no"] = no;
                nrow["co"] = co;
                nrow["sotien"] = sotien;
                nrow["datra"] = datra;
                nrow["ghichu"] = ghichu;
                nrow["chon"] = datra != 0;
                nrow["prn"] = false;
                nrow["makho"] = makho;
                nrow["sotiennovat"] = sotiennovat;
                dt.Rows.Add(nrow);
            }
        }

		private void load_gridct(decimal id,string mmyy)
		{
			sql="select id,stt,so,to_char(ngay,'dd/mm/yyyy') as ngay,no,co,sotien,ghichu,to_char(ngayct,'dd/mm/yyyy') as ngayct from "+user+mmyy+".d_thanhtoanct where id="+id+" order by stt";
			dsct=d.get_data(sql);
			dataGrid2.DataSource=dsct.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid2.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			ref_text();
		}

		private void tinh_giatri(string sql)
		{
            decimal zdanhdau = 0;
            string sql1 = "";
            //if (sql != "") sql1 = sql + " and ";
            sql1 += "chon=true and datra=0";
            foreach (DataRow r in ds.Tables[0].Select(sql1)) zdanhdau += decimal.Parse(r["sotien"].ToString());
            danhdau.Text = zdanhdau.ToString(format_sotien);
            dsxml.Clear();
            d_tongcong = 0; d_datra = 0;
            foreach (DataRow r in ds.Tables[0].Select(sql))
            {
                d_tongcong += decimal.Parse(r["sotien"].ToString());
                d_datra += decimal.Parse(r["datra"].ToString());
            }
            decimal d_conlai = d_tongcong - d_datra;
            tongcong.Text = d_tongcong.ToString(format_sotien);
            datra.Text = d_datra.ToString(format_sotien);
            conlai.Text = d_conlai.ToString(format_sotien);
            sql = "true";
            if (!chkAll.Checked) sql = " datra=0";
            dsxml.Merge(ds.Tables[0].Select(sql));
		}


		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsct.Tables[0].TableName;
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
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Đợt";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "so";
			TextCol.HeaderText = "Số CT";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Đề nghị";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "no";
			TextCol.HeaderText = "TK Nợ";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "co";
			TextCol.HeaderText = "TK Có";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.Format=format_sotien;
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngayct";
            TextCol.HeaderText = "Chi trả";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);			

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ghichu";
			TextCol.HeaderText = "Ghi chú";
			TextCol.Width = dataGrid2.Width-(20+10+30+60+80+80+80+80+80);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);			
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
			ts.RowHeaderWidth=5;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "";
			discontinuedCol.Width = 0;
			discontinuedCol.AllowNull = false;

			//discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			//discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

            discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "prn";
            discontinuedCol.HeaderText = "In";
            discontinuedCol.Width = 30;
            discontinuedCol.AllowNull = false;

            //discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            //discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "sophieu";
			TextCol.HeaderText = "Số phiếu";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngaysp";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sohd";
			TextCol.HeaderText = "Số hóa đơn";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ngayhd";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 65;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "madv";
			TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width =180;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "no";
			TextCol.HeaderText = "Nợ";
			TextCol.Width =50;
			TextCol.ReadOnly=false;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "co";
			TextCol.HeaderText = "Có";
			TextCol.Width =50;
			TextCol.ReadOnly=false;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width =90;
			TextCol.ReadOnly=true;
			TextCol.Format="### ### ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "datra";
			TextCol.HeaderText = "Đã trả";
			TextCol.Width =90;
			TextCol.ReadOnly=false;
			TextCol.Format="### ### ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ghichu";
			TextCol.HeaderText = "Ghi chú";
			TextCol.Width =200;
			TextCol.ReadOnly=false;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width =0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "mmyy";
			TextCol.HeaderText = "";
			TextCol.Width =0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "makho";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "sotiennovat";
            TextCol.HeaderText = "Số tiền trước VAT";
            TextCol.Width = 100;
            TextCol.ReadOnly = false;
            TextCol.Format = "### ### ### ###";
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))	e.ForeBrush = this.disabledTextBrush;
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
            //if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
            //    this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
            //afterCurrentCellChanged = true;
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i,12].ToString());
				s_mmyy=dataGrid1[i,13].ToString();
				s_sophieu=dataGrid1[i,2].ToString();
				s_no=dataGrid1[i,7].ToString();
				s_co=dataGrid1[i,8].ToString();
				d_sotien=decimal.Parse(dataGrid1[i,9].ToString());
                d_sotien=decimal.Parse(d_sotien.ToString(format_sotien));
				dataGrid2.CaptionText=dataGrid1[i,6].ToString().Trim()+", Số hóa đơn :"+dataGrid1[i,4].ToString().Trim()+", ngày :"+dataGrid1[i,5].ToString().Trim();
                i_makho = int.Parse(dataGrid1[i, 14].ToString());
				load_gridct(l_id,s_mmyy);
			}
			catch{}
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

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void sophieu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==sophieu) ref_grid();
		}

		private void sohd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==sohd) ref_grid();
		}

		private void madv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==madv) ref_grid();
		}

		private void ref_grid()
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			sql="";
			if (sophieu.Text!="")
			{
				if (sql!="") sql+=" and ";
				sql+=" sophieu like '%"+sophieu.Text+"%'";
			}
			if (sohd.Text!="")
			{
				if (sql!="") sql+=" and ";
				sql+=" sohd like '%"+sohd.Text+"%'";
			}
			if (madv.Text!="")
			{
				if (sql!="") sql+=" and ";
				sql+=" madv like '%"+madv.Text+"%'";
			}
			dv.RowFilter=sql;
			tinh_giatri(sql);
		}

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
			butKiemtra_Click(sender,e);
			load_grid();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
			ds.AcceptChanges();
            string xxx = "";
			foreach(DataRow r in ds.Tables[0].Rows)
			{
                xxx = user + r["mmyy"].ToString();
				if (r["chon"].ToString().Trim().ToLower()=="true")
				{
					d.upd_thanhtoan(r["mmyy"].ToString(),decimal.Parse(r["id"].ToString()),s_ngay,r["no"].ToString(),r["co"].ToString(),decimal.Parse(r["datra"].ToString()),i_userd);
					d.execute_data("update "+xxx+".d_nhapll set paid=1 where id="+decimal.Parse(r["id"].ToString()));
				}
				else 
				{
					d.execute_data("update "+xxx+".d_thanhtoan set datra=0 where id="+decimal.Parse(r["id"].ToString()));
					d.execute_data("update "+xxx+".d_nhapll set paid=0 where id="+decimal.Parse(r["id"].ToString()));
				}
			}
			load_grid();
			butIn.Focus();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			try
			{				
				if (dsxml.Tables[0].Rows.Count==0)
				{
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
					return;
				}
                DataSet dsr = new DataSet();
                dsr = dsxml.Copy();
                if (ds.Tables[0].Select("prn=true").Length>0)
                {
                    dsr.Clear();
                    foreach (DataRow r in ds.Tables[0].Select("prn=true"))
                        dsr.Tables[0].Rows.Add(r.ItemArray);
                }
                if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
                dsr.WriteXml("..\\..\\dataxml\\congno.xml", XmlWriteMode.WriteSchema); 
				frmReport f=new frmReport(d,dsr.Tables[0], i_userd,"d_congno_ct.rpt","CÔNG NỢ",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"","","","","","","","");
				f.ShowDialog(this);
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();System.GC.Collect();this.Close();
		}

		private void butKiemtra_Click(object sender, System.EventArgs e)
		{
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="",xxx;
            decimal id = 0;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						sql="select a.id,sum(b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu) as sotien, sum(b.sotien) as sotiennovat ";
                        sql += " from "+xxx+".d_nhapll a,"+xxx+".d_nhapct b where a.id=b.id and a.nhom="+i_nhom+" and a.loai='M'";
						sql += " group by a.id ";
                        if (chkTraNhacc.Checked)
                        {
                            sql += " union all ";
                            sql += " select a.id,sum(-1*b.soluong*t.giamua) as sotien, sum(-1*b.soluong*t.gianovat) as sotiennovat  from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + xxx + ".d_theodoi t";
                            sql += " where a.id=b.id and b.sttt=t.id and a.loai='XK' and a.khon=0 and a.idduyet<>0";
                            sql += " group by a.id";
                        }
						foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
						{
							d.execute_data("update "+xxx+".d_thanhtoan set sotien=0, sotiennovat=0 where id="+decimal.Parse(r["id"].ToString()));
                            d.upd_thanhtoan(mmyy, decimal.Parse(r["id"].ToString()), decimal.Parse(r["sotien"].ToString()), decimal.Parse(r["sotiennovat"].ToString()));
						}
					}
				}
			}
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkAll) tinh_giatri("true");
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void ref_text()
		{
			emp_text();
			try
			{
				DataRow r=d.getrowbyid(dsct.Tables[0],"stt="+decimal.Parse(dataGrid2[dataGrid2.CurrentCell.RowNumber,0].ToString()));
				if (r!=null)
				{
					stt.Value=decimal.Parse(r["stt"].ToString());
					so.Text=r["so"].ToString();
					ngay.Value=new DateTime(int.Parse(r["ngay"].ToString().Substring(6,4)),int.Parse(r["ngay"].ToString().Substring(3,2)),int.Parse(r["ngay"].ToString().Substring(0,2)),0,0,0,0);
					no.Text=r["no"].ToString();
					co.Text=r["co"].ToString();
					decimal st=decimal.Parse(r["sotien"].ToString());
					sotien.Text=st.ToString(format_sotien);
					ghichu.Text=r["ghichu"].ToString();
                    ngayct.Value = new DateTime(int.Parse(r["ngayct"].ToString().Substring(6, 4)), int.Parse(r["ngayct"].ToString().Substring(3, 2)), int.Parse(r["ngayct"].ToString().Substring(0, 2)), 0, 0, 0, 0);
				}
			}
			catch{emp_text();}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			decimal st=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			if (st!=0)
			{
                if (so.Text=="")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số chứng từ !"), d.Msg);
                    so.Focus();
                    return;
                }
                /*
				if (d.get_data("select * from "+user+s_mmyy+".d_thanhtoanct where id="+l_id).Tables[0].Rows.Count==0)
				{
                    so.Text = d.get_sophieu("CT", i_makho, -400, s_mmyy);
                    so.Update();
				}
                */
				if (no.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Tài khoản nợ !"),d.Msg);
					no.Focus();
					return;
				}
				if (co.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Tài khoản có !"),d.Msg);
					co.Focus();
					return;
				}
				decimal stdatra=0;
				foreach(DataRow r in d.get_data("select sotien from "+user+s_mmyy+".d_thanhtoanct where id="+l_id+" and stt<>"+stt.Value).Tables[0].Rows)
					stdatra+=decimal.Parse(r["sotien"].ToString());
				if (st+stdatra>d_sotien)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số tiền thanh toán không được lớn hơn số tiền trên hóa đơn (")+d_sotien.ToString(format_sotien)+" !",d.Msg);
					sotien.Focus();
					return;
				}
				d.upd_thanhtoanct(s_mmyy,l_id,stt.Value,so.Text,ngay.Text,no.Text,co.Text,decimal.Parse(sotien.Text),ghichu.Text,ngayct.Text,i_userd);
				d.execute_data("update "+user+s_mmyy+".d_thanhtoan set datra="+(st+stdatra)+" where id="+l_id);
                if (!bChitra_ndot) d.execute_data("update " + user + s_mmyy + ".d_nhapll set paid=1 where id=" + l_id);
				DataRow r1=d.getrowbyid(ds.Tables[0],"id="+l_id);
				if (r1!=null)
				{
					r1["datra"]=st+stdatra;
					r1["chon"]=(st+stdatra)!=0;
				}
				ds.AcceptChanges();
				r1=d.getrowbyid(dsct.Tables[0],"stt="+stt.Value);
				if (r1==null)
				{
					DataRow r2=dsct.Tables[0].NewRow();
					r2["id"]=l_id;
					r2["stt"]=stt.Value;
					r2["so"]=so.Text;
					r2["ngay"]=ngay.Text;
					r2["no"]=no.Text;
					r2["co"]=co.Text;
					r2["sotien"]=st;
					r2["ghichu"]=ghichu.Text;
                    r2["ngayct"] = ngayct.Text;
					dsct.Tables[0].Rows.Add(r2);
				}
				else
				{
					DataRow [] dr=dsct.Tables[0].Select("stt="+stt.Value);
					if (dr.Length>0)
					{
						dr[0]["id"]=l_id;
						dr[0]["stt"]=stt.Value;
						dr[0]["so"]=so.Text;
						dr[0]["ngay"]=ngay.Text;
						dr[0]["no"]=no.Text;
						dr[0]["co"]=co.Text;
						dr[0]["sotien"]=st;
						dr[0]["ghichu"]=ghichu.Text;
                        dr[0]["ngayct"]=ngayct.Text;
					}
				}
				tinh_giatri("true");
			}
			emp_text();
			so.Focus();
		}

		private void emp_text()
		{
			stt.Value=d.get_stt(dsct.Tables[0],"stt");
			so.Text=sotien.Text=ghichu.Text="";
			no.Text=s_no;co.Text=s_co;
            so.Text = "";// s_sophieu;
			decimal stdatra=0;
			foreach(DataRow r in d.get_data("select sotien from "+user+s_mmyy+".d_thanhtoanct where id="+l_id+" and stt<>"+stt.Value).Tables[0].Rows)
				stdatra+=decimal.Parse(r["sotien"].ToString());
			decimal st=d_sotien-stdatra;
			sotien.Text=st.ToString(format_sotien);
            string _ngay = d.ngayhienhanh_server;
            ngay.Value = new DateTime(int.Parse(_ngay.Substring(6, 4)), int.Parse(_ngay.Substring(3, 2)), int.Parse(_ngay.Substring(0, 2)), 0, 0, 0, 0);
            ngayct.Value = new DateTime(int.Parse(_ngay.Substring(6, 4)), int.Parse(_ngay.Substring(3, 2)), int.Parse(_ngay.Substring(0, 2)), 0, 0, 0, 0);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			decimal st=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			if (so.Text!="" && st!=0)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy đợt thanh toán ")+ " "+stt.Value.ToString()+" ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					d.execute_data("delete from "+user+s_mmyy+".d_thanhtoanct where id="+l_id+" and stt="+stt.Value);
					decimal stdatra=0;
					foreach(DataRow r in d.get_data("select sotien from "+user+s_mmyy+".d_thanhtoanct where id="+l_id).Tables[0].Rows)
						stdatra+=decimal.Parse(r["sotien"].ToString());
					d.execute_data("update "+user+s_mmyy+".d_thanhtoan set datra="+stdatra+" where id="+l_id);
                    if (!bChitra_ndot) d.execute_data("update " + user + s_mmyy + ".d_nhapll set paid=0 where id=" + l_id);
					DataRow r1=d.getrowbyid(ds.Tables[0],"id="+l_id);
					if (r1!=null)
					{
						r1["datra"]=stdatra;
						r1["chon"]=stdatra>0;
					}
					ds.AcceptChanges();
					tinh_giatri("true");
					d.delrec(dsct.Tables[0],"stt="+stt.Value);
					ref_text();
				}
			}
		}

		private void sotien_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDecimal(e);
		}

		private void sotien_Validated(object sender, System.EventArgs e)
		{
			try
			{
				decimal st=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
				sotien.Text=st.ToString(format_sotien);
			}
			catch{}
		}

		private void butInct_Click(object sender, System.EventArgs e)
		{
			if (dsct.Tables[0].Rows.Count==0) return;
			string xxx=user+s_mmyy;
			sql="select a.id,a.sophieu,to_char(a.ngaysp,'dd/mm/yyyy') ngaysp,a.sohd,to_char(a.ngayhd,'dd/mm/yyyy') ngayhd,";
			sql+="c.ten madv,d.no,d.co,b.sotien,b.datra,d.ghichu,d.so,to_char(d.ngay,'dd/mm/yyyy') as ngay,d.sotien as sotiendot,to_char(d.ngayct,'dd/mm/yyyy') as ngayct";
			sql+=" from "+xxx+".d_nhapll a,"+xxx+".d_thanhtoan b,"+user+".d_dmnx c,"+xxx+".d_thanhtoanct d";
			sql+=" where a.id=b.id and a.madv=c.id and b.id=d.id and b.id="+l_id+"  order by d.stt";
			DataSet tmp=d.get_data(sql);
			frmReport f=new frmReport(d,tmp.Tables[0], i_userd,"d_congno_dot.rpt","CÔNG NỢ",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"","","","","","","","");
			f.ShowDialog(this);		
		}

        private void f_capnhat_db()
        {
            string asql = "";
            asql = "alter table " + user + s_mmyy + ".d_thanhtoan add sotiennovat numeric(18,4) default 0";
            d.execute_data(asql, false);
        }
        private void f_capnhat_db(string tu, string den)
        {            
            string asql = "";
            asql = "alter table xxx.d_thanhtoan add sotiennovat numeric(18,4) default 0";
            d.execute_data_mmyy(asql, tu, den, 23);
        }

        private void chkTraNhacc_Click(object sender, EventArgs e)
        {
            d.writeXml("d_thongso", "congno_tranhacc", chkTraNhacc.Checked ? "1" : "0");
        }

        private void chkSeeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkSeeAll) load_grid();
        }
	}
}
