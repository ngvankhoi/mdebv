using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
//using doiso;
using dichso;

namespace Medisoft
{
	/// <summary>
	/// Summary description for Phieu xuat kho.	
	/// </summary>
	public class frmInphieuxuat : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.ComboBox nhom;
		private System.Windows.Forms.CheckedListBox makho;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private string s_makp="",sql,s_makho,s_tenkho,s_loai,s_phieu,soct,s_nhomkho,user,stime,s_mmyy;
		private int i_userid;
		private decimal id;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private decimal d_tongcong;
		private int i_nhom,i_dongia;
		private DataTable dtkho=new DataTable();
		private DataTable dtmakp=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtloai=new DataTable();
		private DataTable dtphieu=new DataTable();
        private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		//private Doisototext doiso=new Doisototext();
        private numbertotext doiso = new numbertotext();
		private System.Windows.Forms.CheckedListBox loai;
		private System.Windows.Forms.CheckedListBox phieu;
		private System.Windows.Forms.CheckBox imp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInphieuxuat(string _makp,string _nhomkho,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			i_userid=userid;
            s_makp = _makp; s_nhomkho = _nhomkho; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInphieuxuat));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.nhom = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.CheckedListBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.loai = new System.Windows.Forms.CheckedListBox();
            this.phieu = new System.Windows.Forms.CheckedListBox();
            this.imp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(131, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(51, 8);
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
            this.den.Location = new System.Drawing.Point(163, 8);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-5, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nhóm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(51, 56);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 3;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // nhom
            // 
            this.nhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(51, 32);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(192, 21);
            this.nhom.TabIndex = 2;
            this.nhom.SelectedIndexChanged += new System.EventHandler(this.nhom_SelectedIndexChanged);
            this.nhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhom_KeyDown);
            // 
            // makho
            // 
            this.makho.CheckOnClick = true;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(51, 80);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(192, 100);
            this.makho.TabIndex = 4;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(150, 192);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(222, 192);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // loai
            // 
            this.loai.CheckOnClick = true;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(245, 8);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(187, 84);
            this.loai.TabIndex = 8;
            this.loai.SelectedIndexChanged += new System.EventHandler(this.loai_SelectedIndexChanged);
            // 
            // phieu
            // 
            this.phieu.CheckOnClick = true;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(245, 96);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(187, 84);
            this.phieu.TabIndex = 9;
            // 
            // imp
            // 
            this.imp.Location = new System.Drawing.Point(51, 182);
            this.imp.Name = "imp";
            this.imp.Size = new System.Drawing.Size(93, 24);
            this.imp.TabIndex = 5;
            this.imp.Text = "Implants";
            this.imp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmInphieuxuat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(442, 231);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.imp);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInphieuxuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In phiếu xuất";
            this.Load += new System.EventHandler(this.frmInphieuxuat_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmInphieuxuat_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			imp.Visible=m.Mabv_so==701424;
			ds.ReadXml("..//..//..//xml//d_xuatkho.xml");
			dsxml.ReadXml("..//..//..//xml//d_xuatkho.xml");
			makp.DisplayMember="TEN";
			makp.ValueMember="ID";

			dtloai=d.get_data("select * from "+user+".d_dmphieu where id<5 order by stt").Tables[0];
			loai.DataSource=dtloai;
            loai.DisplayMember = "TEN";
            loai.ValueMember = "ID";

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";

			nhom.DisplayMember="TEN";
			nhom.ValueMember="ID";
			load_nhom();
			load_makp();
			load_makho();				
		}

		private void load_makp()
		{
			sql="select * from "+user+".d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by stt";
			dtmakp=d.get_data(sql).Tables[0];
			makp.DataSource=dtmakp;
		}

		private void load_nhom()
		{
			sql="select * from "+user+".d_dmnhomkho ";
			if (s_nhomkho!="") sql+=" where id in ("+s_nhomkho.Substring(0,s_nhomkho.Length-1)+")";
			sql+=" order by stt";
			nhom.DataSource=d.get_data(sql).Tables[0];
			i_nhom=(nhom.SelectedIndex!=-1)?int.Parse(nhom.SelectedValue.ToString()):0;
			loai.Enabled=d.bChonloaiphieu_xuat(i_nhom);
			phieu.Enabled=loai.Enabled;
		}

		private void load_makho()
		{
			s_makho="";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (makp.SelectedIndex!=-1)
			{
				DataRow r=d.getrowbyid(dtmakp,"id="+int.Parse(makp.SelectedValue.ToString()));
				if (r!=null) s_makho=r["makho"].ToString();
			}
			if (s_makho=="") 
			{
				foreach(DataRow r1 in d.get_data("select kho from "+user+".d_dmphieu where nhom="+i_nhom).Tables[0].Rows)
					s_makho+=r1["kho"].ToString();
			}
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtkho;
            makho.DisplayMember = "TEN";
            makho.ValueMember = "ID";
		}

		private void makp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==makp) load_makho();
		}

		private void nhom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==nhom)
			{
				i_nhom=(nhom.SelectedIndex!=-1)?int.Parse(nhom.SelectedValue.ToString()):0;
				load_makp();
				load_makho();				
			}
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (makp.SelectedIndex==-1 && makp.Items.Count>0) makp.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

		private void nhom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (nhom.SelectedIndex==-1 && nhom.Items.Count>0) nhom.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private bool kiemtra()
		{
			if (makp.SelectedIndex==-1)
			{
				makp.Focus();return false;
			}
			if (nhom.SelectedIndex==-1)
			{
				nhom.Focus();return false;
			}
			return true;
		}

		private void taotable()
		{
			if (!kiemtra()) return;
			i_dongia=d.d_dongia_le(int.Parse(nhom.SelectedValue.ToString()));
			ds.Clear();
            dtdmbd = d.get_data("select * from " + user + ".d_dmbd where nhom=" + int.Parse(nhom.SelectedValue.ToString())).Tables[0];
			string cont=" and a.makp="+int.Parse(makp.SelectedValue.ToString())+" and a.nhom="+int.Parse(nhom.SelectedValue.ToString());
			cont+=" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			if (s_loai!="") cont+=" and a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") cont+=" and a.phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			if (imp.Visible)
			{
				if (imp.Checked) cont+=" and c.manhom in (31,55)";
				else cont+=" and c.manhom not in (31,55)";
			}
			s_makho="";s_tenkho="";
			for(int i=0;i<makho.Items.Count;i++)
				if (makho.GetItemChecked(i))
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			if (s_makho=="") 
			{
				for(int i=0;i<makho.Items.Count;i++)
				{
					s_makho+=dtkho.Rows[i]["id"].ToString().Trim()+",";
					s_tenkho+=dtkho.Rows[i]["ten"].ToString().Trim()+";";
				}
			}
			if (s_makho!="") cont+=" and b.makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			get_xuat(cont);
			get_hoantra(cont);
			sort();
		}

		private void get_xuat(string cont)
		{
			sql="select b.mabd,round(t.giamua,"+i_dongia+") as giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from xxx.d_xuatsdll a,xxx.d_thucxuat b,"+user+".d_dmbd c,xxx.d_theodoi t where a.id=b.id and b.sttt=t.id and b.mabd=c.id ";
			sql+=cont;
			sql+=" and a.loai<>3 group by b.mabd,round(t.giamua,"+i_dongia+")";
			foreach(DataRow r in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
				r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));
				if (r3!=null)
				{
					sql="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["giamua"].ToString());
					r1=d.getrowbyid(ds.Tables[0],sql);
					if (r1==null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r["giamua"].ToString();
						r2["soluong"]=r["soluong"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
						}
					}
				}
			}
		}

		private void get_hoantra(string cont)
		{
			sql="select b.mabd,round(t.giamua,"+i_dongia+") as giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien from xxx.d_xuatsdll a,xxx.d_thucxuat b,"+user+".d_dmbd c,xxx.d_theodoi t where a.id=b.id and b.sttt=t.id and b.mabd=c.id ";
			sql+=cont;
			sql+=" and a.loai=3 group by b.mabd,round(t.giamua,"+i_dongia+")";
			foreach(DataRow r in d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows)
			{
				r3=d.getrowbyid(dtdmbd,"id="+int.Parse(r["mabd"].ToString()));
				if (r3!=null)
				{
					sql="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["giamua"].ToString());
					r1=d.getrowbyid(ds.Tables[0],sql);
					if (r1==null)
					{
						r2=ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["dongia"]=r["giamua"].ToString();
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
					else
					{
						dr=ds.Tables[0].Select(sql);
						if (dr.Length>0)
						{
							dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
							dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())-decimal.Parse(r["sotien"].ToString());
						}
					}
				}
			}			
		}

		private void sort()
		{
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("soluong<>0","ma"));
			d_tongcong=0;
			foreach(DataRow r in dsxml.Tables[0].Rows) d_tongcong+=decimal.Parse(r["sotien"].ToString());
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            string sql1;
			s_loai="";s_phieu="";
			for(int i=0;i<loai.Items.Count;i++) if (loai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			for(int i=0;i<phieu.Items.Count;i++) if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
			sql="select * from xxx.d_daduyet where nhom="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" and ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")";
			sql+=" and makp="+int.Parse(makp.SelectedValue.ToString());
			if (s_makho!="") sql+=" and makho in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			if (d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
            sql1 = sql;
			sql="select * from xxx.d_duyet where loai<>2 and done=1 and nhom="+int.Parse(nhom.SelectedValue.ToString());
			sql+=" and makhoa="+int.Parse(makp.SelectedValue.ToString());
            sql += " and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_loai!="") sql+=" and loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
			if (s_phieu!="") sql+=" and phieu in ("+s_phieu.Substring(0,s_phieu.Length-1)+")";
			if (d.get_thuoc(tu.Text,den.Text,sql).Tables[0].Rows.Count>0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu kho chưa duyệt xong !"),d.Msg);
				tu.Focus();
				return;
			}
			taotable();
			if (dsxml.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				tu.Focus();
				return;
			}
            s_mmyy = d.get_mmyy(tu.Text, den.Text, sql1);
            if (s_mmyy == "") s_mmyy = d.mmyy(tu.Text);
			if (s_makho!="") s_makho=s_makho.Substring(0,s_makho.Length-1);
			id=d.get_id_phieuxuat(tu.Text,int.Parse(makp.SelectedValue.ToString()),i_nhom,s_loai,s_phieu,s_makho,s_mmyy);
			if (id==0)
			{
				id=d.get_id_phieuxuat();
				soct=d.get_phieuxuat(s_mmyy,i_nhom,s_makho);
			}
			else soct=d.get_phieuxuat(s_mmyy,id);
			d.upd_phieuxuat(s_mmyy,id,soct,tu.Text,int.Parse(makp.SelectedValue.ToString()),i_nhom,s_loai,s_phieu,s_makho,d_tongcong,"","","",i_userid);
			string s_tndn=tu.Text;
			dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml.Tables[0],"d_phieuxuat.rpt",soct,s_tndn,"","",makp.Text,"Xuất sử dụng",s_tenkho,doiso.doiraso(Convert.ToInt64(d_tongcong).ToString()),"","");
			f.ShowDialog();
		}

		private void loai_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			s_loai="";
			s_phieu="";
			for(int i=0;i<loai.Items.Count;i++) if (loai.GetItemChecked(i)) s_loai+=dtloai.Rows[i]["id"].ToString().Trim()+",";
			if (s_loai!="")
			{
				for(int i=0;i<phieu.Items.Count;i++) 
					if (phieu.GetItemChecked(i)) s_phieu+=dtphieu.Rows[i]["id"].ToString().Trim()+",";
                sql = "select a.id,trim(b.ten)||'//'||trim(a.ten) as ten from " + user + ".d_loaiphieu a," + user + ".d_dmphieu b where a.loai=b.id ";
				sql+=" and (a.loai in ("+s_loai.Substring(0,s_loai.Length-1)+")";
				sql+=" and a.nhom="+i_nhom;
				if (s_loai.IndexOf("3,")!=-1) sql+=" or (a.id=0 and a.loai=3)";
				sql+=")";
				sql+=" order by a.loai,a.stt";
				dtphieu=d.get_data(sql).Tables[0];
			}
            else dtphieu = d.get_data("select * from " + user + ".d_loaiphieu where id=-1").Tables[0];
			phieu.DataSource=dtphieu;
            phieu.DisplayMember = "TEN";
            phieu.ValueMember = "ID";
			if (s_phieu!="")
				for(int i=0;i<phieu.Items.Count;i++) 
					if (s_phieu.IndexOf(dtphieu.Rows[i]["id"].ToString().Trim()+",")!=-1) phieu.SetItemCheckState(i,CheckState.Checked);
					else phieu.SetItemCheckState(i,CheckState.Unchecked);
		}
	}
}
