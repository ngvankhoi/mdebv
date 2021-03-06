﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data;
using LibDuoc;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptBcngay.
	/// </summary>
	public class frmThkhoa_ng : System.Windows.Forms.Form
	{
        Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_dongiale, i_userid=0;
		private string sql,s_kho,s_makho,s_makp,s_loaint,s_tenkho,s_tenkp,s_tenloai,user,stime,xxx;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private bool bChitiet;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdmkho=new DataTable();
		private DataTable dtkp=new DataTable();
		private DataTable dtloai=new DataTable();
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckBox chkChitiet;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckedListBox loai;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThkhoa_ng(AccessData acc,int nhom,string kho,string kp,string loaint,int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_loaint=loaint;
			s_makho=kho;s_makp=kp;
            i_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThkhoa_ng));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.chkChitiet = new System.Windows.Forms.CheckBox();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(82, 186);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "&In";
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(144, 186);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(60, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(59, 85);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 68);
            this.kho.TabIndex = 5;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(59, 6);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(171, 6);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            // 
            // chkChitiet
            // 
            this.chkChitiet.Location = new System.Drawing.Point(61, 161);
            this.chkChitiet.Name = "chkChitiet";
            this.chkChitiet.Size = new System.Drawing.Size(155, 24);
            this.chkChitiet.TabIndex = 9;
            this.chkChitiet.Text = "Số lượng && đơn giá";
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(254, 5);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 212);
            this.makp.TabIndex = 6;
            // 
            // loai
            // 
            this.loai.CheckOnClick = true;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(59, 30);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(192, 52);
            this.loai.TabIndex = 4;
            // 
            // frmThkhoa_ng
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThkhoa_ng";
            this.ResumeLayout(false);

		}
		#endregion

		private void frmThkhoa_ng_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			i_dongiale=d.d_dongia_le(i_nhom);
			sql="select * from "+user+".d_duockp ";
			sql+=" where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="")  sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtkp=d.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			
			sql="select * from "+user+".d_dmloaint where nhom="+i_nhom;
			if (s_loaint!="") sql+=" and id in ("+s_loaint.Substring(0,s_loaint.Length-1)+")";
			sql+=" order by stt";
			dtloai=d.get_data(sql).Tables[0];
            loai.DataSource = dtloai;
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			
			sql="select a.*,b.stt as sttnhom,b.ten as tennhom,c.ten as tenhang ";
            sql += " from " + user + ".d_dmbd a," + user + ".d_dmnhom b," + user + ".d_dmhang c where a.manhom=b.id and a.mahang=c.id and a.nhom=" + i_nhom;
			dt=d.get_data(sql).Tables[0];
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
            kho.DataSource = dtdmkho;
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			
			ds.ReadXml("..\\..\\..\\xml\\d_thkhoa.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_thkhoa.xml");
		}

		private void get_xuat(string s_mmyy)
		{
            xxx = user + s_mmyy;
			sql="select b.mabd,";
			if (bChitiet) sql+="round(t.giamua,"+i_dongiale+") as dongia,";
			else sql+="0 as dongia,";
			sql+="sum(b.soluong) as soluong from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom+" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_makp!="") sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			if (s_loaint!="") sql+=" and a.loai in ("+s_loaint.Substring(0,s_loaint.Length-1)+")";
			sql+=" group by b.mabd";
			if (bChitiet) sql+=",round(t.giamua,"+i_dongiale+")";
			ins_items();
		}

		private void ins_items()
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r3!=null)
				{
					sql="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
					r1=d.getrowbyid(ds.Tables[0],sql);
					if ( r1 == null )
					{
						r2 = ds.Tables[0].NewRow();
						r2["stt"]=r3["sttnhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tenhang"]=r3["tenhang"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["sotien"]=decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["dongia"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
					else
					{
						dr = ds.Tables[0].Select(sql);
						dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["soluong"].ToString())*decimal.Parse(r["dongia"].ToString());
					}
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


		private void butIn_Click(object sender, System.EventArgs e)
		{
			bChitiet=chkChitiet.Checked;
			if (!kiemtra()) return;
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("true","stt,ma"));
			string title=(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text;
			if (s_tenkho!="") s_tenkho=s_tenkho.Substring(0,s_tenkho.Length-1);
			s_tenkho+=(s_tenkp!="")?" KHOA "+s_tenkp.Substring(0,s_tenkp.Length-1):"";
			s_tenkho+=(s_tenloai!="")?";"+s_tenloai.Substring(0,s_tenloai.Length-1):"";
			frmReport f1=new frmReport(d,dsxml.Tables[0],i_userid,(bChitiet)?"d_thkhoa_ct.rpt":"d_thkhoa.rpt",s_tenkho,title,"","","","","","","","");
			f1.ShowDialog(this);
		}

		private bool kiemtra()
		{
			s_kho="";s_makp="";s_loaint="";s_tenkho="";s_tenkp="";s_tenloai="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++) 
				if (kho.GetItemChecked(i)) 
				{
					s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
					s_tenkho+=dtdmkho.Rows[i]["ten"].ToString().Trim()+",";
				}
			for(int i=0;i<makp.Items.Count;i++) 
				if (makp.GetItemChecked(i)) 
				{
					s_makp+=dtkp.Rows[i]["id"].ToString()+",";
					s_tenkp+=dtkp.Rows[i]["ten"].ToString().Trim()+",";
				}
			for(int i=0;i<loai.Items.Count;i++) 
				if (loai.GetItemChecked(i)) 
				{
					s_loaint+=dtloai.Rows[i]["id"].ToString()+",";
					s_tenloai+=dtloai.Rows[i]["ten"].ToString().Trim()+",";
				}
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";		
			ds.Clear();
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy)) get_xuat(mmyy);
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
