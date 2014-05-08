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
	/// Summary description for frmDSdutru_duyet.
	/// </summary>
	public class frmDSdutru_duyet : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox loai;
		private DataSet ds=new DataSet();
		private DataSet ds1=new DataSet();
        private DataSet dslinh = new DataSet();
		private AccessData d;
		private string sql,s_makp,s_mmyy,user,xxx,f_ngay,s_makho;
		private int i_nhom;
		private bool bClear=true,b1kho=false;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label l1;
		private System.Windows.Forms.Label l2;
		private System.Windows.Forms.Label l3;
        private DataGrid dataGrid3;
        private NumericUpDown txtNam;
        private NumericUpDown txtThang;
        private Label label5;
        private Label label6;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDSdutru_duyet(AccessData acc,string _makp,int nhom,string mmyy,string makho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            d = acc; s_makp = _makp; i_nhom = nhom; s_mmyy = mmyy; s_makho = makho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSdutru_duyet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butXem = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(130, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(57, 4);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(194, 4);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.Validated += new System.EventHandler(this.den_Validated);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(460, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(501, 4);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(99, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(606, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phiếu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(644, 4);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(144, 21);
            this.loai.TabIndex = 7;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXem.Image = global::Duoc.Properties.Resources.search;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(328, 535);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(72, 25);
            this.butXem.TabIndex = 8;
            this.butXem.Text = "       &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(400, 535);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
            this.dataGrid1.Size = new System.Drawing.Size(400, 497);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // l1
            // 
            this.l1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l1.BackColor = System.Drawing.Color.Red;
            this.l1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l1.Location = new System.Drawing.Point(4, 509);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(146, 23);
            this.l1.TabIndex = 11;
            this.l1.Text = "Chưa chuyển xuống kho";
            this.l1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l2
            // 
            this.l2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l2.BackColor = System.Drawing.Color.Blue;
            this.l2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l2.Location = new System.Drawing.Point(154, 509);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(166, 23);
            this.l2.TabIndex = 12;
            this.l2.Text = "chuyển xuống kho chưa duyệt";
            this.l2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l3
            // 
            this.l3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l3.BackColor = System.Drawing.Color.Black;
            this.l3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l3.Location = new System.Drawing.Point(324, 509);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(84, 23);
            this.l3.TabIndex = 13;
            this.l3.Text = "Đã duyệt";
            this.l3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(425, 302);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(368, 204);
            this.dataGrid2.TabIndex = 26;
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid3.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid3.DataMember = "";
            this.dataGrid3.FlatMode = true;
            this.dataGrid3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(425, 9);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.RowHeaderWidth = 3;
            this.dataGrid3.Size = new System.Drawing.Size(368, 307);
            this.dataGrid3.TabIndex = 27;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(411, 4);
            this.txtNam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(49, 20);
            this.txtNam.TabIndex = 31;
            this.txtNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(343, 4);
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(40, 20);
            this.txtThang.TabIndex = 30;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(382, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "năm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(275, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Số liệu tháng";
            // 
            // frmDSdutru_duyet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 572);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.dataGrid3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDSdutru_duyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách dự trù,duyệt,in phiếu xuất";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDSdutru_duyet_MouseMove);
            this.Load += new System.EventHandler(this.frmDSdutru_duyet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDSdutru_duyet_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy; f_ngay = d.f_ngay; b1kho = d.b1kho(s_makho);
            txtThang.Value = int.Parse(s_mmyy.Substring(0, 2));
            txtNam.Value = 2000 + int.Parse(s_mmyy.Substring(2, 2));
            //
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=d.get_data("select * from "+user+".d_dmphieu where id<5 order by stt").Tables[0];

			sql="select * from "+user+".d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=d.get_data(sql).Tables[0];
			load_grid();
			AddGridTableStyle();
			AddGridTableStyle1();
            f_load_phieuduyet(1, 0);//
            AddGridTableStyle2();
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds1.Tables[0].TableName;
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
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 70;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soct";
			TextCol.HeaderText = "Số CT";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "no";
			TextCol.HeaderText = "Nợ";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "co";
			TextCol.HeaderText = "Có";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "diengiai";
			TextCol.HeaderText = "Diễn giải";
			TextCol.Width = 100;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

		}
        private void AddGridTableStyle2()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dslinh.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.Teal;
            ts.SelectionForeColor = Color.PaleGreen;
            ts.ReadOnly = false;
            ts.RowHeaderWidth = 5;

            DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenphieu";
            TextCol.HeaderText = "Tên phiếu";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "phieu";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "makp";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);

            dataGrid3.TableStyles.Add(ts);
        }
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void load_grid()
		{
			Cursor=Cursors.WaitCursor;
            string sxxx = d.user + txtThang.Value.ToString().PadLeft(2, '0') + txtNam.Value.ToString().Substring(2, 2);
            string exp = "";
            if (s_makho != "") exp += " and e.makho in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";//sql += " and e.makho=" + int.Parse(s_makho.Substring(0, s_makho.Length - 1));
            if (makp.SelectedIndex != -1) exp += " and a.makhoa=" + int.Parse(makp.SelectedValue.ToString());
            if (loai.SelectedIndex != -1) exp += " and a.loai=" + int.Parse(loai.SelectedValue.ToString());
            exp += " and a.nhom=" + i_nhom;
            if (s_makp != "") exp += " and a.makhoa in (" + s_makp.Substring(0, s_makp.Length - 1) + ")";
            exp += " and a.ngay between to_date('" + tu.Text + "','" + f_ngay + "') and to_date('" + den.Text + "','" + f_ngay + "')";

            sql = "select distinct '" + sxxx + "' as mmyy,a.makhoa,a.makp,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.phieu,a.loai,";
			sql+="b.ten as tenkp,c.ten as tenloai,d.ten as tenphieu,";
            sql += "e.done, a.id as idduyet ";
            sql += " from  " + sxxx + ".d_duyet a," + sxxx + ".d_dutrull a1," + user + ".d_duockp b," + user + ".d_dmphieu c," + user + ".d_loaiphieu d";
            sql += " , " + sxxx + ".d_duyetkho e";
			sql+=" where a.makhoa=b.id and a.loai=c.id and a.phieu=d.id and a.id=a1.idduyet";
            sql += " and a.id=e.idduyet ";
            sql += exp;
            sql += " union all ";
            sql += "select distinct '" + sxxx + "' as mmyy,a.makhoa,a.makp,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.phieu,a.loai,";
            sql += "b.ten as tenkp,c.ten as tenloai,d.ten as tenphieu,";
            sql += "e.done, a.id as idduyet ";
            sql += " from  " + sxxx + ".d_duyet a," + sxxx + ".d_xtutrucll a1," + user + ".d_duockp b," + user + ".d_dmphieu c," + user + ".d_loaiphieu d";
            sql += " , " + sxxx + ".d_duyetkho e";
            sql += " where a.makhoa=b.id and a.loai=c.id and a.phieu=d.id and a.id=a1.idduyet";
            sql += " and a.id=e.idduyet ";
            sql += exp;
            sql += " union all ";
            sql += "select distinct '" + sxxx + "' as mmyy,a.makhoa,a.makp,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.phieu,a.loai,";
            sql += "b.ten as tenkp,c.ten as tenloai,d.ten as tenphieu,";
            sql += "e.done, a.id as idduyet ";
            sql += " from  " + sxxx + ".d_duyet a," + sxxx + ".d_hoantrall a1," + user + ".d_duockp b," + user + ".d_dmphieu c," + user + ".d_loaiphieu d";
            sql += " , " + sxxx + ".d_duyetkho e";
            sql += " where a.makhoa=b.id and a.loai=c.id and a.phieu=d.id and a.id=a1.idduyet";
            sql += " and a.id=e.idduyet ";
            sql += exp;
            sql += " union all ";
            sql += "select distinct '" + sxxx + "' as mmyy,a.makhoa,a.makp,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.phieu,a.loai,";
            sql += "b.ten as tenkp,c.ten as tenloai,d.ten as tenphieu,";
            sql += "e.done, a.id as idduyet ";
            sql += " from  " + sxxx + ".d_duyet a," + sxxx + ".d_haophill a1," + user + ".d_duockp b," + user + ".d_dmphieu c," + user + ".d_loaiphieu d";
            sql += " , " + sxxx + ".d_duyetkho e";
            sql += " where a.makhoa=b.id and a.loai=c.id and a.phieu=d.id and a.id=a1.idduyet";
            sql += " and a.id=e.idduyet ";
            sql += exp;
            ds = d.get_data (sql); //ds = d.get_data_mmyy(sql, tu.Text, den.Text, true);
            foreach (DataRow r in ds.Tables[0].Rows) r["mmyy"] = r["mmyy"].ToString().Replace("medibv", "");
			dataGrid1.DataSource=ds.Tables[0];
			l1.Text="Chưa chuyển xuống kho: "+ds.Tables[0].Select("done=0").Length.ToString().Trim();
			l2.Text="chuyển xuống kho chưa duyệt: "+ds.Tables[0].Select("done=1").Length.ToString().Trim();
			l3.Text="Đã duyệt: "+ds.Tables[0].Select("done=2").Length.ToString().Trim();

			sql="select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenkp,a.soct,a.no,a.co,a.diengiai,a.sotien";
			sql+=" from "+xxx+".d_phieuxuat a,"+user+".d_duockp b";
			sql+=" where a.makp=b.id and a.nhom="+i_nhom;
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (makp.SelectedIndex!=-1) sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			sql+=" and a.ngay between to_date('"+tu.Text+"','"+f_ngay+"') and to_date('"+den.Text+"','"+f_ngay+"')";
			sql+=" order by a.ngay,a.makp,a.soct";
			ds1=d.get_data(sql);
			dataGrid2.DataSource=ds1.Tables[0];
			Cursor=Cursors.Default;
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
			ts.ReadOnly=false;
			ts.RowHeaderWidth=5;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 100;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "tenloai";
			TextCol.HeaderText = "Loại";
			TextCol.Width = 90;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "tenphieu";
			TextCol.HeaderText = "Phiếu";
			TextCol.Width = 105;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "done";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "mmyy";
            TextCol.HeaderText = "MMYY";
            TextCol.Width = 30;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "idduyet";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,4].ToString().Trim()=="0") return Color.Red;
			else if (this.dataGrid1[row,4].ToString().Trim()=="1") return Color.Blue;
			else return Color.Black;
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
			load_grid();
            Cursor = Cursors.Default;
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmDSdutru_duyet_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				loai.SelectedIndex=-1;
				bClear=false;
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

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            int i_loai = int.Parse(dataGrid1[dataGrid1.CurrentRowIndex, 6].ToString());
            decimal l_idduyet = decimal.Parse(dataGrid1[dataGrid1.CurrentRowIndex, 7].ToString());
            f_load_phieuduyet(i_loai, l_idduyet);
        }

        private void f_load_phieuduyet(int loai, decimal idduyet)
        {
            string user = d.user;
            string sxxx = d.user + txtThang.Value.ToString().PadLeft(2, '0') + txtNam.Value.ToString().Substring(2, 2);
            string d_user = user + "" + s_mmyy;
            string sql = "";
            switch (loai.ToString())//loai
            {
                case "2":
                    sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu, a.loai, a.phieu, a.makhoa as makp  from xxx.d_xuatsdll a," + user + ".d_loaiphieu b,xxx.d_thucbucstt c where a.id=c.id and a.phieu=b.id and a.idduyet in(select id from " + sxxx + ".d_xtutrucll where idduyet in(select id from " + sxxx + ".d_duyet where id =" + idduyet + "))";
                    break;
                case "3":
                    sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu, a.loai, a.phieu, a.makhoa as makp  from xxx.d_xuatsdll a," + user + ".d_loaiphieu b where a.phieu=b.id and a.idduyet in(select id from " + sxxx + ".d_hoantrall where idduyet in(select id from " + sxxx + ".d_duyet where id =" + idduyet + "))";
                    break;
                case "4":
                    sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu, a.loai, a.phieu, a.makhoa as makp  from xxx.d_xuatsdll a," + user + ".d_loaiphieu b where a.phieu=b.id and a.idduyet in(select id from " + sxxx + ".d_haophill where idduyet in(select id from " + sxxx + ".d_duyet where id =" + idduyet + "))";
                    break;
                default:
                    sql = "select distinct to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten as tenphieu, a.loai, a.phieu, a.makhoa as makp from xxx.d_xuatsdll a," + user + ".d_loaiphieu b where a.phieu=b.id and a.idduyet in(select id from " + sxxx + ".d_dutrull where idduyet in(select id from " + sxxx + ".d_duyet where id =" + idduyet + "))";
                    break;
            };
            dslinh = d.get_data_mmyy(sql, tu.Text, den.Text, true);
            
            dataGrid3.DataSource = dslinh.Tables[0];
            //    
        }

        private void den_Validated(object sender, EventArgs e)
        {
            txtThang.Value = den.Value.Month;
            txtNam.Value = den.Value.Year;
            if (den.Value < tu.Value) tu.Value = den.Value;
        }
	}
}
