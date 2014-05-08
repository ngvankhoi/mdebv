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
	public class frmtkbscls : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataTable dtbs=new DataTable();
		private DataTable dtkp=new DataTable();
		private string sql,user,stime;
		private AccessData m;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmtkbscls(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m=acc;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtkbscls));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // loai
            // 
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(56, 32);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 21);
            this.loai.TabIndex = 5;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(36, 72);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(91, 25);
            this.butIN.TabIndex = 6;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(129, 72);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(92, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // frmtkbscls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 117);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmtkbscls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê theo bác sỹ";
            this.Load += new System.EventHandler(this.frmtkbscls_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmtkbscls_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			dtbs=m.get_data("select * from "+user+".dmbs").Tables[0];
			dtkp=m.get_data("select * from "+user+".btdkp_bv").Tables[0];
			ds.ReadXml("..//..//..//xml//m_tkcls.xml");
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=m.get_data("select * from "+user+".cls_loai order by id").Tables[0];
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			DataRow r1,r2,r3,r4;
			DataRow [] dr;
			ds.Clear();
			sql="select 0 as loai,b.ma,a.makp,sum(case when d.id is null then 1 else case when g.mat=0 then 1 else d.mp+d.mt end end) as so ";
            sql+="from xxx.cls_thuchien a inner join "+user+".dmbs b on a.bsth=b.ma ";
            sql+=" inner join "+user+".btdkp_bv c on a.makp=c.makp ";
            sql+=" left join xxx.cls_mat d on a.id=d.id ";
            sql+=" inner join "+user+".cls_loai g on a.loai=g.id";
            sql += " where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai="+int.Parse(loai.SelectedValue.ToString());
			sql+=" group by b.ma,a.makp";
			sql+=" union all ";
			sql+=" select 1 as loai,b.ma,a.makp,count(*) as so ";
            sql+="from xxx.cls_thuchien a inner join "+user+".dmbs b on a.ytaphu=b.ma ";
            sql+=" inner join "+user+".btdkp_bv c on a.makp=c.makp ";
            sql+=" inner join "+user+".cls_loai g on a.loai=g.id";
            sql+=" where " + m.for_ngay("a.ngay", stime) + " between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.loai="+int.Parse(loai.SelectedValue.ToString());
			sql+=" group by b.ma,a.makp";
			foreach(DataRow r in m.get_data_mmyy(sql,tu.Text,den.Text,false).Tables[0].Rows)
			{
				r1=m.getrowbyid(dtbs,"ma='"+r["ma"].ToString()+"'");
				if (r1!=null)
				{
					sql="loai="+int.Parse(r["loai"].ToString())+" and mabn='"+r["ma"].ToString()+"'";
					r2=m.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{
						r3=ds.Tables[0].NewRow();
						r3["loai"]=r["loai"].ToString();
						r3["mabn"]=r["ma"].ToString();
						r3["hoten"]=r1["hoten"].ToString();
						r3["c01"]=(r["loai"].ToString()=="0")?decimal.Parse(r["so"].ToString()):0;
						r3["c02"]=(r["loai"].ToString()=="1")?decimal.Parse(r["so"].ToString()):0;
						r4=m.getrowbyid(dtkp,"makp='"+r["makp"].ToString()+"'");
						if (r4!=null) r3["tenkp"]=r4["tenkp"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							dr[0]["c01"]=decimal.Parse(dr[0]["c01"].ToString())+((r["loai"].ToString()=="0")?decimal.Parse(r["so"].ToString()):0);
							dr[0]["c02"]=decimal.Parse(dr[0]["c02"].ToString())+((r["loai"].ToString()=="1")?decimal.Parse(r["so"].ToString()):0);
						}
					}
				}
			}
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,loai.Text.Trim().ToUpper()+","+((tu.Text==den.Text)?"Ngày :"+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text),"rpttkbscls.rpt");
				f.ShowDialog();
			}
		}
	}
}
