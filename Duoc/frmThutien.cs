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
	public class frmThutien : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData d;
		private bool bUser,b_ktra;
        private int i_nhom, i_userid=0;
        private decimal tc = 0;
		private string sql,s_quay,s_kho,s_makho,user,stime,xxx;
		private DataSet ds;
		private DataSet dsxml=new DataSet();
		private DataTable dtquay=new DataTable();
		private DataTable dtdmkho=new DataTable();
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckedListBox quay;
		private System.Windows.Forms.CheckedListBox kho;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb3;
		private System.Windows.Forms.RadioButton rb2;
		private System.Windows.Forms.RadioButton rb1;
        private CheckBox chkHoantra;
        private CheckBox chkThungan;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThutien(AccessData acc,int nhom,string makho, int _userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThutien));
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
            this.chkHoantra = new System.Windows.Forms.CheckBox();
            this.chkThungan = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
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
            this.butKetthuc.Location = new System.Drawing.Point(143, 246);
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
            this.butXem.Location = new System.Drawing.Point(73, 246);
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
            this.groupBox1.Location = new System.Drawing.Point(56, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 32);
            this.groupBox1.TabIndex = 14;
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
            this.rb2.Size = new System.Drawing.Size(97, 16);
            this.rb2.TabIndex = 1;
            this.rb2.Text = "Ko hóa đơn";
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(4, 11);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(58, 16);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Tất cả";
            // 
            // chkHoantra
            // 
            this.chkHoantra.AutoSize = true;
            this.chkHoantra.Checked = true;
            this.chkHoantra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoantra.Location = new System.Drawing.Point(56, 217);
            this.chkHoantra.Name = "chkHoantra";
            this.chkHoantra.Size = new System.Drawing.Size(67, 17);
            this.chkHoantra.TabIndex = 15;
            this.chkHoantra.Text = "Hoàn trả";
            this.chkHoantra.UseVisualStyleBackColor = true;
            // 
            // chkThungan
            // 
            this.chkThungan.AutoSize = true;
            this.chkThungan.Location = new System.Drawing.Point(147, 217);
            this.chkThungan.Name = "chkThungan";
            this.chkThungan.Size = new System.Drawing.Size(72, 17);
            this.chkThungan.TabIndex = 16;
            this.chkThungan.Text = "Thu ngân";
            this.chkThungan.UseVisualStyleBackColor = true;
            this.chkThungan.CheckedChanged += new System.EventHandler(this.chkThungan_CheckedChanged_1);
            // 
            // frmThutien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(274, 282);
            this.Controls.Add(this.chkThungan);
            this.Controls.Add(this.chkHoantra);
            this.Controls.Add(this.quay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kho);
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
            this.Name = "frmThutien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thu tiền thuốc";
            this.Load += new System.EventHandler(this.frmThutien_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        private void frmThutien_Load(object sender, System.EventArgs e)
        {
            user = d.user; stime = "'" + d.f_ngay + "'";
            b_ktra = d.bBienlai_sohieu(i_nhom);
            dsxml.ReadXml("..\\..\\..\\xml\\d_thutien.xml");
            dsxml.Tables[0].Columns.Add("sotiennovat");
            dsxml.Tables[0].Columns.Add("sotiengiamua");
            bUser = d.bXuatban_user(i_nhom);
            //Thuy 29.02.2012
            if (bUser)
            {
                chkThungan.Visible = true;
                chkThungan.Checked = b_ktra;
                if (b_ktra)
                {
                    sql = "select * from " + user + ".v_dlogin order by id";
                }
                else
                {
                    sql = "select * from " + user + ".d_dlogin where nhomkho=" + i_nhom + " order by id";
                }
            }
            else
            {
                chkThungan.Visible = false;
                sql = "select * from " + user + ".d_dmloaint where nhom=" + i_nhom + " order by stt";
            }
            //end Thuy 29.02.2012
            dtquay = d.get_data(sql).Tables[0];
            quay.DataSource = dtquay;
            quay.DisplayMember = (bUser) ? "HOTEN" : "TEN";
            quay.ValueMember = "ID";

            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
            if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            sql += " order by stt";
            dtdmkho = d.get_data(sql).Tables[0];
            kho.DataSource = dtdmkho;
            kho.DisplayMember = "TEN";
            kho.ValueMember = "ID";

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
            bool bBoquaInphieuxuatban = d.bInPhieuxuatban(i_nhom);
            s_quay = "";
            if (quay.CheckedItems.Count > 0)
                for (int i = 0; i < quay.Items.Count; i++) if (quay.GetItemChecked(i)) s_quay += dtquay.Rows[i]["id"].ToString() + ",";
            s_kho = "";
            if (kho.CheckedItems.Count > 0)
                for (int i = 0; i < kho.Items.Count; i++) if (kho.GetItemChecked(i)) s_kho += dtdmkho.Rows[i]["id"].ToString() + ",";
            string s_title = "Từ ngày " + tu.Text + " đến ngày " + den.Text;
            if (tu.Text == den.Text) s_title = "Ngày " + tu.Text;
            if (rb3.Checked) s_title += " (HÓA ĐƠN TÀI CHÍNH)";
            DateTime dt1 = d.StringToDate(tu.Text).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(den.Text).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            dsxml.Clear();
            tc = 0;
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (d.bMmyy(mmyy))
                    {
                        xxx = user + mmyy;
                        sql = " select to_char(a.ngay,'yyyy/mm/dd') as ngay,";
                        if (bUser && !chkThungan.Checked)
                        {
                            sql += " a.userid as loai,";
                        }
                        else if (bUser && chkThungan.Checked)
                        {
                            sql += "a.userid_vp as loai,";
                        }
                        else
                        {
                            sql += "a.loai,";
                        }
                        sql += "sum(b.soluong*b.giaban) as sotien,0 as sotoa,0 as done,sum(b.soluong*c.giamua) as sotiengiamua,sum(b.soluong*c.gianovat) as sotiennovat";
                        sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b,"+xxx+".d_theodoi c ";
                        sql += " where a.id=b.id and b.sttt=c.id  and b.idttrv=0";
                       //khuyen 20/02/14 sql += " and b.paid=1 "; //thanh quan done=1,paid=0
                        if (!bBoquaInphieuxuatban) sql += " and done=1";
                        if (s_quay != "")
                        {
                            if (bUser)
                            {
                                if (chkThungan.Checked)
                                {
                                    sql += " and a.userid_vp in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                                }
                                else
                                {
                                    sql += " and a.userid in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                                }
                            }
                        }
                        if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                        sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                        if (rb2.Checked) sql += " and a.id not in (select id from " + xxx + ".d_bienlai)";
                        else if (rb3.Checked) sql += " and a.id in (select id from " + xxx + ".d_bienlai)";
                        sql += " group by to_char(a.ngay,'yyyy/mm/dd'),";
                        if (bUser && !chkThungan.Checked)
                        {
                            sql += "a.userid";
                        }
                        else if (bUser && chkThungan.Checked)
                        {
                            sql += "a.userid_vp";
                        }
                        else
                        {
                            sql += "a.loai";
                        }
                        ds = d.get_data(sql);
                        ins_items();

                        if (chkHoantra.Checked)
                        {
                            sql = " select to_char(a.ngaysp,'yyyy/mm/dd') as ngay,";
                            sql += (bUser) ? "a.userid as loai," : "a.lydo as loai,";
                            sql += "sum(-1*b.soluong*b.giaban) as sotien,0 as sotoa,0 as done,sum(-1*b.soluong*c.giamua) as sotiengiamua,sum(-1*b.soluong*c.gianovat) as sotiennovat ";
                            sql += " from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + xxx + ".d_tonkhoct d," + xxx + ".d_theodoi c ";
                            sql += " where a.id=b.id and d.idn=b.id and b.stt=d.sttn and d.stt=c.id and a.loai='N'";
                            if (s_quay != "")
                            {
                                if (bUser) sql += " and a.userid in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                                else sql += " and a.lydo in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                            }
                            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                            sql += " and a.ngaysp between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                            sql += " group by to_char(a.ngaysp,'yyyy/mm/dd'),";
                            sql += (bUser) ? "a.userid" : "a.lydo";
                            ds = d.get_data(sql);
                            ins_items();
                        }
                        if (!bBoquaInphieuxuatban)
                        {
                            //chua in 
                            sql = " select to_char(a.ngay,'yyyy/mm/dd') as ngay,";
                            if (bUser && !chkThungan.Checked)
                            {
                                sql += " a.userid as loai,";
                            }
                            else if (bUser && chkThungan.Checked)
                            {
                                sql += "a.userid_vp as loai,";
                            }
                            else
                            {
                                sql += "a.loai,";
                            }
                            sql += "sum(b.soluong*b.giaban) as sotien,a.sotoa,1 as done,sum(b.soluong*c.giamua) as sotiengiamua,sum(b.soluong*c.gianovat) as sotiennovat ";
                            sql += " from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b,"+xxx+".d_theodoi c ";
                            sql += " where a.id=b.id and b.sttt=c.id ";
                           //khuyen 20/02/14 sql += " and done=0 ";//thanh quan done=1,paid=0
                            if (s_quay != "")
                            {
                                if (bUser) sql += " and a.userid in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                                else sql += " and a.loai in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                            }
                            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                            sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                            if (rb2.Checked) sql += " and a.id not in (select id from " + xxx + ".d_bienlai)";
                            else if (rb3.Checked) sql += " and a.id in (select id from " + xxx + ".d_bienlai)";
                            sql += " group by to_char(a.ngay,'yyyy/mm/dd'),";
                            if (bUser && !chkThungan.Checked)
                            {
                                sql += "a.userid,";
                            }
                            else if (bUser && chkThungan.Checked)
                            {
                                sql += "a.userid_vp,";
                            }
                            else
                            {
                                sql += "a.loai,";
                            }
                            sql += " a.sotoa";
                            ds = d.get_data(sql);
                            ins_items();
                        }
                        //huy
                        sql = " select to_char(a.ngay,'yyyy/mm/dd') as ngay,";
                        sql += (bUser) ? "a.userid as loai," : "a.loai as loai,";
                        sql += "sum(b.soluong*b.giaban) as sotien,a.sotoa,2 as done,sum(b.soluong*c.giamua) as sotiengiamua,sum(b.soluong*c.gianovat) as sotiennovat ";
                        sql += " from " + xxx + ".d_huybanll a," + xxx + ".d_huybanct b,"+xxx+".d_theodoi c ";
                        sql += " where a.id=b.id and b.sttt=c.id and b.paid=1 and b.idttrv=0";
                        if (s_quay != "")
                        {
                            if (bUser) sql += " and a.userid in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                            else sql += " and a.loai in (" + s_quay.Substring(0, s_quay.Length - 1) + ")";
                        }
                        if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                        sql += " and a.ngay between to_date('" + tu.Text + "'," + stime + ") and to_date('" + den.Text + "'," + stime + ")";
                        if (rb2.Checked) sql += " and a.id not in (select id from " + xxx + ".d_bienlai)";
                        else if (rb3.Checked) sql += " and a.id in (select id from " + xxx + ".d_bienlai)";
                        sql += " group by to_char(a.ngay,'yyyy/mm/dd'),";
                        sql += (bUser) ? "a.userid," : "a.loai,";
                        sql += "a.sotoa";
                        ds = d.get_data(sql);
                        ins_items();
                    }
                }
            }
            if (dsxml.Tables[0].Rows.Count == 0) MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"), d.Msg);
            else
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\d_thutien.xml", XmlWriteMode.WriteSchema);
                doiso.Doisototext dd = new doiso.Doisototext();
                frmReport f1 = new frmReport(d, dsxml.Tables[0], i_userid, "d_thutien.rpt", "", s_title, "", "", "", "", "", "", "", dd.Doiso_Unicode(Convert.ToInt64(tc).ToString()));
                f1.ShowDialog(this);
            }
        }
        private void ins_items()
        {
			DataRow [] dr;
			DataRow r1,r2,r3;
			string ngay="",sql,st,fie=(bUser)?"hoten":"ten";
			foreach(DataRow r in ds.Tables[0].Select("true","ngay,loai,done,sotoa"))
			{
				if (r["done"].ToString()=="0") st="sotien";
				else st="sotien"+r["done"].ToString().Trim();
				ngay=r["ngay"].ToString().Substring(8,2)+"/"+r["ngay"].ToString().Substring(5,2)+"/"+r["ngay"].ToString().Substring(0,4);
				sql="ngay='"+ngay+"' and loai="+int.Parse(r["loai"].ToString())+" and done="+int.Parse(r["done"].ToString())+" and sotoa="+int.Parse(r["sotoa"].ToString());
				r1=d.getrowbyid(dsxml.Tables[0],sql);
				if (r1==null)
				{
					r3=d.getrowbyid(dtquay,"id="+int.Parse(r["loai"].ToString()));
					if (r3!=null)
					{
						r2=dsxml.Tables[0].NewRow();
						r2["ngay"]=ngay;
						r2["loai"]=r["loai"].ToString();
						r2["tenloai"]=r3[fie].ToString();
						r2[st]=r["sotien"].ToString();
						if (r["done"].ToString()=="1") r2["diengiai"]="Số toa thuốc chưa in";
						else if (r["done"].ToString()=="2") r2["diengiai"]="Số toa thuốc hủy";
						else r2["diengiai"]="";
						r2["sotoa"]=r["sotoa"].ToString();
						r2["done"]=r["done"].ToString();
                        if (r["done"].ToString() == "0") tc += decimal.Parse(r["sotien"].ToString());
                        r2["sotiengiamua"] = r["sotiengiamua"].ToString();
                        r2["sotiennovat"] = r["sotiennovat"].ToString();
						dsxml.Tables[0].Rows.Add(r2);
					}
				}
				else
				{
					dr=dsxml.Tables[0].Select(sql);
					if (dr.Length>0) dr[0][st]=decimal.Parse(dr[0][st].ToString())+decimal.Parse(r["sotien"].ToString());
					if (r["done"].ToString()=="0") tc+=decimal.Parse(r["sotien"].ToString());
				}
			}	
        }
    
        //Thuy 29.02.2012
        private void chkThungan_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkThungan.Checked && b_ktra)
            {
                sql = "select * from " + user + ".v_dlogin order by id";
            }
            else
            {
                sql = "select * from " + user + ".d_dlogin where nhomkho=" + i_nhom + " order by id";
            }
            dtquay = d.get_data(sql).Tables[0];
            quay.DataSource = dtquay;
            quay.DisplayMember = (bUser) ? "HOTEN" : "TEN";
            quay.ValueMember = "ID";
        }
   }
}
