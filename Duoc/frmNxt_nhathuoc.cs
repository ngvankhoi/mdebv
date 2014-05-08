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
	/// Summary description for rptBhyt.
	/// </summary>
	public class frmNxt_nhathuoc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom = 0, i_userid = 0;
		private string sql,mmyy,s_makho,user,stime,xxx;
		private DataTable dt=new DataTable();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dssort=new DataSet();
		private DataRow [] dr;
		private DataRow r1,r2,r3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox kho;
		private System.Windows.Forms.ComboBox sort;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNxt_nhathuoc(AccessData acc,int nhom,string s_mmyy,string makho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;mmyy=s_mmyy;s_makho=makho;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNxt_nhathuoc));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.ComboBox();
            this.sort = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(138, 93);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 9;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(126, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.Print1;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(68, 93);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 8;
            this.butXem.Text = "     &In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 10);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 1;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(168, 10);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 3;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kho :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thứ tự :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 33);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 21);
            this.kho.TabIndex = 5;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // sort
            // 
            this.sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sort.Location = new System.Drawing.Point(56, 56);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(192, 21);
            this.sort.TabIndex = 7;
            this.sort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // frmNxt_nhathuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 135);
            this.Controls.Add(this.sort);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNxt_nhathuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo nhập xuất tồn";
            this.Load += new System.EventHandler(this.frmNxt_nhathuoc_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmNxt_nhathuoc_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'"; xxx = user + mmyy;
            dt = d.get_data("select a.*,b.ten as tenhang,c.ten as tennhom,d.ten as tenloai from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".d_dmloai d where a.mahang=b.id and a.manhom=c.id and a.maloai=d.id and a.nhom=" + i_nhom).Tables[0];
			dssort.ReadXml("..\\..\\..\\xml\\d_sortnxt.xml");
			ds.ReadXml("..\\..\\..\\xml\\d_nxtnhathuoc.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_nxtnhathuoc.xml");
            string sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";
			kho.DataSource=d.get_data(sql).Tables[0];
			sort.DisplayMember="TEN";
			sort.ValueMember="FIELD";
			sort.DataSource=dssort.Tables[0];
			if (d.bInPhieuxuatban(i_nhom) && sort.Items.Count>3) sort.SelectedIndex=3;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void items_tondau()
		{
			foreach(DataRow r in get_tondau().Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["maloai"]=r2["maloai"].ToString();
						r3["tenloai"]=r2["tenloai"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=r["soluong"].ToString();
						r3["dongia"]=r2["giaban"].ToString();
						r3["slnhap"]=0;
						r3["slxuat"]=0;
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			//nhap
			foreach(DataRow r in get_nhap(" and a.ngaysp<to_date('"+tu.Text+"',"+stime+")"," and a.ngay<to_date('"+tu.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["maloai"]=r2["maloai"].ToString();
						r3["tenloai"]=r2["tenloai"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=0;
						r3["dongia"]=r2["giaban"].ToString();
						r3["slnhap"]=r["soluong"].ToString();
						r3["slxuat"]=0;
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			//xuat
			foreach(DataRow r in get_xuat(" and a.ngay<to_date('"+tu.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["maloai"]=r2["maloai"].ToString();
						r3["tenloai"]=r2["tenloai"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=0;
						r3["dongia"]=r2["giaban"].ToString();
						r3["slnhap"]=0;
						r3["slxuat"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())-decimal.Parse(r["soluong"].ToString());
				}
			}
		}

		private DataSet get_tondau()
		{
			sql=" select mabd,sum(tondau) as soluong from "+xxx+".d_tonkhoct ";
			sql+=" where makho="+int.Parse(kho.SelectedValue.ToString());
			sql+=" group by mabd";
			return d.get_data(sql);
		}

		private void items_xuat()
		{
			foreach(DataRow r in get_xuat(" and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["maloai"]=r2["maloai"].ToString();
						r3["tenloai"]=r2["tenloai"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=0;
						r3["slnhap"]=0;
						r3["dongia"]=r2["giaban"].ToString();
						r3["slxuat"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["slxuat"]=decimal.Parse(dr[0]["slxuat"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
		}

		private void items_nhap()
		{
			foreach(DataRow r in get_nhap(" and a.ngaysp between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")"," and a.ngay between to_date('"+tu.Text+"',"+stime+") and to_date('"+den.Text+"',"+stime+")").Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if (r1==null)
				{
					r2=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r2!=null)
					{
						r3=ds.Tables[0].NewRow();
						r3["manhom"]=r2["manhom"].ToString();
						r3["tennhom"]=r2["tennhom"].ToString();
						r3["maloai"]=r2["maloai"].ToString();
						r3["tenloai"]=r2["tenloai"].ToString();
						r3["mabd"]=r["mabd"].ToString();
						r3["ma"]=r2["ma"].ToString();
						r3["ten"]=r2["ten"].ToString().Trim()+" "+r2["hamluong"].ToString();
						r3["tenhc"]=r2["tenhc"].ToString();
						r3["dang"]=r2["dang"].ToString();
						r3["tenhang"]=r2["tenhang"].ToString();
						r3["tondau"]=0;
						r3["slnhap"]=r["soluong"].ToString();
						r3["slxuat"]=0;
						r3["dongia"]=r2["giaban"].ToString();
						ds.Tables[0].Rows.Add(r3);
					}
				}
				else 
				{
					dr=ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					if (dr.Length>0) dr[0]["slnhap"]=decimal.Parse(dr[0]["slnhap"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
		}
		private DataSet get_nhap(string cont1,string cont2)
		{
			sql=" select b.mabd,sum(b.soluong) as soluong from "+xxx+".d_nhapll a,"+xxx+".d_nhapct b ";
			sql+=" where a.id=b.id and a.makho="+int.Parse(kho.SelectedValue.ToString());
			sql+=cont1;
			sql+=" group by b.mabd";
			sql+=" union ";
			sql+=" select b.mabd,sum(b.soluong) as soluong from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b ";
			sql+=" where a.id=b.id and a.loai in ('CK','TH','HT') and a.khon="+int.Parse(kho.SelectedValue.ToString());
			sql+=cont2;
			sql+=" group by b.mabd";
			return d.get_data(sql);
		}

		private DataSet get_xuat(string cont)
		{
			sql=" select b.mabd,sum(b.soluong) as soluong from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b ";
			sql+=" where a.id=b.id and b.makho="+int.Parse(kho.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			sql+=" union ";
			sql+=" select b.mabd,sum(b.soluong) as soluong from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b ";
			sql+=" where a.id=b.id and a.loai in ('CK','BS','XK') and a.khox="+int.Parse(kho.SelectedValue.ToString());
			sql+=cont;
			sql+=" group by b.mabd";
			return d.get_data(sql);
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			print();
		}	

		private void print()
		{
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
			if(tu.Text==den.Text)s_title="Ngày "+tu.Text;
			ds.Clear();
			items_tondau();
			items_nhap();
			items_xuat();
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
			else
			{
				dsxml.Clear();
				foreach(DataRow r in ds.Tables[0].Select("true",sort.SelectedValue.ToString()))
				{
					r3=dsxml.Tables[0].NewRow();
					if (sort.SelectedValue.ToString()=="manhom,ten")
					{
						r3["manhom"]=r["manhom"].ToString();
						r3["tennhom"]=r["tennhom"].ToString();
					}
					if (sort.SelectedValue.ToString()=="maloai,ten")
					{
						r3["maloai"]=r["maloai"].ToString();
						r3["tenloai"]=r["tenloai"].ToString();
					}
					r3["mabd"]=r["mabd"].ToString();
					r3["ma"]=r["ma"].ToString();
					r3["ten"]=r["ten"].ToString();
					r3["tenhc"]=r["tenhc"].ToString();
					r3["dang"]=r["dang"].ToString();
					r3["tenhang"]=r["tenhang"].ToString();
					r3["tondau"]=r["tondau"].ToString();
					r3["dongia"]=r["dongia"].ToString();
					r3["slnhap"]=r["slnhap"].ToString();
					r3["slxuat"]=r["slxuat"].ToString();
					r3["sort"]=sort.SelectedValue.ToString();
					dsxml.Tables[0].Rows.Add(r3);
				}	
				frmReport f1=new frmReport(d,dsxml.Tables[0],i_userid,"d_nxt_nhathuoc.rpt",kho.Text,s_title,"","","","","","","","");
				f1.ShowDialog(this);
			}
		}	
	}
}
