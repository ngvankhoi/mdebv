using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Excel;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmThuoc_ts_pttt.
	/// </summary>
	public class frmThuoc_ts_pttt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butKetthuc;
		private string sql,ngaypt,user;
		private decimal maql;
		private int i_col;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private DataSet dsngay=new DataSet();
		private DataSet dsll=new DataSet();
        private DataSet dsct,dsxml;
		private DataColumn dc;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Button butIn;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThuoc_ts_pttt(LibMedi.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public frmThuoc_ts_pttt()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThuoc_ts_pttt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 3);
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
            this.den.Location = new System.Drawing.Point(168, 3);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 32);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(240, 440);
            this.dataGrid1.TabIndex = 4;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // butTim
            // 
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(280, 478);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(79, 25);
            this.butTim.TabIndex = 3;
            this.butTim.Text = "&Tìm";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(436, 478);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(89, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(56, 26);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(359, 478);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(77, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // frmThuoc_ts_pttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butKetthuc;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThuoc_ts_pttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sử dụng thuốc trước & sau mỗ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThuoc_ts_pttt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmThuoc_ts_pttt_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
            makp.DataSource = m.get_data("select * from " + user + ".btdkp_bv order by loai,makp").Tables[0];
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";
			dt=m.get_data("select * from "+user+".d_dmbd").Tables[0];
			dsngay.ReadXml("..//..//..//xml//m_pttt_ng.xml");
			dsll.ReadXml("..//..//..//xml//m_pttt_ll.xml");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			dataGrid1.DataSource=dsll.Tables[0];
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsll.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn Col=new DataGridTextBoxColumn();
			Col.MappingName = "maql";
			Col.HeaderText = "";
			Col.Width = 0;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "mabn";
			Col.HeaderText = "Mã BN";
			Col.Width = 60;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "hoten";
			Col.HeaderText = "Họ tên";
			Col.Width = 150;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "namsinh";
			Col.HeaderText = "NS";
			Col.Width = 40;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "tenkp";
			Col.HeaderText = "Khoa";
			Col.Width = 100;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "ngayvv";
			Col.HeaderText = "Ngày vào";
			Col.Width = 100;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "ngaypt";
			Col.HeaderText = "Ngày PTTT";
			Col.Width = 100;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "tenpt";
			Col.HeaderText = "Phương pháp phẫu thủ thuật";
			Col.Width = 300;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);

			Col=new DataGridTextBoxColumn();
			Col.MappingName = "den";
			Col.HeaderText = "";
			Col.Width = 0;
			ts.GridColumnStyles.Add(Col);
			dataGrid1.TableStyles.Add(ts);
		}

		private void tao_chitiet()
		{
			dsct=new DataSet();
			dsct.ReadXml("..//..//..//xml//m_pttt_ct.xml");
			string ngay="";
			foreach(DataRow r in dsngay.Tables[0].Select("true","ngay"))
			{
				if (ngay!=r["ngay"].ToString())
				{
					ngay=r["ngay"].ToString();
					dc=new DataColumn();
					dc.ColumnName="C_"+ngay;
					dc.DataType=Type.GetType("System.Decimal");
					dsct.Tables[0].Columns.Add(dc);
				}
			}
			dc=new DataColumn();
			dc.ColumnName="tongso";
			dc.DataType=Type.GetType("System.Decimal");
			dsct.Tables[0].Columns.Add(dc);
			DataRow r1,r2,r3;
			DataRow [] dr;
			foreach(DataRow r in dsngay.Tables[0].Select("true","ngay"))
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r1!=null)
				{	
					r2=d.getrowbyid(dsct.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
					if (r2==null)
					{
						r3=dsct.Tables[0].NewRow();
						r3["mabd"]=r["mabd"].ToString();
						r3["ten"]=r1["ten"].ToString().Trim()+" "+r1["hamluong"].ToString();
						r3["dang"]=r1["dang"].ToString();
						for(int i=3;i<dsct.Tables[0].Columns.Count;i++) r3[dsct.Tables[0].Columns[i].ColumnName.ToString()]=0;
						r3["c_"+r["ngay"].ToString().Trim()]=r["soluong"].ToString();
						r3["tongso"]=r["soluong"].ToString();
						dsct.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=dsct.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
						if (dr.Length>0)
						{
							dr[0]["c_"+r["ngay"].ToString().Trim()]=decimal.Parse(dr[0]["c_"+r["ngay"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0]["tongso"]=decimal.Parse(dr[0]["tongso"].ToString())+decimal.Parse(r["soluong"].ToString());
						}
					}
				}
			}
			dsxml=new DataSet();
			dsxml=dsct.Copy();
			dsxml.Clear();
			dsxml.Merge(dsct.Tables[0].Select("true","ten"));
			foreach(System.Windows.Forms.Control c in this.Controls) if (c.Name=="dataGrid2") this.Controls.Remove(c);
			dataGrid2=new System.Windows.Forms.DataGrid();
			dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
			dataGrid2.DataMember = "";
			dataGrid2.FlatMode = true;
			dataGrid2.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
			try
			{
				dataGrid2.CaptionText=dataGrid1[dataGrid1.CurrentCell.RowNumber,7].ToString().Trim();
			}
			catch{}
			dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			dataGrid2.Location = new System.Drawing.Point(256,0);
			dataGrid2.Name = "dataGrid2";
			dataGrid2.RowHeaderWidth = 10;
			dataGrid2.Size = new System.Drawing.Size(528, 472);
			dataGrid2.TabIndex = 5;
			dataGrid2.DataSource=dsxml.Tables[0];
			AddGridTableStyle1();

			this.Controls.Add(dataGrid2);
			lan.Read_dtgrid_to_Xml(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid2, this.Name.ToString()+"_"+dataGrid2.Name.ToString());
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{/*
          * user+".btdbn a,"+user+".benhandt b,xxx.pttt c,"+user+".btdkp_bv d,"+user+".xuatvien e
          * 
          * a.mabn=b.mabn and b.maql=c.maql and c.makp=d.makp and b.maql=e.maql(+)
          * */
            sql ="select a.mabn,a.hoten,a.namsinh,d.tenkp,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngaypt,c.tenpt,";
			sql+=" case when e.ngay is null then to_char(now(),'dd/mm/yyyy') else to_char(e.ngay,'dd/mm/yyyy') end as den";
			sql+=" from "+user+".btdbn a inner join "+user+".benhandt b on a.mabn=b.mabn inner join xxx.pttt c on b.maql=c.maql inner join "+user+".btdkp_bv d on c.makp=d.makp left join "+user+".xuatvien e on b.maql=e.maql ";
			sql+=" where true";
			sql+=" and "+m.for_ngay("c.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (makp.SelectedIndex!=-1) sql+=" and c.makp='"+makp.SelectedValue.ToString()+"'";
            sql += " union all ";
            sql += "select a.mabn,a.hoten,a.namsinh,d.tenkp,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngaypt,c.tenpt,";
            sql += " case when b.ngayrv is null then to_char(now(),'dd/mm/yyyy') else to_char(b.ngayrv,'dd/mm/yyyy') end as den";
            sql += " from " + user + ".btdbn a inner join " + user + ".benhanngtr b on a.mabn=b.mabn inner join xxx.pttt c on b.maql=c.maql inner join " + user + ".btdkp_bv d on c.makp=d.makp  ";
            sql += " where true";
            sql += " and " + m.for_ngay("c.ngay", "'dd/mm/yyyy'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
            if (makp.SelectedIndex != -1) sql += " and c.makp='" + makp.SelectedValue.ToString() + "'";
            sql += " union all ";
            sql += "select a.mabn,a.hoten,a.namsinh,d.tenkp,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngaypt,c.tenpt,";
            sql += " case when b.ngayrv is null then to_char(now(),'dd/mm/yyyy') else to_char(b.ngayrv,'dd/mm/yyyy') end as den";
            sql += " from " + user + ".btdbn a inner join xxx.benhancc b on a.mabn=b.mabn inner join xxx.pttt c on b.maql=c.maql inner join " + user + ".btdkp_bv d on c.makp=d.makp  ";
            sql += " where true";
            sql += " and " + m.for_ngay("c.ngay", "'dd/mm/yyyy'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
            if (makp.SelectedIndex != -1) sql += " and c.makp='" + makp.SelectedValue.ToString() + "'";
            sql += " union all ";
            sql += "select a.mabn,a.hoten,a.namsinh,d.tenkp,b.maql,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngaypt,c.tenpt,";
            sql += " to_char(b.ngay,'dd/mm/yyyy') as den";
            sql += " from " + user + ".btdbn a inner join xxx.benhanpk b on a.mabn=b.mabn inner join xxx.pttt c on b.maql=c.maql inner join " + user + ".btdkp_bv d on c.makp=d.makp  ";
            sql += " where true";
            sql += " and " + m.for_ngay("c.ngay", "'dd/mm/yyyy'") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
            if (makp.SelectedIndex != -1) sql += " and c.makp='" + makp.SelectedValue.ToString() + "'";
            sql += " order by tenkp,ngaypt desc";
			dsll.Clear();
			dsll.Merge(m.get_data_mmyy(sql,tu.Text,den.Text,false));
			dataGrid1.DataSource=dsll.Tables[0];
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				maql=decimal.Parse(dataGrid1[dataGrid1.CurrentCell.RowNumber,0].ToString());
				ngaypt=dataGrid1[dataGrid1.CurrentCell.RowNumber,6].ToString().Substring(0,10);
			}
			catch{maql=0;ngaypt="";}
			load_chitiet();
		}

		private void load_chitiet()
		{
			dsngay.Clear();
			try
			{
				DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
				DateTime dt2=d.StringToDate(dataGrid1[dataGrid1.CurrentCell.RowNumber,8].ToString().Trim()).AddDays(d.iNgaykiemke);
				int y1=dt1.Year,m1=dt1.Month;
				int y2=dt2.Year,m2=dt2.Month;
				int itu,iden;
				string mmyy="";		
				for(int i=y1;i<=y2;i++)
				{
					itu=(i==y1)?m1:1;
					iden=(i==y2)?m2:12;
					for(int j=itu;j<=iden;j++)
					{
						mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
						if (d.bMmyy(mmyy))
						{
                            sql = "select to_char(a.ngay,'yyyymmdd') as ngay,a.mabd,sum(a.soluong) as soluong from " + user + mmyy + ".d_tienthuoc a," + user +".d_dmbd b";
							sql+=" where a.mabd=b.id and a.maql="+maql;
							sql+=" group by to_char(a.ngay,'yyyymmdd'),a.mabd";
							dsngay.Merge(d.get_data(sql));
						}
					}
				}
				tao_chitiet();
			}
			catch{}
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts1=new DataGridTableStyle();
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			ts1.MappingName = dsxml.Tables[0].TableName;
			ts1.AlternatingBackColor = Color.Beige;
			ts1.BackColor = Color.GhostWhite;
			ts1.ForeColor = Color.MidnightBlue;
			ts1.GridLineColor = Color.RoyalBlue;
			ts1.HeaderBackColor = Color.MidnightBlue;
			ts1.HeaderForeColor = Color.Lavender;
			ts1.SelectionBackColor = Color.Teal;
			ts1.SelectionForeColor = Color.PaleGreen;
			ts1.ReadOnly=false;
			ts1.RowHeaderWidth=5;

			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên thuốc - hàm lượng";
			TextCol.Width = 150;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts1);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts1);
			int i=3;
			string ngay;
			i_col=0;
			for(;i<dsct.Tables[0].Columns.Count-1;i++)
			{

				ngay=dsct.Tables[0].Columns[i].ColumnName.ToString().Substring(2);
				if (ngay.Substring(6,2)+"/"+ngay.Substring(4,2)+"/"+ngay.Substring(0,4)==ngaypt) i_col=i-3;
				TextCol=new DataGridColoredTextBoxColumn(de,i-2);
				TextCol.MappingName = dsct.Tables[0].Columns[i].ColumnName.ToString();
				TextCol.HeaderText = ngay.Substring(6,2)+"/"+ngay.Substring(4,2)+"/"+ngay.Substring(2,2);
				TextCol.Width = 50;
				TextCol.Format="#,###,###.##";
				TextCol.Alignment=HorizontalAlignment.Right;
				ts1.GridColumnStyles.Add(TextCol);
				dataGrid2.TableStyles.Add(ts1);
			}
			TextCol=new DataGridColoredTextBoxColumn(de,i);
			TextCol.MappingName = "tongso";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 50;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts1);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (col>i_col && col<dsct.Tables[0].Columns.Count-1) return Color.Red;
			else return Color.Black;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
			int be=3;
			int dong=dsxml.Tables[0].Rows.Count+be+1,socot=dsxml.Tables[0].Columns.Count;
			string ten,tenfile=d.Export_Excel(dsxml,"sudungthuoc");
			oxl=new Excel.Application();
            owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			oxl.ActiveWindow.DisplayZeros=false;
            for (int i = 0; i < be; i++) osheet.get_Range(d.getIndex(i) + "1", d.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
			osheet.Cells[be+1,1]="Tên thuốc - hàm lượng";
			osheet.Cells[be+1,2]="ĐVT";
			int j=3;
			for(;j<socot-1;j++) 
			{
				ten=dsxml.Tables[0].Columns[j].ColumnName.Substring(2);
				osheet.Cells[be+1,j]=ten.Substring(6,2)+"/"+ten.Substring(4,2)+"/"+ten.Substring(2,2);
			}
			osheet.Cells[be+1,j]="Tổng cộng";
			orange=osheet.get_Range(m.getIndex(0)+"4",m.getIndex(socot-2)+"4");
			orange.VerticalAlignment=Excel.XlVAlign.xlVAlignCenter;
			orange.HorizontalAlignment=Excel.XlVAlign.xlVAlignCenter;
			osheet.get_Range(d.getIndex(be-1)+"4",d.getIndex(socot-2)+"4").Orientation=90;
			osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot-2)+dong.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			osheet.get_Range(m.getIndex(0)+"4",m.getIndex(socot-2)+dong.ToString()).EntireColumn.AutoFit();
			osheet.Cells[1,1]="Họ tên :"+dataGrid1[dataGrid1.CurrentCell.RowNumber,1].ToString().Trim()+"-"+dataGrid1[dataGrid1.CurrentCell.RowNumber,2].ToString().Trim();
			osheet.Cells[2,1]="Ngày vào :"+dataGrid1[dataGrid1.CurrentCell.RowNumber,5].ToString();
			osheet.Cells[2,4]="Ngày phẫu thủ thuật :"+dataGrid1[dataGrid1.CurrentCell.RowNumber,6].ToString().Substring(0,10);
			osheet.Cells[3,1]="Phương pháp phẫu thủ thuật :"+dataGrid1[dataGrid1.CurrentCell.RowNumber,7].ToString().Trim();
			oxl.Visible=true;
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
	}
}
