using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXemton.
	/// </summary>
	public class frmXemtonthck : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private DataColumn dc;
		private DataSet ds=new DataSet();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private string s_mmyy,sql,format_soluong,user;
		private System.Windows.Forms.Button butRef;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butIn; 
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
        private ComboBox cbnhom;
        private ComboBox cbnguon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox manhom;
        private System.Windows.Forms.TextBox manguon;
        private System.Windows.Forms.Button butLoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXemtonthck(AccessData acc,string mmyy,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			s_mmyy=mmyy;
			i_nhom=nhom;
			this.Text="Tồn tổng hợp các kho tháng "+mmyy.Substring(0,2)+" năm "+mmyy.Substring(2,2);
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemtonthck));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.cbnhom = new System.Windows.Forms.ComboBox();
            this.cbnguon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.manhom = new System.Windows.Forms.TextBox();
            this.manguon = new System.Windows.Forms.TextBox();
            this.butLoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 28);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 455);
            this.dataGrid1.TabIndex = 5;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(446, 492);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butRef
            // 
            this.butRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(306, 492);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(70, 25);
            this.butRef.TabIndex = 6;
            this.butRef.Text = "&Refresh";
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Location = new System.Drawing.Point(9, 25);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(775, 20);
            this.tim.TabIndex = 4;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(376, 492);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // cbnhom
            // 
            this.cbnhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbnhom.FormattingEnabled = true;
            this.cbnhom.Location = new System.Drawing.Point(450, 2);
            this.cbnhom.Name = "cbnhom";
            this.cbnhom.Size = new System.Drawing.Size(300, 21);
            this.cbnhom.TabIndex = 3;
            this.cbnhom.Validated += new System.EventHandler(this.cbnhom_Validated);
            this.cbnhom.SelectedIndexChanged += new System.EventHandler(this.cbnhom_SelectedIndexChanged);
            this.cbnhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // cbnguon
            // 
            this.cbnguon.FormattingEnabled = true;
            this.cbnguon.Location = new System.Drawing.Point(94, 2);
            this.cbnguon.Name = "cbnguon";
            this.cbnguon.Size = new System.Drawing.Size(245, 21);
            this.cbnguon.TabIndex = 1;
            this.cbnguon.Validated += new System.EventHandler(this.cbnguon_Validated);
            this.cbnguon.SelectedIndexChanged += new System.EventHandler(this.cbnguon_SelectedIndexChanged);
            this.cbnguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nguốn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nhóm :";
            // 
            // manhom
            // 
            this.manhom.Location = new System.Drawing.Point(393, 2);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(56, 20);
            this.manhom.TabIndex = 2;
            this.manhom.Validated += new System.EventHandler(this.manhom_Validated);
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // manguon
            // 
            this.manguon.Location = new System.Drawing.Point(52, 2);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(41, 20);
            this.manguon.TabIndex = 0;
            this.manguon.Validated += new System.EventHandler(this.manguon_Validated);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // butLoc
            // 
            this.butLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLoc.Location = new System.Drawing.Point(751, 1);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(35, 23);
            this.butLoc.TabIndex = 12;
            this.butLoc.Text = "Lọc";
            this.butLoc.UseVisualStyleBackColor = true;
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // frmXemtonthck
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butLoc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbnguon);
            this.Controls.Add(this.cbnhom);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.butRef);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemtonthck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemtonthck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemtonthck_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			Cursor=Cursors.WaitCursor;
            user = d.user;
			dtkho=d.get_data("select * from "+user+".d_dmkho where nhom="+i_nhom+" order by stt").Tables[0];
			format_soluong=d.format_soluong(i_nhom);
			ds.ReadXml("..\\..\\..\\xml\\d_toncackho.xml");
			foreach(DataRow r in dtkho.Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="c_"+r["id"].ToString().PadLeft(3,'0');
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
            //
            cbnhom.DataSource = d.get_data("select id, ten from " + user + ".d_dmnhom where nhom=" + i_nhom).Tables[0];
            cbnhom.DisplayMember = "TEN";
            cbnhom.ValueMember = "ID";
            //
            cbnguon.DataSource = d.get_data("select id, ten from " + user + ".d_dmnguon where nhom=" + i_nhom).Tables[0];
            cbnguon.DisplayMember = "TEN";
            cbnguon.ValueMember = "ID";
            //
			load_grid("","");
			AddGridTableStyle();
			Cursor=Cursors.Default;
		}

		private void load_grid(string d_manguon, string d_manhom)
		{

			sql="select a.makho,a.manguon,a.mabd,c.ten as tennguon,b.ma,trim(b.ten)||' '||b.hamluong as tenbd,b.tenhc,b.dang,a.tondau+a.slnhap-a.slxuat as toncuoi ";
			sql+=",d.stt as manhom,d.ten as tennhom";
            sql += " from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnhom d";
			sql+=" where a.mabd=b.id and a.manguon=c.id and b.manhom=d.id and a.makho in (select id from "+user+".d_dmkho where nhom="+i_nhom+")";
            if (d_manguon.Trim() != "" && d_manguon.Trim() != "0") sql += " and a.manguon in(" + d_manguon.Trim().Trim(',') + ")";
            if (d_manhom.Trim() != "" && d_manhom.Trim() != "0") sql += " and b.manhom in(" + d_manhom.Trim().Trim(',') + ")";
            sql+=" order by b.ten";
			DataRow r1,r2;
			DataRow [] dr;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				sql="manguon="+int.Parse(r["manguon"].ToString())+" and mabd="+int.Parse(r["mabd"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["manhom"]=r["manhom"].ToString();
					r2["tennhom"]=r["tennhom"].ToString();
					r2["manguon"]=r["manguon"].ToString();
					r2["tennguon"]=r["tennguon"].ToString();
					r2["mabd"]=r["mabd"].ToString();
					r2["ma"]=r["ma"].ToString();
					r2["tenbd"]=r["tenbd"].ToString();
					r2["tenhc"]=r["tenhc"].ToString();
					r2["dang"]=r["dang"].ToString();
					r2["tc"]=r["toncuoi"].ToString();
					foreach(DataRow r3 in dtkho.Rows) r2["c_"+r3["id"].ToString().PadLeft(3,'0')]=0;
					r2["c_"+r["makho"].ToString().PadLeft(3,'0')]=r["toncuoi"].ToString();
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0)
					{
						dr[0]["c_"+r["makho"].ToString().PadLeft(3,'0')]=decimal.Parse(dr[0]["c_"+r["makho"].ToString().PadLeft(3,'0')].ToString())+decimal.Parse(r["toncuoi"].ToString());
						dr[0]["tc"]=decimal.Parse(dr[0]["tc"].ToString())+decimal.Parse(r["toncuoi"].ToString());
					}
				}
			}
			dataGrid1.DataSource=ds.Tables[0];
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
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (d.bHoatchat)?200:270;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "tc";
			TextCol.HeaderText = "Tổng Tồn";
			TextCol.Width = 72;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			int i=6;
			foreach(DataRow r in dtkho.Rows)
			{
				TextCol=new DataGridColoredTextBoxColumn(de, i++);
				TextCol.MappingName = "c_"+r["id"].ToString().PadLeft(3,'0');
				TextCol.HeaderText = r["ten"].ToString();
				TextCol.Width = 72;
				TextCol.Format=format_soluong;
				TextCol.Alignment=HorizontalAlignment.Right;
				ts.GridColumnStyles.Add(TextCol);
				dataGrid1.TableStyles.Add(ts);
			}
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (col==5) return Color.Blue;
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

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbd like '%"+text.Trim()+"%' or tenhc like '%"+text.Trim()+"%' or ma like '%"+text.Trim()+"%'";
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
            Cursor = Cursors.WaitCursor;
            d.execute_data("delete from " + user + s_mmyy + ".d_tonkhoct where tondau=0 and slnhap=0 and slxuat=0");
            d.execute_data("delete from " + user + s_mmyy + ".d_tonkhoth where tondau=0 and slnhap=0 and slxuat=0");
			d.upd_tonkho(s_mmyy,i_nhom,1);
			ds.Clear();
            load_grid("", "");
            Cursor = Cursors.Default;
		}

		private void tim_Enter(object sender, System.EventArgs e)
		{
			tim.Text="";
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim) RefreshChildren(tim.Text);
		}

		private string get_ten(int i)
		{
			string [] map={"Stt","Tên thuốc - hàm lượng","ĐVT","Tổng số"};
			return map[i];
		}
		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
			#region
			DataSet dsxml=new DataSet();
			dsxml=ds.Copy();
			dsxml.Clear();
			DataRow r2;
			int stt=0,tt=1;
			sql="manhom,tenbd";
			DataRow []dr=ds.Tables[0].Select("true",sql);
			for(int i=0;i<dr.Length;i++)
			{
				if (stt!=int.Parse(dr[i]["manhom"].ToString()))
				{
					stt=int.Parse(dr[i]["manhom"].ToString());
					r2 = dsxml.Tables[0].NewRow();
					r2["stt"]=0;
					r2["tenbd"]=dr[i]["tennhom"].ToString().ToUpper();
					r2["dang"]="";
					r2["tc"]=0;
					foreach(DataRow r3 in dtkho.Rows) r2["c_"+r3["id"].ToString().PadLeft(3,'0')]=0;
					dsxml.Tables[0].Rows.Add(r2);
				}
				r2 = dsxml.Tables[0].NewRow();
				r2["stt"]=tt;
				r2["tenbd"]=dr[i]["tenbd"].ToString();
				r2["dang"]=dr[i]["dang"].ToString();
				foreach(DataRow r3 in dtkho.Rows) r2["c_"+r3["id"].ToString().PadLeft(3,'0')]=dr[i]["c_"+r3["id"].ToString().PadLeft(3,'0')];
				r2["tc"]=dr[i]["tc"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
				tt++;
			}
			dsxml.Tables[0].Columns.Remove("manhom");
			dsxml.Tables[0].Columns.Remove("tennhom");
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("manguon");
			dsxml.Tables[0].Columns.Remove("tennguon");
			dsxml.Tables[0].Columns.Remove("ma");
			dsxml.Tables[0].Columns.Remove("tenhc");
			#endregion
			int be=0;
			int dong=dsxml.Tables[0].Rows.Count+be+1,socot=dsxml.Tables[0].Columns.Count+1;
			string tenfile=d.Export_Excel(dsxml,"tonkho");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
			int j=0;
			for(;j<4;j++) osheet.Cells[be+1,j+1]=get_ten(j);
			foreach(DataRow r in dtkho.Rows) osheet.Cells[be+1,++j]=r["ten"].ToString();
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot-2)+dong.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot-2)+dong.ToString()).EntireColumn.AutoFit();
			oxl.Visible=true;
		}

        private void butLoc_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ds.Clear();
            load_grid(manguon.Text, manhom.Text);
            Cursor = Cursors.Default;
        }

        private void cbnhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbnhom) manhom.Text = cbnhom.SelectedValue.ToString();
            }
            catch { manhom.Text = "0"; }
        }

        private void cbnguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cbnguon) manguon.Text = cbnguon.SelectedValue.ToString();
            }
            catch { manguon.Text = "0";  }
        }

        private void manguon_Validated(object sender, EventArgs e)
        {
            try
            {
                cbnguon.SelectedValue = manguon.Text;
            }
            catch { }
        }

        private void manhom_Validated(object sender, EventArgs e)
        {
            try
            {
                cbnhom.SelectedValue = manhom.Text;
            }
            catch { }
        }

        private void manguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

       
        private void cbnhom_Validated(object sender, EventArgs e)
        {
            try
            {
                manhom.Text = cbnhom.SelectedValue.ToString();
            }
            catch { manhom.Text = "0"; }
        }

        private void cbnguon_Validated(object sender, EventArgs e)
        {
            try
            {
                manguon.Text = cbnguon.SelectedValue.ToString();
            }
            catch { manguon.Text = "0"; }
        }

	}
}
