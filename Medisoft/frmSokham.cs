using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmtkdscls.
	/// </summary>
	public class frmSokham : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds;
		private DataSet dsxml;
		private DataSet dsxt=new DataSet();
		private DataSet dsdt=new DataSet();
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		private System.Data.DataTable dtxt=new System.Data.DataTable();
		private System.Data.DataTable dtdt=new System.Data.DataTable();
		private System.Data.DataTable dtthuoc=new System.Data.DataTable();
		private System.Data.DataTable dtduoc=new System.Data.DataTable();
		private string sql,s_makp;
		private int namsinh,soluongle;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private System.Windows.Forms.CheckedListBox makp;
		private DataColumn dc;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.CheckBox chkThuoc;
		private System.Windows.Forms.CheckBox chkDuoc;
		private System.Windows.Forms.CheckBox chkDuyet;
        private string user = "";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSokham(LibMedi.AccessData acc,string _makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            m = acc;
			s_makp=_makp;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSokham));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.chkDuoc = new System.Windows.Forms.CheckBox();
            this.chkDuyet = new System.Windows.Forms.CheckBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIN = new System.Windows.Forms.Button();
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
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(55, 32);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 100);
            this.makp.TabIndex = 4;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkThuoc
            // 
            this.chkThuoc.Checked = true;
            this.chkThuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThuoc.Location = new System.Drawing.Point(56, 136);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(184, 24);
            this.chkThuoc.TabIndex = 7;
            this.chkThuoc.Text = "Kèm theo thuốc + cận lâm sàng";
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // chkDuoc
            // 
            this.chkDuoc.Checked = true;
            this.chkDuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuoc.Location = new System.Drawing.Point(56, 179);
            this.chkDuoc.Name = "chkDuoc";
            this.chkDuoc.Size = new System.Drawing.Size(184, 24);
            this.chkDuoc.TabIndex = 9;
            this.chkDuoc.Text = "Kèm cấp toa tại dược";
            // 
            // chkDuyet
            // 
            this.chkDuyet.Checked = true;
            this.chkDuyet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDuyet.Location = new System.Drawing.Point(56, 157);
            this.chkDuyet.Name = "chkDuyet";
            this.chkDuyet.Size = new System.Drawing.Size(184, 24);
            this.chkDuyet.TabIndex = 8;
            this.chkDuyet.Text = "Thuốc + cận lâm sàng đã duyệt";
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(130, 210);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIN
            // 
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(59, 210);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(70, 25);
            this.butIN.TabIndex = 5;
            this.butIN.Text = "    &In";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // frmSokham
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 253);
            this.Controls.Add(this.chkDuyet);
            this.Controls.Add(this.chkDuoc);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSokham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ khám bệnh";
            this.Load += new System.EventHandler(this.frmSokham_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmSokham_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a").Tables[0];
            dtxt = m.get_data("select * from " + user + ".xutrikb").Tables[0];
			dsxt.ReadXml("..//..//..//xml//m_xtdt.xml");
			dsdt.ReadXml("..//..//..//xml//m_xtdt.xml");
            sql = "select * from " + user + ".btdkp_bv where loai=1";
			if (s_makp!="")
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
            soluongle = d.d_soluong_le(m.nhom_duoc);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIN_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
			namsinh=int.Parse(tu.Text.ToString().Substring(6,4));
			s_makp="'";
			for(int i=0;i<makp.Items.Count;i++)
				if (makp.GetItemChecked(i)) s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+"','";
			dtthuoc.Clear();
			dtduoc.Clear();
            string m_tu=tu.Text.Substring(0,10);
            string m_den=den.Text.Substring(0,10);
            string stime="'"+m.f_ngay+"'";
			if (chkDuoc.Checked || chkDuyet.Checked)
			{
                sql = "select 0 as loai,a.maql,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.soluong," + soluongle + ") as soluong ";
				sql+=",a.mabn,d.hoten,case when d.phai=0 then to_char("+namsinh+"-to_number(d.namsinh,'0000')) else '' end as nam,";
				sql+="case when d.phai=1 then to_char("+namsinh+"-to_number(d.namsinh,'0000')) else '' end as nu,";
				sql+="trim(d.sonha)||' '||trim(d.thon)||' '||trim(g.tenpxa)||' '||trim(f.tenquan)||' '||trim(e.tentt) as diachi,";
				sql+="nullif(a.sothe,'') as sothe,'' as noigioithieu,'' as chandoan_gt,";
                sql += "a.chandoan as chandoan_kkb,'01,' as xutri,nullif(h.hoten,' ') as tenbs,a.maphu as madoituong,to_number('2') as nhantu";
				sql+=" from xxx.bhytkb a left join xxx.bhytthuoc b on a.id=b.id";
                sql+=" inner join "+user+".d_dmbd c on b.mabd=c.id";
                sql+=" inner join "+user+".btdbn d on a.mabn=d.mabn";
                sql+=" inner join "+user+".btdtt e on d.matt=e.matt";
                sql+=" inner join "+user+".btdquan f on d.maqu=f.maqu";
                sql+=" inner join "+user+".btdpxa g on d.maphuongxa=g.maphuongxa";
                sql+=" left join "+user+".dmbs h on a.mabs=h.ma";
                sql += " where a.id>0";
                if (m_tu != "")
                    sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
				if (s_makp.Length>1) sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" union all ";
				sql+="select 2 as loai,a.maql,c.ten,c.dvt as dang,1 as soluong ";
				sql+=",a.mabn,d.hoten,case when d.phai=0 then to_char("+namsinh+"-to_number(d.namsinh,'0000')) else '' end as nam,";
				sql+="case when d.phai=1 then to_char("+namsinh+"-to_number(d.namsinh,'0000')) else '' end as nu,";
				sql+="trim(d.sonha)||' '||trim(d.thon)||' '||trim(g.tenpxa)||' '||trim(f.tenquan)||' '||trim(e.tentt) as diachi,";
				sql+="nullif(a.sothe,'') as sothe,'' as noigioithieu,'' as chandoan_gt,";
                sql += "a.chandoan as chandoan_kkb,'01,' as xutri,nullif(h.hoten,' ') as tenbs,a.maphu as madoituong,to_number('2') as nhantu";
				sql+=" from xxx.bhytkb a left join xxx.bhytcls b on a.id=b.id";
                sql+=" inner join "+user+".v_giavp c on b.mavp=c.id";
                sql+=" inner join "+user+".btdbn d on a.mabn=d.mabn";
                sql+=" inner join "+user+".btdtt e on d.matt=e.matt";
                sql+=" inner join "+user+".btdquan f on d.maqu=f.maqu";
                sql+=" inner join "+user+".btdpxa g on d.maphuongxa=g.maphuongxa";
                sql+=" left join "+user+".dmbs h on a.mabs=h.ma";
				sql+=" where a.id>0";
                if (m_tu != "")
                    sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
				if (s_makp.Length>1) sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";				
                //
                //Toa thuoc mua ngoai
                sql += " UNION ALL ";
                sql += "select 0 as loai,a.maql,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.soluong," + soluongle + ") as soluong ";
                sql += ",a.mabn,d.hoten,case when d.phai=0 then to_char(" + namsinh + "-to_number(d.namsinh,'0000')) else '' end as nam,";
                sql += "case when d.phai=1 then to_char(" + namsinh + "-to_number(d.namsinh,'0000')) else '' end as nu,";
                sql += "trim(d.sonha)||' '||trim(d.thon)||' '||trim(g.tenpxa)||' '||trim(f.tenquan)||' '||trim(e.tentt) as diachi,";
                sql += "' ' as sothe,'' as noigioithieu,'' as chandoan_gt,";
                sql += " ab.chandoan as chandoan_kkb,'01,' as xutri,nullif(h.hoten,' ') as tenbs,to_number('2') as madoituong,to_number('2') as nhantu";
                sql += " from xxx.d_ngtrull a left join xxx.d_ngtruct b on a.id=b.id";
                sql += " inner join xxx.benhanpk ab on a.maql=ab.maql ";
                sql += " inner join " + user + ".d_dmbd c on b.mabd=c.id";
                sql += " inner join " + user + ".btdbn d on a.mabn=d.mabn";
                sql += " inner join " + user + ".btdtt e on d.matt=e.matt";
                sql += " inner join " + user + ".btdquan f on d.maqu=f.maqu";
                sql += " inner join " + user + ".btdpxa g on d.maphuongxa=g.maphuongxa";
                sql += " left join " + user + ".dmbs h on a.mabs=h.ma";
                sql += " where a.id>0";
                if (m_tu != "")
                    sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
                if (s_makp.Length > 1) sql += " and ab.makp in (" + s_makp.Substring(0, s_makp.Length - 2) + ")";
                //
                dtduoc = d.get_thuoc(tu.Text, den.Text, sql).Tables[0];
			}
			if (chkThuoc.Checked && !chkDuyet.Checked)
			{
				sql="select 0 as loai,a.maql,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau,"+soluongle+") as soluong";
                sql += " from xxx.benhanpk d inner join xxx.d_thuocbhytll a on d.maql=a.maql";
                sql += " left join xxx.d_thuocbhytct b on a.id=b.id";
                sql += " inner join " + user + ".d_dmbd c on b.mabd=c.id";
                sql += " where d.maql>0";
                if (m_tu != "")
                    sql += " and " + m.for_ngay("d.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
				if (s_makp.Length>1) sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" union all ";
                sql += " select 1 as loai,a.maql,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.soluong," + soluongle + ") as soluong";
                sql+=" from xxx.d_toathuocll a left join xxx.d_toathuocct b on a.id=b.id";
                sql += " inner join " + user + ".d_dmbd c on b.mabd=c.id";
                sql+=" inner join xxx.benhanpk d on a.maql=d.maql";
				sql+=" where d.maql>0";
                if (m_tu != "")
                    sql += " and " + m.for_ngay("d.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
				if (s_makp.Length>1) sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				sql+=" union all ";
				sql+="select 2 as loai,a.maql,b.ten,b.dvt as dang,1 as soluong ";
                sql += " from xxx.v_chidinh a inner join " + user + ".v_giavp b on a.mavp=b.id";
                sql+=" inner join xxx.benhanpk d on a.maql=d.maql";
				sql+=" where d.maql>0";
                if (m_tu != "")
                    sql += " and " + m.for_ngay("d.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
				if (s_makp.Length>1) sql+=" and d.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
				dtthuoc=m.get_data_mmyy(sql,m_tu,m_den,false).Tables[0];
			}
			sql="select a.maql,a.mabn,c.hoten,case when c.phai=0 then to_char("+namsinh+"-to_number(c.namsinh,'0000')) else '' end as nam,";
			sql+="case when c.phai=1 then to_char("+namsinh+"-to_number(c.namsinh,'0000')) else '' end as nu,";
			sql+="trim(c.sonha)||' '||trim(c.thon)||' '||trim(f.tenpxa)||' '||trim(e.tenquan)||' '||trim(d.tentt) as diachi,";
            sql += "nullif(i.sothe,'') as sothe,nullif(h.tenbv,'') as noigioithieu,nullif(g.chandoan,'') as chandoan_gt,";
			sql+="a.chandoan as chandoan_kkb,k.xutri,j.hoten as tenbs,a.madoituong,a.nhantu";
            sql += " from xxx.benhanpk a inner join " + user + ".btdbn c on a.mabn=c.mabn";
            sql += " inner join " + user + ".btdtt d on c.matt=d.matt";
            sql += " inner join " + user + ".btdquan e on c.maqu=e.maqu";
            sql += " inner join " + user + ".btdpxa f on c.maphuongxa=f.maphuongxa";
            sql += " left join " + user + ".noigioithieu g on a.maql=g.maql";
            sql += " left join " + user + ".dstt h on g.mabv=h.mabv";
            //linh 18/11/THIS
            //sql += " left join " + user + ".bhyt i on a.maql=i.maql";
            sql += " left join xxx.bhyt i on a.maql=i.maql";
            sql += " inner join " + user + ".dmbs j on a.mabs=j.ma";
            sql += " inner join xxx.xutrikbct k on a.maql=k.maql";//xuatvien b
			sql+=" where a.maql>0 and a.ttlucrv>0";
            if (m_tu != "")
                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + m_tu + "'," + stime + ") and to_date('" + m_den + "'," + stime + ")";
			if (s_makp.Length>1) sql+=" and a.makp in ("+s_makp.Substring(0,s_makp.Length-2)+")";
			ds=m.get_data_mmyy(sql,m_tu,m_den,false);
			taotable();
			get_data(ds.Tables[0],1,false);

			if (chkDuoc.Checked) get_data(dtduoc,dsxml.Tables[0].Rows.Count+1,true);
			Cursor=Cursors.Default;
			if (dsxml.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				return;
			}
			exp_excel();
		}

		private void get_data(System.Data.DataTable dt,int tt,bool duoc)
		{
			DataRow r1,r3;
			string s="";
			int i=0;
			foreach(DataRow r in dt.Select("true","mabn"))
			{
				sql="maql="+decimal.Parse(r["maql"].ToString());
				r3=m.getrowbyid(dsxml.Tables[0],sql);
				if (r3==null)
				{
					r1=dsxml.Tables[0].NewRow();
					r1["stt"]=tt;
					r1["maql"]=r["maql"].ToString();
					r1["mabn"]=r["mabn"].ToString();
					r1["hoten"]=r["hoten"].ToString();
					r1["nam"]=r["nam"].ToString();
					r1["nu"]=r["nu"].ToString();
					r1["diachi"]=r["diachi"].ToString();
					r1["sothe"]=r["sothe"].ToString();
					r1["noigioithieu"]=r["noigioithieu"].ToString();
					r1["chandoan_gt"]=r["chandoan_gt"].ToString();
					r1["chandoan_kkb"]=r["chandoan_kkb"].ToString();
					if (duoc) r1["chidinh"]=get_dichvu(dtduoc,decimal.Parse(r["maql"].ToString()));
					else r1["chidinh"]=(chkThuoc.Checked)?get_dichvu((chkDuyet.Checked)?dtduoc:dtthuoc,decimal.Parse(r["maql"].ToString())):"";
					foreach(DataRow r2 in dsxt.Tables[0].Select("true","ma")) r1["x"+r2["ma"].ToString()]="";
					foreach(DataRow r2 in dsdt.Tables[0].Select("true","ma")) r1["d"+r2["ma"].ToString()]="";
					s=r["xutri"].ToString().Trim();
					s=(s.Length>0)?s.Substring(0,s.Length-1):"";
					i=0;
					while (i<s.Length)
					{
						r1["x"+s.Substring(i,2).PadLeft(2,'0')]="X";
						i+=3;
					}
					r1["tenbs"]=r["tenbs"].ToString();
					r1["d"+r["madoituong"].ToString().PadLeft(2,'0')]="X";
					r1["capcuu"]=(r["nhantu"].ToString().Trim()=="1")?"X":"";	
					dsxml.Tables[0].Rows.Add(r1);
					tt++;
				}
			}
		}

		private string get_dichvu(System.Data.DataTable dt,decimal maql)
		{
			string ret="";
			foreach(DataRow r in dt.Select("maql="+maql,"loai"))
				ret=ret+r["ten"].ToString().Trim()+":"+r["soluong"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\n";
			return ret;
		}

		private void updrec(System.Data.DataTable dt,string ma,string ten)
		{
			DataRow r1,r2;
			r1=m.getrowbyid(dt,"ma='"+ma.PadLeft(2,'0')+"'");
			if (r1==null)
			{
				r2=dt.NewRow();
				r2["ma"]=ma.PadLeft(2,'0');
				r2["ten"]=ten;
				dt.Rows.Add(r2);
			}
		}
		private void taotable()
		{
			dsxt.Clear();
			dsdt.Clear();
			DataRow r1;
			string s="";
			int i=0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				r1=m.getrowbyid(dtdt,"madoituong="+int.Parse(r["madoituong"].ToString()));
				if (r1!=null) updrec(dsdt.Tables[0],r["madoituong"].ToString(),r1["doituong"].ToString());
				s=r["xutri"].ToString().Trim();
				s=(s.Length>0)?s.Substring(0,s.Length-1):"";
				i=0;
				while (i<s.Length)
				{
					r1=m.getrowbyid(dtxt,"ma="+int.Parse(s.Substring(i,2)));
					if (r1!=null) updrec(dsxt.Tables[0],r1["ma"].ToString(),r1["ten"].ToString());
					i+=3;
				}
			}
			if (chkDuoc.Checked)
			{
				foreach(DataRow r in dtduoc.Rows)
				{
					r1=m.getrowbyid(dtdt,"madoituong="+int.Parse(r["madoituong"].ToString()));
					if (r1!=null) updrec(dsdt.Tables[0],r["madoituong"].ToString(),r1["doituong"].ToString());
					s=r["xutri"].ToString().Trim();
					s=(s.Length>0)?s.Substring(0,s.Length-1):"";
					i=0;
					while (i<s.Length)
					{
						r1=m.getrowbyid(dtxt,"ma="+int.Parse(s.Substring(i,2)));
						if (r1!=null) updrec(dsxt.Tables[0],r1["ma"].ToString(),r1["ten"].ToString());
						i+=3;
					}
				}
			}
            dsxml=new DataSet();
			dsxml.ReadXml("..//..//..//xml//m_sokham.xml");
			foreach(DataRow r in dsxt.Tables[0].Select("true","ma"))
			{
				dc=new DataColumn();
				dc.ColumnName="x"+r["ma"].ToString();
				dc.DataType=Type.GetType("System.String");
				dsxml.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="tenbs";
			dc.DataType=Type.GetType("System.String");
			dsxml.Tables[0].Columns.Add(dc);
			foreach(DataRow r in dsdt.Tables[0].Select("true","ma"))
			{
				dc=new DataColumn();
				dc.ColumnName="d"+r["ma"].ToString();
				dc.DataType=Type.GetType("System.String");
				dsxml.Tables[0].Columns.Add(dc);
			}
			dc=new DataColumn();
			dc.ColumnName="capcuu";
			dc.DataType=Type.GetType("System.String");
			dsxml.Tables[0].Columns.Add(dc);
		}

		private void exp_excel()
		{
			m.check_process_Excel();
			dsxml.Tables[0].Columns.Remove("MAQL");
			int be=5,dong=6,sodong=dsxml.Tables[0].Rows.Count+dong,socot=dsxml.Tables[0].Columns.Count-1,dongke=sodong-1;
			string tenfile=m.Export_Excel(dsxml,"sokhambenh");
			oxl=new Excel.Application();
            owb = (Excel._Workbook)(oxl.Workbooks.Open(tenfile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
			osheet=(Excel._Worksheet)owb.ActiveSheet;
			oxl.ActiveWindow.DisplayGridlines=true;
            for (int i = 0; i < be - 1; i++) osheet.get_Range(m.getIndex(i) + "1", m.getIndex(i) + "1").EntireRow.Insert(Missing.Value);
			osheet.get_Range(m.getIndex(0)+"4",m.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
			for(int i=0;i<11;i++) 
			{
                osheet.Cells[dong-1,i+1]=get_ten(i);
				if (i!=3 && i!=4 && i!=8 && i!=9)
				{
					orange=osheet.get_Range(m.getIndex(i)+"4",m.getIndex(i)+"5");
					orange.HorizontalAlignment=XlHAlign.xlHAlignCenter;
					orange.VerticalAlignment=XlHAlign.xlHAlignCenter;
					orange.MergeCells=true;
				}
			}
			osheet.Cells[dong-2,4]="Tuổi";
			osheet.get_Range(m.getIndex(3)+"4",m.getIndex(4)+"4").HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			osheet.Cells[dong-2,9]="Chẩn đoán";
			osheet.get_Range(m.getIndex(8)+"4",m.getIndex(9)+"4").HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			osheet.Cells[dong-2,12]="Xử trí";
			int p=12;
			foreach(DataRow r in dsxt.Tables[0].Select("true","ma")) osheet.Cells[dong-1,p++]=r["ten"].ToString();
			osheet.get_Range(m.getIndex(11)+"4",m.getIndex(p-1)+"4").HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange=osheet.get_Range(m.getIndex(11)+"5",m.getIndex(p-2)+"5");
			orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
			orange.Orientation=90;
			osheet.Cells[dong-1,p]="Bác sỹ";
			orange=osheet.get_Range(m.getIndex(p-1)+"4",m.getIndex(p-1)+"5");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenter;
			orange.VerticalAlignment=XlHAlign.xlHAlignCenter;
			orange.MergeCells=true;
			p+=1;
			int q=p;
			osheet.Cells[dong-2,p]="Đối tượng";
			foreach(DataRow r in dsdt.Tables[0].Select("true","ma")) osheet.Cells[dong-1,p++]=r["ten"].ToString();
			osheet.get_Range(m.getIndex(q-1)+"4",m.getIndex(p-1)+"4").HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange=osheet.get_Range(m.getIndex(q-1)+"5",m.getIndex(p-2)+"5");
			orange.VerticalAlignment=XlVAlign.xlVAlignBottom;
			orange.Orientation=90;
			osheet.Cells[dong-1,p]="Cấp cứu";
			orange=osheet.get_Range(m.getIndex(p-1)+"4",m.getIndex(p-1)+"5");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenter;
			orange.VerticalAlignment=XlHAlign.xlHAlignCenter;
			orange.MergeCells=true;
			
			orange=osheet.get_Range(m.getIndex(0)+"4",m.getIndex(socot)+dongke.ToString());
			orange.Font.Name="Arial";
			orange.Font.Size=10;
			orange.EntireColumn.AutoFit();
			oxl.ActiveWindow.DisplayZeros=false;
			osheet.Cells[1,1]=m.Syte;osheet.Cells[2,1]=m.Tenbv;
			osheet.Cells[2,4]="SỔ KHÁM BỆNH "+((tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text);
			orange=osheet.get_Range(m.getIndex(1)+"2",m.getIndex(socot-1)+"3");
			orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
			orange.Font.Size=12;
			orange.Font.Bold=true;	
			oxl.Visible=true;
		}

		private string get_ten(int i)
		{
			string [] map={"STT","Mã BN","Họ tên","Nam","Nữ","Địa chỉ","Số thẻ","Nơi giới thiệu","Giới thiệu","Khoa khám bệnh","Thuốc - dịch vụ"};
			return map[i];
		}

		private void chkThuoc_CheckedChanged(object sender, System.EventArgs e)
		{
			chkDuyet.Enabled=chkThuoc.Checked;
			if (!chkThuoc.Checked) chkDuyet.Checked=false;
		}
	}
}
