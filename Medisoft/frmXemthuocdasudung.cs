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
	/// Summary description for frmXemthuocdasudung.
	/// </summary>
	public class frmXemthuocdasudung : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private AccessData m;
		public DataSet ds=new DataSet();
        public DataSet tmp = new DataSet();
		private string sql,nam,mabn,user;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
        private Brush disabledTextBrush;
        private Brush currentRowBackBrush;
        private Font currentRowFont;
        private Button butchon;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemthuocdasudung(AccessData acc,string _mabn,string _hoten)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; mabn = _mabn; this.Text = _hoten; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //Tu:28/03/2011
        public frmXemthuocdasudung(AccessData acc, string _mabn, string _nam, string _hoten)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            m = acc; mabn = _mabn; nam = _nam; this.Text = _hoten;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemthuocdasudung));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butchon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(492, 392);
            this.dataGrid1.TabIndex = 29;
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(217, 384);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 30;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butchon
            // 
            this.butchon.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butchon.Image = ((System.Drawing.Image)(resources.GetObject("butchon.Image")));
            this.butchon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butchon.Location = new System.Drawing.Point(141, 384);
            this.butchon.Name = "butchon";
            this.butchon.Size = new System.Drawing.Size(70, 25);
            this.butchon.TabIndex = 31;
            this.butchon.Text = "Chọn";
            this.butchon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butchon.Click += new System.EventHandler(this.butchon_Click);
            // 
            // frmXemthuocdasudung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 421);
            this.Controls.Add(this.butchon);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemthuocdasudung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmXemthuocdasudung";
            this.Load += new System.EventHandler(this.frmXemthuocdasudung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmXemthuocdasudung_Load(object sender, System.EventArgs e)
		{
			user=m.user;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                nam = r["nam"].ToString();
            nam=(nam=="")?m.mmyy(m.ngayhienhanh_server)+"+":nam;
			sql="select 0 as loai,b.stt,e.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yymmdd') yymmdd,";
			sql+="b.mabd,trim(d.ten)||' '||d.hamluong as tenbd,d.dang,b.slyeucau soluong ";
            sql += ",b.cachdung,b.solan,d.duongdung,d.hamluong,'' as losx,f.ten,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayket ";
			sql+=" from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b,xxx.benhanpk c,"+user+".d_dmbd d,"+user+".btdkp_bv e ";
            sql += "," + user + ".d_dmhang f ";
            sql += " where a.id=b.id and a.maql=c.maql and b.mabd=d.id and c.makp=e.makp and d.mahang=f.id(+) ";
			sql+=" and a.mabn='"+mabn+"'";
			DataSet tmp=m.get_data_nam(nam,sql);
			sql=" select 1 as loai,b.stt,e.tenkp,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,to_char(a.ngay,'yymmdd') yymmdd,";
            sql+="b.mabd,d.ten as tenbd,d.dang,b.soluong ";
            sql += ",b.cachdung,b.solan,d.duongdung,d.hamluong,'' as losx,f.ten,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayket ";
            sql += " from xxx.d_toathuocll a,xxx.d_toathuocct b," + user + ".d_dmthuoc d," + user + ".btdkp_bv e ";
            sql += ","+user+".d_dmhang f ";
			sql+=" where a.id=b.id and b.mabd=d.id and a.makp=e.makp and d.mahang=f.id(+) ";
			sql+=" and a.mabn='"+mabn+"'";
            if (tmp != null)
                tmp.Merge(m.get_data_nam(nam,sql));
            else
                tmp = m.get_data_nam(nam,sql);
			ds=tmp.Copy();
			ds.Clear();
			ds.Merge(tmp.Tables[0].Select("","tenkp,yymmdd,loai,stt"));
            ds.Tables[0].Columns.Add("chon",typeof(bool));
            foreach (DataRow r in ds.Tables[0].Rows) r["chon"] = false;
			dataGrid1.DataSource=ds.Tables[0];
            dataGrid1.ReadOnly = false;
			AddGridTableStyle();
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
			//ts.SelectionBackColor = Color.Teal;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
			ts.SelectionForeColor = Color.PaleGreen;
			//ts.ReadOnly=false;
			ts.RowHeaderWidth=5;

            DataGridBoolColumn ChkCol = new DataGridBoolColumn();
            ChkCol.MappingName = "chon";
            ChkCol.HeaderText = "Chọn";
            ChkCol.Width = 30;
            ChkCol.ReadOnly = false;
            ChkCol.AllowNull = false;
            ts.GridColumnStyles.Add(ChkCol);
            dataGrid1.TableStyles.Add(ts);
            //FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            //discontinuedCol.MappingName = "chon";
            //discontinuedCol.HeaderText = "Chọn";
            //discontinuedCol.Width = 30;
            //discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            //discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            //ts.GridColumnStyles.Add(discontinuedCol);
            //dataGrid1.TableStyles.Add(ts);
			
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "tenkp";
			TextCol.HeaderText = "Khoa/Phòng";
			TextCol.Width = 100;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ngay";
			TextCol.HeaderText = "Ngày";
			TextCol.Width = 70;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên thuốc - hàm lượng";
			TextCol.Width = 200;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 30;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
            TextCol.ReadOnly = true;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}
        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
                else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont;
                }
                else if (dataGrid1[e.Row, 11].ToString() == "1" || dataGrid1[e.Row, 12].ToString() == "1") e.ForeBrush = new SolidBrush(Color.Orange);
            }
            catch { }
        }

        private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
        {
            this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row, false);
            RefreshRow(e.Row);
            this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"], e.Row);
        }
        private void RefreshRow(int row)
        {
            Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
            rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
            this.dataGrid1.Invalidate(rect);
        }
		public Color MyGetColorRowCol(int row, int col)
		{
			if (this.dataGrid1[row,5].ToString().Trim()=="1") return Color.Red;
			else return Color.Black;
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

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void butchon_Click(object sender, EventArgs e)
        {
            tmp = ds.Clone();
            foreach (DataRow r in ds.Tables[0].Select("chon=true"))
            {
                tmp.Tables[0].Rows.Add(r.ItemArray);
            }
            tmp.AcceptChanges();
            this.Close();
        }
	}
}
