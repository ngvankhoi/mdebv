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
	/// Summary description for rptTh_chitiet.
	/// </summary>
	public class rptTh_chitiet : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom = 0, i_userid=0;
		private bool bClear=true;
		private string sql,s_mmyy,s_sotk,user,xxx;
		private DataRow r1,r2,r3;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtnhom=new DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.ComboBox nhom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptTh_chitiet(AccessData acc,int nhom,string mmyy, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
            i_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptTh_chitiet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(58, 81);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(130, 81);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // nhom
            // 
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(56, 46);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(192, 21);
            this.nhom.TabIndex = 3;
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(56, 22);
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
            this.yyyy.Location = new System.Drawing.Point(200, 22);
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
            // rptTh_chitiet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 124);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptTh_chitiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp chi tiết vật liệu,dụng cụ,sản phẩm,hàng hóa";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptTh_chitiet_MouseMove);
            this.Load += new System.EventHandler(this.rptTh_chitiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptTh_chitiet_Load(object sender, System.EventArgs e)
		{
            user = d.user; xxx = user + s_mmyy;
			dtnhom=d.get_data("select * from "+user+".d_dmnhomkt where nhom="+i_nhom+" order by stt").Tables[0];
			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			nhom.DataSource=dtnhom;
			dt=d.get_data("select * from "+user+".d_dmbd where nhom="+i_nhom+" order by id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_nxttonghop.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_nxttonghop.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (nhom.SelectedIndex==-1) s_sotk="";
			else
			{
				r1=d.getrowbyid(dtnhom,"id="+int.Parse(nhom.SelectedValue.ToString()));
				if (r1!=null) s_sotk=r1["ma"].ToString();
			}
			ds.Clear();
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			get_tondau(s_mmyy);
			get_nhap(s_mmyy);
			get_xuat(s_mmyy);
			get_hoantra(s_mmyy);
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,"d_thchitiet.rpt","Tháng "+s_mmyy.Substring(0,2)+"/"+s_mmyy.Substring(2,2),(nhom.SelectedIndex==-1)?"":"Tài khoản :"+nhom.Text,s_sotk,"","","","","","","");
			f.ShowDialog();
		}

		private void get_sort()
		{
			dsxml.Clear();
			DataRow []dr=ds.Tables[0].Select("ma<>''","ten");
			for(int i=0;i<dr.Length;i++)
			{
				r2 = dsxml.Tables[0].NewRow();
				r2["mabd"]=dr[i]["mabd"].ToString();
				r2["ma"]=dr[i]["ma"].ToString();
				r2["ten"]=dr[i]["ten"].ToString().Trim();
				r2["tenhc"]=dr[i]["tenhc"].ToString();
				r2["dang"]=dr[i]["dang"].ToString();
				r2["tondau"]=dr[i]["tondau"].ToString();
				r2["sttondau"]=dr[i]["sttondau"].ToString();
				r2["slnhap"]=dr[i]["slnhap"].ToString();
				r2["stnhap"]=dr[i]["stnhap"].ToString();
				r2["slxuat"]=dr[i]["slxuat"].ToString();
				r2["stxuat"]=dr[i]["stxuat"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
			}
		}
		private void get_tondau(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select a.mabd,sum(a.tondau) as soluong,sum(a.tondau*t.giamua) as sotien from "+xxx+".d_tonkhoct a,"+xxx+".d_theodoi t,"+user+".d_dmbd b where a.stt=t.id and a.mabd=b.id and b.nhom="+i_nhom;
			if (nhom.SelectedIndex!=-1) sql+=" and b.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by a.mabd";
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
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=r["soluong"].ToString();
						r2["sttondau"]=r["sotien"].ToString();
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sttondau"]=decimal.Parse(dr[0]["sttondau"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_nhap(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select b.mabd,sum(b.soluong) as soluong,sum(round(b.sotien+b.sotien*b.vat/100,3)) as sotien from "+xxx+".d_nhapll a,"+xxx+".d_nhapct b,"+user+".d_dmbd c where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom;
			if (nhom.SelectedIndex!=-1) sql+=" and c.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by b.mabd";
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
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=r["soluong"].ToString();
						r2["stnhap"]=r["sotien"].ToString();
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["slnhap"]=decimal.Parse(dr[0]["slnhap"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["stnhap"]=decimal.Parse(dr[0]["stnhap"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select b.mabd,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai<>3 and a.nhom="+i_nhom;
			if (nhom.SelectedIndex!=-1) sql+=" and c.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by b.mabd";
			sql+=" union all select b.mabd,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom;
			if (nhom.SelectedIndex!=-1) sql+=" and c.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by b.mabd";
			sql+=" union all select b.mabd,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom+" and a.loai='XK'";
			if (nhom.SelectedIndex!=-1) sql+=" and c.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by b.mabd";
			sql+=" union all select b.mabd,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom;
			if (nhom.SelectedIndex!=-1) sql+=" and c.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by b.mabd";			
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
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=r["soluong"].ToString();
						r2["stxuat"]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["slxuat"]=decimal.Parse(dr[0]["slxuat"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["stxuat"]=decimal.Parse(dr[0]["stxuat"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select b.mabd,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 and a.nhom="+i_nhom;
			if (nhom.SelectedIndex!=-1) sql+=" and c.sotk="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" group by b.mabd";
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
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=-decimal.Parse(r["soluong"].ToString());
						r2["stxuat"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["slxuat"]=decimal.Parse(dr[0]["slxuat"].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["stxuat"]=decimal.Parse(dr[0]["stxuat"].ToString())-decimal.Parse(r["sotien"].ToString());
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


		private void rptTh_chitiet_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				nhom.SelectedIndex=-1;
				bClear=false;
			}
		}
	}
}
