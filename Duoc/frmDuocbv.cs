using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmDuocbv.
	/// </summary>
	public class frmDuocbv : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butTonghop;
		private DataSet ds=new DataSet();
        private string user;
		private int i_row,i_col,i_tong,i_nhom,i_userid;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private System.Windows.Forms.Button butKHTH;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDuocbv(LibDuoc.AccessData acc,int nhom,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;i_userid=userid;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuocbv));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butTonghop = new System.Windows.Forms.Button();
            this.butKHTH = new System.Windows.Forms.Button();
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
            this.dataGrid1.Location = new System.Drawing.Point(8, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 512);
            this.dataGrid1.TabIndex = 8;
            // 
            // den
            // 
            this.den.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(434, 501);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(321, 501);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(399, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(266, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(516, 531);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(446, 531);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butTonghop
            // 
            this.butTonghop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTonghop.Image = global::Duoc.Properties.Resources.ok;
            this.butTonghop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTonghop.Location = new System.Drawing.Point(216, 531);
            this.butTonghop.Name = "butTonghop";
            this.butTonghop.Size = new System.Drawing.Size(74, 25);
            this.butTonghop.TabIndex = 4;
            this.butTonghop.Text = "&Tổng hợp";
            this.butTonghop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTonghop.Click += new System.EventHandler(this.butTonghop_Click);
            // 
            // butKHTH
            // 
            this.butKHTH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKHTH.Enabled = false;
            this.butKHTH.Image = global::Duoc.Properties.Resources.Export;
            this.butKHTH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKHTH.Location = new System.Drawing.Point(290, 531);
            this.butKHTH.Name = "butKHTH";
            this.butKHTH.Size = new System.Drawing.Size(156, 25);
            this.butKHTH.TabIndex = 5;
            this.butKHTH.Text = "Chuyển vào Medisoft 2003";
            this.butKHTH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKHTH.Click += new System.EventHandler(this.butKHTH_Click);
            // 
            // frmDuocbv
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 572);
            this.Controls.Add(this.butKHTH);
            this.Controls.Add(this.butTonghop);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDuocbv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dược bệnh viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDuocbv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDuocbv_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user;
			load_grid();
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			dataGrid1.ReadOnly=false;
		}

		private void load_grid()
		{
            ds = m.get_data("select * from " + user + ".dm_07 order by ma");
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol1;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = ds.Tables[0].TableName;
			ts.AllowSorting=false;
			
			TextCol1=new DataGridColoredTextBoxColumn(de, 0);
			TextCol1.MappingName = "ma";
			TextCol1.HeaderText = "ma";
			TextCol1.Width = 0;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 1);
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "STT";
			TextCol1.Width = 24;
			TextCol1.ReadOnly=true;
			TextCol1.Alignment=HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 2);
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Chỉ tiêu";
			TextCol1.Width = 520;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 3);
			TextCol1.MappingName = "donvi";
			TextCol1.HeaderText = "Đơn vị";
			TextCol1.Width = 100;
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new DataGridColoredTextBoxColumn(de, 4);
			TextCol1.MappingName = "soluong";
			TextCol1.HeaderText = "Số lượng";
			TextCol1.Width = 100;
			TextCol1.Format="# ### ### ###.##";
			TextCol1.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			string s="ABCDE";
			Color c = Color.Black;
			if (s.IndexOf(this.dataGrid1[row,1].ToString().Trim())!=-1)
			{
				c=Color.Red;
				i_tong=row;
			}
			if (row==i_tong) c=Color.Red;
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
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}
		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				i_col=dataGrid1.CurrentCell.ColumnNumber;
				if (i_col<4) return;
				if (dataGrid1[i_row,i_col].ToString().IndexOf("-")!=-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số liệu không hợp lệ !"),d.Msg);
					dataGrid1[i_row,i_col]=0;
				}
				int ma=22;
				if (i_row >=1 && i_row<=2) ma=2;
				else if (i_row>=9 && i_row<=10) ma=11;
				else if (i_row>=14 && i_row<=15) ma=17;
				m.updrec_07(ds.Tables[0],ma,i_col,0);
				i_row=dataGrid1.CurrentRowIndex;
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			frmReport f=new frmReport(d,ds.Tables[0], i_userid,(tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày : "+tu.Text+" đến ngày : "+den.Text,"bieu_07.rpt");
			f.ShowDialog(this);
		}

		private void butTonghop_Click(object sender, System.EventArgs e)
		{
            //f_tonghop_duocbv();//mau cu
            f_tonghop_duocbv_angiang();//mau moi cua An giang
		}

		private void butKHTH_Click(object sender, System.EventArgs e)
		{
			decimal l_id=0;
			DataTable tmp=m.get_data("select id from "+user+".bieu_07 where to_char(ngay,'dd/mm/yyyy')='"+tu.Text+"'").Tables[0];
			if (tmp.Rows.Count==0) l_id=m.get_capid(16);
			else l_id=decimal.Parse(tmp.Rows[0]["id"].ToString());
			m.execute_data("delete from "+user+".bieu_07 where id="+l_id);
			string exp="soluong>0";
			DataRow[] r=ds.Tables[0].Select(exp);
			Int16 iRec=Convert.ToInt16(r.Length);
			for(Int16 i=0;i<iRec;i++)
				m.upd_bieu07(l_id,int.Parse(r[i]["ma"].ToString()),tu.Text,Decimal.Parse(r[i]["soluong"].ToString()),i_userid);
			MessageBox.Show(lan.Change_language_MessageText("Đã chuyển thành công !"),d.Msg); 
		}

        private void f_tonghop_duocbv()
        {
            Cursor = Cursors.WaitCursor;
            decimal sum = 0, st = 0;
            DataSet tmp = d.get_sotien_dbv(i_nhom, tu.Text, den.Text);
            foreach (DataRow r in ds.Tables[0].Select("ma in (3,4,5,6,7,8)"))
            {
                st = 0;
                foreach (DataRow r1 in tmp.Tables[0].Select("stt=" + int.Parse(r["ma"].ToString()))) st += decimal.Parse(r1["sotien"].ToString());
                r["soluong"] = st / 1000;
            }
            foreach (DataRow r in tmp.Tables[0].Rows) sum += decimal.Parse(r["sotien"].ToString());
            DataRow r2 = d.getrowbyid(ds.Tables[0], "ma=1");
            if (r2 != null) r2["soluong"] = sum / 1000;
            tmp = d.get_sothuoc_dbv(i_nhom, tu.Text, den.Text);
            r2 = d.getrowbyid(ds.Tables[0], "ma=21");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Rows.Count;
            r2 = d.getrowbyid(ds.Tables[0], "ma=23");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Select("id=1").Length;
            r2 = d.getrowbyid(ds.Tables[0], "ma=24");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Select("id=2").Length;
            tmp = d.get_soluong_dichtruyen(i_nhom, tu.Text, den.Text);
            sum = 0;
            foreach (DataRow r in ds.Tables[0].Select("ma in (12,13,14)"))
            {
                st = 0;
                foreach (DataRow r1 in tmp.Tables[0].Select("stt=" + int.Parse(r["ma"].ToString())))
                    st += decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(d.so_chu(r1["hamluong"].ToString()));
                r["soluong"] = st / 1000;
                if (r["ma"].ToString() == "14") sum += st;
            }
            r2 = d.getrowbyid(ds.Tables[0], "ma=13");
            if (r2 != null) r2["soluong"] = decimal.Parse(r2["soluong"].ToString()) + sum / 1000;
            sum = 0;
            foreach (DataRow r in ds.Tables[0].Select("ma in (12,13)")) sum += decimal.Parse(r["soluong"].ToString());
            r2 = d.getrowbyid(ds.Tables[0], "ma=10");
            if (r2 != null) r2["soluong"] = sum;
            foreach (DataRow r in ds.Tables[0].Rows) d.execute_data("update " + user + ".dm_07 set soluong=" + decimal.Parse(r["soluong"].ToString()) + " where ma=" + int.Parse(r["ma"].ToString()));
            butKHTH.Enabled = true;
            Cursor = Cursors.Default;
        }
        private void f_tonghop_duocbv_angiang()
        {
            Cursor = Cursors.WaitCursor;            
            f_get_tongtienthuoc_xuat();
            if(d.bDuocBV_Xuat_tinhnguoncungcap(i_nhom)==false) f_get_tongtienthuoc_nhap();
            else f_get_tongtienthuoc_xuat_donhap();

            foreach (DataRow r in ds.Tables[0].Rows) d.execute_data("update " + user + ".dm_07 set soluong=" + decimal.Parse(r["soluong"].ToString()) + " where ma=" + int.Parse(r["ma"].ToString()));
            Cursor = Cursors.Default;
        }
        private void f_get_tongtienthuoc_xuat()
        {
            string s_ma = "1,3,4";
            DataSet tmp = d.get_sotien_dbv_angiang(i_nhom, tu.Text, den.Text);
            decimal st1 = 0, st2 = 0, st3 = 0;
            foreach (DataRow r1 in tmp.Tables[0].Select("stt>0","stt"))//.Rows)//.Select("stt=" + int.Parse(r["ma"].ToString())))
            {
                st1 += decimal.Parse(r1["sotien"].ToString());
                if (r1["loai"].ToString() == "1")//noi tru - benh vien
                    st2 += decimal.Parse(r1["sotien"].ToString());
                else
                    st3 += decimal.Parse(r1["sotien"].ToString());
            }

            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")")) 
            {       
                if(r["ma"].ToString()=="1")         
                    r["soluong"] = st1 / 1000;
                else if (r["ma"].ToString() == "3")
                    r["soluong"] = st2 / 1000;
                else if (r["ma"].ToString() == "4")
                    r["soluong"] = st3 / 1000;
            }
            //tien thuoc bhyt tra
            tmp = d.get_sotien_bhyt_dbv_angiang_vp(i_nhom, tu.Text, den.Text);
            st2 = 0;
            foreach (DataRow r1 in tmp.Tables[0].Select("stt>0", "stt"))//.Rows)//.Select("stt=" + int.Parse(r["ma"].ToString())))
            {
                st2 += decimal.Parse(r1["sotien"].ToString());                
            }
            s_ma = "9";//thuoc dung cho bhyt
            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                if (r["ma"].ToString() == "9")
                {
                    r["soluong"] = st2 / 1000;
                }
            }
            s_ma = "8";//thuoc dung cho bhyt
            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                r["soluong"] = (st1 - st2) / 1000;
            }
            ds.AcceptChanges();
        }
        private void f_get_tongtienthuoc_nhap()
        {
            //Nhap mua moi
            string s_ma = "14,15,16";
            DataSet tmp = d.get_sotien_nhap_dbv_angiang(i_nhom, tu.Text, den.Text);
            decimal st1 = 0, st2 = 0, st3 = 0, st = 0;
            foreach (DataRow r1 in tmp.Tables[0].Select("stt>0", "stt"))//.Rows)//.Select("stt=" + int.Parse(r["ma"].ToString())))
            {
                if (r1["loai"].ToString() == "DNNN") st1 += decimal.Parse(r1["sotien"].ToString());
                else 
                    st2 += decimal.Parse(r1["sotien"].ToString());
                
            }

            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                if (r["ma"].ToString() == "14")
                    r["soluong"] = st1 / 1000;
                else if (r["ma"].ToString() == "15")
                    r["soluong"] = st2 / 1000;
                else if (r["ma"].ToString() == "16")
                    r["soluong"] = st3 / 1000;
            }
            //ma: 18,19
            s_ma = "18,19";
            st1 = 0; st2 = 0;
            foreach (DataRow r1 in tmp.Tables[0].Select("stt>0", "stt"))//.Rows)//.Select("stt=" + int.Parse(r["ma"].ToString())))
            {
                if (r1["idnn"].ToString() == "1") st1 += decimal.Parse(r1["sotien"].ToString());
                else
                    st2 += decimal.Parse(r1["sotien"].ToString());

            }

            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                if (r["ma"].ToString() == "18")
                    r["soluong"] = st1 / 1000;
                else 
                    r["soluong"] = st2 / 1000;
            }
            //Nhap theo nhom
            s_ma = "20,21,22,23,26,37";
            foreach (DataRow r in ds.Tables[0].Select("ma in ("+s_ma+")"))
            {
                st = 0;
                foreach (DataRow r1 in tmp.Tables[0].Select("stt=" + int.Parse(r["ma"].ToString())))
                    st += decimal.Parse(r1["sotien"].ToString());
                r["soluong"] = st / 1000;
            }
            //chung loai nhap
            s_ma = "27,28,29";
            tmp = d.get_sothuoc_dbv_angiang(i_nhom, tu.Text, den.Text);
            DataRow r2 = d.getrowbyid(ds.Tables[0], "ma=27");//tong chung loai thuoc
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Rows.Count;
            r2 = d.getrowbyid(ds.Tables[0], "ma=28");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Select("id=1").Length;//thuoc noi
            r2 = d.getrowbyid(ds.Tables[0], "ma=29");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Select("id<>1").Length;//thuoc ngoai

            

            //Dich truyen
            tmp = d.get_soluong_dichtruyen_angiang(i_nhom, tu.Text, den.Text);
            st = 0;
            s_ma = "24,25";
            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")")) 
            {
                st1 = 0;
                foreach (DataRow r1 in tmp.Tables[0].Select("stt=" + int.Parse(r["ma"].ToString())))
                    st1 += decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(d.so_chu(r1["hamluong"].ToString()));
                r["soluong"] = st1 / 1000;
            }
            //
            ds.AcceptChanges();
        }

        private void f_get_tongtienthuoc_xuat_donhap()
        {
            //Nhap mua moi
            string s_ma = "14,15,16";//nhap tu dnnn, dntt
            DataSet tmp = d.get_sotien_xuat_nhaptu_dbv_angiang(i_nhom, tu.Text, den.Text);
            decimal st1 = 0, st2 = 0, st3 = 0, st = 0;
            foreach (DataRow r1 in tmp.Tables[0].Select("stt>0", "stt"))//.Rows)//.Select("stt=" + int.Parse(r["ma"].ToString())))
            {
                if (r1["loai"].ToString() == "DNNN") st1 += decimal.Parse(r1["sotien"].ToString());
                else
                    st2 += decimal.Parse(r1["sotien"].ToString());

            }

            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                if (r["ma"].ToString() == "14")
                    r["soluong"] = st1 / 1000;
                else if (r["ma"].ToString() == "15")
                    r["soluong"] = st2 / 1000;
                else if (r["ma"].ToString() == "16")
                    r["soluong"] = st3 / 1000;
            }
            //ma: 18,19
            s_ma = "18,19";//thuoc sx trong nuoc, ngoai nhap
            st1 = 0; st2 = 0;
            foreach (DataRow r1 in tmp.Tables[0].Select("stt>0", "stt"))//.Rows)//.Select("stt=" + int.Parse(r["ma"].ToString())))
            {
                if (r1["idnn"].ToString() == "1") st1 += decimal.Parse(r1["sotien"].ToString());
                else
                    st2 += decimal.Parse(r1["sotien"].ToString());

            }

            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                if (r["ma"].ToString() == "18")
                    r["soluong"] = st1 / 1000;
                else
                    r["soluong"] = st2 / 1000;
            }
            //Nhap theo nhom
            s_ma = "20,21,22,23,26,37";
            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                st = 0;
                foreach (DataRow r1 in tmp.Tables[0].Select("stt=" + int.Parse(r["ma"].ToString())))
                    st += decimal.Parse(r1["sotien"].ToString());
                r["soluong"] = st / 1000;
            }
            //chung loai nhap
            s_ma = "27,28,29";
            //
            //tmp = d.get_sothuoc_dbv_angiang(i_nhom, tu.Text, den.Text);
            tmp = d.get_sothuoc_xuat_dbv_angiang(i_nhom, tu.Text, den.Text);
            DataRow r2 = d.getrowbyid(ds.Tables[0], "ma=27");//tong chung loai thuoc
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Rows.Count;
            r2 = d.getrowbyid(ds.Tables[0], "ma=28");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Select("id=1").Length;//thuoc noi
            r2 = d.getrowbyid(ds.Tables[0], "ma=29");
            if (r2 != null) r2["soluong"] = tmp.Tables[0].Select("id<>1").Length;//thuoc ngoai



            //Dich truyen
            tmp = d.get_soluong_dichtruyen_angiang(i_nhom, tu.Text, den.Text);
            st = 0;
            s_ma = "24,25";
            foreach (DataRow r in ds.Tables[0].Select("ma in (" + s_ma + ")"))
            {
                st1 = 0;
                foreach (DataRow r1 in tmp.Tables[0].Select("stt=" + int.Parse(r["ma"].ToString())))
                    st1 += decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(d.so_chu(r1["hamluong"].ToString()));
                r["soluong"] = st1 / 1000;
            }
            //
            ds.AcceptChanges();
        }
	}
}
