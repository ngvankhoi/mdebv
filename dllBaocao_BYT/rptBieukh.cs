using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi; 

namespace dllBaocao_BYT
{
	/// <summary>
	/// Summary description for rptBieu01.
	/// </summary>
	public class rptBieukh : System.Windows.Forms.Form
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
		private Print p=new Print();
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
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBieukh(AccessData acc,string title,bool ena,string table,int bieu)
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
        public rptBieukh( string title, bool ena, string table, int bieu)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptBieukh));
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
            this.thongke.Location = new System.Drawing.Point(96, 128);
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(168, 24);
            this.thongke.TabIndex = 10;
            this.thongke.Text = "Tổng hợp từ biểu thống kê";
            this.thongke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thongke_KeyDown);
            // 
            // benhan
            // 
            this.benhan.Location = new System.Drawing.Point(96, 152);
            this.benhan.Name = "benhan";
            this.benhan.Size = new System.Drawing.Size(192, 24);
            this.benhan.TabIndex = 11;
            this.benhan.Text = "Tổng hợp từ hồ sơ bệnh án";
            this.benhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhan_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(137, 197);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 11;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(199, 197);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phatsinh);
            this.groupBox1.Controls.Add(this.mau);
            this.groupBox1.Location = new System.Drawing.Point(88, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // phatsinh
            // 
            this.phatsinh.Location = new System.Drawing.Point(8, 40);
            this.phatsinh.Name = "phatsinh";
            this.phatsinh.Size = new System.Drawing.Size(208, 24);
            this.phatsinh.TabIndex = 1;
            this.phatsinh.Text = "Chỉ xem có mục có số liệu phát sinh";
            this.phatsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phatsinh_KeyDown);
            // 
            // mau
            // 
            this.mau.Location = new System.Drawing.Point(8, 15);
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(200, 24);
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
            this.butXem.Size = new System.Drawing.Size(60, 25);
            this.butXem.TabIndex = 10;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // rptBieukh
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
            this.Name = "rptBieukh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bieu01";
            this.Load += new System.EventHandler(this.rptBieukh_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void rptBieukh_Load(object sender, System.EventArgs e)
		{
            user = m.user;
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
			ds=m.get_data("select id from "+user+".khbieu_01 where "+m.for_ngay("ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')"+" order by ngay desc");
			if (ds.Tables[0].Rows.Count!=0)
			{
				decimal l_id=decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
                sql = "select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
                sql += "sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12)as c12,sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16 ";
				sql+=" from "+user+".khbieu_01 a,"+user+".khdm_01 b where a.ma=b.ma and a.id="+l_id;
                sql += " group by a.ma,b.stt,b.ten order by a.ma";
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
                            dr[0]["c01"] = r["c01"].ToString();
                            dr[0]["c02"] = r["c02"].ToString();
                            dr[0]["c03"] = r["c03"].ToString();
                            dr[0]["c04"] = r["c04"].ToString();
                            dr[0]["c05"] = r["c05"].ToString();
                            dr[0]["c06"] = r["c06"].ToString();
                            dr[0]["c07"] = r["c07"].ToString();
                            dr[0]["c08"] = r["c08"].ToString();
                            dr[0]["c09"] = r["c09"].ToString();
                            dr[0]["c10"] = r["c10"].ToString();
                            dr[0]["c11"] = r["c11"].ToString();
                            dr[0]["c12"] = r["c12"].ToString();
                            dr[0]["c13"] = r["c13"].ToString();
                            dr[0]["c14"] = r["c14"].ToString();
                            dr[0]["c15"] = r["c15"].ToString();
                            dr[0]["c16"] = r["c16"].ToString();
						}
					}
				}
				if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16>0")==null)
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				else
				{
					if (prn) p.Printer(m,ds,"khbieu_01.rpt",title.ToUpper(),2);
					else
					{
						frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_01.rpt");
						f.ShowDialog(this);
					}
				}
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void bieu_02(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16";
			sql+=" from "+user+".khbieu_02 a,"+user+".khdm_02 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
						dr[0]["c10"]=r["c10"].ToString();
						dr[0]["c11"]=r["c11"].ToString();
						dr[0]["c12"]=r["c12"].ToString();
						dr[0]["c13"]=r["c13"].ToString();
						dr[0]["c14"]=r["c14"].ToString();
						dr[0]["c15"]=r["c15"].ToString();
						dr[0]["c16"]=r["c16"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_02.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_02.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_03(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
            sql += "sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11 ";
			sql+=" from "+user+".khbieu_031 a,"+user+".khdm_031 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            sql += " group by a.ma,b.stt,b.ten,b.sttt order by b.sttt";
			if (bPhatsinh)	ds=m.get_data(sql);
			else
			{
				ds=m.get_data("select * from "+user+"."+s_table+" order by sttt");
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
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_03.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_03.rpt");
					f.ShowDialog(this);
				}
			}
		}
        #region bieu 032
        private void bieu_032(bool prn)
        {
            sql = "select a.ma as ma ,b.ten,b.stt,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
            sql += "sum(a.c05) as c05";
            sql += " from "+user+".khbieu_032 a,"+user+".khdm_032 b where a.ma=b.ma ";
            sql += " and " + m.for_ngay("a.ngay", "'dd/mm/yyyy'") + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
            sql += " group by a.ma,b.ten,to_number(b.stt),b.stt order by to_number(b.stt)";
            if (bPhatsinh) ds = m.get_data(sql);
            else
            {
                ds = m.get_data("select * from " + user+"."+s_table + " order by to_number(stt)");
                DataRow[] dr;
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    dr = ds.Tables[0].Select("ma='" + r["ma"].ToString() + "'");
                    if (dr != null)
                    {
                        dr[0]["c01"] = r["c01"].ToString();
                        dr[0]["c02"] = r["c02"].ToString();
                        dr[0]["c03"] = r["c03"].ToString();
                        dr[0]["c04"] = r["c04"].ToString();
                        dr[0]["c05"] = r["c05"].ToString();

                    }
                }
            }
            if (m.getrowbyid(ds.Tables[0], "c01+c02+c03+c04+c05>0") == null)
                MessageBox.Show("Không có số liệu !", LibMedi.AccessData.Msg);
            else
            {
                DataRow[] dr1 = ds.Tables[0].Select("stt='0'");
                if (dr1.Length > 0)
                {
                    dr1[0]["stt"] = "A";
                }
                if (prn) p.Printer(m, ds, "khbieu_032.rpt", title.ToUpper(), 2);
                else
                {
                    frmReport f = new frmReport(m, ds, title.ToUpper(), "khbieu_032.rpt");
                    f.ShowDialog(this);
                }
            }
        }
        #endregion
		private void bieu_04(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
            sql += "sum(a.c17) as c17,sum(a.c18) as c18";
			sql+=" from "+user+".khbieu_04 a,"+user+".khdm_04 b where a.ma=b.ma ";
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

					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_04.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_04.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_05(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14";
			sql+=" from "+user+".khbieu_05 a,"+user+".khdm_05 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
						dr[0]["c10"]=r["c10"].ToString();
						dr[0]["c11"]=r["c11"].ToString();
						dr[0]["c12"]=r["c12"].ToString();
						dr[0]["c13"]=r["c13"].ToString();
						dr[0]["c14"]=r["c14"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_05.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_05.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_06(bool prn)
		{
			ds=m.get_data("select id from "+user+".khbieu_06 where "+m.for_ngay("ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')"+" order by ngay desc");
			if (ds.Tables[0].Rows.Count!=0)
			{
				decimal l_id=decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
				sql="select a.ma,b.stt,b.ten,a.c01,a.c02,a.c03,a.c04,";
				sql+="a.c05,a.c06,a.c07,a.c08,a.c09,a.c10";
				sql+=" from "+user+".khbieu_06 a,"+user+".khdm_06 b where a.ma=b.ma and a.id="+l_id;
				sql+=" order by a.ma";
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
							dr[0]["c08"]=r["c08"].ToString();
							dr[0]["c09"]=r["c09"].ToString();
							dr[0]["c10"]=r["c10"].ToString();
						}
					}
				}
				if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10>0")==null)
					MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
				else
				{
					if (prn) p.Printer(m,ds,"khbieu_06.rpt",title.ToUpper(),2);
					else
					{
						frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_06.rpt");
						f.ShowDialog(this);
					}
				}
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void bieu_07(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09";
			sql+=" from "+user+".khbieu_07 a,"+user+".khdm_07 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_07.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_07.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_08(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
            sql += "sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,sum(a.c09) as c09,sum(a.c10) as c10";
			sql+=" from "+user+".khbieu_08 a,"+user+".khdm_08 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten order by a.ma";
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
                        dr[0]["c07"] = r["c07"].ToString();
                        dr[0]["c08"] = r["c08"].ToString();
                        dr[0]["c09"] = r["c09"].ToString();
                        dr[0]["c10"] = r["c10"].ToString();

					}
				}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_08.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_08.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_09(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08";
			sql+=" from "+user+".khbieu_09 a,"+user+".khdm_09 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_09.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_09.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_10(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11";
			sql+=" from "+user+".khbieu_10 a,"+user+".khdm_10 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
						dr[0]["c10"]=r["c10"].ToString();
						dr[0]["c11"]=r["c11"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_10.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_10.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_11(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,";
            sql+="sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23,sum(a.c24) as c24 ";
			sql+=" from "+user+".khbieu_11 a,"+user+".khdm_11 b where a.ma=b.ma ";
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
                        dr[0]["c24"]=r["c24"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+C21+c22+c23+c24>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_11.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_11.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_121(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08";
			sql+=" from "+user+".khbieu_121 a,"+user+".khdm_121 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_121.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_121.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_122(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10 ";
			sql+=" from "+user+".khbieu_122 a,"+user+".khdm_122 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
						dr[0]["c10"]=r["c10"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_122.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_122.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_123(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20";
			sql+=" from "+user+".kh_bieu_123 a,"+user+".kh_dm_123 b where a.ma=b.ma ";
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
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"kh_bieu_123.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"kh_bieu_123.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_124(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,";
			sql+="sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23,sum(a.c24) as c24";
			sql+=" from "+user+".kh_bieu_124 a,"+user+".kh_dm_124 b where a.ma=b.ma ";
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
						dr[0]["c24"]=r["c24"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+c21+c22+c23+c24>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"kh_bieu_124.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"kh_bieu_124.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_131(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.soluong) as soluong,a.ghichu";
			sql+=" from "+user+".khbieu_13 a,"+user+".khdm_13 b where a.ma=b.ma ";
			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
			sql+=" group by a.ma,b.stt,b.ten,a.ghichu order by a.ma";
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
                        dr[0]["soluong"] = r["soluong"].ToString();
                        dr[0]["ghichu"] = r["ghichu"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"soluong>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_13.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_13.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_132(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,";
			sql+="sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23,sum(a.c24) as c24,";
			sql+="sum(a.c25) as c25,sum(a.c26) as c26,sum(a.c27) as c27";
			sql+=" from "+user+".kh_bieu_132 a,"+user+".kh_dm_132 b where a.ma=b.ma ";
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
						dr[0]["c24"]=r["c24"].ToString();
						dr[0]["c25"]=r["c25"].ToString();
						dr[0]["c26"]=r["c26"].ToString();
						dr[0]["c27"]=r["c27"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+c21+c22+c23+c24+c25+c26+c27>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"kh_bieu_132.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"kh_bieu_132.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_133(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,";
			sql+="sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23,sum(a.c24) as c24,";
			sql+="sum(a.c25) as c25,sum(a.c26) as c26,sum(a.c27) as c27,sum(a.c28) as c28,sum(a.c29) as c29,sum(a.c30) as c30";
			sql+=" from "+user+".kh_bieu_133 a,"+user+".kh_dm_133 b where a.ma=b.ma ";
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
						dr[0]["c24"]=r["c24"].ToString();
						dr[0]["c25"]=r["c25"].ToString();
						dr[0]["c26"]=r["c26"].ToString();
						dr[0]["c27"]=r["c27"].ToString();
						dr[0]["c28"]=r["c28"].ToString();
						dr[0]["c29"]=r["c29"].ToString();
						dr[0]["c30"]=r["c30"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+c21+c22+c23+c24+c25+c26+c27+c28+c29+c30>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"kh_bieu_133.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"kh_bieu_133.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_141(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20";
			sql+=" from "+user+".khbieu_141 a,"+user+".khdm_141 b where a.ma=b.ma ";
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
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_141.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_141.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_142(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20";
			//sql+="sum(a.c21) as c21,sum(a.c22) as c22";
			sql+=" from "+user+".khbieu_142 a,"+user+".khdm_142 b where a.ma=b.ma ";
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
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_142.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_142.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_143(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16 ";
			sql+=" from "+user+".khbieu_143 a,"+user+".khdm_143 b where a.ma=b.ma ";
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
						dr[0]["c08"]=r["c08"].ToString();
						dr[0]["c09"]=r["c09"].ToString();
						dr[0]["c10"]=r["c10"].ToString();
						dr[0]["c11"]=r["c11"].ToString();
						dr[0]["c12"]=r["c12"].ToString();
						dr[0]["c13"]=r["c13"].ToString();
						dr[0]["c14"]=r["c14"].ToString();
						dr[0]["c15"]=r["c15"].ToString();
						dr[0]["c16"]=r["c16"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_143.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_143.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_144(bool prn)
		{
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,";
			sql+="sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23,sum(a.c24) as c24,";
			sql+="sum(a.c25) as c25,sum(a.c26) as c26,sum(a.c27) as c27,sum(a.c28) as c28";
			sql+=" from "+user+".kh_bieu_144 a,"+user+".kh_dm_144 b where a.ma=b.ma ";
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
						dr[0]["c24"]=r["c24"].ToString();
						dr[0]["c25"]=r["c25"].ToString();
						dr[0]["c26"]=r["c26"].ToString();
						dr[0]["c27"]=r["c27"].ToString();
						dr[0]["c28"]=r["c28"].ToString();
					}
				}
			}
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20+c21+c22+c23+c24+c25+c26+c27+c28>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"kh_bieu_144.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"kh_bieu_144.rpt");
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_145(bool prn)
		{
			int d01=0,d02=0,d03=0,d04=0,d05=0,d06=0,d07=0,d08=0,d09=0,d10=0;
//			sql="select a.ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03";
//			sql+=" from "+user+".kh_bieu_1452 a,"+user+".kh_dm_1452 b where a.ma=b.ma ";
//			sql+=" and "+m.for_ngay("a.ngay","'dd/mm/yyyy'")+" between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";
//			sql+=" group by a.ma order by a.ma";
//			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
//			{
//				switch (int.Parse(r["ma"].ToString()))
//				{
//					case 1:
//						d01=int.Parse(r["c01"].ToString());
//						d07=int.Parse(r["c02"].ToString());
//						break;
//					case 2:
//						d02=int.Parse(r["c01"].ToString());
//						d08=int.Parse(r["c02"].ToString());
//						break;
//					case 3:
//						d03=int.Parse(r["c01"].ToString());
//						break;
//					case 4:
//						d04=int.Parse(r["c01"].ToString());
//						d09=int.Parse(r["c02"].ToString());
//						d10=int.Parse(r["c03"].ToString());
//						break;
//					case 5:
//						d05=int.Parse(r["c01"].ToString());
//						break;
//					case 6:
//						d06=int.Parse(r["c01"].ToString());
//						break;
//				}
//			}
			ds=e.kh_bieu_145(s_tu,s_tu1,s_den,s_table,benhan.Checked,thongke.Checked,phatsinh.Checked);

			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12+c13+c14+c15+c16+c17+c18+c19+c20>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				DataSet dsxml=new DataSet();
				ds.WriteXml("..//..//..//xml//kh_bieu_145.xml",XmlWriteMode.WriteSchema);
				dsxml.ReadXml("..//..//..//xml//kh_bieu_145.xml");
				if (prn) p.Printer(m,dsxml,"kh_bieu_145.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,dsxml,title.ToUpper(),"kh_bieu_145.rpt",d01,d02,d03,d04,d05,d06,d07,d08,d09,d10);
					f.ShowDialog(this);
				}
			}
		}

		private void bieu_15(bool prn)
		{
			ds=e.khbieu_15(s_tu,s_tu1,s_den,s_table,benhan.Checked,thongke.Checked,phatsinh.Checked,"khbieu_15");
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10+c11+c12>0")==null)
				MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"khbieu_15.rpt",title.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,title.ToUpper(),"khbieu_15.rpt");
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
				case 3: bieu_03(prn);
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
				case 9: bieu_09(prn);
					break;
				case 10: bieu_10(prn);
					break;
				case 11: bieu_11(prn);
					break;
				case 121: bieu_121(prn);
					break;
				case 122: bieu_122(prn);
					break;
				case 123: bieu_123(prn);
					break;
				case 124: bieu_124(prn);
					break;
				case 131: bieu_131(prn);
					break;
				case 132: bieu_132(prn);
					break;
				case 133: bieu_133(prn);
					break;
				case 141: bieu_141(prn);
					break;
				case 142: bieu_142(prn);
					break;
				case 143: bieu_143(prn);
					break;
				case 144: bieu_144(prn);
					break;
				case 145: bieu_145(prn);
					break;
				case 15: bieu_15(prn);
					break;
                case 32: bieu_032(prn);
                    break;
			}
		}
	}
}
