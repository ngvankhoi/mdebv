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
	/// Summary description for rptNxt_tonghop.
	/// </summary>
	public class rptNxt_CK : System.Windows.Forms.Form
	{
        Language lan = new Language();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private int i_nhom,i_tt,i_dongiale;
		private bool bClear=true,bGiaban,bGiabandot;
		private string user,xxx,sql,s_mmyy,s_tu,s_den,s_yy,s_kho,tenfile,s_manhom,tenreport,exp,s_khott;
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
        private CheckBox chkXML;
        private CheckBox gianovat;
        private CheckBox chktonghop;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptNxt_CK(AccessData acc,int nhom,string kho,string mmyy,string file,bool giaban)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
			tenfile=file;
			tu.Value=decimal.Parse(mmyy.Substring(0,2));
			den.Value=tu.Value;bGiaban=giaban;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptNxt_CK));
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
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.gianovat = new System.Windows.Forms.CheckBox();
            this.chktonghop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
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
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 14;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(234, 222);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(60, 25);
            this.butKetthuc.TabIndex = 15;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 37);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(200, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn :";
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
            this.label6.Location = new System.Drawing.Point(-8, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kho :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 60);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(200, 132);
            this.kho.TabIndex = 11;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-8, 194);
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
            "Kho,nhóm kế toán",
            "Nhóm",
            "Phân loại"});
            this.tt.Location = new System.Drawing.Point(56, 194);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(200, 21);
            this.tt.TabIndex = 13;
            this.tt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(374, 217);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(85, 17);
            this.chkXML.TabIndex = 17;
            this.chkXML.Text = "Xuất ra XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // gianovat
            // 
            this.gianovat.AutoSize = true;
            this.gianovat.Location = new System.Drawing.Point(300, 216);
            this.gianovat.Name = "gianovat";
            this.gianovat.Size = new System.Drawing.Size(73, 17);
            this.gianovat.TabIndex = 18;
            this.gianovat.Text = "In giá gốc";
            this.gianovat.UseVisualStyleBackColor = true;
            this.gianovat.CheckedChanged += new System.EventHandler(this.gianovat_CheckedChanged);
            // 
            // chktonghop
            // 
            this.chktonghop.AutoSize = true;
            this.chktonghop.Location = new System.Drawing.Point(56, 217);
            this.chktonghop.Name = "chktonghop";
            this.chktonghop.Size = new System.Drawing.Size(80, 17);
            this.chktonghop.TabIndex = 19;
            this.chktonghop.Text = "In tổng hợp";
            this.chktonghop.UseVisualStyleBackColor = true;
            // 
            // rptNxt_CK
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(466, 271);
            this.Controls.Add(this.chktonghop);
            this.Controls.Add(this.gianovat);
            this.Controls.Add(this.chkXML);
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
            this.Name = "rptNxt_CK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập xuất tồn";
            this.Load += new System.EventHandler(this.rptNxt_CK_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptNxt_CK_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void rptNxt_CK_Load(object sender, System.EventArgs e)
		{
            user = d.user;
			bGiabandot=d.bGiaban_theodot(i_nhom);
			i_dongiale=d.d_dongia_le(i_nhom);
			if (tt.Items.Count>0) tt.SelectedIndex=0;
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

            dtdmnhom = d.get_data("select * from " + user + ".d_dmnhom where stt<>0 and nhom=" + i_nhom + " order by stt").Tables[0];
            manhom.DataSource = dtdmnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";
			
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			ds.ReadXml("..\\..\\..\\xml\\d_nxt_ck.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_nxt_ck.xml");
            ds.Tables[0].Columns.Add("gianovat", typeof(decimal));
            ds.Tables[0].Columns.Add("sotk");
            dsxml.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("sotk");
			if (bGiaban) tt.SelectedIndex=3;
            gianovat.Checked=d.Thongso("gianovat")=="1";
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			i_tt=tt.SelectedIndex;
			if (i_tt==0)
			{
                sql = "select a.*, b.stt as tt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai,g.ma as stk ";
                sql+=" from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id ";
                sql+=" inner join " + user + ".d_dmhang e on a.mahang=e.id ";
                sql+=" inner join " + user + ".d_dmloai f on a.maloai=f.id ";
                sql += " left join " + user + ".d_dmnhomkt g on a.sotk=g.id ";
				sql+=" where a.nhom="+i_nhom+" order by a.id";
			}
			else if (i_tt==1)
			{
				sql="select a.*, b.stt as tt, b.ten as tennhom,b.ma as stk";
                sql += " from " + user + ".d_dmbd a," + user + ".d_dmnhomkt b where a.sotk=b.id and a.nhom=" + i_nhom + " order by a.id";
			}
			else if (i_tt==2) //nhom
			{
				sql="select a.*, b.stt as tt, b.ten as tennhom,c.ma as stk";
                sql+=" from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b ";
                sql+=" on a.manhom=b.id left join "+user+".d_dmnhomkt c on a.sotk=c.id ";
                sql+=" where a.nhom=" + i_nhom + " order by a.id";
			}
			else //phan  loai
			{
				sql="select a.*, b.stt as tt, b.ten as tennhom,c.ma as stk";
                sql += " from " + user + ".d_dmbd a inner join " + user + ".d_dmloai b on a.maloai=b.id ";
                sql+=" left join "+user+".d_dmnhomkt c on a.sotk=c.id where a.nhom=" + i_nhom + " order by a.id";
			}
			dt=d.get_data(sql).Tables[0];
			get_data();
		}

		private void get_sort()
		{
			//d.delrec(dsxml.Tables[0],"tondau+slnhap+slxuat+slxuat_ck+slnhap_ck=0");
			dsxml.Clear();
			sql=(s_manhom!="")?"idnn,stt,ten":"idnn,stt,ten";
			tenreport=tenfile;
			//dsxml.Merge(ds.Tables[0].Select("ma<>'' and tondau+slnhap+slxuat+slxuat_ck+slnhap_ck>0",sql));			
            dsxml.Merge(ds.Tables[0].Select("ma<>''", sql));
		}

		private void get_tondau(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+="a.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="c.giaban,";
				else sql+="b.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "c.gianovat,";
            else sql += "0 as gianovat,";
			sql+="a.mabd,trunc(c.giamua,"+i_dongiale+") as dongia,c.manguon,sum(a.tondau) as soluong,";
            if (gianovat.Checked) sql += "sum(a.tondau*c.gianovat) as sotien ";
            else sql+="sum(a.tondau*c.giamua) as sotien ";
            sql += "from " + xxx + ".d_tonkhoct a," + user + ".d_dmbd b," + xxx + ".d_theodoi c ";
			sql+=" where a.mabd=b.id and a.stt=c.id and b.nhom="+i_nhom;
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and b.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and c.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="a.makho,";
			if (bGiaban) 
			{
				if (bGiabandot) sql+="c.giaban,";
				else sql+="b.giaban,";
			}
            if (gianovat.Checked) sql += "c.gianovat,";            
			sql+="a.mabd,trunc(c.giamua,"+i_dongiale+"),c.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
                exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
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
                        r2["sotk"] = r3["stk"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=r["soluong"].ToString();
						r2["sttondau"]=r["sotien"].ToString();
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
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
			if (bGiaban) 
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += "sum(b.soluong*d.gianovat) as sotien ";
            else sql+="sum(b.soluong*d.giamua) as sotien ";
            sql+=" from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban) 
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
                exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
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
                        r2["sotk"] = r3["stk"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						r2["slxuat_ck"]=r["soluong"].ToString();
						r2["stxuat_ck"]=r["sotien"].ToString();
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
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
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += "sum(b.soluong*d.gianovat) as sotien ";
            else sql+="sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.stttchuyen=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
                exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
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
                        r2["sotk"] = r3["stk"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						r2["slnhap_ck"]=r["soluong"].ToString();
						r2["stnhap_ck"]=r["sotien"].ToString();
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
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
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "b.dongia as gianovat,";
            else sql += "0 as gianovat,";
			sql+="0 as loai,b.mabd,trunc(b.giamua,"+i_dongiale+") as dongia,a.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked)  sql += " sum(b.sotien+b.cuocvc+b.chaythu) as sotien ";
            else sql+=" sum(b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu) as sotien ";
            sql += "from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c where a.id=b.id and b.mabd=c.id and a.nhom=" + i_nhom + "  and b.soluong>0";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and a.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" group by ";
			if (i_tt==1) sql+="a.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "b.dongia,";
			sql+="b.mabd,trunc(b.giamua,"+i_dongiale+"),a.manguon";
			if (s_khott=="")
			{
				sql+=" union all select ";
				if (i_tt==1) sql+="a.khon as makho,";
				if (bGiaban)
				{
					if (bGiabandot) sql+="b.giaban,";
					else sql+="c.giaban,";
				}
				else sql+="0 as giaban,";
                if (gianovat.Checked) sql += "d.gianovat,";
                else sql += "0 as gianovat,";
				sql+="0 as loai,b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
				sql+="sum(b.soluong) as soluong,";
                if (gianovat.Checked)  sql += " sum(b.soluong*d.gianovat) as sotien ";
                else sql+=" sum(b.soluong*d.giamua) as sotien ";
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
				if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" group by ";
				if (i_tt==1) sql+="a.khon,";
				if (bGiaban)
				{
					if (bGiabandot) sql+="b.giaban,";
					else sql+="c.giaban,";
				}
                if (gianovat.Checked) sql += "d.gianovat,";
				sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			}
			else
			{
				sql+=" union all select ";
				if (i_tt==1) sql+="a.khon as makho,";
				if (bGiaban)
				{
					if (bGiabandot) sql+="b.giaban,";
					else sql+="c.giaban,";
				}
				else sql+="0 as giaban,";
                if (gianovat.Checked) sql += "d.gianovat,";
                else sql += "0 as gianovat,";
				sql+="1 as loai,b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
				sql+="sum(b.soluong) as soluong,";
                if (gianovat.Checked) sql+=" sum(b.soluong*d.gianovat) as sotien ";
                else sql += " sum(b.soluong*d.giamua) as sotien ";
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
				if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
				if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
				if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
				sql+=" and a.khox not in ("+s_khott.Substring(0,s_khott.Length-1)+")";
				sql+=" group by ";
				if (i_tt==1) sql+="a.khon,";
				if (bGiaban)
				{
					if (bGiabandot) sql+="b.giaban,";
					else sql+="c.giaban,";
				}
                if (gianovat.Checked) sql += "d.gianovat,";
				sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
			
				if (!d.bChuyenkho_inrieng(i_nhom) || kho.SelectedItems.Count==1)
				{
					sql+=" union all select ";
					if (i_tt==1) sql+="a.khon as makho,";
					if (bGiaban)
					{
						if (bGiabandot) sql+="b.giaban,";
						else sql+="c.giaban,";
					}
					else sql+="0 as giaban,";
                    if (gianovat.Checked) sql += "d.gianovat,";
                    else sql += "0 as gianovat,";
					sql+="1 as loai,b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,";
					sql+="sum(b.soluong) as soluong,";
                    if (gianovat.Checked) sql += " sum(b.soluong*d.gianovat) as sotien ";
                    else sql+=" sum(b.soluong*d.giamua) as sotien ";
                    sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
					if (s_kho!="") sql+=" and a.khon in ("+s_kho.Substring(0,s_kho.Length-1)+")";
					if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
					if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
					sql+=" and b.soluong>0 and a.khox in ("+s_khott.Substring(0,s_khott.Length-1)+")";
					sql+=" group by ";
					if (i_tt==1) sql+="a.khon,";
					if (bGiaban)
					{
						if (bGiabandot) sql+="b.giaban,";
						else sql+="c.giaban,";
					}
                    if (gianovat.Checked) sql += "d.gianovat,";
					sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon ";
				}
			}
			string f1="slnhap",f2="stnhap";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
				if (r3!=null)
				{
					f1="slnhap";f2="stnhap";
					if (r["loai"].ToString()=="1")// && !bGiaban)
					{
						f1+="_ck";f2+="_ck";
					}
					exp="mabd="+int.Parse(r["mabd"].ToString());
					exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
                    exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
					if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
					if (i_tt==1) exp+=" and idnn="+int.Parse(r["makho"].ToString());
					r1=d.getrowbyid(ds.Tables[0],exp);
					if ( r1 == null )
					{
						r2 = ds.Tables[0].NewRow();
						r2["manhom"]=r3["manhom"].ToString();
						r2["tennhom"]=r3["tennhom"].ToString();
						r2["mabd"]=r["mabd"].ToString();
                        r2["sotk"] = r3["stk"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						r2["slxuat_ck"]="0";
						r2["stxuat_ck"]="0";
						r2["slnhap_ck"]="0";
						r2["stnhap_ck"]="0";
						r2["slnhap"]="0";
						r2["stnhap"]="0";
						r2[f1]=r["soluong"].ToString();
						r2[f2]=r["sotien"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
					else
					{
						DataRow[] dr = ds.Tables[0].Select(exp);
						dr[0][f1]=decimal.Parse(dr[0][f1].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0][f2]=decimal.Parse(dr[0][f2].ToString())+decimal.Parse(r["sotien"].ToString());
					}
				}
			}
			ds.AcceptChanges();
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked)  sql += "sum(b.soluong*d.gianovat) as sotien ";
            else sql+="sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=" + i_nhom ;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//xu ly tren d_thucbucstt: bu tu truc
			sql+=" union all select ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += " sum(b.soluong*d.gianovat) as sotien ";
            else sql+=" sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//xuat CK, BS, XK
			sql+=" union all select ";
			if (i_tt==1) sql+="a.khox makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += " sum(b.soluong*d.gianovat) as sotien ";
            else sql += " sum(b.soluong*d.giamua) as sotien ";
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
			sql+=" and a.loai in ('BS','XK')";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" a.khox,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//BHYT
			sql+=" union all select ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += " sum(b.soluong*d.gianovat) as sotien ";
            else sql+=" sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			//ngoaitru
			//BHYT
			sql+=" union all select ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia, d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql+=" sum(b.soluong*d.gianovat) as sotien ";
            else sql += " sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+=" b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{				
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
                exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
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
                        r2["sotk"] = r3["stk"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slnhap_ck"]=0;
						r2["stnhap_ck"]=0;
						r2["slxuat_ck"]=0;
						r2["stxuat_ck"]=0;
						r2["slxuat"]=r["soluong"].ToString();
						r2["stxuat"]=r["sotien"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						r2["noingoai"]="";
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
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
					dr[0]["slxuat"]=decimal.Parse(dr[0]["slxuat"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["stxuat"]=decimal.Parse(dr[0]["stxuat"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			sql="select ";
			if (i_tt==1) sql+="a.khox makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += " sum(b.soluong*d.gianovat) as sotien ";
            else sql += " sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK')";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+="a.khox,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{	
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
                exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
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
                        r2["sotk"] = r3["stk"].ToString();
						r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slnhap_ck"]=0;
						r2["stnhap_ck"]=0;
						r2["slxuat"]=0;
						r2["stxuat"]=0;
						r2["slxuat_ck"]=0;
						r2["stxuat_ck"]=0;
						r2["slxuat"]="0";
						r2["stxuat"]="0";
						//if (bGiaban)
						//{
						//	r2["slxuat"]=r["soluong"].ToString();
						//	r2["stxuat"]=r["sotien"].ToString();
						//}
						//else
						//{
							r2["slxuat_ck"]=r["soluong"].ToString();
							r2["stxuat_ck"]=r["sotien"].ToString();
						//}
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
						}
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					//if (bGiaban)
					//{
					//	dr[0]["slxuat"]=decimal.Parse(dr[0]["slxuat"].ToString())+decimal.Parse(r["soluong"].ToString());
					//	dr[0]["stxuat"]=decimal.Parse(dr[0]["stxuat"].ToString())+decimal.Parse(r["sotien"].ToString());
					//}
					//else
					//{
						dr[0]["slxuat_ck"]=decimal.Parse(dr[0]["slxuat_ck"].ToString())+decimal.Parse(r["soluong"].ToString());
						dr[0]["stxuat_ck"]=decimal.Parse(dr[0]["stxuat_ck"].ToString())+decimal.Parse(r["sotien"].ToString());
					//}
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
			else sql+="0 as giaban,";
            if (gianovat.Checked) sql += "d.gianovat,";
            else sql += "0 as gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+") as dongia,d.manguon,";
			sql+="sum(b.soluong) as soluong,";
            if (gianovat.Checked) sql += " sum(b.soluong*d.gianovat) as sotien ";
            else sql += " sum(b.soluong*d.giamua) as sotien ";
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai=3 and a.nhom=" + i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and d.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
			sql+=" group by ";
			if (i_tt==1) sql+="b.makho,";
			if (bGiaban)
			{
				if (bGiabandot) sql+="b.giaban,";
				else sql+="c.giaban,";
			}
            if (gianovat.Checked) sql += "d.gianovat,";
			sql+="b.mabd,trunc(d.giamua,"+i_dongiale+"),d.manguon";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString());
				exp+=" and dongia="+decimal.Parse(r["dongia"].ToString());
                exp += " and gianovat=" + decimal.Parse(r["gianovat"].ToString());
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
                        r2["sotk"] = r3["stk"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						if (i_tt==0) r2["tenhc"]=r3["tenhc"].ToString();
						else r2["tenhc"]="";
						r2["noingoai"]="";
						r2["dang"]=r3["dang"].ToString();
						r2["tondau"]=0;
						r2["sttondau"]=0;
						r2["slnhap"]=0;
						r2["stnhap"]=0;
						r2["slxuat"]=-decimal.Parse(r["soluong"].ToString());
						r2["stxuat"]=-decimal.Parse(r["sotien"].ToString());
						r2["dongia"]=r["dongia"].ToString();
						r2["giaban"]=r["giaban"].ToString();
                        r2["gianovat"] = r["gianovat"].ToString();
						r2["sttt"]=0;
						r2["manguon"]=r["manguon"].ToString();
						r2["stt"]=r3["tt"].ToString();
						if (i_tt==0)
						{
							r2["idnn"]=r3["idnn"].ToString();
							r2["noingoai"]=r3["noingoai"].ToString();
						}
						else if (i_tt==1)
						{
							r4=d.getrowbyid(dtdmkho,"id="+int.Parse(r["makho"].ToString()));
							if (r4!=null)
							{
								r2["idnn"]=r["makho"].ToString();
								r2["noingoai"]=r4["ten"].ToString();
							}
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


		private void rptNxt_CK_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
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
				MessageBox.Show(lan.Change_language_MessageText("Tháng không hợp lệ !"),d.Msg);
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
			sql="select * from "+user+".d_dmkho where khott=1 and nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by id";
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
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return;
			}
			get_sort();
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\nxtnhathuoc.xml", XmlWriteMode.WriteSchema);
            }
			if (bGiaban) tenreport=tenfile;
			else tenreport=(s_kho=="" && d.bChuyenkho_inrieng(i_nhom))?"d_bcnxt_ck_n.rpt":tenfile;
            if (chktonghop.Checked) tenreport = tenreport.Replace(".rpt", "") + "_th.rpt";
			string s_thoigian=d.title(tu.Value.ToString(),den.Value.ToString())+" Năm "+yyyy.Value.ToString();
			if(s_tenkho!="")s_thoigian=s_tenkho.Substring(0,s_tenkho.Trim().Length-1)+" - "+s_thoigian;
			frmReport f=new frmReport(d,dsxml.Tables[0],tenreport,s_thoigian,(manguon.SelectedIndex==-1)?"":"Nguồn :"+manguon.Text,"","","","","","","","");
			f.ShowDialog();
			if (d.bChuyenkho_inrieng(i_nhom))
			{
				if (ds.Tables[0].Select("slxuat_ck>0").Length>0)
				{
					d.delrec(dsxml.Tables[0],"slxuat_ck=0");
					tenreport="d_chuyenkho.rpt";
					dsxml.WriteXml("..\\..\\..\\xml\\d_nxt_ck.xml",XmlWriteMode.WriteSchema);
					frmReport f1=new frmReport(d,dsxml.Tables[0],tenreport,s_thoigian,(manguon.SelectedIndex==-1)?"":"Nguồn :"+manguon.Text,"","","","","","","","");
					f1.ShowDialog();
				}
			}
		}

        private void gianovat_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl==gianovat) d.writeXml("d_thongso", "gianovat", (gianovat.Checked) ? "1" : "0");
        }
	}
}

