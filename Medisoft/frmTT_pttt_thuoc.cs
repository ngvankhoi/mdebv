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
	/// Summary description for rptThekho.
	/// </summary>
	public class frmTT_pttt_thuoc : System.Windows.Forms.Form
	{
Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_nhom;
		private string ma,user;
		private DataSet dsdm=new DataSet();
		private DataSet ds=new DataSet();
		private DataTable dtdt=new DataTable();
		private DataTable dtnguon=new DataTable();
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged;
        private int checkCol = 0;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.DataGrid dataGrid2;
		private CurrencyManager objStudentCM;
		private DataGridTableStyle ts;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTT_pttt_thuoc(int nhom,string _ma,string title)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			i_nhom=nhom;ma=_ma;
			this.Text+="("+title+")";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTT_pttt_thuoc));
            this.butXoa = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // butXoa
            // 
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(306, 380);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 3;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(379, 380);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(6, 160);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(647, 184);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(6, 348);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(650, 21);
            this.tim.TabIndex = 1;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(233, 380);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 2;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(5, -14);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(648, 190);
            this.dataGrid2.TabIndex = 26;
            // 
            // frmTT_pttt_thuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(658, 423);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butXoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTT_pttt_thuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thuốc + vật tư y tế";
            this.Load += new System.EventHandler(this.frmTT_pttt_thuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTT_pttt_thuoc_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			dtdt=m.get_data("select * from "+user+".d_doituong order by madoituong").Tables[0];
			if (d.bQuanlynguon(i_nhom))
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where nhom=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			dsdm.ReadXml("..//..//..//xml//d_dmbd.xml");
			dsdm.Tables[0].Columns.Add("Chon",typeof(bool));
			load_grid();
			AddGridTableStyle();

			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			ds.ReadXml("..//..//..//xml//m_pttt_thuoc.xml");
			AddGridTableStyle1();
			load_chitiet();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
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
			TextCol.Width = 330;
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
			TextCol.Width = 155;
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
					//e.BackBrush = this.disabledBackBrush;
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
            dsdm.Merge(m.get_data("select a.id,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,a.tenhc,b.ten as tenhang from " + user + ".d_dmbd a," + user + ".d_dmhang b where a.mahang=b.id and a.nhom=" + i_nhom + " and a.id not in (select mabd from " + user + ".pttt_thuoc where ma='" + ma + "') order by a.ten"));
			dataGrid1.DataSource=dsdm.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
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
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) dataGrid1.Focus();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (dsdm.Tables[0].Select("chon=true").Length>0)
			{
				int i_madoituong=5;
				DataRow r3=m.getrowbyid(dtdt,"madoituong=5");
				if (r3==null && dtdt.Rows.Count>0) i_madoituong=int.Parse(dtdt.Rows[0]["madoituong"].ToString());
				foreach(DataRow r in dsdm.Tables[0].Select("chon=true"))
					m.upd_pttt_thuoc(ma,int.Parse(r["id"].ToString()),1,int.Parse(dtnguon.Rows[0]["id"].ToString()),i_madoituong);
				foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
				load_chitiet();
			}
			else 
			{
				ds.AcceptChanges();
				DataRow r1,r2;
				foreach(DataRow r in ds.Tables[0].Rows) 
				{
					r1=m.getrowbyid(dtdt,"doituong='"+r["doituong"].ToString()+"'");
					if (r1!=null)
					{
						r2=m.getrowbyid(dtnguon,"ten='"+r["nguon"].ToString()+"'");
						if (r2!=null)
							m.upd_pttt_thuoc(ma,int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),int.Parse(r2["id"].ToString()),int.Parse(r1["madoituong"].ToString()));
					}
				}
			}
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid2.CurrentCell.RowNumber;
                m.execute_data("delete from " + user + ".pttt_thuoc where ma='" + ma + "' and mabd=" + int.Parse(dataGrid2[i, 0].ToString()));
				load_chitiet();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_chitiet()
		{
			dataGrid2.DataSource=null;
			string sql="select nullif(b.manguon,0) as manguon,nullif(e.ten,' ') as nguon,nullif(b.madoituong,0) as madoituong,nullif(d.doituong,' ') as doituong,b.mabd,a.ma,trim(a.ten)||' '||a.hamluong as ten,a.dang,nullif(c.ten,' ') as tenhang,b.soluong ";
            sql += "from " + user + ".d_dmbd a inner join " + user + ".pttt_thuoc b on a.id=b.mabd ";
            sql += " left join " + user + ".d_dmhang c on a.mahang=c.id ";
            sql += " left join " + user + ".d_doituong d on b.madoituong=d.madoituong ";
            sql+=" left join "+user+".d_dmnguon e on b.manguon=e.id ";
			sql+="where b.ma='"+ma+"' order by a.ten";
			ds=m.get_data(sql);
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
			ts.MappingName = ds.Tables[0].TableName;
			dataGrid2.DataSource = ds;
			dataGrid2.DataMember = ds.Tables[0].TableName;
		}

		private void AddGridTableStyle1()
		{
			int IntAvgCharWidth;
			ts = new DataGridTableStyle();
			IntAvgCharWidth=(int)(System.Drawing.Graphics.FromHwnd(this.Handle).MeasureString("ABCDEFGHIJKLMNOPQRSTUVWXYZ",this.Font).Width/26);
			objStudentCM = (System.Windows.Forms.CurrencyManager)this.BindingContext[ds.Tables[0]];
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
			ts.ReadOnly=false;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["mabd"]));
			ts.GridColumnStyles[0].MappingName = "mabd";
			ts.GridColumnStyles[0].HeaderText = "";
			ts.GridColumnStyles[0].Width=0;
			ts.ReadOnly=true;
			ts.GridColumnStyles[0].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[0].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtnguon,1,1));
			ts.GridColumnStyles[1].MappingName = "nguon";
			ts.GridColumnStyles[1].HeaderText = "Nguồn";
			ts.GridColumnStyles[1].Width=140;
			ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[1].NullText = string.Empty;			
			dataGrid2.CaptionText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtdt,1,1));
			ts.GridColumnStyles[2].MappingName = "doituong";
			ts.GridColumnStyles[2].HeaderText = "Đối tượng";
			ts.GridColumnStyles[2].Width=80;
			ts.GridColumnStyles[2].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[2].NullText = string.Empty;			
			dataGrid2.CaptionText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["ten"]));
			ts.GridColumnStyles[3].MappingName = "ten";
			ts.GridColumnStyles[3].HeaderText = "Tên thuốc";
			ts.GridColumnStyles[3].Width=270;
			ts.ReadOnly=true;
			ts.GridColumnStyles[3].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[3].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["dang"]));
			ts.GridColumnStyles[4].MappingName = "dang";
			ts.GridColumnStyles[4].HeaderText = "ĐVT";
			ts.GridColumnStyles[4].Width=60;
			ts.ReadOnly=true;
			ts.GridColumnStyles[4].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[4].NullText = string.Empty;

			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["soluong"]));
			ts.GridColumnStyles[5].MappingName = "soluong";
			ts.GridColumnStyles[5].HeaderText = "Số lượng";
			ts.GridColumnStyles[5].Width=50;
			ts.ReadOnly=false;
			ts.GridColumnStyles[5].Alignment = HorizontalAlignment.Right;
			ts.GridColumnStyles[5].NullText = string.Empty;

			dataGrid2.DataSource = ds;
			dataGrid2.DataMember = ds.Tables[0].TableName;
			dataGrid2.TableStyles.Add(ts);
		}

	}
}
