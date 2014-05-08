using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Medisoft
{
	public class frmDausinhton_chung : System.Windows.Forms.Form
    {
        decimal d_mavaovien = 0; decimal o_id = 0;
        string s_ngay = "";
        private int i_maxlength_mabn = 8,i_userid;
        private bool bQuanly_Theo_Chinhanh = false;
        #region Khai bao
        Language lan =null;// new Language();
        Bogotiengviet tv =null;// new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        public Label label1;
        public MaskedTextBox.MaskedTextBox mabn;
        public Label label2;
        public TextBox hoten;
        public Label label3;
        public MaskedTextBox.MaskedTextBox mabs;
        public TextBox tenbs;
        public MaskedTextBox.MaskedTextBox manv;
        public DataGrid dataGrid1;
        public Button butKetthuc;
        public Button butHuy;
        public Button butBoqua;
        public Button butLuu;
        public Button butSua;
        public Button butMoi;
        public ComboBox cmbMabn;
        private LibDuoc.AccessData d;//=new LibDuoc.AccessData();
		private LibMedi.AccessData m;
		private int i_old;
        public int i_loaiba = 0;//Tu:19/06/2011
        public string s_makp, sql, user,xxx="";
        public decimal l_id = 0, l_idkhoa, l_dutru, l_maql = 0;
		private bool bNew;
		private LibList.List listHoten;
		private LibList.List listNv;
		private DataRow r;
		public DataTable dthoten=new DataTable();
        public DataTable dtnv = new DataTable();
        public DataTable dtct = new DataTable();
        public Label label17;
        public Label label18;
        public Label label19;
        public MaskedTextBox.MaskedTextBox phong;
        public MaskedTextBox.MaskedTextBox giuong;
        public MaskedTextBox.MaskedTextBox ghichu;
        public MaskedBox.MaskedBox ngay;
        public MaskedBox.MaskedBox nhietdo;
        public MaskedTextBox.MaskedTextBox huyetap1;
        public MaskedTextBox.MaskedTextBox nhiptho;
        public MaskedTextBox.MaskedTextBox cannang;
        public MaskedTextBox.MaskedTextBox mach;
        public Label label21;
        public Label label5;
        public Label label6;
        public Label label7;
        public Label label14;
        public Label label8;
        public Label label11;
        public Label label12;
        public Label label13;
        public Label label9;
        public Label label10;
        public Button butBieudo;
        public string mNgayvao = "", mNgayra = "", s_table = "", s_mabn = "", s_mabs = "";
        private DataTable dtll = new DataTable();
        public MaskedBox.MaskedBox huyetap;
		private System.ComponentModel.Container components = null;
        #endregion

        public frmDausinhton_chung()
		{
			InitializeComponent();
			//lan.Read_Language_to_Xml(this.Name.ToString(),this);
			//lan.Changelanguage_to_English(this.Name.ToString(),this);
            //m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			//s_makp=makp;
		}        

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDausinhton_chung));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.manv = new MaskedTextBox.MaskedTextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.listHoten = new LibList.List();
            this.listNv = new LibList.List();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.phong = new MaskedTextBox.MaskedTextBox();
            this.giuong = new MaskedTextBox.MaskedTextBox();
            this.ghichu = new MaskedTextBox.MaskedTextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap1 = new MaskedTextBox.MaskedTextBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.butBieudo = new System.Windows.Forms.Button();
            this.huyetap = new MaskedBox.MaskedBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(48, 6);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(80, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(176, 6);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(296, 21);
            this.hoten.TabIndex = 2;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(470, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bác sĩ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mabs.Location = new System.Drawing.Point(515, 6);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(35, 21);
            this.mabs.TabIndex = 3;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(552, 6);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(232, 21);
            this.tenbs.TabIndex = 4;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // manv
            // 
            this.manv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manv.Enabled = false;
            this.manv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.manv.Location = new System.Drawing.Point(495, 101);
            this.manv.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(36, 21);
            this.manv.TabIndex = 5;
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 33);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(777, 415);
            this.dataGrid1.TabIndex = 28;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(681, 479);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 21;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(611, 479);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 20;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(471, 479);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 17;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(401, 479);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 16;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(331, 479);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 19;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(261, 479);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 18;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // cmbMabn
            // 
            this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(48, 6);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(80, 21);
            this.cmbMabn.TabIndex = 0;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // listHoten
            // 
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(120, 542);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 90;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(208, 542);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 91;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(2, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 23);
            this.label17.TabIndex = 93;
            this.label17.Text = "Phòng :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(130, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 23);
            this.label18.TabIndex = 94;
            this.label18.Text = "Giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(236, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 23);
            this.label19.TabIndex = 95;
            this.label19.Text = "Tình trạng :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(48, 29);
            this.phong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.phong.MaxLength = 10;
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 7;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(176, 29);
            this.giuong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giuong.MaxLength = 10;
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(64, 21);
            this.giuong.TabIndex = 8;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(296, 29);
            this.ghichu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(488, 21);
            this.ghichu.TabIndex = 9;
            // 
            // ngay
            // 
            this.ngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(39, 452);
            this.ngay.Mask = "##/##/#### ##:##";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(94, 21);
            this.ngay.TabIndex = 10;
            this.ngay.Text = "  /  /       :  ";
            // 
            // nhietdo
            // 
            this.nhietdo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(319, 452);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 12;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap1
            // 
            this.huyetap1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap1.Enabled = false;
            this.huyetap1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap1.Location = new System.Drawing.Point(706, 538);
            this.huyetap1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap1.MaxLength = 7;
            this.huyetap1.Name = "huyetap1";
            this.huyetap1.Size = new System.Drawing.Size(45, 21);
            this.huyetap1.TabIndex = 13;
            // 
            // nhiptho
            // 
            this.nhiptho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(575, 452);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 14;
            // 
            // cannang
            // 
            this.cannang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(711, 452);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 15;
            // 
            // mach
            // 
            this.mach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(183, 452);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label21.Location = new System.Drawing.Point(-9, 451);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 23);
            this.label21.TabIndex = 119;
            this.label21.Text = "Ngày :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(135, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 114;
            this.label5.Text = "Mạch :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(215, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 105;
            this.label6.Text = "lần/phút";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(263, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 115;
            this.label7.Text = "Nhiệt độ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(351, 451);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 23);
            this.label14.TabIndex = 107;
            this.label14.Text = "C°";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(375, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 116;
            this.label8.Text = "Huyết áp :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(479, 451);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 23);
            this.label11.TabIndex = 110;
            this.label11.Text = "mmHg";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(607, 451);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 23);
            this.label12.TabIndex = 112;
            this.label12.Text = "lần/phút";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(751, 451);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 113;
            this.label13.Text = "kg";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(519, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 117;
            this.label9.Text = "Nhịp thở :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(655, 451);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 23);
            this.label10.TabIndex = 118;
            this.label10.Text = "Cân nặng :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butBieudo
            // 
            this.butBieudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBieudo.Image = ((System.Drawing.Image)(resources.GetObject("butBieudo.Image")));
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(541, 479);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(70, 25);
            this.butBieudo.TabIndex = 120;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBieudo.Click += new System.EventHandler(this.butBieudo_Click);
            // 
            // huyetap
            // 
            this.huyetap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(429, 452);
            this.huyetap.Mask = "###/###";
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(46, 21);
            this.huyetap.TabIndex = 13;
            this.huyetap.Text = "   /   ";
            // 
            // frmDausinhton_chung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.butBieudo);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.huyetap1);
            this.Controls.Add(this.nhiptho);
            this.Controls.Add(this.cannang);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.manv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDausinhton_chung";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dấu sinh tồn";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public void Init()
        {
            d = new LibDuoc.AccessData();
            lan = new Language();
            tv = new Bogotiengviet();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            //m = acc;
        }

        public LibMedi.AccessData acc
        {
            get { return m; }
            set { m = value; }
        }
        public string s_Makp
        {
            get { return s_makp; }
            set { s_makp = value; }
        }
        public int iuserid
        {
            get { return i_userid; }
            set { i_userid = value; }
        }
        public string s_Mabn
        {
            get { return s_mabn; }
            set { s_mabn = value; }
        }
        public decimal l_Maql
        {
            get { return l_maql; }
            set { l_maql = value; }
        }
        public string s_Table
        {
            get { return s_table; }
            set { s_table = value; }
        }
        public string s_Ngay
        {
            get { return s_ngay; }
            set { s_ngay = value; }
        }
        public int i_Loaiba
        {
            get { return i_loaiba; }
            set
            {
                i_loaiba = value;
                if (i_loaiba == 3) s_table = "benhanpk";
                else if (i_loaiba == 2) s_table = "benhanngtr";
                else if (i_loaiba == 4) s_table = "benhancc";
                else s_table = "";
            }
        }
        public decimal d_Mavaovien
        {
            set { d_mavaovien = value; }
        }
        public void Load_form()
        {
            user = m.user;
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            s_ngay = m.ngayhienhanh_server.Substring(0, 10);
            dthoten = m.get_hiendien(s_makp, s_ngay,1).Tables[0];
            listHoten.DataSource = dthoten;
            listHoten.DisplayMember = "MABN";
            listHoten.ValueMember = "HOTEN";
            DataRow[] dr = dthoten.Select("mabn='" + s_Mabn + "'");
            if (dr.Length > 0) hoten.Text = dr[0]["hoten"].ToString();
            sql = "select ma,hoten,nhom from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec;
            if (s_mabs != "") sql += " and ma='" + s_mabs + "'";
            sql += " order by hoten";
            dtnv = d.get_data(sql).Tables[0];
            listNv.DataSource = dtnv;
            listNv.DisplayMember = "MA";
            listNv.ValueMember = "HOTEN";

            cmbMabn.DisplayMember = "MABN";
            cmbMabn.ValueMember = "IDKHOA";
            load_mabn();
            cmbMabn_SelectedIndexChanged(null, null);
            load_head();
            AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            //try { DataTable dt_chieucao = m.get_data("select chieucao from " + user + xxx + ".d_dausinhton where 1=0").Tables[0]; }
            //catch { m.execute_data("alter table " + user + xxx + ".d_dausinhton add chieucao numeric(7,2)"); }
        }

        private void load_mabn()
        {
            sql = "select distinct b.mabn,b.hoten,a.idkhoa,a.mavaovien,a.maql from "+user+m.mmyy(m.ngayhienhanh_server)+".d_dausinhton a," + user + ".btdbn b ";
            sql += " where a.mabn=b.mabn and a.makp='" + s_makp + "'" + " and to_char(a.ngay,'dd/mm/yyyy')='" + m.ngayhienhanh_server.Substring(0, 10) + "'";
            dtll = m.get_data(sql).Tables[0]; ;
            cmbMabn.DataSource = dtll;
            if (cmbMabn.Items.Count > 0) l_idkhoa = decimal.Parse(cmbMabn.SelectedValue.ToString());
            else l_idkhoa = 0;
        }

        private void load_grid()
        {
            sql = "select c.id,c.idkhoa,c.iddutru,to_char(c.ngay,'dd/mm/yyyy hh24:mi') ngay,c.mabs,c.manv,c.mach, ";
            sql += "c.nhietdo,c.huyetap,c.nhiptho,c.cannang,c.chieucao,c.phong,c.giuong,c.ghichu,d.hoten as tenbs,c.maql,c.mavaovien";
            sql += " from xxx.d_dausinhton c left join " + user + ".dmbs d on c.mabs=d.ma ";
            sql += " where c.mabn='" + mabn.Text + "' and (mabn<>'' or mabn is not null) ";
            sql += " and c.maql=" + l_maql.ToString();
            sql += " order by c.ngay desc ";
            dtct = m.get_data_mmyy(sql, mNgayvao == "" ? m.ngayhienhanh_server.Substring(0, 10) : mNgayvao, mNgayra == "" ? m.ngayhienhanh_server.Substring(0, 10) : mNgayra, false).Tables[0];
            dataGrid1.DataSource = dtct;
        }

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày/giờ";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sĩ điều trị";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "mach";
			TextCol.HeaderText = "Mạch";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "nhietdo";
			TextCol.HeaderText = "Nhiệt độ";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "huyetap";
			TextCol.HeaderText = "Huyết áp";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "nhiptho";
			TextCol.HeaderText = "Nhịp thở";
			TextCol.Width = 55;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "cannang";
			TextCol.HeaderText = "Cân nặng";
			TextCol.Width = 55;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "phong";
			TextCol.HeaderText = "Phòng";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "giuong";
			TextCol.HeaderText = "Giường";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "ghichu";
			TextCol.HeaderText = "Ghi chú";
			TextCol.Width = 140;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "iddutru";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "mabs";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "manv";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 14);
            TextCol.MappingName = "maql";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 15);
            TextCol.MappingName = "mavaovien";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return Color.Black;
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i, 0].ToString()); 
                DataRow r = m.getrowbyid(dtct, "id=" + l_id);
                if (r != null)
                {
                    ngay.Text = r["ngay"].ToString(); ;
                    tenbs.Text = r["tenbs"].ToString();
                    mach.Text = r["mach"].ToString();
                    nhietdo.Text = r["nhietdo"].ToString();
                    huyetap.Text = r["huyetap"].ToString();
                    nhiptho.Text = r["nhiptho"].ToString();
                    cannang.Text = r["cannang"].ToString();
                    phong.Text = r["phong"].ToString();
                    giuong.Text = r["giuong"].ToString();
                    ghichu.Text = r["ghichu"].ToString();
                    l_dutru = decimal.Parse(r["iddutru"].ToString());
                    mabs.Text = r["mabs"].ToString();
                    manv.Text = r["manv"].ToString();
                    l_maql = decimal.Parse(r["maql"].ToString());
                    d_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                }
				
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
            mabn.Enabled = ena;
			cmbMabn.Visible=!ena;
            hoten.Enabled = ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			phong.Enabled=ena;
			giuong.Enabled=ena;
			ghichu.Enabled=ena;
			ngay.Enabled=ena;
			mach.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			nhiptho.Enabled=ena;
			cannang.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butBieudo.Enabled=!ena;
			i_old=cmbMabn.SelectedIndex;
		}

		private void emp_head()
		{
            //if (cmbMabn.SelectedIndex!=-1) mabn.Text=cmbMabn.Text;
            hoten.Text = mabn.Text = mabs.Text = tenbs.Text = "";
			phong.Text="";giuong.Text="";ghichu.Text="";mach.Text="";nhiptho.Text="";
			huyetap.Text="";nhietdo.Text="";cannang.Text="";l_id=0;ngay.Text=m.Ngaygio;
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
            if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
            if (mabn.Text.Trim().Length != i_maxlength_mabn)
            {
                if (bQuanly_Theo_Chinhanh)
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(i_maxlength_mabn - 2, '0');//(6,'0');
                }
                else
                {
                    mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');//(i_maxlength_mabn - 2, '0');
                }
            }
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r!=null)
			{
				hoten.Text=r["hoten"].ToString();
                mabs.Text = r["mabs"].ToString();
                giuong.Text = r["giuong"].ToString();
                l_maql = decimal.Parse(r["maql"].ToString());
                d_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_idkhoa = decimal.Parse(r["id"].ToString());
                mabs_Validated(null, null);
			}
            else { hoten.Text = ""; l_idkhoa = 0; mNgayvao = ""; mNgayra = ""; }
			if (butMoi.Enabled) load_grid();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
        {
            o_id = (cmbMabn.SelectedIndex < 0) ? 0 : decimal.Parse(cmbMabn.SelectedValue.ToString());
            l_id = 0;
            emp_head();
            ena_object(true); 
			bNew=true;
            //if (s_mabs != "")
            //{
            //    DataRow rbs = m.getrowbyid(dtnv, "ma='" + s_mabs + "'");
            //    if (rbs != null)
            //    {
            //        mabs.Text = s_mabs;
            //        tenbs.Text = rbs["hoten"].ToString();
            //    }
            //    mach.Focus();
            //}
            mabn.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			mabn.Enabled=false;
			bNew=false;
			ref_text();
            dataGrid1.Focus();
            o_id = (cmbMabn.SelectedIndex < 0) ? 0 : decimal.Parse(cmbMabn.SelectedValue.ToString());		
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			i_old=(bNew)?0:1;
            d_mavaovien = (d_mavaovien == 0 ? (decimal)l_maql : d_mavaovien);
			l_id=(bNew)?d.get_id_xuatsd:l_id;
            d.upd_dausinhton(m.mmyy(ngay.Text), l_id, l_idkhoa, l_dutru, ngay.Text, mabs.Text, manv.Text, (mach.Text != "") ? decimal.Parse(mach.Text) : 0,
                (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text.Trim().Trim('.')) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0,
                (cannang.Text != "") ? int.Parse(cannang.Text) : 0, phong.Text, giuong.Text, ghichu.Text, mabn.Text, (decimal)l_maql, d_mavaovien, s_makp,i_userid);
            xxx = m.mmyy(ngay.Text);
            load_grid();
            ref_text(); 
            cmbMabn.Refresh();
            cmbMabn.SelectedValue = l_idkhoa.ToString();
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            //load_head();
            //ena_object(false);
            //butMoi.Focus();
            load_mabn();
            if (o_id > 0)
            {
                cmbMabn.SelectedValue = o_id;
                l_idkhoa = o_id;
            }
            load_head();
            ena_object(false);
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

		private void Filt_dmbs(string ten,string exp)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%' and "+exp;
			}
			catch{}
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text,"nhom<>"+LibMedi.AccessData.nhanvien);
				listNv.BrowseToDanhmuc(tenbs,mabs,manv,35);
			}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}


		private void hoten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hoten)
			{
				Filt_hoten(hoten.Text);
				listHoten.BrowseToDanhmuc(hoten,mabn,mabs,55);
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

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}
		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{			
			if (mabs.Text=="") return;
			r=d.getrowbyid(dtnv,"nhom<>"+LibMedi.AccessData.nhanvien+" and ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbMabn)
			{
				try
				{
					l_idkhoa=decimal.Parse(cmbMabn.SelectedValue.ToString());
				}
				catch{l_idkhoa=0;}
				load_head();
			}
		}

		private void load_head()
		{
            r = m.getrowbyid(dtll, "idkhoa=" + l_idkhoa);
            if (r != null)
            {
                mabn.Text = r["mabn"].ToString();
                hoten.Text = r["hoten"].ToString();
                l_maql = decimal.Parse(r["maql"].ToString());
                d_mavaovien = decimal.Parse(r["mavaovien"].ToString());
            }
            else l_idkhoa = 0;
            load_grid();//(s_ngay, l_idkhoa);
            ref_text();
		}

		private bool KiemtraHead()
		{
			r=d.getrowbyid(dthoten,"mabn='"+mabn.Text+"'");
			if (r==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return false;
			}
			if ((mabn.Text!="" && hoten.Text=="") || (mabn.Text=="" && hoten.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Họ tên người bệnh !"),LibMedi.AccessData.Msg);
				hoten.Focus();
				return false;
			}
            //if (s_table == "") l_idkhoa = decimal.Parse(r["id"].ToString());
            //else l_idkhoa = decimal.Parse(r["maql"].ToString());
			if ((mabs.Text!="" && tenbs.Text=="") || (mabs.Text=="" && tenbs.Text!=""))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else if (tenbs.Text=="") tenbs.Focus();
				return false;
			}
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbMabn.Items.Count==0) return;
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    d.execute_data("delete from " + user+m.mmyy(ngay.Text) + ".d_dausinhton where id=" + l_id);
					d.delrec(dtct,"id="+l_id);
					dtct.AcceptChanges();
					ref_text();
				}
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
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ lấy dấu sinh tồn !"),LibMedi.AccessData.Msg);
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
		}

		private void butBieudo_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
            DauSinhTon.frmBieudosinhton f = new DauSinhTon.frmBieudosinhton(i_loaiba, (decimal)l_maql, s_makp, (decimal)l_idkhoa, s_ngay);
			f.ShowDialog(this);
		}
	}
}
