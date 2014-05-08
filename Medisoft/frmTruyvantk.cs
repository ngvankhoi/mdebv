﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using WebTel.Drawing.Chart;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmTkvaovien.
	/// </summary>
	public class frmTruyvantk : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butTim;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable icd=new DataTable();
		private AccessData m;
		private string sql,sql1,sql2;
		private int ts;
		private MaskedBox.MaskedBox den;
		private MaskedBox.MaskedBox tu;
		private System.Windows.Forms.ComboBox noidung;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.TextBox soca;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Panel panel1;
		private WebTel.Drawing.Chart.ucChart ucChart1;
		private Label lbl1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox butBieudo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTruyvantk(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTruyvantk));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butTim = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.den = new MaskedBox.MaskedBox();
            this.tu = new MaskedBox.MaskedBox();
            this.noidung = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.soca = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucChart1 = new WebTel.Drawing.Chart.ucChart();
            this.butBieudo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(116, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(299, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nội dung :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 17);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 464);
            this.dataGrid1.TabIndex = 16;
            // 
            // butTim
            // 
            this.butTim.Image = ((System.Drawing.Image)(resources.GetObject("butTim.Image")));
            this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTim.Location = new System.Drawing.Point(201, 490);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(100, 25);
            this.butTim.TabIndex = 4;
            this.butTim.Text = "&Truy vấn";
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(501, 490);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(100, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // den
            // 
            this.den.BackColor = System.Drawing.SystemColors.HighlightText;
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(160, 12);
            this.den.Mask = "##/##/####";
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(64, 21);
            this.den.TabIndex = 1;
            this.den.Text = "  /  /    ";
            this.den.Validated += new System.EventHandler(this.den_Validated);
            // 
            // tu
            // 
            this.tu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(64, 12);
            this.tu.Mask = "##/##/####";
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(64, 21);
            this.tu.TabIndex = 0;
            this.tu.Text = "  /  /    ";
            this.tu.Validated += new System.EventHandler(this.tu_Validated);
            // 
            // noidung
            // 
            this.noidung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(360, 12);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(424, 21);
            this.noidung.TabIndex = 3;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noidung_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(216, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 65;
            this.label8.Text = "Số ca :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(8, 492);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(176, 23);
            this.lbl.TabIndex = 66;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // soca
            // 
            this.soca.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soca.Location = new System.Drawing.Point(264, 12);
            this.soca.Name = "soca";
            this.soca.Size = new System.Drawing.Size(40, 21);
            this.soca.TabIndex = 2;
            this.soca.Text = "20";
            this.soca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soca.Validated += new System.EventHandler(this.soca_Validated);
            this.soca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.soca_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(401, 490);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(100, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Location = new System.Drawing.Point(704, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 452);
            this.panel1.TabIndex = 70;
            this.panel1.Visible = false;
            // 
            // ucChart1
            // 
            // Layout is suspended for performance reasons.
            this.ucChart1.Chart.SuspendLayout();
            this.ucChart1.Chart.CategoryX.Font = null;
            this.ucChart1.Chart.CategoryX.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryX.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.CategoryY.Font = null;
            this.ucChart1.Chart.CategoryY.ForeColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.GridLineColor = System.Drawing.Color.Black;
            this.ucChart1.Chart.CategoryY.LineDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ucChart1.Chart.ChartBackColor = System.Drawing.SystemColors.Info;
            this.ucChart1.Chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChart1.Chart.MarginBackColor = System.Drawing.Color.White;
            this.ucChart1.Chart.ResumeLayout();
            this.ucChart1.Location = new System.Drawing.Point(8, 37);
            this.ucChart1.Name = "ucChart1";
            this.ucChart1.Size = new System.Drawing.Size(768, 450);
            this.ucChart1.TabIndex = 69;
            this.ucChart1.Visible = false;
            // 
            // butBieudo
            // 
            this.butBieudo.Appearance = System.Windows.Forms.Appearance.Button;
            this.butBieudo.Image = ((System.Drawing.Image)(resources.GetObject("butBieudo.Image")));
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(301, 490);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(100, 25);
            this.butBieudo.TabIndex = 71;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.butBieudo.CheckedChanged += new System.EventHandler(this.butBieudo_CheckedChanged);
            // 
            // frmTruyvantk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butBieudo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucChart1);
            this.Controls.Add(this.soca);
            this.Controls.Add(this.den);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butTim);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTruyvantk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truy vấn thông tin từ biểu thống kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTruyvantk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTruyvantk_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			noidung.DisplayMember="ten";
			noidung.ValueMember="ma";
			dsxml.ReadXml("..//..//..//xml//tksosanh.xml");
			noidung.DataSource=dsxml.Tables[0];
			ds.ReadXml("..//..//..//xml//tvsolieu.xml");
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			icd=m.get_data("select * from "+m.user+".dm_11").Tables[0];
            tu.Text = m.ngayhienhanh_server.Substring(0, 10);
            den.Text = tu.Text;
		}

		private void tu_Validated(object sender, System.EventArgs e)
		{
			if (tu.Text=="")
			{
				den.Text="";
				return;
			}
			tu.Text=tu.Text.Trim();
			if (!m.bNgay(tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				tu.Focus();
				return;
			}
			tu.Text=m.Ktngaygio(tu.Text,10);
            if (den.Text == "") den.Text = tu.Text;
		}

		private void den_Validated(object sender, System.EventArgs e)
		{
			if (den.Text=="")
			{
				tu.Text="";
				return;
			}
			den.Text=den.Text.Trim();
			if (!m.bNgay(den.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				den.Focus();
				return;
			}
			den.Text=m.Ktngaygio(den.Text,10);
			if (tu.Text=="")
			{
				tu.Focus();
				return;
			}
			if (!m.bNgay(den.Text,tu.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đến ngày không được nhỏ hơn từ ngày !"));
				den.Focus();
				return;
			}
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
			DataRow r1,r2;
			ds.Clear();
			sql="";
			if (tu.Text!="")
				sql=" and "+m.for_ngay("a.ngay","'"+m.f_ngay+"'")+" between to_date('"+tu.Text+"','"+m.f_ngay+"') and to_date('"+den.Text+"','"+m.f_ngay+"')";
			r1=m.getrowbyid(dsxml.Tables[0],"ma='"+noidung.SelectedValue.ToString()+"'");
			if (r1==null) return;
			sql1=r1["sql1"].ToString()+" where a.ma=b.ma and b.icd10<>'-' "+sql+" "+r1["gr1"].ToString();
			sql2=r1["sql2"].ToString()+" where a.ma=b.ma and b.icd10<>'-' "+sql+" "+r1["gr2"].ToString();
			int i=1,so=(soca.Text=="")?0:int.Parse(soca.Text);
			ts=0;
			try
			{
				ts=int.Parse(m.get_data(sql2.Replace("medibv",m.user)).Tables[0].Rows[0][0].ToString());
			}
			catch{}
			lbl.Text="TỔNG SỐ : "+ts.ToString("### ### ### ###");
			foreach(DataRow r in m.get_data(sql1.Replace("medibv",m.user)).Tables[0].Rows)
			{
				r2=m.getrowbyid(icd,"ma="+int.Parse(r["ma"].ToString()));
				if (r2!=null)
				{
					r1 = ds.Tables[0].NewRow();
					r1["maicd"] = r2["icd10"].ToString();
					r1["tenbenh"] = r2["ten"].ToString();
					r1["solieu"] = Decimal.Parse(r["solieu"].ToString());
					r1["tyle"] = Decimal.Parse(r["solieu"].ToString())/ts*100;
					ds.Tables[0].Rows.Add(r1);
					if (so!=0)
					{
						i++;
						if (i>so) break;
					}
				}
			}
			dataGrid1.DataSource=ds.Tables[0];
		}

		private void AddGridTableStyle()
		{
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
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "maicd";
			TextCol.HeaderText = "Mã ICD";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenbenh";
			TextCol.HeaderText = "Tên bệnh";
			TextCol.Width = 520;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "solieu";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 80;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tyle";
			TextCol.HeaderText = "Tỷ lệ (%)";
			TextCol.Width = 80;
			TextCol.Format="# ### ##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{ 
			m.close();this.Close();
		}

		private void noidung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void soca_Validated(object sender, System.EventArgs e)
		{
			if (soca.Text=="") soca.Text="0";
		}

		private void soca_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				tu.Focus();
				return;
			}
			dllReportM.frmReport f=new dllReportM.frmReport(m,ds,noidung.Text.ToUpper(),"rptTruyvan.rpt",ts,0,0,0,0,0,0,0,0,0);
			f.ShowDialog();		
		}

		private void butBieudo_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),AccessData.Msg);
				tu.Focus();
				return;
			}
			ucChart1.Visible=butBieudo.Checked;
			panel1.Visible=ucChart1.Visible;
			if (panel1.Visible)
			{
				panel1.BringToFront();
				ucChart1.Chart.ChartType = ChartTypes.Bar;
				ucChart1.Chart.Series.Items.Clear();
				ucChart1.Chart.CategoryX.Items.Clear();
				panel1.Controls.Clear();
				try
				{
					ucChart1.Chart.CategoryX.Items.Add(new ChartCategory(noidung.Text.ToUpper(),0));
					int i=0;
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						float [] f={float.Parse(r["solieu"].ToString())};
						ucChart1.Chart.Series.Items.Add(new ChartSerie(m.getColor(i),Color.Black,f));
						title(r["tenbenh"].ToString(),r["maicd"].ToString(),i,i*26+8,decimal.Parse(r["solieu"].ToString()));//40
						i++;
					}
					ucChart1.Refresh();		
				}
				catch{}
			}
		}

		private void title(string ten,string so,int ind,int y,decimal solieu)
		{
			toolTip1=new ToolTip();
			lbl1=new Label();
			lbl1.Text=so;
			lbl1.Location = new Point(5,y);//736
			lbl1.Size = new Size(50, 23);
			lbl1.TextAlign = ContentAlignment.MiddleCenter;
			lbl1.BackColor=m.getColor(ind);
			toolTip1.SetToolTip(lbl1,ten.Trim()+"("+solieu.ToString().Trim()+")");
			toolTip1.Active=true;
			this.panel1.Controls.Add(lbl1);
			lbl1.BringToFront();
		}
	}
}
