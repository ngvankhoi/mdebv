using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptNxt_tonghop.
	/// </summary>
	public class rptXuat_khoa : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
        private int i_nhom, i_dongia, i_userid=0;
		private string user,xxx,stime,sql,s_mmyy,tenfile,s_kho,format_soluong;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private DataSet dskp;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkXml;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptXuat_khoa(LibDuoc.AccessData acc,int nhom,string mmyy,string _kho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;s_kho=_kho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptXuat_khoa));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(93, 182);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(163, 182);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(76, 26);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(200, 21);
            this.manguon.TabIndex = 5;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(165, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(76, 49);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(200, 100);
            this.makho.TabIndex = 6;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(197, 2);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(76, 2);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXml
            // 
            this.chkXml.AutoSize = true;
            this.chkXml.Location = new System.Drawing.Point(76, 155);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(85, 17);
            this.chkXml.TabIndex = 9;
            this.chkXml.Text = "Xuất ra XML";
            this.chkXml.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 255);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.manguon);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkXml);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.makho);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(316, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xuất kho theo ngày";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(316, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(310, 223);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // rptXuat_khoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(324, 255);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptXuat_khoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo xuất kho theo ngày";
            this.Load += new System.EventHandler(this.rptXuat_khoa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptXuat_khoa_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			i_dongia=d.d_dongia_le(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
            sql = "select a.*, b.stt as sttnhom, b.ten as tennhom from " + user + ".d_dmbd a, " + user + ".d_dmnhom b";
			sql+=" where a.manhom=b.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtdmkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
		}

		private string get_ten(int i)
		{
			string []map={"TT","Tên thuốc - hàm lượng","ĐVT","Hoàn trả","Ngoại trú","Trẻ em","Khác","Nội trú"};
			return map[i];
		}

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
			int k=9,dong=1,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong;
			tenfile=d.Export_Excel(ds,"BCXUATKHO");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;		
			osheet.get_Range(d.getIndex(1)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat=format_soluong;
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			for(int i=0;i<8;i++) osheet.Cells[dong,i+1]=get_ten(i);
			foreach(DataRow r in dskp.Tables[0].Select("true","mabd"))	osheet.Cells[dong,k++]=r["ma"].ToString();
			osheet.Cells[dong,k]="Tổng cộng";
			osheet.get_Range(d.getIndex(8)+"2",d.getIndex(socot-1)+dongke.ToString()).Font.ColorIndex=5;
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=10;
			orange.EntireColumn.AutoFit();
			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";
			string s_title="Từ ngày "+tu.Text+" đến "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			osheet.PageSetup.LeftHeader = d.Syte+"\n"+d.Tenbv;
			osheet.PageSetup.CenterHeader = "&\"Arial,Bold\"&14BÁO CÁO XUẤT KHO\n"+s_title;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void tao_table()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
			dskp=new DataSet();
			dskp.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			DataRow r1,r2;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					s_mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(s_mmyy))
					{
                        xxx = user + s_mmyy;
                        sql = "select distinct a.makp,c.ten from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_duockp c where a.id=b.id and a.makp=c.id";
						sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						sql+=" and a.loai<>3 and a.nhom="+i_nhom;
						if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
						sql+=" union all ";
						sql+="select distinct a.makp,c.ten from "+xxx+".d_xuatsdll a,"+xxx+".d_thucbucstt b,"+user+".d_duockp c where a.id=b.id and a.makp=c.id";
						sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						sql+=" and a.loai=2 and a.nhom="+i_nhom;
						if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
						foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
						{
							r1=d.getrowbyid(dskp.Tables[0],"mabd="+int.Parse(r["makp"].ToString()));
							if (r1==null)
							{
								r2=dskp.Tables[0].NewRow();
								r2["mabd"]=r["makp"].ToString();
								r2["ma"]=r["ten"].ToString();
								dskp.Tables[0].Rows.Add(r2);
							}
						}
					}
				}
			}
			dc=new DataColumn();
			dc.ColumnName="hoantra";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="ngoaitru";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="treem";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="khac";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="noitru";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			foreach(DataRow r in dskp.Tables[0].Select("true","mabd"))
			{
				dc=new DataColumn();
				dc.ColumnName="sl_"+r["mabd"].ToString().PadLeft(3,'0');
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="tongcong";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
		}

		private void get_sort()
		{
			dsxml=ds.Copy();
			dsxml.Clear();
			int stt=0,tt=1;
			sql="stt,ten";
			DataRow []dr=ds.Tables[0].Select("ma<>''",sql);
			for(int i=0;i<dr.Length;i++)
			{
				if (stt!=int.Parse(dr[i]["stt"].ToString()))
				{
					stt=int.Parse(dr[i]["stt"].ToString());
					r2 = dsxml.Tables[0].NewRow();
					r2["stt"]=0;
					r2["ten"]=dr[i]["tennhom"].ToString().ToUpper();
					r2["dang"]="";
					foreach(DataRow r in dskp.Tables[0].Select("true","mabd"))
						r2["sl_"+r["mabd"].ToString().PadLeft(3,'0')]=0;
					r2["hoantra"]=0;
					r2["ngoaitru"]=0;
					r2["treem"]=0;
					r2["khac"]=0;
					r2["noitru"]=0;
					r2["tongcong"]=0;
					dsxml.Tables[0].Rows.Add(r2);
				}
				r2 = dsxml.Tables[0].NewRow();
				r2["manhom"]=dr[i]["manhom"].ToString();
				r2["tennhom"]=dr[i]["tennhom"].ToString();
				r2["mabd"]=dr[i]["mabd"].ToString();
				r2["ma"]=dr[i]["ma"].ToString();
				r2["ten"]=dr[i]["ten"].ToString();
				r2["tenhc"]=dr[i]["tenhc"].ToString();
				r2["dang"]=dr[i]["dang"].ToString();
				r2["stt"]=tt;
				r2["hoantra"]=dr[i]["hoantra"].ToString();
				r2["ngoaitru"]=dr[i]["ngoaitru"].ToString();
				r2["treem"]=dr[i]["treem"].ToString();
				r2["khac"]=dr[i]["khac"].ToString();
				r2["noitru"]=0;
				foreach(DataRow r in dskp.Tables[0].Select("true","mabd"))
				{
					r2["sl_"+r["mabd"].ToString().PadLeft(3,'0')]=dr[i]["sl_"+r["mabd"].ToString().PadLeft(3,'0')].ToString();
					r2["noitru"]=decimal.Parse(r2["noitru"].ToString())+decimal.Parse(dr[i]["sl_"+r["mabd"].ToString().PadLeft(3,'0')].ToString());
				}
				r2["tongcong"]=decimal.Parse(r2["noitru"].ToString())+decimal.Parse(r2["ngoaitru"].ToString())+decimal.Parse(r2["treem"].ToString())+decimal.Parse(r2["khac"].ToString())-decimal.Parse(r2["hoantra"].ToString());
				dsxml.Tables[0].Rows.Add(r2);
				tt++;
			}
			dsxml.Tables[0].Columns.Remove("dongia");
			dsxml.Tables[0].Columns.Remove("manhom");
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("ma");
			dsxml.Tables[0].Columns.Remove("tenhc");
			dsxml.Tables[0].Columns.Remove("manguon");
			dsxml.Tables[0].Columns.Remove("tennhom");
			dsxml.Tables[0].Columns.Remove("noingoai");
			dsxml.Tables[0].Columns.Remove("idnn");
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
			s_kho="";
			if (makho.CheckedItems.Count==0)
				for(int i=0;i<makho.Items.Count;i++) makho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString().Trim()+",";
			tao_table();
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					s_mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(s_mmyy)) items_xuat(s_mmyy);
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\baocaoxuatkho.xml", XmlWriteMode.WriteSchema);
            }
            if (System.IO.File.Exists("..\\..\\..\\report\\d_baocaoxuatkho.rpt"))
            {
                string s_title = "Từ ngày " + tu.Text + " đến " + den.Text;
                if (tu.Text == den.Text) s_title = "Ngày " + tu.Text;
                frmReport f = new frmReport(d, dsxml.Tables[0], i_userid,"d_baocaoxuatkho.rpt",s_title,"","","","","","","","","");
                f.ShowDialog();
            }
            else exp_excel(false);
		}

		private void items(string f1)
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["hoantra"]=0;
						r3["ngoaitru"]=0;
						r3["treem"]=0;
						r3["khac"]=0;
						r3["noitru"]=0;
						foreach(DataRow r4 in dskp.Tables[0].Select("true","mabd"))
							r3["sl_"+r4["mabd"].ToString().PadLeft(3,'0')]=0;
						if (f1!="") r3[f1]=r["soluong"].ToString();
						else r3["sl_"+r["makp"].ToString().Trim().PadLeft(3,'0')]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
					{
						if (f1!="") dr[0][f1]=decimal.Parse(dr[0][f1].ToString())+decimal.Parse(r["soluong"].ToString());
						else dr[0]["sl_"+r["makp"].ToString().Trim().PadLeft(3,'0')]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim().PadLeft(3,'0')].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
		}

		private void items_xuat(string mmyy)
		{
            xxx = user + mmyy;
			sql="select a.makp,b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (1,4)";
			sql+=" and a.nhom="+i_nhom;
			sql+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.makp,b.mabd";
			sql+=" union all ";
			sql+="select a.makp,b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (2)";
			sql+=" and a.nhom="+i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.makp,b.mabd";
			items("");

			sql="select b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai in (3)";
			sql+=" and a.nhom="+i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
            if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd ";
			items("hoantra");

			sql="select b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id and a.loai='XK'";
			sql+=" and a.nhom="+i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd ";
			items("khac");

			sql="select b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id";
			sql+=" and a.nhom="+i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd ";
			sql+=" union all ";
			sql+="select b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id";
			sql+=" and a.nhom="+i_nhom+" and a.maphu<>"+m.iTreem6tuoi;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd ";
			items("ngoaitru");

			sql="select b.mabd,sum(b.soluong) as soluong ";
            sql += " from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + xxx + ".d_theodoi c where a.id=b.id and b.sttt=c.id";
			sql+=" and a.nhom="+i_nhom+" and a.maphu="+m.iTreem6tuoi;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd ";
			items("treem");
		}
	}
}
