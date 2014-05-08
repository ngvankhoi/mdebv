using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data;
using LibDuoc;
using Excel;
namespace Medisoft
{
	/// <summary>
	/// Summary description for rptBcngay.
	/// </summary>
	public class rptBcngay : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butKetthuc;
		private DataColumn dc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_nhom;
		private string sql,tenfile,s_makp,s_manhom,user,xxx,stime;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtnhom=new System.Data.DataTable();
		private DataSet dsngay=new DataSet();
		private System.Windows.Forms.Label label4;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox dieutri;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBcngay(string _makp,int _nhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            s_makp=_makp;i_nhom=_nhom;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBcngay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dieutri = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(132, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(129, 189);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(55, 55);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 7;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Khoa :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(59, 189);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 9;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(55, 8);
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
            this.den.Location = new System.Drawing.Point(167, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(55, 79);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(192, 100);
            this.manhom.TabIndex = 8;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Điều trị :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dieutri
            // 
            this.dieutri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Items.AddRange(new object[] {
            "Nội trú",
            "Ngoại trú"});
            this.dieutri.Location = new System.Drawing.Point(55, 32);
            this.dieutri.Name = "dieutri";
            this.dieutri.Size = new System.Drawing.Size(192, 21);
            this.dieutri.TabIndex = 5;
            this.dieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptBcngay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 231);
            this.Controls.Add(this.dieutri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBcngay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sử dụng theo ngày";
            this.Load += new System.EventHandler(this.rptBcngay_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBcngay_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			dtnhom=d.get_data("select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt").Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";
            sql = "select * from " + user + ".d_duockp where makp is not null and nhom like '%" + i_nhom.ToString() + ",%'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
            makp.DataSource = dtmakp;
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
            dt = d.get_data("select * from " + user + ".d_dmbd where nhom=" + i_nhom + " order by id").Tables[0];
			dsngay.ReadXml("..//..//..//xml//d_tsngay.xml");
			dieutri.SelectedIndex=0;
		}

		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..//..//..//xml//d_bcngay.xml");
			dsngay.Clear();
			DateTime dt1=d.StringToDate(tu.Text);
			DateTime dt2=d.StringToDate(den.Text);
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
                    xxx = user + mmyy;
					if (dieutri.SelectedIndex==0)
					{
						sql="select distinct to_char(a.ngay,'yymmdd') as ngay,to_char(a.ngay,'dd/mm') as ten from "+xxx+".d_xuatsdll a,"+xxx+".d_xuatsdct b,"+user+".d_dmbd c ";
						sql+=" where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
						sql+=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString());
					}
					else
					{
						sql="select distinct to_char(a.ngay,'yymmdd') as ngay,to_char(a.ngay,'dd/mm') as ten from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+user+".d_dmbd c,"+user+".d_duockp d";
						sql+=" where a.id=b.id and b.mabd=c.id and a.makp=d.makp and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						sql+=" and a.loaiba=2";
						if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
						sql+=" and d.id="+int.Parse(makp.SelectedValue.ToString());
					}
					dr=d.get_data(sql).Tables[0].Select("ngay<>''","ngay");
					for(int k=0;k<dr.Length;k++)
					{
						r1=d.getrowbyid(dsngay.Tables[0],"ngay='"+dr[k]["ngay"].ToString()+"'");
						if ( r1 == null )
						{
							r2 = dsngay.Tables[0].NewRow();
							r2["ngay"]=dr[k]["ngay"].ToString();
							r2["ten"]=dr[k]["ten"].ToString();
							dsngay.Tables[0].Rows.Add(r2);
							dc=new DataColumn();
							dc.ColumnName="SL_"+dr[k]["ngay"].ToString().Trim();
							dc.DataType=Type.GetType("System.Decimal");
							ds.Tables[0].Columns.Add(dc);
						}
					}
				}
			}
			dc=new DataColumn();
			dc.ColumnName="TONGCONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			if (dieutri.SelectedIndex==0)
			{
				sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c ";
				sql+="where a.id=b.id and b.mabd=c.id and a.loai<>3 and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
				sql+=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString());
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				sql+=" group by a.ngay,b.mabd,c.ten order by c.ten";
			}
			else
			{
				sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+user+".d_dmbd c,"+user+".d_duockp d ";
				sql+="where a.id=b.id and b.mabd=c.id and a.makp=d.makp and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
				sql+=" and a.loaiba=2";
				sql+=" and d.id="+int.Parse(makp.SelectedValue.ToString());
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				sql+=" group by a.ngay,b.mabd,c.ten order by c.ten";
			}
			ins_items();
		}

		private void ins_items()
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dsngay.Tables[0].Rows) r2["sl_"+r4["ngay"].ToString().Trim()]=0;
						r2["sl_"+r["ngay"].ToString().Trim()]=r["soluong"].ToString();
						r2["tongcong"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["sl_"+r["ngay"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["ngay"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["tongcong"]=decimal.Parse(dr[0]["tongcong"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c ";
			sql+="where a.id=b.id and b.mabd=c.id and a.loai=3 and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			sql+=" and a.makhoa="+int.Parse(makp.SelectedValue.ToString());
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=" group by a.ngay,b.mabd,c.ten";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dsngay.Tables[0].Rows) r2["sl_"+r4["ngay"].ToString().Trim()]=0;
						r2["sl_"+r["ngay"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r2["tongcong"]=-decimal.Parse(r["soluong"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["sl_"+r["ngay"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["ngay"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["tongcong"]=decimal.Parse(dr[0]["tongcong"].ToString())-decimal.Parse(r["soluong"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}


		private void exp_excel(bool print)
		{
			try
			{
				DataSet tmp=new DataSet();
				tmp=ds.Copy();
				ds.Clear();
				ds.Merge(tmp.Tables[0].Select("true","ten,dang"));
				int k=1;
				foreach(DataRow r in ds.Tables[0].Rows) r["stt"]=k++;
				int be=3,dong=5,sodong=ds.Tables[0].Rows.Count+5,socot=ds.Tables[0].Columns.Count-2,dongke=sodong-1;
				tenfile=d.Export_Excel(ds,"bcngay");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(be)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.00";
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				for(int i=1;i<dong;i++) osheet.Cells[dong-1,i]=get_ten(i-1);
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
				osheet.Cells[dong-1,dsngay.Tables[0].Rows.Count+5]="Cộng";
				for(int i=0;i<dsngay.Tables[0].Rows.Count;i++)
					osheet.Cells[dong-1,i+5]=" "+dsngay.Tables[0].Rows[i]["ten"].ToString();
				osheet.get_Range(d.getIndex(4)+"4",d.getIndex(dsngay.Tables[0].Rows.Count+5)+"4").Orientation=90;
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(dsngay.Tables[0].Rows.Count+5)+"4").RowHeight=30;
				orange.Font.Name="Arial";
				orange.Font.Size=8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.get_Range("A5","A5").Select();
				oxl.ActiveWindow.FreezePanes = true;
				osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
				osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
				osheet.Cells[1,4]="BÁO CÁO SỬ DỤNG "+dieutri.Text.ToUpper();
				osheet.Cells[2,4]=(tu.Text==den.Text)?"Ngày : "+tu.Text:"Từ ngày : "+tu.Text+" đến : "+den.Text;
				orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
				if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private string get_ten(int i)
		{
			string []map={"TT","Mã số","Tên","ĐVT"};
			return map[i];
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			exp_excel(false);
		}

		private bool kiemtra()
		{
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++) if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString()+",";
			Tao_dataset();
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
						get_xuat(mmyy);
						if (dieutri.SelectedIndex==0) get_hoantra(mmyy);
					}
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
				return false;
			}
			return true;
		}

	}
}
