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
	public class frmHiendienngtr : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
		private DataSet ds=new DataSet("hiendien");
		private System.Windows.Forms.Button butketthuc;
		private System.Windows.Forms.Button butInReport;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label lbl;
        private int songay;
        private ComboBox makp;
        private Label label1;
        private Button butXem;
        private string s_makp,user;
        private TextBox tim;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHiendienngtr(AccessData acc,string _makp,int _songay,DataSet _ds)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = _makp; songay = _songay; if (m.bBogo) tv.GanBogo(this, textBox111);
            if (songay != 0) ds = _ds;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHiendienngtr));
            this.butketthuc = new System.Windows.Forms.Button();
            this.butInReport = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.lbl = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butketthuc.BackColor = System.Drawing.Color.Transparent;
            this.butketthuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.butketthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butketthuc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(440, 544);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(70, 25);
            this.butketthuc.TabIndex = 4;
            this.butketthuc.Text = "&Kết thúc";
            this.butketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butketthuc.UseVisualStyleBackColor = false;
            this.butketthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butInReport
            // 
            this.butInReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butInReport.BackColor = System.Drawing.Color.Transparent;
            this.butInReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.butInReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInReport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butInReport.Image = ((System.Drawing.Image)(resources.GetObject("butInReport.Image")));
            this.butInReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInReport.Location = new System.Drawing.Point(370, 544);
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 9);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(778, 534);
            this.dataGrid1.TabIndex = 5;
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(12, 546);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(768, 23);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "label2";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(39, 4);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(554, 21);
            this.makp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXem.BackColor = System.Drawing.Color.Transparent;
            this.butXem.Cursor = System.Windows.Forms.Cursors.Default;
            this.butXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butXem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(300, 544);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 2;
            this.butXem.Text = "     &Xem";
            this.butXem.UseVisualStyleBackColor = false;
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(596, 4);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(189, 21);
            this.tim.TabIndex = 14;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // frmHiendienngtr
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 583);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.butInReport);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHiendienngtr";
            this.Text = "Danh sách người bệnh hiện diện tại ngoại trú";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHiendienngtr_KeyDown);
            this.Load += new System.EventHandler(this.frmHiendienngtr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmHiendienngtr_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            load_khoa();
			load_grid();
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
            if (songay != 0)
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                label1.Visible = makp.Visible = false;
                this.lbl.Location = new System.Drawing.Point(0, 4);
            }
            else this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		}

        private void load_khoa()
        {
            string sql = "select makp,tenkp from " + m.user + ".btdkp_bv where makp<>'01' and (maba like '%20%'";
            sql += " or maba like '%21%'";
            sql += " or maba like '%22%'";
            sql += " or maba like '%23%')";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            sql += " order by loai,makp";
            makp.DisplayMember = "TENKP";
            makp.ValueMember = "MAKP";
            makp.DataSource = m.get_data(sql).Tables[0];
        }

		private void load_grid()
		{
            Cursor = Cursors.WaitCursor;
            if (songay==0)
            {            
                string sql = "select c.tenkp as khoa,a.mabn,b.hoten,case when b.phai=0 then 'Nam' else 'Nữ' end as phai,";
                sql += " b.namsinh,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.tenkp,";
                sql += "date(to_char(now(),'yyyymmdd'))-date(to_char(a.ngay,'yyyymmdd'))+to_number(1) as ngaydt ";
                sql += ", bh.sothe, case when bh.traituyen is null then 0 else bh.traituyen end as traituyen ";
                sql += " from "+user+".benhanngtr a inner join " + user + ".btdbn b on a.mabn=b.mabn";
                sql += " inner join " + user + ".btdkp_bv c on a.makp=c.makp";
                sql += " left join " + user + ".bhyt bh on a.maql=bh.maql and (bh.sudung=1 or bh.sudung is null)";
                sql += " where a.ttlucrv=0 and a.ngayrv is null";
                if (makp.SelectedIndex != -1) sql += " and a.makp='" + makp.SelectedValue.ToString() + "'";
                sql += " order by a.makp,a.ngay desc";
			    ds=m.get_data(sql);
            }
			dataGrid1.DataSource=ds.Tables[0];
            if (songay != 0) lbl.Text = lan.Change_language_MessageText("TỔNG SỐ VƯỢT QUÁ SỐ NGÀY QUI ĐỊNH (" + songay.ToString().Trim() + "): ") + ds.Tables[0].Rows.Count.ToString();
			else lbl.Text=lan.Change_language_MessageText("TỔNG SỐ HIỆN DIỆN :")+ds.Tables[0].Rows.Count.ToString();
            Cursor = Cursors.Default;
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
			TextCol.Width = (songay!=0)?100:0;
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
			TextCol.Width = 200;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "phai";
			TextCol.HeaderText = "Phái";
			TextCol.Width = 40;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "namsinh";
			TextCol.HeaderText = "Năm sinh";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày vào";
			TextCol.Width = 110;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Nơi chuyển";
			TextCol.Width = 100;
            TextCol.NullText = string.Empty;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "ngaydt";
            TextCol.HeaderText = "Số ngày";
            TextCol.Format = "### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.Width = 60;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 8);
            TextCol.MappingName = "sothe";
            TextCol.HeaderText = "Số thẻ";
            TextCol.Width = 100;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 9);
            TextCol.MappingName = "traituyen";
            TextCol.HeaderText = "Trái tuyến";
            TextCol.Width = 50;
            TextCol.NullText = string.Empty;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
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
            if (makp.SelectedIndex != -1) msg = "Khoa " + " " + makp.Text.ToString();
            else msg = "Toàn viện";
			dllReportM.frmReport f = new dllReportM.frmReport(m,ds,msg,"dshiendien.rpt");
			f.Show();
		}

		private void frmHiendienngtr_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butKetthuc_Click(sender,e);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void butXem_Click(object sender, EventArgs e)
        {
            load_grid();
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
            }						
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }
	}
}
