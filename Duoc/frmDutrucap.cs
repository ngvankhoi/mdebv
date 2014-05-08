using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXchuyenkho.
	/// </summary>
	public class frmDutrucap : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private LibList.List listDMBD;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string user,xxx,s_mmyy,s_ngay,sql,s_loai,s_ngaysp,s_makho,format_soluong;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay;
		private decimal l_id;
		private decimal d_soluong,d_soluongton,d_soluongcu;
        private bool bKhoaso, bNew, bEdit = true, bAdmin, bDutrucap, bSophieu, bLockytu, bMaso_ten, bSophieu_kho, bTru_tonao=false;
        private bool b_DutruCungchinhanh = true;
        private int i_IDChinhanhXuat = 0, i_IDChinhanhHientai = 0;
        private string s_DBLink_CNXuat = "";
		private AccessData d;
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private MaskedTextBox.MaskedTextBox sophieu;
		private System.Windows.Forms.ComboBox khox;
		private System.Windows.Forms.ComboBox khon;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.ComboBox manguon;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.TextBox find;
		private MaskedBox.MaskedBox donvi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private MaskedBox.MaskedBox tenhang;
		private MaskedBox.MaskedBox tennuoc;
        private Button butXuat;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDutrucap(AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;	i_nhom=nhom;	s_makho=kho;
			i_userid=userid;s_mmyy=mmyy;
			s_ngay=ngay;s_loai=loai;bAdmin=admin;this.Text=title;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public frmDutrucap(AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool admin, bool _DutruCungChinhanh, int _IDChinhanhXuat)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            d = acc; i_nhom = nhom; s_makho = kho;
            i_userid = userid; s_mmyy = mmyy;
            s_ngay = ngay; s_loai = loai; bAdmin = admin; this.Text = title;

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            b_DutruCungchinhanh = _DutruCungChinhanh;
            i_IDChinhanhXuat = _IDChinhanhXuat;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDutrucap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.khox = new System.Windows.Forms.ComboBox();
            this.khon = new System.Windows.Forms.ComboBox();
            this.listDMBD = new LibList.List();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.find = new System.Windows.Forms.TextBox();
            this.donvi = new MaskedBox.MaskedBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tenhang = new MaskedBox.MaskedBox();
            this.tennuoc = new MaskedBox.MaskedBox();
            this.butXuat = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(118, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(221, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Kho xuất : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(423, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Kho nhập :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(164, 4);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // khox
            // 
            this.khox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khox.Enabled = false;
            this.khox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khox.Location = new System.Drawing.Point(279, 4);
            this.khox.Name = "khox";
            this.khox.Size = new System.Drawing.Size(147, 21);
            this.khox.TabIndex = 3;
            this.khox.SelectedIndexChanged += new System.EventHandler(this.khox_SelectedIndexChanged);
            this.khox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khox_KeyDown);
            // 
            // khon
            // 
            this.khon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khon.Enabled = false;
            this.khon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khon.Location = new System.Drawing.Point(484, 4);
            this.khon.Name = "khon";
            this.khon.Size = new System.Drawing.Size(184, 21);
            this.khon.TabIndex = 4;
            this.khon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khon_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 560);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 26;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(21, 455);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(97, 455);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(41, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(94, 478);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(44, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(656, 478);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(435, 478);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 35;
            this.label20.Text = "Nguồn :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(136, 455);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(304, 21);
            this.tenbd.TabIndex = 7;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(50, 455);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(54, 21);
            this.mabd.TabIndex = 6;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(136, 478);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(62, 21);
            this.dang.TabIndex = 9;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(712, 478);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(75, 21);
            this.soluong.TabIndex = 11;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(56, 3);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(72, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(497, 455);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(289, 21);
            this.tenhc.TabIndex = 8;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(426, 454);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(73, 23);
            this.lTenhc.TabIndex = 64;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(56, 3);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 10;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(72, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 9);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(779, 438);
            this.dataGrid1.TabIndex = 27;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(497, 478);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(160, 21);
            this.manguon.TabIndex = 10;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // find
            // 
            this.find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(672, 4);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(115, 21);
            this.find.TabIndex = 105;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            this.find.Enter += new System.EventHandler(this.find_Enter);
            // 
            // donvi
            // 
            this.donvi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.donvi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donvi.Enabled = false;
            this.donvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donvi.Location = new System.Drawing.Point(50, 478);
            this.donvi.Mask = "";
            this.donvi.MaxLength = 20;
            this.donvi.Name = "donvi";
            this.donvi.Size = new System.Drawing.Size(54, 21);
            this.donvi.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(-3, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 107;
            this.label3.Text = "Đóng gói :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(200, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 108;
            this.label4.Text = "Hãng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(316, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 109;
            this.label5.Text = "Nước :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhang
            // 
            this.tenhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhang.Enabled = false;
            this.tenhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhang.Location = new System.Drawing.Point(238, 478);
            this.tenhang.Mask = "";
            this.tenhang.MaxLength = 10;
            this.tenhang.Name = "tenhang";
            this.tenhang.Size = new System.Drawing.Size(80, 21);
            this.tenhang.TabIndex = 110;
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(354, 478);
            this.tennuoc.Mask = "";
            this.tennuoc.MaxLength = 10;
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(86, 21);
            this.tennuoc.TabIndex = 111;
            // 
            // butXuat
            // 
            this.butXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXuat.Enabled = false;
            this.butXuat.Image = global::Duoc.Properties.Resources.copy_enabled;
            this.butXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXuat.Location = new System.Drawing.Point(39, 506);
            this.butXuat.Name = "butXuat";
            this.butXuat.Size = new System.Drawing.Size(96, 25);
            this.butXuat.TabIndex = 112;
            this.butXuat.Text = "Số lượng xuất";
            this.butXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butXuat.Click += new System.EventHandler(this.butXuat_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(695, 506);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 26;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(625, 506);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 25;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(555, 506);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 24;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(485, 506);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 21;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = global::Duoc.Properties.Resources.Cancel;
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(415, 506);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 19;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(345, 506);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 18;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(275, 506);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 20;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(205, 506);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 23;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(135, 506);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 22;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // frmDutrucap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(795, 573);
            this.Controls.Add(this.butXuat);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.tenhang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.donvi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.find);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.khon);
            this.Controls.Add(this.khox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDutrucap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu dự trù kho cấp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDutrucap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDutrucap_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
			bMaso_ten=d.bMaso_ten(i_nhom);
			bSophieu=d.bSophieuxuat_tudong(i_nhom);
            bSophieu_kho = d.bSophieu_theokho(i_nhom);
			bLockytu=d.bLockytu_traiphai(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			bDutrucap=d.bDutrucap_kho(i_nhom);
            bTru_tonao = d.bTru_tonao(i_nhom);
			i_songay=d.Ngaylv_Ngayht;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			khox.DisplayMember="TEN";
			khox.ValueMember="ID";
            i_IDChinhanhHientai = d.i_Chinhanh_hientai;
            //
            if (i_IDChinhanhXuat > 0 && i_IDChinhanhHientai != i_IDChinhanhXuat)
            {
                s_DBLink_CNXuat = d.getDBLink(i_IDChinhanhXuat);
                s_DBLink_CNXuat = "@" + s_DBLink_CNXuat.Trim().Trim('@');
            }
            else s_DBLink_CNXuat = "";

            sql = "select * from " + user + ".d_dmkho" + s_DBLink_CNXuat + " where nhom=" + i_nhom;
            if (b_DutruCungchinhanh == false  && i_IDChinhanhXuat > 0) sql += " and chinhanh=" + i_IDChinhanhXuat;
            else sql += " and (chinhanh=" + i_IDChinhanhHientai + " or chinhanh =0) ";
			sql+=" order by stt";            
            khox.DataSource = d.get_data(sql).Tables[0];
            //DataSet ads = d.get_data("select '" + sql + "' from dual ");
            //ads.WriteXml("..\\..\\dataxml\\dmkho.xml", XmlWriteMode.WriteSchema);

            //if (b_DutruCungchinhanh)
            //{
            //    khox.DataSource = d.get_data(sql).Tables[0];
            //}
            //else
            //{
            //    string s_con = d.f_get_connection(i_IDChinhanhXuat);
            //    khox.DataSource = d.get_data(s_con,sql).Tables[0];
            //}
			khon.DisplayMember="TEN";
			khon.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
            if(b_DutruCungchinhanh && khox.SelectedIndex>0) sql+="  and id<>" + int.Parse(khox.SelectedValue.ToString());
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			khon.DataSource=d.get_data(sql).Tables[0];

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			load_dm();
			//
            //
			sql="select a.id,a.sophieu,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.khox,a.khon ";
            sql += " from " + xxx + ".d_dutrucapll a inner join medibv.d_dmkho" + s_DBLink_CNXuat + " b on a.khox=b.id ";
            sql+=" where a.loai='"+s_loai+"'"+" and a.nhom="+i_nhom;
			sql+=" and a.userid="+i_userid;
			if (s_makho!="") sql+=" and a.khon in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (b_DutruCungchinhanh == false) sql += " and b.chinhanh=" + i_IDChinhanhXuat;
            else if (b_DutruCungchinhanh && i_IDChinhanhHientai > 0) sql += " and b.chinhanh=" + i_IDChinhanhHientai;
			sql+=" order by a.sophieu";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="SOPHIEU";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_xuatct.xml");
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tennguon,a.slyeucau as soluong,a.slthuc,a.manguon,e.ten as tennuoc,d.ten as tenhang,' ' as mabs,' ' as tenbs,' ' as hotenbn,b.donvi ";
			sql+=" from "+xxx+".d_dutrucapct a,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_dmhang d,"+user+".d_dmnuoc e where a.mabd=b.id and a.manguon=c.id and b.mahang=d.id and b.manuoc=e.id and a.id="+l_id+" order by b.ten";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				mabd.Text=dataGrid1[i,0].ToString();
				tenbd.Text=dataGrid1[i,1].ToString();
				tenhc.Text=dataGrid1[i,2].ToString();
				donvi.Text=dataGrid1[i,3].ToString();
				dang.Text=dataGrid1[i,4].ToString();
				tenhang.Text=dataGrid1[i,5].ToString();
				tennuoc.Text=dataGrid1[i,6].ToString();
				d_soluong=(dataGrid1[i,8].ToString()!="")?decimal.Parse(dataGrid1[i,8].ToString()):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				manguon.SelectedValue=dataGrid1[i,9].ToString();
				d_soluongcu=d_soluong;
			}
			catch{}
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtct.TableName;
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
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (d.bHoatchat)?170:370;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?150:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "donvi";
			TextCol.HeaderText = "Đóng gói";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennuoc";
			TextCol.HeaderText = "Nước";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 60;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "slthuc";
            TextCol.HeaderText = "SL duyệt";
            TextCol.Width = 60;
            TextCol.Format = format_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sophieu='"+sophieu.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã nhập !"),d.Msg);
					sophieu.Focus();
				}
			}
			catch{}
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbSophieu)
			{
				try
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					sophieu.Text=r["sophieu"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					khox.SelectedValue=r["khox"].ToString();
					load_khon();
					khon.SelectedValue=r["khon"].ToString();
					s_ngaysp=ngaysp.Text;
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="(ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
				if (bDutrucap) sql+=" and (soluong>0)";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDMBD.Tonkhoct(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-20,mabd.Height+5);
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
		}

        private void ena_object(bool ena)
        {
            find.Enabled = !ena;
            sophieu.Visible = ena;
            cmbSophieu.Visible = !ena;
            if (!bSophieu) sophieu.Enabled = ena;
            ngaysp.Enabled = ena;
            khox.Enabled = ena;
            khon.Enabled = ena;
            if (d.bNhapmaso) mabd.Enabled = ena;
            tenbd.Enabled = ena;
            if (!bDutrucap) manguon.Enabled = ena;
            soluong.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butThem.Enabled = ena;
            butXoa.Enabled = ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            butHuy.Enabled = !ena;
            butIn.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            butXuat.Enabled = ena;
            i_old = cmbSophieu.SelectedIndex;
            //if (!ena)
            //{
            find.Text = "";
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
            //}

            butXuat.Visible = b_DutruCungchinhanh;

        }

		private void emp_head()
		{
			l_id=0;
			if (bSophieu) sophieu.Text=d.get_sophieu(s_mmyy,"d_dutrucapll","sophieu","where nhom="+i_nhom+" and loai='"+s_loai+"' and userid="+i_userid);
			else sophieu.Text="";
			ngaysp.Text=s_ngay;
            /*find.Text = "";
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";*/
			khon.SelectedIndex=-1;
			khox.SelectedIndex=0;
			s_ngaysp=ngaysp.Text;
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
			mabd.Text="";
			tenbd.Text="";
			tenhc.Text="";
			dang.Text="";
			donvi.Text="";
			tenhang.Text="";
			tennuoc.Text="";
			soluong.Text="0";
			manguon.SelectedIndex=-1;
			d_soluongcu=0;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			if (sophieu.Enabled) sophieu.Focus();
			else if (ngaysp.Enabled) ngaysp.Focus();
			else khox.Focus();
			load_dm();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			if (d.get_dutrucap(s_mmyy,l_id))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được cấp không được sửa !"),d.Msg);
				return;
			}
			ena_object(true);
			bNew=false;
			bEdit=true;
			khox.Enabled=false;
			khon.Enabled=false;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			sophieu.Focus();
			load_dm();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số phiếu !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (khox.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập kho xuất !"),d.Msg);
				khox.Focus();
				return false;
			}
			if (khon.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập kho nhập !"),d.Msg);
				khon.Focus();
				return false;
			}
			return true;
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="")
			{
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="" && mabd.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			if (!bDutrucap)
			{
				if (manguon.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập nguồn !"),d.Msg);
					manguon.Focus();
					return false;
				}
			}
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			cmbSophieu.SelectedIndex=i_old;
			if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaysp.Focus();
					return;
				}
			}
			SendKeys.Send("{F4}");
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
			if (!upd_table(dtct,false)) return;
			emp_detail();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],true) || manguon.SelectedIndex==-1) return;
			d.delrec(dtct,"ma='"+mabd.Text+"' and manguon="+int.Parse(manguon.SelectedValue.ToString()));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,bool del)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d.updrec_dutrucapct(dt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,d_soluong,(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(del)?null:dtton);
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
                d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						if (bDutrucap)
						{
							d_soluongton=d.get_slton_nguon(dtton,int.Parse(khox.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
							if (d_soluong>d_soluongton)
							{
								MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",d.Msg);
								soluong.Focus();
								return;
							}
						}
					}
				}
			}
			catch{}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				if (d.get_dutrucap(s_mmyy,l_id))
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu đã được cấp không được sửa !"),d.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    //
                    foreach (DataRow r1 in dtct.Rows)
                    {                        
                        d.upd_tonkhoth_dutru(d.delete, i_nhom, s_mmyy, int.Parse(khox.SelectedValue.ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()),i_IDChinhanhXuat);
                    }
                    ///
					d.execute_data("delete from "+xxx+".d_dutrucapct where id="+l_id);
					d.execute_data("delete from "+xxx+".d_dutrucapll where id="+l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void khox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==khox) load_khon();
		}

		private void load_khon()
		{
			try
			{
                sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
                sql += " and (chinhanh=" + i_IDChinhanhHientai + " or chinhanh=0 )";
                if (b_DutruCungchinhanh || i_IDChinhanhXuat <=0)
                {
                    sql += " and id<>" + int.Parse(khox.SelectedValue.ToString());                    
                }                 
				if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
				sql+=" order by stt";
				khon.DataSource=d.get_data(sql).Tables[0];
				load_dm();
			}
			catch{}
		}

		private void khox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (khox.SelectedIndex==-1) khox.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");	
			}
		}

		private void khon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
                try
                {
                    if (khon.SelectedIndex == -1) khon.SelectedIndex = 0;
                }
                catch { }
				SendKeys.Send("{Tab}");
			}
		}

		private void load_dm()
		{
            if (b_DutruCungchinhanh)
            {
                if (bDutrucap) dtton = d.get_tonkhoth(s_mmyy, int.Parse(khox.SelectedValue.ToString()));
                else dtton = d.get_tonkhoth(i_nhom);
            }
            else
            {
                dtton = d.get_tonkhoth_chinhanhkhac(i_IDChinhanhXuat, s_mmyy, int.Parse(khox.SelectedValue.ToString()));
            }
			listDMBD.DataSource=dtton;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct,false);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
            l_id = (bNew) ? d.get_id_xuat : l_id;
            if (bNew)
            {
                if (bSophieu)
                {
                    sql = "where nhom=" + i_nhom + " and loai='" + s_loai + "' and userid=" + i_userid;
                    if (bSophieu_kho) sql+=" and khox="+int.Parse(khox.SelectedValue.ToString());
                    sophieu.Text = d.get_sophieu(s_mmyy, "d_dutrucapll", "sophieu", sql);
                }
            }
			if (!d.upd_dutrucapll(s_mmyy,l_id,i_nhom,sophieu.Text,ngaysp.Text,s_loai,int.Parse(khox.SelectedValue.ToString()),int.Parse(khon.SelectedValue.ToString()),i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu dự trù !"),d.Msg);
				return;
			}
			if (!bNew)
			{
                if (bTru_tonao)
                {
                    foreach (DataRow r1 in dtsave.Rows)
                    {
                        if (i_IDChinhanhXuat <= 0)
                        {
                            d.upd_tonkhoth_dutru(d.delete, i_nhom, s_mmyy, int.Parse(khox.SelectedValue.ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        }
                        else
                        {
                            d.upd_tonkhoth_dutru(d.delete, i_nhom, s_mmyy, int.Parse(khox.SelectedValue.ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()),i_IDChinhanhXuat );
                        }
                    }
                }
                foreach (DataRow r1 in dsxoa.Tables[0].Rows)
                {
                    d.execute_data("delete from " + xxx + ".d_dutrucapct where id=" + l_id + " and manguon=" + decimal.Parse(r1["manguon"].ToString()) + " and mabd=" + int.Parse(r1["mabd"].ToString()));
                    //d.upd_tonkhoth_dutru(d.delete, i_nhom, s_mmyy, int.Parse(khox.SelectedValue.ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                }
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                d.upd_dutrucapct(s_mmyy, l_id, int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                if (i_IDChinhanhXuat <= 0)
                {
                    d.upd_tonkhoth_dutru(d.dutru, i_nhom, s_mmyy, int.Parse(khox.SelectedValue.ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                }
                else
                {
                    d.upd_tonkhoth_dutru(d.dutru, i_nhom, s_mmyy, int.Parse(khox.SelectedValue.ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), i_IDChinhanhXuat);
                }
            }
			d.updrec_dutrucapll(dtll,l_id,sophieu.Text,ngaysp.Text,int.Parse(khox.SelectedValue.ToString()),int.Parse(khon.SelectedValue.ToString()));

			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
                if (!bNew)
                {
                    cmbSophieu.SelectedValue = l_id.ToString();
                    load_head();
                }
			}
			catch{}
			load_grid();
			ena_object(false);
			butMoi.Focus();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			string tenfile="d_dutruxuat.rpt";
			string slydo="Chuyển kho";
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct,i_userid,tenfile,cmbSophieu.Text,ngaysp.Text,"","",khon.Text,slydo,khox.Text,"","","");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+tenfile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+khon.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+slydo+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+khox.Text+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="";
				oRpt.DataDefinition.FormulaFields["c9"].Text="";
				oRpt.DataDefinition.FormulaFields["c10"].Text="";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				//oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
				oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				if (d.bPrintDialog)
				{
					result=Thongso();
					if (result==DialogResult.OK)
					{
						oRpt.PrintOptions.PrinterName=p.PrinterSettings.PrinterName;
						oRpt.PrintToPrinter(p.PrinterSettings.Copies,false,p.PrinterSettings.FromPage,p.PrinterSettings.ToPage);
					}
				}
				else oRpt.PrintToPrinter(1,false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
		}

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.Tonkhoct(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-20,mabd.Height+5);
			}		
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu)
				{
					if (bMaso_ten) sql="ma like '"+ma.Trim()+"%' or ten like '"+ma.Trim()+"%' or tenhc like '"+ma.Trim()+"%'";
					else sql="ma like '"+ma.Trim()+"%'";
				}
				else 
				{
					if (bMaso_ten) sql="ma like '%"+ma.Trim()+"%' or ten like '%"+ma.Trim()+"%' or tenhc like '%"+ma.Trim()+"%'";
					else sql="ma like '%"+ma.Trim()+"%'";
				}
				if (bDutrucap) sql+=" and soluong>0";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void get_items(int stt)
		{
			try
			{
				sql="stt="+stt;
				if (bDutrucap) sql+=" and soluong>0";
				r=d.getrowbyid(dtton,sql);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					donvi.Text=r["donvi"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					listDMBD.Hide();
					soluong.Focus();
				}
			}
			catch{}		
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					sql="stt="+int.Parse(mabd.Text);
					if (bDutrucap) sql+=" and soluong>0";
					r=d.getrowbyid(dtton,sql);
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
						donvi.Text=r["donvi"].ToString();
						tenhang.Text=r["tenhang"].ToString();
						tennuoc.Text=r["tennuoc"].ToString();
						manguon.SelectedValue=r["manguon"].ToString();
						listDMBD.Hide();
						soluong.Focus();
					}
				}
				catch{}		
			}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
				if (bDutrucap) sql+=" and soluong>0";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(int.Parse(mabd.Text));
					if(!listDMBD.Focused) listDMBD.Hide();
					soluong.Focus();
				}
				else
				{
					if (listDMBD.Visible)
					{
						listDMBD.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void find_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==find) RefreshChildren(find.Text);
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				dv.RowFilter="sophieu like '%"+text.Trim()+"%'";
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void manguon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (manguon.SelectedIndex==-1 && manguon.Items.Count>0) manguon.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

        private void butXuat_Click(object sender, EventArgs e)
        {
            if (khox.SelectedIndex==-1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn kho xuất !"), d.Msg);
                khox.Focus();
                return;
            }
            if (khon.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn kho nhập !"), d.Msg);
                khon.Focus();
                return;
            }
            frmChonngay f = new frmChonngay(d, s_ngay);
            f.ShowDialog();
            if (f.s_tu != "" && f.s_den != "")
            {
                string s = "";
                DataRow r1,r2;
                decimal sl = 0;
                foreach (DataRow r in get_xuat(f.s_tu, f.s_den).Select("true","ma"))
                {
                    r1 = d.getrowbyid(dtton, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r1 != null)
                    {
                        sl = decimal.Parse(r["soluong"].ToString());
                        if (bDutrucap && sl>decimal.Parse(r1["soluong"].ToString()))
                        {
                            s += r1["ten"].ToString().Trim() + " : " + sl.ToString().Trim()+" "+ r1["dang"].ToString().Trim()+"\n";
                            sl = Math.Min(sl, decimal.Parse(r1["soluong"].ToString()));
                        }
                        if (sl > 0)
                        {
                            d.updrec_dutrucapct(dtct, int.Parse(r["mabd"].ToString()), r1["ma"].ToString(), r1["ten"].ToString(), r1["tenhc"].ToString(), r1["dang"].ToString(), r1["tennguon"].ToString(), sl, Math.Max(0, int.Parse(r1["manguon"].ToString())), dtton);
                            r2 = d.getrowbyid(dtct, "mabd=" + int.Parse(r["mabd"].ToString()));
                            if (r2 != null)
                            {
                                r2["tenhang"] = r1["tenhang"].ToString();
                                r2["tennuoc"] = r1["tennuoc"].ToString();
                                r2["donvi"] = r1["donvi"].ToString();
                                r2["slthuc"] = 0;
                            }
                        }
                    }
                }
                if (s != "") MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ tồn")+"\n" + s, d.Msg);
            }
        }
        private DataTable get_xuat(string tu,string den)
        {
            string stime = "'" + d.f_ngay + "'", cont = " and a.ngay between to_date('" + tu + "'," + stime + ") and to_date('" + den + "'," + stime + ")";
            sql = " select c.ma,b.mabd,sum(b.soluong) as soluong from xxx.d_xuatsdll a,xxx.d_thucxuat b," + user + ".d_dmbd c";
            sql += " where a.id=b.id and b.mabd=c.id and b.makho=" + int.Parse(khon.SelectedValue.ToString());
            sql += " and a.loai in (1,4)";
            sql += cont;
            sql += " group by c.ma,b.mabd";
            sql += " union all ";
            sql += " select c.ma,b.mabd,sum(b.soluong) as soluong from xxx.d_xuatsdll a,xxx.d_thucbucstt b," + user + ".d_dmbd c";
            sql += " where a.id=b.id and b.mabd=c.id and b.makho=" + int.Parse(khon.SelectedValue.ToString());
            sql += " and a.loai in (2)";
            sql += cont;
            sql += " group by c.ma,b.mabd";
            sql += " union all ";
            sql += " select c.ma,b.mabd,sum(b.soluong) as soluong from xxx.bhytkb a,xxx.bhytthuoc b," + user + ".d_dmbd c";
            sql += " where a.id=b.id and b.mabd=c.id and b.makho=" + int.Parse(khon.SelectedValue.ToString());
            sql += cont;
            sql += " group by c.ma,b.mabd";
            sql += " union all ";
            sql += " select c.ma,b.mabd,sum(b.soluong) as soluong from xxx.d_ngtrull a,xxx.d_ngtruct b," + user + ".d_dmbd c";
            sql += " where a.id=b.id and b.mabd=c.id and b.makho=" + int.Parse(khon.SelectedValue.ToString());
            sql += cont;
            sql += " group by c.ma,b.mabd";
            sql += " union all ";
            sql += " select c.ma,b.mabd,sum(b.soluong) as soluong from xxx.d_xuatll a,xxx.d_xuatct b," + user + ".d_dmbd c";
            sql += " where a.id=b.id and b.mabd=c.id and a.loai in ('CK','BS','XK') and a.khox=" + int.Parse(khon.SelectedValue.ToString());
            sql += cont;
            sql += " group by c.ma,b.mabd";
            DataTable tmp1 = d.get_data_mmyy(sql, tu, den, true).Tables[0];
            DataTable tmp2 = tmp1.Copy();
            tmp1.Clear();
            DataRow r1, r2; DataRow[] dr;
            foreach (DataRow r in tmp2.Rows)
            {
                sql = "mabd=" + int.Parse(r["mabd"].ToString());
                r1 = d.getrowbyid(tmp1, sql);
                if (r1 == null)
                {
                    r2 = tmp1.NewRow();
                    r2["ma"] = r["ma"].ToString();
                    r2["mabd"] = r["mabd"].ToString();
                    r2["soluong"] = r["soluong"].ToString();
                    tmp1.Rows.Add(r2);
                }
                else
                {
                    dr = tmp1.Select(sql);
                    if (dr.Length > 0) dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r["soluong"].ToString());
                }
            }
            return tmp1;
        }

        private void butchuyen_Click(object sender, EventArgs e)
        {

        }
	}
}