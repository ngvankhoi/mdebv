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
	/// Summary description for rptBbknhap.
	/// </summary>
	public class rptBkhoadon : System.Windows.Forms.Form
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
		private string sql,s_madv,s_kho,user,xxx,stime;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds=new DataSet();
		private DataTable dt=new DataTable();
		private DataSet dsdmnx;
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.Label label12;
		private MaskedTextBox.MaskedTextBox c18;
		private MaskedTextBox.MaskedTextBox c12;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butLoc;
		private System.Windows.Forms.CheckedListBox madv;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBkhoadon(AccessData acc,int nhom,string kho, int _userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBkhoadon));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.c18 = new MaskedTextBox.MaskedTextBox();
            this.c12 = new MaskedTextBox.MaskedTextBox();
            this.kho = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.butLoc = new System.Windows.Forms.Button();
            this.madv = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(130, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(52, 10);
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
            this.den.Location = new System.Drawing.Point(165, 10);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(255, 236);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 9;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(325, 236);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // c18
            // 
            this.c18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c18.Location = new System.Drawing.Point(776, 270);
            this.c18.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c18.Name = "c18";
            this.c18.Size = new System.Drawing.Size(234, 21);
            this.c18.TabIndex = 38;
            this.c18.Text = "Thủ kho - Ủy viên";
            this.c18.Visible = false;
            // 
            // c12
            // 
            this.c12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c12.Location = new System.Drawing.Point(776, 126);
            this.c12.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(234, 21);
            this.c12.TabIndex = 20;
            this.c12.Text = "Trưởng phòng KHTH - Ủy viên";
            this.c12.Visible = false;
            // 
            // kho
            // 
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(280, 10);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(112, 21);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(248, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 4;
            this.label12.Text = "Kho :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(432, 10);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(112, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kho_KeyDown);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(392, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 23);
            this.label14.TabIndex = 6;
            this.label14.Text = "Nguồn";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butLoc
            // 
            this.butLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLoc.Location = new System.Drawing.Point(185, 236);
            this.butLoc.Name = "butLoc";
            this.butLoc.Size = new System.Drawing.Size(70, 25);
            this.butLoc.TabIndex = 8;
            this.butLoc.Text = "&Tìm";
            this.butLoc.Click += new System.EventHandler(this.butLoc_Click);
            // 
            // madv
            // 
            this.madv.CheckOnClick = true;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(52, 34);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(492, 196);
            this.madv.TabIndex = 11;
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptBkhoadon
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(554, 279);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.butLoc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.c18);
            this.Controls.Add(this.c12);
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
            this.Name = "rptBkhoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng kê hoá đơn mua hàng";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBkhoadon_MouseMove);
            this.Load += new System.EventHandler(this.rptBkhoadon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptBkhoadon_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'"; 
            madv.DisplayMember = "TEN";
			madv.ValueMember="ID";
			dt=d.get_data("select * from "+user+".d_dmnx where nhom="+i_nhom+" order by stt").Tables[0];

			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			kho.DataSource=d.get_data(sql).Tables[0];
			//
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			sql="select * from "+user+".d_dmnguon ";
			if (d.bQuanlynguon(i_nhom)) sql+=" where nhom="+i_nhom;
			else sql+=" where id=0";
			sql+=" order by stt";
			manguon.DataSource=d.get_data(sql).Tables[0];
			manguon.SelectedIndex=-1;

			ds.ReadXml("..\\..\\..\\xml\\d_bkhoadon.xml");
            ds.Tables[0].Columns.Add("sodangky");
			//
			manguon.Enabled=d.bQuanlynguon(i_nhom);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_madv="";
			for(int i=0;i<madv.Items.Count;i++)
				if (madv.GetItemChecked(i)) s_madv+=dsdmnx.Tables[0].Rows[i]["id"].ToString()+",";
			ds.Clear();
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
					if (d.bMmyy(mmyy)) get_nhap(mmyy);
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
            if (System.IO.Directory.Exists("..\\..\\dataxml") == false) System.IO.Directory.CreateDirectory("..\\..\\dataxml");
            ds.WriteXml("..\\..\\dataxml\\d_Bkhoadon.xml", XmlWriteMode.WriteSchema);
			frmReport f=new frmReport(d,ds.Tables[0], i_userid,"d_Bkhoadon.rpt",(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"","","","","","","","","");
			f.ShowDialog();
		}

		private void get_nhap(string d_mmyy)
		{
            xxx = user + d_mmyy;
			string ten="";
            sql = "select c.id,b.stt,b.mabd,trim(d.ten)||' '||trim(d.hamluong)||' '||d.dang as tenbd,a.sohd,to_char(a.ngayhd,'dd/mm/yyyy') as ngayhd,b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu as sotien,b.sodangky ";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmnx c," + user + ".d_dmbd d";
			sql+=" where a.id=b.id and a.madv=c.id and b.mabd=d.id and a.nhom="+i_nhom;
			sql+=" and a.ngayhd between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (kho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(kho.SelectedValue.ToString());
			if (s_madv!="") sql+=" and a.madv in ("+s_madv.Substring(0,s_madv.Length-1)+")";
			if(manguon.SelectedIndex!=-1 && manguon.Enabled) sql+=" and a.manguon="+manguon.SelectedValue.ToString();
			sql+=" order by c.id,a.sohd,to_char(a.ngayhd,'dd/mm/yyyy'),b.stt";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(dt,"id="+int.Parse(r["id"].ToString()));
				if (r1!=null)
				{
					sql="id="+decimal.Parse(r["id"].ToString())+" and sohd='"+r["sohd"].ToString()+"' and ngayhd='"+r["ngayhd"].ToString()+"'";
					r2=d.getrowbyid(ds.Tables[0],sql);
					if (r2==null)
					{
						r3=ds.Tables[0].NewRow();
						r3["id"]=r["id"].ToString();
						r3["sohd"]=r["sohd"].ToString();
						r3["ngayhd"]=r["ngayhd"].ToString();
						r3["ten"]=r1["ten"].ToString();
						r3["diachi"]=r1["diachi"].ToString();
						r3["dienthoai"]=r1["dienthoai"].ToString();
						r3["masothue"]=r1["masothue"].ToString();
						r3["sotk"]=r1["sotk"].ToString();
						r3["stt"]=r["stt"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["diengiai"]=r["tenbd"].ToString().Trim();
						r3["sotien"]=r["sotien"].ToString();
                        r3["sodangky"] = r["sodangky"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							ten=dr[0]["diengiai"].ToString().Trim()+";";
							ten+=r["tenbd"].ToString().Trim();
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
							dr[0]["diengiai"]=ten;
						}
					}
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void rptBkhoadon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				if (manguon.Enabled) manguon.SelectedIndex=-1;
				kho.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void kho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void butLoc_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			dsdmnx=new DataSet();
			DateTime dt1=d.StringToDate(tu.Text.Substring(0,10)).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text.Substring(0,10)).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			bool be=true;
			string mmyy="",sql;
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						sql="select distinct b.* from "+xxx+".d_nhapll a,"+user+".d_dmnx b where a.madv=b.id";
						sql+=" and a.ngayhd between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
						if (kho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(kho.SelectedValue.ToString());
						if (manguon.SelectedIndex!=-1 && manguon.Enabled) sql+=" and a.manguon="+int.Parse(manguon.SelectedValue.ToString());
						sql+=" and a.nhom="+i_nhom;
						if (be) dsdmnx=d.get_data(sql);
						else dsdmnx.Merge(d.get_data(sql));
						be=false;
					}
				}
			}
			madv.DataSource=dsdmnx.Tables[0];
            madv.DisplayMember = "TEN";
            madv.ValueMember = "ID";
			Cursor=Cursors.Default;
		}
	}
}
