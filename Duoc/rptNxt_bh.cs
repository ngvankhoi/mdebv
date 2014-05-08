using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using dichso;

namespace Duoc
{
	/// <summary>
	/// Summary description for rptNxt_tonghop.
	/// </summary>
	public class rptNxt_bh : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom, i_tt, i_dongiale, i_userid=0;
		private bool bClear=true;
		private string sql,s_mmyy,s_tu,s_den,s_yy,s_kho,tenfile,s_manhom,exp,s_khott,user,xxx;
		private DataRow r1,r2,r3,r4;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dt=new DataTable();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.NumericUpDown yyyy;
		private System.Windows.Forms.NumericUpDown tu;
		private System.Windows.Forms.NumericUpDown den;
		private System.Windows.Forms.Label label3;
		private DataTable dtdmkho=new DataTable();
		private DataTable dtdmnhom=new DataTable();
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox tt;
		private numbertotext dso=new numbertotext();
		private decimal ts;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptNxt_bh(AccessData acc,int nhom,string kho,string mmyy,string file, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
			tenfile=file;
            i_userid = _userid;
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			den.Value=tu.Value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptNxt_bh));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(172, 222);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 14;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(242, 222);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 38);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(200, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-5, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(56, 14);
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
            this.tu.TabIndex = 1;
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
            this.yyyy.Location = new System.Drawing.Point(208, 14);
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
            this.yyyy.TabIndex = 5;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(128, 14);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(40, 21);
            this.den.TabIndex = 3;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(96, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(258, 14);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(200, 196);
            this.manhom.TabIndex = 16;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-13, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kho ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 62);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(200, 116);
            this.kho.TabIndex = 11;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-8, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thứ tự :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tt
            // 
            this.tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.Items.AddRange(new object[] {
            "Nội ngoại,nhóm",
            "Kho,nhóm kế toán"});
            this.tt.Location = new System.Drawing.Point(56, 180);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(200, 21);
            this.tt.TabIndex = 13;
            this.tt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // rptNxt_bh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(466, 262);
            this.Controls.Add(this.tt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.manhom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.den);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptNxt_bh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập xuất tồn";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptNxt_bh_MouseMove);
            this.Load += new System.EventHandler(this.rptNxt_bh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptNxt_bh_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			i_dongiale=d.d_dongia_le(i_nhom);
			if (tt.Items.Count>0) tt.SelectedIndex=0;
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

			dtdmnhom=d.get_data("select * from "+user+".d_dmnhom where stt<>0 and nhom="+i_nhom+" order by stt").Tables[0];
            manhom.DataSource = dtdmnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_nxt_bh.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_nxt_bh.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			i_tt=tt.SelectedIndex;
			if (i_tt==0)
			{
                sql = "select a.*, b.stt as tt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f";
				sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.nhom="+i_nhom+" order by a.id";
			}
			else 
			{
				sql="select a.*, b.stt as tt, b.ten as tennhom";
                sql += " from " + user + ".d_dmbd a," + user + ".d_dmnhomkt b where a.sotk=b.id and a.nhom=" + i_nhom + " order by a.id";
			}
			dt=d.get_data(sql).Tables[0];
			get_data();
		}

		private void get_sort()
		{
			dsxml.Clear();
			sql=(s_manhom!="")?"idnn,stt,ten":"idnn,stt,ten";
			dsxml.Merge(ds.Tables[0].Select("ma<>''",sql));
			d.delrec(dsxml.Tables[0],"tondau+slnhap+slxuat+slxuat_ck+slnhap_ck+slxuat_k=0");
		}

		private void get_tondau(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+="a.makho,";
			sql+="a.mabd,trunc(c.giamua,"+i_dongiale+") as dongia,c.manguon,sum(a.tondau) as soluong,sum(a.tondau*c.giamua) as sotien ";
			sql+="from "+xxx+".d_tonkhoct a,"+user+".d_dmbd b,"+xxx+".d_theodoi c ";
			sql+=" where a.mabd=b.id and a.stt=c.id and a.tondau<>0 and b.nhom="+i_nhom;
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and b.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="a.makho,";
			sql+="a.mabd,trunc(c.giamua,"+i_dongiale+"),c.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=r["soluong"].ToString();
						r2["sttondau"]=r["sotien"].ToString();
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
						r2["slxuat_k"]="0";
						r2["stxuat_k"]="0";
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["tondau"]=decimal.Parse(dr[0]["tondau"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sttondau"]=decimal.Parse(dr[0]["sttondau"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_chuyennguon(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
			sql+=" from "+xxx+".d_chuyenll a,"+xxx+".d_chuyenct b, "+user+".d_dmbd c,"+xxx+".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom="+i_nhom+" and b.soluong>0";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						r2["slxuat_ck"]=r["soluong"].ToString();
						r2["stxuat_ck"]=r["sotien"].ToString();
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
						r2["slxuat_k"]="0";
						r2["stxuat_k"]="0";
						r2["slnhap"]="0";
						r2["stnhap"]="0";
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["slxuat_ck"]=decimal.Parse(dr[0]["slxuat_ck"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["stxuat_ck"]=decimal.Parse(dr[0]["stxuat_ck"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			//
			sql="select ";
			if (i_tt==1) sql+=" b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
			sql+="from "+xxx+".d_chuyenll a,"+xxx+".d_chuyenct b, "+user+".d_dmbd c,"+xxx+".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.stttchuyen=d.id and a.nhom="+i_nhom+" and b.soluong>0";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						r2["slnhap_ck"]=r["soluong"].ToString();
						r2["stnhap_ck"]=r["sotien"].ToString();
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
						r2["slxuat_k"]="0";
						r2["stxuat_k"]="0";
						r2["slnhap"]="0";
						r2["stnhap"]="0";
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["slnhap_ck"]=decimal.Parse(dr[0]["slnhap_ck"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["stnhap_ck"]=decimal.Parse(dr[0]["stnhap_ck"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_nhap(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+=" a.makho,";
			sql+="case when a.loai='M' then 0 else 1 end as loai,b.mabd,trunc(b.giamua,"+i_dongiale+") as dongia,a.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.sotien+b.sotien*b.vat/100) as sotien ";
			sql+="from "+xxx+".d_nhapll a,"+xxx+".d_nhapct b,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.mabd=c.id and a.nhom="+i_nhom+" and b.soluong>0";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and a.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="a.makho,";
			sql+="case when a.loai='M' then 0 else 1 end,b.mabd,trunc(b.giamua,"+i_dongiale+"),a.manguon";
			if (s_khott=="")
			{
				sql+=" union all select ";
				if (i_tt==1) sql+="a.khon as makho,";
				sql+="1 as loai,b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
				sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
				sql+="from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b, "+user+".d_dmbd c,"+xxx+".d_theodoi d ";
                sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom="+i_nhom+" and a.loai in ('CK','HT','TH') and b.soluong>0";
				if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" group by ";
				if (i_tt==1) sql+="a.khon,";
				sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			}
			else
			{
				sql+=" union all select ";
				if (i_tt==1) sql+="a.khon as makho,";
				sql+="1 as loai,b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
				sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
				sql+="from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b, "+user+".d_dmbd c,"+xxx+".d_theodoi d ";
                sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom="+i_nhom+" and a.loai in ('CK','HT','TH') and b.soluong>0";
				if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and a.khox not in ("+s_khott.Substring(0,s_khott.Length-1)+")";
				sql+=" group by ";
				if (i_tt==1) sql+="a.khon,";
				sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
				//
				sql+=" union all select ";
				if (i_tt==1) sql+="a.khon as makho,";
				sql+="0 as loai,b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
				sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
				sql+="from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b, "+user+".d_dmbd c,"+xxx+".d_theodoi d ";
                sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom="+i_nhom+" and a.loai in ('CK','HT','TH') and b.soluong>0";
				if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and a.khox in ("+s_khott.Substring(0,s_khott.Length-1)+")";
				sql+=" group by ";
				if (i_tt==1) sql+="a.khon,";
				sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			}
			string f1="slnhap",f2="stnhap";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				f1="slnhap";f2="stnhap";
				if (r["loai"].ToString()=="1")
				{
					f1+="_ck";f2+="_ck";
				}
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) sql+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
						r2["slxuat_k"]="0";
						r2["stxuat_k"]="0";
						r2["slnhap"]="0";
						r2["stnhap"]="0";
						r2[f1]=r["soluong"].ToString();
						r2[f2]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0][f1]=decimal.Parse(dr[0][f1].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0][f2]=decimal.Parse(dr[0][f2].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select 0 as loai,";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
			sql+="from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+user+".d_dmbd c,"+xxx+".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"), d.manguon";
			//xu ly tren d_thucbucstt: bu tu truc
			sql+=" union all select 0 as loai,";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
            sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
			sql+="from "+xxx+".d_xuatsdll a,"+xxx+".d_thucbucstt b,"+user+".d_dmbd c,"+xxx+".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//xuat CK, BS, XK
			sql+=" union all select 1 as loai,";
			if (i_tt==1) sql+="a.khox makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('BS','XK') ";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" a.khox,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//BHYT
			sql+=" union all select 0 as loai,";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//ngoaitru
			//BHYT
			sql+=" union all select 0 as loai,";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
			sql+="from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+user+".d_dmbd c,"+xxx+".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			string f1,f2;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{	
				f1="slxuat";f2="stxuat";
				if (r["loai"].ToString()=="1")
				{
					f1="slxuat_k";f2="stxuat_k";
				}
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slnhap_ck"]=0;
						r2["stnhap_ck"]=0;
						r2["slxuat_ck"]=0;
						r2["stxuat_ck"]=0;
						r2["slxuat_k"]=0;
						r2["stxuat_k"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2[f1]=r["soluong"].ToString();
						r2[f2]=r["sotien"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0][f1]=decimal.Parse(dr[0][f1].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0][f2]=decimal.Parse(dr[0][f2].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			sql="select ";
			if (i_tt==1) sql+="a.khox makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK')";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+="a.khox,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{	
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slnhap_ck"]=0;
						r2["stnhap_ck"]=0;
						r2["slxuat_k"]="0";
						r2["stxuat_k"]="0";
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["slxuat_ck"]=0;
						r2["stxuat_ck"]=0;
						r2["slxuat"]="0";
						r2["stxuat"]="0";
						r2["slxuat_ck"]=r["soluong"].ToString();
						r2["stxuat_ck"]=r["sotien"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["slxuat_ck"]=decimal.Parse(dr[0]["slxuat_ck"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["stxuat_ck"]=decimal.Parse(dr[0]["stxuat_ck"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,";
			sql+="sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai=3 and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+="b.makho,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=-decimal.Parse(r["soluong"].ToString());
						r2["stxuat"]=-decimal.Parse(r["sotien"].ToString());
						r2["dongia"]=r["dongia"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						else
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
						r2["slxuat_k"]="0";
						r2["stxuat_k"]="0";
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
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


		private void rptNxt_bh_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void get_data()
		{
			s_khott="";
			if (tu.Value>den.Value)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Tháng không hợp lệ !"),d.Msg);
				tu.Focus();
				return;
			}
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++) 
				if (manhom.GetItemChecked(i)) s_manhom+=dtdmnhom.Rows[i]["id"].ToString()+",";
			s_kho="";
			string s_tenkho="";
			for(int i=0;i<kho.Items.Count;i++) 
			{
				if (kho.GetItemChecked(i))
				{
					s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
					s_tenkho+=dtdmkho.Rows[i]["ten"].ToString()+",";
				}
			}
			ds.Clear();
			dsxml.Clear();
			sql="select * from "+user+".d_dmkho where khott=1 and nhom="+i_nhom+" order by id";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows) s_khott+=r["id"].ToString().Trim()+",";
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			int y1=int.Parse(yyyy.Value.ToString()),m1=int.Parse(tu.Value.ToString());
			int y2=int.Parse(yyyy.Value.ToString()),m2=int.Parse(den.Value.ToString());
			int itu,iden;
			string mmyy=m1.ToString().PadLeft(2,'0')+y1.ToString().Substring(2,2);
			if (d.bMmyy(mmyy))get_tondau(mmyy);
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{						
						get_nhap(mmyy);
						get_xuat(mmyy);
						get_hoantra(mmyy);
						if (manguon.SelectedIndex!=-1) get_chuyennguon(mmyy);
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
			ts=0;
			foreach(DataRow r in dsxml.Tables[0].Rows)
				ts+=decimal.Parse(r["STTONDAU"].ToString())+decimal.Parse(r["STNHAP"].ToString())+decimal.Parse(r["STNHAP_CK"].ToString())-decimal.Parse(r["STXUAT"].ToString())-decimal.Parse(r["STXUAT_CK"].ToString())-decimal.Parse(r["STXUAT_K"].ToString());
			string s_thoigian=d.title(tu.Value.ToString(),den.Value.ToString())+" Năm "+yyyy.Value.ToString();
			if(s_tenkho!="")s_thoigian=s_tenkho.Substring(0,s_tenkho.Trim().Length-1)+" - "+s_thoigian;
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,tenfile,s_thoigian,(manguon.SelectedIndex==-1)?"":"Nguồn :"+manguon.Text,"",dso.doithapphan(ts.ToString()),"","","","","","");
			f.ShowDialog();
		}
	}
}
