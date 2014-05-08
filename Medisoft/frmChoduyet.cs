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
	/// Summary description for frmChoduyet.
	/// </summary>
	public class frmChoduyet : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		///
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private int i_nhom;
		private string user;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged;
		private int checkCol=0;
		private System.Windows.Forms.Button butLuu;
		private System.ComponentModel.Container components = null;

		public frmChoduyet(int _nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			i_nhom=_nhom;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChoduyet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butXem = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(64, 4);
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
            this.den.Location = new System.Drawing.Point(176, 4);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butXem
            // 
            this.butXem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butXem.Location = new System.Drawing.Point(258, 4);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(60, 21);
            this.butXem.TabIndex = 4;
            this.butXem.Text = "&Tìm";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butKetthuc.Location = new System.Drawing.Point(384, 4);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(60, 21);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
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
            this.dataGrid1.Location = new System.Drawing.Point(5, 9);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(783, 561);
            this.dataGrid1.TabIndex = 7;
            // 
            // butLuu
            // 
            this.butLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butLuu.Location = new System.Drawing.Point(321, 4);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 21);
            this.butLuu.TabIndex = 5;
            this.butLuu.Text = "Đồng ý";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // frmChoduyet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChoduyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Những thuốc chờ lãnh đạo duyệt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChoduyet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmChoduyet_Load(object sender, System.EventArgs e)
		{
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			user=d.user;
			ds.ReadXml("..\\..\\..\\xml\\d_ylenh.xml");
            ds.Tables[0].Columns.Add("ngay");
            ds.Tables[0].Columns.Add("ten");
            ds.Tables[0].Columns.Add("dang");
            ds.Tables[0].Columns.Add("slylenh",typeof(decimal));
            ds.Tables[0].Columns.Add("tenkp");
            ds.Tables[0].Columns.Add("tenbs");
            ds.Tables[0].Columns.Add("cachdung");
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Duyệt";
			discontinuedCol.Width = 35;
			discontinuedCol.ReadOnly=false;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);


			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 55;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc - hàm lượng";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 30;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "slylenh";
			TextCol.HeaderText = "SL";
			TextCol.Width = 45;
			TextCol.Format="### ##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 80;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "tenbs";
			TextCol.HeaderText = "Bác sĩ";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";
			TextCol.HeaderText = "Mã BN";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên bệnh nhân";
			TextCol.Width = 160;
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
			Rectangle rect = this.dataGrid1.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void load_grid()
		{
            string stime = "'" + m.f_ngay + "'";
			string sql="select to_char(c.ngay,'dd/mm/yy') as ngay,d.ten,d.dang,b.slyeucau as slylenh,g.tenkp,i.hoten as tenbs,a.mabn,e.hoten,b.cachdung,b.choduyet,b.id,b.stt";
            sql += " from xxx.d_dutrull a,xxx.d_dutruct b,xxx.d_duyet c," + user + ".d_dmbd d," + user + ".btdbn e," + user + ".d_duockp f," + user + ".btdkp_bv g,xxx.d_dausinhton h," + user + ".dmbs i";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and a.mabn=e.mabn and c.makhoa=f.id and f.makp=g.makp ";
			sql+=" and a.id=h.id and h.mabs=i.ma ";
            sql += " and " + m.for_ngay("c.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and d.choduyet=1 and c.nhom="+i_nhom+" order by c.ngay,d.ten";
			ds=d.get_data_mmyy(sql,tu.Text,den.Text,true);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			foreach(DataRow r in ds.Tables[0].Rows) r["chon"]=r["choduyet"].ToString()=="0";
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			load_grid();
			tu.Focus();
			Cursor=Cursors.Default;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();d.close();
			System.GC.Collect();
			this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			foreach(DataRow r in ds.Tables[0].Rows)
				m.execute_data_mmyy("update xxx.d_dutruct set choduyet="+((r["chon"].ToString().ToLower()=="true")?0:1)+" where id="+decimal.Parse(r["id"].ToString())+" and stt="+decimal.Parse(r["stt"].ToString()),tu.Text,den.Text,true);
			load_grid();
		}
	}
}
