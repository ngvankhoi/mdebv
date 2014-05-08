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
	/// Summary description for rptThekho.
	/// </summary>
	public class rptThekho : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_userid=0;
		private string sql,s_rpt,s_tu,s_den,s_yy,s_kho,user,xxx;
		private DataRow []dr;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable tmpkho=new DataTable();
		private DataSet dsdm=new DataSet();
		private DataTable dtkhac=new DataTable();
		private DataTable dtphieu=new DataTable();
		private DataTable dtloaint=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtkho=new DataTable();
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged,bGiaban;
		int checkCol=0;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.NumericUpDown den;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox theo;
        private CheckBox chktra;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptThekho(AccessData acc,int nhom,string kho,string mmyy,string rpt,string title,bool giaban, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
			this.Text=title;
			s_rpt=rpt;
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			den.Value=tu.Value;bGiaban=giaban;
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
            i_userid = _userid;
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptThekho));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.theo = new System.Windows.Forms.ComboBox();
            this.chktra = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(260, 379);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(330, 379);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // kho
            // 
            this.kho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(480, 6);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(152, 21);
            this.kho.TabIndex = 4;
            this.kho.SelectedIndexChanged += new System.EventHandler(this.kho_SelectedIndexChanged);
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(448, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "Kho :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(200, 6);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 2;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(61, 6);
            this.tu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(38, 21);
            this.tu.TabIndex = 0;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.ValueChanged += new System.EventHandler(this.tu_ValueChanged);
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(10, 10);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(622, 335);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(128, 6);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(38, 21);
            this.den.TabIndex = 1;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.ValueChanged += new System.EventHandler(this.den_ValueChanged);
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(96, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "đến : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(10, 349);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(406, 21);
            this.tim.TabIndex = 8;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(240, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Nguồn :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(296, 6);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(152, 21);
            this.manguon.TabIndex = 3;
            this.manguon.SelectedIndexChanged += new System.EventHandler(this.manguon_SelectedIndexChanged);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(404, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Theo :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theo
            // 
            this.theo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.theo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.theo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theo.Items.AddRange(new object[] {
            "Tất cả",
            "Thuốc Độc",
            "Thuốc thường",
            "Vật tư y tế"});
            this.theo.Location = new System.Drawing.Point(464, 349);
            this.theo.Name = "theo";
            this.theo.Size = new System.Drawing.Size(168, 21);
            this.theo.TabIndex = 29;
            this.theo.SelectedIndexChanged += new System.EventHandler(this.theo_SelectedIndexChanged);
            // 
            // chktra
            // 
            this.chktra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chktra.AutoSize = true;
            this.chktra.Location = new System.Drawing.Point(464, 371);
            this.chktra.Name = "chktra";
            this.chktra.Size = new System.Drawing.Size(97, 17);
            this.chktra.TabIndex = 31;
            this.chktra.Text = "Trả in cột riêng";
            this.chktra.UseVisualStyleBackColor = true;
            // 
            // rptThekho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(642, 423);
            this.Controls.Add(this.chktra);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.theo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptThekho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ chi tiết";
            this.Load += new System.EventHandler(this.rptThekho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptThekho_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			theo.SelectedIndex=0;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtkho;

            tmpkho = d.get_data("select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom).Tables[0];
            dtkhac = d.get_data("select * from " + user + ".d_dmkhac where nhom=0 or nhom=" + i_nhom + " order by stt").Tables[0];
            dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + i_nhom + " order by stt").Tables[0];
            dtloaint = d.get_data("select * from " + user + ".d_dmloaint where nhom=" + i_nhom + " order by stt").Tables[0];
            dtkp = d.get_data("select * from " + user + ".d_duockp where (nhom is null or nhom='' or nhom like '%" + i_nhom.ToString() + ",%'" + ") order by stt").Tables[0];
            dt = d.get_data("select a.*,b.ten as tenhang,c.ten as tennuoc,d.ten as tennhom from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnuoc c," + user + ".d_dmnhom d where a.mahang=b.id and a.manuoc=c.id and a.manhom=d.id and a.nhom=" + i_nhom + " order by a.id").Tables[0];
			dsdm.ReadXml("..\\..\\..\\xml\\d_thekho.xml");
			ds.ReadXml("..\\..\\..\\xml\\d_sochitiet.xml");
			//dsxml.ReadXml("..\\..\\..\\xml\\d_sochitiet.xml");
			dsdm.Tables[0].Columns.Add("Chon",typeof(bool));
            ds.Tables[0].Columns.Add("sltra", typeof(decimal)).DefaultValue = 0;
            ds.Tables[0].Columns.Add("sttra", typeof(decimal)).DefaultValue = 0;
            ds.Tables[0].Columns.Add("ngaysp");
            dsxml=ds.Copy();//
			load_grid();
			AddGridTableStyle();

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsdm.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width =50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 250;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "toncuoi";
			TextCol.HeaderText = "Tồn";
			TextCol.Width =55;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					//				e.BackBrush = this.disabledBackBrush;
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
			afterCurrentCellChanged = false;
		}

		private void load_grid()
		{
			dsdm.Clear();
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			for(int i=int.Parse(s_tu);i<=int.Parse(s_den);i++)
			{
                if (d.bMmyy(i.ToString().PadLeft(2, '0') + s_yy))
                {
                    xxx = user + i.ToString().PadLeft(2, '0') + s_yy;
                    sql = "select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tenhang,a.tondau+a.slnhap-a.slxuat as toncuoi,e.stt from "+xxx+".d_tonkhoth a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnhom d," + user + ".d_nhomin e where (a.mabd=b.id and b.mahang=c.id and b.manhom=d.id and d.nhomin=e.id and a.makho=" + int.Parse(kho.SelectedValue.ToString());
                    if (manguon.SelectedIndex != -1) sql += " and a.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                    sql += ") and (a.tondau<>0 or a.slnhap<>0 or a.slxuat<>0) order by b.ten";
                    foreach (DataRow r in d.get_data(sql).Tables[0].Rows) d.updrec_thekho(dsdm.Tables[0], int.Parse(r["mabd"].ToString()), r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenhang"].ToString(), decimal.Parse(r["toncuoi"].ToString()), int.Parse(r["stt"].ToString()));
                }
			}
			dataGrid1.DataSource=dsdm.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
			load_theo();
		}

		private void kho_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==kho) load_grid();
		}

		private void Loc()
		{
			d.execute_data("delete from "+user+".d_mabd");
			DataRow[] dr=dsdm.Tables[0].Select("chon=true");
			string mmyy;
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (dr.Length==0)
			{
				for(int i=int.Parse(s_tu);i<=int.Parse(s_den);i++)
				{
					mmyy=i.ToString().PadLeft(2,'0')+s_yy;
                    if (d.bMmyy(mmyy))
                    {
                        xxx = user + mmyy;
                      	foreach(DataRow r in d.get_data("select distinct mabd from "+xxx+".d_tonkhoth where makho="+int.Parse(kho.SelectedValue.ToString())).Tables[0].Rows)
    						d.upd_mabd(int.Parse(r["mabd"].ToString()));
                    }
				}
			}
			else for(int i=0;i<dr.Length;i++) d.execute_data("insert into "+user+".d_mabd(mabd) values ("+int.Parse(dr[i]["mabd"].ToString())+")");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (den.Value<tu.Value)
			{
				MessageBox.Show(lan.Change_language_MessageText("Tháng không hợp lệ !"),d.Msg);
				return;
			}
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			ds.Clear();
			Loc();
			ds.Merge(d.get_tondau(ds,dt,s_tu+s_yy,int.Parse(kho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?-1:int.Parse(manguon.SelectedValue.ToString()),i_nhom));
            ds.Merge(d.get_nhap(ds, dt, dtkp, tmpkho, s_tu, s_den, s_yy, int.Parse(kho.SelectedValue.ToString()), (manguon.SelectedIndex == -1) ? -1 : int.Parse(manguon.SelectedValue.ToString()), i_nhom, chktra.Checked));
			ds.Merge(d.get_xuat(ds,dt,dtkp,dtloaint,dtkhac,tmpkho,s_tu,s_den,s_yy,int.Parse(kho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?-1:int.Parse(manguon.SelectedValue.ToString()),i_nhom));
			get_sort();
			if (dsxml.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
            if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
            dsxml.WriteXml("..\\..\\dataxml\\thekho.xml", XmlWriteMode.WriteSchema);
            string tmp_rpt = s_rpt;
            if (chktra.Checked) tmp_rpt = tmp_rpt.Replace(".rpt", "") + "_tra.rpt";
            if (System.IO.File.Exists("..\\..\\..\\report\\" + tmp_rpt) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy file '" + tmp_rpt + "', chương trình sẽ load file '")+" "+ s_rpt + "'");
                tmp_rpt = s_rpt;
            }
            frmReport f = new frmReport(d, dsxml.Tables[0], i_userid, tmp_rpt, kho.Text, (s_tu == s_den) ? "Tháng " + s_tu + " năm " + yyyy.Value.ToString() : "Từ tháng " + s_tu + " đến " + s_den + " năm " + yyyy.Value.ToString(), (manguon.SelectedIndex == -1) ? "" : manguon.Text, "", "", "", "", "", "", (bGiaban) ? "Cửa Hàng Trưởng" : "Khoa Dược");
			f.ShowDialog();
		}

		private void get_sort()
		{
			dsxml.Clear();
			decimal slton=0,stton=0;
			string s_ma="";
			dr=ds.Tables[0].Select("ma<>''","ma,ten,yymmdd");
			for(int i=0;i<dr.Length;i++)
			{
				if (dr[i]["ma"].ToString()!=s_ma)
				{
					s_ma=dr[i]["ma"].ToString();
                    slton = decimal.Parse(dr[i]["tondau"].ToString()) + decimal.Parse(dr[i]["slnhap"].ToString()) + decimal.Parse(dr[i]["sltra"].ToString()) - decimal.Parse(dr[i]["slxuat"].ToString());
                    stton = decimal.Parse(dr[i]["sttondau"].ToString()) + decimal.Parse(dr[i]["stnhap"].ToString()) + decimal.Parse(dr[i]["sttra"].ToString()) - decimal.Parse(dr[i]["stxuat"].ToString());
				}
				else
				{
                    slton += decimal.Parse(dr[i]["slnhap"].ToString()) + decimal.Parse(dr[i]["sltra"].ToString()) - decimal.Parse(dr[i]["slxuat"].ToString());
                    stton += decimal.Parse(dr[i]["stnhap"].ToString()) + decimal.Parse(dr[i]["sttra"].ToString()) - decimal.Parse(dr[i]["stxuat"].ToString());
				}
				dsxml.Merge(d.ins_items(dsxml,dr,i,slton,stton));
			}
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="ten like '%"+tim.Text.Trim()+"%' or ma like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butIn.Focus();
		}

		private void manguon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==manguon) load_grid();
		}

		private void theo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==theo) load_theo();
		}

		private void load_theo()
		{
			foreach (DataRow row in dsdm.Tables[0].Rows) 
			{
				if (theo.SelectedIndex==1) row["chon"]=int.Parse(row["stt"].ToString())<4;
				else if (theo.SelectedIndex==2) row["chon"]=int.Parse(row["stt"].ToString())==4;
				else if (theo.SelectedIndex==3) row["chon"]=int.Parse(row["stt"].ToString())==5;
				else row["chon"]=false;
			}
		}

		private void tu_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tu) load_grid();
		}

        private void den_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == den) load_grid();//gam 19/09/2011
        }
	}
}
