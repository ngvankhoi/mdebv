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
	public class rptBCTienthuoc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom = 0, i_userid=0;
		private string sql,mmyy,user,stime;
		private DataSet ds=new DataSet();
		private DataSet dsloai=new DataSet();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBCTienthuoc(AccessData acc,int nhom, int _userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBCTienthuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(138, 48);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(127, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(68, 48);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 10;
            this.butXem.Text = "&In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 13);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(168, 13);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptBCTienthuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 95);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBCTienthuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tiền thuốc sử dụng";
            this.Load += new System.EventHandler(this.rptBCTienthuoc_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBCTienthuoc_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			ds.ReadXml("..\\..\\..\\xml\\d_bctienthuoc.xml");
			dsloai.ReadXml("..\\..\\..\\xml\\d_bcloaithuoc.xml");
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
			print();
		}	

		private void get_xuat_tien()
		{
			sql="select c.nhombo,sum(case when e.stt=1 then b.soluong*t.giamua else 0 end) as vn_st,sum(case when e.stt=1 then 0 else b.soluong*t.giamua end) as nn_st ";
            sql+=" from xxx.d_xuatsdll a,xxx.d_thucxuat b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+="where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
			sql+=" and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			sql+=" and a.loai not in (3)";
			sql+=" group by c.nhombo";
			sql+=" union all ";
			sql+="select c.nhombo,-sum(case when e.stt=1 then b.soluong*t.giamua else 0 end) as vn_st,-sum(case when e.stt=1 then 0 else b.soluong*t.giamua end) as nn_st ";
            sql+=" from xxx.d_xuatsdll a,xxx.d_thucxuat b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai in (3)";
			sql+=" group by c.nhombo";
			sql+=" union all ";
			sql+="select c.nhombo,sum(case when e.stt=1 then b.soluong*t.giamua else 0 end) as vn_st,sum(case when e.stt=1 then 0 else b.soluong*t.giamua end) as nn_st ";
            sql+=" from xxx.d_ngtrull a,xxx.d_ngtruct b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" group by c.nhombo";
			sql+=" union all ";
			sql+="select c.nhombo,sum(case when e.stt=1 then b.soluong*t.giamua else 0 end) as vn_st,sum(case when e.stt=1 then 0 else b.soluong*t.giamua end) as nn_st ";
            sql+=" from xxx.bhytkb a,xxx.bhytthuoc b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" group by c.nhombo";
			sql+=" union all ";
			sql+="select c.nhombo,sum(case when e.stt=1 then b.soluong*t.giamua else 0 end) as vn_st,sum(case when e.stt=1 then 0 else b.soluong*t.giamua end) as nn_st ";
            sql+=" from xxx.d_xuatll a,xxx.d_xuatct b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai='XK' group by c.nhombo";
			DataTable dt=d.get_thuoc(tu.Text,den.Text,sql).Tables[0];
			decimal vn_st=0,nn_st=0,vn=0,nn=0;
			foreach(DataRow r in dt.Rows)
			{
				if (r["vn_st"].ToString()!="") vn+=decimal.Parse(r["vn_st"].ToString());
                if (r["nn_st"].ToString() != "") nn += decimal.Parse(r["nn_st"].ToString());
			}
			foreach(DataRow r1 in ds.Tables[0].Select("ma<>''"))
			{
				foreach(DataRow r in dt.Rows)
				{
					if (r1["ma"].ToString().IndexOf(r["nhombo"].ToString().Trim()+",")!=-1)
					{
						r1["vn_st"]=decimal.Parse(r1["vn_st"].ToString())+decimal.Parse(r["vn_st"].ToString());
						r1["nn_st"]=decimal.Parse(r1["nn_st"].ToString())+decimal.Parse(r["nn_st"].ToString());
						r1["tongso"]=decimal.Parse(r1["vn_st"].ToString())+decimal.Parse(r1["nn_st"].ToString());
						vn_st+=decimal.Parse(r["vn_st"].ToString());
						nn_st+=decimal.Parse(r["nn_st"].ToString());
					}
				}
			}
			DataRow r2=d.getrowbyid(ds.Tables[0],"ma=''");
			if (r2!=null)
			{
				r2["vn_st"]=decimal.Parse(r2["vn_st"].ToString())+vn-vn_st;
				r2["nn_st"]=decimal.Parse(r2["nn_st"].ToString())+nn-nn_st;
				r2["tongso"]=decimal.Parse(r2["vn_st"].ToString())+decimal.Parse(r2["nn_st"].ToString());
			}
		}

		private void get_xuat_loai()
		{
			sql="select b.mabd,c.nhombo,case when e.stt=1 then 1 else 0 end as vn_sl,case when e.stt=1 then 0 else 1 end as nn_sl ";
            sql+=" from xxx.d_xuatsdll a,xxx.d_thucxuat b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai not in (3)";
			sql+=" union all ";
			sql+="select b.mabd,c.nhombo,case when e.stt=1 then 1 else 0 end as vn_sl,case when e.stt=1 then 0 else 1 end as nn_sl ";
            sql+=" from xxx.d_xuatsdll a,xxx.d_thucxuat b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai in (3)";
			sql+=" union all ";
			sql+="select b.mabd,c.nhombo,case when e.stt=1 then 1 else 0 end as vn_sl,case when e.stt=1 then 0 else 1 end as nn_sl ";
            sql+=" from xxx.d_ngtrull a,xxx.d_ngtruct b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" union all ";
			sql+="select b.mabd,c.nhombo,case when e.stt=1 then 1 else 0 end as vn_sl,case when e.stt=1 then 0 else 1 end as nn_sl ";
            sql+=" from xxx.bhytkb a,xxx.bhytthuoc b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" union all ";
			sql+="select b.mabd,c.nhombo,case when e.stt=1 then 1 else 0 end as vn_sl,case when e.stt=1 then 0 else 1 end as nn_sl ";
            sql+=" from xxx.d_xuatll a,xxx.d_xuatct b,xxx.d_theodoi t,"+user+".d_dmbd c,"+user+".d_dmhang d,"+user+".d_nhomhang e ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and c.mahang=d.id and d.loai=e.id";
            sql += " and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai='XK'";
			DataRow r1,r2;
			foreach(DataRow r in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and nhombo="+int.Parse(r["nhombo"].ToString());
				r1=d.getrowbyid(dsloai.Tables[0],sql);
				if (r1==null)
				{
					r2=dsloai.Tables[0].NewRow();
					r2["mabd"]=r["mabd"].ToString();
					r2["nhombo"]=r["nhombo"].ToString();
					r2["vn_sl"]=r["vn_sl"].ToString();
					r2["nn_sl"]=r["nn_sl"].ToString();
					dsloai.Tables[0].Rows.Add(r2);
				}
			}
		}

		private void print()
		{
			Cursor=Cursors.WaitCursor;
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				r["vn_st"]=0;r["vn_sl"]=0;
				r["nn_st"]=0;r["nn_sl"]=0;
				r["tongso"]=0;
			}
			dsloai.Clear();
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
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
						get_xuat_tien();
						get_xuat_loai();
					}
				}
			}

			#region dem loai thuoc
			foreach(DataRow r1 in ds.Tables[0].Select("ma<>''"))
			{
				foreach(DataRow r in dsloai.Tables[0].Select("nhombo<>0"))
				{
					if (r1["ma"].ToString().IndexOf(r["nhombo"].ToString().Trim()+",")!=-1)
					{
						r1["vn_sl"]=decimal.Parse(r1["vn_sl"].ToString())+decimal.Parse(r["vn_sl"].ToString());
						r1["nn_sl"]=decimal.Parse(r1["nn_sl"].ToString())+decimal.Parse(r["nn_sl"].ToString());
					}
				}
			}
			DataRow r2=d.getrowbyid(ds.Tables[0],"ma=''");
			if (r2!=null)
			{
				r2["vn_sl"]=dsloai.Tables[0].Select("nhombo=0 and vn_sl<>0").Length;
				r2["nn_sl"]=dsloai.Tables[0].Select("nhombo=0 and nn_sl<>0").Length;
			}
			#endregion
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
			else
			{
				frmReport f1=new frmReport(d,ds.Tables[0], i_userid,"d_bctienthuoc.rpt","",s_title,"","","","","","","","");
				f1.ShowDialog(this);
			}
		}	
	}
}
