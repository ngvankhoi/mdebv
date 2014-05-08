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
	/// Summary description for dsbnKhoa.
	/// </summary>
	public class frmHiendien : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private bool bPhonggiuong;
        private int i_chinhanh = 0;
		private DataSet ds=new DataSet("hiendien");
		private System.Windows.Forms.Button butketthuc;
		private System.Windows.Forms.Button butInReport;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makp;
		private string s_makp,user,sql;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Button butXem;
        private ComboBox phong;
        private Label label2;
        private CheckBox chkHientai;
        private Label label3;
        private DateTimePicker tu;
        private Label label4;
        private DateTimePicker den;
        private CheckBox chkThuoc;
        private TextBox tim;
        private CheckBox chkToanvien;
        private CheckBox chktheogio;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton tooltripmn;
        private ToolStripMenuItem tmn_hienthitamung;
        private ToolStripMenuItem tmn_hienthitenphonggiuong;
        private ToolStripMenuItem tmn_hienthingayvaovien;
        private ComboBox cmbNgheNghiep;
        private Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHiendien(AccessData acc,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			s_makp=makp;
			m=acc;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHiendien));
            this.butketthuc = new System.Windows.Forms.Button();
            this.butInReport = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.phong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHientai = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.chkToanvien = new System.Windows.Forms.CheckBox();
            this.chktheogio = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tooltripmn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmn_hienthitamung = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_hienthitenphonggiuong = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_hienthingayvaovien = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbNgheNghiep = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butketthuc.BackColor = System.Drawing.Color.Transparent;
            this.butketthuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.butketthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butketthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(440, 542);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 11;
            this.butketthuc.Text = "&Kết thúc";
            this.butketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butketthuc.UseVisualStyleBackColor = false;
            this.butketthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butInReport
            // 
            this.butInReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butInReport.BackColor = System.Drawing.Color.Transparent;
            this.butInReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.butInReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInReport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butInReport.Image = ((System.Drawing.Image)(resources.GetObject("butInReport.Image")));
            this.butInReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInReport.Location = new System.Drawing.Point(370, 542);
            this.butInReport.Name = "butInReport";
            this.butInReport.Size = new System.Drawing.Size(70, 25);
            this.butInReport.TabIndex = 10;
            this.butInReport.Text = "     &In";
            this.butInReport.UseVisualStyleBackColor = false;
            this.butInReport.Click += new System.EventHandler(this.butInReport_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(4, 57);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(784, 473);
            this.dataGrid1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(246, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(284, 30);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(240, 21);
            this.makp.TabIndex = 6;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(12, 547);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(236, 23);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "label2";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXem.BackColor = System.Drawing.Color.Transparent;
            this.butXem.Cursor = System.Windows.Forms.Cursors.Default;
            this.butXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(300, 542);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 9;
            this.butXem.Text = "     &Xem";
            this.butXem.UseVisualStyleBackColor = false;
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // phong
            // 
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(565, 30);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(138, 21);
            this.phong.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(517, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phòng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkHientai
            // 
            this.chkHientai.AutoSize = true;
            this.chkHientai.Checked = true;
            this.chkHientai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHientai.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkHientai.Location = new System.Drawing.Point(12, 32);
            this.chkHientai.Name = "chkHientai";
            this.chkHientai.Size = new System.Drawing.Size(62, 17);
            this.chkHientai.TabIndex = 0;
            this.chkHientai.Text = "Hiện tại";
            this.chkHientai.UseVisualStyleBackColor = true;
            this.chkHientai.CheckedChanged += new System.EventHandler(this.chkHientai_CheckedChanged);
            this.chkHientai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkHientai_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(122, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Từ ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Enabled = false;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(188, 540);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(79, 21);
            this.tu.TabIndex = 2;
            this.tu.Visible = false;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkHientai_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(73, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "đến ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy HH:mm";
            this.den.Enabled = false;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(137, 29);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(111, 21);
            this.den.TabIndex = 4;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkHientai_KeyDown);
            // 
            // chkThuoc
            // 
            this.chkThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThuoc.AutoSize = true;
            this.chkThuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkThuoc.Location = new System.Drawing.Point(624, 553);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(162, 17);
            this.chkThuoc.TabIndex = 12;
            this.chkThuoc.Text = "Kiểm tra sử dụng thuốc chưa";
            this.chkThuoc.UseVisualStyleBackColor = true;
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(706, 30);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(81, 21);
            this.tim.TabIndex = 13;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // chkToanvien
            // 
            this.chkToanvien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkToanvien.AutoSize = true;
            this.chkToanvien.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkToanvien.Location = new System.Drawing.Point(624, 536);
            this.chkToanvien.Name = "chkToanvien";
            this.chkToanvien.Size = new System.Drawing.Size(74, 17);
            this.chkToanvien.TabIndex = 14;
            this.chkToanvien.Text = "Toàn viện";
            this.chkToanvien.UseVisualStyleBackColor = true;
            this.chkToanvien.CheckedChanged += new System.EventHandler(this.chkToanvien_CheckedChanged);
            // 
            // chktheogio
            // 
            this.chktheogio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chktheogio.AutoSize = true;
            this.chktheogio.Enabled = false;
            this.chktheogio.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chktheogio.Location = new System.Drawing.Point(710, 536);
            this.chktheogio.Name = "chktheogio";
            this.chktheogio.Size = new System.Drawing.Size(68, 17);
            this.chktheogio.TabIndex = 15;
            this.chktheogio.Text = "Theo giờ";
            this.chktheogio.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltripmn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tooltripmn
            // 
            this.tooltripmn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tooltripmn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmn_hienthitamung,
            this.tmn_hienthitenphonggiuong,
            this.tmn_hienthingayvaovien});
            this.tooltripmn.Image = ((System.Drawing.Image)(resources.GetObject("tooltripmn.Image")));
            this.tooltripmn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooltripmn.Name = "tooltripmn";
            this.tooltripmn.Size = new System.Drawing.Size(64, 22);
            this.tooltripmn.Text = "Tùy chọn";
            // 
            // tmn_hienthitamung
            // 
            this.tmn_hienthitamung.CheckOnClick = true;
            this.tmn_hienthitamung.Name = "tmn_hienthitamung";
            this.tmn_hienthitamung.Size = new System.Drawing.Size(283, 22);
            this.tmn_hienthitamung.Text = "Hiển thị tổng tạm ứng của Bệnh nhân";
            this.tmn_hienthitamung.Click += new System.EventHandler(this.tmn_hienthitamung_Click);
            // 
            // tmn_hienthitenphonggiuong
            // 
            this.tmn_hienthitenphonggiuong.CheckOnClick = true;
            this.tmn_hienthitenphonggiuong.Name = "tmn_hienthitenphonggiuong";
            this.tmn_hienthitenphonggiuong.Size = new System.Drawing.Size(283, 22);
            this.tmn_hienthitenphonggiuong.Text = "Hiển thị tên phòng giường của Bệnh nhân";
            this.tmn_hienthitenphonggiuong.Click += new System.EventHandler(this.tmn_hienthitenphonggiuong_Click);
            // 
            // tmn_hienthingayvaovien
            // 
            this.tmn_hienthingayvaovien.CheckOnClick = true;
            this.tmn_hienthingayvaovien.Name = "tmn_hienthingayvaovien";
            this.tmn_hienthingayvaovien.Size = new System.Drawing.Size(283, 22);
            this.tmn_hienthingayvaovien.Text = "Hiển thị ngày giờ vào viện của Bệnh nhân";
            this.tmn_hienthingayvaovien.Click += new System.EventHandler(this.tmn_hienthingayvaovien_Click);
            // 
            // cmbNgheNghiep
            // 
            this.cmbNgheNghiep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNgheNghiep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgheNghiep.Location = new System.Drawing.Point(565, 53);
            this.cmbNgheNghiep.Name = "cmbNgheNghiep";
            this.cmbNgheNghiep.Size = new System.Drawing.Size(222, 21);
            this.cmbNgheNghiep.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(486, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Nghề nghiệp :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmHiendien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 583);
            this.Controls.Add(this.cmbNgheNghiep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chktheogio);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.chkToanvien);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkHientai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.butInReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHiendien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người bệnh hiện diện tại Khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHiendien_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHiendien_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHiendien_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            bPhonggiuong = m.bPhonggiuong;
            user = m.user;
            i_chinhanh = m.i_Chinhanh_hientai;
            phong.DisplayMember = "TEN";
            phong.ValueMember = "ID";
            phong.Enabled = bPhonggiuong;
			load_khoa();
            load_nghenghiep();
            tmn_hienthitamung.Checked = m.Thongso("hiendien_tamung") == "1";
            tmn_hienthitenphonggiuong.Checked = m.Thongso("hiendien_phonggiuong") == "1";//gam 23/08/2011
            tmn_hienthingayvaovien.Checked = m.Thongso("hiendien_ngayvaovien") == "1";
            Tao_view_tamumg(6);            
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            chkThuoc.Checked = m.Thongso("hiendienthuoc") == "1";
		}

		private void load_khoa()
		{
            string sql = "select * from " + user + ".btdkp_bv where loai=0";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_chinhanh > 0) sql += " and chinhanh =" + i_chinhanh;
			sql+=" order by makp";
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=m.get_data(sql).Tables[0];
            if (makp.Items.Count > 0) makp.SelectedIndex = 0;
            if (bPhonggiuong) load_phong();
		}

        private void load_phong()
        {
            string sql = "select * from " + user + ".dmphong ";
            if (makp.SelectedIndex != -1) sql += " where makp='" + makp.SelectedValue.ToString() + "'";
            sql += " order by stt";
            phong.DataSource = m.get_data(sql).Tables[0];
            phong.SelectedIndex = -1;
        }

        private void load_nghenghiep()
        {
            string sql = "select * from " + user + ".btdnn_bv order by mann";
            cmbNgheNghiep.DisplayMember = "TENNN";
            cmbNgheNghiep.ValueMember = "MANN";
            cmbNgheNghiep.DataSource = m.get_data(sql).Tables[0];
            cmbNgheNghiep.SelectedIndex = -1;
        }

		private void load_grid()
		{
            string stime = "'" + m.f_ngay + "'";
            string ngaysrv = m.ngayhienhanh_server;
            if (chktheogio.Checked) stime = "'" + m.f_ngaygio + "'";
            int i_length = (chktheogio.Checked) ? 16 : 10;
            if (chkHientai.Checked)
            {
                sql = "select e.tenkp as khoa,a.mabn,b.hoten,case when b.phai=0 then 'Nam' else 'Nữ' end as phai,";
                sql +=" b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,f.doituong,g.sothe,h.ma as giuong,";
                sql += "a.id,a.maql,b.nam";
                //Khuong 03/11 Them option trong tuy chon, cho phep hien thi ngay gio vao vien
                if(tmn_hienthingayvaovien.Checked)sql+=",to_char(d.ngay,'dd/mm/yyyy hh24:mi') as ngayvaovien";
                if (tmn_hienthitamung.Checked) sql += ", i.sotien as tamung ";
                else sql += ", 0 as tamung ";
                if (tmn_hienthitenphonggiuong.Checked) sql += ", ee.ten ||' , ' ||n.ten as tengiuong ";
                else sql += ", '' as tengiuong ";//gam 23/08/2011
                sql += ", g.traituyen,a.maicd,ii.vviet as chandoan,nn.tennn,to_number(to_char(now,'yyyy')) - b.namsinh as tuoi ";//Thuy 24.03.2012
                sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                sql += " inner join " + user + ".btdkp_bv c on a.noichuyen=c.makp ";
                sql += " inner join " + user + ".benhandt d on a.maql=d.maql ";
                sql += " inner join " + user + ".btdkp_bv e on a.makp=e.makp ";
                sql += " inner join " + user + ".doituong f on d.madoituong=f.madoituong ";
                sql += " left join " + user + ".bhyt g on a.maql=g.maql ";
                sql += " left join " + user + ".dmgiuong h on a.idgiuong=h.id";
                sql += " left join " + user + ".icd10 ii on a.maicd=ii.cicd10";//Thuy 24.03.2012
                sql += " left join " + user + ".btdnn_bv nn on b.mann=nn.mann ";
                sql += " left join " + user + ".dmgiuong n on a.idgiuong=n.id ";
                sql += " left join " + user + ".dmphong ee on n.idphong=ee.id ";
                //end gam
                if (tmn_hienthitamung.Checked) sql += " left join " + user + ".vv_tamung_" + m.get_dmcomputer(System.Environment.MachineName).ToString().PadLeft(4, '0') + " as i on a.mavaovien= i.mavaovien ";
                sql += " where d.loaiba=1 and a.nhapkhoa=1 and a.xuatkhoa=0";
                if (makp.SelectedIndex != -1 && chkToanvien.Checked==false) sql += " and a.makp='" + makp.SelectedValue.ToString() + "'";
                if (phong.SelectedIndex != -1) sql += " and h.idphong=" + int.Parse(phong.SelectedValue.ToString());
                if (cmbNgheNghiep.SelectedIndex != -1) sql += " and b.mann='" + cmbNgheNghiep.SelectedValue.ToString() + "'";
                sql += " and (g.sudung is null or g.sudung=1) and to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi')<=to_date('" + ngaysrv + "','dd/mm/yyyy hh24:mi')";
                sql += " order by a.makp,a.ngay desc";
            }
            else
            {
                sql = "select i.tenkp as khoa,a.mabn,a.hoten,case when a.phai=0 then 'Nam' else 'Nữ' end as phai,";
                sql+="a.namsinh,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngay,j.tenkp,l.doituong,m.sothe,b.giuong,";
                sql += "b.id,b.maql,a.nam";
                if (tmn_hienthingayvaovien.Checked) sql += ",to_char(k.ngay,'dd/mm/yyyy hh24:mi') as ngayvaovien";
                if (tmn_hienthitamung.Checked) sql += ", n.sotien as tamung ";
                else sql += ", 0 as tamung ";
                if (tmn_hienthitenphonggiuong.Checked) sql += ", ee.ten || ' , ' ||nn.ten as tengiuong ";//gam 23/08/2011
                else sql += ", '' as tengiuong ";//gam 23/08/2011
                sql += ", m.traituyen,b.maicd,b.chandoan,z.tennn,to_number(to_char(now,'yyyy')) - a.namsinh as tuoi ";//Thuy 24.03.2012
                sql += " from " + user + ".btdbn a inner join " + user + ".nhapkhoa b on a.mabn=b.mabn";
                sql += " left join " + user + ".xuatkhoa c on b.id=c.id";
                sql += " inner join " + user + ".btdkp_bv i on b.makp=i.makp";
                sql += " inner join " + user + ".btdkp_bv j on b.khoachuyen=j.makp";
                sql += " inner join " + user + ".benhandt k on b.maql=k.maql";
                sql += " inner join " + user + ".doituong l on k.madoituong=l.madoituong";
                sql += " left join " + user + ".bhyt m on k.maql=m.maql";
                sql += " left join " + user + ".btdnn_bv z on a.mann=z.mann ";
                //gam 23/08/2011
                sql += " left join " + user + ".dmgiuong nn on b.giuong=nn.ma ";//Thuy 12/12/2011.
                sql += " left join " + user + ".dmphong ee on nn.idphong=ee.id ";//Thuy 20.02.2012
                //end gam
                if (tmn_hienthitamung.Checked) sql += " left join " + user + ".vv_tamung_" +
                    m.get_dmcomputer(System.Environment.MachineName).ToString().PadLeft(4, '0') +
                    " as n on k.mavaovien= n.mavaovien ";
                sql += " where b.id>0";
                //sql += " and " + m.for_ngay("b.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                
                //sql += " and (" + m.for_ngay("b.ngay", "'dd/mm/yyyy'") + "<=to_date('" + den.Text + "','dd/mm/yyyy') ";
                //sql += " and (c.ngay is null or " + m.for_ngay("c.ngay", "'dd/mm/yyyy'") + ">to_date('" + den.Text + "','dd/mm/yyyy')))";
                //
                sql += " and (" + m.for_ngay("b.ngay", stime) + "<=to_date('" + den.Text.Substring(0, i_length) + "'," + stime + ") ";
                sql += " and (c.ngay is null or " + m.for_ngay("c.ngay", stime) + ">to_date('" + den.Text.Substring(0, i_length) + "'," + stime + ")))";
                //
                
                //sql += " and (c.ngay is null or " + m.for_ngay("c.ngay", "'dd/mm/yyyy'") + ">to_date('" + den.Text + "','dd/mm/yyyy'))";//b.ngay
                //sql += " and c.ngay is null";
                if (makp.SelectedIndex != -1 && chkToanvien.Checked == false) sql += " and b.makp='" + makp.SelectedValue.ToString() + "'"; ;
                if (cmbNgheNghiep.SelectedIndex != -1) sql += " and a.mann='" + cmbNgheNghiep.SelectedValue.ToString() + "'";
                sql += " and (m.sudung is null or m.sudung=1) and to_date(to_char(b.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi')<=to_date('" + ngaysrv + "','dd/mm/yyyy hh24:mi')";
                sql += " order by b.makp,b.ngay desc";
            }
			ds=m.get_data(sql);
            ds.Tables[0].Columns.Add("thuoc", typeof(decimal));
            ds.Tables[0].Columns.Add("ngaydt", typeof(decimal));
            int ithuoc = 1;
            //m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvv.Text.Substring(0, 10)), 1).ToString();
            string ngayvv = "";
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ngayvv = r["ngay"].ToString();
                if (chkThuoc.Checked)
                {
                    ithuoc = (d.get_data_mmyy_dec("select * from xxx.v_chidinh where mabn='" + r["mabn"].ToString() + "' and maql=" + decimal.Parse(r["maql"].ToString()) + " and idkhoa=" + decimal.Parse(r["id"].ToString()), r["ngay"].ToString().Substring(0, 10), ngaysrv.Substring(0, 10), false)) ? 1 : 0;
                    if (ithuoc == 0)
                    {
                        sql = "select a.id from xxx.d_dutrull a,xxx.d_dutruct b where a.id=b.id and a.mabn='" + r["mabn"].ToString() + "' and a.maql=" + decimal.Parse(r["maql"].ToString()) + " and a.idkhoa=" + decimal.Parse(r["id"].ToString());
                        sql += " union all ";
                        sql += "select a.id from xxx.d_xtutrucll a,xxx.d_xtutrucct b where a.id=b.id and a.mabn='" + r["mabn"].ToString() + "' and a.maql=" + decimal.Parse(r["maql"].ToString()) + " and a.idkhoa=" + decimal.Parse(r["id"].ToString());
                        ithuoc = (d.get_data_mmyy_dec(sql, r["ngay"].ToString().Substring(0, 10), ngaysrv.Substring(0, 10), true)) ? 1 : 0;
                    }
                }
                r["thuoc"] = ithuoc;
                r["ngaydt"] = m.songay(m.StringToDate(ngaysrv.Substring(0,10)), m.StringToDate(ngayvv.Substring(0, 10)), 0).ToString();//gam 28/11/2011
            }                
			dataGrid1.DataSource=ds.Tables[0];
			lbl.Text=lan.Change_language_MessageText("TỔNG SỐ HIỆN DIỆN : ")+ds.Tables[0].Rows.Count.ToString();
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
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
			ts.RowHeaderWidth=10;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "khoa";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
            TextCol.Width = dataGrid1.Width - 635;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "phai";
			TextCol.HeaderText = "Giới tính";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày vào khoa";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Nơi chuyển";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "tennn";
            TextCol.HeaderText = "Nghề nghiệp";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 8);
            TextCol.MappingName = "doituong";
            TextCol.HeaderText = "Đối tượng";
            TextCol.Width = 70;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 9);
            TextCol.MappingName = "sothe";
            TextCol.HeaderText = "Số thẻ";
            TextCol.Width = 80;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 10);
            TextCol.MappingName = "traituyen";
            TextCol.HeaderText = "Trái tuyến";
            TextCol.Width = 50;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 11);
            TextCol.MappingName = "giuong";
            TextCol.HeaderText = "Giường";
            TextCol.Width = 65;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 12);
            TextCol.MappingName = "tengiuong";
            TextCol.HeaderText = "Tên giường";
            TextCol.Width = 100;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 13);
            TextCol.MappingName = "ngayvaovien";
            TextCol.HeaderText = "Ngày vào viện";
            TextCol.Width = 100;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 14);
            TextCol.MappingName = "thuoc";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 15);
            TextCol.MappingName = "tamung";
            TextCol.HeaderText = "Tạm ứng";
            TextCol.Format = "###,###,###,##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.NullText = string.Empty;
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 16);//gam 28/11/2011
            TextCol.MappingName = "ngaydt";
            TextCol.HeaderText = "Số ngày điều trị";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 17);//thuy 24.03.2012
            TextCol.MappingName = "maicd";
            TextCol.HeaderText = "Mã ICD";
            TextCol.Width = 50;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 18);//thuy 24.03.2012
            TextCol.MappingName = "chandoan";
            TextCol.HeaderText = "Chẩn đoán";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 18);//thuy 24.03.2012
            TextCol.MappingName = "tuoi";
            TextCol.HeaderText = "Tuổi";
            TextCol.Width = 200;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
            
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (dataGrid1[row,10].ToString()=="0")?Color.Red:Color.Black;
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
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void butInReport_Click(object sender, System.EventArgs e)
		{
            dllReportM.frmReport f ;
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				return;
			}
			string msg;
			if (makp.SelectedIndex!=-1 && chkToanvien.Checked==false) msg="Khoa "+" "+makp.Text.ToString();
			else msg="Toàn viện";
            if (!System.IO.Directory.Exists("..\\..\\dataxml")) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
            ds.WriteXml("..\\..\\dataxml\\dshiendien.xml");
            if(tmn_hienthingayvaovien.Checked ) f = new dllReportM.frmReport(m,ds,msg,"dshiendien_ngayvv.rpt");
			else f = new dllReportM.frmReport(m,ds,msg,"dshiendien.rpt");
			f.Show();
		}

		private void frmHiendien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
			load_grid();
            Cursor = Cursors.Default;
		}

        private void makp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == makp) load_phong();
        }

        private void chkHientai_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkHientai) tu.Enabled = den.Enabled = chktheogio.Enabled = !chkHientai.Checked;
        }

        private void chkHientai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void chkThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkThuoc) m.writeXml("thongso", "hiendienthuoc", (chkThuoc.Checked) ? "1" : "0");
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
            }						
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void chkToanvien_CheckedChanged(object sender, EventArgs e)
        {
            makp.Enabled = !chkToanvien.Checked;
        }

        private void Tao_view_tamumg(int i_limit)
        {
            if(i_limit==0) i_limit=6;
            string s_user= m.user ;
            sql = "select mmyy from " + s_user + ".table order by substr(mmyy,3,2) desc, substr(mmyy,1,2) desc limit " + i_limit;
            DataSet lds = m.get_data(sql);
            string sql_v = " create or replace view " + s_user + ".vv_tamung_" + m.get_dmcomputer(System.Environment.MachineName).ToString().PadLeft(4, '0')+" as ";
            string sql_v1 = "";
            foreach (DataRow r1 in lds.Tables[0].Rows)
            {
                if (f_kiemtra_db_exist(r1["mmyy"].ToString(), "v_tamung"))
                {
                    sql_v1 += (sql_v1 == "") ? "" : "union all ";
                    sql_v1 += " select mabn, mavaovien, sum(sotien) as sotien from " + s_user + r1["mmyy"].ToString() + ".v_tamung a where done=0 ";
                    sql_v1 += " group by mabn, mavaovien ";
                }
            }
            sql_v += " select mabn, mavaovien, sum(sotien) as sotien from (" + sql_v1 + ") v_tu group by mabn, mavaovien ";
            m.execute_data(sql_v);
        }

        private void tmn_hienthitamung_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso","hiendien_tamung", tmn_hienthitamung.Checked ? "1" : "0");
            Tao_view_tamumg(6);
            load_grid();
        }
        private bool f_kiemtra_db_exist(string mmyy, string s_table)
        {
            try
            {
                sql = "select tablename from pg_tables where schemaname='" + m.user + mmyy + "' and tablename='" + s_table + "'";
                return m.get_data(sql).Tables[0].Rows.Count > 0;
            }
            catch { return false; }
        }

        private void tmn_hienthitenphonggiuong_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "hiendien_phonggiuong", tmn_hienthitenphonggiuong.Checked ? "1" : "0");
            //Tao_view_tamumg(7);
            load_grid();
        }

        private void tmn_hienthingayvaovien_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "hiendien_ngayvaovien", tmn_hienthingayvaovien.Checked ? "1" : "0");
            //Tao_view_tamumg(7);
            load_grid();
        }
	}
}
