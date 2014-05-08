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
	public class rptXuatkho : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
        private int i_nhom = 0, i_userid = 0;
		private bool bClear=true;
		private string user,xxx,sql,s_mmyy,s_tu,s_den,s_yy,s_kho,tenfile,s_manhom,tenreport,exp, s_gia="";
		private DataRow r1,r2,r3;
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
		private System.Windows.Forms.CheckedListBox kho;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckBox chkgianovat;
        private RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptXuatkho(AccessData acc,int nhom,string kho,string mmyy,string file, int _userid)
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
			den.Value=tu.Value;
			yyyy.Value=decimal.Parse("20"+mmyy.Substring(2,2));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptXuatkho));
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
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkgianovat = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(171, 217);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 13;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(243, 217);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(64, 27);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(200, 21);
            this.manguon.TabIndex = 7;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(64, 4);
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
            this.yyyy.Location = new System.Drawing.Point(216, 4);
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
            this.den.Location = new System.Drawing.Point(136, 4);
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
            this.label3.Location = new System.Drawing.Point(104, 4);
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
            this.manhom.Location = new System.Drawing.Point(266, 0);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(200, 180);
            this.manhom.TabIndex = 12;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(64, 49);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(200, 132);
            this.kho.TabIndex = 11;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(499, 276);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkgianovat);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.manhom);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.yyyy);
            this.tabPage1.Controls.Add(this.manguon);
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 250);
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
            this.tabPage2.Size = new System.Drawing.Size(491, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkgianovat
            // 
            this.chkgianovat.AutoSize = true;
            this.chkgianovat.Location = new System.Drawing.Point(64, 186);
            this.chkgianovat.Name = "chkgianovat";
            this.chkgianovat.Size = new System.Drawing.Size(127, 17);
            this.chkgianovat.TabIndex = 15;
            this.chkgianovat.Text = "In theo giá trước VAT";
            this.chkgianovat.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(485, 244);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // rptXuatkho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(499, 276);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptXuatkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất kho từ tháng ... đến tháng";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptXuatkho_MouseMove);
            this.Load += new System.EventHandler(this.rptXuatkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptXuatkho_Load(object sender, System.EventArgs e)
		{
            user = d.user;

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

			dtdmnhom=d.get_data("select * from "+user+".d_dmnhom where stt<>0 and nhom="+i_nhom+" order by stt").Tables[0];
			manhom.DataSource=dtdmnhom;
            manhom.DisplayMember = "TEN";
            manhom.ValueMember = "ID";

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where id=0 or nhom="+i_nhom+" order by stt").Tables[0];

            sql = "select a.*, b.stt as tt, b.ten as nhombd, a.maloai as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f";
			sql+=" where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.nhom="+i_nhom+" order by a.id";
			dt=d.get_data(sql).Tables[0];			
			ds.ReadXml("..\\..\\..\\xml\\d_dasudung.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\d_dasudung.xml");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			get_data();
		}

		private void get_sort()
		{
			dsxml.Clear();
			sql=(s_manhom!="")?"ten":"ten";
			tenreport=tenfile;
			DataRow []dr=ds.Tables[0].Select("ma<>''",sql);
			for(int i=0;i<dr.Length;i++)
			{
				r2 = dsxml.Tables[0].NewRow();
				r2["mabd"]=dr[i]["mabd"].ToString();
				r2["ma"]=dr[i]["ma"].ToString();
				r2["ten"]=dr[i]["ten"].ToString().Trim();
				r2["tenhc"]=dr[i]["tenhc"].ToString();
				r2["dang"]=dr[i]["dang"].ToString();
				r2["soluong"]=dr[i]["soluong"].ToString();
				r2["sotien"]=dr[i]["sotien"].ToString();
				r2["dongia"]=dr[i]["dongia"].ToString();
				//Nhombd
				r2["stt"]=dr[i]["stt"].ToString();
				r2["nhombd"]=dr[i]["nhombd"].ToString();
				r2["idnn"]=dr[i]["idnn"].ToString();
				r2["noingoai"]=dr[i]["noingoai"].ToString();
				//
				dsxml.Tables[0].Rows.Add(r2);
			}
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
            s_gia = chkgianovat.Checked ? "t.gianovat" : "t.giamua";
            sql = "select b.makho,b.mabd,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia, t.manguon ";
            sql+="from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in(1,4) and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and t.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            sql += " group by b.makho,b.mabd," + s_gia + ", t.manguon";
			//xu ly tren d_thucbucstt: bu tu truc
			sql+=" union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien," + s_gia + " as dongia, t.manguon ";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucbucstt b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai in(2) and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            sql += " group by b.makho,b.mabd," + s_gia + ", t.manguon  ";
			//xuat CK, BS, XK
			sql+=" union all ";
            sql += "select a.khox as makho,b.mabd,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " dongia, t.manguon ";
            sql+="from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom+" and a.loai in ('BS','XK')";
			if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            sql += " group by a.khox,b.mabd, " + s_gia + ", t.manguon ";
			//BHYT
			sql+=" union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia, t.manguon ";
            sql+=" from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            sql += " group by b.makho,b.mabd, " + s_gia + ", t.manguon ";
			//ngoaitru
			//BHYT
			sql+=" union all ";
            sql += "select b.makho,b.mabd,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia, t.manguon ";
            sql+="from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            sql += " group by b.makho,b.mabd, " + s_gia + ", t.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{				
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
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
						r2["sotien"]=r["sotien"].ToString();
						r2["dongia"]=r["dongia"].ToString();
						//nhombd
						r2["stt"]=r3["tt"].ToString();
						r2["nhombd"]=r3["nhombd"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
					dr[0]["soluong"]=decimal.Parse(dr[0]["soluong"].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["sotien"]=decimal.Parse(dr[0]["sotien"].ToString())+decimal.Parse(r["sotien"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
            s_gia = chkgianovat.Checked ? "t.gianovat" : "t.giamua";
            sql = "select b.makho,b.mabd,sum(b.soluong) as soluong,sum(b.soluong*" + s_gia + ") as sotien, " + s_gia + " as dongia, t.manguon ";
            sql+=" from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql+=" where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 and a.nhom="+i_nhom;
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
			sql+=" and b.soluong>0";
            sql += " group by b.makho,b.mabd, " + s_gia + ", t.manguon ";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				exp="mabd="+int.Parse(r["mabd"].ToString())+" and dongia="+decimal.Parse(r["dongia"].ToString());
				if (manguon.SelectedIndex!=-1) exp+=" and manguon="+int.Parse(manguon.SelectedValue.ToString());
				r1=d.getrowbyid(ds.Tables[0],exp);
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
						r2["dongia"]=r["dongia"].ToString();
						//nhombd
						r2["stt"]=r3["tt"].ToString();
						r2["nhombd"]=r3["nhombd"].ToString();
						r2["idnn"]=r3["idnn"].ToString();
						r2["noingoai"]=r3["noingoai"].ToString();
						//
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					DataRow[] dr = ds.Tables[0].Select(exp);
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


		private void rptXuatkho_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void get_data()
		{
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
			s_mmyy=tu.Value.ToString().PadLeft(2,'0')+yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			s_tu=tu.Value.ToString().PadLeft(2,'0');
			s_den=den.Value.ToString().PadLeft(2,'0');
			s_yy=yyyy.Value.ToString().PadLeft(4,'0').Substring(2,2);
			int y1=int.Parse(yyyy.Value.ToString()),m1=int.Parse(tu.Value.ToString());
			int y2=int.Parse(yyyy.Value.ToString()),m2=int.Parse(den.Value.ToString());
			int itu,iden;
			string mmyy=m1.ToString().PadLeft(2,'0')+y1.ToString().Substring(2,2);
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{						
						get_xuat(mmyy);
						get_hoantra(mmyy);
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
			string s_thoigian=d.title(tu.Value.ToString(),den.Value.ToString())+" "+
lan.Change_language_MessageText("Năm")+" "+yyyy.Value.ToString();
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,"d_dasudung.rpt",s_thoigian,"",(manguon.SelectedIndex==-1)?"":"Nguồn :"+manguon.Text,"","PHIẾU XUẤT KHO","","","","","");
			f.ShowDialog();
		}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
	}
}
