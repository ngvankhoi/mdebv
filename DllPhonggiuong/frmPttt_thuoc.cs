using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
namespace DllPhonggiuong
{
	public class frmPttt_thuoc : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_nhom;
		private string ma;
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
		private int checkCol=0;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.DataGrid dataGrid2;
		private CurrencyManager objStudentCM;
		private DataGridTableStyle ts;
		private int loai,phieu,makp,i_userid,makhoa;
		private string ngay,mmyy,makho,manguon,s_mabn,sql;
		private long l_duyet,l_id,l_maql,l_idkhoa;
		private bool bNew;
		private System.Windows.Forms.Button butThem;
		private System.ComponentModel.Container components = null;

		public frmPttt_thuoc(int nhom,string _ma,string title,int _makp,string _ngay,int _loai,int _phieu,string _mmyy,string _makho,string _manguon,long duyet,bool bnew,string mabn,long maql,long idkhoa,int userid,long idduoc,int _makhoa)
		{
			InitializeComponent();
			i_nhom=nhom;ma=_ma;makho=_makho;manguon=_manguon;s_mabn=mabn;l_maql=maql;l_idkhoa=idkhoa;
			makp=_makp;loai=_loai;phieu=_phieu;ngay=_ngay;mmyy=_mmyy;l_duyet=duyet;bNew=bnew;l_id=idduoc;
			this.Text+="("+title+")";i_userid=userid;makhoa=_makhoa;
		}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPttt_thuoc));
			this.butKetthuc = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label4 = new System.Windows.Forms.Label();
			this.tim = new System.Windows.Forms.TextBox();
			this.butLuu = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.butThem = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(369, 380);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
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
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(6, 160);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeaderWidth = 5;
			this.dataGrid1.Size = new System.Drawing.Size(647, 184);
			this.dataGrid1.TabIndex = 23;
			this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 348);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "&Tên mặt hàng :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tim
			// 
			this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tim.Location = new System.Drawing.Point(80, 348);
			this.tim.Name = "tim";
			this.tim.Size = new System.Drawing.Size(576, 21);
			this.tim.TabIndex = 1;
			this.tim.Text = "";
			this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
			this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
			// 
			// butLuu
			// 
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(292, 380);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 2;
			this.butLuu.Text = "      &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
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
			this.dataGrid2.Location = new System.Drawing.Point(5, -14);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.RowHeaderWidth = 3;
			this.dataGrid2.Size = new System.Drawing.Size(648, 190);
			this.dataGrid2.TabIndex = 26;
			// 
			// butThem
			// 
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(215, 380);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(75, 28);
			this.butThem.TabIndex = 27;
			this.butThem.Text = "      &Thêm";
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// frmPttt_thuoc
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(658, 423);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butThem,
																		  this.dataGrid2,
																		  this.butLuu,
																		  this.tim,
																		  this.label4,
																		  this.dataGrid1,
																		  this.butKetthuc});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPttt_thuoc";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thuốc + vật tư y tế";
			this.Load += new System.EventHandler(this.frmPttt_thuoc_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPttt_thuoc_Load(object sender, System.EventArgs e)
		{
//			DataTable dt=d.get_data("select id from d_duyet where nhom="+i_nhom+" and to_char(ngay,'dd/mm/yyyy')='"+ngay+"'"+" and loai="+loai+" and phieu="+phieu+" and makhoa="+makp).Tables[0];
//			if (dt.Rows.Count!=0) l_duyet=long.Parse(dt.Rows[0][0].ToString());
//			else l_duyet=0;
			dtdt=m.get_data("select * from d_doituong order by madoituong").Tables[0];
			if (d.bQuanlynguon(i_nhom))
				dtnguon=d.get_data("select * from d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				dtnguon=d.get_data("select * from d_dmnguon where nhom=0 or nhom="+i_nhom+" order by stt").Tables[0];
			dsdm.ReadXml("..\\..\\..\\xml\\d_tutructh.xml");
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
			ds.ReadXml("..\\..\\..\\xml\\m_pttt_thuoc.xml");
			AddGridTableStyle1();
			load_chitiet();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = 135;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
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
			TextCol.Width = 300;
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
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
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
			dsdm.Merge(d.get_tutructh_dutru(mmyy,makp,makho,manguon,0,i_nhom));
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
			ds.AcceptChanges();
			DataRow r1,r2;
			foreach(DataRow r in ds.Tables[0].Select("soluong>0"))
			{
				r1=m.getrowbyid(dtdt,"doituong='"+r["doituong"].ToString()+"'");
				if (r1!=null)
				{
					r2=m.getrowbyid(dtnguon,"ten='"+r["nguon"].ToString()+"'");
					if (r2!=null)
					{
						r["madoituong"]=r1["madoituong"].ToString();
						r["manguon"]=r2["id"].ToString();
					}
				}
			}
			string s="",sql;
			int tt=1;
			foreach(DataRow r in ds.Tables[0].Select("soluong>0"))
			{
				sql="manguon="+int.Parse(r["manguon"].ToString())+" and id="+int.Parse(r["mabd"].ToString());
				r1=m.getrowbyid(dsdm.Tables[0],sql);
				if (r1==null) s=s+r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\n";
				else 
				{
					if (decimal.Parse(r1["soluong"].ToString())<decimal.Parse(r["soluong"].ToString())) s=s+r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\n";
					r["makho"]=r1["makho"].ToString();
					r["stt"]=tt++;
				}
			}
			if (s!="") 
			{
				MessageBox.Show("Những mặt hàng sau không đủ tồn :\n"+s);
				dataGrid2.Focus();
				return;
			}
			if (!bNew)
			{
				foreach(DataRow r in d.get_data(mmyy,"select * from d_thucxuat where id="+l_id).Tables[0].Rows)
				{
					d.upd_tonkhoct_thucxuat(d.delete,mmyy,makp,loai,1,long.Parse(r["sttt"].ToString()),int.Parse(r["makho"].ToString()),int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()),int.Parse(r["mabd"].ToString()),r["handung"].ToString(),r["losx"].ToString(),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["sotien"].ToString()),decimal.Parse(r["giaban"].ToString()),decimal.Parse(r["giamua"].ToString()));
					d.upd_theodoicongno(d.delete,s_mabn,l_maql,l_idkhoa,int.Parse(r["madoituong"].ToString()),decimal.Parse(r["sotien"].ToString()),"thuoc");
					d.upd_tienthuoc(d.delete,mmyy,s_mabn,l_maql,l_idkhoa,ngay,makhoa,loai,int.Parse(r["madoituong"].ToString()),int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["sotien"].ToString()),decimal.Parse(r["giaban"].ToString()),decimal.Parse(r["giamua"].ToString()));
				}
				d.execute_data(mmyy,"delete from d_xuatsdct where id="+l_id);
				d.execute_data(mmyy,"delete from d_thucxuat where id="+l_id);
			}
			d.upd_dausinhton(l_id,l_idkhoa,l_id,ngay,"","",0,0,"",0,0,"","","");
			d.upd_xtutrucll(l_id,l_duyet,s_mabn,l_maql,l_idkhoa);
			foreach(DataRow r in ds.Tables[0].Rows)
				d.upd_xtutrucct(l_id,int.Parse(r["stt"].ToString()),int.Parse(r["madoituong"].ToString()),int.Parse(r["makho"].ToString()),int.Parse(r["mabd"].ToString()),decimal.Parse(r["soluong"].ToString()),0,"",int.Parse(r["manguon"].ToString()),0);
			d.upd_xuatsdll(l_id,i_nhom,s_mabn,l_maql,l_idkhoa,ngay,loai,phieu,makp,mmyy,i_userid,l_id,1,makhoa,0,0,"");
			d.get_xuatsdct_cstt(mmyy,ds.Tables[0].Select("soluong>0","stt"),makp,makhoa,0,l_id,s_mabn,l_maql,l_idkhoa,loai,1,ngay);
			butKetthuc.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i=dataGrid2.CurrentCell.RowNumber;
				m.execute_data("delete from pttt_thuoc where ma='"+ma+"' and mabd="+int.Parse(dataGrid2[i,0].ToString()));
				load_chitiet();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_chitiet()
		{
			dataGrid2.DataSource=null;
			sql="select b.stt,b.makho,b.manguon,e.ten as nguon,b.madoituong,f.doituong,b.mabd,d.ma,";
			sql+=" trim(d.ten)||' '||d.hamluong ten,d.dang,g.ten tenhang,b.slyeucau soluong ";
			sql+=" from d_xtutrucll a,d_xtutrucct b,d_duyet c,d_dmbd d,d_dmnguon e,d_doituong f,d_dmhang g";
			sql+=" where a.id=b.id and a.idduyet=c.id and b.mabd=d.id and b.manguon=e.id and b.madoituong=f.madoituong and d.mahang=g.id";
			sql+=" and a.idduyet="+l_duyet+" and a.mabn='"+s_mabn+"' and a.maql="+l_maql+" and a.idkhoa="+l_idkhoa;	
			sql+=" order by b.stt";
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count==0)
			{
				sql="select rownum as stt,0 as makho,b.manguon,e.ten as nguon,b.madoituong,d.doituong,b.mabd,a.ma,trim(a.ten)||' '||a.hamluong ten,a.dang,c.ten tenhang,b.soluong ";
				sql+="from d_dmbd a,pttt_thuoc b,d_dmhang c,d_doituong d,d_dmnguon e ";
				sql+="where a.id=b.mabd and a.mahang=c.id(+) and b.madoituong=d.madoituong(+) and b.manguon=e.id and b.ma='"+ma+"' order by a.ten";
				ds=m.get_data(sql);
			}
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

//			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtnguon,1,1));
			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["nguon"]));
			ts.GridColumnStyles[1].MappingName = "nguon";
			ts.GridColumnStyles[1].HeaderText = "Nguồn";
			ts.GridColumnStyles[1].Width=140;
			ts.GridColumnStyles[1].Alignment = HorizontalAlignment.Left;
			ts.GridColumnStyles[1].NullText = string.Empty;			
			dataGrid2.CaptionText = string.Empty;

//			ts.GridColumnStyles.Add(new DataGridComboBoxColumn(dtdt,1,1));//khanh
			ts.GridColumnStyles.Add(new DataGridTextBoxColumn(objStudentCM .GetItemProperties()["doituong"]));
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

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (dsdm.Tables[0].Select("chon=true").Length>0)
			{
				string sql;
				DataRow r1,r2;
				int i_madoituong=5;
				DataRow r3=m.getrowbyid(dtdt,"madoituong=5");
				if (r3==null && dtdt.Rows.Count>0) i_madoituong=int.Parse(dtdt.Rows[0]["madoituong"].ToString());
				foreach(DataRow r in dsdm.Tables[0].Select("chon=true"))
				{
					sql="mabd="+int.Parse(r["id"].ToString());
					r1=m.getrowbyid(ds.Tables[0],sql);
					if (r1==null)
					{
						r2=ds.Tables[0].NewRow();
						r2["makho"]=0;
						r2["manguon"]=dtnguon.Rows[0]["id"].ToString();
						r2["nguon"]=dtnguon.Rows[0]["ten"].ToString();
						r2["madoituong"]=i_madoituong.ToString();
						r3=m.getrowbyid(dtdt,"madoituong="+i_madoituong);
						if (r3!=null) r2["doituong"]=r3["doituong"].ToString();
						r2["mabd"]=r["id"].ToString();
						r2["ma"]=r["ma"].ToString();
						r2["ten"]=r["ten"].ToString();
						r2["dang"]=r["dang"].ToString();
						r2["soluong"]=1;
						ds.Tables[0].Rows.Add(r2);
					}
				}
				foreach (DataRow row in dsdm.Tables[0].Rows) row["chon"]=false;
			}
			butLuu.Focus();
		}

	}
}
