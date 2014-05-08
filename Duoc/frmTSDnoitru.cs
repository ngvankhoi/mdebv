using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptNxt_tonghop.
	/// </summary>
	public class frmTSDnoitru : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,stt;
		private string sql,s_mmyy,tenfile,s_kho;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds=new DataSet();
		private DataSet dsxml;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTSDnoitru(AccessData acc,int nhom,string mmyy,string _kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;s_kho=_kho;
			i_nhom=nhom;
			s_mmyy=mmyy;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTSDnoitru));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(60, 93);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(72, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(132, 93);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kho :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(50, 35);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(190, 21);
            this.makho.TabIndex = 2;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(50, 59);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(190, 21);
            this.manguon.TabIndex = 3;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(160, 11);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(50, 11);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(120, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "đến :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTSDnoitru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(250, 142);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTSDnoitru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo xuât kho";
            this.Load += new System.EventHandler(this.frmTSDnoitru_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmTSDnoitru_Load(object sender, System.EventArgs e)
		{
			sql="select a.*, b.stt sttnhom, b.ten tennhom,c.ten tennx,d.ten tenhang,e.ten tennuoc from d_dmbd a, d_dmnhom b,d_dmnx c,d_dmhang d,d_dmnuoc e";
			sql+=" where a.manhom=b.id and a.madv=c.id(+) and a.mahang=d.id and a.manuoc=e.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from d_dmnguon where id=0 or nhom="+i_nhom+" order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtdmkho;
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_nt.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
		}

		private string get_ten(int i)
		{
			string []map={"TT","Tên hoạt chất","Tên thuốc - hàm lượng","ĐVT","Tên hãng","Nước sản xuất","Công ty phân phối","Số lượng"};
			return map[i];
		}

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
			int be=2,dong=4,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
			tenfile=d.Export_Excel(ds,"cosotutruc");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			
			for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(be-1)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.00";
			osheet.get_Range(d.getIndex(0)+"3",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			for(int i=0;i<8;i++)
				osheet.Cells[dong-1,i+1]=get_ten(i);
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=8;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";

			osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
			osheet.Cells[1,4]="BÁO CÁO SỬ DỤNG NỘI TRÚ";
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			osheet.Cells[2,4]=s_title;
			orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange.Font.Size=12;
			orange.Font.Bold=true;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void get_sort()
		{
            dsxml=new DataSet();
			dsxml.ReadXml("..\\..\\..\\xml\\d_xuat_nt.xml");
			dsxml.Merge(ds.Tables[0].Select("soluong>0","ten"));
			stt=1;
			foreach(DataRow r in dsxml.Tables[0].Rows) r["stt"]=stt++;
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("ma");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void get_data()
		{
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			stt=1;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					s_mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(s_mmyy)) items_xuat();
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			exp_excel(false);
		}

		private void items_xuat()
		{
			foreach(DataRow r in get_xuat(" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=stt.ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tennuoc"]=r2["tennuoc"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tendv"]=r2["tennx"].ToString();
						r3["soluong"]=decimal.Parse(r["soluong"].ToString());
						ds.Tables[0].Rows.Add(r3);
						stt++;
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
		}

		private DataSet get_xuat(string cont)
		{
			sql=" select b.mabd,sum(b.soluong) soluong from d_xuatsdll a,d_thucxuat b,"+d.user+".d_dmbd c";
			sql+=" where a.id=b.id and b.mabd=c.id and a.loai<>3 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			sql+=" union all ";
			sql+=" select b.mabd,-sum(b.soluong) soluong from d_xuatsdll a,d_thucxuat b,"+d.user+".d_dmbd c";
			sql+=" where a.id=b.id and b.mabd=c.id and a.loai=3 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			sql+=" union all ";
			sql+=" select b.mabd,sum(b.soluong) soluong from d_xuatll a,d_xuatct b,"+d.user+".d_dmbd c";
			sql+=" where a.id=b.id and b.mabd=c.id and a.loai in ('BS','XK','CK')";
			if (makho.SelectedIndex!=-1) sql+=" and a.khox="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			sql+=" union all ";
			sql+=" select b.mabd,sum(b.soluong) soluong from d_ngtrull a,d_ngtruct b,"+d.user+".d_dmbd c";
			sql+=" where a.id=b.id and b.mabd=c.id ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			sql+=" union all ";
			sql+=" select b.mabd,sum(b.soluong) soluong from bhytkb a,bhytthuoc b,"+d.user+".d_dmbd c";
			sql+=" where a.id=b.id and b.mabd=c.id ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			return d.get_data(sql);
		}
	}
}
