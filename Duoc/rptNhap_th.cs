using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;
namespace Duoc
{
	/// <summary>
	/// Summary description for rptDalinh.
	/// </summary>
	public class rptNhap_th : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker den;
		private AccessData d;
        private int i_nhom, i_nhapxuat, i_userid=0;
		private bool bClear=true;
		private string sql,s_manhom,s_kho,s_tennhom,tenfile,user,stime,xxx;
		private DataRow r1,r2,r3;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtnhom=new DataTable();
		private DataTable dtdmkho=new DataTable();
        private DataTable dtdmnuocsx = new DataTable();//gam 26/08/2011
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.CheckedListBox nhom;
		private System.Windows.Forms.CheckBox chkIn;
		private Doisototext doiso=new Doisototext();
		private System.Windows.Forms.CheckBox muamoi;
        private CheckedListBox kho;
        private CheckBox chkXML;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public rptNhap_th(AccessData acc, int nhom, string kho, int nhapxuat, string tit, string file, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
            i_userid = _userid;
			i_nhom=nhom;s_kho=kho;i_nhapxuat=nhapxuat;
			this.Text=tit;tenfile=file;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptNhap_th));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nhom = new System.Windows.Forms.CheckedListBox();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.muamoi = new System.Windows.Forms.CheckBox();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(134, 15);
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
            this.tu.Location = new System.Drawing.Point(56, 15);
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
            this.den.Location = new System.Drawing.Point(169, 15);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(176, 275);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(246, 275);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 38);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 2;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(1, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhom
            // 
            this.nhom.CheckOnClick = true;
            this.nhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhom.Location = new System.Drawing.Point(252, 16);
            this.nhom.Name = "nhom";
            this.nhom.Size = new System.Drawing.Size(224, 244);
            this.nhom.TabIndex = 5;
            // 
            // chkIn
            // 
            this.chkIn.Location = new System.Drawing.Point(336, 264);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(144, 24);
            this.chkIn.TabIndex = 11;
            this.chkIn.Text = "Không in nhóm đã chọn";
            // 
            // muamoi
            // 
            this.muamoi.Checked = true;
            this.muamoi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.muamoi.Location = new System.Drawing.Point(336, 282);
            this.muamoi.Name = "muamoi";
            this.muamoi.Size = new System.Drawing.Size(104, 24);
            this.muamoi.TabIndex = 12;
            this.muamoi.Text = "Chỉ in mua mới";
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 63);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 196);
            this.kho.TabIndex = 4;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(336, 303);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(48, 17);
            this.chkXML.TabIndex = 13;
            this.chkXML.Text = "XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // rptNhap_th
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(490, 319);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.muamoi);
            this.Controls.Add(this.chkIn);
            this.Controls.Add(this.nhom);
            this.Controls.Add(this.kho);
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
            this.Name = "rptNhap_th";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng nhập thuốc vật tư tổng hợp";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptNhap_th_MouseMove);
            this.Load += new System.EventHandler(this.rptNhap_th_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptNhap_th_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			sql="select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt";
			dtnhom=d.get_data(sql).Tables[0];
			nhom.DataSource=dtnhom;
            nhom.DisplayMember = "TEN";
            nhom.ValueMember = "ID";

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			//
            sql = "select a.*, b.stt as sttnhom, b.ten as nhombd,c.ten as tenhang,a.manuoc from " + user + ".d_dmbd a, " + user + ".d_dmnhom b," + user + ".d_dmhang c where a.manhom=b.id and a.mahang=c.id and a.nhom=" + i_nhom + " order by a.id";//gam 26/08/2011
			dt=d.get_data(sql).Tables[0];
            dtdmnuocsx = d.get_data("select id,ten from " + user + ".d_dmnuoc").Tables[0];
			//			
			ds.ReadXml("..\\..\\..\\xml\\d_dasudung.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_dasudung.xml");
			muamoi.Visible=i_nhapxuat==1;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			ds.Clear();
			s_kho="";
			s_tennhom="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++)
				if (kho.GetItemChecked(i))
				{
					s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
					s_tennhom+=dtdmkho.Rows[i]["ten"].ToString()+",";
				}
			s_manhom="";
			for(int i=0;i<nhom.Items.Count;i++)
				if (nhom.GetItemChecked(i))
					s_manhom+=dtnhom.Rows[i]["id"].ToString()+",";

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
						if (i_nhapxuat==1) get_nhap(mmyy);
						else
						{
							get_xuat(mmyy);
							get_hoantra(mmyy);
						}
					}
				}
			}
			//			
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
            if (chkXML.Checked)
                dsxml.WriteXml("..//..//dataxml//"+tenfile.Replace(".rpt",".xml"),XmlWriteMode.WriteSchema);
			if (tenfile=="d_phieuxuat.rpt")
			{
				decimal d_tongcong=0;
				foreach(DataRow r in dsxml.Tables[0].Rows) d_tongcong+=decimal.Parse(r["sotien"].ToString());
				frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,tenfile,"",tu.Text,"","","","Xuất sử dụng",s_tennhom,doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString()),"","");
				f.ShowDialog();
			}
			else
			{
				frmReport f1=new frmReport(d,dsxml.Tables[0], i_userid,tenfile,(tu.Text==den.Text)?" Ngày :"+tu.Text:"Từ ngày :"+tu.Text+" đến :"+den.Text,(s_tennhom=="")?"":"Kho :"+s_tennhom,(manguon.SelectedIndex==-1)?"":"Nguồn :"+manguon.Text,"",this.Text.Trim().ToUpper(),"","","","","");
				f1.ShowDialog();
			}
		}

		private void get_sort()
		{
			dsxml.Clear();
			if (tenfile=="d_phieuxuat.rpt") sql="ten";
			else sql="stt,ten";
			dsxml.Merge(ds.Tables[0].Select("soluong<>0",sql));
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select b.mabd,t.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in (1,4) and a.nhom=" + i_nhom;
            //sql+=" and a.ngay between to_date('" + tu.Text + "',"+stime+") and to_date('" + den.Text + "',"+stime+")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";//gam 06/01/2012
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd,t.giamua";
			sql+=" union all select b.mabd,t.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + xxx + ".d_theodoi t," + user + ".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in (2) and a.nhom=" + i_nhom;
            //sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd,t.giamua";
			sql+=" union all select b.mabd,t.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
            sql+=" from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom;
            //sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd,t.giamua";
			sql+=" union all select b.mabd,t.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
            sql+=" from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom;
            //sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd,t.giamua";
			sql+=" union all select b.mabd,t.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
            sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom;
            //sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and a.loai in ('BS','XK') group by b.mabd,t.giamua";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["giamua"].ToString()));
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
						r2["soluong"]=r["soluong"].ToString();
						r2["dongia"]=r["giamua"].ToString();
						r2["sotien"]=r["sotien"].ToString();
						//Nhom bd
						r2["stt"]=r3["sttnhom"].ToString();
						r2["nhombd"]=r3["nhombd"].ToString();
						r2["noingoai"]=r3["tenhang"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					//DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
                    DataRow[] dr = ds.Tables[0].Select("mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["giamua"].ToString()));//Thuy 29.12.2011
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_nhap(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select b.mabd,b.giamua,sum(b.soluong) as soluong,sum(round(b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu,3)) as sotien ";
            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c where a.id=b.id and b.mabd=c.id and a.nhom=" + i_nhom;
            //sql += " and a.ngaysp between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            sql += " and to_date(to_char(a.ngaysp,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and a.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd,b.giamua ";
			if (!muamoi.Checked)
			{
				sql+="union all select b.mabd,b.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
                sql+=" from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
                sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom;
                //sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
				if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") 
				{
					if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
					else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				}
				if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and a.loai='CK' group by b.mabd,t.giamua";
			}
            try
            {
                ds.Tables[0].Columns.Add("NUOCSX",typeof(string));//gam 26/08/2011
            }
            catch { }
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
                DataRow rNuocsx;
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["giamua"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
                        rNuocsx = d.getrowbyid(dtdmnuocsx, "id=" + int.Parse(r3["manuoc"].ToString()));//gam 26/08/2011
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["soluong"]=decimal.Parse(r["soluong"].ToString());
						r2["dongia"]=r["giamua"].ToString();
						r2["sotien"]=decimal.Parse(r["sotien"].ToString());
						//Nhom bd
						r2["stt"]=r3["sttnhom"].ToString();
						r2["nhombd"]=r3["nhombd"].ToString();
						r2["noingoai"]=r3["tenhang"].ToString();
                        if(rNuocsx != null)//gam 26/08/2011
                            r2["nuocsx"] = rNuocsx["ten"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					//DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
                    DataRow[] dr = ds.Tables[0].Select("mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["giamua"].ToString()));//Thuy 29.12.2011
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select b.mabd,t.giamua,sum(b.soluong) as soluong,sum(b.soluong*t.giamua) as sotien ";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += " where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + tu.Text + "'," + stime + //gam 06/01/2012 sua dk a.ngay thanh to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') => khi lưu a.ngay co dinh dang dd/mm/yyyy hh24:mi nen khi lay between sẽ thiếu số liệu
                ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") 
			{
				if (chkIn.Checked) sql+=" and c.manhom not in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				else sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			}
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by b.mabd,t.giamua";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["giamua"].ToString()));
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
						r2["soluong"]=-decimal.Parse(r["soluong"].ToString());
						r2["sotien"]=-decimal.Parse(r["sotien"].ToString());
						//Nhom bd
						r2["stt"]=r3["sttnhom"].ToString();
						r2["nhombd"]=r3["nhombd"].ToString();
						r2["noingoai"]=r3["tenhang"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					//DataRow[] dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
                    DataRow[] dr = ds.Tables[0].Select("mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["giamua"].ToString()));//Thuy 29.12.2011
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())-decimal.Parse(r["soluong"].ToString());
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

		private void rptNhap_th_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}
	}
}
