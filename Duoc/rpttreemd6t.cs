using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBhyt.
	/// </summary>
	public class rpttreemd6t : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataColumn dc;
		private AccessData d;
        private int i_nhom, i_userid=0;
		private bool bClear=true;
		private string sql,s_kho,s_makho,user,stime,xxx;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds;
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtkho=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rpttreemd6t(AccessData acc,int nhom,string kho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpttreemd6t));
            this.label1 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(104, 172);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(174, 172);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 40);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 2;
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(126, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 64);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 100);
            this.kho.TabIndex = 4;
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(34, 172);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 5;
            this.butXem.Text = "&Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 16);
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
            this.den.Location = new System.Drawing.Point(168, 16);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rpttreemd6t
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(266, 213);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rpttreemd6t";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trẻ em dưới 6 tuổi";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBhyt_MouseMove);
            this.Load += new System.EventHandler(this.rptBhyt_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBhyt_Load(object sender, System.EventArgs e)
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
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
		}

		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_bhyt.xml");
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
            xxx = user + d_mmyy;
            sql = "select b.makho,b.mabd,c.ten,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) sotien from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai<>3 and b.madoituong=1 and a.nhom=" + i_nhom;
            sql+=" and a.ngay between to_date('" + tu.Text + "',"+stime+") and to_date('" + den.Text + "',"+stime+")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
			ins_items();

            sql = "select b.makho,b.mabd,c.ten,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.makho,b.mabd,c.ten order by c.ten";
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
            xxx = user + d_mmyy;
            sql = "select b.makho,b.mabd,c.ten,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi t ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 and b.madoituong=1 and a.nhom=" + i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
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


		private void rptBhyt_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{				
			kiemtra_toa();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			kiemtra_toa();
		}
		private DataSet get_dsbn_bhyt(string d_mmyy, string s_kho,string s_cond )
		{
            xxx = user + d_mmyy;
			sql=" select ((to_char(a.sotoa,'0000')||a.mabn)||to_char(a.id,'000000000000')) as key_,"+
				" a.mabn, trim(a.hoten)||' ('||trim(a.namsinh)||')' as hoten, ' ' as sothe, 0 as maphu, 0 as congkham,a.ngay,b.soluong,b.soluong*t.giamua as sotien,t.giamua as dongia,"+
				" d.ma,(d.ten||' '||d.hamluong) as ten, d.tenhc, d.hamluong, d.dang, case when a.mabn is null then '0' else a.mabn end as sotoa ";
			sql+=" from "+xxx+".d_ngtrull a, "+xxx+".d_ngtruct b, "+user+".d_dmbd d ,"+xxx+".d_theodoi t ";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=d.id and b.soluong>0";
			if(s_kho!="") sql+=" and b.makho in ("+s_kho+")";
			sql+=s_cond;
			DataSet ds=new DataSet();
			ds=d.get_data(sql);
			return ds;
		}	
		private void kiemtra_toa()
		{			
			string s_cond="and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if(manguon.SelectedIndex>=0)s_cond+=" and t.manguon="+manguon.SelectedValue.ToString();
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			string s_rpt="d_pxuatct_treem.rpt";
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++)	if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";		
			ds=new DataSet();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						if(ds.Tables.Count<=0) 
							ds.Tables.Add(get_dsbn_bhyt(mmyy, s_kho.Substring(0,s_kho.Length-1),s_cond).Tables[0].Copy());
						else
							ds.Merge(get_dsbn_bhyt(mmyy, s_kho.Substring(0,s_kho.Length-1),s_cond).Tables[0].Copy());
					}
				}
			}
			if(ds.Tables[0].Rows.Count<=0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu."),
lan.Change_language_MessageText("Trẻ em <6 Tuổi"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				doiso.Doisototext dd=new doiso.Doisototext();				
				decimal tc=0;
				foreach(DataRow r in ds.Tables[0].Select("sotien<>0")) tc+=decimal.Parse(r["sotien"].ToString());
				frmReport f=new frmReport(d,ds.Tables[0], i_userid,s_rpt,"",s_title,kho.Text,"","","",kho.Text,"","",dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
				f.ShowDialog();				
			}
		}
	}
}
