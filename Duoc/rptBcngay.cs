using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Data;
using LibDuoc;
using Excel;
namespace Duoc
{
	/// <summary>
	/// Summary description for rptBcngay.
	/// </summary>
	public class rptBcngay : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private DataColumn dc;
		private AccessData d;
		private int i_nhom,i_id;
        private string s_gia = "",s_makp="";
		private bool bClear=true;
		private string user,stime,xxx,sql,tenfile,s_kho,s_makho,s_manhom,s_maloai;
		private DataRow r1,r2,r3;
		private DataRow[] dr;
		private DataSet ds;
		private System.Data.DataTable dt=new System.Data.DataTable();
        private System.Data.DataTable dtkho = new System.Data.DataTable();
        private System.Data.DataTable dt_duockp = new System.Data.DataTable();
		private System.Data.DataTable dtdmkho=new System.Data.DataTable();
		private System.Data.DataTable dtnhom=new System.Data.DataTable();
		private System.Data.DataTable dtloai=new System.Data.DataTable();
		private DataSet dsngay=new DataSet();
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox manguon;
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
		Excel.Range orange;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox manhom;
		private System.Windows.Forms.CheckedListBox maloai;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private ComboBox makp;
        private System.Windows.Forms.Label label3;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBcngay(AccessData acc,int nhom,string kho)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBcngay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.manhom = new System.Windows.Forms.CheckedListBox();
            this.maloai = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.makp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.label1.Text = "Từ ngày :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(135, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(207, 236);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(279, 236);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(58, 26);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(192, 21);
            this.manguon.TabIndex = 2;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(58, 72);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(192, 148);
            this.kho.TabIndex = 4;
            // 
            // butXem
            // 
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(135, 236);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 5;
            this.butXem.Text = "&Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(58, 3);
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
            this.den.Location = new System.Drawing.Point(170, 3);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // manhom
            // 
            this.manhom.CheckOnClick = true;
            this.manhom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manhom.Location = new System.Drawing.Point(253, 3);
            this.manhom.Name = "manhom";
            this.manhom.Size = new System.Drawing.Size(192, 100);
            this.manhom.TabIndex = 11;
            this.manhom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // maloai
            // 
            this.maloai.CheckOnClick = true;
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(253, 105);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(192, 116);
            this.maloai.TabIndex = 12;
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 305);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.makp);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.manguon);
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.maloai);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.manhom);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.butXem);
            this.tabPage1.Controls.Add(this.kho);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(483, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xuất sử dụng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(58, 49);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(192, 21);
            this.makp.TabIndex = 18;
            this.makp.SelectedIndexChanged += new System.EventHandler(this.makp_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Khoa :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(483, 279);
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
            this.richTextBox1.Size = new System.Drawing.Size(477, 273);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // rptBcngay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(491, 305);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBcngay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sử dụng theo ngày";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptBcngay_MouseMove);
            this.Load += new System.EventHandler(this.rptBcngay_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBcngay_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			dtnhom=d.get_data("select * from "+user+".d_dmnhom where nhom="+i_nhom+" order by stt").Tables[0];
            dtloai = d.get_data("select * from " + user + ".d_dmloai where nhom=" + i_nhom + " order by stt").Tables[0];
            manhom.DataSource = dtnhom;
			manhom.DisplayMember="TEN";
			manhom.ValueMember="ID";

            maloai.DataSource = dtloai;
			maloai.DisplayMember="TEN";
			maloai.ValueMember="ID";
			
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            dt = d.get_data("select * from " + user + ".d_dmbd where nhom=" + i_nhom + " order by id").Tables[0];
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
            kho.DataSource = dtdmkho;
			kho.DisplayMember="TEN";
			kho.ValueMember="ID";

            dt_duockp = d.get_data("select * from " + user + ".d_duockp order by stt").Tables[0];
            makp.DataSource = dt_duockp;
            makp.DisplayMember = "TEN";
            makp.ValueMember = "ID";
            makp.SelectedIndex = -1;

			dsngay.ReadXml("..\\..\\..\\xml\\d_tsngay.xml");
		}

		private void Tao_dataset()
		{
			ds=new DataSet();
			ds.ReadXml("..\\..\\..\\xml\\d_bcngay.xml");
            ds.Tables[0].Columns.Remove("ma");
            ds.Tables[0].Columns.Add("QUYCACH").SetOrdinal(4);//gam 08/03/2012
			dsngay.Clear();
			DateTime dt1=d.StringToDate(tu.Text);
			DateTime dt2=d.StringToDate(den.Text);
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
                    xxx = user + mmyy;
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select distinct to_char(ngay,'yymmdd') as ngay,to_char(ngay,'dd/mm') as ten from "+xxx+".d_xuatsdll where nhom=" + i_nhom + " and ngay between to_date('" + tu.Text + "',"+stime+") and to_date('" + den.Text + "',"+stime+")";
                        sql += "union all select distinct to_char(ngay,'yymmdd') as ngay,to_char(ngay,'dd/mm') as ten from " + xxx + ".d_xuatll where nhom=" + i_nhom + " and loai='XK' and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                        sql += "union all select distinct to_char(ngay,'yymmdd') as ngay,to_char(ngay,'dd/mm') as ten from " + xxx + ".d_ngtrull where nhom=" + i_nhom + " and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                        sql += "union all select distinct to_char(a.ngay,'yymmdd') as ngay,to_char(a.ngay,'dd/mm') as ten from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b where a.id=b.id and a.nhom=" + i_nhom + " and ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                        dr = d.get_data(sql).Tables[0].Select("ngay<>''", "ngay");
                        for (int k = 0; k < dr.Length; k++)
                        {
                            r1 = d.getrowbyid(dsngay.Tables[0], "ngay='" + dr[k]["ngay"].ToString() + "'");
                            if (r1 == null)
                            {
                                r2 = dsngay.Tables[0].NewRow();
                                r2["ngay"] = dr[k]["ngay"].ToString();
                                r2["ten"] = dr[k]["ten"].ToString();
                                dsngay.Tables[0].Rows.Add(r2);
                                dc = new DataColumn();
                                dc.ColumnName = "SL_" + dr[k]["ngay"].ToString().Trim();
                                dc.DataType = Type.GetType("System.Decimal");
                                ds.Tables[0].Columns.Add(dc);
                            }
                        }
                    }
				}
			}
			dc=new DataColumn();
			dc.ColumnName="TONGCONG";
			dc.DataType=Type.GetType("System.Decimal");
			ds.Tables[0].Columns.Add(dc);
		}

		private void get_xuat(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai<>3 and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay,"+stime+"),"+stime+") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_maloai!="") sql+=" and c.maloai in ("+s_maloai.Substring(0,s_maloai.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
            if (makp.SelectedIndex != -1) sql += " and a.makp="+int.Parse(makp.SelectedValue.ToString());//gam 08/03/2012
			sql+=" group by a.ngay,b.mabd,c.ten order by c.ten";
			ins_items();
			
            //sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".d_xuatll a,"+xxx+".d_xuatct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            //sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai='XK' and a.nhom=" + i_nhom + " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
            //if (s_kho!="") sql+=" and a.khox in ("+s_kho.Substring(0,s_kho.Length-1)+")";
            //if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
            //if (s_maloai!="") sql+=" and c.maloai in ("+s_maloai.Substring(0,s_maloai.Length-1)+")";
            //if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
            //sql+=" group by a.ngay,b.mabd,c.ten order by c.ten";
            //ins_items();

			sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".d_ngtrull a,"+xxx+".d_ngtruct b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay," + stime + ")," + stime + ") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_maloai!="") sql+=" and c.maloai in ("+s_maloai.Substring(0,s_maloai.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
            if (makp.SelectedIndex != -1) sql += " and a.makp=" + int.Parse(makp.SelectedValue.ToString());//gam 08/03/2012
			sql+=" group by a.ngay,b.mabd,c.ten order by c.ten";
			ins_items();

			sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".bhytkb a,"+xxx+".bhytthuoc b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay," + stime + ")," + stime + ") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_maloai!="") sql+=" and c.maloai in ("+s_maloai.Substring(0,s_maloai.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
            if (makp.SelectedIndex != -1) sql += " and a.makp='"+s_makp+"'";;//gam 08/03/2012
			sql+=" group by a.ngay,b.mabd,c.ten order by c.ten";
			ins_items();
		}

		private void ins_items()
		{
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						//r2["ma"]=r3["ma"].ToString();
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dsngay.Tables[0].Rows) r2["sl_"+r4["ngay"].ToString().Trim()]=0;
						r2["sl_"+r["ngay"].ToString().Trim()]=r["soluong"].ToString();
						r2["tongcong"]=r["soluong"].ToString();
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["sl_"+r["ngay"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["ngay"].ToString().Trim()].ToString())+decimal.Parse(r["soluong"].ToString());
					dr[0]["tongcong"]=decimal.Parse(dr[0]["tongcong"].ToString())+decimal.Parse(r["soluong"].ToString());
				}
			}
			ds.AcceptChanges();
		}

		private void get_hoantra(string d_mmyy)
		{
            xxx = user + d_mmyy;
			sql="select to_char(a.ngay,'yymmdd') as ngay,b.mabd,c.ten,sum(b.soluong) as soluong from "+xxx+".d_xuatsdll a,"+xxx+".d_thucxuat b,"+xxx+".d_theodoi t,"+user+".d_dmbd c ";
            sql += "where a.id=b.id and b.sttt=t.id and b.mabd=c.id and a.loai=3 and a.nhom=" + i_nhom + " and to_date(to_char(a.ngay," + stime + ")," + stime + ") between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
			if (s_kho!="") sql+=" and b.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_manhom!="") sql+=" and c.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			if (s_maloai!="") sql+=" and c.maloai in ("+s_maloai.Substring(0,s_maloai.Length-1)+")";
			if (manguon.SelectedIndex!=-1) sql+=" and t.manguon="+int.Parse(manguon.SelectedValue.ToString());
            if (makp.SelectedIndex != -1) sql += " and a.makp=" + int.Parse(makp.SelectedValue.ToString());//gam 08/03/2012
			sql+=" group by a.ngay,b.mabd,c.ten";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				r1=d.getrowbyid(ds.Tables[0],"mabd="+int.Parse(r["mabd"].ToString()));
				if ( r1 == null )
				{
					r3=d.getrowbyid(dt,"id="+int.Parse(r["mabd"].ToString()));
					if (r3!=null)
					{
						r2 = ds.Tables[0].NewRow();
						r2["mabd"]=r["mabd"].ToString();
						r2["stt"]=d.get_stt(ds.Tables[0]);
						//r2["ma"]=r3["ma"].ToString();//Thuy 18.04.2012
						r2["ten"]=r3["ten"].ToString().Trim()+" "+r3["hamluong"].ToString();
						r2["dang"]=r3["dang"].ToString();
						foreach(DataRow r4 in dsngay.Tables[0].Rows) r2["sl_"+r4["ngay"].ToString().Trim()]=0;
						r2["sl_"+r["ngay"].ToString().Trim()]=-decimal.Parse(r["soluong"].ToString());
						r2["tongcong"]=-decimal.Parse(r["soluong"].ToString());
						ds.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr = ds.Tables[0].Select("mabd="+int.Parse(r["mabd"].ToString()));
					dr[0]["sl_"+r["ngay"].ToString().Trim()]=decimal.Parse(dr[0]["sl_"+r["ngay"].ToString().Trim()].ToString())-decimal.Parse(r["soluong"].ToString());
					dr[0]["tongcong"]=decimal.Parse(dr[0]["tongcong"].ToString())-decimal.Parse(r["soluong"].ToString());
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


		private void rptBcngay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (bClear)
			{
				manguon.SelectedIndex=-1;
				bClear=false;
			}
		}

		private void exp_excel(bool print)
		{
			try
			{
				DataSet tmp=new DataSet();
				tmp=ds.Copy();
				ds.Clear();
				ds.Merge(tmp.Tables[0].Select("true","ten,dang"));
				int k=1;
				foreach(DataRow r in ds.Tables[0].Rows) r["stt"]=k++;
				int be=5,dong=7,sodong=ds.Tables[0].Rows.Count+6,socot=ds.Tables[0].Columns.Count-1,dongke=sodong;
				tenfile=d.Export_Excel(ds,"bcngay");
				oxl=new Excel.Application();
				owb=(Excel._Workbook)(oxl.Workbooks.Open(tenfile,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value));
				osheet=(Excel._Worksheet)owb.ActiveSheet;
				oxl.ActiveWindow.DisplayGridlines=true;
				osheet.get_Range(d.getIndex(0)+"1",d.getIndex(0)+"1").EntireColumn.Delete(Missing.Value);
				for(int i=0;i<be;i++) osheet.get_Range(d.getIndex(i)+"1",d.getIndex(i)+"1").EntireRow.Insert(Missing.Value);
				osheet.get_Range(d.getIndex(be)+dong.ToString(),d.getIndex(socot)+sodong.ToString()).NumberFormat="#,##0.00";
				osheet.get_Range(d.getIndex(0)+"5",d.getIndex(socot)+dongke.ToString()).Borders.LineStyle=XlBorderWeight.xlHairline;
				for(int i=1;i<dong-2;i++) osheet.Cells[dong-1,i]=get_ten(i-1);
				orange=osheet.get_Range(d.getIndex(0)+"1",d.getIndex(socot + 7)+(sodong+7).ToString());
				osheet.Cells[dong-1,dsngay.Tables[0].Rows.Count+5]="Tổng cộng";
                osheet.Cells[dong - 1, dsngay.Tables[0].Rows.Count + 6] = "Ghi Chú";
				for(int i=0;i<dsngay.Tables[0].Rows.Count;i++)
					osheet.Cells[dong-1,i+5]=" "+dsngay.Tables[0].Rows[i]["ten"].ToString();
				osheet.get_Range(d.getIndex(4)+"6",d.getIndex(dsngay.Tables[0].Rows.Count+3)+"6").Orientation=90;
				osheet.get_Range(d.getIndex(0)+"6",d.getIndex(dsngay.Tables[0].Rows.Count+3)+"6").RowHeight=30;
				orange.Font.Name="Arial";
				orange.Font.Size=8;
				orange.EntireColumn.AutoFit();
				oxl.ActiveWindow.DisplayZeros=false;
				osheet.PageSetup.Orientation=XlPageOrientation.xlLandscape;
				osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
				osheet.PageSetup.LeftMargin=20;
				osheet.PageSetup.RightMargin=20;
				osheet.PageSetup.TopMargin=30;
				osheet.PageSetup.CenterFooter="Trang : &P/&N";
                osheet.Cells[1, 2] = d.Syte; osheet.Cells[2, 2] =d.Tenbv;
                osheet.Cells[3, 2] = "Khoa: " + makp.Text;
                osheet.Cells[1, socot] = "MS: 16D/BV-01";
                osheet.Cells[2, socot] = "Số:";
                orange = osheet.get_Range(osheet.Cells[1, socot], osheet.Cells[2, socot]);
                orange.Font.Bold = false;
                orange.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                orange = osheet.get_Range(osheet.Cells[dong - 1, 1], osheet.Cells[dong - 1, dsngay.Tables[0].Rows.Count + 6]);
                orange.Font.Bold = true;

                orange = osheet.get_Range(d.getIndex(1) + "5", d.getIndex(1) + "6");
                orange.Merge( Type.Missing );
                //excelApp.get_Range("A1:A360,B1:E1", Type.Missing).Merge(Type.Missing)
                orange = osheet.get_Range(d.getIndex(2) + "5", d.getIndex(2) + "6");
                orange.Merge(Type.Missing);
                orange = osheet.get_Range(d.getIndex(3) + "5", d.getIndex(3) + "6");
                orange.Merge(Type.Missing);
                orange = osheet.get_Range(d.getIndex(0) + "5", d.getIndex(0) + "6");
                orange.Merge(Type.Missing);
                orange = osheet.get_Range(d.getIndex(socot) + "5", d.getIndex(socot) + "6");
                orange.Merge(Type.Missing);
                orange = osheet.get_Range(d.getIndex(socot-1) + "5", d.getIndex(socot-1) + "6");
                orange.Merge(Type.Missing);
                orange = osheet.get_Range(d.getIndex(4) + "5", d.getIndex(socot - 2) + "5");
                orange.Merge(Type.Missing);
                orange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                osheet.Cells[5, 5] = "Ngày";
                osheet.get_Range(d.getIndex(0) + "7", d.getIndex(socot) + "7").EntireRow.Insert(Missing.Value);
                osheet.Cells[7, 1] = "A";
                osheet.Cells[7, 2] = "B";
                osheet.Cells[7, 3] = "C";
                osheet.Cells[7, 4] = "D";
                osheet.Cells[7, socot ] = "E";
                osheet.Cells[7, socot+1] = "G";
                orange = osheet.get_Range(d.getIndex(0) + "7", d.getIndex(socot+2) + "7");
                string s_ngay = d.Ngay_hethong;
                osheet.Cells[sodong+3, 2] = "NGƯỜI THỐNG KÊ";
                osheet.Cells[sodong+3, 6] = "KẾ TOÁN DƯỢC";
                osheet.Cells[sodong + 3, 19] = "Ngày " + s_ngay.Substring(0, 2) + " tháng " + s_ngay.Substring(3, 2) + " năm "+s_ngay.Substring(6,4) ;
                osheet.Cells[sodong+4, 19] = "TRƯỞNG KHOA " + makp.Text.ToUpper();
                osheet.Cells[sodong + 7, 2] = "Họ tên: ";
                osheet.Cells[sodong + 7, 6] = "Họ tên: ";
                osheet.Cells[sodong + 8, 19] = "Họ tên: ";
                orange = osheet.get_Range(osheet.Cells[sodong + 3, 2], osheet.Cells[sodong + 4, 20]);
                orange.Font.Bold = true;
                //orange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                orange.Orientation = 0;

				//osheet.Cells[1,4]="BÁO CÁO SỬ DỤNG";
                osheet.Cells[1, 4] = "THỐNG KÊ "+dsngay.Tables[0].Rows.Count.ToString()+" NGÀY SỬ DỤNG THUỐC, HÓA CHẤT,\n VẬT TƯ Y TẾ TIÊU HAO";
				osheet.Cells[2,4]=(tu.Text==den.Text)?"Ngày : "+tu.Text:"Từ ngày : "+tu.Text+" đến : "+den.Text;
				orange=osheet.get_Range(d.getIndex(3)+"1",d.getIndex(socot-2)+"2");
				orange.HorizontalAlignment=XlHAlign.xlHAlignCenterAcrossSelection;
				orange.Font.Size=12;
				orange.Font.Bold=true;
				if (print) osheet.PrintOut(Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);
				else oxl.Visible=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private string get_ten(int i)
		{
			//string []map={"TT","Mã số","Tên","ĐVT"};
            string[] map ={ "Số TT", "Tên thuốc  ( nồng độ/hàm lượng )/hóa chất/vật tư y tế tiêu hao", "Đơn vị", "Quy cách" };
			return map[i];
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			exp_excel(false);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			exp_excel(true);
		}

		private bool kiemtra()
		{
			s_kho="";
			if (kho.CheckedItems.Count==0) for(int i=0;i<kho.Items.Count;i++) kho.SetItemCheckState(i,CheckState.Checked);
			for(int i=0;i<kho.Items.Count;i++) if (kho.GetItemChecked(i)) s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
			s_manhom="";
			for(int i=0;i<manhom.Items.Count;i++) if (manhom.GetItemChecked(i)) s_manhom+=dtnhom.Rows[i]["id"].ToString()+",";
			s_maloai="";
			for(int i=0;i<maloai.Items.Count;i++) if (maloai.GetItemChecked(i)) s_maloai+=dtloai.Rows[i]["id"].ToString()+",";

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtkho=d.get_data(sql).Tables[0];
			Tao_dataset();
			//
			//
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
						get_xuat(mmyy);
						get_hoantra(mmyy);
					}
				}
			}
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
				return false;
			}
			return true;
		}


        private void makp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == makp)
            {
                i_id = int.Parse(makp.SelectedValue.ToString());
                foreach (DataRow r in dt_duockp.Select("id=" + i_id))
                {
                    s_makp = r["makp"].ToString();
                }
            }
        }

	}
}
