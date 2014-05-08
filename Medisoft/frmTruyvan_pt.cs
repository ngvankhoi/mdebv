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
	/// Summary description for frmTruyvan_kb.
	/// </summary>
	public class frmTruyvan_pt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private DataSet ds=new DataSet();
		private DataSet dstmp=new DataSet();
		private DataSet dstuoi=new DataSet();
		private DataTable dtkp=new DataTable();
		private DataTable dtpm=new DataTable();
		private DataTable dt;
		private AccessData m;
		private DataRow r1,r2;
		private string sql,s_makp,s_mapm;
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
		private System.Windows.Forms.Button butTonghop;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox pt;
		private System.Windows.Forms.CheckedListBox mapm;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private CheckBox chkmonoisoi;
        private CheckBox chkmolai;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTruyvan_pt(AccessData acc)
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
        public frmTruyvan_pt()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTruyvan_pt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.opt = new System.Windows.Forms.GroupBox();
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
            this.butTonghop = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.pt = new System.Windows.Forms.TextBox();
            this.mapm = new System.Windows.Forms.CheckedListBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkmonoisoi = new System.Windows.Forms.CheckBox();
            this.chkmolai = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.opt.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(294, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(480, 507);
            this.dataGrid1.TabIndex = 10;
            // 
            // opt
            // 
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
            this.opt.Location = new System.Drawing.Point(8, 32);
            this.opt.Name = "opt";
            this.opt.Size = new System.Drawing.Size(280, 283);
            this.opt.TabIndex = 4;
            this.opt.TabStop = false;
            // 
            // rb15
            // 
            this.rb15.Location = new System.Drawing.Point(12, 257);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(220, 18);
            this.rb15.TabIndex = 14;
            this.rb15.Text = "Phương pháp";
            // 
            // rb14
            // 
            this.rb14.Location = new System.Drawing.Point(12, 238);
            this.rb14.Name = "rb14";
            this.rb14.Size = new System.Drawing.Size(156, 18);
            this.rb14.TabIndex = 13;
            this.rb14.Text = "Giới tính";
            // 
            // rb13
            // 
            this.rb13.Location = new System.Drawing.Point(12, 219);
            this.rb13.Name = "rb13";
            this.rb13.Size = new System.Drawing.Size(256, 18);
            this.rb13.TabIndex = 12;
            this.rb13.Text = "Độ tuổi";
            // 
            // rb12
            // 
            this.rb12.Location = new System.Drawing.Point(12, 200);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(256, 18);
            this.rb12.TabIndex = 11;
            this.rb12.Text = "Địa phương";
            // 
            // rb11
            // 
            this.rb11.Location = new System.Drawing.Point(12, 181);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(256, 18);
            this.rb11.TabIndex = 10;
            this.rb11.Text = "Khoa";
            // 
            // rb10
            // 
            this.rb10.Location = new System.Drawing.Point(12, 162);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(256, 18);
            this.rb10.TabIndex = 9;
            this.rb10.Text = "Phòng mỗ";
            // 
            // rb9
            // 
            this.rb9.Location = new System.Drawing.Point(12, 143);
            this.rb9.Name = "rb9";
            this.rb9.Size = new System.Drawing.Size(256, 18);
            this.rb9.TabIndex = 8;
            this.rb9.Text = "PTV chính";
            // 
            // rb8
            // 
            this.rb8.Location = new System.Drawing.Point(12, 126);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(256, 16);
            this.rb8.TabIndex = 7;
            this.rb8.Text = "Theo trẻ em";
            // 
            // rb7
            // 
            this.rb7.Location = new System.Drawing.Point(12, 107);
            this.rb7.Name = "rb7";
            this.rb7.Size = new System.Drawing.Size(256, 18);
            this.rb7.TabIndex = 6;
            this.rb7.Text = "Nghề nghiệp";
            // 
            // rb6
            // 
            this.rb6.Location = new System.Drawing.Point(12, 88);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(256, 18);
            this.rb6.TabIndex = 5;
            this.rb6.Text = "Đối tượng";
            // 
            // rb5
            // 
            this.rb5.Location = new System.Drawing.Point(12, 69);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(92, 18);
            this.rb5.TabIndex = 4;
            this.rb5.Text = "Tên thủ thuật";
            // 
            // rb4
            // 
            this.rb4.Location = new System.Drawing.Point(12, 50);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(100, 18);
            this.rb4.TabIndex = 3;
            this.rb4.Text = "Tên phẫu thuật";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(12, 31);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(256, 18);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Theo loại phẫu thủ thuật";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(12, 12);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(256, 18);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Phẫu thuật - thủ thuật";
            // 
            // butTonghop
            // 
            this.butTonghop.Image = ((System.Drawing.Image)(resources.GetObject("butTonghop.Image")));
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(324, 496);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(74, 25);
            this.butTonghop.TabIndex = 8;
            this.butTonghop.Text = "Tổng hợp";
            this.butTonghop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTonghop.Click += new System.EventHandler(this.butTonghop_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(398, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // pt
            // 
            this.pt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pt.Location = new System.Drawing.Point(72, 319);
            this.pt.Name = "pt";
            this.pt.Size = new System.Drawing.Size(216, 21);
            this.pt.TabIndex = 5;
            this.pt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mapm
            // 
            this.mapm.CheckOnClick = true;
            this.mapm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapm.Location = new System.Drawing.Point(72, 430);
            this.mapm.Name = "mapm";
            this.mapm.Size = new System.Drawing.Size(216, 68);
            this.mapm.TabIndex = 7;
            this.mapm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(72, 343);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(216, 84);
            this.makp.TabIndex = 6;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mã pttt :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Khoa :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Phòng mỗ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkmonoisoi
            // 
            this.chkmonoisoi.AutoSize = true;
            this.chkmonoisoi.Location = new System.Drawing.Point(72, 504);
            this.chkmonoisoi.Name = "chkmonoisoi";
            this.chkmonoisoi.Size = new System.Drawing.Size(74, 17);
            this.chkmonoisoi.TabIndex = 15;
            this.chkmonoisoi.Text = "Mổ nội soi";
            this.chkmonoisoi.UseVisualStyleBackColor = true;
            // 
            // chkmolai
            // 
            this.chkmolai.AutoSize = true;
            this.chkmolai.Location = new System.Drawing.Point(72, 520);
            this.chkmolai.Name = "chkmolai";
            this.chkmolai.Size = new System.Drawing.Size(98, 17);
            this.chkmolai.TabIndex = 16;
            this.chkmolai.Text = "Mổ lại miễn phí";
            this.chkmolai.UseVisualStyleBackColor = true;
            // 
            // frmTruyvan_pt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.chkmolai);
            this.Controls.Add(this.chkmonoisoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mapm);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.opt);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTruyvan_pt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy vấn thông tin phẫu thủ thuật";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTruyvan_pt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.opt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTruyvan_pt_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			dtkp=m.get_data("select * from "+m.user+".btdkp_bv order by loai,makp").Tables[0];
            makp.DataSource = dtkp;
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";
			dtpm=m.get_data("select * from "+m.user+".btdpmo order by ma").Tables[0];
            mapm.DataSource = dtpm;
            mapm.DisplayMember = "TEN";
			mapm.ValueMember="MA";
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
			TextCol1.HeaderText = "Mã";//(rb4.Checked || rb5.Checked)?"Mã":"";
			TextCol1.Width = 80;//(rb4.Checked || rb5.Checked)?60:0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "noidung";
			TextCol1.HeaderText = "Nội dung";
			TextCol1.Width = 185;//(rb4.Checked || rb5.Checked)?205:265;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "c01";
			TextCol1.HeaderText = "T.Phố";
			TextCol1.Width = 60;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "c02";
			TextCol1.HeaderText = "Tỉnh";
			TextCol1.Width = 60;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "c03";
			TextCol1.HeaderText = "Tổng số";
			TextCol1.Width = 60;
			TextCol1.Format="# ### ###";
			TextCol1.Alignment=HorizontalAlignment.Right;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,0].ToString().Trim()=="") return Color.Red;
			else return Color.Black;
		}

	
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			s_makp="";
			s_mapm="";
			string s_tenkp="",s_tenpm="";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) 
				{
					s_makp+=dtkp.Rows[i]["makp"].ToString()+",";
					s_tenkp+=dtkp.Rows[i]["tenkp"].ToString()+",";
				}
			for(int i=0;i<mapm.Items.Count;i++)
				if (mapm.GetItemChecked(i)) 
				{
					s_mapm+=dtpm.Rows[i]["ma"].ToString()+",";
					s_tenpm+=dtpm.Rows[i]["ten"].ToString()+",";
				}
			if (s_makp!="") s_makp=s_makp.Replace(",","','");
			if (s_mapm!="") s_mapm=s_mapm.Replace(",","','");
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
			sql="select ";
			sql+=" substr(a.mamau,1,1) as ma,";
			sql+="sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by substr(a.mamau,1,1) order by substr(a.mamau,1,1)";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal c01=0,c02=0;
			foreach(DataRow r in dt.Rows)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]=r["ma"].ToString();
				r1["noidung"]=(r["ma"].ToString()=="P")?"Phẫu thuật":"Thủ thuật";
				r1["c01"]=r["c01"].ToString();
				r1["c02"]=r["c02"].ToString();
				r1["c03"]=r["c03"].ToString();
				c01+=decimal.Parse(r["c01"].ToString());
				c02+=decimal.Parse(r["c02"].ToString());
				ds.Tables[0].Rows.Add(r1);
			}
			r1=ds.Tables[0].NewRow();
			r1["ma"]="";
			r1["noidung"]="TỔNG CỘNG :";
			r1["c01"]=c01;
			r1["c02"]=c02;
			r1["c03"]=c01+c02;
			ds.Tables[0].Rows.Add(r1);
		}

		private void load_2()
		{/*
          * xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f,"+m.user+".dmpttt g
          * 
          * a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann
          * */
            ds.Clear();
			DataTable tmp=m.get_data("select * from "+m.user+".loaipttt").Tables[0];
			sql="select ";
			sql+=" g.loaipt as ma,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f,"+m.user+".dmpttt g";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and a.mapt=g.mapt and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by g.loaipt order by g.loaipt";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal c01=0,c02=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"ma="+int.Parse(r["ma"].ToString()));
				if (r2!=null)
				{
					r1=ds.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["ten"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					c01+=decimal.Parse(r["c01"].ToString());
					c02+=decimal.Parse(r["c02"].ToString());
					ds.Tables[0].Rows.Add(r1);
				}
			}
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG :";
				r1["c01"]=c01;
				r1["c02"]=c02;
				r1["c03"]=c01+c02;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_4()
		{/*
          * xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f
          * 
          * a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann
			and substr(a.mamau,1,1)='P'
          * */
            dstmp.Clear();
			ds.Clear();
			sql="select ";
			sql+=" a.mamau,a.tenpt,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and substr(a.mamau,1,1)='P' and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by a.mamau,a.tenpt order by a.mamau,a.tenpt";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal c01=0,c02=0;
			foreach(DataRow r in dt.Rows)
			{
				r1=dstmp.Tables[0].NewRow();
				r1["ma"]=r["mamau"].ToString();
				r1["noidung"]=r["tenpt"].ToString();
				r1["c01"]=r["c01"].ToString();
				r1["c02"]=r["c02"].ToString();
				r1["c03"]=r["c03"].ToString();
				c01+=decimal.Parse(r["c01"].ToString());
				c02+=decimal.Parse(r["c02"].ToString());
				dstmp.Tables[0].Rows.Add(r1);
			}
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG :";
				r1["c01"]=c01;
				r1["c02"]=c02;
				r1["c03"]=c01+c02;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_5()
		{
			ds.Clear();
			dstmp.Clear();
			sql="select ";
			sql+=" a.mamau,a.tenpt,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and substr(a.mamau,1,1)='T' and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by a.mamau,a.tenpt order by a.mamau,a.tenpt";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal c01=0,c02=0;
			foreach(DataRow r in dt.Rows)
			{
				r1=dstmp.Tables[0].NewRow();
				r1["ma"]=r["mamau"].ToString();
				r1["noidung"]=r["tenpt"].ToString();
				r1["c01"]=r["c01"].ToString();
				r1["c02"]=r["c02"].ToString();
				r1["c03"]=r["c03"].ToString();
				c01+=decimal.Parse(r["c01"].ToString());
				c02+=decimal.Parse(r["c02"].ToString());
				dstmp.Tables[0].Rows.Add(r1);
			}
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG :";
				r1["c01"]=c01;
				r1["c02"]=c02;
				r1["c03"]=c01+c02;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_6()
		{
			ds.Clear();
			dstmp.Clear();
			DataTable tmp=m.get_data("select * from "+m.user+".doituong").Tables[0];
			sql="select ";
			sql+="a.madoituong as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by ";
			sql+=" a.madoituong";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal c01=0,c02=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"madoituong="+int.Parse(r["ma"].ToString()));
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["doituong"].ToString();
					r1["c01"]=r["c01"].ToString();
					r1["c02"]=r["c02"].ToString();
					r1["c03"]=r["c03"].ToString();
					c01+=decimal.Parse(r["c01"].ToString());
					c02+=decimal.Parse(r["c02"].ToString());
					dstmp.Tables[0].Rows.Add(r1);
				}
			}
			ds.Merge(dstmp.Tables[0].Select("true","c03 desc"));
			if (dt.Rows.Count>0)
			{
				r1=ds.Tables[0].NewRow();
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG :";
				r1["c01"]=c01;
				r1["c02"]=c02;
				r1["c03"]=c01+c02;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_7()
		{
			dstmp.Clear();
			DataTable tmp=m.get_data("select * from "+m.user+".btdnn_bv").Tables[0];
			sql="select b.mann as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by b.mann";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
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
				r1["ma"]="";
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
			DataTable tmp=m.get_data("select * from "+m.user+".btdtt").Tables[0];
			sql="select b.matt as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by b.matt";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
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
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_14()
		{
			dstmp.Clear();
			DataTable tmp=m.get_data("select * from "+m.user+".dmphai").Tables[0];
			sql="select b.phai as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
            if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
			sql+=" group by b.phai";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
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
				r1["ma"]="";
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
			int nam=int.Parse(tu.Text.Substring(6,4));
			sql="select ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=4 then 1 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=6 then 2 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=14 then 3 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)>=15 and "+nam+"-to_number(b.namsinh)<=60 then 4 else ";
			sql+=" 5 end end end end as ma,";
			sql+="sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			sql+=" and "+nam+"-to_number(b.namsinh)<=14";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by case when "+nam+"-to_number(b.namsinh)<=4 then 1 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=6 then 2 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=14 then 3 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)>=15 and "+nam+"-to_number(b.namsinh)<=60 then 4 else ";
			sql+=" 5 end end end end";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
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
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load_9()
		{
			dstmp.Clear();
			DataTable tmp=m.get_data("select * from "+m.user+".dmbs").Tables[0];
			sql="select a.ptv as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by a.ptv";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"ma='"+r["ma"].ToString()+"'");
				if (r2!=null)
				{
					r1=dstmp.Tables[0].NewRow();
					r1["ma"]=r["ma"].ToString();
					r1["noidung"]=r2["hoten"].ToString();
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
				r1["ma"]="";
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
			DataTable tmp=m.get_data("select * from "+m.user+".btdpmo").Tables[0];
			sql="select a.mapmo as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by a.mapmo";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"ma='"+r["ma"].ToString()+"'");
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
				r1["ma"]="";
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
			DataTable tmp=m.get_data("select * from "+m.user+".btdkp_bv").Tables[0];
			sql="select a.makp as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by a.makp";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
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
				r1["ma"]="";
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
			int nam=int.Parse(tu.Text.Substring(6,4));
			sql="select ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=4 then 1 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=6 then 2 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=14 then 3 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)>=15 and "+nam+"-to_number(b.namsinh)<=60 then 4 else ";
			sql+=" 5 end end end end as ma,";
			sql+="sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by case when "+nam+"-to_number(b.namsinh)<=4 then 1 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=6 then 2 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)<=14 then 3 else ";
			sql+=" case when "+nam+"-to_number(b.namsinh)>=15 and "+nam+"-to_number(b.namsinh)<=60 then 4 else ";
			sql+=" 5 end end end end";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
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
				r1["ma"]="";
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
            DataTable tmp = m.get_data("select * from " + m.user +".dmmete").Tables[0];
			sql="select a.phuongphap as ma,sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then a.somat else 0 end) as c01,";
			sql+=" sum(case when b.matt='"+m.Mabv.Substring(0,3)+"' then 0 else a.somat end) as c02,";
			sql+=" sum(a.somat) as c03 from xxx.pttt a,"+m.user+".btdbn b,"+m.user+".btdtt c,"+m.user+".btdquan d,"+m.user+".btdpxa e,"+m.user+".btdnn_bv f";
			sql+=" where a.mabn=b.mabn and b.matt=c.matt and b.maqu=d.maqu and b.maphuongxa=e.maphuongxa and b.mann=f.mann";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (pt.Text!="") sql+=" and substr(a.mamau,1,"+pt.Text.Trim().Length+")='"+pt.Text.Trim()+"'";
			if (s_makp!="") sql+=" and a.makp in ('"+s_makp.Substring(0,s_makp.Length-3)+"')";
			if (s_mapm!="") sql+=" and a.mapmo in ('"+s_mapm.Substring(0,s_mapm.Length-3)+"')";
            if (chkmonoisoi.Checked) sql += " and a.noisoi <> 0";
            if (chkmolai.Checked) sql += " and a.molaimien <> 0";
			sql+=" group by a.phuongphap";
			dt=m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0];
			decimal z01=0,z02=0,z03=0;
			foreach(DataRow r in dt.Rows)
			{
				r2=m.getrowbyid(tmp,"ma='"+r["ma"].ToString()+"'");
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
				r1["ma"]="";
				r1["noidung"]="TỔNG CỘNG";
				r1["c01"]=z01;
				r1["c02"]=z02;
				r1["c03"]=z03;
				ds.Tables[0].Rows.Add(r1);
			}
		}

		private void load()
		{
			if (rb1.Checked) load_1();
			else if (rb2.Checked) load_2();
			else if (rb4.Checked) load_4();
			else if (rb5.Checked) load_5();
			else if (rb6.Checked) load_6();
			else if (rb7.Checked) load_7();
			else if (rb8.Checked) load_8();
			else if (rb9.Checked) load_9();
			else if (rb10.Checked) load_10();
			else if (rb12.Checked) load_12();
			else if (rb11.Checked) load_11();
			else if (rb13.Checked) load_13();
			else if (rb14.Checked) load_14();
			else if (rb15.Checked) load_15();
		}
	}
}
