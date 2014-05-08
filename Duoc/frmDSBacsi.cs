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
	/// Summary description for rptBhyt.
	/// </summary>
	public class frmDSBacsi : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,i_userid=0;
		private string sql,s_quay,user,xxx,stime;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dtquay=new System.Data.DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox quay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown tyle;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butExcel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmDSBacsi(AccessData acc, int nhom, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSBacsi));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.quay = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tyle = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.butExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tyle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(169, 208);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(135, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.Print1;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(29, 208);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 4;
            this.butXem.Text = "     &In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(65, 5);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(177, 5);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // quay
            // 
            this.quay.CheckOnClick = true;
            this.quay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quay.Location = new System.Drawing.Point(65, 28);
            this.quay.Name = "quay";
            this.quay.Size = new System.Drawing.Size(192, 148);
            this.quay.TabIndex = 2;
            this.quay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-9, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Trích thưởng :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tyle
            // 
            this.tyle.Location = new System.Drawing.Point(65, 178);
            this.tyle.Name = "tyle";
            this.tyle.Size = new System.Drawing.Size(167, 20);
            this.tyle.TabIndex = 3;
            this.tyle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(237, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "%";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butExcel
            // 
            this.butExcel.Image = global::Duoc.Properties.Resources.Export;
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(99, 208);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 5;
            this.butExcel.Text = "     &Excel";
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            // 
            // frmDSBacsi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(266, 247);
            this.Controls.Add(this.butExcel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.quay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDSBacsi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu theo bác sĩ";
            this.Load += new System.EventHandler(this.frmDSBacsi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tyle)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDSBacsi_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			dsxml.ReadXml("..\\..\\..\\xml\\d_dsbacsi.xml");
			sql="select * from "+user+".dmbs order by ma";
			dtquay=d.get_data(sql).Tables[0];
            quay.DataSource = dtquay;
			quay.DisplayMember="HOTEN";
			quay.ValueMember="MA";
			
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			print(true);
		}	

		private void print(bool prn)
		{
			s_quay="'";
			if (quay.CheckedItems.Count>0) 
				for(int i=0;i<quay.Items.Count;i++)	if (quay.GetItemChecked(i)) s_quay+=dtquay.Rows[i]["ma"].ToString()+"','";
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden,be=0;
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
						sql=" select a.mabs,sum(b.soluong*b.giaban) as sotien";
						sql+=" from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b ";
						sql+=" where a.id=b.id";
						if(s_quay.Length>1) sql+=" and a.mabs in ("+s_quay.Substring(0,s_quay.Length-2)+")";
						sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						sql+=" group by a.mabs";
						if (be==0) ds=d.get_data(sql);
						else ds.Merge(d.get_data(sql));
						be++;
					}
				}
			}
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
			else
			{
				dsxml.Clear();
				DataRow [] dr;
				DataRow r1,r2,r3;
				decimal tc=0;
				foreach(DataRow r in ds.Tables[0].Select("sotien>0","mabs"))
				{
					sql="mabs='"+r["mabs"].ToString()+"'";
					r1=d.getrowbyid(dsxml.Tables[0],sql);
					if (r1==null)
					{
						r3=d.getrowbyid(dtquay,"ma='"+r["mabs"].ToString()+"'");
						if (r3!=null)
						{
							r2=dsxml.Tables[0].NewRow();
							r2["mabs"]=r["mabs"].ToString();
							r2["hoten"]=r3["hoten"].ToString();
							r2["sotien"]=r["sotien"].ToString();
							r2["tenkp"]="";
							r2["trichthuong"]=0;//decimal.Parse(r["sotien"].ToString())*(tyle.Value/100);
							dsxml.Tables[0].Rows.Add(r2);
						}
					}
					else
					{
						dr=dsxml.Tables[0].Select(sql);
						if (dr.Length>0)
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
					}
					tc+=decimal.Parse(r["sotien"].ToString());
				}	
				foreach(DataRow r in dsxml.Tables[0].Rows)
					r["trichthuong"]=decimal.Parse(r["sotien"].ToString())*(tyle.Value/100);
				doiso.Doisototext dd=new doiso.Doisototext();
				if (prn)
				{
					frmReport f1=new frmReport(d,dsxml.Tables[0],i_userid,"d_dsbacsi.rpt","",s_title,"","","","","","","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
					f1.ShowDialog(this);
				}
				else
				{
					d.check_process_Excel();
					string tenfile=d.Export_Excel(dsxml,"bacsi");
					oxl=new Excel.Application();
					owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
					osheet=(Excel._Worksheet)owb.ActiveSheet;
					oxl.ActiveWindow.DisplayGridlines=true;
					oxl.ActiveWindow.DisplayZeros=false;
					osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
					osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
					osheet.PageSetup.LeftMargin=20;
					osheet.PageSetup.RightMargin=20;
					osheet.PageSetup.TopMargin=30;
					osheet.PageSetup.CenterFooter="Trang : &P/&N";
					oxl.Visible=true;
				}
			}
		}

		private void butExcel_Click(object sender, System.EventArgs e)
		{
			print(false);		
		}	
	}
}
