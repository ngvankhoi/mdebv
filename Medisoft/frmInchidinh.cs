using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmInchidinh.
	/// </summary>
	public class frmInchidinh : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private string sql,s_makp,user,xxx;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dtkp=new DataTable();
		private DataTable dtbs=new DataTable();
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged,bClear=true;
		private int checkCol=0;
		private System.Windows.Forms.DateTimePicker ngay;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.CheckBox chkIn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;
        private dllReportM.Print print = new dllReportM.Print();
		private FileStream fstr;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.TextBox mabn;
		private byte[] image;

		public frmInchidinh(AccessData acc,string _makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;s_makp=_makp;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInchidinh));
            this.label1 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.butTim = new System.Windows.Forms.Button();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.mabn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(371, 536);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(441, 536);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(10, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(774, 520);
            this.dataGrid1.TabIndex = 8;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // ngay
            // 
            this.ngay.CustomFormat = "dd/MM/yyyy";
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngay.Location = new System.Drawing.Point(48, 3);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(80, 21);
            this.ngay.TabIndex = 0;
            this.ngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(205, 3);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(171, 21);
            this.makp.TabIndex = 1;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(112, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Phòng khám :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(560, 3);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(224, 21);
            this.tim.TabIndex = 7;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butTim
            // 
            this.butTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(301, 536);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(70, 25);
            this.butTim.TabIndex = 4;
            this.butTim.Text = "     &Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // chkIn
            // 
            this.chkIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIn.Checked = true;
            this.chkIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIn.Location = new System.Drawing.Point(16, 536);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(64, 16);
            this.chkIn.TabIndex = 6;
            this.chkIn.Text = "Chưa in";
            this.chkIn.CheckedChanged += new System.EventHandler(this.chkIn_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(369, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Đối tượng :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(432, 3);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(128, 21);
            this.madoituong.TabIndex = 2;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(10, 26);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(23, 21);
            this.chkAll.TabIndex = 11;
            this.chkAll.Text = "...";
            this.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.chkAll, "Chọn in tất cả");
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXem.Location = new System.Drawing.Point(96, 536);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 16);
            this.chkXem.TabIndex = 12;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // mabn
            // 
            this.mabn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.ForeColor = System.Drawing.Color.Red;
            this.mabn.Location = new System.Drawing.Point(584, 528);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(88, 21);
            this.mabn.TabIndex = 3;
            this.mabn.Text = "MSBN";
            this.mabn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mabn.Visible = false;
            this.mabn.Enter += new System.EventHandler(this.mabn_Enter);
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.TextChanged += new System.EventHandler(this.mabn_TextChanged);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // frmInchidinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIn);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInchidinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In chỉ định";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmInchidinh_MouseMove);
            this.Load += new System.EventHandler(this.frmInchidinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmInchidinh_Load(object sender, System.EventArgs e)
		{
			if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			user=m.user;
			string sql="select * from "+user+".btdkp_bv where makp<>'01' and (maba like '%20%'";
			sql+=" or maba like '%21%'";
			sql+=" or maba like '%22%'";
			sql+=" or maba like '%23%' or loai=1)";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai desc,makp";
			dtkp=m.get_data(sql).Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=dtkp;

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select * from " + user + ".doituong order by madoituong").Tables[0];

			ds.ReadXml("..\\..\\..\\xml\\m_intoa.xml");
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			ds.Tables[0].Columns.Add("id",typeof(decimal));
			ds.Tables[0].Columns.Add("ten");
			dsxml.ReadXml("..\\..\\..\\xml\\m_inchidinh.xml");
			dsxml.Tables[0].Columns.Add("Image", typeof(byte[]));
			dsxml.Tables[0].Columns.Add("id",typeof(decimal));
			dsxml.Tables[0].Columns.Add("ten");
			AddGridTableStyle();

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			chkXem.Checked=m.bPreview;

			//dtbs=m.get_data("select * from dmbs").Tables[0];
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();
			System.GC.Collect();
			this.Close();
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
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "NS";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Dịch vụ";
			TextCol.Width = 200;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Phòng khám";
			TextCol.Width =100;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sỹ";
			TextCol.Width =150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width =300;
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
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
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

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%' or tenbs like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butIn.Focus();
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) SendKeys.Send("{Tab}");
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			if (!m.bMmyy(m.mmyy(ngay.Text)))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				ngay.Focus();
				return;
			}
			xxx=user+m.mmyy(ngay.Text);
			sql="select a.id,a.maql,a.mabn,b.hoten,b.namsinh,c.doituong,d.tenkp,e.hoten as tenbs,a.chandoan,a.lan,f.sothe,g.tenbv,";
			sql+="trim(b.sonha)||' '||trim(b.thon)||' '||trim(j.tenpxa)||' '||trim(i.tenquan)||' '||trim(h.tentt) as diachi,a.mabs,a.madoituong,a.makp,x.ten";
            sql += " from " + xxx + ".v_chidinh a," + user + ".btdbn b," + user + ".doituong c," + user + ".btdkp_bv d," + user + ".dmbs e," + xxx + ".bhyt f," + user + ".dmnoicapbhyt g," + user + ".btdtt h," + user + ".btdquan i," + user + ".btdpxa j," + user + ".v_giavp x ";
			sql+=" where a.mabn=b.mabn and a.madoituong=c.madoituong and a.makp=d.makp and a.mabs=e.ma(+) and a.maql=f.maql(+) and f.mabv=g.mabv(+)";
			sql+=" and b.matt=h.matt and b.maqu=i.maqu and b.maphuongxa=j.maphuongxa and a.mavp=x.id";
			sql+=" and a.loai=2 and to_char(a.ngay,'dd/mm/yyyy')='"+ngay.Text+"'";
			if (makp.SelectedIndex!=-1) sql+=" and a.makp='"+makp.SelectedValue.ToString()+"'";
			if (madoituong.SelectedIndex!=-1) sql+=" and a.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			if (chkIn.Checked) sql+=" and a.lan=0";
			else sql+=" and a.lan<>0";
			sql+=" order by d.tenkp,a.mabn";
			DataRow r1;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1=ds.Tables[0].NewRow();
				r1["id"]=r["id"].ToString();
				r1["mabn"]=r["mabn"].ToString();
				r1["hoten"]=r["hoten"].ToString();
				r1["namsinh"]=r["namsinh"].ToString();
				r1["doituong"]=r["doituong"].ToString();
				r1["tenkp"]=r["tenkp"].ToString();
				r1["tenbs"]=r["tenbs"].ToString();
				r1["chandoan"]=r["chandoan"].ToString();
				r1["lan"]=r["lan"].ToString();
				r1["chon"]=false;
				r1["maql"]=r["maql"].ToString();
				r1["sothe"]=r["sothe"].ToString();
				r1["noidkkcb"]=r["tenbv"].ToString();
				r1["diachi"]=r["diachi"].ToString();
				r1["mabs"]=r["mabs"].ToString();
				r1["ghichu"]=r["makp"].ToString();
				r1["madoituong"]=r["madoituong"].ToString();
				r1["ten"]=r["ten"].ToString();
				ds.Tables[0].Rows.Add(r1);
			}
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void frmInchidinh_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			sql="";
			if (tim.Text!="")
				sql="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%' or tenbs like '%"+tim.Text.Trim()+"%'";
			foreach(DataRow r in ds.Tables[0].Select(sql)) r["chon"]=(chkAll.Checked)?true:false;
		}

		private void in_toa(string id)
		{
				sql="select a.mabn,a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia+a.vattu as dongia,a.soluong*(a.dongia+a.vattu) as sotien,a.maql,a.idkhoa,b.ma, ";
				sql+="l.hoten,l.namsinh,case when l.phai=0 then 'Nam' else 'Nu' end phai,";
				sql+="trim(l.sonha)||' '||trim(l.thon)||' '||trim(o.tenpxa)||','||trim(n.tenquan)||','||trim(m.tentt) as diachi,";
				sql+="coalesce(f.sothe,' ') as sothe,to_char(f.denngay,'dd/mm/yyyy') as denngay,coalesce(h.tenbv,' ') as noigioithieu,";
				sql+="coalesce(i.tenbv,' ') as noicap,'' as sogiuong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
				sql+="'' as maicd,a.chandoan,k.stt as sttnhom,k.ten as nhom,j.stt as sttloai,j.ten as loai,x.hoten as userid,y.hoten as tenbs,a.mabs";
				sql+=" from "+xxx+".v_chidinh a,"+user+".v_giavp b,"+user+".doituong c,"+user+".btdkp_bv d,";
				sql+=xxx+".bhyt f,"+user+".noigioithieu g,"+user+".tenvien h,"+user+".dmnoicapbhyt i,"+user+".v_loaivp j,"+user+".v_nhomvp k,";
				sql+=user+".btdbn l,"+user+".btdtt m,"+user+".btdquan n,"+user+".btdpxa o,"+user+".dlogin x,"+user+".dmbs y";
				sql+=" where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp ";
				sql+=" and b.id_loai=j.id and j.id_nhom=k.ma and a.mabn=l.mabn and l.matt=m.matt and l.maqu=n.maqu and l.maphuongxa=o.maphuongxa";
				sql+=" and a.maql=f.maql(+) and a.maql=g.maql(+) and g.mabv=h.mabv(+) and  f.mabv=i.mabv(+) and a.userid=x.id(+) and a.mabs=y.ma(+)";
				sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+ngay.Text+"'";
				if (id!="") sql+=" and a.id in ("+id.Substring(0,id.Length-1)+")";
				sql+=" order by k.stt";
				dsxml.Merge(m.get_data(sql));
                //foreach(DataRow r in dsxml.Tables[0].Rows)
                //{
                //    if (File.Exists("..\\..\\..\\chuky\\"+r["mabs"].ToString().Trim()+".bmp"))
                //    {
                //        fstr = new FileStream("..\\..\\..\\chuky\\"+r["mabs"].ToString().Trim()+".bmp", FileMode.Open, FileAccess.Read);
                //        image = new byte[fstr.Length];
                //        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                //        fstr.Close();
                //        r["Image"]=image;			
                //    }					
                //}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (m.bInchidinh_dien)
			{
				foreach(DataRow r in ds.Tables[0].Select("chon=true"))
				{
                    DLLPrintchidinh.frmPrintchidinh f1 = new DLLPrintchidinh.frmPrintchidinh();
                    f1.f_Print_Chidinh(false, r["mabn"].ToString(), r["maql"].ToString(), "", ngay.Text.Substring(0, 10),"");
					m.execute_data("update "+xxx+".v_chidinh set lan=lan+1 where mabn='"+r["mabn"].ToString()+"' and to_char(ngay,'dd/mm/yyyy')='"+ngay.Text+"' and loai=2 and makp='"+r["ghichu"].ToString()+"'");
				}
			}
			else
			{
				dsxml.Clear();
				string sid="";
				foreach(DataRow r in ds.Tables[0].Select("chon=true"))
				{
					sid+=r["id"].ToString()+",";					
					sql="update "+xxx+".v_chidinh set lan=lan+1 where id="+decimal.Parse(r["id"].ToString());
					m.execute_data(sql);
				}
				if(sid=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn bệnh nhân !"),LibMedi.AccessData.Msg);
					try
					{
						mabn.Focus();
					}
					catch{}
					return;
				}
				in_toa(sid);
				if (dsxml.Tables[0].Rows.Count>0)
				{
					if (chkXem.Checked)
					{
						dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","rptChidinh.rpt",true);
						f.ShowDialog();
					}
					else print.Printer(m,dsxml,"rptChidinh.rpt","",1);
				}
				else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			}
			butTim_Click(sender,e);
		}

		private void chkIn_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkIn) butTim_Click(sender,e);
		}

		private void mabn_Enter(object sender, System.EventArgs e)
		{
			mabn.Text="";
		}

		private void mabn_Validated(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || mabn.Text.Trim().Length<3) return;
			if (mabn.Text.Trim().Length!=8) mabn.Text=mabn.Text.Substring(0,2)+mabn.Text.Substring(2).PadLeft(6,'0');
		}

		private void mabn_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="mabn like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
