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
namespace Duoc
{
	/// <summary>
	/// Summary description for rptDaphat.
	/// </summary>
	public class rptDaphat : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataColumn dc;
		private AccessData d;
		private int i_nhom;
		private bool bClear=true;
		private string sql,s_mmyy,s_tu,s_den,s_yy,tenfile,s_kho,s_makho;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label3;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptDaphat(AccessData acc,int nhom,string mmyy,string kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			den.Value=tu.Value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptDaphat));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(96, 199);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(74, 26);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(170, 199);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 26);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 40);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 3;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(56, 64);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(192, 21);
            this.nhomcc.TabIndex = 4;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-4, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhóm CC :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(56, 16);
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
            this.tu.TabIndex = 0;
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
            this.yyyy.Location = new System.Drawing.Point(200, 16);
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
            this.yyyy.TabIndex = 2;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(128, 16);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(40, 21);
            this.den.TabIndex = 1;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(96, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 87);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 100);
            this.kho.TabIndex = 5;
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(22, 199);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(74, 26);
            this.butXem.TabIndex = 6;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // rptDaphat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 239);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptDaphat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đã phát cho người bệnh";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptDaphat_MouseMove);
            this.Load += new System.EventHandler(this.rptDaphat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptDaphat_Load(object sender, System.EventArgs e)
		{
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from d_dmnguon where id=0 or nhom="+i_nhom+" order by stt").Tables[0];
			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
				nhomcc.DataSource=d.get_data("select * from d_nhomcc where nhom="+i_nhom+" order by stt").Tables[0];
			else
				nhomcc.DataSource=d.get_data("select * from d_nhomcc where id=0 or nhom="+i_nhom+" order by stt").Tables[0];
			dt=d.get_data("select * from d_dmbd where nhom="+i_nhom+" order by id").Tables[0];
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
		}

		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_daphat.xml");
			foreach(DataRow r in dtkho.Rows)
			{
				dc=new DataColumn();
				dc.ColumnName="SOLUONG_"+r["id"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);

				dc=new DataColumn();
				dc.ColumnName="SOTIEN_"+r["id"].ToString().Trim();
				dc.DataType=Type.GetType("System.Decimal");
				ds.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="SOLUONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="SOTIEN";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
		}

		private void get_xuat(string d_mmyy)
		{
			sql="select b.makho,b.mabd,c.ten,sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien from d_xuatsdll a,d_thucxuat b,"+d.user+".d_dmbd c ";
			sql+="where a.id=b.id and b.mabd=c.id and a.loai<>3 and a.nhom="+i_nhom+" and substr(a.mmyy,3,2)='"+s_yy+"'"+" and substr(a.mmyy,1,2) between '"+s_tu+"'"+" and '"+s_den+"'";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			ins_items(d_mmyy);

			sql="select b.makho,b.mabd,c.ten,sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien from d_ngtrull a,d_ngtruct b,"+d.user+".d_dmbd c ";
			sql+="where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and substr(a.mmyy,3,2)='"+s_yy+"'"+" and substr(a.mmyy,1,2) between '"+s_tu+"'"+" and '"+s_den+"'";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			ins_items(d_mmyy);

			sql="select b.makho,b.mabd,c.ten,sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien from bhytkb a,bhytthuoc b,"+d.user+".d_dmbd c ";
			sql+="where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and substr(a.mmyy,3,2)='"+s_yy+"'"+" and substr(a.mmyy,1,2) between '"+s_tu+"'"+" and '"+s_den+"'";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			ins_items(d_mmyy);
		}

		private void ins_items(string d_mmyy)
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
						foreach(DataRow r4 in dtkho.Rows)
						{
							r2["soluong_"+r4["id"].ToString().Trim()]=0;
							r2["sotien_"+r4["id"].ToString().Trim()]=0;
						}
						r2["soluong_"+r["makho"].ToString().Trim()]=r["soluong"].ToString();
						r2["sotien_"+r["makho"].ToString().Trim()]=r["sotien"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["soluong_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["soluong_"+r["makho"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["sotien_"+r["makho"].ToString().Trim()].ToString())+decimal.Parse(r["sotien"].ToString());
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
			sql="select b.makho,b.mabd,c.ten,sum(b.soluong) soluong,sum(b.soluong*b.giamua) sotien from d_xuatsdll a,d_thucxuat b,"+d.user+".d_dmbd c ";
			sql+="where a.id=b.id and b.mabd=c.id and a.loai=3 and a.nhom="+i_nhom+" and substr(a.mmyy,3,2)='"+s_yy+"'"+" and substr(a.mmyy,1,2) between '"+s_tu+"'"+" and '"+s_den+"'";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
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
						foreach(DataRow r4 in dtkho.Rows)
						{
							r2["soluong_"+r4["id"].ToString().Trim()]=0;
							r2["sotien_"+r4["id"].ToString().Trim()]=0;
						}
						r2["soluong_"+r["makho"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien_"+r["makho"].ToString().Trim()]=-decimal.Parse(r["sotien"].ToString());
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["soluong_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["soluong_"+r["makho"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien_"+r["makho"].ToString().Trim()]=decimal.Parse(dr[0]["sotien_"+r["makho"].ToString().Trim()].ToString())-decimal.Parse(r["sotien"].ToString());
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())-decimal.Parse(r["sotien"].ToString());
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


		private void rptDaphat_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				nhomcc.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void exp_excel(bool print)
		{
			try
			{
				int i_rec=dtkho.Rows.Count,be=4,dong=6,sodong=ds.Tables[0].Rows.Count+6,socot=ds.Tables[0].Columns.Count-1,dongke=sodong-1;
				tenfile=d.Export_Excel(ds,"daphat");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(be)+dong.ToString(),d.getIndex(socot)+sodong.ToString()).NumberFormat="#,##0.00";
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(socot-1)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				for(int i=0;i<i_rec;i++)
				{
					osheet.Cells[dong-2,i*2+5]=dtkho.Rows[i]["ten"].ToString();
					orange=osheet.get_Range(d.getIndex(i*2+4)+"4",d.getIndex(i*2+5)+"4");
					orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
					orange.Font.Bold=true;
				}
				osheet.Cells[dong-2,i_rec*2+5]="Tổng cộng";
				orange=osheet.get_Range(d.getIndex(i_rec*2+4)+"4",d.getIndex(i_rec*2+5)+"4");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Bold=true;
				for(int i=1;i<=be;i++) 
				{
					osheet.Cells[dong-1,i]=get_ten(i+1);
					orange=osheet.get_Range(d.getIndex(i-1)+"4",d.getIndex(i-1)+"5");
					orange.MergeCells=true;
				}
				for(int i=be;i<socot;i++) osheet.Cells[dong-1,i+1]=get_ten(i%2);
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
				osheet.Cells[1,2]=d.Syte;osheet.Cells[2,2]=d.Tenbv;
				orange=osheet.get_Range(d.getIndex(1)+"1",d.getIndex(3)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				s_tu=tu.Value.ToString().PadLeft(2,'0');
				s_den=den.Value.ToString().PadLeft(2,'0');
				s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
				osheet.Cells[1,4]="BÁO CÁO ĐÃ PHÁT CHO NGƯỜI BỆNH";
				osheet.Cells[2,4]=(tu.Value==den.Value)?"Tháng : "+s_tu+"/"+yyyy.Value.ToString():"Từ tháng :"+s_tu+"/"+yyyy.Value.ToString()+" đến tháng :"+s_den+"/"+yyyy.Value.ToString();
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
			string []map={"Số lượng","Số tiền","TT","Mã số","Tên","ĐVT"};
			return map[i];
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			exp_excel(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			exp_excel(true);
		}

		private bool kiemtra()
		{
			if (tu.Value>den.Value)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Tháng không hợp lệ !"),d.Msg);
				tu.Focus();
				return false;
			}
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++)
				if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			Tao_dataset();
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			//			
			int y1=int.Parse(yyyy.Value.ToString()),m1=int.Parse(tu.Value.ToString());
			int y2=int.Parse(yyyy.Value.ToString()),m2=int.Parse(den.Value.ToString());
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
						get_hoantra(mmyy);
					}
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return false;
			}
			return true;
		}
	}
}
