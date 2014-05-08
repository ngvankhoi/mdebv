using System;
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
	public class frmThkhoa : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_dongiale, d_userid=0;
		private string sql,s_kho,s_makho,s_makp,user,stime,xxx,s_tenkho;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private bool bChitiet;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtdmkho=new DataTable();
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.CheckBox chkChitiet;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThkhoa(AccessData acc,int nhom,string kho,string kp, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;
			s_makho=kho;s_makp=kp;
            d_userid = _userid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThkhoa));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.chkChitiet = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(138, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(74, 194);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(74, 25);
            this.butIn.TabIndex = 4;
            this.butIn.Text = "       &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(148, 194);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(74, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(61, 38);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Khoa :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(61, 61);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 100);
            this.kho.TabIndex = 3;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(61, 14);
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
            this.den.Location = new System.Drawing.Point(173, 14);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkChitiet
            // 
            this.chkChitiet.Location = new System.Drawing.Point(63, 165);
            this.chkChitiet.Name = "chkChitiet";
            this.chkChitiet.Size = new System.Drawing.Size(155, 24);
            this.chkChitiet.TabIndex = 9;
            this.chkChitiet.Text = "Số lượng && đơn giá";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(278, 259);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkChitiet);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.makp);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(270, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xuất kho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(270, 233);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(264, 227);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "- Tổng hợp phiếu Xuất khoa, bao gồm:\n1. Phiếu lĩnh\n2. Phiếu lĩnh hao phí\n3. Bù cơ" +
                " số tủ trực\n4. Xuất bổ sung Cơ số tủ trực\nTrừ đi:\n1. Hoàn trả thừa\n2. Thu hồi cơ" +
                " số tủ trực";
            // 
            // frmThkhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(278, 259);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThkhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp phiếu xuất theo khoa";
            this.Load += new System.EventHandler(this.frmThkhoa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmThkhoa_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			i_dongiale=d.d_dongia_le(i_nhom);
			sql="select * from "+user+".d_duockp ";
			sql+=" where nhom like '%"+i_nhom.ToString()+",%'";
			//if (s_makp.Trim().Trim(',')!="")  sql+=" and makp in ("+s_makp.Substring(0,s_makp.Length-1)+")";
            if (s_makp.Trim().Trim(',') != "") sql += " and id in (" + s_makp.Trim().Trim(',') + ")";
			sql+=" order by stt";
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
			makp.DataSource=d.get_data(sql).Tables[0];
			sql="select a.*,b.stt as sttnhom,b.ten as tennhom,c.ten as tenhang ";
			sql+=" from "+user+".d_dmbd a,"+user+".d_dmnhom b,"+user+".d_dmhang c where a.manhom=b.id and a.mahang=c.id and a.nhom="+i_nhom;
			dt=d.get_data(sql).Tables[0];
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
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
			sql+="sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in(1,4) and a.nhom=" + i_nhom;
            sql+=" and a.ngay between to_date('" + tu.Text + "',"+stime+") and to_date('" + den.Text + "',"+stime+")";
			sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" group by b.mabd";
			if (bChitiet) sql+=",round(t.giamua,"+i_dongiale+")";
			ins_items();
			//bu tu truc
			sql="select b.mabd,";
			if (bChitiet) sql+="round(t.giamua,"+i_dongiale+") as dongia,";
			else sql+="0 as dongia,";
			sql+="sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucbucstt b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in (2) and a.nhom=" + i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" group by b.mabd";
			if (bChitiet) sql+=",round(t.giamua,"+i_dongiale+")";
			ins_items();
			//hoantra
			sql="select b.mabd,";
			if (bChitiet) sql+="round(t.giamua,"+i_dongiale+") as dongia,";
			else sql+="0 as dongia,";
			sql+="-sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+xxx+".d_theodoi t ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in (3) and a.nhom=" + i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" group by b.mabd";
			if (bChitiet) sql+=",round(t.giamua,"+i_dongiale+")";
			ins_items();
            //Thu hoi+Hoan tra
            sql = "select b.mabd,";
            if (bChitiet) sql += "round(t.giamua," + i_dongiale + ") as dongia,";
            else sql += "0 as dongia,";
            sql += "-sum(b.soluong) as soluong from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in ('TH','HT') and a.nhom=" + i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and a.khox=" + int.Parse(makp.SelectedValue.ToString());
            if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            sql += " group by b.mabd";
            if (bChitiet) sql += ",round(t.giamua," + i_dongiale + ")";
            ins_items();
            //bo sung cstt
            sql = "select b.mabd,";
            if (bChitiet) sql += "round(t.giamua," + i_dongiale + ") as dongia,";
            else sql += "0 as dongia,";
            sql += "sum(b.soluong) as soluong from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in ('BS') and a.nhom=" + i_nhom;
            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and a.khon=" + int.Parse(makp.SelectedValue.ToString());
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            sql += " group by b.mabd";
            if (bChitiet) sql += ",round(t.giamua," + i_dongiale + ")";
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
			frmReport f1=new frmReport(d,dsxml.Tables[0],d_userid,(bChitiet)?"d_thkhoa_ct.rpt":"d_thkhoa.rpt","KHOA :"+makp.Text.Trim(),title,s_tenkho.Trim().Trim(','),"","","","","","","");
			f1.ShowDialog(this);
		}

		private bool kiemtra()
		{
            s_kho = ""; s_tenkho = "";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
            for (int i = 0; i < kho.Items.Count; i++)
            {
                if (kho.GetItemChecked(i))
                {
                    s_kho += dtdmkho.Rows[i]["id"].ToString() + ",";
                    s_tenkho += dtdmkho.Rows[i]["ten"].ToString() + ", ";
                }
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
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return false;
			}
			return true;
		}		
	}
}
