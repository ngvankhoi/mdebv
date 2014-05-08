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
	public class frmbcthcls : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataTable dtloai=new DataTable();
		private DataTable dtkh=new DataTable();
		private string sql,mmyy,user,xxx;
		private int namsinh;
		private AccessData m;
		private System.Windows.Forms.NumericUpDown mm;
		private System.Windows.Forms.NumericUpDown yyyy;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmbcthcls(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbcthcls));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIN = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.mm = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(110, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(38, 66);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(75, 25);
            this.butIN.TabIndex = 4;
            this.butIN.Text = "&In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(114, 66);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // mm
            // 
            this.mm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mm.Location = new System.Drawing.Point(54, 24);
            this.mm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(56, 23);
            this.mm.TabIndex = 1;
            this.mm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(150, 24);
            this.yyyy.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(56, 23);
            this.yyyy.TabIndex = 3;
            this.yyyy.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmbcthcls
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(224, 117);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmbcthcls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tháng khu chẩn đoán hình";
            this.Load += new System.EventHandler(this.frmbcthcls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmbcthcls_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			ds.ReadXml("..//..//..//xml//m_tkcls.xml");
			mm.Value=DateTime.Now.Month;
			yyyy.Value=DateTime.Now.Year;
			dtloai=m.get_data("select * from "+user+".cls_loai").Tables[0];
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			namsinh=int.Parse(yyyy.Value.ToString());
			mmyy=mm.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
            xxx = user + mmyy;
			dtkh=m.get_data("select * from "+user+".cls_kehoach where mmyy='"+mmyy+"'").Tables[0];
			DataRow  r1,r2,r3,r4;
			DataRow [] dr;
			ds.Clear();
			sql="select a.loai,sum(1) as ts,";
			sql+=" sum(case when a.loaibn=0 then 1 else 0 end) as c02,";
			sql+=" sum(case when "+namsinh+"-to_number(b.namsinh)<=14 then 1 else 0 end) as c03,";
			sql+=" sum(case when a.madoituong=1 then 1 else 0 end) as c04,";
			sql+=" sum(case when a.madoituong<>1 and c.mien=0 then 1 else 0 end) as c05,";
			sql+=" sum(case when a.madoituong<>1 and c.mien=1 then 1 else 0 end) as c06";
			sql+=" from "+xxx+".cls_thuchien a,"+user+".btdbn b,"+user+".doituong c";
			sql+=" where a.mabn=b.mabn and a.madoituong=c.madoituong";
			sql+=" and to_char(a.ngay,'mmyy')='"+mmyy+"'";
			sql+=" group by a.loai";
			sql+=" order by a.loai";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				r1=m.getrowbyid(dtloai,"id="+int.Parse(r["loai"].ToString()));
				if (r1!=null)
				{
					sql="loai="+int.Parse(r["loai"].ToString());
					r2=m.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{	
						r3=ds.Tables[0].NewRow();
						r3["loai"]=r["loai"].ToString();
						r3["hoten"]=r1["ten"].ToString();
						r4=m.getrowbyid(dtkh,"id="+int.Parse(r["loai"].ToString()));
						if (r4!=null) r3["c01"]=r4["so"].ToString();
						else r3["c01"]=0;
						r3["ts"]=r["ts"].ToString();
						r3["c02"]=r["c02"].ToString();
						r3["c03"]=r["c03"].ToString();
						r3["c04"]=r["c04"].ToString();
						r3["c05"]=r["c05"].ToString();
						r3["c06"]=r["c06"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							dr[0]["ts"]=decimal.Parse(dr[0]["ts"].ToString())+decimal.Parse(r["ts"].ToString());
							dr[0]["c02"]=decimal.Parse(dr[0]["c02"].ToString())+decimal.Parse(r["c02"].ToString());
							dr[0]["c03"]=decimal.Parse(dr[0]["c03"].ToString())+decimal.Parse(r["c03"].ToString());
							dr[0]["c04"]=decimal.Parse(dr[0]["c04"].ToString())+decimal.Parse(r["c04"].ToString());
							dr[0]["c05"]=decimal.Parse(dr[0]["c05"].ToString())+decimal.Parse(r["c05"].ToString());
							dr[0]["c06"]=decimal.Parse(dr[0]["c06"].ToString())+decimal.Parse(r["c06"].ToString());
						}
					}
				}
			}
			Cursor=Cursors.Default;
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,ds,
lan.Change_language_MessageText("Tháng")+" "+mm.Value.ToString().PadLeft(2,'0')+" "+
lan.Change_language_MessageText("năm")+" "+yyyy.Value.ToString(),"rptbcthcls.rpt");
				f.ShowDialog();
			}
		}
	}
}
