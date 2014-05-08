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
	/// Summary description for rptBhyt.
	/// </summary>
	public class rptBanhang : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private bool bUser;
        private int i_nhom, i_userid=0;
		private decimal tc=0;
		private string sql,s_quay,s_kho,s_makho,user,stime,xxx;
		private doiso.Doisototext doiso=new doiso.Doisototext();
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dtquay=new DataTable();
		private DataTable dtdmkho=new DataTable();
		private DataTable dtdm=new DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox quay;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb1;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rloai;
		private System.Windows.Forms.RadioButton rnhom;
		private System.Windows.Forms.CheckBox chkGiamua;
		private System.Windows.Forms.RadioButton rBaocao;
        private CheckBox chkHoantra;
        private CheckBox hoantra;
        private CheckBox chkXml;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBanhang(AccessData acc,int nhom,string makho, int _userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;s_makho=makho;
			i_nhom=nhom;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBanhang));
            this.label1 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.butXem = new System.Windows.Forms.Button();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.quay = new System.Windows.Forms.CheckedListBox();
            this.kho = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBaocao = new System.Windows.Forms.RadioButton();
            this.rloai = new System.Windows.Forms.RadioButton();
            this.rnhom = new System.Windows.Forms.RadioButton();
            this.chkGiamua = new System.Windows.Forms.CheckBox();
            this.chkHoantra = new System.Windows.Forms.CheckBox();
            this.hoantra = new System.Windows.Forms.CheckBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 3);
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
            this.butKetthuc.Location = new System.Drawing.Point(147, 293);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(144, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butXem
            // 
            this.butXem.Image = global::Duoc.Properties.Resources.Print1;
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(77, 293);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 4;
            this.butXem.Text = "      &In";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // tu
            // 
            this.tu.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(56, 3);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(80, 21);
            this.tu.TabIndex = 0;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(184, 3);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(80, 21);
            this.den.TabIndex = 1;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // quay
            // 
            this.quay.CheckOnClick = true;
            this.quay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quay.Location = new System.Drawing.Point(56, 96);
            this.quay.Name = "quay";
            this.quay.Size = new System.Drawing.Size(208, 84);
            this.quay.TabIndex = 3;
            this.quay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // kho
            // 
            this.kho.CheckOnClick = true;
            this.kho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kho.Location = new System.Drawing.Point(56, 26);
            this.kho.Name = "kho";
            this.kho.Size = new System.Drawing.Size(208, 68);
            this.kho.TabIndex = 2;
            this.kho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(56, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 32);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // rb3
            // 
            this.rb3.Location = new System.Drawing.Point(139, 11);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(68, 16);
            this.rb3.TabIndex = 2;
            this.rb3.Text = "Hóa đơn";
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(59, 11);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(93, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Ko hóa đơn";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(4, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(62, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Tất cả";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBaocao);
            this.groupBox2.Controls.Add(this.rloai);
            this.groupBox2.Controls.Add(this.rnhom);
            this.groupBox2.Location = new System.Drawing.Point(56, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 32);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // rBaocao
            // 
            this.rBaocao.Location = new System.Drawing.Point(139, 11);
            this.rBaocao.Name = "rBaocao";
            this.rBaocao.Size = new System.Drawing.Size(70, 16);
            this.rBaocao.TabIndex = 2;
            this.rBaocao.Text = "Báo cáo";
            // 
            // rloai
            // 
            this.rloai.Location = new System.Drawing.Point(59, 11);
            this.rloai.Name = "rloai";
            this.rloai.Size = new System.Drawing.Size(72, 16);
            this.rloai.TabIndex = 1;
            this.rloai.Text = "Phân loại";
            // 
            // rnhom
            // 
            this.rnhom.Checked = true;
            this.rnhom.Location = new System.Drawing.Point(4, 11);
            this.rnhom.Name = "rnhom";
            this.rnhom.Size = new System.Drawing.Size(62, 16);
            this.rnhom.TabIndex = 0;
            this.rnhom.TabStop = true;
            this.rnhom.Text = "Nhóm";
            // 
            // chkGiamua
            // 
            this.chkGiamua.Location = new System.Drawing.Point(56, 265);
            this.chkGiamua.Name = "chkGiamua";
            this.chkGiamua.Size = new System.Drawing.Size(152, 21);
            this.chkGiamua.TabIndex = 15;
            this.chkGiamua.Text = "Kèm theo đơn giá";
            this.chkGiamua.CheckedChanged += new System.EventHandler(this.chkGiamua_CheckedChanged);
            // 
            // chkHoantra
            // 
            this.chkHoantra.Checked = true;
            this.chkHoantra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoantra.Location = new System.Drawing.Point(174, 248);
            this.chkHoantra.Name = "chkHoantra";
            this.chkHoantra.Size = new System.Drawing.Size(91, 19);
            this.chkHoantra.TabIndex = 16;
            this.chkHoantra.Text = "Kèm hoàn trả";
            this.chkHoantra.CheckedChanged += new System.EventHandler(this.chkHoantra_CheckedChanged);
            // 
            // hoantra
            // 
            this.hoantra.Location = new System.Drawing.Point(56, 246);
            this.hoantra.Name = "hoantra";
            this.hoantra.Size = new System.Drawing.Size(131, 21);
            this.hoantra.TabIndex = 17;
            this.hoantra.Text = "Thống kê hoàn trả";
            this.hoantra.CheckedChanged += new System.EventHandler(this.hoantra_CheckedChanged);
            // 
            // chkXml
            // 
            this.chkXml.Location = new System.Drawing.Point(174, 265);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(96, 21);
            this.chkXml.TabIndex = 18;
            this.chkXml.Text = "Xuất ra XML";
            // 
            // rptBanhang
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(282, 333);
            this.Controls.Add(this.chkHoantra);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.hoantra);
            this.Controls.Add(this.chkGiamua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kho);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.quay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rptBanhang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng kê xuất bán hàng";
            this.Load += new System.EventHandler(this.rptBanhang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBanhang_Load(object sender, System.EventArgs e)
		{
            user = d.user; stime = "'" + d.f_ngay + "'";
			bUser=d.bXuatban_user(i_nhom);
			dsxml.ReadXml("..\\..\\..\\xml\\d_banhang.xml");
			ds.ReadXml("..\\..\\..\\xml\\d_banhang.xml");
            ds.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("gianovat", typeof(decimal));
			sql=(bUser)?"select * from "+user+".d_dlogin where nhomkho="+i_nhom+" order by id":"select * from "+user+".d_dmloaint where nhom="+i_nhom+" order by stt";
			dtquay=d.get_data(sql).Tables[0];
            quay.DataSource = dtquay;
			quay.DisplayMember=(bUser)?"HOTEN":"TEN";
			quay.ValueMember="ID";

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			dtdmkho=d.get_data(sql).Tables[0];
			kho.DataSource=dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";
            dtdm = d.get_data("select a.*,b.ten as tennhom,c.ten as tenloai,d.ten as tenbaocao from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id inner join " + user + ".d_dmloai c on a.maloai=c.id left join " + user + ".d_nhombo d on a.nhombo=d.id where a.nhom=" + i_nhom).Tables[0];
			if (d.Mabv_so==701417) rBaocao.Checked=true;
            //chkXml.Enabled = chkGiamua.Checked;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();		
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{			
			print();
		}	

		private void print()
		{
			ds.Clear();
			string s_tenquay="",s_tenkho="";
			s_quay="";
			if (quay.CheckedItems.Count>0) 
				for(int i=0;i<quay.Items.Count;i++)	
					if (quay.GetItemChecked(i)) 
					{
						s_quay+=dtquay.Rows[i]["id"].ToString()+",";
						s_tenquay+=dtquay.Rows[i][(bUser)?"hoten":"ten"].ToString()+",";
					}
			s_kho="";
			if (kho.CheckedItems.Count>0) 
				for(int i=0;i<kho.Items.Count;i++)
					if (kho.GetItemChecked(i))
					{
						s_kho+=dtdmkho.Rows[i]["id"].ToString()+",";
						s_tenkho+=dtdmkho.Rows[i]["ten"].ToString()+",";
					}
			string s_title="Từ ngày "+tu.Text+" đến ngày "+den.Text;
            if (tu.Text == den.Text) s_title = "Ngày " + tu.Text;
			if (rb3.Checked) s_title+=" (HÓA ĐƠN TÀI CHÍNH)";
			DateTime dt1=d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";
			DataRow r1,r2,r3;
			DataRow [] dr;
            //string gia = (chkXml.Checked) ? "gianovat" : "giamua";
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (d.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
                        //gia = (chkXml.Checked) ? "gianovat" : "giamua";
                        if (!hoantra.Checked)
                        {
                            sql = " select b.mabd,b.giaban,";
                            if (chkGiamua.Checked) sql += "t.giamua,t.gianovat,";
                            else sql += "0 as giamua,0 as gianovat,";
                            sql += "sum(b.soluong) as soluong,sum(b.soluong*b.giaban) as sotien";
                            sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + xxx + ".d_theodoi t ";
                            sql += " where a.id=b.id and b.sttt=t.id and b.paid=1 and b.idttrv=0";
                            if (s_quay != "")
                            {
                                if (bUser) sql += " and a.userid in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                                else sql += " and a.loai in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                            }
                            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                            if (rb2.Checked) sql += " and a.id not in (select id from " + xxx + ".d_bienlai)";
                            else if (rb3.Checked) sql += " and a.id in (select id from " + xxx + ".d_bienlai)";
                            sql += " group by b.mabd,b.giaban";
                            if (chkGiamua.Checked) sql += ",t.giamua,t.gianovat";
                            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                            {
                                r3 = d.getrowbyid(dtdm, "id=" + int.Parse(r["mabd"].ToString()));
                                if (r3 != null)
                                {
                                    sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and giaban=" + decimal.Parse(r["giaban"].ToString());
                                    if (chkGiamua.Checked) sql += " and giamua=" + decimal.Parse(r["giamua"].ToString())+" and gianovat="+decimal.Parse(r["gianovat"].ToString());
                                    r1 = d.getrowbyid(ds.Tables[0], sql);
                                    if (r1 == null)
                                    {
                                        r2 = ds.Tables[0].NewRow();
                                        r2["tennhom"] = (rnhom.Checked) ? r3["tennhom"].ToString() : (rloai.Checked) ? r3["tenloai"].ToString() : r3["tenbaocao"].ToString();
                                        r2["mabd"] = r["mabd"].ToString();
                                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                                        r2["dang"] = r3["dang"].ToString();
                                        r2["soluong"] = r["soluong"].ToString();
                                        r2["gianovat"] = r["gianovat"].ToString();
                                        r2["giamua"] = r["giamua"].ToString();
                                        r2["giaban"] = r["giaban"].ToString();
                                        r2["sotien"] = r["sotien"].ToString();
                                        ds.Tables[0].Rows.Add(r2);
                                    }
                                    else
                                    {
                                        dr = ds.Tables[0].Select(sql);
                                        if (dr.Length > 0)
                                        {
                                            dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r["soluong"].ToString());
                                            dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                        if (chkHoantra.Checked || hoantra.Checked)
                        {
                            //gia = (chkXml.Checked) ? "dongia" : "giamua";
                            sql = " select b.mabd,b.giaban,";
                            if (chkGiamua.Checked) sql += "b.giamua,b.dongia as gianovat,";
                            else sql += "0 as giamua,0 as gianovat,";
                            if (hoantra.Checked)
                                sql += "sum(b.soluong) as soluong,sum(b.soluong*b.giaban) as sotien";
                            else
                                sql += "sum(-1*b.soluong) as soluong,sum(-1*b.soluong*b.giaban) as sotien";
                            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b ";
                            sql += " where a.id=b.id and a.loai='N'";
                            if (s_quay != "")
                            {
                                if (bUser) sql += " and a.userid in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                                else sql += " and a.lydo in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                            }
                            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                            sql += " and a.ngaysp between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                            sql += " group by b.mabd,b.giaban";
                            if (chkGiamua.Checked) sql += ",b.giamua,b.dongia";
                            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                            {
                                r3 = d.getrowbyid(dtdm, "id=" + int.Parse(r["mabd"].ToString()));
                                if (r3 != null)
                                {
                                    sql = "mabd=" + int.Parse(r["mabd"].ToString()) + " and giaban=" + decimal.Parse(r["giaban"].ToString());
                                    if (chkGiamua.Checked) sql += " and giamua=" + decimal.Parse(r["giamua"].ToString())+" and gianovat="+decimal.Parse(r["gianovat"].ToString());
                                    r1 = d.getrowbyid(ds.Tables[0], sql);
                                    if (r1 == null)
                                    {
                                        r2 = ds.Tables[0].NewRow();
                                        r2["tennhom"] = (rnhom.Checked) ? r3["tennhom"].ToString() : (rloai.Checked) ? r3["tenloai"].ToString() : r3["tenbaocao"].ToString();
                                        r2["mabd"] = r["mabd"].ToString();
                                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                                        r2["dang"] = r3["dang"].ToString();
                                        r2["soluong"] = r["soluong"].ToString();
                                        r2["gianovat"] = r["gianovat"].ToString();
                                        r2["giamua"] = r["giamua"].ToString();
                                        r2["giaban"] = r["giaban"].ToString();
                                        r2["sotien"] = r["sotien"].ToString();
                                        ds.Tables[0].Rows.Add(r2);
                                    }
                                    else
                                    {
                                        dr = ds.Tables[0].Select(sql);
                                        if (dr.Length > 0)
                                        {
                                            dr[0]["soluong"] = decimal.Parse(dr[0]["soluong"].ToString()) + decimal.Parse(r["soluong"].ToString());
                                            dr[0]["sotien"] = decimal.Parse(dr[0]["sotien"].ToString()) + decimal.Parse(r["sotien"].ToString());
                                        }
                                    }
                                }
                            }
                        }
					}
				}
			}
			if (ds.Tables[0].Rows.Count==0) MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),d.Msg);
			else
			{
				tc=0;
				foreach(DataRow r in ds.Tables[0].Rows) tc+=decimal.Parse(r["sotien"].ToString());
				dsxml.Clear();
				dsxml.Merge(ds.Tables[0].Select("true","tennhom,ten"));
                if (chkXml.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    dsxml.WriteXml("..\\xml\\banhang.xml", XmlWriteMode.WriteSchema);
                }
                frmReport f1 = new frmReport(d, dsxml.Tables[0],i_userid, (chkGiamua.Checked) ? "d_banhang_gmua.rpt" : "d_banhang.rpt", "", s_title, s_tenquay, s_tenkho, (hoantra.Checked) ? "BẢNG KÊ HOÀN TRẢ" : "BẢNG KÊ XUẤT BÁN HÀNG", "", "", "", "", doiso.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
				f1.ShowDialog(this);
			}
		}

        private void hoantra_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == hoantra && hoantra.Checked) chkHoantra.Checked = false;
        }

        private void chkHoantra_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkHoantra && chkHoantra.Checked) hoantra.Checked = false; 
        }

        private void chkGiamua_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.ActiveControl == chkGiamua) chkXml.Enabled = chkGiamua.Checked;
        }	
	}
}
