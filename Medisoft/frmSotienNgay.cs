using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using LibVienphi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSotienNgay.
	/// </summary>
	public class frmSotienNgay : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox ketqua;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox maicd;
		private System.Windows.Forms.CheckBox chkmaicd;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butExit;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private System.Windows.Forms.DataGrid dataGrid1;
        private string user;
		private bool bClear=true;
		private DataSet ds=new DataSet();

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSotienNgay()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSotienNgay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ketqua = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maicd = new System.Windows.Forms.TextBox();
            this.chkmaicd = new System.Windows.Forms.CheckBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(131, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(51, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 2;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(163, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(280, 8);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(144, 21);
            this.makp.TabIndex = 5;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(416, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kết quả :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ketqua
            // 
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(472, 8);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(104, 21);
            this.ketqua.TabIndex = 7;
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(567, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã ICD :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maicd
            // 
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(621, 8);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(56, 21);
            this.maicd.TabIndex = 9;
            this.maicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkmaicd
            // 
            this.chkmaicd.Location = new System.Drawing.Point(682, 12);
            this.chkmaicd.Name = "chkmaicd";
            this.chkmaicd.Size = new System.Drawing.Size(120, 16);
            this.chkmaicd.TabIndex = 10;
            this.chkmaicd.Text = "Danh sách ICD10";
            this.chkmaicd.CheckStateChanged += new System.EventHandler(this.chkmaicd_CheckStateChanged);
            this.chkmaicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(323, 496);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(76, 25);
            this.butOk.TabIndex = 11;
            this.butOk.Text = "&Tổng hợp";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butExit
            // 
            this.butExit.Image = global::Medisoft.Properties.Resources.exit1;
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(400, 496);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 12;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
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
            this.dataGrid1.Location = new System.Drawing.Point(12, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(768, 472);
            this.dataGrid1.TabIndex = 20;
            // 
            // frmSotienNgay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.den);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.chkmaicd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSotienNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi phí & số ngày điều trị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSotienNgay_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSotienNgay_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSotienNgay_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			ds.ReadXml("..//..//..//xml//sotienngay.xml");
            makp.DataSource = d.get_data("select * from " + user + ".btdkp_bv order by loai,makp").Tables[0];
            makp.DisplayMember = "TENKP";
			makp.ValueMember="MAKP";

            ketqua.DataSource = d.get_data("select * from " + user + ".ketqua order by ma").Tables[0];
            ketqua.DisplayMember = "TEN";
			ketqua.ValueMember="MA";
			
			dataGrid1.DataSource=ds.Tables[0];
			AddGridTableStyle();	
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
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
			TextCol.MappingName = "chandoan";
			TextCol.HeaderText = "Chẩn đoán";
			TextCol.Width = 425;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soca";
			TextCol.HeaderText = "Số ca";
			TextCol.Width = 50;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "songay";
			TextCol.HeaderText = "Số ngày trung bình";
			TextCol.Width = 100;
			TextCol.Format="# ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền trung bình";
			TextCol.Width = 100;
			TextCol.Format="### ### ### ###";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void frmSotienNgay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				makp.SelectedIndex=-1;
				ketqua.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{	
			Cursor=Cursors.WaitCursor;
			ds.Clear();
			string sql="";
			bool bsum=maicd.Text=="" && !chkmaicd.Checked;
			sql="select a.maql,to_char(a.ngay,'dd/mm/yyyy') ngayvao,to_char(b.ngay,'dd/mm/yyyy') ngayra,b.maicd,b.chandoan,"+m.for_num_ngay("b.ngay")+"-"+m.for_num_ngay("a.ngay")+"+1 as songay,b.sotien ";
			sql+=" from "+user+".benhandt a,"+user+".xuatvien b,"+user+".btdbn c where a.maql=b.maql and a.mabn=c.mabn and a.loaiba=1";
			sql+=" and "+m.for_ngay("b.ngay","'dd/mm/yyyy'")+" between to_date('"+tu.Text+"','dd/mm/yyyy') and to_date('"+den.Text+"','dd/mm/yyyy')";
			if (makp.SelectedIndex!=-1) sql+=" and b.makp='"+makp.SelectedValue.ToString()+"'";
			if (ketqua.SelectedIndex!=-1) sql+=" and b.ketqua="+int.Parse(ketqua.SelectedValue.ToString());
			if (maicd.Text!="") sql+=" and b.maicd='"+maicd.Text+"'";
			if (chkmaicd.Checked) sql+=" and b.maicd in (select ma from bctheoicd)";
			sql+=" order by b.maicd";
			DataRow r1,r2;
			DataRow [] dr;
			if (bsum)
			{
				r1=ds.Tables[0].NewRow();
				r1["maicd"]=" ";
				r1["chandoan"]="Tổng cộng :";
				r1["soca"]=0;
				r1["songay"]=0;
				r1["sotien"]=0;
				ds.Tables[0].Rows.Add(r1);
			}
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				if (bsum)
				{
					ds.Tables[0].Rows[0]["soca"]=decimal.Parse(ds.Tables[0].Rows[0]["soca"].ToString())+1;
					ds.Tables[0].Rows[0]["songay"]=decimal.Parse(ds.Tables[0].Rows[0]["songay"].ToString())+decimal.Parse(r["songay"].ToString());
					ds.Tables[0].Rows[0]["sotien"]=decimal.Parse(ds.Tables[0].Rows[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());//sotien(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString());
				}
				else
				{
					r1=d.getrowbyid(ds.Tables[0],"maicd='"+r["maicd"].ToString()+"'");
					if (r1==null)
					{
						r2=ds.Tables[0].NewRow();
						r2["maicd"]=r["maicd"].ToString();
						r2["chandoan"]=r["chandoan"].ToString();
						r2["soca"]=1;
						r2["songay"]=r["songay"].ToString();
						r2["sotien"]=r["sotien"].ToString();//sotien(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
					else
					{
						dr=ds.Tables[0].Select("maicd='"+r["maicd"].ToString()+"'");
						if (dr.Length>0)
						{
							dr[0]["soca"]=decimal.Parse(dr[0]["soca"].ToString())+1;
							dr[0]["songay"]=decimal.Parse(dr[0]["songay"].ToString())+decimal.Parse(r["songay"].ToString());
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());//sotien(decimal.Parse(r["maql"].ToString()),r["ngayvao"].ToString(),r["ngayra"].ToString());
						}
					}
				}
			}
			foreach(DataRow r in ds.Tables[0].Rows)
			{
                if (r["soca"].ToString() != "0")
                {
                    r["songay"] = decimal.Parse(r["songay"].ToString()) / decimal.Parse(r["soca"].ToString());
                    r["sotien"] = decimal.Parse(r["sotien"].ToString()) / decimal.Parse(r["soca"].ToString());
                }
			}
			Cursor=Cursors.Default;
		}

		private decimal sotien(decimal maql,string tu,string den)
		{
			DateTime dt1=d.StringToDate(tu).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			decimal sotien=0;
			DataTable dt;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						dt=d.get_data("select sum(sotien) sotien from "+user+mmyy+".d_tienthuoc where maql="+maql+" and to_date(ngay,'dd/mm/yy') between to_date('"+tu.Substring(0,10)+"','dd/mm/yy') and to_date('"+den.Substring(0,10)+"','dd/mm/yy')").Tables[0];
						if (dt.Rows[0]["sotien"].ToString()!="") sotien+=decimal.Parse(dt.Rows[0]["sotien"].ToString());
					}
				}
				/*if (v.bYy(i.ToString().Substring(2,2)))
				{
					dt=v.get_data("select sum(soluong*(dongia+vattu)) sotien from v_vpkhoa where maql="+maql+" and to_date(ngay,'dd/mm/yy') between to_date('"+tu.Substring(0,10)+"','dd/mm/yy') and to_date('"+den.Substring(0,10)+"','dd/mm/yy')").Tables[0];
					if (dt.Rows[0]["sotien"].ToString()!="") sotien+=decimal.Parse(dt.Rows[0]["sotien"].ToString());
				}*/
			}
			return sotien;
		}

		private void chkmaicd_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (chkmaicd.Checked)
			{
				if (MessageBox.Show(lan.Change_language_MessageText("Có muốn chọn lại danh sách ICD10 không ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					frmDmbcicd f=new frmDmbcicd(m);
					f.ShowDialog();
				}
			}		
		}
	}
}
