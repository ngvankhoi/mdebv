using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibVP;
using System.Data;

namespace Vienphi
{
	/// <summary>
	/// Summary description for frmKhoasolieu.
	/// </summary>
	public class frmKhoasolieu : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibVP.AccessData m_v = new LibVP.AccessData();
		private System.Windows.Forms.Panel pButton;
        private System.Windows.Forms.Button butKetthuc;
        private System.Windows.Forms.Button butLuu;
        private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DateTimePicker txtNgay;
		private System.Windows.Forms.Label lbKS_Hienhanh;
		private System.Windows.Forms.Label lbKS_All;
		private System.Windows.Forms.Label lbKKS_Hienhanh;
		private System.Windows.Forms.Label lbKKS_All;
		private System.Windows.Forms.Label lbTD_Hienhanh;
		private System.Windows.Forms.Label lbTD_All;
		private System.Windows.Forms.NumericUpDown txtSongay;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKhoasolieu()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoasolieu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pButton = new System.Windows.Forms.Panel();
            this.txtSongay = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbTD_Hienhanh = new System.Windows.Forms.Label();
            this.lbTD_All = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbKKS_Hienhanh = new System.Windows.Forms.Label();
            this.lbKKS_All = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbKS_Hienhanh = new System.Windows.Forms.Label();
            this.lbKS_All = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSongay)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pButton
            // 
            this.pButton.Controls.Add(this.txtSongay);
            this.pButton.Controls.Add(this.groupBox3);
            this.pButton.Controls.Add(this.txtNgay);
            this.pButton.Controls.Add(this.groupBox2);
            this.pButton.Controls.Add(this.groupBox1);
            this.pButton.Controls.Add(this.butKetthuc);
            this.pButton.Controls.Add(this.butLuu);
            this.pButton.Controls.Add(this.butBoqua);
            this.pButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.pButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pButton.Location = new System.Drawing.Point(2, 325);
            this.pButton.Name = "pButton";
            this.pButton.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.pButton.Size = new System.Drawing.Size(690, 86);
            this.pButton.TabIndex = 111;
            // 
            // txtSongay
            // 
            this.txtSongay.Location = new System.Drawing.Point(482, 6);
            this.txtSongay.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtSongay.Name = "txtSongay";
            this.txtSongay.Size = new System.Drawing.Size(47, 20);
            this.txtSongay.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbTD_Hienhanh);
            this.groupBox3.Controls.Add(this.lbTD_All);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(355, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 73);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Khoá sổ tự động sau:                      ngày";
            // 
            // lbTD_Hienhanh
            // 
            this.lbTD_Hienhanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTD_Hienhanh.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.lbTD_Hienhanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTD_Hienhanh.Location = new System.Drawing.Point(8, 20);
            this.lbTD_Hienhanh.Name = "lbTD_Hienhanh";
            this.lbTD_Hienhanh.Size = new System.Drawing.Size(112, 22);
            this.lbTD_Hienhanh.TabIndex = 10;
            this.lbTD_Hienhanh.Text = "      Dòng đang chọn";
            this.lbTD_Hienhanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTD_Hienhanh.Click += new System.EventHandler(this.lbTD_Hienhanh_Click);
            // 
            // lbTD_All
            // 
            this.lbTD_All.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTD_All.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.lbTD_All.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTD_All.Location = new System.Drawing.Point(8, 42);
            this.lbTD_All.Name = "lbTD_All";
            this.lbTD_All.Size = new System.Drawing.Size(72, 22);
            this.lbTD_All.TabIndex = 11;
            this.lbTD_All.Text = "     Tất cả";
            this.lbTD_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTD_All.Click += new System.EventHandler(this.lbTD_All_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(56, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "(0: không tự động khoá sổ)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNgay
            // 
            this.txtNgay.CustomFormat = "dd/MM/yyyy";
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgay.Location = new System.Drawing.Point(96, 6);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(88, 20);
            this.txtNgay.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbKKS_Hienhanh);
            this.groupBox2.Controls.Add(this.lbKKS_All);
            this.groupBox2.Location = new System.Drawing.Point(201, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 73);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Không khoá sổ";
            // 
            // lbKKS_Hienhanh
            // 
            this.lbKKS_Hienhanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbKKS_Hienhanh.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.lbKKS_Hienhanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbKKS_Hienhanh.Location = new System.Drawing.Point(8, 20);
            this.lbKKS_Hienhanh.Name = "lbKKS_Hienhanh";
            this.lbKKS_Hienhanh.Size = new System.Drawing.Size(112, 22);
            this.lbKKS_Hienhanh.TabIndex = 10;
            this.lbKKS_Hienhanh.Text = "      Dòng đang chọn";
            this.lbKKS_Hienhanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbKKS_Hienhanh.Click += new System.EventHandler(this.lbKKS_Hienhanh_Click);
            // 
            // lbKKS_All
            // 
            this.lbKKS_All.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbKKS_All.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.lbKKS_All.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbKKS_All.Location = new System.Drawing.Point(8, 42);
            this.lbKKS_All.Name = "lbKKS_All";
            this.lbKKS_All.Size = new System.Drawing.Size(72, 22);
            this.lbKKS_All.TabIndex = 11;
            this.lbKKS_All.Text = "     Tất cả";
            this.lbKKS_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbKKS_All.Click += new System.EventHandler(this.lbKKS_All_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbKS_Hienhanh);
            this.groupBox1.Controls.Add(this.lbKS_All);
            this.groupBox1.Location = new System.Drawing.Point(1, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 73);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khoá sổ từ ngày:";
            // 
            // lbKS_Hienhanh
            // 
            this.lbKS_Hienhanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbKS_Hienhanh.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.lbKS_Hienhanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbKS_Hienhanh.Location = new System.Drawing.Point(6, 22);
            this.lbKS_Hienhanh.Name = "lbKS_Hienhanh";
            this.lbKS_Hienhanh.Size = new System.Drawing.Size(112, 22);
            this.lbKS_Hienhanh.TabIndex = 8;
            this.lbKS_Hienhanh.Text = "      Dòng đang chọn";
            this.lbKS_Hienhanh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbKS_Hienhanh.Click += new System.EventHandler(this.lbKS_Hienhanh_Click);
            // 
            // lbKS_All
            // 
            this.lbKS_All.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbKS_All.Image = global::Vienphi.Properties.Resources.t_chon_5;
            this.lbKS_All.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbKS_All.Location = new System.Drawing.Point(6, 44);
            this.lbKS_All.Name = "lbKS_All";
            this.lbKS_All.Size = new System.Drawing.Size(72, 22);
            this.lbKS_All.TabIndex = 9;
            this.lbKS_All.Text = "     Tất cả";
            this.lbKS_All.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbKS_All.Click += new System.EventHandler(this.lbKS_All_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(604, 56);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(604, 2);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 3;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.butBoqua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(604, 29);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 4;
            this.butBoqua.Text = "    &Bỏ qua";
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(690, 3);
            this.label1.TabIndex = 114;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.ForestGreen;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(2, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(690, 28);
            this.toolStrip1.TabIndex = 115;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(270, 25);
            this.toolStripLabel1.Text = "KHOÁ SỐ LIỆU VIỆN PHÍ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(2, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(690, 292);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 116;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "id";
            this.Column5.HeaderText = "id";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 40;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "hoten";
            this.Column1.HeaderText = "Họ và tên gnười dùng";
            this.Column1.Name = "Column1";
            this.Column1.Width = 350;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "userid";
            this.Column2.HeaderText = "Tên đăng nhập";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "ngay";
            this.Column3.HeaderText = "Khoá sổ từ ngày";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.DataPropertyName = "songay";
            this.Column4.HeaderText = "Số ngày khoá sổ";
            this.Column4.Name = "Column4";
            // 
            // frmKhoasolieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(694, 413);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhoasolieu";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khoá số liệu báo cáo viện phí";
            this.Load += new System.EventHandler(this.frmKhoasolieu_Load);
            this.SizeChanged += new System.EventHandler(this.frmKhoasolieu_SizeChanged);
            this.pButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSongay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmKhoasolieu_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtNgay.Value=m_v.s_server_date;
				m_v.execute_data("insert into medibv.v_khoaso(userid,ngay,songay) select id,'xx/xx/xxxx',0 from medibv.v_dlogin where id not in (select userid from medibv.v_khoaso)");
				f_Load_DG();
			}
			catch
			{
			}
		}
		private void f_Load_DG()
		{
			try
			{			
                dataGridView1.DataSource=m_v.get_data("select b.id,b.hoten, b.userid , a.ngay, a.songay from medibv.v_khoaso a left join medibv.v_dlogin b on b.id=a.userid order by b.hoten").Tables[0];
                
			}
			catch
			{
			}
		}					
		private void lbKS_Hienhanh_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
                dv.AllowNew = false;
                dv.AllowEdit = false;
                dv.AllowDelete = false;				
                
                foreach (DataRow r in dv.Table.Select("id=" + dv.Table.Rows[dataGridView1.CurrentRow.Index]["id"].ToString() + ""))
                {
                    r["ngay"] = txtNgay.Text;
                    r["songay"] = 0;
                }
			}
			catch
			{
			}
		}

		private void lbKS_All_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;
				foreach(DataRow  r in dv.Table.Rows)
				{
					r["ngay"]=txtNgay.Text;
					r["songay"]=0;
				}
			}
			catch
			{
			}
		}

		private void lbKKS_All_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;
				foreach(DataRow  r in dv.Table.Rows)
				{
					r["ngay"]="xx/xx/xxxx";
					r["songay"]=0;
				}
			}
			catch
			{
			}
		}
		private void lbKKS_Hienhanh_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;				
                foreach (DataRow r in dv.Table.Select("id=" + dv.Table.Rows[dataGridView1.CurrentRow.Index]["id"].ToString() + "")) 
				{
					r["ngay"]="xx/xx/xxxx";
					r["songay"]=0;
				}
			}
			catch
			{
			}
		}
		private void lbTD_All_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;
				string angay="";
				DateTime adt = m_v.s_server_date;
				adt=adt.AddDays(int.Parse(txtSongay.Value.ToString())*-1);
				angay=adt.Day.ToString().PadLeft(2,'0')+"/"+adt.Month.ToString().PadLeft(2,'0')+"/"+adt.Year.ToString();
				foreach(DataRow  r in dv.Table.Rows)
				{
					r["ngay"]=angay;
					r["songay"]=txtSongay.Value.ToString();
				}
			}
			catch
			{
			}
		}

		private void lbTD_Hienhanh_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;
				string angay="";
				DateTime adt = m_v.s_server_date;
				adt=adt.AddDays(int.Parse(txtSongay.Value.ToString())*-1);
				angay=adt.Day.ToString().PadLeft(2,'0')+"/"+adt.Month.ToString().PadLeft(2,'0')+"/"+adt.Year.ToString();
                foreach (DataRow r in dv.Table.Select("id=" + dv.Table.Rows[dataGridView1.CurrentRow.Index]["id"].ToString() + ""))
				{
					r["ngay"]=angay;
					r["songay"]=txtSongay.Value.ToString();
				}
			}
			catch
			{
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			f_Load_DG();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource, dataGridView1.DataMember];
				DataView dv = (DataView)cm.List;
				dv.AllowNew=false;
				dv.AllowEdit=false;
				dv.AllowDelete=false;
				m_v.execute_data("delete from medibv.v_khoaso");
				foreach(DataRow r in dv.Table.Rows)
				{
					m_v.execute_data("insert into medibv.v_khoaso(userid,ngay,songay) values("+r["id"].ToString()+",'"+r["ngay"].ToString()+"',"+r["songay"].ToString()+")");
				}
                m_v.f_upd_v_khoaso();               
			}
			catch
			{
			}
		}

		private void frmKhoasolieu_SizeChanged(object sender, System.EventArgs e)
		{
			//f_ResizeDG(dataGrid0,1);
		}		        
	}
}
