using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for rptNxt_tonghop.
	/// </summary>
	public class frmKhoacstt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private int i_nhom,i_loai;
		private string sql,s_mmyy,s_makp,s_nhomkho,format_soluong,s_makho,user,xxx,stime;
		private DataRow r1,r2,r3;
		private DataRow [] dr;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private System.Data.DataTable dt=new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtmakp=new System.Data.DataTable();
		private System.Data.DataTable dtkp=new System.Data.DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox makp;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkSoluong;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmKhoacstt(string makp,int nhom,int loai,string nhomkho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            s_makp=makp;i_nhom=nhom;i_loai=loai;s_nhomkho=nhomkho;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoacstt));
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSoluong = new System.Windows.Forms.CheckBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(54, 136);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(126, 136);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kho :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(50, 58);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(190, 21);
            this.makho.TabIndex = 3;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(160, 11);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(50, 11);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(120, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "đến :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(50, 35);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(190, 21);
            this.makp.TabIndex = 2;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-6, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Khoa :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSoluong
            // 
            this.chkSoluong.Location = new System.Drawing.Point(50, 112);
            this.chkSoluong.Name = "chkSoluong";
            this.chkSoluong.Size = new System.Drawing.Size(104, 18);
            this.chkSoluong.TabIndex = 16;
            this.chkSoluong.Text = "Số lượng";
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.ItemHeight = 13;
            this.manguon.Location = new System.Drawing.Point(50, 82);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(190, 21);
            this.manguon.TabIndex = 4;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmKhoacstt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(250, 175);
            this.Controls.Add(this.chkSoluong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKhoacstt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo cơ số tủ trực theo khoa";
            this.Load += new System.EventHandler(this.frmKhoacstt_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmKhoacstt_Load(object sender, System.EventArgs e)
		{
            s_makho = ""; user = d.user; stime = "'" + d.f_ngay + "'";
			foreach(DataRow r in d.get_data("select kho from "+user+".d_dmphieu where id=2").Tables[0].Rows)
				s_makho=r["kho"].ToString();

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            string sql = "select * from " + user + ".d_dmkho where hide=0 and loai=" + i_loai;
			if (i_loai==1) 
			{
				sql+=" and nhom="+i_nhom;
				if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			}
			else 
			{
				sql+=" and nhom<>"+i_nhom;
				if (s_nhomkho!="") sql+=" and nhom in ("+s_nhomkho.Substring(0,s_nhomkho.Length-1)+")"; 
			}
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			makho.DataSource=dtdmkho;
			if (makho.Items.Count>0) makho.SelectedIndex=0;

			makp.DisplayMember="TEN";
			makp.ValueMember="ID";
            sql = "select * from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
			if (s_makp!="" )
			{
				string s=s_makp.Replace(",","','");
				sql+=" and makp in ('"+s.Substring(0,s.Length-3)+"')";
			}
			sql+=" order by stt";
			dtkp=d.get_data(sql).Tables[0];
			makp.DataSource=dtkp;
			if (makp.Items.Count>0) makp.SelectedIndex=0;

			ds.ReadXml("..//..//..//xml//d_khoacstt.xml");
			dsxml.ReadXml("..//..//..//xml//d_khoacstt.xml");
			format_soluong=d.format_soluong(i_nhom);
            sql = "select a.*, b.stt as sttnhom, b.ten as tennhom,c.ten as tenhang,d.ten as nuocsx from " + user + ".d_dmbd a, " + user + ".d_dmnhom b," + user + ".d_dmhang c,"+user+".d_dmnuoc d";
			sql+=" where a.manhom=b.id and a.mahang=c.id and a.manuoc=d.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=0 or nhom=" + i_nhom + " order by stt").Tables[0];
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			s_mmyy=tu.Text.Substring(3,2)+tu.Text.Substring(8,2);
            xxx = user + s_mmyy;
			get_data();
		}

		private void get_sort()
		{
			dsxml.Clear();
			dsxml.Merge(ds.Tables[0].Select("tondau+slnhap-slxuat>0","stt,ten"));
            if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
            dsxml.WriteXml("..\\xml\\cstt.xml", XmlWriteMode.WriteSchema);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void get_data()
		{
			ds.Clear();
			items_tondau();
			items_nhap();
			items_xuat();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
                return;
            }
            else
            {
                try
                {
                    ds.Tables[0].Columns.Add("nuocsx");
                }
                catch{}
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r2 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r2 != null)
                    {
                        r["nuocsx"] = r2["nuocsx"].ToString();
                    }
                }
            }
			get_sort();
			dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml.Tables[0],(chkSoluong.Checked)?"d_khoacstt_sl.rpt":"d_khoacstt.rpt",makp.Text,(tu.Text==den.Text)?"Ngày "+tu.Text:"Từ ngày "+tu.Text+" đến "+den.Text,"","","","","","","","");
			f.ShowDialog();
		}

		private void items_tondau()
		{
			foreach(DataRow r in get_tondau().Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and handung='"+r["handung"].ToString()+"' and dongia="+decimal.Parse(r["giamua"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();					
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
                        r3["tenhang"]=r2["tenhang"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["dongia"]=r["giamua"].ToString();
						r3["handung"]=r["handung"].ToString();
						r3["tondau"]=r["soluong"].ToString();
						r3["slnhap"]=0;
						r3["slxuat"]=0;
                        r3["losx"] = r["losx"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
						dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			//nhap
            foreach (DataRow r in get_nhap(" and a.ngay<to_date('" + tu.Text + "'," + stime + ")", " and a.ngay<to_date('" + tu.Text + "'," + stime + ")").Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and handung='"+r["handung"].ToString()+"' and dongia="+decimal.Parse(r["giamua"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["dongia"]=r["giamua"].ToString();
						r3["handung"]=r["handung"].ToString();
						r3["tondau"]=r["soluong"].ToString();
						r3["slnhap"]=0;
						r3["slxuat"]=0;
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
						dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			//xuat
            foreach (DataRow r in get_xuat(" and a.ngay<to_date('" + tu.Text + "'," + stime + ")").Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and handung='"+r["handung"].ToString()+"' and dongia="+decimal.Parse(r["giamua"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["dongia"]=r["giamua"].ToString();
						r3["handung"]=r["handung"].ToString();
						r3["tondau"]=-decimal.Parse(r["soluong"].ToString());
						r3["slnhap"]=0;
						r3["slxuat"]=0;
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
						dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())-decimal.Parse(r["soluong"].ToString());
				}
			}
		}

		private DataSet get_tondau()
		{
			sql=" select a.mabd,";
			if (chkSoluong.Checked) sql+="'' as handung,0 as giamua,";
			else sql+="t.handung,t.giamua,";
			sql+="sum(a.tondau) as soluong,t.losx from "+xxx+".d_tutrucct a,"+user+".d_dmbd b,"+xxx+".d_theodoi t";
			sql+=" where a.stt=t.id and a.mabd=b.id ";
			if (makho.SelectedIndex!=-1) sql+=" and a.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (makp.SelectedIndex!=-1) sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			sql+=" group by a.mabd,t.losx";
			if (!chkSoluong.Checked) sql+=",t.handung,t.giamua";
			return d.get_data(sql);
		}

		private void items_xuat()
		{
			foreach(DataRow r in get_xuat(" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")").Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and handung='"+r["handung"].ToString()+"' and dongia="+decimal.Parse(r["giamua"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["dongia"]=r["giamua"].ToString();
						r3["handung"]=r["handung"].ToString();
						r3["tondau"]=0;
						r3["slnhap"]=0;
						r3["slxuat"]=r["soluong"].ToString();
                        r3["losx"] = r["losx"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
						dr[0]["slxuat"]=decimal.Parse(dr[0]["slxuat"].ToString())+decimal.Parse(r["soluong"].ToString());
				}			
			}
		}

		private void items_nhap()
		{
			foreach(DataRow r in get_nhap(" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")"," and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")").Tables[0].Rows)
			{
				sql="mabd="+int.Parse(r["mabd"].ToString())+" and handung='"+r["handung"].ToString()+"' and dongia="+decimal.Parse(r["giamua"].ToString());
				r1=d.getrowbyid(ds.Tables[0],sql);
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["stt"]=r2["sttnhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["dongia"]=r["giamua"].ToString();
						r3["handung"]=r["handung"].ToString();
						r3["tondau"]=0;
						r3["slnhap"]=r["soluong"].ToString();
						r3["slxuat"]=0;
                        r3["losx"] = r["losx"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select(sql);
					if (dr.Length>0) 
						dr[0]["slnhap"]=decimal.Parse(dr[0]["slnhap"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
		}
		private DataSet get_nhap(string cont1,string cont2)
		{
			sql=" select b.mabd,";
			if (chkSoluong.Checked) sql+="'' as handung,0 as giamua,";
			else sql+="t.handung,t.giamua,";
			sql+="sum(b.soluong) as soluong,t.losx from "+xxx+".d_xuatsdll a,"+xxx+".d_thucbucstt b,"+user+".d_dmbd c,"+xxx+".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=2 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (makp.SelectedIndex!=-1) sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			sql+=cont1;
            sql += " group by b.mabd,t.losx";
			if (!chkSoluong.Checked) sql+=",t.handung,t.giamua";
			sql+=" union all ";
			sql+=" select b.mabd,";
			if (chkSoluong.Checked) sql+="'' as handung,0 as giamua,";
			else sql+="t.handung,t.giamua,";
			sql+="sum(b.soluong) as soluong,t.losx from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+user+".d_dmbd c,"+xxx+".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in ('BS') ";
			if (makho.SelectedIndex!=-1) sql+=" and a.khox="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (makp.SelectedIndex!=-1) sql+=" and a.khon="+int.Parse(makp.SelectedValue.ToString());
			sql+=cont2;
            sql += " group by b.mabd,t.losx";
			if (!chkSoluong.Checked) sql+=",t.handung,t.giamua";
			return d.get_data(sql);
		}

		private DataSet get_xuat(string cont)
		{
			sql=" select b.mabd,";
			if (chkSoluong.Checked) sql+="'' as handung,0 as giamua,";
			else sql+="t.handung,t.giamua,";
			sql+="sum(b.soluong) as soluong,t.losx from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+xxx+".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=2 ";
			if (makho.SelectedIndex!=-1) sql+=" and b.makho="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (makp.SelectedIndex!=-1) sql+=" and a.makp="+int.Parse(makp.SelectedValue.ToString());
			sql+=cont;
            sql += " group by b.mabd,t.losx";
			if (!chkSoluong.Checked) sql+=",t.handung,t.giamua";
			sql+=" union all ";
			sql+=" select b.mabd,";
			if (chkSoluong.Checked) sql+="'' as handung,0 as giamua,";
			else sql+="t.handung,t.giamua,";
            sql += "sum(b.soluong) as soluong,t.losx from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi t";
			sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in ('TH','HT') ";
			if (makho.SelectedIndex!=-1) sql+=" and a.khon="+int.Parse(makho.SelectedValue.ToString());
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			if (makp.SelectedIndex!=-1) sql+=" and a.khox="+int.Parse(makp.SelectedValue.ToString());
			sql+=cont;
            sql += " group by b.mabd,t.losx";
			if (!chkSoluong.Checked) sql+=",t.handung,t.giamua";
			return d.get_data(sql);
		}

	}
}
