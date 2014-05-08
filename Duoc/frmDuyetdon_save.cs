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
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmDuyetdon_save : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont,alertFont2;
		private Brush alertTextBrush;
		private Font currentRowFont,currentRowFont2;
		private Brush currentRowBackBrush,RowBackBrushVP;
		private bool afterCurrentCellChanged,bSkip=false;
		private int checkCol=0,i_userid,i_row,i_row_thuoc=0;
		private AccessData d;
		private int i_nhom,i_loai,i_makho;
		private long l_id;
		private string sql,s_kho,s_ngay,s_mmyy,s_mabn,s_makp;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dttonct=new DataTable();
		private DataRow r2;
		public DataTable dtll=new DataTable();
		public bool bOk=false;
		public int sobienlai;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TextBox tim2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDuyetdon_save(AccessData acc,DataTable dt,int nhom,string kho,string ngay,int userid,string mmyy,int loai)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			dtll=dt;
			i_nhom=nhom;i_loai=loai;
			i_userid=userid;
			s_kho=kho;i_makho=int.Parse(s_kho.Substring(0,s_kho.Length-1).ToString());
			s_ngay=ngay;
			s_mmyy=mmyy;
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
						RowBackBrushVP.Dispose();
						alertFont2.Dispose();
						currentRowFont2.Dispose();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDuyetdon_save));
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tim = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.tim2 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(322, 429);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(72, 28);
			this.butLuu.TabIndex = 5;
			this.butLuu.Text = "      &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(396, 429);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(76, 28);
			this.butBoqua.TabIndex = 6;
			this.butBoqua.Text = "&Kết thúc";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(9, -8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeaderWidth = 3;
			this.dataGrid1.Size = new System.Drawing.Size(275, 400);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// tim
			// 
			this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tim.Location = new System.Drawing.Point(48, 398);
			this.tim.Name = "tim";
			this.tim.Size = new System.Drawing.Size(236, 21);
			this.tim.TabIndex = 3;
			this.tim.Text = "";
			this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
			this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(-8, 398);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "&Tìm kiếm";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid2
			// 
			this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(294, -8);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.RowHeaderWidth = 3;
			this.dataGrid2.Size = new System.Drawing.Size(496, 400);
			this.dataGrid2.TabIndex = 1;
			this.dataGrid2.Click += new System.EventHandler(this.dataGrid2_Click);
			this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
			// 
			// tim2
			// 
			this.tim2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tim2.Location = new System.Drawing.Point(288, 398);
			this.tim2.Name = "tim2";
			this.tim2.Size = new System.Drawing.Size(496, 21);
			this.tim2.TabIndex = 4;
			this.tim2.Text = "";
			this.tim2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
			this.tim2.TextChanged += new System.EventHandler(this.tim2_TextChanged);
			// 
			// frmDuyetdon_save
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(794, 471);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tim2,
																		  this.dataGrid2,
																		  this.label3,
																		  this.tim,
																		  this.dataGrid1,
																		  this.butBoqua,
																		  this.butLuu});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(0, 38);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDuyetdon_save";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đơn thuốc";
			this.Load += new System.EventHandler(this.frmDuyetdon_save_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDuyetdon_save_Load(object sender, System.EventArgs e)
		{	
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			this.alertFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Bold);
			this.currentRowFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Regular);

			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			this.RowBackBrushVP = new SolidBrush(Color.Blue);

			dtton=d.get_data(s_mmyy,"select a.mabd,a.tondau+a.slnhap-a.slxuat-a.slyeucau ton,b.ma,trim(b.ten)||' '||trim(b.hamluong) ten,trim(b.dang) dang,b.giaban from d_tonkhoth a,"+d.user+".d_dmbd b where a.mabd=b.id and b.nhom="+i_nhom+" and a.makho="+i_makho+" and a.tondau+a.slnhap-a.slxuat-a.slyeucau>0").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_duyetdon.xml");
			dataGrid2.DataSource=ds.Tables[0];
			AddGridTableStyle2();
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			load_grid();
		}

		private void AddGridTableStyle2()
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
			discontinuedCol.HeaderText = "Bỏ";
			discontinuedCol.Width = 20;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged2);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid2.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width =0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã";
			TextCol.Width =60;
			//TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc";
			TextCol.Width =180;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width =35;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = "Đơn gía";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "sotienban";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 60;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
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
			TextCol.MappingName = "id";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
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
					e.ForeBrush = this.disabledTextBrush;
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void SetCellFormat2(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid2[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
				else if (e.Column>0 && this.dataGrid2[e.Row,4].ToString()=="0") e.ForeBrush=this.RowBackBrushVP;
				else if(e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont2;
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


		private void BoolValueChanged2(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow2(e.Row);
			this.dataGrid2.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow2(int row)
		{
			Rectangle rect = this.dataGrid2.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid2.Width, rect.Height);
			this.dataGrid2.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			i_row=dataGrid1.CurrentRowIndex;
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
				//
				l_id=long.Parse(dataGrid1[i_row,3].ToString());
				s_makp=dataGrid1[i_row,4].ToString();
				s_mabn=dataGrid1[i_row,1].ToString();
				if (dataGrid1[i_row,0].ToString().Trim()=="True")
				{
					load_dtct();
					foreach(DataRow r in dtct.Rows)
					{
						r2=d.getrowbyid(dtton,"ten='"+r["ten"].ToString().Trim()+"' and dang='"+r["dang"].ToString().Trim()+"'");
						if (r2!=null)
							d.updrec_donthuoc(ds.Tables[0],dataGrid1[i_row,2].ToString(),l_id,int.Parse(r["stt"].ToString()),long.Parse(r["sttt"].ToString()),int.Parse(r2["mabd"].ToString()),
								r2["ma"].ToString(),r2["ten"].ToString(),r["tenhc"].ToString(),r2["dang"].ToString(),r["tenkho"].ToString(),
								r["tennguon"].ToString(),r["tennhomcc"].ToString(),r["handung"].ToString(),r["losx"].ToString(),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["dongia"].ToString()),
								decimal.Parse(r["sotien"].ToString()),int.Parse(r["makho"].ToString()),int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()),decimal.Parse(r2["giaban"].ToString()),decimal.Parse(r2["giamua"].ToString()),Math.Round(decimal.Parse(r["soluong"].ToString())*decimal.Parse(r2["giaban"].ToString()),0),false,null);
						else 
							d.updrec_donthuoc(ds.Tables[0],dataGrid1[i_row,2].ToString(),l_id,int.Parse(r["stt"].ToString()),long.Parse(r["sttt"].ToString()),int.Parse(r["mabd"].ToString()),
								r["ma"].ToString(),r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),r["tenkho"].ToString(),
								r["tennguon"].ToString(),r["tennhomcc"].ToString(),r["handung"].ToString(),r["losx"].ToString(),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["dongia"].ToString()),
								decimal.Parse(r["sotien"].ToString()),int.Parse(r["makho"].ToString()),int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()),decimal.Parse(r["giaban"].ToString()),decimal.Parse(r["giamua"].ToString()),decimal.Parse(r["sotienban"].ToString()),true,null);
					}
				}
				else d.delrec(ds.Tables[0],"id="+l_id);
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_grid()
		{
			sql="select a.id,a.mabn,b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon diachi,b.cholam,";
			sql+=" nvl(c.id,0) makp,a.mabs from d_toathuocll a,btdbn b,d_duockp c ";
			sql+=" where a.mabn=b.mabn and a.done=0";
			sql+=" and a.makp=c.makp(+) and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by a.id";
			dt=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dt;
			if (!bSkip) AddGridTableStyle();
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
			foreach (DataRow row in dt.Rows) row["chon"]=false;
			butLuu.Enabled=dt.Rows.Count!=0;
			dataGrid1.Focus();
			i_row=dataGrid1.CurrentRowIndex;
			load_items();
		}

		private void load_items()
		{
			ds.Clear();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv=(DataView)cm.List;
			dv.RowFilter="";
			cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
			dv=(DataView)cm.List;
			dv.RowFilter="";
			upd_data();
			load_grid();
			bOk=true;
			Cursor=Cursors.Default;
		}

		private void load_tonct()
		{
			sql="select a.*,b.ten tennguon,c.ten tennhomcc from d_tonkhoct a,"+d.user+".d_dmnguon b,"+d.user+".d_nhomcc c where a.manguon=b.id and a.nhomcc=c.id and a.mmyy='"+s_mmyy+"'";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by a.stt";
			dttonct=d.get_data(s_mmyy,sql).Tables[0];
		}

		private void load_dtct()
		{
			sql="select a.stt,0 sttt,a.mabd,'' ma,trim(b.ten) ten,";
			sql+=" '' tenhc,b.dang,'' tenkho,'' tennguon,' ' tennhomcc,";
			sql+=" ' ' handung,' ' losx,a.soluong,0 dongia,0 sotien,0 giaban,";
			sql+=" 0 sotienban,"+i_makho+" makho,0 manguon,0 nhomcc,0 soluongcu,0 sotiencu ";
			sql+=" from d_toathuocct a,d_dmthuoc b";
			sql+=" where a.mabd=b.id ";
			sql+=" and a.id="+l_id+" order by a.stt";
			dtct=d.get_data(sql).Tables[0];
		}

		private void upd_data()
		{
			load_tonct();
			long o_id=0,id;
			DataRow r;
			DataRow [] dr=ds.Tables[0].Select("chon=false and soluong>0","id,stt");
			for(int i=0;i<dr.Length;i++)
			{
				l_id=long.Parse(dr[i]["id"].ToString());
				if (o_id!=l_id)
				{
					r=d.getrowbyid(dt,"id="+l_id);
					if (r!=null)
					{
						id=d.get_id_ngtru;
						d.upd_ngtrull(id,i_nhom,r["mabn"].ToString(),r["hoten"].ToString(),r["namsinh"].ToString(),s_ngay,r["mabs"].ToString(),int.Parse(r["makp"].ToString()),i_loai,s_mmyy,i_userid,0,0);
						foreach(DataRow r1 in d.get_xuatban(ds.Tables[0].Select("chon=false and id="+l_id,"stt"),dttonct,l_id).Rows)
							d.upd_ngtruct(s_mmyy,id,int.Parse(r1["stt"].ToString()),long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
						d.updrec_ngtrull(dtll,id,r["mabn"].ToString(),r["hoten"].ToString(),r["namsinh"].ToString(),s_ngay,r["mabs"].ToString(),int.Parse(r["makp"].ToString()),i_loai,0,i_userid,0,0);
						d.execute_data("update d_toathuocll set done=1 where id="+l_id);
					}
					o_id=l_id;
				}
			}
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid1.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim.Text!="")
					dv.RowFilter="hoten like '%"+tim.Text.Trim()+"%' or mabn like '%"+tim.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void tim2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim2)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim2.Text!="")
					dv.RowFilter="ten like '%"+tim2.Text.Trim()+"%' or hoten like '%"+tim2.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void dataGrid2_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid2[hti.Row, checkCol] = !(bool)this.dataGrid2[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid2[this.dataGrid2.CurrentRowIndex, checkCol]) this.dataGrid2.CurrentCell = new DataGridCell(this.dataGrid2.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			try
			{
				if (dataGrid2.CurrentCell.ColumnNumber==2)
				{
					string ma=dataGrid2[i_row_thuoc,2].ToString().ToUpper();
					r2=d.getrowbyid(dtton,"ma='"+ma+"'");
					if (r2!=null)
					{
						ds.Tables[0].Rows[i_row_thuoc]["ma"]=ma;
						ds.Tables[0].Rows[i_row_thuoc]["mabd"]=r2["mabd"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["dang"]=r2["dang"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["ten"]=r2["ten"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["giaban"]=r2["giaban"].ToString();
						ds.Tables[0].Rows[i_row_thuoc]["sotienban"]=Math.Round(decimal.Parse(ds.Tables[0].Rows[i_row_thuoc]["soluong"].ToString())*decimal.Parse(r2["giaban"].ToString()),0);
					}
					else ds.Tables[0].Rows[i_row_thuoc]["chon"]=true;
					i_row_thuoc=dataGrid2.CurrentRowIndex;
				}
			}
			catch{}
		}
	}
}
