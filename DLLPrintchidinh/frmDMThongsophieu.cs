using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;
using LibMedi;

namespace DLLPrintchidinh
{
	/// <summary>
	/// Summary description for frmDMThongsophieucd.
	/// </summary>
	public class frmDMThongsophieu : System.Windows.Forms.Form
	{
		private string m_userid="";
		private string m_report="";
		private bool m_chosuacauhinh=true,bloai=false;
		private LibMedi.AccessData m_m = new LibMedi.AccessData();
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button butUnmap;
		private System.Windows.Forms.Button butMap;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.TextBox txtTim;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbReport;
		private System.Windows.Forms.Button butMay;
        private ComboBox cboloai;
        private Label label1;
        private CheckBox chkAll;
		private System.ComponentModel.IContainer components;

		public frmDMThongsophieu(string v_userid, string v_report)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_userid=v_userid;
			m_report=v_report;
			f_SetEvent(panel2);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public bool s_chosuacauhinh
		{
			get
			{
				return m_chosuacauhinh;
			}
			set
			{
				m_chosuacauhinh=value;
				butMay.Enabled=m_chosuacauhinh;
				butLuu.Enabled=true;
				butMap.Enabled=m_chosuacauhinh;
				butUnmap.Enabled=m_chosuacauhinh;
			}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMThongsophieu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butMay = new System.Windows.Forms.Button();
            this.butUnmap = new System.Windows.Forms.Button();
            this.butMap = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboloai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReport = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(748, 49);
            this.panel1.TabIndex = 16;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Green;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(1, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(744, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = " KHAI BÁO THÔNG SỐ PHIẾU CHỈ ĐỊNH";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lbTitle, " KHAI BÁO MÁY XÉT NGHIỆM");
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(748, 3);
            this.label15.TabIndex = 18;
            // 
            // butMay
            // 
            this.butMay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMay.BackColor = System.Drawing.SystemColors.Control;
            this.butMay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butMay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMay.ForeColor = System.Drawing.Color.Blue;
            this.butMay.Image = ((System.Drawing.Image)(resources.GetObject("butMay.Image")));
            this.butMay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMay.Location = new System.Drawing.Point(336, 9);
            this.butMay.Name = "butMay";
            this.butMay.Size = new System.Drawing.Size(16, 19);
            this.butMay.TabIndex = 159;
            this.butMay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.butMay, "Khai báo thêm máy");
            this.butMay.UseVisualStyleBackColor = false;
            this.butMay.Click += new System.EventHandler(this.butMay_Click);
            // 
            // butUnmap
            // 
            this.butUnmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butUnmap.BackColor = System.Drawing.SystemColors.Control;
            this.butUnmap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butUnmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUnmap.ForeColor = System.Drawing.Color.Navy;
            this.butUnmap.Image = ((System.Drawing.Image)(resources.GetObject("butUnmap.Image")));
            this.butUnmap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butUnmap.Location = new System.Drawing.Point(354, 91);
            this.butUnmap.Name = "butUnmap";
            this.butUnmap.Size = new System.Drawing.Size(67, 23);
            this.butUnmap.TabIndex = 2;
            this.butUnmap.Text = "   &Unmap";
            this.butUnmap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butUnmap.UseVisualStyleBackColor = false;
            this.butUnmap.Click += new System.EventHandler(this.butUnmap_Click);
            // 
            // butMap
            // 
            this.butMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMap.BackColor = System.Drawing.SystemColors.Control;
            this.butMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMap.ForeColor = System.Drawing.Color.Navy;
            this.butMap.Image = ((System.Drawing.Image)(resources.GetObject("butMap.Image")));
            this.butMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMap.Location = new System.Drawing.Point(354, 68);
            this.butMap.Name = "butMap";
            this.butMap.Size = new System.Drawing.Size(67, 23);
            this.butMap.TabIndex = 1;
            this.butMap.Text = "   &Map";
            this.butMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMap.UseVisualStyleBackColor = false;
            this.butMap.Click += new System.EventHandler(this.butMap_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackColor = System.Drawing.Color.White;
            this.dataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.Navy;
            this.dataGrid2.CaptionText = "File dữ liệu";
            this.dataGrid2.DataMember = "";
            this.dataGrid2.ForeColor = System.Drawing.Color.Navy;
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(419, 31);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 16;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid2.Size = new System.Drawing.Size(321, 339);
            this.dataGrid2.TabIndex = 3;
            this.dataGrid2.TabStop = false;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.BackColor = System.Drawing.SystemColors.Control;
            this.butIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.Color.Navy;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(568, 4);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(80, 28);
            this.butIn.TabIndex = 1;
            this.butIn.Text = "       &In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(648, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(80, 28);
            this.butKetthuc.TabIndex = 2;
            this.butKetthuc.Text = "  &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.BackColor = System.Drawing.SystemColors.Control;
            this.butLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.Color.Navy;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(488, 4);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(80, 28);
            this.butLuu.TabIndex = 0;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.White;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
            this.dataGrid1.CaptionText = "File dữ liệu";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.ForeColor = System.Drawing.Color.Navy;
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(4, 31);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 16;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid1.Size = new System.Drawing.Size(349, 339);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TabStop = false;
            this.dataGrid1.SizeChanged += new System.EventHandler(this.dataGrid1_SizeChanged);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Controls.Add(this.cboloai);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.butMay);
            this.panel2.Controls.Add(this.cbReport);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txtTim);
            this.panel2.Controls.Add(this.butUnmap);
            this.panel2.Controls.Add(this.butMap);
            this.panel2.Controls.Add(this.dataGrid2);
            this.panel2.Controls.Add(this.dataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(748, 418);
            this.panel2.TabIndex = 19;
            // 
            // cboloai
            // 
            this.cboloai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboloai.Location = new System.Drawing.Point(464, 9);
            this.cboloai.Name = "cboloai";
            this.cboloai.Size = new System.Drawing.Size(236, 21);
            this.cboloai.TabIndex = 160;
            this.cboloai.SelectedIndexChanged += new System.EventHandler(this.cboloai_SelectedIndexChanged);
            this.cboloai.Click += new System.EventHandler(this.cboloai_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(419, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 161;
            this.label1.Text = "Loại vp:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbReport
            // 
            this.cbReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReport.Location = new System.Drawing.Point(87, 9);
            this.cbReport.Name = "cbReport";
            this.cbReport.Size = new System.Drawing.Size(250, 21);
            this.cbReport.TabIndex = 158;
            this.cbReport.SelectedIndexChanged += new System.EventHandler(this.cbReport_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 157;
            this.label2.Text = "Phiếu chỉ định:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Green;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.butKetthuc);
            this.panel3.Controls.Add(this.butIn);
            this.panel3.Controls.Add(this.butLuu);
            this.panel3.Location = new System.Drawing.Point(4, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 37);
            this.panel3.TabIndex = 156;
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.BackColor = System.Drawing.Color.White;
            this.txtTim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(561, 32);
            this.txtTim.MaxLength = 100;
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(181, 20);
            this.txtTim.TabIndex = 4;
            this.txtTim.TabStop = false;
            this.txtTim.Tag = "";
            this.txtTim.Text = "Tìm kiếm";
            this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTim_KeyDown);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(706, 11);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 162;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_Click);
            // 
            // frmDMThongsophieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(754, 476);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDMThongsophieu";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Thông số phiếu chỉ định";
            this.Load += new System.EventHandler(this.frmDMThongsophieucd_Load);
            this.SizeChanged += new System.EventHandler(this.frmDMThongsophieucd_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDMThongsophieucd_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDMThongsophieucd_Load(object sender, System.EventArgs e)
		{
			f_Load_CB_Phieu();
			f_Load_DG1();
			f_Load_DG2();
			dataGrid1.Tag="";
			butMay.Enabled=m_chosuacauhinh;
			butLuu.Enabled=true;
			butMap.Enabled=m_chosuacauhinh;
			butUnmap.Enabled=m_chosuacauhinh;

            cboloai.DataSource = m_m.get_data("select * from medibv.v_loaivp order by id").Tables[0];
            cboloai.DisplayMember = "TEN";
            cboloai.ValueMember = "ID";
            cboloai.SelectedIndex = -1;
		}
		private void f_Load_DG1()
		{
			try
			{
				string areport="";
				try
				{
					areport=cbReport.SelectedValue.ToString();
				}
				catch
				{
					areport="";
				}
				DataSet ads = new DataSet();
				string asql="select a.id, a.mavp, b.ten tenvp, c.ten tenloai, d.ten tennhom from medibv.cd_thongsophieucd a, medibv.v_giavp b, medibv.v_loaivp c, medibv.v_nhomvp d where to_number(a.mavp)=b.id(+) and b.id_loai=c.id and c.id_nhom=d.ma(+) and lower(trim(a.report))=lower('"+areport.Trim()+"') order by id";
				ads = m_m.get_data(asql);
				try
				{
					string atmp = ads.Tables[0].TableName;
				}
				catch
				{
					m_m.execute_data("CREATE TABLE medibv.cd_thongsophieucd( id text, report text, mavp text, val text) WITHOUT OIDS;ALTER TABLE medibv.cd_thongsophieucd OWNER TO medisoft;");
					ads=m_m.get_data(asql);
				}

				AddGridTableStyle1(ads);
				f_resizeDG1();
			}
			catch
			{
			}
		}
		private void f_Load_DG2()
		{
			try
			{
                AddGridTableStyle2(m_m.get_data("select to_char(a.id) id, a.ma, a.ten, b.ten ten_loai, c.ten "+
                    "ten_nhom from medibv.v_giavp a, medibv.v_loaivp b, medibv.v_nhomvp c where a.id_loai=b.id "+
                    "and b.id_nhom=c.ma and a.id not in (select to_number(mavp) from medibv.cd_thongsophieucd) "+
                    "order by a.ten, b.ten,c.ten"));
				f_resizeDG2();
			}
			catch
			{
			}
		}
		private void f_print()
		{
			try
			{
				
				string sql="select * from medibv.cd_thongsophieucd order by report";					
				DataSet ds=m_m.get_data(sql);
			
				//ds.WriteXml("D:\\DMSo.xml",XmlWriteMode.WriteSchema);
				if(ds.Tables[0].Rows.Count>0)
				{
					CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
					crystalReportViewer1.ActiveViewIndex = -1;
					crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
					crystalReportViewer1.DisplayGroupTree = false;
					crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
					crystalReportViewer1.Name = "crystalReportViewer1";
					crystalReportViewer1.ReportSource = null;
					crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
					crystalReportViewer1.TabIndex = 85;
					System.Windows.Forms.Form af = new System.Windows.Forms.Form();
					af.WindowState=FormWindowState.Maximized;
					af.Controls.Add(crystalReportViewer1);
					crystalReportViewer1.BringToFront();
					crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
	
					string areport="",asyt="",abv="",angayin="",anguoiin="",aghichu="";
					areport="cd_thongsophieu.rpt";
					asyt = m_m.Syte;
					abv = m_m.Tenbv;
					angayin ="Ngày " + DateTime.Now.Day.ToString().PadLeft(2,'0') + " tháng " + DateTime.Now.Month.ToString().PadLeft(2,'0') + " năm " + DateTime.Now.Year.ToString();
					anguoiin = "";
					aghichu = "";

					ReportDocument cMain=new ReportDocument();
					//cMain.Load(@"..\..\..\Report\"+areport, OpenReportMethod.OpenReportByTempCopy);
					cMain.SetDataSource(ds);
					cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
					cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
					cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
					cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
					cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
					cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
					crystalReportViewer1.ReportSource=cMain;
					af.Text="Danh mục sổ xét nghiệm";
					af.ShowDialog();				
				}
				else
					MessageBox.Show("Trong sổ xét nghiệm không danh mục","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch(Exception ex){ MessageBox.Show(ex.ToString()); }
		}
		private void f_Load_CB_Phieu()
		{

            try
            {
                string asql = "";
                string aexp = "";
                if (m_report != "")
                {
                    aexp = " where lower(trim(reportname))=lower('" + m_report.Trim() + "')";
                }
                asql = "select reportname ten from medibv.cd_phieucd " + aexp + " order by reportname";
                DataSet ads = new DataSet();
                ads = m_m.get_data(asql);
                try
                {
                    string atmp = ads.Tables[0].TableName;
                }
                catch
                {
                    m_m.execute_data("CREATE TABLE medibv.cd_phieucd( reportname text) WITHOUT OIDS;ALTER TABLE medibv.cd_phieucd OWNER TO medisoft;");
                    ads = m_m.get_data(asql);
                }
                cbReport.DisplayMember = "TEN";
                cbReport.ValueMember = "TEN";
                cbReport.DataSource = ads.Tables[0];
                cbReport.SelectedIndex = 0;
            }
            catch { }
		}
		private string f_Cur_Date()
		{
			try
			{
				return System.DateTime.Now.Day.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Month.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Year.ToString();
			}
			catch
			{
				return "";
			}
		}

		private void f_SetEvent(System.Windows.Forms.Control v_c)
		{
			try
			{
				foreach(Control c in v_c.Controls)
				{
					c.Leave += new System.EventHandler(this.Control_Leave);
					c.Enter += new System.EventHandler(this.Control_Enter);
				}
			}
			catch
			{
			}
		}
		private void Control_Enter(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox")||(c.GetType().ToString()=="System.Windows.Forms.NumericUpDown"))
				{
					c.BackColor=SystemColors.Info;
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.InfoText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=SystemColors.Info;
					}
					else
						if(c.GetType().ToString()=="System.Windows.Forms.ComboBox")
					{
						System.Windows.Forms.ComboBox c1 = (System.Windows.Forms.ComboBox)(sender);
						if(c1.SelectedIndex<0)
						{
							c1.SelectedIndex=0;
						}
					}
				}
			}
			catch
			{
			}
		}
		private void Control_Leave(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox")||(c.GetType().ToString()=="System.Windows.Forms.NumericUpDown"))
				{
					c.BackColor=Color.FromArgb(255,255,255);
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.ControlText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=Color.White;
					}
				}
			}
			catch
			{
			}
		}
		private void AddGridTableStyle1(DataSet v_ds)
		{
			try
			{
				dataGrid1.TableStyles.Clear();
				dataGrid1.AllowSorting=false;
				//dataGrid1.DataSource=v_ds.Tables[0];//null;
				//return;
				DataGridColoredTextBoxColumn TextCol;
				delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol1);
				DataGridTableStyle ts =new DataGridTableStyle();
				ts.MappingName = v_ds.Tables[0].TableName;
				ts.AlternatingBackColor = Color.Linen;
				ts.BackColor = Color.GhostWhite;
				ts.ForeColor = Color.MidnightBlue;
				ts.GridLineColor = SystemColors.Control;
				ts.HeaderBackColor = SystemColors.Control;
				ts.HeaderForeColor = Color.Navy;
				ts.SelectionBackColor = Color.Teal;
				ts.SelectionForeColor = Color.White;
				ts.RowHeaderWidth=16;
				ts.AllowSorting=false;
						
				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "id";
				TextCol.HeaderText = "id";
				TextCol.ReadOnly=!m_chosuacauhinh;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 60;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "mavp";
				TextCol.HeaderText = "ID Viện phí";
				TextCol.ReadOnly=!m_chosuacauhinh;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 100;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "tenvp";
				TextCol.HeaderText = "Nội dung chỉ định";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 150;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);


				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "tenloai";
				TextCol.HeaderText = "Loại viện phí";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 150;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "tennhom";
				TextCol.HeaderText = "Nhóm viện phí";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 150;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);

				dataGrid1.DataSource=v_ds.Tables[0];

				//MessageBox.Show(v_ds.Tables[0].Rows.Count.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void AddGridTableStyle2(DataSet v_ds)
		{
			try
			{
				dataGrid2.TableStyles.Clear();
				dataGrid2.AllowSorting=true;
				//dataGrid2.DataSource=v_ds.Tables[0];//null;
				//return;
				DataGridColoredTextBoxColumn TextCol;
				delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol2);
				DataGridTableStyle ts =new DataGridTableStyle();
				ts.MappingName = v_ds.Tables[0].TableName;
				ts.AlternatingBackColor = Color.Linen;
				ts.BackColor = Color.GhostWhite;
				ts.ForeColor = Color.MidnightBlue;
				ts.GridLineColor = SystemColors.Control;
				ts.HeaderBackColor = SystemColors.Control;
				ts.HeaderForeColor = Color.Navy;
				ts.SelectionBackColor = Color.Teal;
				ts.SelectionForeColor = Color.White;
				ts.RowHeaderWidth=16;
				ts.AllowSorting=true;
						
				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "id";
				TextCol.HeaderText = "id";
				TextCol.Width = 0;
				TextCol.ReadOnly=true;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid2.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "ma";
				TextCol.HeaderText = "Mã VP";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 60;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid2.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "ten";
				TextCol.HeaderText = "Nội dung thu viện phí";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 150;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid2.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "ten_loai";
				TextCol.HeaderText = "Loại viện phí";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 200;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid2.TableStyles.Add(ts);

				TextCol=new DataGridColoredTextBoxColumn(de, 0);
				TextCol.MappingName = "ten_nhom";
				TextCol.HeaderText = "Nhóm viện phí";
				TextCol.ReadOnly=true;
				TextCol.Alignment=HorizontalAlignment.Left;
				TextCol.Width = 200;
				TextCol.NullText = "";
				ts.GridColumnStyles.Add(TextCol);
				dataGrid2.TableStyles.Add(ts);

				dataGrid2.DataSource = v_ds.Tables[0];
				//MessageBox.Show(v_ds.Tables[0].Rows.Count.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_resizeDG1()
		{
			try
			{
				string aft=f_filter1();
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = m_chosuacauhinh; 
				dv.AllowDelete = m_chosuacauhinh; 
				dv.AllowEdit = m_chosuacauhinh; 
				dv.RowFilter=aft;
				int n=280, n1=(dataGrid1.Height-23)/20,aw=200,aw1=0;
				if(dv.Table.Select(aft).Length>n1)
				{
					aw1 = dataGrid1.Width - n - 16;
				}
				else
				{
					aw1 = dataGrid1.Width - n;
				}
				if(aw1>aw)
				{
					aw=aw1;
				}

				//dataGrid1.TableStyles[0].GridColumnStyles[5].Width = aw;
				dataGrid1.CaptionText="Thông số report: "+dv.Table.Select(aft).Length.ToString();
				//dataGrid1.Update();
			}
			catch
			{
				dataGrid1.CaptionText="Thông số report";
			}
		}
		private void f_resizeDG2()
		{
			try
			{
				string aft=f_filter2();
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid2.DataMember];  
				DataView dv = (DataView) cm.List; 
				dv.AllowNew = false; 
				dv.AllowDelete = false; 
				dv.AllowEdit = false; 
				dv.RowFilter=aft;
				int n=80, n1=(dataGrid2.Height-23)/20;
				
				/*
				if(dv.Table.Select(aft).Length>n1)
				{
					dataGrid2.TableStyles[0].GridColumnStyles[2].Width = dataGrid2.Width - n - 16;
				}
				else
				{
					dataGrid2.TableStyles[0].GridColumnStyles[2].Width = dataGrid2.Width - n;
				}
				*/
				dataGrid2.CaptionText="Nội dung thu viện phí: "+dv.Table.Select(aft).Length.ToString();
				//dataGrid2.Update();
			}
			catch
			{
				dataGrid2.CaptionText="Nội dung thu viện phí";
			}
		}
		private string f_filter1()
		{
			try
			{
				string aft="";				
				return aft;
			}
			catch
			{				
				return "";
			}
		}
		private string f_filter2()
		{
			try
			{
				string aft="";				
				if(txtTim.Text.Trim().ToLower()!="tìm kiếm" && txtTim.Text.Trim().ToLower()!="")
				{
					aft="ma like '%"+txtTim.Text.Trim()+"%' or ten like '%"+txtTim.Text.Trim()+"%' or ten_loai like '%"+txtTim.Text.Trim()+"%' or ten_nhom like '%"+txtTim.Text.Trim()+"%'";
				}
				return aft;
			}
			catch
			{				
				return "";
			}
		}
		#region Datagrid Colored Collum
		public Color MyGetColorRowCol1(int row, int col)
		{
			Color c = Color.Black;
			try
			{
				switch (col.ToString())
				{
					case "0":
						c=Color.Black;
						break;
					case "1":
						c=Color.Blue;
						break;
					case "2":
						c=Color.Red;
						break;
					case "3":
						c=Color.Orange;
						break;
					case "4":
						c=Color.Cyan;
						break;
					default:
						c=Color.Black;
						break;
				}
			}
			catch
			{
			}
			return c;
		}

		public Color MyGetColorRowCol2(int row, int col)
		{
			Color c = Color.Black;
			try
			{
				switch (col.ToString())
				{
					case "0":
						c=Color.Black;
						break;
					case "1":
						c=Color.Blue;
						break;
					case "2":
						c=Color.Red;
						break;
					case "3":
						c=Color.Orange;
						break;
					case "4":
						c=Color.Cyan;
						break;
					default:
						c=Color.Black;
						break;
				}
			}
			catch
			{
				if(dataGrid2.CurrentCell.RowNumber==row)
				{
					c=Color.White;
					//dataGrid2.Select(row);
				}
			}
			return c;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				string areport="";
				try
				{
					areport=cbReport.SelectedValue.ToString().ToLower().Trim();
				}
				catch
				{
					areport="";
				}
				if(areport=="")
				{
					MessageBox.Show(this,"Chọn report","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
					cbReport.Focus();
					SendKeys.Send("{Tab}");
					return;
				}
				if(butMap.Enabled)
				{
					m_m.execute_data("delete from medibv.cd_thongsophieucd where mavp is null");
					m_m.execute_data("delete from medibv.cd_thongsophieucd where lower(trim(report))=lower('"+areport+"')");
					foreach(DataRow r in dv.Table.Rows)
					{
                        if (r["id"].ToString().ToString() != "")
                        {
                            try
                            {
                                m_m.execute_data("insert into medibv.cd_thongsophieucd(id,report,mavp,val) values('" + r["id"].ToString() + "','" + cbReport.SelectedValue.ToString().Trim().ToLower() + "','" + r["mavp"].ToString() + "','')");
                            }
                            catch
                            {
                            }
                        }

					}
				}
				f_Save_Local(areport);
				f_Load_Local(areport);

				f_Load_DG1();
                if (cboloai.SelectedIndex == -1) f_Load_DG2(); else cboloai_SelectedIndexChanged(null, null);
				f_resizeDG1();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Save_Local(string v_idmay)
		{
			try
			{
			}
			catch
			{
			}
		}
		private void f_Load_Local(string v_idmay)
		{
			try
			{
			}
			catch
			{
			}
		}
		private void butUnmap_Click(object sender, System.EventArgs e)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				int  j = dataGrid1.CurrentCell.RowNumber;
				dv.Table.Rows[j]["mavp"]="";
				dv.Table.Rows[j]["tenvp"]="";
				dv.Table.Rows[j]["tenloai"]="";
				dv.Table.Rows[j]["tennhom"]="";
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}

		private void frmDMThongsophieucd_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				//this.WindowState=FormWindowState.Normal;
			}
			catch
			{
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				dataGrid1.UnSelect(int.Parse(dataGrid1.Tag.ToString()));
			}
			catch
			{
				dataGrid1.Tag="0";
			}

			try
			{
				dataGrid1.Tag = dataGrid1.CurrentCell.RowNumber;
				dataGrid1.Select(int.Parse(dataGrid1.Tag.ToString()));
				//dataGrid1.CurrentCell =  new DataGridCell(dataGrid1.CurrentCell.RowNumber,0);
			}
			catch
			{
			}
		}
		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				dataGrid2.UnSelect(int.Parse(dataGrid2.Tag.ToString()));
			}
			catch
			{
				dataGrid2.Tag="0";
			}

			try
			{
				dataGrid2.Tag = dataGrid2.CurrentCell.RowNumber;
				dataGrid2.Select(int.Parse(dataGrid2.Tag.ToString()));
				//dataGrid2.CurrentCell =  new DataGridCell(dataGrid2.CurrentCell.RowNumber,0);
			}
			catch
			{
			}
		}

		private void butMap_Click(object sender, System.EventArgs e)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
				DataView dv = (DataView) cm.List; 
				CurrencyManager cm1 = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid2.DataMember];  
				DataView dv1 = (DataView) cm1.List; 
				int i=0,j=0;
				i=dataGrid1.CurrentCell.RowNumber;
				j=dataGrid2.CurrentCell.RowNumber;
				DataRow r = dv1.Table.Select("id='"+dataGrid2[j,0].ToString()+"'")[0];
				dv.Table.Rows[i]["mavp"]=r["id"].ToString();
				dv.Table.Rows[i]["tenvp"]=r["ten"].ToString();
				dv.Table.Rows[i]["tenloai"]=r["ten_loai"].ToString();
				dv.Table.Rows[i]["tennhom"]=r["ten_nhom"].ToString();;
			}
			catch
			{
			}
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}
		private void txtTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtStt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtTim_TextChanged(object sender, System.EventArgs e)
		{
			f_resizeDG2();
		}

		private void txtTim_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTim.Text.Trim()=="")
				{
					txtTim.Text="Tìm kiếm";
				}
			}
			catch
			{
			}
		}

		private void txtTim_Enter(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTim.Text.Trim().ToLower()=="tìm kiếm")
				{
					txtTim.Text="";
				}
			}
			catch
			{
			}		
		}

		private void txtTim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtMa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}
		private void txtTen_Validated(object sender, System.EventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			f_print();
		}		
		private void frmDMThongsophieucd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}

		private void txtMa_Validated(object sender, System.EventArgs e)
		{					
		}

		private void dataGrid1_SizeChanged(object sender, System.EventArgs e)
		{
			f_resizeDG1();
		}
		private void cbReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ActiveControl.Name==cbReport.Name)
				{
					f_Load_DG1();
					f_Load_Local(cbReport.SelectedValue.ToString());
					f_resizeDG1();
				}
			}
			catch
			{
			}

		}

		private void butMay_Click(object sender, System.EventArgs e)
		{
			try
			{
				frmDMPhieucd af = new frmDMPhieucd();
				af.ShowInTaskbar=false;
				af.ShowDialog(this);
				af.Dispose();
				f_Load_CB_Phieu();
				f_Load_DG1();
				f_resizeDG1();
			}
			catch
			{
			}
		
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
					//foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		#endregion

        private void cboloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cboloai || sender == null)
            {
                try
                {
                    if (bloai == true)
                    {
                        string asql = "select to_char(a.id) id, a.ma, a.ten, b.ten ten_loai, c.ten ten_nhom ";
                        asql += " from medibv.v_giavp a, medibv.v_loaivp b, medibv.v_nhomvp c ";
                        asql += " where a.id_loai=b.id and b.id_nhom=c.ma ";
                        if (chkAll.Checked == false)
                        {
                            asql += " and a.id not in (select nvl(to_number(mavp),0) as id from medibv.cd_thongsophieucd)";
                        }

                        asql += " and b.id=" + cboloai.SelectedValue.ToString();
                        asql += " order by a.ten, b.ten,c.ten";
                        DataSet ads = m_m.get_data(asql);
                        AddGridTableStyle2(ads);
                        f_resizeDG2();
                    }
                }
                catch
                {
                }
            }
        }

        private void cboloai_Click(object sender, EventArgs e)
        {
            bloai = true;
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            cboloai_SelectedIndexChanged(null, null);
        }
	}
}
