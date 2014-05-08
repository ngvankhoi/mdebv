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
	/// <summary>
	/// Summary description for frmTruyvan_kb.
	/// </summary>
	/// 	
	public class frmTruyvan_kb : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private DataSet ds=new DataSet();
		private DataSet dstmp=new DataSet();
		private DataSet dstuoi=new DataSet();
		private DataTable dt;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private DataRow r1,r2;
		private string sql,s_thetunguyen,s_tunguyen;
		private int v1=5,v2=2,i_nhom;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox opt;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb4;
		private System.Windows.Forms.RadioButton rb5;
		private System.Windows.Forms.RadioButton rb6;
		private System.Windows.Forms.RadioButton rb7;
		private System.Windows.Forms.RadioButton rb8;
		private System.Windows.Forms.RadioButton rb9;
		private System.Windows.Forms.RadioButton rb10;
		private System.Windows.Forms.RadioButton rb11;
		private System.Windows.Forms.RadioButton rb12;
		private System.Windows.Forms.RadioButton rb13;
		private System.Windows.Forms.RadioButton rb14;
		private System.Windows.Forms.RadioButton rb15;
		private System.Windows.Forms.RadioButton rb16;
		private System.Windows.Forms.NumericUpDown tuoi;
		private System.Windows.Forms.Button butICD10;
		private System.Windows.Forms.Button butTonghop;
        private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.CheckBox chkMabn;
		private MaskedTextBox.MaskedTextBox maicd;

        private string user = "", s_tu = "",s_den="",s_time="";
        private decimal s_c01, s_c02, s_c03;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTruyvan_kb(LibMedi.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTruyvan_kb));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.opt = new System.Windows.Forms.GroupBox();
            this.tuoi = new System.Windows.Forms.NumericUpDown();
            this.rb16 = new System.Windows.Forms.RadioButton();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.rb14 = new System.Windows.Forms.RadioButton();
            this.rb13 = new System.Windows.Forms.RadioButton();
            this.rb12 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb9 = new System.Windows.Forms.RadioButton();
            this.rb8 = new System.Windows.Forms.RadioButton();
            this.rb7 = new System.Windows.Forms.RadioButton();
            this.rb6 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.butICD10 = new System.Windows.Forms.Button();
            this.maicd = new MaskedTextBox.MaskedTextBox();
            this.butTonghop = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chkMabn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.opt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tuoi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(158, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(59, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(96, 23);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(190, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(96, 23);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(299, -11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(480, 507);
            this.dataGrid1.TabIndex = 7;
            // 
            // opt
            // 
            this.opt.Controls.Add(this.tuoi);
            this.opt.Controls.Add(this.rb16);
            this.opt.Controls.Add(this.rb15);
            this.opt.Controls.Add(this.rb14);
            this.opt.Controls.Add(this.rb13);
            this.opt.Controls.Add(this.rb12);
            this.opt.Controls.Add(this.rb11);
            this.opt.Controls.Add(this.rb10);
            this.opt.Controls.Add(this.rb9);
            this.opt.Controls.Add(this.rb8);
            this.opt.Controls.Add(this.rb7);
            this.opt.Controls.Add(this.rb6);
            this.opt.Controls.Add(this.rb5);
            this.opt.Controls.Add(this.rb4);
            this.opt.Controls.Add(this.rb2);
            this.opt.Controls.Add(this.rb1);
            this.opt.Controls.Add(this.butICD10);
            this.opt.Controls.Add(this.maicd);
            this.opt.Location = new System.Drawing.Point(8, 32);
            this.opt.Name = "opt";
            this.opt.Size = new System.Drawing.Size(280, 384);
            this.opt.TabIndex = 4;
            this.opt.TabStop = false;
            // 
            // tuoi
            // 
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(88, 350);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(72, 23);
            this.tuoi.TabIndex = 18;
            this.tuoi.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rb16
            // 
            this.rb16.Location = new System.Drawing.Point(12, 350);
            this.rb16.Name = "rb16";
            this.rb16.Size = new System.Drawing.Size(92, 24);
            this.rb16.TabIndex = 17;
            this.rb16.Text = "Trẻ em <=";
            this.rb16.CheckedChanged += new System.EventHandler(this.rb16_CheckedChanged);
            // 
            // rb15
            // 
            this.rb15.Location = new System.Drawing.Point(12, 326);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(76, 24);
            this.rb15.TabIndex = 14;
            this.rb15.Text = "Mã ICD10 ";
            this.rb15.CheckedChanged += new System.EventHandler(this.rb15_CheckedChanged);
            // 
            // rb14
            // 
            this.rb14.Location = new System.Drawing.Point(12, 302);
            this.rb14.Name = "rb14";
            this.rb14.Size = new System.Drawing.Size(156, 24);
            this.rb14.TabIndex = 13;
            this.rb14.Text = "Tiếp đón && phòng khám";
            // 
            // rb13
            // 
            this.rb13.Location = new System.Drawing.Point(12, 278);
            this.rb13.Name = "rb13";
            this.rb13.Size = new System.Drawing.Size(256, 24);
            this.rb13.TabIndex = 12;
            this.rb13.Text = "Phòng khám (tiếp đón chỉ định)";
            // 
            // rb12
            // 
            this.rb12.Location = new System.Drawing.Point(12, 254);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(256, 24);
            this.rb12.TabIndex = 11;
            this.rb12.Text = "Giới tính";
            // 
            // rb11
            // 
            this.rb11.Location = new System.Drawing.Point(12, 230);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(256, 24);
            this.rb11.TabIndex = 10;
            this.rb11.Text = "Độ tuổi";
            // 
            // rb10
            // 
            this.rb10.Location = new System.Drawing.Point(12, 206);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(256, 24);
            this.rb10.TabIndex = 9;
            this.rb10.Text = "Địa phương";
            // 
            // rb9
            // 
            this.rb9.Location = new System.Drawing.Point(12, 182);
            this.rb9.Name = "rb9";
            this.rb9.Size = new System.Drawing.Size(256, 24);
            this.rb9.TabIndex = 8;
            this.rb9.Text = "Nhập viện";
            // 
            // rb8
            // 
            this.rb8.Location = new System.Drawing.Point(12, 158);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(256, 24);
            this.rb8.TabIndex = 7;
            this.rb8.Text = "Bệnh tật";
            // 
            // rb7
            // 
            this.rb7.Location = new System.Drawing.Point(12, 134);
            this.rb7.Name = "rb7";
            this.rb7.Size = new System.Drawing.Size(256, 24);
            this.rb7.TabIndex = 6;
            this.rb7.Text = "Nghề nghiệp";
            // 
            // rb6
            // 
            this.rb6.Location = new System.Drawing.Point(12, 110);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(256, 24);
            this.rb6.TabIndex = 5;
            this.rb6.Text = "Xử trí";
            // 
            // rb5
            // 
            this.rb5.Location = new System.Drawing.Point(12, 86);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(256, 24);
            this.rb5.TabIndex = 4;
            this.rb5.Text = "Trẻ em";
            // 
            // rb4
            // 
            this.rb4.Location = new System.Drawing.Point(12, 62);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(188, 24);
            this.rb4.TabIndex = 3;
            this.rb4.Text = "Đối tượng";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(12, 40);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(256, 24);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Khám bệnh";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(12, 16);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(256, 24);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Tiếp đón";
            // 
            // butICD10
            // 
            this.butICD10.Enabled = false;
            this.butICD10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butICD10.Location = new System.Drawing.Point(162, 328);
            this.butICD10.Name = "butICD10";
            this.butICD10.Size = new System.Drawing.Size(24, 23);
            this.butICD10.TabIndex = 16;
            this.butICD10.Text = "...";
            this.butICD10.Click += new System.EventHandler(this.butICD10_Click);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(88, 328);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.maicd.MaxLength = 9;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(72, 21);
            this.maicd.TabIndex = 15;
            // 
            // butTonghop
            // 
            this.butTonghop.Image = ((System.Drawing.Image)(resources.GetObject("butTonghop.Image")));
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(68, 448);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(74, 25);
            this.butTonghop.TabIndex = 5;
            this.butTonghop.Text = "Tổng hợp";
            this.butTonghop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTonghop.Click += new System.EventHandler(this.butTonghop_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(143, 448);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chkMabn
            // 
            this.chkMabn.Location = new System.Drawing.Point(20, 421);
            this.chkMabn.Name = "chkMabn";
            this.chkMabn.Size = new System.Drawing.Size(136, 24);
            this.chkMabn.TabIndex = 8;
            this.chkMabn.Text = "Theo người bệnh";
            // 
            // frmTruyvan_kb
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkMabn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.opt);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTruyvan_kb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy vấn thông tin khám bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTruyvan_kb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.opt.ResumeLayout(false);
            this.opt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tuoi)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmTruyvan_kb_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
			i_nhom=m.nhom_duoc;
			s_thetunguyen=d.thetunguyen(i_nhom);
			if (s_thetunguyen!="" ) s_tunguyen=s_thetunguyen.Replace(",","','");
			string vitri=d.thetunguyen_vitri_ora(i_nhom);
			if (vitri!="")
			{
				v1=int.Parse(vitri.Substring(0,1));v2=int.Parse(vitri.Substring(2,1));
			}
			ds.ReadXml("..//..//..//xml//m_truyvan.xml");
			dstmp.ReadXml("..//..//..//xml//m_truyvan.xml");
			dstuoi.ReadXml("..//..//..//xml//m_tvdotuoi.xml");
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "ma";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "noidung";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 205;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "c01";
			TextCol1.HeaderText = "Thành phố";
			TextCol1.Width = 80;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "c02";
			TextCol1.HeaderText = "Tỉnh";
			TextCol1.Width = 80;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "c03";
			TextCol1.HeaderText = "Tổng số";
			TextCol1.Width = 100;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,0].ToString().Trim()=="B") return Color.Blue;
			else if (this.dataGrid1[row,0].ToString().Trim()=="A") return Color.Red;
			else return Color.Black;
		}

		private void rb16_CheckedChanged(object sender, System.EventArgs e)
		{
			tuoi.Enabled=rb16.Checked;
			
		}

		private void rb15_CheckedChanged(object sender, System.EventArgs e)
		{
			butICD10.Enabled=rb15.Checked;
			maicd.Enabled=rb15.Checked;
			
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
            load();
			Cursor=Cursors.Default;
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

		private void load_1()
		{
			ds.Clear();
            s_c01 = 0; s_c02 = 0; s_c03 = 0;
			sql="select ";
			if (chkMabn.Checked) sql+=" a.mabn ,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql+= " where a.noitiepdon=0 ";
            if(s_tu != "")
                sql += " and " + m.for_ngay("a.ngay",s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
			
			if (chkMabn.Checked) sql+=" group by a.mabn";
			dt=m.get_data_mmyy(sql,s_tu,s_den,false).Tables[0];
            sum_data(dt);
			r1=ds.Tables[0].NewRow();
			r1["ma"]="A";
			r1["noidung"]=(chkMabn.Checked)?"Số người tiếp đón":"Số lượt tiếp đón";
            r1["c01"] = s_c01.ToString();
            r1["c02"] = s_c02.ToString();
            r1["c03"] = s_c03.ToString();
			if (chkMabn.Checked)
			{
				r1["c01"]=dt.Select("c01>0").Length;
				r1["c02"]=dt.Select("c02>0").Length;
				r1["c03"]=dt.Select("c03>0").Length;
			}
			ds.Tables[0].Rows.Add(r1);
		}

		private void load_2()
		{
			ds.Clear();
            s_c01 = 0; s_c02 = 0; s_c03 = 0;
			sql="select ";
			if (chkMabn.Checked) sql+=" a.mabn,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.benhanpk a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where ";
            if(s_tu!="")
                sql += " " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
			if (chkMabn.Checked) sql+=" group by a.mabn";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			r1=ds.Tables[0].NewRow();
			r1["ma"]="A";
			r1["noidung"]=(chkMabn.Checked)?"Số người khám bệnh":"Số lượt khám bệnh";
            sum_data(dt);
            r1["c01"] = s_c01.ToString();
            r1["c02"] = s_c02.ToString();
            r1["c03"] = s_c03.ToString();
			if (chkMabn.Checked)
			{
				r1["c01"]=dt.Select("c01>0").Length;
				r1["c02"]=dt.Select("c02>0").Length;
				r1["c03"]=dt.Select("c03>0").Length;
			}
			ds.Tables[0].Rows.Add(r1);
		}

        private void sum_data(DataTable s_dt)
        {
            if (s_dt.Rows.Count > 0)
            {
                foreach (DataRow dr in s_dt.Rows)
                {
                    s_c01 += decimal.Parse(dr["c01"].ToString());
                    s_c02 += decimal.Parse(dr["c02"].ToString());
                    s_c03 += decimal.Parse(dr["c03"].ToString());
                }
            }
        }

		private void load_3()
		{
		}

		private void load_4()
		{
			dstmp.Clear();
            s_c01 = 0; s_c02 = 0; s_c03 = 0;
            DataTable tmp = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a").Tables[0];
			sql="select ";
			sql+="a.madoituong as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' and g.sothe is not null and a.madoituong=1 and h.sothe>0 and substr(g.sothe,"+v1+","+v2+") not in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"') then 1 else 0 end) as bb1,"; 
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' and g.sothe is not null and a.madoituong=1 and h.sothe>0 and substr(g.sothe,"+v1+","+v2+") in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"') then 1 else 0 end) as tn1,"; 
			sql+=" sum(case when b.matt<>'"+m.Mabv.Substring(0,3)+"' and g.sothe is not null and a.madoituong=1 and h.sothe>0 and substr(g.sothe,"+v1+","+v2+") not in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"') then 1 else 0 end) as bb2,"; 
			sql+=" sum(case when b.matt<>'"+m.Mabv.Substring(0,3)+"' and g.sothe is not null and a.madoituong=1 and h.sothe>0 and substr(g.sothe,"+v1+","+v2+") in ('"+s_tunguyen.Substring(0,s_tunguyen.Length)+"') then 1 else 0 end) as tn2,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " left join " + user + ".bhyt g on a.maql=g.maql";
            sql += " inner join " + user + ".doituong h on a.madoituong=h.madoituong";
            sql += " where a.noitiepdon=0 ";
            if (s_tu != "")
                sql += " and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
			sql+=" group by a.madoituong";
			sql+=" order by a.madoituong";
            dt = m.get_data_mmyy(sql,s_tu,s_den,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"madoituong="+int.Parse(r["ma"].ToString()));
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=decimal.Parse(r["ma"].ToString());
					r1["noidung"]=r2["doituong"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
					if (r["ma"].ToString()=="1")
					{
						r1=dstmp.Tables[0].NewRow();
						r1["ma"]="B";
						r1["noidung"]="Trong đó :";
						r1["c01"]=0;
						r1["c02"]=0;
						r1["c03"]=0;
						dstmp.Tables[0].Rows.Add(r1);
						r1=dstmp.Tables[0].NewRow();
						r1["ma"]="B";
						r1["noidung"]="- Bắt buộc";
						r1["c01"]=r["bb1"].ToString();
						r1["c02"]=r["bb2"].ToString();
						r1["c03"]=decimal.Parse(r["bb1"].ToString())+decimal.Parse(r["bb2"].ToString());
						dstmp.Tables[0].Rows.Add(r1);
						r1=dstmp.Tables[0].NewRow();
						r1["ma"]="B";
						r1["noidung"]="- Tự nguyện";
						r1["c01"]=r["tn1"].ToString();
						r1["c02"]=r["tn2"].ToString();
						r1["c03"]=decimal.Parse(r["tn1"].ToString())+decimal.Parse(r["tn2"].ToString());
						dstmp.Tables[0].Rows.Add(r1);
					}
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_6()
		{
			dstmp.Clear();
            DataTable tmp = m.get_data("select * from " + user + ".xutrikb").Tables[0];
			sql="select a.ttlucrv as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.benhanpk a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            //sql += " inner join " + user + ".xuatvien g on a.maql=g.maql";
            sql += " where a.ttlucrv is not null";
            if(s_tu!="")
                sql+=" and "+m.for_ngay("a.ngay",s_time)+" between to_date('"+s_tu+"',"+s_time+") and to_date('"+s_den+"',"+s_time+")";
			sql+=" group by a.ttlucrv";
            dt = m.get_data_mmyy(sql,s_tu,s_den,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"ma="+int.Parse(r["ma"].ToString()));
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["ten"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_7()
		{
			dstmp.Clear();
            DataTable tmp = m.get_data("select * from " + user + ".btdnn_bv").Tables[0];
			sql="select b.mann as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0";
            if(s_tu!="")
                sql+=" and "+m.for_ngay("a.ngay",s_time)+" between to_date('"+s_tu+"',"+s_time+") and to_date('"+s_den+"',"+s_time+")";
			sql+=" group by b.mann";
			dt=m.get_data_mmyy(sql,s_tu,s_den,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"mann='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["tennn"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_8()
		{
			dstmp.Clear();
			sql="select trim(a.maicd)||'-'||a.chandoan as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.benhanpk a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            //sql += " inner join " + user + ".xuatvien g on a.maql=g.maql";
            sql += " where a.ttlucrv is not null and "+m.for_ngay("a.ngay",s_time)+" between to_date('" + s_tu + "',"+s_time+") and to_date('" + s_den + "',"+s_time+")";
			sql+=" group by trim(a.maicd)||'-'||a.chandoan";
			dt=m.get_data_mmyy(sql,s_tu,s_den,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			int stt=1;
			foreach(DataRow r in dt.Rows)
			{
				r1=dstmp.Tables[0].NewRow();
				r1["ma"]=stt++;
				r1["noidung"]=r["ma"].ToString();
				r1["c01"]=r["c01"].ToString();
				r1["c02"]=r["c02"].ToString();
				r1["c03"]=r["c03"].ToString();
				z01+=decimal.Parse(r["c01"].ToString());
				z02+=decimal.Parse(r["c02"].ToString());
				z03+=decimal.Parse(r["c03"].ToString());
				dstmp.Tables[0].Rows.Add(r1);
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_10()
		{
			dstmp.Clear();
            DataTable tmp = m.get_data("select * from " + user + ".btdtt").Tables[0];
			sql="select b.matt as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0 ";
            if (s_tu != "")
                sql += " and "+m.for_ngay("a.ngay",s_time)+" between to_date('"+s_tu+"',"+s_time+") and to_date('"+s_den+"',"+s_time+")";
			sql+=" group by b.matt";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"matt='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["tentt"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_12()
		{
			dstmp.Clear();
            DataTable tmp = m.get_data("select * from " + user + ".dmphai").Tables[0];
			sql="select b.phai as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0";
            if (s_tu != "")
                sql += " and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";			
			sql+=" group by b.phai";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"ma="+int.Parse(r["ma"].ToString()));
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["ten"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_13()
		{
			dstmp.Clear();
            DataTable tmp = m.get_data("select * from " + user + ".btdkp_bv").Tables[0];
			sql="select a.makp as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0";
            if (s_tu != "")
                sql += " and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
			sql+=" group by a.makp";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"makp='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["tenkp"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_5()
		{
			dstmp.Clear();
			int nam=int.Parse(tu.Text.Substring(6,4));
			sql="select ";
			sql+=" case when "+nam+"-to_number(b.namsinh,'0000')<=4 then 1 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=6 then 2 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=14 then 3 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')>=15 and " + nam + "-to_number(b.namsinh,'0000')<=60 then 4 else ";
			sql+=" 5 end end end end as ma,";
			sql+="sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0";
            if (s_tu != "")
                sql += " and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
            sql += " and " + nam + "-to_number(b.namsinh,'0000')<=14";
            sql += " group by case when " + nam + "-to_number(b.namsinh,'0000')<=4 then 1 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=6 then 2 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=14 then 3 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')>=15 and " + nam + "-to_number(b.namsinh,'0000')<=60 then 4 else ";
			sql+=" 5 end end end end";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(dstuoi.Tables[0],"ma='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["ten"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","ma"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_11()
		{
			dstmp.Clear();
			int nam=int.Parse(tu.Text.Substring(6,4));
			sql="select ";
			sql+=" case when "+nam+"-to_number(b.namsinh,'0000')<=4 then 1 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=6 then 2 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=14 then 3 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')>=15 and " + nam + "-to_number(b.namsinh,'0000')<=60 then 4 else ";
			sql+=" 5 end end end end as ma,";
			sql+="sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0";
            if (s_tu != "")
                sql += " and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
            sql += " group by case when " + nam + "-to_number(b.namsinh,'0000')<=4 then 1 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=6 then 2 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=14 then 3 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')>=15 and " + nam + "-to_number(b.namsinh,'0000')<=60 then 4 else ";
			sql+=" 5 end end end end";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(dstuoi.Tables[0],"ma='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["ten"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","ma"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_16()
		{
			dstmp.Clear();
			int nam=int.Parse(tu.Text.Substring(6,4));
			sql="select ";
			sql+=" case when "+nam+"-to_number(b.namsinh,'0000')<=4 then 1 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=6 then 2 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=14 then 3 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')>=15 and " + nam + "-to_number(b.namsinh,'0000')<=60 then 4 else ";
			sql+=" 5 end end end end as ma,";
			sql+="sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            sql += " where a.noitiepdon=0";
            if (s_tu != "")
                sql += " and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
            sql += " and " + nam + "-to_number(b.namsinh,'0000')<=" + Convert.ToInt16(tuoi.Value);
            sql += " group by case when " + nam + "-to_number(b.namsinh,'0000')<=4 then 1 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=6 then 2 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')<=14 then 3 else ";
            sql += " case when " + nam + "-to_number(b.namsinh,'0000')>=15 and " + nam + "-to_number(b.namsinh,'0000')<=60 then 4 else ";
			sql+=" 5 end end end end";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(dstuoi.Tables[0],"ma='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["ten"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					z01+=decimal.Parse(r["c01"].ToString());
					z02+=decimal.Parse(r["c02"].ToString());
					z03+=decimal.Parse(r["c03"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","ma"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_15()
		{
			dstmp.Clear();
			sql="select trim(a.maicd)||'-'||a.chandoan as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 1 else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else 1 end) as c02,";
            sql += " sum(1) as c03 from xxx.benhanpk a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdtt c on b.matt=c.matt";
            sql += " inner join " + user + ".btdquan d on b.maqu=d.maqu";
            sql += " inner join " + user + ".btdpxa e on b.maphuongxa=e.maphuongxa";
            sql += " inner join " + user + ".btdnn_bv f on b.mann=f.mann";
            //sql += " inner join " + user + ".xuatvien g on a.maql=g.maql";
            sql += " where a.ttlucrv is not null and " + m.for_ngay("a.ngay", s_time) + " between to_date('" + s_tu + "'," + s_time + ") and to_date('" + s_den + "'," + s_time + ")";
			if (maicd.Text!="") sql+=" and a.maicd like '%"+maicd.Text.Trim()+"%'";
            else sql += " and a.maicd in (select ma from " + user + ".bctheoicd)";
			sql+=" group by trim(a.maicd)||'-'||a.chandoan";
            dt = m.get_data_mmyy(sql, s_tu, s_den, false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			int stt=1;
			foreach(DataRow r in dt.Rows)
			{
				r1=dstmp.Tables[0].NewRow();
				r1["ma"]=stt++;
				r1["noidung"]=r["ma"].ToString();
				r1["c01"]=r["c01"].ToString();
				r1["c02"]=r["c02"].ToString();
				r1["c03"]=r["c03"].ToString();
				z01+=decimal.Parse(r["c01"].ToString());
				z02+=decimal.Parse(r["c02"].ToString());
				z03+=decimal.Parse(r["c03"].ToString());
				dstmp.Tables[0].Rows.Add(r1);
			}
			ds.Clear();
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="A";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load()
		{
            s_tu = tu.Text;
            s_den = den.Text;
            s_time = "'" + m.f_ngay + "'";
			if (rb1.Checked) load_1();
			else if (rb2.Checked) load_2();
			else if (rb4.Checked) load_4();
			else if (rb5.Checked) load_5();
			else if (rb6.Checked) load_6();
			else if (rb7.Checked) load_7();
			else if (rb8.Checked) load_8();
			else if (rb10.Checked) load_10();
			else if (rb11.Checked) load_11();
			else if (rb12.Checked) load_12();
			else if (rb13.Checked) load_13();
			else if (rb15.Checked) load_15();
			else if (rb16.Checked) load_16();
		}

		private void rb1_CheckedChanged(object sender, System.EventArgs e)
		{
			chkMabn.Enabled=rb1.Checked;
			
		}

		private void rb2_CheckedChanged(object sender, System.EventArgs e)
		{
			chkMabn.Enabled=rb2.Checked;
			
		}

		private void butICD10_Click(object sender, System.EventArgs e)
		{
			frmDmbcicd f=new frmDmbcicd(m);
			f.ShowDialog(this);
		}
	}
}
