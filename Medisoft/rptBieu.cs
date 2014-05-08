using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi; 

namespace Medisoft
{
	/// <summary>
	/// Summary description for rptBieu01.
	/// </summary>
	public class rptBieu : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox loaibc;
		private System.Windows.Forms.ComboBox ky;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private Export e=new Export();
		private DataSet ds=new DataSet();
		private DataSet dm=new DataSet();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton phatsinh;
		private System.Windows.Forms.RadioButton mau;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nam;
		private string s_table,sql,title,s_tu,s_den,s_tu1,s_tu2,user;
		private int i_bieu;
		private bool bPhatsinh;
		private System.Windows.Forms.CheckBox thongke;
		private System.Windows.Forms.CheckBox benhan;
		private System.Windows.Forms.Button butXem;
        private dllReportM.Print p = new dllReportM.Print();
        private CheckBox chkmau2010;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBieu(AccessData acc,string title,bool ena,string table,int bieu)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
			this.Text=title;
            s_table =table;
			i_bieu=bieu;
			benhan.Enabled=ena;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public rptBieu(string title, bool ena, string table, int bieu)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
            this.Text = title;
            s_table = table;
            i_bieu = bieu;
            benhan.Enabled = ena;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBieu));
            this.label1 = new System.Windows.Forms.Label();
            this.loaibc = new System.Windows.Forms.ComboBox();
            this.ky = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.thongke = new System.Windows.Forms.CheckBox();
            this.benhan = new System.Windows.Forms.CheckBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkmau2010 = new System.Windows.Forms.CheckBox();
            this.phatsinh = new System.Windows.Forms.RadioButton();
            this.mau = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.butXem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo cáo theo :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaibc
            // 
            this.loaibc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibc.Items.AddRange(new object[] {
            "Kỳ",
            "Ngày"});
            this.loaibc.Location = new System.Drawing.Point(88, 11);
            this.loaibc.Name = "loaibc";
            this.loaibc.Size = new System.Drawing.Size(80, 22);
            this.loaibc.TabIndex = 1;
            this.loaibc.SelectedIndexChanged += new System.EventHandler(this.loaibc_SelectedIndexChanged);
            this.loaibc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibc_KeyDown);
            // 
            // ky
            // 
            this.ky.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ky.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ky.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ky.Items.AddRange(new object[] {
            "03 tháng",
            "06 tháng",
            "09 tháng",
            "12 tháng"});
            this.ky.Location = new System.Drawing.Point(171, 11);
            this.ky.Name = "ky";
            this.ky.Size = new System.Drawing.Size(79, 22);
            this.ky.TabIndex = 2;
            this.ky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ky_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(178, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "đến ngày :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(88, 35);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(96, 22);
            this.tu.TabIndex = 6;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(240, 35);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(96, 22);
            this.den.TabIndex = 8;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // thongke
            // 
            this.thongke.Location = new System.Drawing.Point(25, 128);
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(303, 24);
            this.thongke.TabIndex = 10;
            this.thongke.Text = "Tổng hợp từ biểu thống kê";
            this.thongke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thongke_KeyDown);
            // 
            // benhan
            // 
            this.benhan.Location = new System.Drawing.Point(25, 152);
            this.benhan.Name = "benhan";
            this.benhan.Size = new System.Drawing.Size(159, 24);
            this.benhan.TabIndex = 11;
            this.benhan.Text = "Tổng hợp từ hồ sơ bệnh án";
            this.benhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhan_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(145, 197);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 11;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(215, 197);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkmau2010);
            this.groupBox1.Controls.Add(this.phatsinh);
            this.groupBox1.Controls.Add(this.mau);
            this.groupBox1.Location = new System.Drawing.Point(14, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // chkmau2010
            // 
            this.chkmau2010.Checked = true;
            this.chkmau2010.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkmau2010.Location = new System.Drawing.Point(229, 88);
            this.chkmau2010.Name = "chkmau2010";
            this.chkmau2010.Size = new System.Drawing.Size(86, 24);
            this.chkmau2010.TabIndex = 12;
            this.chkmau2010.Text = "Mẫu mới";
            // 
            // phatsinh
            // 
            this.phatsinh.Location = new System.Drawing.Point(11, 40);
            this.phatsinh.Name = "phatsinh";
            this.phatsinh.Size = new System.Drawing.Size(303, 24);
            this.phatsinh.TabIndex = 1;
            this.phatsinh.Text = "Chỉ xem có mục có số liệu phát sinh";
            this.phatsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phatsinh_KeyDown);
            // 
            // mau
            // 
            this.mau.Location = new System.Drawing.Point(11, 15);
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(303, 24);
            this.mau.TabIndex = 0;
            this.mau.Text = "Tổng hợp theo mẫu báo cáo";
            this.mau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mau_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(245, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Năm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nam.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(284, 11);
            this.nam.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nam.Minimum = new decimal(new int[] {
            1997,
            0,
            0,
            0});
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(52, 22);
            this.nam.TabIndex = 4;
            this.nam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nam_KeyDown);
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(75, 197);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 10;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // rptBieu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(344, 237);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.ky);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.benhan);
            this.Controls.Add(this.thongke);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.den);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loaibc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "rptBieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bieu01";
            this.Load += new System.EventHandler(this.rptBieu_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBieu_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            //
            f_capnhat_db();
            //
			if (benhan.Enabled)
			{
				thongke.Checked=true;
				benhan.Checked=true;
			}
			else
			{
				thongke.Checked=true;
				thongke.Enabled=false;
			}
			loaibc.SelectedIndex=0;
			ky.SelectedIndex=0;
			phatsinh.Checked=m.bSolieu;
			mau.Checked=!phatsinh.Checked;
			nam.Value=DateTime.Now.Year;
            chkmau2010.Visible = i_bieu == 11;
		}

		private void loaibc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaibc.SelectedIndex==-1) loaibc.SelectedIndex=0;
				if (ky.Enabled) SendKeys.Send("{Tab}{F4}");
				else SendKeys.Send("{Tab}");
		}
		}

		private void loaibc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ky.Enabled=loaibc.SelectedIndex==0;
			nam.Enabled=ky.Enabled;
			tu.Enabled=!ky.Enabled;
			den.Enabled=tu.Enabled;
			if (loaibc.SelectedIndex==1) ky.SelectedIndex=-1;
			else if (ky.SelectedIndex==-1) ky.SelectedIndex=0;
		}

		private void ky_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void phatsinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void thongke_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void benhan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void bieu_01(bool prn)
		{
			ds=m.get_data("select id from "+user+".bieu_01 where "+m.for_ngay("ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')"+" order by ngay desc");
			if (ds.Tables[0].Rows.Count!=0)
			{
				decimal l_id=decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
				sql="select a.ma,b.stt,b.ten,a.c01,a.c02,a.c03,a.c04,";
				sql+="a.c05,a.c06,a.c07,a.c08,a.c09,a.c10,a.c11,a.c12,";
				sql+="a.c13,a.c14,a.c15,a.c16,a.c17,a.c18,a.c19,a.c20,";
				sql+="a.c21,a.c22,a.c23 ";
				sql+=" from "+user+".bieu_01 a,"+user+".dm_01 b where a.ma=b.ma and a.id="+l_id;
				sql+=" order by b.loai,b.kp,a.ma";
				if (bPhatsinh)	ds=m.get_data(sql);
				else
				{
					ds=m.get_data("select * from "+user+"."+s_table+" order by loai,kp,ma");
					DataRow[] dr;
					foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
					{
						dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
						if (dr!=null)
						{
							dr[0]["c01"]=r["c01"].ToString();
							dr[0]["c02"]=r["c02"].ToString();
							dr[0]["c03"]=r["c03"].ToString();
							dr[0]["c04"]=r["c04"].ToString();
							dr[0]["c05"]=r["c05"].ToString();
							dr[0]["c06"]=r["c06"].ToString();
							dr[0]["c07"]=r["c07"].ToString();
							dr[0]["c08"]=r["c08"].ToString();
							dr[0]["c09"]=r["c09"].ToString();
							dr[0]["c10"]=r["c10"].ToString();
							dr[0]["c11"]=r["c11"].ToString();
							dr[0]["c12"]=r["c12"].ToString();
							dr[0]["c13"]=r["c13"].ToString();
							dr[0]["c14"]=r["c14"].ToString();
							dr[0]["c15"]=r["c15"].ToString();
							dr[0]["c16"]=r["c16"].ToString();
							dr[0]["c17"]=r["c17"].ToString();
							dr[0]["c18"]=r["c18"].ToString();
							dr[0]["c19"]=r["c19"].ToString();
							dr[0]["c20"]=r["c20"].ToString();
							dr[0]["c21"]=r["c21"].ToString();
							dr[0]["c22"]=r["c22"].ToString();
							dr[0]["c23"]=r["c23"].ToString();
						}
					}
				}
				if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+c21+c22+c23>0")==null)
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				else
				{
					if (prn) p.Printer(m,ds,"bieu_01.rpt",title.ToUpper(),2);
					else
					{
						dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_01.rpt");
						f.ShowDialog(this);
					}
				}
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void bieu_02(bool prn)
		{
            DataSet dstmp = new DataSet();
			ds=e.bieu_02_bv(s_tu,s_tu1,s_den,s_table,benhan.Checked,thongke.Checked,phatsinh.Checked);
            dstmp = ds.Copy();
            dstmp.Clear();
            DataRow r1;
            foreach (DataRow r in ds.Tables[0].Select("c01+c02+c03+c04+c05+c06+c07+c08>0"))
            {
                r1 = dstmp.Tables[0].NewRow();
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++) r1[i] = (r[i].ToString() == "") ? "0" : r[i].ToString();
                dstmp.Tables[0].Rows.Add(r1);
            }
			if (m.getrowbyid(dstmp.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,dstmp,"bieu_02.rpt",title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,dstmp,title.ToUpper(),"bieu_02.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_031(bool prn)
		{
			ds=e.bieu_031_bv(s_tu,s_tu1,s_den,s_table,benhan.Checked,thongke.Checked,phatsinh.Checked);
			if (m.getrowbyid(ds.Tables[0],"c02+c03+c04+c05+c06+c07+c08+c09+c10+c11>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_031.rpt",title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_031.rpt");
					f.ShowDialog(this);
				}
			}
		}
		private void bieu_04(bool prn)
		{
			ds=e.bieu_04(s_tu,s_tu1,s_den,s_table,benhan.Checked,thongke.Checked,phatsinh.Checked);
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_04.rpt",title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_04.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_05(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.soluong) as soluong";
			sql+=" from "+user+".bieu_05 a,"+user+".dm_05 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["soluong"]=r["soluong"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"soluong>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_05.rpt",title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_05.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_06(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,b.donvi,sum(a.c01) as c01,sum(a.c02) as c02";
			sql+=" from "+user+".bieu_06 a,"+user+".dm_06 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten,b.donvi order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=r["c02"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_06.rpt",title.ToUpper(),1);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_06.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_07(bool prn)
		{
			sql="select id from "+user+".bieu_07 where "+m.for_ngay("ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')"+" order by ngay desc";
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count!=0)
			{
				decimal l_id=decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
				sql="select a.ma,b.stt,b.ten,b.donvi,sum(a.soluong) as soluong";
				sql+=" from "+user+".bieu_07 a,"+user+".dm_07 b where a.ma=b.ma ";
				sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
				sql+=" group by a.ma,b.stt,b.ten,b.donvi order by a.ma";
				if (bPhatsinh)	ds=m.get_data(sql);
				else
				{
					ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
					DataRow[] dr;
					foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
					{
						dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
						if (dr!=null)
						{
							dr[0]["soluong"]=r["soluong"].ToString();
						}
					}
				}
				if (m.getrowbyid(ds.Tables[0],"soluong>0")==null)
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				else
				{
					DataRow r1;
					sql="select ma,soluong from "+user+".bieu_07 where ma in (21,22,23,24) and id="+l_id;
					foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
					{
						r1=m.getrowbyid(ds.Tables[0],"ma="+int.Parse(r["ma"].ToString()));
						if (r1!=null) r1["soluong"]=r["soluong"].ToString();
					}
					if (prn) p.Printer(m,ds,"bieu_07.rpt",title.ToUpper(),1);
					else
					{
						dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_07.rpt");
						f.ShowDialog(this);
					}
				}
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void bieu_08(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,";
			sql+="sum(a.c03) as c03,sum(a.c04) as c04,sum(a.c05) as c05,";
			sql+="sum(a.c06) as c06,sum(a.c07) as c07";
			sql+=" from "+user+".bieu_08 a,"+user+".dm_08 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=r["c02"].ToString();
						dr[0]["c03"]=r["c03"].ToString();
						dr[0]["c04"]=r["c04"].ToString();
						dr[0]["c05"]=r["c05"].ToString();
						dr[0]["c06"]=r["c06"].ToString();
						dr[0]["c07"]=r["c07"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_08.rpt",title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_08.rpt");
					f.ShowDialog();
				}
			}
		}

		private void bieu_091(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,b.donvi,sum(a.tongso) as tongso";
			sql+=" from "+user+".bieu_091 a,"+user+".dm_091 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten,b.donvi order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["tongso"]=r["tongso"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"tongso>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_091.rpt",title.ToUpper(),1);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_091.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_092(bool prn)
		{
			sql="select ma as stt,ten,sum(c01) as c01,sum(c02) as c02,";
			sql+="sum(c03) as c03,sum(c04) as c04";
			sql+=" from "+user+".bieu_092";
			sql+=" where "+m.for_ngay("ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by ma,ten order by ma";
			ds=m.get_data(sql);
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_092.rpt",title.ToUpper(),1);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_092.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_101(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.sotien) as sotien";
			sql+=" from "+user+".bieu_101 a,"+user+".dm_101 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["sotien"]=r["sotien"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"sotien>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_101.rpt",title.ToUpper(),1);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_101.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_1021(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.vienphi) as vienphi,sum(a.bhyt) as bhyt";
			sql+=" from "+user+".bieu_1021 a,"+user+".dm_1021 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["vienphi"]=r["vienphi"].ToString();
						dr[0]["bhyt"]=r["bhyt"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"vienphi+bhyt>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_1021.rpt",title.ToUpper(),1);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_1021.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_1022(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.sotien) as sotien";
			sql+=" from "+user+".bieu_1022 a,"+user+".dm_1022 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["sotien"]=r["sotien"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"sotien>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_1022.rpt",title.ToUpper(),1);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_1022.rpt");
					f.ShowDialog(this);
				}
			}
		}
		private void bieu_103(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,";
			sql+="sum(a.c03) as c03,sum(a.c04) as c04,sum(a.c05) as c05,";
			sql+="sum(a.c06) as c06";
			sql+=" from "+user+".bieu_103 a,"+user+".dm_103 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by ma");
				DataRow[] dr;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					dr=ds.Tables[0].Select("ma="+int.Parse(r["ma"].ToString()));
					if (dr!=null)
					{
						dr[0]["c01"]=r["c01"].ToString();
						dr[0]["c02"]=r["c02"].ToString();
						dr[0]["c03"]=r["c03"].ToString();
						dr[0]["c04"]=r["c04"].ToString();
						dr[0]["c05"]=r["c05"].ToString();
						dr[0]["c06"]=r["c06"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_103.rpt",title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),"bieu_103.rpt");
					f.ShowDialog(this);
				}
			}
		}
		private void bieu_11(bool prn)
		{
			ds=e.bieu_11(s_tu,s_tu1,s_den,s_table,benhan.Checked,thongke.Checked,phatsinh.Checked);
			string tenfile=(m.Mabv.Substring(0,3)=="701")?"bieu_11_18.rpt":"bieu_11.rpt";
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,tenfile,title.ToUpper(),2);
				else
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,ds,title.ToUpper(),tenfile);
					f.ShowDialog(this);
				}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			print(true);
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			print(false);
		}
        /* -Neu in theo qui
         * s_tu = ngay dau qui(if b.congcong=true) else ngay dau nam
         * s_tu1 = ngay dau nam
         * -Neu in theo thang
         * s_tu1=s_tu
         * */
        private void print(bool prn)
		{
			if (!thongke.Checked && !benhan.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn cách tổng hợp số liệu !"),LibMedi.AccessData.Msg);
				return;
			}
			bPhatsinh=phatsinh.Checked;
			title="Từ ngày : "+tu.Text+" đến ngày : "+den.Text;
			s_tu=tu.Text;
			s_tu1=s_tu;
			s_den=den.Text;
			if (loaibc.SelectedIndex==0)
			{
				title="( Báo cáo thống kê "+ky.Text+" năm "+nam.Value.ToString()+" )";
				s_tu="01/01/"+nam.Value.ToString();
				s_tu2="01/10/"+nam.Value.ToString();
				s_den="31/12/"+nam.Value.ToString();
				switch (ky.SelectedIndex)
				{
					case 0:	
						s_tu2="01/01/"+nam.Value.ToString();
						s_den="31/03/"+nam.Value.ToString();
						break;
					case 1:	
						s_tu2="01/04/"+nam.Value.ToString();
						s_den="30/06/"+nam.Value.ToString();
						break;
					case 2:	
						s_tu2="01/07/"+nam.Value.ToString();
						s_den="30/09/"+nam.Value.ToString();
						break;
				}
				s_tu1=s_tu;
				if (m.bCongdon) s_tu=s_tu2;
			}
			switch (i_bieu)
			{
				case 1: bieu_01(prn);
					break;
				case 2: bieu_02(prn);
					break;
				case 3: bieu_031(prn);
					break;
				case 4: bieu_04(prn);
					break;
				case 5: bieu_05(prn);
					break;
				case 6: bieu_06(prn);
					break;
				case 7: bieu_07(prn);
					break;
				case 8: bieu_08(prn);
					break;
				case 91: bieu_091(prn);
					break;
				case 92: bieu_092(prn);
					break;
				case 101: bieu_101(prn);
					break;
				case 1021: bieu_1021(prn);
					break;
				case 1022: bieu_1022(prn);
					break;
				case 103: bieu_103(prn);
					break;
                case 11: 
                    if(chkmau2010.Checked)bieu_111(prn); 
                    else bieu_11(prn);
					break;                
			}
		}

        private void bieu_111(bool prn)
        {
            ds = e.bieu_11_maumoi(s_tu, s_tu1, s_den, s_table, benhan.Checked, thongke.Checked, phatsinh.Checked);
            //string tenfile=(m.Mabv.Substring(0,3)=="701")?"bieu_11_18.rpt":"bieu_11.rpt";
            string tenfile = "bieu_111_18.rpt";
            if (m.getrowbyid(ds.Tables[0], "c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12>0") == null)
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
            else
            {
                if (prn) p.Printer(m, ds, tenfile, title.ToUpper(), 2);
                else
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, ds, title.ToUpper(), tenfile);
                    f.ShowDialog(this);
                }
            }
        }

        private void f_capnhat_db()
        {
            string asql = "alter table " + user + ".bieu_11 add C041 numeric(7) default 0 ";
            m.execute_data(asql, false);
            asql = "alter table " + user + ".bieu_11 add C051 numeric(7) default 0 ";
            m.execute_data(asql, false);
            asql = "alter table " + user + ".bieu_11 add C19 numeric(7) default 0 ";
            m.execute_data(asql, false);
            //
            asql = "alter table " + user + ".dm_11 add C041 numeric(7) default 0 ";
            m.execute_data(asql, false);
            asql = "alter table " + user + ".dm_11 add C051 numeric(7) default 0 ";
            m.execute_data(asql, false);
            asql = "alter table " + user + ".dm_11 add C19 numeric(7) default 0 ";
            m.execute_data(asql, false);
        }
	}
}
