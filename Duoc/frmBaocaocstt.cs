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
	public class frmBaocaocstt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private string sql,s_mmyy,tenfile,s_kho,s_makp,format_soluong,user,stime,xxx;
		private bool bClear=true;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBaocaocstt(AccessData acc,int nhom,string mmyy,string _kho)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaocstt));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(80, 224);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(150, 224);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
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
            this.makho.Size = new System.Drawing.Size(233, 21);
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
            this.manguon.Size = new System.Drawing.Size(233, 21);
            this.manguon.TabIndex = 3;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(50, 84);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(233, 132);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(203, 11);
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
            this.label1.Location = new System.Drawing.Point(163, 11);
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
            // frmBaocaocstt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(290, 263);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.makp);
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
            this.Name = "frmBaocaocstt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo cơ số tủ trực";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmBaocaocstt_MouseMove);
            this.Load += new System.EventHandler(this.frmBaocaocstt_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmBaocaocstt_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			format_soluong=d.format_soluong(i_nhom);
            sql = "select a.*, b.stt as sttnhom, b.ten as tennhom from " + user + ".d_dmbd a, " + user + ".d_dmnhom b";
			sql+=" where a.manhom=b.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];

            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString().Trim() + ",%' order by stt";
            dtkp = d.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";


			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
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
			string []map={"TT","Tên thuốc - hàm lượng","ĐVT","Tổng số"};
			return map[i];
		}

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
            ds.Tables[0].Columns.Remove("losx");
            ds.Tables[0].Columns.Remove("handung");
            ds.Tables[0].Columns.Remove("hangsx");
            ds.Tables[0].Columns.Remove("nuocsx");
			int dong=2,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
			tenfile=d.Export_Excel(ds,"cosotutruc");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			
			osheet.get_Range(d.getIndex(3)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat=format_soluong;
			osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			int pos=5;
			foreach(DataRow r in dtmakp.Select("makp<>''","stt,makp"))
			{
				osheet.Cells[dong-1,pos]=r["tenkp"].ToString();
				pos+=1;
			}
			for(int i=0;i<4;i++)
				osheet.Cells[dong-1,i+1]=get_ten(i);
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=10;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
			osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
			osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
			osheet.PageSetup.CenterFooter="Trang : &P/&N";
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			osheet.PageSetup.LeftHeader = d.Syte+"\n"+d.Tenbv;
			osheet.PageSetup.CenterHeader = "&\"Arial,Bold\"&14BÁO CÁO CƠ SỐ TỦ TRỰC\n"+s_title;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void tao_table()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
			dc=new DataColumn();
			dc.ColumnName="SOLUONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			sql="select stt,to_char(id,'000') as makp,ten as tenkp from "+user+".d_duockp where nhom like '%"+i_nhom.ToString().Trim()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			foreach(DataRow r in dtmakp.Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="SL_"+r["makp"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
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
					foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
						r2["sl_"+r5["makp"].ToString().Trim()]=0;
					r2["soluong"]=0;
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
				foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
					r2["sl_"+r5["makp"].ToString().Trim()]=dr[i]["sl_"+r5["makp"].ToString().Trim()].ToString();
				r2["soluong"]=dr[i]["soluong"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
				tt++;
			}
			dsxml.Tables[0].Columns.Remove("manhom");
			dsxml.Tables[0].Columns.Remove("mabd");
			dsxml.Tables[0].Columns.Remove("ma");
			dsxml.Tables[0].Columns.Remove("tenhc");
			dsxml.Tables[0].Columns.Remove("manguon");
			dsxml.Tables[0].Columns.Remove("tennhom");
			dsxml.Tables[0].Columns.Remove("noingoai");
			dsxml.Tables[0].Columns.Remove("idnn");
			dsxml.Tables[0].Columns.Remove("dongia");
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
			s_makp="";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["id"].ToString().Trim()+",";
			d.writeXml("d_thongso","sudung",s_makp);
			tao_table();
			items_tondau();
			items_nhap();
			items_xuat();
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			exp_excel(false);
		}

		private void items_tondau()
		{
			foreach(DataRow r in get_tondau().Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
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
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r3["sl_"+r5["makp"].ToString().Trim()]=0;
						r3["sl_"+r["makp"].ToString().Trim()]=r["soluong"].ToString();
						r3["soluong"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) 
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
			//nhap
			foreach(DataRow r in get_nhap(" and a.ngay<to_date('"+tu.Text+"',"+stime+")"," and a.ngay<to_date('"+tu.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
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
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r3["sl_"+r5["makp"].ToString().Trim()]=0;
						r3["sl_"+r["makp"].ToString().Trim()]=r["soluong"].ToString();
						r3["soluong"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
			//xuat
			foreach(DataRow r in get_xuat(" and a.ngay<to_date('"+tu.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["manhom"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r3["sl_"+r5["makp"].ToString().Trim()]=0;
						r3["sl_"+r["makp"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r3["soluong"]=-decimal.Parse(r["soluong"].ToString());
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
					}
				}
			}
		}

		private DataSet get_tondau()
		{
            xxx = user + s_mmyy;
			sql=" select to_char(a.makp,'000') as makp,a.mabd,sum(a.tondau) as soluong ";
            sql+=" from "+xxx+".d_tutrucct a,"+user+".d_dmbd b,"+xxx+".d_theodoi t ";
			sql+=" where a.stt=t.id and a.mabd=b.id ";
			if (makho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" group by to_char(a.makp,'000'),a.mabd";
			return d.get_data(sql);
		}

		private void items_xuat()
		{
			foreach(DataRow r in get_xuat(" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["manhom"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r3["sl_"+r5["makp"].ToString().Trim()]=0;
						r3["sl_"+r["makp"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r3["soluong"]=-decimal.Parse(r["soluong"].ToString());
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
					}
				}
			}
		}

		private void items_nhap()
		{
			foreach(DataRow r in get_nhap(" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")"," and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
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
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r3["sl_"+r5["makp"].ToString().Trim()]=0;
						r3["sl_"+r["makp"].ToString().Trim()]=r["soluong"].ToString();
						r3["soluong"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0)
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
		}
		private DataSet get_nhap(string cont1,string cont2)
		{
            xxx = user + s_mmyy;
			sql=" select to_char(a.makp,'000') as makp,b.mabd,sum(b.soluong) as soluong ";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucbucstt b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=2 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=cont1;
			sql+=" group by to_char(a.makp,'000'),b.mabd";
			sql+=" union all ";
			sql+=" select to_char(a.khon,'000') as makp,b.mabd,sum(b.soluong) as soluong ";
            sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in ('BS') ";
			if (makho.SelectedIndex!=-1) sql+=" and a.khox="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.khon in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=cont2;
			sql+=" group by to_char(a.khon,'000'),b.mabd";
			return d.get_data(sql);
		}

		private DataSet get_xuat(string cont)
		{
            xxx = user + s_mmyy;
			sql=" select to_char(a.makp,'000') as makp,b.mabd,sum(b.soluong) as soluong ";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+xxx+".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=2 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=cont;
			sql+=" group by to_char(a.makp,'000'),b.mabd";
			sql+=" union all ";
			sql+=" select to_char(a.khox,'000') as makp,b.mabd,sum(b.soluong) as soluong ";
            sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in ('TH','HT') ";
			if (makho.SelectedIndex!=-1) sql+=" and a.khon="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (s_makp!="") sql+=" and a.khox in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=cont;
			sql+=" group by to_char(a.khox,'000'),b.mabd";
			return d.get_data(sql);
		}

		private void frmBaocaocstt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				s_makp=d.Thongso("d_thongso","sudung").Trim();
				for(int i=0;i<makp.Items.Count;i++)
					if (s_makp.IndexOf(dtkp.Rows[i]["id"].ToString().Trim()+",")!=-1) makp.SetItemCheckState(i,CheckState.Checked);
					else makp.SetItemCheckState(i,CheckState.Unchecked);
				bClear=false;
			}
		}
	}
}
