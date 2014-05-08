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
	/// Summary description for rptBcngay.
	/// </summary>
	public class frmxkngay : System.Windows.Forms.Form
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
		private string user,stime,xxx,sql,tenfile,s_kho,s_makho;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private DataSet dsngay=new DataSet();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
        Excel.Range orange;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
        private System.Windows.Forms.DateTimePicker den;
        private CheckedListBox kho;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmxkngay(AccessData acc,int nhom,string kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		//s_mmyy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmxkngay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(111, 200);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(181, 200);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(59, 40);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 2;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(41, 200);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 6;
            this.butXem.Text = "&Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(59, 16);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(171, 16);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(59, 64);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 132);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmxkngay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(266, 243);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.kho);
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
            this.Name = "frmxkngay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo xuất kho theo ngày";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBcngay_MouseMove);
            this.Load += new System.EventHandler(this.rptBcngay_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBcngay_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            dt = d.get_data("select * from " + user + ".d_dmbd where nhom=" + i_nhom + " order by id").Tables[0];
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
            kho.DataSource = dtdmkho;
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			
			dsngay.ReadXml("..\\..\\..\\xml\\d_tsngay.xml");
			//
		}

		private void Tao_dataset(DateTime d1,DateTime d2)
		{
			string mmyy1="",mmyy2="";
			mmyy1=d1.Month.ToString().PadLeft(2,'0')+d1.Year.ToString().Substring(2,2);
			mmyy2=d2.Month.ToString().PadLeft(2,'0')+d2.Year.ToString().Substring(2,2);
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_bcngay.xml");
			dsngay.Clear();
			sql="select distinct to_char(ngay,'yymmdd') as ngay,to_char(ngay,'dd/mm') as ten from xxx.d_xuatsdll where nhom="+i_nhom+" and ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
            sql += "union all select distinct to_char(ngay,'yymmdd') as ngay,to_char(ngay,'dd/mm') as ten from xxx.d_xuatll where nhom=" + i_nhom + " and loai='XK' and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += "union all select distinct to_char(ngay,'yymmdd') as ngay,to_char(ngay,'dd/mm') as ten from xxx.d_ngtrull where nhom=" + i_nhom + " and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += "union all select distinct to_char(a.ngay,'yymmdd') as ngay,to_char(a.ngay,'dd/mm') as ten from xxx.bhytkb a,xxx.bhytthuoc b where a.id=b.id and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			dr=d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Select("ngay<>''","ngay");
			for(int i=0;i<dr.Length;i++)
			{
				r1=d.getrowbyid(dsngay.Tables[0],"ngay='"+dr[i]["ngay"].ToString()+"'");
				if ( r1 == null )
				{
					r2 = dsngay.Tables[0].NewRow();
					r2["ngay"]=dr[i]["ngay"].ToString();
					r2["ten"]=dr[i]["ten"].ToString();
					dsngay.Tables[0].Rows.Add(r2);
					dc=new DataColumn();
					dc.ColumnName="SL_"+dr[i]["ngay"].ToString().Trim();
					dc.DataType=Type.GetType("System.Decimal");
					ds.Tables[0].Columns.Add(dc);
				}
			}
			if (mmyy2!=mmyy1)
			{
				dr=d.get_data(sql).Tables[0].Select("ngay<>''","ngay");
				for(int i=0;i<dr.Length;i++)
				{
					r1=d.getrowbyid(dsngay.Tables[0],"ngay='"+dr[i]["ngay"].ToString()+"'");
					if ( r1 == null )
					{
						r2 = dsngay.Tables[0].NewRow();
						r2["ngay"]=dr[i]["ngay"].ToString();
						r2["ten"]=dr[i]["ten"].ToString();
						dsngay.Tables[0].Rows.Add(r2);
						dc=new DataColumn();
						dc.ColumnName="SL_"+dr[i]["ngay"].ToString().Trim();
						dc.DataType=Type.GetType("System.Decimal");
						ds.Tables[0].Columns.Add(dc);
					}
				}
			}
			dc=new DataColumn();
			dc.ColumnName="TONGCONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
			//
			dc=new DataColumn();
			dc.ColumnName="TONGTRA";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
		}

		private void get_xuat(string s_mmyy)
		{
			xxx=user+s_mmyy;			
			//phieu linh+haophi
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.loai not in(2,3) and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.ngay,b.mabd,c.ten";
			ins_items();

			//bu tu truc
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.loai in(2) and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.ngay,b.mabd,c.ten";
			ins_items();
			//d_xuatll+d_xuatct
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.loai='XK' and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.ngay,b.mabd,c.ten";
			ins_items();
			//d_ngtrull+d_ngtruct
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.ngay,b.mabd,c.ten";
			ins_items();
			//bhytkb+bhytthuoc
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.ngay,b.mabd,c.ten";
			ins_items();
			//tang xo so tu truc			
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.loai in('BS') and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by a.ngay,b.mabd,c.ten";
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
						string s_tenbd=r3["tenhc"].ToString();
						if(s_tenbd!=r3["ten"].ToString())s_tenbd+=" ("+r3["ten"].ToString().Trim()+") "+r3["hamluong"].ToString();
						r2["ten"]=s_tenbd;//r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dsngay.Tables[0].Rows) r2["sl_"+r4["ngay"].ToString().Trim()]=0;
						r2["sl_"+r["ngay"].ToString().Trim()]=r["soluong"].ToString();
						r2["tongcong"]=r["soluong"].ToString();
						//
						r2["tongtra"]=0;
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

		private void get_hoantra(string s_mmyy)
		{
			xxx=user+s_mmyy;
            sql = "select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c, " + user + ".d_dmhang e," + xxx + ".d_theodoi t ";
			sql+="where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=e.id and a.loai=3 and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
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
						string s_tenbd=r3["tenhc"].ToString();
						if(s_tenbd!=r3["ten"].ToString())s_tenbd+=" ("+r3["ten"].ToString().Trim()+") "+r3["hamluong"].ToString();
						r2["ten"]=s_tenbd;//r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dsngay.Tables[0].Rows) r2["sl_"+r4["ngay"].ToString().Trim()]=0;
						//r2["sl_"+r["ngay"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r2["tongcong"]=0;//-decimal.Parse(r["soluong"].ToString());
						//
						r2["tongtra"]=decimal.Parse(r["soluong"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					//dr[0]["sl_"+r["ngay"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["ngay"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
					//dr[0]["tongcong"]=decimal.Parse(dr[0]["tongcong"].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["tongtra"]=decimal.Parse(dr[0]["tongtra"].ToString())+decimal.Parse(r["soluong"].ToString());
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


		private void rptBcngay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void exp_excel(bool print)
		{
			try
			{
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
				osheet.Cells[dong-1,dsngay.Tables[0].Rows.Count+6]="Tổng trả";
				for(int i=0;i<dsngay.Tables[0].Rows.Count;i++)
					osheet.Cells[dong-1,i+5]=" "+dsngay.Tables[0].Rows[i]["ten"].ToString();
				osheet.get_Range(d.getIndex(4)+"4",d.getIndex(dsngay.Tables[0].Rows.Count+5)+"4").Orientation=90;
				osheet.get_Range(d.getIndex(0)+"4",d.getIndex(dsngay.Tables[0].Rows.Count+5)+"4").RowHeight=30;
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
				osheet.Cells[1,4]="BÁO CÁO SỬ DỤNG";
				string s_title=(tu.Text==den.Text)?"Ngày : "+tu.Text:"Từ ngày : "+tu.Text+" đến : "+den.Text;
				osheet.Cells[2,4]=s_title;
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
			d.check_process_Excel();
			if (!kiemtra()) return;
			exp_excel(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			d.check_process_Excel();
			if (!kiemtra()) return;
			exp_excel(true);
		}

		private bool kiemtra()
		{
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++) if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			Tao_dataset(tu.Value,den.Value);
			//
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
						get_hoantra(mmyy);
					}
				}
			}
			//
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
