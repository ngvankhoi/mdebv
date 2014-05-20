using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	public class frmDoiTuongBoDoi : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private string sql,user;
		private int i_row;
		private DataSet ds=new DataSet();
		private System.ComponentModel.Container components = null;
        private Label label7;
        private Label label8;
        private ComboBox cmbCapBac;
        private ComboBox cb_sudoan;
        private ComboBox cmbChucVu;
        private bool bbadt = false;
        private decimal d_mavaovien = 0;
        private ComboBox cmbTieu_doan;
        private ComboBox cmbTrungDoan;
        private Label label9;
        private Label label10;
        private ComboBox cmbTrung_Doan;
        private TextBox txttieudoan;
        private ComboBox cb_quandoan;
        private bool bxemlai = false;
        #endregion

        public frmDoiTuongBoDoi(LibMedi.AccessData acc,string s_mabn,string s_hoten,string s_tuoi,string s_diachi,decimal mavaovien, bool _xemlai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			d=new LibDuoc.AccessData();
			mabn.Text=s_mabn;
			hoten.Text=s_hoten;
			tuoi.Text=s_tuoi;
			diachi.Text=s_diachi;
            d_mavaovien = mavaovien;
            bxemlai = _xemlai;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //end Tu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiTuongBoDoi));
            this.hoten = new System.Windows.Forms.TextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_quandoan = new System.Windows.Forms.ComboBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCapBac = new System.Windows.Forms.ComboBox();
            this.cb_sudoan = new System.Windows.Forms.ComboBox();
            this.cmbChucVu = new System.Windows.Forms.ComboBox();
            this.cmbTieu_doan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTrung_Doan = new System.Windows.Forms.ComboBox();
            this.txttieudoan = new System.Windows.Forms.TextBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(168, 4);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 1;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(350, 4);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(55, 21);
            this.tuoi.TabIndex = 2;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(53, 4);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(69, 21);
            this.mabn.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(317, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(5, 30);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(704, 315);
            this.dataGrid1.TabIndex = 15;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(102, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cấp bậc :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(406, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(453, 4);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(264, 21);
            this.diachi.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(16, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Quân đoàn cấp tương đương:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_quandoan
            // 
            this.cb_quandoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_quandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cb_quandoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_quandoan.Enabled = false;
            this.cb_quandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_quandoan.Location = new System.Drawing.Point(162, 384);
            this.cb_quandoan.Name = "cb_quandoan";
            this.cb_quandoan.Size = new System.Drawing.Size(181, 21);
            this.cb_quandoan.TabIndex = 6;
            this.cb_quandoan.SelectedIndexChanged += new System.EventHandler(this.cb_quandoan_SelectedIndexChanged);
            this.cb_quandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mucdo_KeyDown);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(240, 176);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(40, 21);
            this.ma.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(353, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "Sư đoàn cấp tương đương:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(423, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "Chức vụ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCapBac
            // 
            this.cmbCapBac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbCapBac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbCapBac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCapBac.Enabled = false;
            this.cmbCapBac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCapBac.Location = new System.Drawing.Point(162, 361);
            this.cmbCapBac.Name = "cmbCapBac";
            this.cmbCapBac.Size = new System.Drawing.Size(181, 21);
            this.cmbCapBac.TabIndex = 4;
            // 
            // cb_sudoan
            // 
            this.cb_sudoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_sudoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cb_sudoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sudoan.Enabled = false;
            this.cb_sudoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_sudoan.Location = new System.Drawing.Point(493, 382);
            this.cb_sudoan.Name = "cb_sudoan";
            this.cb_sudoan.Size = new System.Drawing.Size(198, 21);
            this.cb_sudoan.TabIndex = 7;
            this.cb_sudoan.SelectedIndexChanged += new System.EventHandler(this.cb_sudoan_SelectedIndexChanged);
            // 
            // cmbChucVu
            // 
            this.cmbChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbChucVu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChucVu.Enabled = false;
            this.cmbChucVu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChucVu.Location = new System.Drawing.Point(493, 359);
            this.cmbChucVu.Name = "cmbChucVu";
            this.cmbChucVu.Size = new System.Drawing.Size(198, 21);
            this.cmbChucVu.TabIndex = 5;
            // 
            // cmbTieu_doan
            // 
            this.cmbTieu_doan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTieu_doan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTieu_doan.Enabled = false;
            this.cmbTieu_doan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTieu_doan.Location = new System.Drawing.Point(726, 394);
            this.cmbTieu_doan.Name = "cmbTieu_doan";
            this.cmbTieu_doan.Size = new System.Drawing.Size(198, 21);
            this.cmbTieu_doan.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(346, 404);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tiểu đoàn cấp tương đương :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(15, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 23);
            this.label10.TabIndex = 35;
            this.label10.Text = "Trung đoàn cấp tương đương:";
            // 
            // cmbTrung_Doan
            // 
            this.cmbTrung_Doan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTrung_Doan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTrung_Doan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrung_Doan.Enabled = false;
            this.cmbTrung_Doan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrung_Doan.Location = new System.Drawing.Point(162, 407);
            this.cmbTrung_Doan.Name = "cmbTrung_Doan";
            this.cmbTrung_Doan.Size = new System.Drawing.Size(181, 21);
            this.cmbTrung_Doan.TabIndex = 37;
            // 
            // txttieudoan
            // 
            this.txttieudoan.Location = new System.Drawing.Point(493, 408);
            this.txttieudoan.Name = "txttieudoan";
            this.txttieudoan.Size = new System.Drawing.Size(198, 20);
            this.txttieudoan.TabIndex = 38;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(533, 438);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(463, 438);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 12;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(393, 438);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 14;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(323, 438);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 11;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(253, 438);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 26;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(183, 438);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 9;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // frmDoiTuongBoDoi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(721, 475);
            this.Controls.Add(this.txttieudoan);
            this.Controls.Add(this.cmbTrung_Doan);
            this.Controls.Add(this.cmbTieu_doan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbChucVu);
            this.Controls.Add(this.cb_sudoan);
            this.Controls.Add(this.cmbCapBac);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.cb_quandoan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiTuongBoDoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan Ly Doi Tuong Bo Doi";
            this.Load += new System.EventHandler(this.frmDiungthuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDiungthuoc_Load(object sender, System.EventArgs e)
		{
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
            //try
            //{
            //    sql = "alter table   " + user + ".qn_benhnhan add column tieudoan varchar(50) ";
            //    m.execute_data(sql);
            //}
            //catch
            //{
            //}
            user = m.user;
            //LoaiDonVi
			cb_quandoan.DisplayMember="TEN";
			cb_quandoan.ValueMember="id";
            //khuyen 12/02/2014 cb_quandoan.DataSource = d.get_data("select * from " + user + ".qn_dmloaidv order by id").Tables[0];
            cb_quandoan.DataSource = d.get_data("select * from " + user + ".qn_dmdonvi_cap1 order by id").Tables[0];//khuyen 12/02/2014 thay table qn_dmloaidv=qn_dmdonvi_cap1
            //Donvi
            cb_sudoan.DisplayMember = "TEN";
            cb_sudoan.ValueMember = "id";
            //khuyen 12/02/14 cmbDonVi.DataSource = d.get_data("select * from " + user + ".qn_dmdonvi order by id").Tables[0];
            cb_sudoan.DataSource = d.get_data("select * from " + user + ".qn_dmdonvi_cap2 order by id").Tables[0];//12/02/14 thay table qn_dmdonvi=qn_dmdonvi_cap2
           
        //khuyen 12/02/2014 them 2 table qn_dmdonvi_cap3,qn_dmdonvi_cap4 vao phan quan ly thong tin bo doi
            //Donvi trung doan
            cmbTrung_Doan.DisplayMember = "TEN";
            cmbTrung_Doan.ValueMember = "id";
            cmbTrung_Doan.DataSource = d.get_data("select * from " + user + ".qn_dmdonvi_cap3 order by id").Tables[0];
            //Donvi tieu doan
            cmbTieu_doan.DisplayMember = "TEN";
            cmbTieu_doan.ValueMember = "id";
            cmbTieu_doan.DataSource = d.get_data("select * from " + user + ".qn_dmdonvi_cap4 order by id").Tables[0];
        //end 
            //CapBac
            cmbCapBac.DisplayMember = "TEN";
            cmbCapBac.ValueMember = "id";
            cmbCapBac.DataSource = d.get_data("select * from " + user + ".qn_dmcapbac order by id").Tables[0];
            //ChucVu
            cmbChucVu.DisplayMember = "TEN";
            cmbChucVu.ValueMember = "id";
            cmbChucVu.DataSource = d.get_data("select * from " + user + ".qn_dmchucvu order by id").Tables[0];
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

			ref_text();
            if (bxemlai==false)
            {
                butMoi_Click(null, null);
            }
          //  cb_quandoan_SelectedIndexChanged(null, null);
		}

		private void load_grid()
		{
           /* khoa khuyen 12/02/14 sql = "select a.mabn,a.mavaovien,c.ten as tenloaidonvi,b.ten as tendonvi,d.ten as tencapbac,e.ten as tenchucvu" +
                " from " + user + ".qn_benhnhan a inner join " + user + ".qn_dmdonvi b on a.iddonvi=b.id" +
                " inner join " + user + ".qn_dmloaidv c on c.id=b.idloaidv inner join " + user + ".qn_dmcapbac d on a.idcapbac=d.id" +
                " inner join " + user + ".qn_dmchucvu e on a.idchucvu=e.id";
            sql += " where a.mabn='" + mabn.Text + "'";*/
            //khuyen 12/02/14 hien thi lai tren dataGrid1 do thay doi cau truc bang
			sql="select a.mabn,a.mavaovien,c.ten as tenloaidonvi,b.ten as tendonvi,c3.ten as tentrungdoan,c4.ten as tentieudoan,d.ten as tencapbac,e.ten as tenchucvu"+
                " from "+user+".qn_benhnhan a inner join "+user+".qn_dmdonvi_cap2 b on a.iddonvicap2=b.id"+
                 " inner join " + user + ".qn_dmdonvi_cap3 c3 on c3.id=a.iddonvicap3 "+
                 " left join " + user + ".qn_dmdonvi_cap4 c4 on c4.id=a.iddonvicap4 " +
                " inner join " + user + ".qn_dmdonvi_cap1 c on c.id=b.iddonvicap1 inner join " + user + ".qn_dmcapbac d on a.idcapbac=d.id" +
                " inner join "+user+".qn_dmchucvu e on a.idchucvu=e.id";
			sql+=" where a.mabn='"+mabn.Text+"'";
            //end
			ds=d.get_data(sql);
			dataGrid1.DataSource=ds.Tables[0];
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
            TextCol.MappingName = "tenloaidonvi";
			TextCol.HeaderText = "Loại Đơn Vị";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tendonvi";
			TextCol.HeaderText = "Tên đơn vị";
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            //khuyen 12/02/2014
            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tentrungdoan";
            TextCol.HeaderText = "Tên trung đoàn";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tentieudoan";
            TextCol.HeaderText = "Tên tiểu đoàn";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            //end

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tencapbac";
			TextCol.HeaderText = "Cấp Bậc";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenchucvu";
			TextCol.HeaderText = "Chức vụ";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
            //else if (e.KeyCode==Keys.Enter)
            //{
            //    if (list.Visible) list.Focus();
            //    else SendKeys.Send("{Tab}");
            //}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
            //if (this.ActiveControl==ten)
            //{
            //    Filter(ten.Text);
            //    list.BrowseToDanhmuc(ten,ma,cb_quandoan,0);
            //}
		}

		private void ref_text()
		{
			try
			{
				int i_row=dataGrid1.CurrentCell.RowNumber;
				cb_quandoan.SelectedValue=dataGrid1[i_row,0].ToString();
                cb_sudoan.SelectedValue = dataGrid1[i_row, 1].ToString();
                cmbCapBac.SelectedValue = dataGrid1[i_row, 2].ToString();
                cmbChucVu.SelectedValue = dataGrid1[i_row, 3].ToString();
			}
			catch{}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void Filter(string ten)
		{
            //try
            //{
            //    CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
            //    DataView dv=(DataView)cm.List;
            //    dv.RowFilter="ten like '%"+ten.Trim()+"%'";
            //}
            //catch{}
		}

		private void ena_object(bool ena)
		{
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			cb_quandoan.Enabled=ena;
            cb_sudoan.Enabled = ena;
            //khuyen 12/02/2014 do them 2 combobox tren form 
            cmbTrung_Doan.Enabled = ena;
            cmbTieu_doan.Enabled = ena;
            txttieudoan.Enabled = ena;
            //end 
            cmbCapBac.Enabled = ena;
            cmbChucVu.Enabled = ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (!ena) butMoi.Focus();
		}

		private void mucdo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (cb_quandoan.SelectedIndex==-1 && cb_quandoan.Items.Count>0) cb_quandoan.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
            cb_quandoan.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			cb_quandoan.Focus();
		}

		private bool kiemtra()
		{
            if (cb_quandoan.SelectedIndex == -1)
            {
                cb_quandoan.Focus();
                return false;
            }
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;

            int id_tieudoan = 1;
            ds = d.get_data("select  max(id) as id from medibv.qn_dmdonvi_cap4");
            if (ds.Tables[0].Rows[0]["id"].ToString() == "") id_tieudoan = 1;
            else id_tieudoan = int.Parse(ds.Tables[0].Rows[0]["id"].ToString()) + 1;
            {
                if (!m.upd_danhmuc_quannhan(id_tieudoan, "", txttieudoan.Text, int.Parse(cb_sudoan.SelectedValue.ToString()), "qn_dmdonvi_cap4"))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được số liệu !"));
                    return;
                }
            }
            // truongthuy them tieu doan trong quan nhan : 12052014 
           /// if(d)
          //khuyen 12/02/2014  if (!d.upd_qn_benhnhan(mabn.Text, d_mavaovien, int.Parse(cmbCapBac.SelectedValue.ToString()), int.Parse(cmbChucVu.SelectedValue.ToString()), int.Parse(cmbDonVi.SelectedValue.ToString())))
            if (!d.upd_qn_benhnhan(mabn.Text, d_mavaovien, int.Parse(cmbCapBac.SelectedValue.ToString()), int.Parse(cmbChucVu.SelectedValue.ToString()), int.Parse(cb_quandoan.SelectedValue.ToString()), int.Parse(cb_sudoan.SelectedValue.ToString()), int.Parse(cmbTrung_Doan.SelectedValue.ToString()), id_tieudoan))//khuyen 12/02/2014 do thay doi cau truc cua table qn_benhnhan
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),LibMedi.AccessData.Msg);
				return;
			}
			ena_object(false);
            load_grid();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
            string s_ngay=m.ngayhienhanh_server.Substring(0,10);
            string asql = "select mabn, maql from xxx.benhanpk where mabn='" + mabn.Text + "' and mavaovien='" + d_mavaovien;
            asql += " UNION ALL ";
            asql += "select mabn, maql from xxx.benhancc where mabn='" + mabn.Text + "' and mavaovien='" + d_mavaovien;
            DataSet ads = m.get_data_mmyy(asql, s_ngay, s_ngay, true);
            if(ads!=null && ads.Tables.Count >0 && ads.Tables[0].Rows.Count >0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã khám, không hủy được."));
                return;
            }
            asql = "select mabn, maql from medibv.benhandt where mabn='" + mabn.Text + "' and mavaovien='" + d_mavaovien;
            ads = m.get_data(asql);
            if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã khám, không hủy được."));
                return;
            }
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
                d.execute_data("delete from " + user + ".qn_benhnhan where mabn='" + mabn.Text + "' and mavaovien=" + d_mavaovien);
			}
            load_grid();
            ena_object(false);
            butMoi.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}


        private void cb_quandoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_sudoan.DataSource = m.get_data("select * from medibv.qn_dmdonvi_cap2 where iddonvicap1 =" + cb_quandoan.SelectedValue.ToString() + "").Tables[0];
                cb_sudoan.DisplayMember = "ten";
                cb_sudoan.ValueMember = "id";
            }
            catch { }
        }

        private void cb_sudoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbTrung_Doan.DataSource = m.get_data("select * from medibv.qn_dmdonvi_cap3 where id_cap2 =" + cb_sudoan.SelectedValue.ToString() + "").Tables[0];
                cmbTrung_Doan.DisplayMember = "ten";
                cmbTrung_Doan.ValueMember = "id";
            }
            catch { }
        }
	}
}
