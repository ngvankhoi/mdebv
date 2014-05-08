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
	public class frmHiendiennt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
		private DataSet ds=new DataSet("hiendien");
		private System.Windows.Forms.Button butketthuc;
		private System.Windows.Forms.Button butInReport;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox makp;
		private string s_makp;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Button butXem;
        private string user = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHiendiennt(AccessData acc,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHiendiennt));
            this.butketthuc = new System.Windows.Forms.Button();
            this.butInReport = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butketthuc
            // 
            this.butketthuc.BackColor = System.Drawing.Color.Transparent;
            this.butketthuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.butketthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butketthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butketthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(431, 483);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 4;
            this.butketthuc.Text = " &Kết thúc";
            this.butketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butketthuc.UseVisualStyleBackColor = false;
            this.butketthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butInReport
            // 
            this.butInReport.BackColor = System.Drawing.Color.Transparent;
            this.butInReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.butInReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInReport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butInReport.Image = ((System.Drawing.Image)(resources.GetObject("butInReport.Image")));
            this.butInReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInReport.Location = new System.Drawing.Point(361, 483);
            this.butInReport.Name = "butInReport";
            this.butInReport.Size = new System.Drawing.Size(70, 25);
            this.butInReport.TabIndex = 3;
            this.butInReport.Text = "     &In";
            this.butInReport.UseVisualStyleBackColor = false;
            this.butInReport.Click += new System.EventHandler(this.butInReport_Click);
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
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(12, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(768, 456);
            this.dataGrid1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(56, 8);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(728, 21);
            this.makp.TabIndex = 1;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(12, 488);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(252, 23);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "label2";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butXem
            // 
            this.butXem.BackColor = System.Drawing.Color.Transparent;
            this.butXem.Cursor = System.Windows.Forms.Cursors.Default;
            this.butXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(291, 483);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 2;
            this.butXem.Text = "     &Xem";
            this.butXem.UseVisualStyleBackColor = false;
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // frmHiendiennt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 583);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.butInReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHiendiennt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người bệnh hiện diện tại Khoa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHiendiennt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHiendiennt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmHiendiennt_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			load_khoa();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
		}

		private void load_khoa()
		{
            string sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
			if (s_makp!="") sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by makp";
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=m.get_data(sql).Tables[0];
		}

		private void load_grid()
		{
			string sql="select e.tenkp as khoa,a.mabn,b.hoten,a.sovaovien,case when b.phai=0 then 'Nam' else 'Nu' end as phai,b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay";
            sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn b on a.mabn=b.mabn";
            sql += " inner join " + user + ".btdkp_bv e on a.makp=e.makp where a.ttlucrv=0 and a.ketqua=0";
			if (makp.SelectedIndex!=-1)	sql+=" and a.makp='"+makp.SelectedValue.ToString()+"'";
			sql+=" order by a.makp,a.ngay desc";            
			ds=m.get_data(sql);
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
			TextCol.Width = 160;
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
			TextCol.Width = 180;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "phai";
			TextCol.HeaderText = "Giới tính";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "Năm sinh";
			TextCol.Width = 80;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "sovaovien";
            TextCol.HeaderText = "Số vào viện";
            TextCol.Width = 80;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            //TextCol=new DataGridColoredTextBoxColumn(de, 6);
            //TextCol.MappingName = "tenkp";
            //TextCol.HeaderText = "Nơi chuyển";
            //TextCol.Width = 130;
            //ts.GridColumnStyles.Add(TextCol);
            //dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			return c;
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
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				return;
			}
			string msg;
			if (makp.SelectedIndex!=-1) msg="Khoa "+" "+makp.Text.ToString();
			else msg="Toàn viện";
			dllReportM.frmReport f = new dllReportM.frmReport(m,ds,msg,"dshiendien.rpt");
			f.Show();
		}

		private void frmHiendiennt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
			load_grid();
		}
	}
}
