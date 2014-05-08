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
	public class rptTkmabd : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_userid=0;
		private string user,xxx,sql,s_rpt,s_mmyy,s_kho;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdm=new DataTable();
		private DataTable dtkhac=new DataTable();
		private DataTable dtphieu=new DataTable();
		private DataTable dtloaint=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtkho=new DataTable();
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
		int checkCol=0;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptTkmabd(AccessData acc,int nhom,string kho,string mmyy,string rpt,string title, int _userid)
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
			s_mmyy=mmyy;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptTkmabd));
            this.label1 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(260, 379);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(330, 379);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // kho
            // 
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
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(10, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.Size = new System.Drawing.Size(622, 328);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(130, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "đến : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "&Tìm kiếm ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(56, 348);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(576, 21);
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
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 6);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(167, 6);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptTkmabd
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(642, 423);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptTkmabd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê mặt hàng";
            this.Load += new System.EventHandler(this.rptTkmabd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptTkmabd_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy;
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

            dtkhac = d.get_data("select * from " + user + ".d_dmkhac where nhom=0 or nhom=" + i_nhom + " order by stt").Tables[0];
            dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where nhom=" + i_nhom + " order by stt").Tables[0];
            dtloaint = d.get_data("select * from " + user + ".d_dmloaint where nhom=" + i_nhom + " order by stt").Tables[0];
            dtkp = d.get_data("select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'" + " order by stt").Tables[0];
            dt = d.get_data("select a.*,b.ten as tenhang,c.ten as tennuoc from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnuoc c where a.mahang=b.id and a.manuoc=c.id and a.nhom=" + i_nhom + " order by a.id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_sochitiet.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_sochitiet.xml");
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
			ts.MappingName = dtdm.TableName;
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
			sql="select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,c.ten as tenhang,a.tondau+a.slnhap-a.slxuat as toncuoi from "+xxx+".d_tonkhoth a,"+user+".d_dmbd b,"+user+".d_dmhang c where (a.mabd=b.id and b.mahang=c.id ";
			if (manguon.SelectedIndex!=-1) sql+=" and a.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+="and a.makho="+int.Parse(kho.SelectedValue.ToString())+") and (a.tondau<>0 or a.slnhap<>0 or a.slxuat<>0) order by b.ten";
			dtdm=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtdm;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dtdm.Columns.Add("Chon",typeof(bool));
			foreach (DataRow row in dtdm.Rows) row["chon"]=false;
		}

		private void kho_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==kho) load_grid();
		}

		private void Loc()
		{
			d.execute_data("delete from "+user+".d_mabd");
			DataRow[] dr=dtdm.Select("chon=true");
			if (dr.Length==0) d.execute_data("insert into "+user+".d_mabd (select mabd from "+xxx+".d_tonkhoth where makho="+int.Parse(kho.SelectedValue.ToString())+")");
			else for(int i=0;i<dr.Length;i++) d.execute_data("insert into "+user+".d_mabd(mabd) values ("+int.Parse(dr[i]["mabd"].ToString())+")");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (den.Value<tu.Value)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Tháng không hợp lệ !"),d.Msg);
				return;
			}
			ds.Clear();
			Loc();
			ds=d.get_xuat_tungay(ds,dt,dtkp,dtloaint,dtkhac,dtkho,tu.Text,den.Text,int.Parse(kho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?-1:int.Parse(manguon.SelectedValue.ToString()));
			get_sort();
			if (dsxml.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,s_rpt,kho.Text,(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,"","","","","","","");
			f.ShowDialog();
		}

		private void get_sort()
		{
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("ma<>''","ten,yymmdd"));
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
	}
}
