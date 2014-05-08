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
	public class frmThdutru : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom;
		private string user,xxx,sql,s_mmyy,tenfile,s_kho,exp;
		private DataRow r1,r2,r3;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThdutru(AccessData acc,int nhom,string mmyy,string _kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;s_kho=_kho;
			i_nhom=nhom;
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThdutru));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(24, 96);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 8;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(94, 96);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(56, 14);
            this.tu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(40, 21);
            this.tu.TabIndex = 1;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(128, 14);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 3;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 36);
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
            this.makho.Location = new System.Drawing.Point(55, 38);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(121, 21);
            this.makho.TabIndex = 5;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-1, 64);
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
            this.manguon.Location = new System.Drawing.Point(55, 62);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(121, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmThdutru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(186, 135);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThdutru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp dù trù";
            this.Load += new System.EventHandler(this.frmThdutru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmThdutru_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy;
			dc=new DataColumn();
			dc.ColumnName="makp";
			dc.DataType=Type.GetType("System.String");
			dtmakp.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="tenkp";
			dc.DataType=Type.GetType("System.String");
			dtmakp.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="stt";
			dc.DataType=Type.GetType("System.Decimal");
			dtmakp.Columns.Add(dc);

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
            makho.DataSource = d.get_data(sql).Tables[0];            
            dtdmkho = d.get_data("select * from " + user + ".d_dmkho where nhom=" + i_nhom+" order by stt").Tables[0];
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            sql = "select a.*, b.stt as tt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f";
			sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];
			get_data();
			exp_excel(false);
		}

		private string get_ten(int i)
		{
			string s="Tồn "+makho.Text;
			string []map={"TT","Tên thuốc - hàm lượng","ĐVT","Đơn gía",s,"Tổng số"};
			return map[i];
		}

		private void exp_excel(bool print)
		{
			d.check_process_Excel();
			ds=dsxml.Copy();
			int be=2,dong=4,sodong=ds.Tables[0].Rows.Count+dong,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
			tenfile=d.Export_Excel(ds,"dutru");
			oxl=new Excel.Application();
			owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
			
			for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(d.getIndex(be-1)+dong.ToString(),d.getIndex(socot+1)+sodong.ToString()).NumberFormat="#,##0.00";
			osheet.get_Range(d.getIndex(0)+"3",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			int pos=7;
			foreach(DataRow r in dtmakp.Select("makp<>''","stt,makp"))
			{
				osheet.Cells[dong-1,pos]=r["tenkp"].ToString();
				pos+=1;
			}
			//osheet.Cells[dong-1,pos]="Tồn "+makho.Text;
			for(int i=0;i<6;i++) osheet.Cells[dong-1,i+1]=get_ten(i);
			orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot)+sodong.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=8;
			orange.EntireColumn.AutoFit();

			oxl.ActiveWindow.DisplayZeros=false;
			osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			osheet.Cells[1,4]="TỔNG HỢP DÙ TRÙ";
			string s_title=d.title(tu.Value.ToString(),tu.Value.ToString())+" năm "+yyyy.Value.ToString();
			osheet.Cells[2,4]=s_title;
			orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-1)+"2");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange.Font.Size=12;
			orange.Font.Bold=true;
			if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
			else oxl.Visible=true;
		}

		private void tao_table()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_xuat_ct.xml");
			dtmakp.Clear();
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (d.bMmyy(s_mmyy)) get_xuat_makp(s_mmyy);
			dc=new DataColumn();
			dc.ColumnName="TONKHO";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="SOLUONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			foreach(DataRow r in dtmakp.Select("makp<>''","stt,makp"))
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
			int idnn=0,stt=0,tt=1;
			sql="idnn,stt,ten";
			DataRow []dr=ds.Tables[0].Select("ma<>''",sql);
			for(int i=0;i<dr.Length;i++)
			{
				if (idnn!=int.Parse(dr[i]["idnn"].ToString()) || stt!=int.Parse(dr[i]["stt"].ToString()))
				{
					if (idnn!=int.Parse(dr[i]["idnn"].ToString()))
					{
						idnn=int.Parse(dr[i]["idnn"].ToString());
						stt=0;
						exp="idnn="+idnn;
						r2 = dsxml.Tables[0].NewRow();
						r2["stt"]=0;
						r2["ten"]=dr[i]["noingoai"].ToString().ToUpper();
						r2["dang"]="";
						r2["dongia"]=0;
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
						r2["soluong"]=0;
						dsxml.Tables[0].Rows.Add(r2);
					}
					if (stt!=int.Parse(dr[i]["stt"].ToString()))
					{
						stt=int.Parse(dr[i]["stt"].ToString());
						exp="idnn="+idnn+" and stt="+stt;
						r2 = dsxml.Tables[0].NewRow();
						r2["stt"]=0;
						r2["ten"]=dr[i]["tennhom"].ToString().ToUpper();
						r2["dang"]="";
						r2["dongia"]=0;
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
						r2["soluong"]=0;
						dsxml.Tables[0].Rows.Add(r2);
					}
				}
				r2 = dsxml.Tables[0].NewRow();
				r2["manhom"]=dr[i]["manhom"].ToString();
				r2["tennhom"]=dr[i]["tennhom"].ToString();
				r2["mabd"]=dr[i]["mabd"].ToString();
				r2["ma"]=dr[i]["ma"].ToString();
				r2["ten"]=dr[i]["ten"].ToString();
				r2["tenhc"]=dr[i]["tenhc"].ToString();
				r2["dang"]=dr[i]["dang"].ToString();
				r2["dongia"]=dr[i]["dongia"].ToString();
				r2["stt"]=tt.ToString();
				r2["idnn"]=dr[i]["idnn"].ToString();
				r2["noingoai"]=dr[i]["noingoai"].ToString();
				foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
					r2["sl_"+r5["makp"].ToString().Trim()]=dr[i]["sl_"+r5["makp"].ToString().Trim()].ToString();
				r2["soluong"]=dr[i]["soluong"].ToString();
				r2["tonkho"]=dr[i]["tonkho"].ToString();
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
		}

		private void get_xuat_makp(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select distinct khon from "+xxx+".d_dutrucapll a,"+xxx+".d_dutrucapct b where a.id=b.id and a.nhom="+i_nhom;
			sql+=" and a.khox="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows) updrec(r["khon"].ToString().Trim());
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select to_char(a.khon,'000') as makp,b.mabd,sum(b.slyeucau) as soluong";
			sql+=" from "+xxx+".d_dutrucapll a,"+xxx+".d_dutrucapct b where a.id=b.id and a.khox="+int.Parse(makho.SelectedValue.ToString())+" and a.nhom="+i_nhom;
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by to_char(a.khon,'000'),b.mabd";
			DataRow[] dr;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{				
				exp="mabd="+int.Parse(r["mabd"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r3["dongia"].ToString();
						r2["stt"]=r3["tt"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
						r2["sl_"+r["makp"].ToString().Trim()]=r["soluong"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["tonkho"]=0;
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select(exp);
					if (dr.Length>0)
					{
						dr[0]["sl_"+r["makp"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["makp"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					}
				}
			}
			sql="select a.mabd,sum(a.tondau+a.slnhap-a.slxuat) as toncuoi from "+xxx+".d_tonkhoct a,"+xxx+".d_theodoi t ";
			sql+=" where a.stt=t.id and a.makho="+int.Parse(makho.SelectedValue.ToString());
			sql+=" and a.tondau+a.slnhap-a.slxuat>0";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.mabd";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r3["dongia"].ToString();
						r2["stt"]=r3["tt"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						foreach(DataRow r5 in dtmakp.Select("makp<>''","stt,makp"))
							r2["sl_"+r5["makp"].ToString().Trim()]=0;
						r2["soluong"]=0;
						r2["tonkho"]=r["toncuoi"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["tonkho"]=decimal.Parse(dr[0]["tonkho"].ToString())+decimal.Parse(r["toncuoi"].ToString());
				}
			}
			ds.AcceptChanges();
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
			tao_table();
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			if (d.bMmyy(s_mmyy)) get_xuat(s_mmyy);
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
		}

		private void updrec (string makp)
		{
			makp=makp.PadLeft(3,'0');
			exp="makp='"+makp+"'";
			DataRow r = d.getrowbyid (dtmakp,exp); 
			if ( r == null )
			{
				DataRow r1=d.getrowbyid(dtdmkho,"id="+int.Parse(makp));
				if (r1!=null)
				{
					DataRow nrow = dtmakp.NewRow ( ) ;
					nrow["makp"] = makp;
					nrow["tenkp"]= r1["ten"].ToString();
					nrow["stt"]=r1["stt"].ToString();
					dtmakp.Rows.Add ( nrow ) ;
				}
			}
		}
	}
}
