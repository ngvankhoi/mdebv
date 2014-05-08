using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using LibMedi;
using Excel;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSoluutruhosobenhan.
	/// </summary>
	public class txtSoBenhAn : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m = new LibMedi.AccessData();
		private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private DataSet ads,ads1;
		private DataRow r2;
		private DataColumn dc;
		private string haison="",sql="",tenfile="",user;
		private Excel.Application oxl;
		private Excel._Workbook owb;
		private Excel._Worksheet osheet;
		private Excel.Range orange;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbKhoa;
		private System.Windows.Forms.Button btTonghop;
        private System.Windows.Forms.Button butKetthuc;
        private DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btReport;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.CheckBox chkPhatQua;
        private System.Windows.Forms.Button button1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn benhan;
        private DataGridViewTextBoxColumn hoten;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column21;
        private DataGridViewTextBoxColumn Column22;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column19;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column18;
        private DataGridViewTextBoxColumn Column20;
        private DataGridViewTextBoxColumn Column23;
        private DataGridViewTextBoxColumn Column24;
        private DataGridViewTextBoxColumn Column25;
        private DataGridViewTextBoxColumn Column26;
        private DataGridViewTextBoxColumn Column27;
        private DataGridViewTextBoxColumn Column28;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public txtSoBenhAn()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(txtSoBenhAn));
            this.label1 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.chkPhatQua = new System.Windows.Forms.CheckBox();
            this.btExcel = new System.Windows.Forms.Button();
            this.btReport = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.btTonghop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.benhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(49, 18);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(86, 20);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(177, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(207, 19);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(86, 20);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbKhoa
            // 
            this.cbKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKhoa.Location = new System.Drawing.Point(357, 19);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(329, 21);
            this.cbKhoa.TabIndex = 2;
            this.cbKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column5,
            this.benhan,
            this.hoten,
            this.Column6,
            this.Column7,
            this.Column21,
            this.Column22,
            this.Column17,
            this.Column19,
            this.Column15,
            this.Column4,
            this.Column9,
            this.Column2,
            this.Column8,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column16,
            this.Column18,
            this.Column20,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 69);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(702, 357);
            this.dataGridView1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(153, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tìm kiếm:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.Location = new System.Drawing.Point(207, 44);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(479, 20);
            this.txtTim.TabIndex = 5;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txthoten_KeyDown);
            // 
            // chkPhatQua
            // 
            this.chkPhatQua.Location = new System.Drawing.Point(49, 43);
            this.chkPhatQua.Name = "chkPhatQua";
            this.chkPhatQua.Size = new System.Drawing.Size(126, 16);
            this.chkPhatQua.TabIndex = 95;
            this.chkPhatQua.Text = "Phát quà thôi nôi";
            this.chkPhatQua.CheckedChanged += new System.EventHandler(this.chkPhatQua_CheckedChanged);
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcel.ForeColor = System.Drawing.Color.Black;
            this.btExcel.Image = ((System.Drawing.Image)(resources.GetObject("btExcel.Image")));
            this.btExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcel.Location = new System.Drawing.Point(433, 445);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(84, 25);
            this.btExcel.TabIndex = 7;
            this.btExcel.Text = "   &Excel";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btReport
            // 
            this.btReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReport.ForeColor = System.Drawing.Color.Black;
            this.btReport.Image = global::Medisoft.Properties.Resources.chonkhoa;
            this.btReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReport.Location = new System.Drawing.Point(518, 445);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(84, 25);
            this.btReport.TabIndex = 8;
            this.btReport.Text = "   &Report";
            this.btReport.Click += new System.EventHandler(this.btReport_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Black;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(603, 445);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(84, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // btTonghop
            // 
            this.btTonghop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btTonghop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btTonghop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTonghop.ForeColor = System.Drawing.Color.Black;
            this.btTonghop.Image = global::Medisoft.Properties.Resources.ok;
            this.btTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTonghop.Location = new System.Drawing.Point(263, 445);
            this.btTonghop.Name = "btTonghop";
            this.btTonghop.Size = new System.Drawing.Size(84, 25);
            this.btTonghop.TabIndex = 6;
            this.btTonghop.Text = "  &Tổng hợp";
            this.btTonghop.Click += new System.EventHandler(this.butIN_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(348, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 25);
            this.button1.TabIndex = 96;
            this.button1.Text = "   &Excel";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "stt";
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "mabn";
            this.Column3.HeaderText = "Mã BN";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "sovaovien";
            this.Column5.HeaderText = "Số vào viện";
            this.Column5.Name = "Column5";
            // 
            // benhan
            // 
            this.benhan.DataPropertyName = "benhan";
            this.benhan.HeaderText = "Thuộc bệnh án";
            this.benhan.Name = "benhan";
            this.benhan.Width = 130;
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "hoten";
            this.hoten.HeaderText = "Họ tên";
            this.hoten.Name = "hoten";
            this.hoten.Width = 170;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "nam";
            this.Column6.HeaderText = "Nam";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "nu";
            this.Column7.HeaderText = "Nữ";
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "CDvao";
            this.Column21.HeaderText = "CD vào";
            this.Column21.Name = "Column21";
            this.Column21.Width = 150;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "CDra";
            this.Column22.HeaderText = "CD ra";
            this.Column22.Name = "Column22";
            this.Column22.Width = 150;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "vaovien";
            this.Column17.HeaderText = "Vào viện";
            this.Column17.Name = "Column17";
            this.Column17.Width = 80;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "ravien";
            this.Column19.HeaderText = "Ra viện";
            this.Column19.Name = "Column19";
            this.Column19.Width = 80;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "diachi";
            this.Column15.HeaderText = "Địa chỉ";
            this.Column15.Name = "Column15";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "dienthoai";
            this.Column4.HeaderText = "Điện thoại";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "bhyt";
            this.Column9.HeaderText = "Có BHYT";
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "soluutru";
            this.Column2.HeaderText = "Số lưu trữ";
            this.Column2.Name = "Column2";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CVC";
            this.Column8.HeaderText = "Công nhân viên";
            this.Column8.Name = "Column8";
            this.Column8.Width = 130;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "thanhthi";
            this.Column10.HeaderText = "Thành thị";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "nongthon";
            this.Column11.HeaderText = "Nông thôn";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "TEduoi12";
            this.Column12.HeaderText = "TE < 12 tháng";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "TE1-15";
            this.Column13.HeaderText = "TE 1-15 tuổi";
            this.Column13.Name = "Column13";
            this.Column13.Width = 80;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "nghenghiep";
            this.Column14.HeaderText = "Nghề nghiệp";
            this.Column14.Name = "Column14";
            this.Column14.Width = 120;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "noigioithieu";
            this.Column16.HeaderText = "Nơi giới thiệu";
            this.Column16.Name = "Column16";
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "chuyenvien";
            this.Column18.HeaderText = "Chuyển viện";
            this.Column18.Name = "Column18";
            this.Column18.Width = 80;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "CDGioithieu";
            this.Column20.HeaderText = "CD giới thiệu";
            this.Column20.Name = "Column20";
            this.Column20.Width = 150;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "kq_1";
            this.Column23.HeaderText = "Khỏi";
            this.Column23.Name = "Column23";
            this.Column23.Width = 30;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "kq_2";
            this.Column24.HeaderText = "Đỡ, giảm";
            this.Column24.Name = "Column24";
            this.Column24.Width = 80;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "kq_3";
            this.Column25.HeaderText = "Không thay đổi";
            this.Column25.Name = "Column25";
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "kq_4";
            this.Column26.HeaderText = "Nặng hơn";
            this.Column26.Name = "Column26";
            this.Column26.Width = 50;
            // 
            // Column27
            // 
            this.Column27.DataPropertyName = "kq_5";
            this.Column27.HeaderText = "Tử vong";
            this.Column27.Name = "Column27";
            this.Column27.Width = 50;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "phatqua";
            this.Column28.HeaderText = "Phát quà";
            this.Column28.Name = "Column28";
            this.Column28.Visible = false;
            // 
            // txtSoBenhAn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(698, 482);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkPhatQua);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btReport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.btTonghop);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "txtSoBenhAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ lưu trữ hồ sơ bệnh án";
            this.Load += new System.EventHandler(this.frmSoluutruhosobenhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Taotable()
		{
			try
			{
				ads = new DataSet();
				haison = "";
				ads.ReadXml("..//..//..//xml//m_hosobenhan.xml");
                ads.Tables[0].Columns.Add("dienthoai");
                haison = "STT+Số lưu trữ+Mã BN+Thuộc bệnh án+Họ tên+Nam+Nữ+Công nhân viên+Có BHYT+Thành thị+Nông thôn+TE <12 tháng+TE 1-15 tuổi+Nghề nghiệp+Địa chỉ+Nơi giới thiệu+Vào viện+Chuyển viện+ra viện+CD giới thiệu+CD vào+CD Ra+";//Khuong 02/12/2011
                ads1 = m.get_data("select * from " + user + ".ketqua");
				foreach (DataRow r in ads1.Tables[0].Rows)
				{
					haison += r["ten"].ToString() + "+";
					dc = new DataColumn();
					dc.ColumnName = "kq_" + r["ma"].ToString();
					dc.DataType = Type.GetType("System.String");
					ads.Tables[0].Columns.Add(dc);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
        //gam 23/02/2012

		private void exp_excel(bool print, DataSet ads1)
		{
			try
			{
				d.check_process_Excel();
				int i_rec = 0, be = 4, dong = 6, sodong = ads1.Tables[0].Rows.Count + 6, socot = ads1.Tables[0].Columns.Count - 1, dongke = sodong - 1;
				char[] cSplit ={ '+' };
				string[] sTitle = haison.Split(cSplit);
				i_rec = sTitle.Length;
				tenfile = d.Export_Excel(ads1, "HOSOBENHAN");
				oxl = new Excel.Application();

				owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
				osheet = (Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines = true;

				for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(0) + "5", d.getIndex(0) + "5").EntireRow.Delete(Missing.Value);//remove row field
				osheet.get_Range(d.getIndex(0) + "4", d.getIndex(socot) + dongke.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                
				for (int i = 0; i < i_rec; i++)
				{
					osheet.Cells[dong - 2, i + 1] = sTitle[i].ToString();

				}
				orange = osheet.get_Range(d.getIndex(i_rec * 2 + 4) + "4", d.getIndex(i_rec * 2 + 5) + "4");
				orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Bold = true;
				orange = osheet.get_Range(d.getIndex(0) + "1", d.getIndex(socot) + sodong.ToString());
				orange.Font.Name = "Arial";
				orange.Font.Size = 8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros = false;
//				osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
//				osheet.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
//				osheet.PageSetup.LeftMargin = 20;
//				osheet.PageSetup.RightMargin = 20;
//				osheet.PageSetup.TopMargin = 30;
//				osheet.PageSetup.CenterFooter = "Trang : &P/&N";
				osheet.Cells[1, 1] = d.Syte; osheet.Cells[2, 1] = d.Tenbv;
				orange = osheet.get_Range(d.getIndex(1) + "1", d.getIndex(3) + "2");
				orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

				osheet.Cells[1, 8] = "SỔ LƯU TRỮ HỒ SƠ BỆNH ÁN";
				osheet.Cells[2, 8] = (tu.Text == den.Text) ? "Tháng " + tu.Text : "Từ ngày " + tu.Text + " đến ngày" + den.Text;
				orange = osheet.get_Range(d.getIndex(3) + "1", d.getIndex(socot - 1) + "2");

				orange.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size = 12;
				orange.Font.Bold = true;
				if (print) osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
				else oxl.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void frmSoluutruhosobenhan_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			cbKhoa.DisplayMember = "TENKP";
			cbKhoa.ValueMember = "MAKP";
            chkPhatQua.Visible = m.bPhatQuaKhiXuatKhoa;//gam 11/04/2012
            cbKhoa.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=0 order by makp").Tables[0];
            butIN_Click(null, null);//gam 10/01/2012
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{Tab}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			if(ads != null && ads.Tables[0].Rows.Count>0)
			{
				if(DialogResult.No == MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn tổng hợp lại không ?"),this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
					return;
			}
			DataSet ds= new DataSet();
			Taotable();
			int stt = 1;
            string stime = "'" + m.f_ngay + "'";
            sql = "select b.maql,a.mabn,cc.ten as benhan,c.soluutru,a.hoten,case when a.phai=0 then a.namsinh else '' end as nam,case when a.phai=0 then '' else a.namsinh end as nu,";
			sql += " h.sothe,a.mann,g.tennn as nghenghiep,trim(a.sonha)||' '||trim(a.thon)||' '||trim(f.tenpxa)||','||trim(e.tenquan)||','||trim(d.tentt) as diachi,";
			sql += " j.tenbv as noigioithieu,to_char(b.ngay,'dd/mm/yyyy hh24:mi')as ngayvao,to_char(c.ngay,'dd/mm/yyyy hh24:mi')as ngayra,i.maicd as icd_noigioithieu,n.vviet as cd_noigioithieu,b.chandoan as cd_vao,b.maicd as maicd_vao,c.chandoan as cd_ra,c.maicd as maicd_ra";
            sql += " ,substr(m.tuoivao,1,3)||case when substr(m.tuoivao,4,1)=0 then 'TU' else case when substr(m.tuoivao,4,1)=1 then 'TH' ";
            sql += "else case when substr(m.tuoivao,4,1)=2 then 'NG' else 'GI' end end end as tuoi,c.ketqua,ttlucrv";
            sql += ",case when k.didong<>'' then k.didong else (case when k.nha <>'' then k.nha else k.coquan end ) end as dienthoai ";
            sql += ",c.phatqua,c.ngaythoinoi,b.sovaovien";
            sql += " from " + user + ".btdbn a inner join " + user + ".benhandt b on a.mabn=b.mabn inner join " + user + 
                ".xuatvien c on b.maql=c.maql inner join (select max(id) as maxid,maql from " + user + 
                ".nhapkhoa group by maql) ca on c.maql=ca.maql inner join " + user + ".nhapkhoa cb on ca.maxid=cb.id inner join " + user + 
                ".dmbenhan cc on cb.maba=cc.maba inner join " + user + ".btdtt d on a.matt=d.matt inner join " + user + 
                ".btdquan e on a.maqu=e.maqu inner join " + user + ".btdpxa f on a.maphuongxa=f.maphuongxa inner join " + user + 
                ".btdnn_bv g on a.mann=g.mann left join " + user + ".bhyt h on b.maql=h.maql left join " + user + 
                ".noigioithieu i on b.maql=i.maql left join " + user + ".dstt j on i.mabv=j.mabv left join " + user + 
                ".icd10 n on i.maicd=cicd10 inner join " + user + ".lienhe m on m.maql=c.maql";//Khuong 02/12/2011
            sql += " left join "+ user + ".dienthoai k on k.mabn=a.mabn ";
            sql += " where length(a.namsinh)=4 ";
            if (cbKhoa.SelectedIndex!=-1) sql += " and b.makp='" + cbKhoa.SelectedValue.ToString() + "'";
            sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + den.Text.Substring(0, 10) + "'," + stime + ")";
			sql += " order by c.soluutru";
			ds = m.get_data(sql);
			if( ds != null && ds.Tables[0].Rows.Count > 0 )
			{
				foreach (DataRow r in ds.Tables[0].Rows)
				{
                    try
                    {
                        ads.Tables[0].Columns.Add("sovaovien");
                        ads.Tables[0].Columns.Add("phatqua");
                         DataColumn cl = ads.Tables[0].Columns.Add("benhan");
                         cl.SetOrdinal(4);
                         
                    }
                    catch { }
					r2 = ads.Tables[0].NewRow();
					r2["stt"] = stt.ToString();
					r2["maql"] = r["maql"].ToString();
                    r2["benhan"] = r["benhan"].ToString(); //Khuong 02/12/2011
					r2["soluutru"] = r["soluutru"].ToString();
					r2["mabn"] = r["mabn"].ToString();
					r2["hoten"] = r["hoten"].ToString();
					r2["nam"] = r["nam"].ToString();
					r2["nu"] = r["nu"].ToString();
                    r2["dienthoai"] = r["dienthoai"].ToString();//gam 10/10/2012
                    r2["sovaovien"] = r["sovaovien"].ToString();//gam 11042012
                    r2["phatqua"] = r["phatqua"].ToString();//gam 11042012
					if (r["mann"].ToString() == "06" || r["mann"].ToString() == "07" || r["mann"].ToString() == "08" || r["mann"].ToString() == "09")
					{
						r2["CVC"] = "X";
					}
					else
					{
						r2["CVC"] = "";
					}

					if (r["sothe"].ToString() != "")
					{
						r2["bhyt"] = "X";
					}
					else
					{
						r2["bhyt"] = " ";
					}
					r2["thanhthi"] = "";
					if (r["mann"].ToString() == "05")
					{
						r2["nongthon"] = "X";
					}
					else
					{
						r2["nongthon"] = "";
					}          
					if (decimal.Parse(r["tuoi"].ToString().Substring(0, 3)) < 12 && r["tuoi"].ToString().Substring(3, 2) == "TH")
					{
						r2["TEduoi12"] = "X";
					}
					else
					{
						r2["TEduoi12"] = "";
					}

					if (decimal.Parse(r["tuoi"].ToString().Substring(0, 3)) <=15 && r["tuoi"].ToString().Substring(3, 2) == "TU")
					{
						r2["TE1-15"] = "X";
					}
					else
					{
						r2["TE1-15"] = "";
					}

					r2["nghenghiep"] = r["nghenghiep"].ToString();
					r2["diachi"] = r["diachi"].ToString();
					r2["noigioithieu"] = r["noigioithieu"].ToString();
					r2["vaovien"] = r["ngayvao"].ToString();
					if (r["ttlucrv"].ToString() == "6")
					{
						r2["Chuyenvien"] = r["ngayra"].ToString();
					}
					else
					{
						r2["Chuyenvien"] = "";
					}
					r2["ravien"] = r["ngayra"].ToString();
					r2["CDGioithieu"] = r["cd_noigioithieu"].ToString();
					r2["CDvao"] = r["cd_vao"].ToString();
					r2["CDra"] = r["cd_ra"].ToString();
					foreach (DataRow rr in ads1.Tables[0].Rows)
					{
						r2["kq_" + rr["ma"].ToString()] = "";
					}
					if (r["ketqua"].ToString() == "1")
					{
						r2["kq_1"] = "X";
					}
					if (r["ketqua"].ToString() == "2")
					{
						r2["kq_2"] = "X";
					}
					if (r["ketqua"].ToString() == "3")
					{
						r2["kq_3"] = "X";
					}
					if (r["ketqua"].ToString() == "4")
					{
						r2["kq_4"] = "X";
					}
					ads.Tables[0].Rows.Add(r2);
					stt += 1;
				}
				if(ads != null && ads.Tables[0].Rows.Count > 0)
				{
                    dataGridView1.DataSource = ads.Tables[0];//gam 09/01/2012
                    ads.Tables[0].Columns.Remove("maql");            
				}
			}
			else 
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),this.Text);
			}
			
		}

        private void btExcel_Click(object sender, EventArgs e)
        {
            DataSet ds = ads.Clone();
            string sText = txtTim.Text.Trim().Replace("'", "''");
            string aft = "hoten like '%" + sText + "%' or mabn like '%" + sText + "%' or soluutru like '%" + sText + "%'";
            ds.Merge(ads.Tables[0].Select(aft));
            if (ds != null )
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Remove("dienthoai");
                    exp_excel(false,ds);
                }
            }
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            DataSet ds = ads.Clone();
            string sText = txtTim.Text.Trim().Replace("'", "''");
            string aft = "hoten like '%" + sText + "%' or mabn like '%" + sText + "%' or soluutru like '%" + sText + "%'";
            ds.Merge(ads.Tables[0].Select(aft));
            ds.WriteXml("..//..//dataxml//hosobenhan.xml", XmlWriteMode.WriteSchema);
            dllReportM.frmReport f = new dllReportM.frmReport(m, ds.Tables[0],"hosobenhan.rpt", "", "SỔ LƯU TRỮ HỒ SƠ BỆNH ÁN", (tu.Text == den.Text) ? "Ngày " + tu.Text : "Từ ngày " + tu.Text + " đến " + den.Text, "", "","","", "", den.Text, "");
            f.ShowDialog(this);
        }

        private void txtsovaovien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtmabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txthoten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string sText = txtTim.Text.Trim().Replace("'", "''");
            string aft = "((hoten like '%" + sText + "%' or mabn like '%" + sText + "%' or soluutru like '%" + sText + "%' or sovaovien like '%" + sText + "%') ";
            if (chkPhatQua.Checked)
            {
                aft += " and phatqua=1 )";
            }
            else
            {
                aft += ")";
            }
            CurrencyManager cm = (CurrencyManager)(BindingContext[dataGridView1.DataSource, dataGridView1.DataMember]);
            DataView dv = (DataView)(cm.List);
            dv.RowFilter = aft;
        }

        private void chkPhatQua_CheckedChanged(object sender, EventArgs e)
        {
            txtTim_TextChanged(null, null);
        }
	}
}
