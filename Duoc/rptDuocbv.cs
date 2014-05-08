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
	/// Summary description for rptDuocbv.
	/// </summary>
	public class rptDuocbv : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private AccessData d;
        private int i_nhom, i_userid=0;
		private bool bClear=true;
		private string sql,s_kho;
		private DataRow r1,r2,r3;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdmkho=new DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.CheckedListBox kho;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptDuocbv(AccessData acc,int nhom,string kho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptDuocbv));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(134, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 12);
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
            this.den.Location = new System.Drawing.Point(169, 12);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(53, 190);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(75, 26);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(130, 190);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 26);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 35);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 2;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(56, 58);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(192, 21);
            this.nhomcc.TabIndex = 3;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-4, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nhóm CC :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 81);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 100);
            this.kho.TabIndex = 4;
            // 
            // rptDuocbv
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 231);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptDuocbv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dược bệnh viện";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptDuocbv_MouseMove);
            this.Load += new System.EventHandler(this.rptDuocbv_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptDuocbv_Load(object sender, System.EventArgs e)
		{
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;

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
			dt=d.get_data("select a.*,b.ten tennhom from d_dmbd a,d_nhombo b where a.nhombo=b.id and a.nhom="+i_nhom+" order by a.id").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_duocbv.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_duocbv.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++) if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
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

			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,"d_duocbv.rpt",(tu.Text==den.Text)?" Ngày :"+tu.Text:"Từ ngày :"+tu.Text+" đến :"+den.Text,(kho.SelectedIndex==-1)?"":"Của kho :"+kho.Text,(manguon.SelectedIndex==-1)?"":"Nguồn :"+manguon.Text,(nhomcc.SelectedIndex==-1)?"":" Nhóm nhà cung cấp :"+nhomcc.Text,"DƯỢC BỆNH VIỆN","","","","","");
			f.ShowDialog();
		}

		private void get_sort()
		{
			dsxml.Clear();
			DataRow []dr=ds.Tables[0].Select("ten<>''","ten");
			for(int i=0;i<dr.Length;i++)
			{
				r2 = dsxml.Tables[0].NewRow();
				r2["id"]=dr[i]["id"].ToString();
				r2["ten"]=dr[i]["ten"].ToString().Trim();
				r2["sotien"]=dr[i]["sotien"].ToString();
				dsxml.Tables[0].Rows.Add(r2);
			}
		}
		private void get_xuat(string d_mmyy)
		{
			sql="select c.nhombo,sum(b.soluong*b.giamua) sotien from d_xuatsdll a,d_thucxuat b,"+d.user+".d_dmbd c where a.id=b.id and b.mabd=c.id and a.loai<>3 and a.nhom="+i_nhom+" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by c.nhombo";
			sql+=" union all select c.nhombo,sum(b.soluong*b.giamua) sotien from d_ngtrull a,d_ngtruct b,"+d.user+".d_dmbd c where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by c.nhombo";
			sql+=" union all select c.nhombo,sum(b.soluong*b.giamua) sotien from d_xuatll a,d_xuatct b,"+d.user+".d_dmbd c where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy') and a.loai='XK'";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by c.nhombo";
			sql+=" union all select c.nhombo,sum(b.soluong*b.giamua) sotien from bhytkb a,bhytthuoc b,"+d.user+".d_dmbd c where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by c.nhombo";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"id="+int.Parse(r["nhombo"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"nhombo="+int.Parse(r["nhombo"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["id"]=r["nhombo"].ToString();
						r2["ten"]=r3["tennhom"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("id="+int.Parse(r["nhombo"].ToString()));
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
			sql="select c.nhombo,sum(b.soluong*b.giamua) sotien from d_xuatsdll a,d_thucxuat b,"+d.user+".d_dmbd c where a.id=b.id and b.mabd=c.id and a.loai=3 and a.nhom="+i_nhom+" and to_date(a.ngay,'dd/mm/yy') between to_date('"+tu.Text+"','dd/mm/yy') and to_date('"+den.Text+"','dd/mm/yy')";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and b.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (nhomcc.SelectedIndex!=-1) sql+=" and b.nhomcc="+int.Parse(nhomcc.SelectedValue.ToString());
			sql+=" group by c.nhombo";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"id="+int.Parse(r["nhombo"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["nhombo"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["id"]=r["nhombo"].ToString();
						r2["ten"]=r3["tennhom"].ToString();
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select("id="+int.Parse(r["nhombo"].ToString()));
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

		private void rptDuocbv_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				nhomcc.SelectedIndex=-1;
				bClear=false;
			}
		}
	}
}
