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
	/// Summary description for frmSbanhapkho.
	/// </summary>
	public class frmSbanhapkho : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox loaibn;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTonghop;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private string sql,s_makp,s_tinh;
        private string m_user;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSbanhapkho(AccessData acc,string makp)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSbanhapkho));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTonghop = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(64, 8);
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
            this.den.Location = new System.Drawing.Point(208, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(288, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "điều trị :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaibn
            // 
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.Items.AddRange(new object[] {
            "Nội trú"});
            this.loaibn.Location = new System.Drawing.Point(336, 8);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(80, 21);
            this.loaibn.TabIndex = 2;
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(8, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(152, 452);
            this.makp.TabIndex = 6;
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
            this.dataGrid1.Location = new System.Drawing.Point(168, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 472);
            this.dataGrid1.TabIndex = 20;
            // 
            // butTonghop
            // 
            this.butTonghop.Image = ((System.Drawing.Image)(resources.GetObject("butTonghop.Image")));
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(264, 496);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(92, 25);
            this.butTonghop.TabIndex = 3;
            this.butTonghop.Text = "&Tổng hợp";
            this.butTonghop.Click += new System.EventHandler(this.butTonghop_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(356, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(92, 25);
            this.butIn.TabIndex = 4;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(448, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(92, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmSbanhapkho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.loaibn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSbanhapkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số bệnh án đã nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSbanhapkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSbanhapkho_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            m_user = m.user;
            DataTable tmp = m.get_data("select tentt from " + m_user + ".btdtt where matt='" + m.Mabv.Substring(0, 3) + "'").Tables[0];
			if (tmp.Rows.Count>0) s_tinh=tmp.Rows[0]["tentt"].ToString();
			else s_tinh="";
			loaibn.SelectedIndex=0;
            sql = "select makp,tenkp from " + m_user + ".btdkp_bv where makp<>'01' and loai=0 ";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by makp";
			dt=m.get_data(sql).Tables[0];

            makp.DataSource = dt;
            makp.ValueMember = "makp";
			makp.DisplayMember="tenkp";			
			
			ds.ReadXml("..//..//..//xml//sbanhapkho.xml");
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());

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
			ts.AllowSorting=false;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "makp";
			TextCol.HeaderText = "Khoa";
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "so";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "nam";
			TextCol.HeaderText = "Nam";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "nu";
			TextCol.HeaderText = "Nữ";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "bhyt";
			TextCol.HeaderText = "BHYT";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "khac";
			TextCol.HeaderText = "Khác";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "t04";
			TextCol.HeaderText = "0-4 Tuổi";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "t06";
			TextCol.HeaderText = "0-6 Tuổi";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "t14";
			TextCol.HeaderText = "0-14 Tuổi";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "t1560";
			TextCol.HeaderText = "15-60 Tuổi";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "t90";
			TextCol.HeaderText = "90 Tuổi";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "tinh";
			TextCol.HeaderText = "Tỉnh";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "tp";
			TextCol.HeaderText = s_tinh;
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "cv";
			TextCol.HeaderText = "Chuyển viện";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "tv";
			TextCol.HeaderText = "Tử vong";
			TextCol.Width = 60;
			TextCol.Format="###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (this.dataGrid1[row,0].ToString().Trim()=="TỔNG SỐ :")?Color.Red:Color.Black;
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

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
			string kp="";
			if (makp.SelectedItems.Count>0) for(int i=0;i<makp.Items.Count;i++) if (makp.GetItemChecked(i)) kp+="'"+ dt.Rows[i]["makp"].ToString()+"',";
            if (loaibn.SelectedIndex == 0)
            {
                sql = "select a.makp,sum(1) as so,";
                sql += "sum(to_number(decode(b.madoituong,1,1,0))) bhyt,sum(to_number(decode(b.madoituong,1,0,1))) khac,";
                sql += "sum(to_number(decode(c.phai,0,1,0))) nam,sum(to_number(decode(c.phai,1,1,0))) nu,";
                sql += "sum(to_number(case when to_number(to_char(b.ngay,'yyyy'),'0000')-to_number(to_char(c.namsinh),'0000')<5 then 1 else 0 end)) t04,";
                sql += "sum(to_number(case when to_number(to_char(b.ngay,'yyyy'),'0000')-to_number(to_char(c.namsinh),'0000')<7 then 1 else 0 end)) t06,";
                sql += "sum(to_number(case when to_number(to_char(b.ngay,'yyyy'),'0000')-to_number(to_char(c.namsinh),'0000')<15 then 1 else 0 end)) t14,";
                sql += "sum(to_number(case when to_number(to_char(b.ngay,'yyyy'),'0000')-to_number(to_char(c.namsinh),'0000') between 15 and 60 then 1 else 0 end)) t1560,";
                sql += "sum(to_number(case when to_number(to_char(b.ngay,'yyyy'),'0000')-to_number(to_char(c.namsinh),'0000')>90 then 1 else 0 end)) t90,";
                sql += "sum(to_number(decode(c.matt,'" + m.Mabv.Substring(0, 3) + "',0,1))) tinh,";
                sql += "sum(to_number(decode(c.matt,'" + m.Mabv.Substring(0, 3) + "',1,0))) tp,";
                sql += "sum(to_number(decode(a.ttlucrv,6,1,0))) cv,";
                sql += "sum(to_number(decode(a.ttlucrv,7,1,0))) tv";
                sql += " from " + m_user + ".xuatvien a inner join " + m_user + ".benhandt b on a.maql = b.maql ";
                sql += " inner join " + m_user + ".btdbn c on a.mabn = c.mabn where ";
                sql += m.for_ngay("a.ngay", "'dd/mm/yyyy' ") + " between to_date('" + tu.Text + "','dd/mm/yyyy') and to_date('" + den.Text + "','dd/mm/yyyy')";
                if (kp != "") sql += " and a.makp in (" + kp.Substring(0, kp.Length - 1) + ")";
                sql += " and b.loaiba=1 and a.done=1";
                sql += " group by a.makp order by a.makp";
                ds = m.get_data(sql);
                DataRow r1;
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r1 = m.getrowbyid(dt, "makp='" + r["makp"].ToString() + "'");
                    if (r1 != null) r["makp"] = r1["tenkp"].ToString();
                }
                Tongcong();
                dataGrid1.DataSource = ds.Tables[0];
            }

            //if (loaibn.SelectedIndex==0) sql+=" and b.loaiba=1";
            
            //else sql += " and b.loaiba=2";
			
		}

		private void Tongcong()
		{
			updrec(ds.Tables[0]);
			string exp="makp not is null",stt="makp is null";
			DataRow[] r;
			Int16 iRec;
			decimal l_tong;
			for(int k=1;k<ds.Tables[0].Columns.Count;k++)
			{
				r=ds.Tables[0].Select(exp);
				iRec=Convert.ToInt16(r.Length);
				l_tong=0;
				for(Int16 i=0;i<iRec;i++) l_tong+=Decimal.Parse(r[i][k].ToString());
				r=ds.Tables[0].Select(stt);
				if (r.Length>0) r[0][k]=l_tong;
			}
			r=ds.Tables[0].Select(stt);
			if (r.Length>0) r[0][0]="TỔNG SỐ :";
		}

		private void updrec(DataTable dt)
		{
			DataRow nrow = dt.NewRow();
			dt.Rows.Add(nrow) ;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				return;
			}
			dllReportM.frmReport f=new dllReportM.frmReport(m,ds.Tables[0],"sbanhapkho.rpt",m.Syte,m.Tenbv,(tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày :"+tu.Text+" đến ngày :"+den.Text,loaibn.Text,s_tinh,"","","","","");
			f.ShowDialog(this);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
