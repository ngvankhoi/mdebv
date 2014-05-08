using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDoichieu.
	/// </summary>
	public class frmDoichieu : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox tenloai;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butDoichieu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private string sql,s_makp,user,stime;
		private bool bClear=true;
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox madoituong;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDoichieu(LibMedi.AccessData acc,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m=acc;s_makp=makp;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoichieu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tenloai = new System.Windows.Forms.ComboBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butDoichieu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(128, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(231, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(420, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khoa phòng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(48, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(160, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tenloai
            // 
            this.tenloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenloai.Location = new System.Drawing.Point(278, 8);
            this.tenloai.Name = "tenloai";
            this.tenloai.Size = new System.Drawing.Size(146, 21);
            this.tenloai.TabIndex = 5;
            this.tenloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tenkp
            // 
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(488, 8);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(128, 21);
            this.tenkp.TabIndex = 7;
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
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
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 472);
            this.dataGrid1.TabIndex = 13;
            // 
            // butDoichieu
            // 
            this.butDoichieu.Image = ((System.Drawing.Image)(resources.GetObject("butDoichieu.Image")));
            this.butDoichieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDoichieu.Location = new System.Drawing.Point(287, 495);
            this.butDoichieu.Name = "butDoichieu";
            this.butDoichieu.Size = new System.Drawing.Size(74, 25);
            this.butDoichieu.TabIndex = 10;
            this.butDoichieu.Text = "Đối chiếu";
            this.butDoichieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDoichieu.Click += new System.EventHandler(this.butDoichieu_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(363, 495);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 11;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(435, 495);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(610, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đối tượng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(680, 8);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(104, 21);
            this.madoituong.TabIndex = 9;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmDoichieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butDoichieu);
            this.Controls.Add(this.tenloai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoichieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đối chiếu chỉ định - viện phí - thực hiện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDoichieu_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDoichieu_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDoichieu_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user; stime = "'" + m.f_ngay + "'";
			tenloai.DisplayMember="TEN";
			tenloai.ValueMember="ID";
			tenloai.DataSource=m.get_data("select * from "+user+".v_loaivp order by stt").Tables[0];

			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
            sql = "select * from " + user + ".btdkp_bv";
			if (s_makp!="")
			{
				string s=s_makp.Replace(",","','");
				sql+=" where makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai desc,makp";
			tenkp.DataSource=m.get_data(sql).Tables[0];

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
            madoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
			ds.ReadXml("..//..//..//xml//m_doichieu.xml");
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
		}

		private void frmDoichieu_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				tenloai.SelectedIndex=-1;
				tenkp.SelectedIndex=-1;
				madoituong.SelectedIndex=-1;
				bClear=false;
			}
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
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Nội dung";
			TextCol.Width = 380;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "c01";
			TextCol.HeaderText = "Ca chỉ định";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "c02";
			TextCol.HeaderText = "Ca thu tiền";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "c03";
			TextCol.HeaderText = "Số tiền đã thu";
			TextCol.Width = 100;
			TextCol.Format="###,###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "c04";
			TextCol.HeaderText = "Ca đã thực hiện";
			TextCol.Width = 100;
			TextCol.Format="###,###,###,###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			if (decimal.Parse(this.dataGrid1[row,2].ToString().Trim())==0 && decimal.Parse(this.dataGrid1[row,4].ToString().Trim())!=0) return Color.Red;
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

		private void load_grid()
		{
			ds.Clear();
			DataRow r2,r3;
			DataRow [] dr;
			sql="select b.stt,c.ten,a.mavp,a.paid,a.done,sum(a.soluong) as soluong,sum(a.soluong*(a.dongia+a.vattu)) as sotien ";
			sql+=" from xxx.v_chidinh a,"+user+".v_loaivp b,"+user+".v_giavp c where a.mavp=c.id and c.id_loai=b.id ";
            sql+=" and " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (tenloai.SelectedIndex!=-1) sql+=" and b.id="+int.Parse(tenloai.SelectedValue.ToString());
			if (tenkp.SelectedIndex!=-1) sql+=" and a.makp='"+tenkp.SelectedValue.ToString()+"'";
			if (madoituong.SelectedIndex!=-1) sql+=" and a.madoituong="+int.Parse(madoituong.SelectedValue.ToString());
			sql+=" group by b.stt,c.ten,a.mavp,a.paid,a.done";
			foreach(DataRow r in v.get_vienphi(tu.Text,den.Text,sql).Tables[0].Select("true","stt,ten"))
			{
				r2=m.getrowbyid(ds.Tables[0],"mavp="+int.Parse(r["mavp"].ToString()));
				if (r2==null)
				{
					r3=ds.Tables[0].NewRow();
					r3["mavp"]=r["mavp"].ToString();
					r3["ten"]=r["ten"].ToString();
					r3["c01"]=r["soluong"].ToString();
					r3["c02"]=0;
					r3["c03"]=0;
					r3["c04"]=0;
					if (r["paid"].ToString()=="1")
					{
						r3["c02"]=r["soluong"].ToString();
						r3["c03"]=r["sotien"].ToString();
					}
					if (r["done"].ToString()=="1") r3["c04"]=r["soluong"].ToString();
					ds.Tables[0].Rows.Add(r3);
				}
				else
				{
					dr=ds.Tables[0].Select("mavp="+int.Parse(r["mavp"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["c01"]=decimal.Parse(dr[0]["c01"].ToString())+decimal.Parse(r["soluong"].ToString());
						if (r["paid"].ToString()=="1")
						{
							dr[0]["c02"]=decimal.Parse(dr[0]["c02"].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0]["c03"]=decimal.Parse(dr[0]["c03"].ToString())+decimal.Parse(r["sotien"].ToString());
						}
						if (r["done"].ToString()=="1") dr[0]["c04"]=decimal.Parse(dr[0]["c04"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butDoichieu_Click(object sender, System.EventArgs e)
		{
			load_grid();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds.Tables[0],"m_doichieu.rpt",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,(madoituong.SelectedIndex!=-1)?madoituong.Text:"",(tenloai.SelectedIndex!=-1)?tenloai.Text:"",(tenkp.SelectedIndex!=-1)?tenkp.Text:"","","","","","","");
				f.ShowDialog();
			}
		}
	}
}
