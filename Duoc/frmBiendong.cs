using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmBiendong.
	/// </summary>
	public class frmBiendong : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.CheckedListBox maloai;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,i_rec;
		private string s_nhom,s_loai,sql,s_hang,tenfile,user,stime,xxx;
		private System.Data.DataTable dtnhom=new System.Data.DataTable();
		private System.Data.DataTable dtloai=new System.Data.DataTable();
		private System.Data.DataTable dthang=new System.Data.DataTable();
		private DataSet dstyle=new DataSet();
		private DataSet ds;
		private DataColumn dc;
		private DataRow r1,r2;
		private DataRow [] dr;
		private System.Windows.Forms.CheckedListBox mahang;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBiendong(AccessData acc,int nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiendong));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.maloai = new System.Windows.Forms.CheckedListBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.mahang = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(154, 14);
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
            this.tu.Location = new System.Drawing.Point(66, 14);
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
            this.den.Location = new System.Drawing.Point(186, 14);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhóm :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phân loại :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(66, 37);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(200, 84);
            this.manhom.TabIndex = 5;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // maloai
            // 
            this.maloai.CheckOnClick = true;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(66, 122);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(200, 84);
            this.maloai.TabIndex = 7;
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(172, 218);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 9;
            this.butIn.Text = "       &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(242, 218);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // mahang
            // 
            this.mahang.CheckOnClick = true;
            this.mahang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mahang.Location = new System.Drawing.Point(270, 14);
            this.mahang.Name = "mahang";
            this.mahang.Size = new System.Drawing.Size(200, 196);
            this.mahang.TabIndex = 8;
            this.mahang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmBiendong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 261);
            this.Controls.Add(this.mahang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBiendong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biến động giá thuốc";
            this.Load += new System.EventHandler(this.frmBiendong_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void frmBiendong_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			dstyle.ReadXml("..\\..\\..\\xml\\m_tyle.xml");
			dtnhom=d.get_data("select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt").Tables[0];
            dtloai = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt").Tables[0];
            dthang = d.get_data("select * from " + user + ".d_dmhang where nhom=" + i_nhom + " order by stt").Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";
			
            maloai.DataSource = dtloai;
			maloai.DisplayMember="TEN";
			maloai.ValueMember="ID";
			
            mahang.DataSource = dthang;
			mahang.DisplayMember="TEN";
			mahang.ValueMember="ID";
			
		}

		private void Taotable()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\m_biendong.xml");
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			i_rec=0;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						sql="select distinct to_char(a.ngay,'yymmdd') as ngay ";
						sql+=" from "+xxx+".d_theodoigia a,"+user+".d_dmbd b,"+user+".d_dmhang c,"+user+".d_nhomhang d where a.mabd=b.id and b.mahang=c.id and c.loai=d.id";
						sql+=" and b.nhom="+i_nhom;
						if (s_nhom!="") sql+=" and b.manhom in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
						if (s_loai!="") sql+=" and b.maloai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
						if (s_hang!="") sql+=" and b.mahang in ("+s_hang.Substring(0,s_hang.Length-1)+")";
						sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						foreach(DataRow r in d.get_data(sql).Tables[0].Select("ngay<>''","ngay"))
						{
							try
							{
								dc=new DataColumn();
								dc.ColumnName=r["ngay"].ToString();
								dc.DataType=Type.GetType("System.Decimal");
								ds.Tables[0].Columns.Add(dc);
								i_rec++;
							}
							catch{}
						}
					}
				}
			}
			dc=new DataColumn();
			dc.ColumnName="tyle";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="ghichu";
			dc.DataType=Type.GetType("System.String");
			ds.Tables[0].Columns.Add(dc);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_nhom="";s_loai="";s_hang="";
			if (manhom.CheckedItems.Count>0)
				for(int i=0;i<manhom.Items.Count;i++) if (manhom.GetItemChecked(i)) s_nhom+=dtnhom.Rows[i]["id"].ToString().Trim()+",";
			if (maloai.CheckedItems.Count>0)
				for(int i=0;i<maloai.Items.Count;i++) if (maloai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			if (mahang.CheckedItems.Count>0)
				for(int i=0;i<mahang.Items.Count;i++) if (mahang.GetItemChecked(i)) s_hang+=dthang.Rows[i]["id"].ToString().Trim()+",";
			Taotable();

			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
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
                        xxx = user + mmyy;
						sql="select a.mabd,b.ma,b.tenhc,trim(b.ten)||' '||b.hamluong as ten,b.dang,a.dongia,to_char(a.ngay,'yymmdd') as ngay,d.ten as tenloai ";
						sql+=" from "+xxx+".d_theodoigia a,"+user+".d_dmbd b,"+user+".d_dmhang c,"+user+".d_nhomhang d where a.mabd=b.id and b.mahang=c.id and c.loai=d.id";
						sql+=" and b.nhom="+i_nhom;						
						if (s_nhom!="") sql+=" and b.manhom in ("+s_nhom.Substring(0,s_nhom.Length-1)+")";
						if (s_loai!="") sql+=" and b.maloai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
						if (s_hang!="") sql+=" and b.mahang in ("+s_hang.Substring(0,s_hang.Length-1)+")";
                        sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "',"+stime+")";
						sql+=" order by a.ngay";
						foreach(DataRow r in d.get_data(sql).Tables[0].Select("dongia>0","ten,ngay"))
						{
							r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
							if (r1==null)
							{
								r2=ds.Tables[0].NewRow();
								r2["mabd"]=r["mabd"].ToString();
								r2["ma"]=r["ma"].ToString();
								r2["tenhc"]=r["tenhc"].ToString();
								r2["ten"]=r["ten"].ToString();
								r2["dang"]=r["dang"].ToString();
								r2["tenloai"]=r["tenloai"].ToString();
								for(int k=0;k<i_rec;k++) r2[k+6]=0;
								r2[r["ngay"].ToString()]=decimal.Parse(r["dongia"].ToString());
								ds.Tables[0].Rows.Add(r2);
							}
							else
							{
								dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
								if (dr.Length>0) dr[0][r["ngay"].ToString()]=decimal.Parse(r["dongia"].ToString());
							}
							r1=d.getrowbyid(dstyle.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
							if (r1==null)
							{
								r2=dstyle.Tables[0].NewRow();
								r2["mabd"]=r["mabd"].ToString();
								r2["cu"]=decimal.Parse(r["dongia"].ToString());
								r2["moi"]=r2["cu"];
								dstyle.Tables[0].Rows.Add(r2);
							}
							else
							{
								dr=dstyle.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
								if (dr.Length>0) dr[0]["moi"]=decimal.Parse(r["dongia"].ToString());
							}
						}
					}
				}
			}
			decimal tyle;
			foreach(DataRow r in dstyle.Tables[0].Rows)
			{
				dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
				if (dr.Length>0)
				{
					tyle=Math.Round((decimal.Parse(r["moi"].ToString())-decimal.Parse(r["cu"].ToString()))/decimal.Parse(r["cu"].ToString())*100,2);
					dr[0]["tyle"]=tyle;
					dr[0]["ghichu"]=(tyle==0)?"":(tyle>0)?"Tăng":"Giảm";
				}
			}
			if (ds.Tables[0].Rows.Count>0) exp_excel();
			else MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
		}

		private void exp_excel()
		{
			try
			{
				string s;
				int be=3,dong=6,sodong=ds.Tables[0].Rows.Count+6,socot=ds.Tables[0].Columns.Count-2,dongke=sodong-2;
				tenfile=d.Export_Excel(ds,"biendong");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				osheet.Cells[dong-2,3]="Tên hoạt chất";
				osheet.Cells[dong-2,4]="Tên thuốc - hàm lượng";
				osheet.Cells[dong-2,5]="ĐVT";
				osheet.Cells[dong-2,6]="Diễn giải";
				for(int i=0;i<i_rec;i++)
				{
					s=ds.Tables[0].Columns[i+6].ColumnName.ToString();
					osheet.Cells[dong-2,i+7]="'"+s.Substring(4,2)+"/"+s.Substring(2,2)+"/"+s.Substring(0,2);
				}
				osheet.Cells[dong-2,i_rec+7]="Tỷ lệ";
				osheet.Cells[dong-2,i_rec+8]="Ghi chú";
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
				osheet.get_Range(d.getIndex(be)+dong.ToString(),d.getIndex(socot)+sodong.ToString()).NumberFormat="#,##0.00";
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot-1)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
				orange.Font.Name="Arial";
				orange.Font.Size=8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
				osheet.Cells[1,1]=d.Syte;osheet.Cells[2,1]=d.Tenbv;
				osheet.Cells[1,3]="BIẾN ĐỘNG GIÁ THUỐC";
				osheet.Cells[2,3]="Từ ngày "+tu.Text+" đến "+den.Text;
				orange=osheet.get_Range(d.getIndex(2)+"1",d.getIndex(socot-1)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
				oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
