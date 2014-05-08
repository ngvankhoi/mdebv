using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmtkdscls.
	/// </summary>
	public class frmtkthcls_n : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtnd=new DataTable();
		private string sql,s_cls,user,stime;
		private AccessData m;
		private System.Windows.Forms.CheckedListBox loai;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmtkthcls_n(AccessData acc,string cls)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m=acc;s_cls=cls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkthcls_n));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(139, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 8);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(168, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(34, 189);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(93, 25);
            this.butIN.TabIndex = 5;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(130, 189);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(93, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // loai
            // 
            this.loai.CheckOnClick = true;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(56, 32);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 148);
            this.loai.TabIndex = 4;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmtkthcls_n
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 229);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkthcls_n";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê tổng hợp cận làm sàng";
            this.Load += new System.EventHandler(this.frmtkthcls_n_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmtkthcls_n_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			ds.ReadXml("..//..//..//xml//m_tkcls.xml");
			sql="select * from "+user+".cls_loai ";
			if (s_cls!="") sql+=" where id in ("+s_cls.Substring(0,s_cls.Length-1)+")";
			sql+=" order by id";
			dt=m.get_data(sql).Tables[0];
            loai.DataSource = dt;
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			
			dtnd=m.get_data("select * from "+user+".cls_noidung").Tables[0];
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			s_cls="";
			for(int i=0;i<loai.Items.Count;i++)
				if (loai.GetItemChecked(i)) s_cls+=dt.Rows[i]["id"].ToString()+",";
			ds.Clear();
			sql="select a.loai,a.ma,";
			sql+=" sum(case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end) as c01,";
			sql+=" sum(case when a.loaibn=0 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c02,";
			sql+=" sum(case when b.canquang is not null and b.canquang=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c03,";
			sql+=" sum(case when a.loaibn=0 and b.canquang is not null and b.canquang=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c04,";
			sql+=" sum(case when b.gayme is not null and b.gayme=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c05,";
			sql+=" sum(case when a.loaibn=0 and b.gayme is not null and b.gayme=1 then case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end else 0 end) as c06";
			sql+=" from xxx.cls_thuchien a left join xxx.cls_motact b on a.id=b.id ";
            sql+=" left join xxx.cls_mat d on a.id=d.id ";
            sql+=" inner join "+user+".cls_loai g on a.loai=g.id";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_cls!="") sql+=" and a.loai in ("+s_cls.Substring(0,s_cls.Length-1)+")";
			sql+=" group by a.loai,a.ma";
			sql+=" order by a.loai,a.ma";
			DataRow r1,r2,r3,r4;
			foreach(DataRow r in m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0].Rows)
			{
				sql="loai="+int.Parse(r["loai"].ToString())+" and mabn='"+r["ma"].ToString()+"'";
				r1=m.getrowbyid(ds.Tables[0],sql);
                if (r1==null)
				{
					r3=m.getrowbyid(dt,"id="+int.Parse(r["loai"].ToString()));
					r4=m.getrowbyid(dtnd,"ma='"+r["ma"].ToString()+"'");
					if (r3!=null && r4!=null)
					{
						r2=ds.Tables[0].NewRow();
						r2["loai"]=r["loai"].ToString();
						r2["mabn"]=r["ma"].ToString();
						r2["hoten"]=r3["ten"].ToString();
						r2["tenkp"]=r4["ten"].ToString();
						r2["ts"]=1;
						r2["c01"]=r["c01"].ToString();
						r2["c02"]=r["c02"].ToString();
						r2["c03"]=0;
						r2["c04"]=0;
						ds.Tables[0].Rows.Add(r2);
						if (decimal.Parse(r["c03"].ToString())+decimal.Parse(r["c04"].ToString())>0)
						{
							r2=ds.Tables[0].NewRow();
							r2["loai"]=r["loai"].ToString();
							r2["mabn"]=r["ma"].ToString();
							r2["hoten"]=r3["ten"].ToString();
							r2["tenkp"]="CÓ CẢN QUANG";
							r2["ts"]=2;
							r2["c01"]=0;
							r2["c02"]=0;
							r2["c03"]=r["c03"].ToString();
							r2["c04"]=r["c04"].ToString();
							ds.Tables[0].Rows.Add(r2);
						}
						if (decimal.Parse(r["c05"].ToString())+decimal.Parse(r["c06"].ToString())>0)
						{
							r2=ds.Tables[0].NewRow();
							r2["loai"]=r["loai"].ToString();
							r2["mabn"]=r["ma"].ToString();
							r2["hoten"]=r3["ten"].ToString();
							r2["tenkp"]="CÓ GÂY MÊ";
							r2["ts"]=3;
							r2["c01"]=0;
							r2["c02"]=0;
							r2["c03"]=r["c05"].ToString();
							r2["c04"]=r["c06"].ToString();
							ds.Tables[0].Rows.Add(r2);
						}
					}
				}
			}
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,((tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text),"rpttkthcls_n.rpt");
				f.ShowDialog();
			}
		}
	}
}
