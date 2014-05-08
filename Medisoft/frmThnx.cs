using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using System.Runtime.InteropServices;
using System.Reflection;
using Excel;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmTktresosinh.
	/// </summary>
	public class frmThnx : System.Windows.Forms.Form
	{
        Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData m=new LibDuoc.AccessData();
		private LibMedi.AccessData b=new LibMedi.AccessData();
		private DataSet ds=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private string sql;
		//private ExportToExcel Excel = new ExportToExcel();
		string tenfile;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.ComboBox loaibenh;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThnx()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmThnx));
			this.label1 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.DateTimePicker();
			this.den = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.butIn = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.loaibenh = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Từ ngày :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tu
			// 
			this.tu.CustomFormat = "dd/MM/yyyy";
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tu.Location = new System.Drawing.Point(60, 24);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(80, 21);
			this.tu.TabIndex = 1;
			this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
			// 
			// den
			// 
			this.den.CustomFormat = "dd/MM/yyyy";
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.den.Location = new System.Drawing.Point(172, 24);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(80, 21);
			this.den.TabIndex = 3;
			this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(140, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "đến :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(51, 88);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 5;
			this.butIn.Text = "&In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(131, 88);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 6;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// loaibenh
			// 
			this.loaibenh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.loaibenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loaibenh.Location = new System.Drawing.Point(60, 47);
			this.loaibenh.Name = "loaibenh";
			this.loaibenh.Size = new System.Drawing.Size(188, 21);
			this.loaibenh.TabIndex = 4;
			this.loaibenh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibenh_KeyDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Loại :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmThnx
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label3,
																		  this.loaibenh,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.den,
																		  this.label2,
																		  this.tu,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmThnx";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tổng hợp tình hình nhập xuất";
			this.Load += new System.EventHandler(this.frmThthbn_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}
																			
		private void butIn_Click(object sender, System.EventArgs e)
		{
			string sql1="",sql2="";
			int loai;
			ds.Clear();
			ds.ReadXml("..\\..\\..\\xml\\thnx.xml");
			foreach(DataColumn c in ds.Tables[0].Columns) c.DefaultValue=0;
			if(loaibenh.SelectedIndex<0)
			{
				loai=-1;
				sql="select to_char(ngay,'dd/mm/yyyy') ngay,count(*) ts,sum(decode(a.phai,0,1,0)) nu,sum(decode(a.mann,'07',1,0)) cb,sum(decode(a.mann,'04',1,0)) cn,";
				sql+="sum(decode(a.mann,'01',1,0)) te,sum(decode(a.mann,'04',0,'01',0,'07',0,1)) nd,sum(decode(b.makp,'02',1,0)) a,";
				sql+="sum(decode(b.makp,'03',1,0)) b,sum(decode(b.makp,'04',1,0)) c,sum(decode(b.makp,'05',1,0)) d,sum(decode(b.makp,'06',1,0)) e,";
				sql+="sum(decode(b.makp,'07',1,0)) x1,sum(decode(b.makp,'08',1,0)) x2,sum(decode(b.makp,'09',1,0)) x3,sum(decode(b.makp,'10',1,0)) hc,sum(decode(b.makp,'20',1,0)) vl";
				sql+=" from btdbn a,nhapkhoa b where a.mabn=b.mabn and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy') ";
				sql+="group by to_char(ngay,'dd/mm/yyyy') order by substr(ngay,7)||substr(ngay,4,2)||substr(ngay,1,2)";

				sql1="select to_char(ngay,'dd/mm/yyyy') ngay,count(*) ts,sum(decode(a.phai,0,1,0)) nu,sum(decode(a.mann,'07',1,0)) cb,sum(decode(a.mann,'04',1,0)) cn,";
				sql1+="sum(decode(a.mann,'01',1,0)) te,sum(decode(a.mann,'04',0,'01',0,'07',0,1)) nd,sum(decode(c.makp,'02',1,0)) a,";
				sql1+="sum(decode(c.makp,'03',1,0)) b,sum(decode(c.makp,'04',1,0)) c,sum(decode(c.makp,'05',1,0)) d,sum(decode(c.makp,'06',1,0)) e,";
				sql1+="sum(decode(c.makp,'07',1,0)) x1,sum(decode(c.makp,'08',1,0)) x2,sum(decode(c.makp,'09',1,0)) x3,sum(decode(c.makp,'10',1,0)) hc,sum(decode(c.makp,'20',1,0)) vl";
				sql1+=" from btdbn a,xuatkhoa b,nhapkhoa c,benhandt d where a.mabn=c.mabn and c.maql=d.maql and b.id=c.id and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy') ";
				sql1+="group by to_char(ngay,'dd/mm/yyyy') order by substr(ngay,7)||substr(ngay,4,2)||substr(ngay,1,2)";

				sql2="select count(*) ts,sum(decode(a.phai,0,1,0)) nu,sum(decode(a.mann,'07',1,0)) cb,sum(decode(a.mann,'04',1,0)) cn,";
				sql2+="sum(decode(a.mann,'01',1,0)) te,sum(decode(a.mann,'04',0,'01',0,'07',0,1)) nd,sum(decode(c.makp,'02',1,0)) a,";
				sql2+="sum(decode(c.makp,'03',1,0)) b,sum(decode(c.makp,'04',1,0)) c,sum(decode(c.makp,'05',1,0)) d,sum(decode(c.makp,'06',1,0)) e,";
				sql2+="sum(decode(c.makp,'07',1,0)) x1,sum(decode(c.makp,'08',1,0)) x2,sum(decode(c.makp,'09',1,0)) x3,sum(decode(c.makp,'10',1,0)) hc,sum(decode(c.makp,'20',1,0)) vl";
				sql2+=" from nhapkhoa c,btdbn a,xuatkhoa b where c.id=b.id(+) and a.mabn=c.mabn ";
				sql2+=" and to_date(c.ngay,'dd/mm/yy')<to_date('"+tu.Text+"','dd/mm/yy') and (b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+tu.Text+"','dd/mm/yy'))";
			}
			else
			{
				loai=int.Parse(loaibenh.SelectedValue.ToString());
				sql="select to_char(b.ngay,'dd/mm/yyyy') ngay,count(*) ts,sum(decode(a.phai,0,1,0)) nu,sum(decode(a.mann,'07',1,0)) cb,sum(decode(a.mann,'04',1,0)) cn,";
				sql+="sum(decode(a.mann,'01',1,0)) te,sum(decode(a.mann,'04',0,'01',0,'07',0,1)) nd,sum(decode(b.makp,'02',1,0)) a,";
				sql+="sum(decode(b.makp,'03',1,0)) b,sum(decode(b.makp,'04',1,0)) c,sum(decode(b.makp,'05',1,0)) d,sum(decode(b.makp,'06',1,0)) e,";
				sql+="sum(decode(b.makp,'07',1,0)) x1,sum(decode(b.makp,'08',1,0)) x2,sum(decode(b.makp,'09',1,0)) x3,sum(decode(b.makp,'10',1,0)) hc,sum(decode(b.makp,'20',1,0)) vl";
				sql+=" from btdbn a,nhapkhoa b,benhandt c where a.mabn=b.mabn and b.maql=c.maql and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy') and loaiba="+loai;
				sql+=" group by to_char(b.ngay,'dd/mm/yyyy') order by substr(ngay,7)||substr(ngay,4,2)||substr(ngay,1,2)";

				sql1="select to_char(b.ngay,'dd/mm/yyyy') ngay,count(*) ts,sum(decode(a.phai,0,1,0)) nu,sum(decode(a.mann,'07',1,0)) cb,sum(decode(a.mann,'04',1,0)) cn,";
				sql1+="sum(decode(a.mann,'01',1,0)) te,sum(decode(a.mann,'04',0,'01',0,'07',0,1)) nd,sum(decode(c.makp,'02',1,0)) a,";
				sql1+="sum(decode(c.makp,'03',1,0)) b,sum(decode(c.makp,'04',1,0)) c,sum(decode(c.makp,'05',1,0)) d,sum(decode(c.makp,'06',1,0)) e,";
				sql1+="sum(decode(c.makp,'07',1,0)) x1,sum(decode(c.makp,'08',1,0)) x2,sum(decode(c.makp,'09',1,0)) x3,sum(decode(c.makp,'10',1,0)) hc,sum(decode(c.makp,'20',1,0)) vl";
				sql1+=" from btdbn a,xuatkhoa b,nhapkhoa c,benhandt d where a.mabn=c.mabn and c.maql=d.maql and to_date(b.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy') and b.id=c.id and loaiba="+loai;
				sql1+=" group by to_char(b.ngay,'dd/mm/yyyy') order by substr(ngay,7)||substr(ngay,4,2)||substr(ngay,1,2)";

				sql2="select count(*) ts,sum(decode(a.phai,0,1,0)) nu,sum(decode(a.mann,'07',1,0)) cb,sum(decode(a.mann,'04',1,0)) cn,";
				sql2+="sum(decode(a.mann,'01',1,0)) te,sum(decode(a.mann,'04',0,'01',0,'07',0,1)) nd,sum(decode(c.makp,'02',1,0)) a,";
				sql2+="sum(decode(c.makp,'03',1,0)) b,sum(decode(c.makp,'04',1,0)) c,sum(decode(c.makp,'05',1,0)) d,sum(decode(c.makp,'06',1,0)) e,";
				sql2+="sum(decode(c.makp,'07',1,0)) x1,sum(decode(c.makp,'08',1,0)) x2,sum(decode(c.makp,'09',1,0)) x3,sum(decode(c.makp,'10',1,0)) hc,sum(decode(c.makp,'20',1,0)) vl";
				sql2+=" from nhapkhoa c,btdbn a,xuatkhoa b,benhandt d where c.id=b.id(+) and a.mabn=c.mabn and c.maql=d.maql and loaiba="+loai;
				sql2+=" and to_date(c.ngay,'dd/mm/yy')<to_date('"+tu.Text+"','dd/mm/yy') and (b.ngay is null or to_date(b.ngay,'dd/mm/yy')>to_date('"+tu.Text+"','dd/mm/yy'))";
			}
			
			System.Data.DataTable dtdk=new System.Data.DataTable();//dau ky
			dtdk=m.get_data(sql2).Tables[0];

			dt=m.get_data(sql1).Tables[0];
			DataRow r1,r2,rdk;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1 = ds.Tables[0].NewRow();
				r1[0] = r["ngay"].ToString();
				r1[1] = Decimal.Parse(r["ts"].ToString());
				r1[2] = Decimal.Parse(r["nu"].ToString());
				r1[3] = Decimal.Parse(r["cb"].ToString());
				r1[4] = Decimal.Parse(r["cn"].ToString());
				r1[5] = Decimal.Parse(r["nd"].ToString());
				r1[6] = Decimal.Parse(r["te"].ToString());
				r1[7] = Decimal.Parse(r["a"].ToString());
				r1[8] = Decimal.Parse(r["b"].ToString());
				r1[9] = Decimal.Parse(r["c"].ToString());
				r1[10] = Decimal.Parse(r["d"].ToString());
				r1[11] = Decimal.Parse(r["e"].ToString());
				r1[12] = Decimal.Parse(r["x1"].ToString());
				r1[13] = Decimal.Parse(r["x2"].ToString());
				r1[14] = Decimal.Parse(r["x3"].ToString());
				r1[15] = Decimal.Parse(r["hc"].ToString());
				r1[16] = Decimal.Parse(r["vl"].ToString());

				r2=m.getrowbyid(dt,"ngay='"+r["ngay"].ToString()+"'");
				if(r2!=null)
				{
					r1[17] = Decimal.Parse(r2["ts"].ToString());
					r1[18] = Decimal.Parse(r2["nu"].ToString());
					r1[19] = Decimal.Parse(r2["cb"].ToString());
					r1[20] = Decimal.Parse(r2["cn"].ToString());
					r1[21] = Decimal.Parse(r2["nd"].ToString());
					r1[22] = Decimal.Parse(r2["te"].ToString());
					r1[23] = Decimal.Parse(r2["a"].ToString());
					r1[24] = Decimal.Parse(r2["b"].ToString());
					r1[25] = Decimal.Parse(r2["c"].ToString());
					r1[26] = Decimal.Parse(r2["d"].ToString());
					r1[27] = Decimal.Parse(r2["e"].ToString());
					r1[28] = Decimal.Parse(r2["x1"].ToString());
					r1[29] = Decimal.Parse(r2["x2"].ToString());
					r1[30] = Decimal.Parse(r2["x3"].ToString());
					r1[31] = Decimal.Parse(r2["hc"].ToString());
					r1[32] = Decimal.Parse(r2["vl"].ToString());					
				}
				//dau ky + nhap - xuat
				rdk=dtdk.Rows[0];
				//rdk["nl"]=Decimal.Parse(rdk["ts"].ToString())+Decimal.Parse(r1["v_ts"].ToString())-Decimal.Parse(r1["r_ts"].ToString())-(Decimal.Parse(rdk["te"].ToString())+Decimal.Parse(r1["v_te"].ToString())-Decimal.Parse(r1["r_te"].ToString()));
				rdk["nu"]=Decimal.Parse(rdk["nu"].ToString())+Decimal.Parse(r1["v_nu"].ToString())-Decimal.Parse(r1["r_nu"].ToString());
				rdk["cb"]=Decimal.Parse(rdk["cb"].ToString())+Decimal.Parse(r1["v_cb"].ToString())-Decimal.Parse(r1["r_cb"].ToString());
				rdk["cn"]=Decimal.Parse(rdk["cn"].ToString())+Decimal.Parse(r1["v_cn"].ToString())-Decimal.Parse(r1["r_cn"].ToString());
				rdk["nd"]=Decimal.Parse(rdk["nd"].ToString())+Decimal.Parse(r1["v_nd"].ToString())-Decimal.Parse(r1["r_nd"].ToString());
				rdk["te"]=Decimal.Parse(rdk["te"].ToString())+Decimal.Parse(r1["v_te"].ToString())-Decimal.Parse(r1["r_te"].ToString());
				rdk["a"]=Decimal.Parse(rdk["a"].ToString())+Decimal.Parse(r1["v_a"].ToString())-Decimal.Parse(r1["r_a"].ToString());
				rdk["b"]=Decimal.Parse(rdk["b"].ToString())+Decimal.Parse(r1["v_b"].ToString())-Decimal.Parse(r1["r_b"].ToString());
				rdk["c"]=Decimal.Parse(rdk["c"].ToString())+Decimal.Parse(r1["v_c"].ToString())-Decimal.Parse(r1["r_c"].ToString());
				rdk["d"]=Decimal.Parse(rdk["d"].ToString())+Decimal.Parse(r1["v_d"].ToString())-Decimal.Parse(r1["r_d"].ToString());
				rdk["e"]=Decimal.Parse(rdk["e"].ToString())+Decimal.Parse(r1["v_e"].ToString())-Decimal.Parse(r1["r_e"].ToString());
				rdk["x1"]=Decimal.Parse(rdk["x1"].ToString())+Decimal.Parse(r1["v_1"].ToString())-Decimal.Parse(r1["r_1"].ToString());
				rdk["x2"]=Decimal.Parse(rdk["x2"].ToString())+Decimal.Parse(r1["v_2"].ToString())-Decimal.Parse(r1["r_2"].ToString());
				rdk["x3"]=Decimal.Parse(rdk["x3"].ToString())+Decimal.Parse(r1["v_3"].ToString())-Decimal.Parse(r1["r_3"].ToString());
				rdk["hc"]=Decimal.Parse(rdk["hc"].ToString())+Decimal.Parse(r1["v_hc"].ToString())-Decimal.Parse(r1["r_hc"].ToString());
				rdk["vl"]=Decimal.Parse(rdk["vl"].ToString())+Decimal.Parse(r1["v_vl"].ToString())-Decimal.Parse(r1["r_vl"].ToString());
				rdk["ts"]=Decimal.Parse(rdk["ts"].ToString())+Decimal.Parse(r1["v_ts"].ToString())-Decimal.Parse(r1["r_ts"].ToString());

				r1[33]=Decimal.Parse(rdk["ts"].ToString())-Decimal.Parse(rdk["te"].ToString());
				r1[34]=rdk["nu"];
				r1[35]=rdk["cb"];
				r1[36]=rdk["cn"];
				r1[37]=rdk["nd"];
				r1[38]=rdk["te"];
				r1[39]=rdk["a"];
				r1[40]=rdk["b"];
				r1[41]=rdk["c"];
				r1[42]=rdk["d"];
				r1[43]=rdk["e"];
				r1[44]=rdk["x1"];
				r1[45]=rdk["x2"];
				r1[46]=rdk["x3"];
				r1[47]=rdk["hc"];
				r1[48]=rdk["vl"];
				r1[49]=rdk["ts"];
				ds.Tables[0].Rows.Add(r1);
			}
			try
			{
				if (ds.Tables[0].Rows.Count==0)
				{
					MessageBox.Show("Không có số liệu !");
					return;
				}
				else
				{
					string title="Từ ngày "+tu.Text+" Đến ngày "+den.Text;
					if (tu.Text==den.Text) title="Ngày "+tu.Text;
//					ds.WriteXml("rthnx.xml");
					exp_excel(false);
				}
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmThthbn_Load(object sender, System.EventArgs e)
		{
			DataSet ds1=new DataSet();
			ds1.ReadXml("..\\..\\..\\xml\\loaibn.xml");
			loaibenh.DisplayMember="LOAIBN";
			loaibenh.ValueMember="ID";
			loaibenh.DataSource=ds1.Tables[0];
		}
		private void exp_excel(bool print)
		{
			try
			{
				string loai=loaibenh.Text!=""?"("+loaibenh.Text.ToUpper()+")":"";
				int be=5,dong=4,sodong=ds.Tables[0].Rows.Count+1,socot=ds.Tables[0].Columns.Count+1,dongke=sodong-1;
				tenfile=m.Export_Excel(ds,"bcngay");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				osheet.get_Range(b.getIndex(0)+"1",b.getIndex(0)+"1").EntireRow.Delete(Missing.Value);
				for(int i=0;i<be;i++) osheet.get_Range(b.getIndex(i)+"1",b.getIndex(i)+"1").EntireRow.Insert(Missing.Value);

				osheet.get_Range(b.getIndex(1)+dong.ToString(),b.getIndex(socot-2)+(dong+sodong+1).ToString()).NumberFormat="#,##";
				osheet.get_Range(b.getIndex(0)+dong.ToString(),b.getIndex(socot-2)+(dong+dongke+1).ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;

				osheet.get_Range(b.getIndex(0)+(dong+1),b.getIndex(0)+dong).Merge(Missing.Value);
				osheet.get_Range(b.getIndex(0)+(dong+1),b.getIndex(0)+dong).VerticalAlignment=XlVAlign.xlVAlignCenter;	
				osheet.get_Range(b.getIndex(1)+dong,b.getIndex(16)+dong).Merge(Missing.Value);
				osheet.get_Range(b.getIndex(1)+dong,b.getIndex(16)+dong).HorizontalAlignment=XlHAlign.xlHAlignCenter;
				osheet.get_Range(b.getIndex(17)+dong,b.getIndex(32)+dong).Merge(Missing.Value);
				osheet.get_Range(b.getIndex(17)+dong,b.getIndex(32)+dong).HorizontalAlignment=XlHAlign.xlHAlignCenter;
				osheet.get_Range(b.getIndex(33)+dong,b.getIndex(48)+dong).Merge(Missing.Value);
				osheet.get_Range(b.getIndex(33)+dong,b.getIndex(48)+dong).HorizontalAlignment=XlHAlign.xlHAlignCenter;
				osheet.get_Range(b.getIndex(49)+(dong+1),b.getIndex(49)+dong).Merge(Missing.Value);

				osheet.Cells[dong,1]=get_tenhead(0);
				osheet.Cells[dong,2]=get_tenhead(1);
				osheet.Cells[dong,18]=get_tenhead(2);
				osheet.Cells[dong,34]=get_tenhead(3);
				osheet.Cells[dong,50]=get_tenhead(4);
				for(int i=1;i<socot;i++) 
				{
					osheet.Cells[dong+1,i]=get_ten(i-1);
				}

				orange=osheet.get_Range(b.getIndex(0)+"1",b.getIndex(socot-1)+(dong+sodong).ToString());
				osheet.get_Range(b.getIndex(1)+(dong+1),b.getIndex(socot-3)+(dong+1)).Orientation=90;
				osheet.get_Range(b.getIndex(1)+(dong+1),b.getIndex(socot-2)+(dong+1)).RowHeight=50;
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
				osheet.Cells[1,1]=b.Syte;osheet.Cells[2,1]=b.Tenbv;
				osheet.Cells[1,4]="TÌNH HÌNH BỆNH NHÂN NHẬP XUẤT"+loai;
				osheet.Cells[2,4]=(tu.Text==den.Text)?"Ngày : "+tu.Text:"Từ ngày : "+tu.Text+" đến : "+den.Text;
				orange=osheet.get_Range(b.getIndex(3)+"1",b.getIndex(socot-1)+"2");
//				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
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
			string []map={"Ngày","T số","Nữ","Cán bộ","Công nhân","Nhân dân","Trẻ em","A","B","C","D","E","Xạ 1","Xạ 2","Xạ 3","Hoá chất","TTVL","T số","Nữ","Cán bộ","Công nhân","Nhân dân","Trẻ em","A","B","C","D","E","Xạ 1","Xạ 2","Xạ 3","Hoá chất","TTVL","Người lớn","Nữ","Cán bộ","Công nhân","Nhân dân","Trẻ em","A","B","C","D","E","Xạ 1","Xạ 2","Xạ 3","Hoá chất","TTVL","Tổng số chung"};
			return map[i];
		}
		private string get_tenhead(int i)
		{
			string []map={"Ngày","Vào","Ra","Tổng số chung","Tổng số chung"};
			return map[i];
		}

		private void loaibenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}
	}
}
