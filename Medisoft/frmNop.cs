using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
using LibZIP;
using FtpLib;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmExport.
	/// </summary>
	public class frmNop : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butKetthuc;
		private DataSet ds=new DataSet();
		private DataSet ds1=new DataSet();
		private AccessData m;
		private System.Windows.Forms.Button exp;
		private System.Windows.Forms.TextBox ketxuat;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox ky;
		private System.Windows.Forms.NumericUpDown nam;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private Export export=new Export();
		private Zip zip=new Zip();
		private FTP ftp=new FTP();
		private string s_tu,s_den,tenfile,s_tu1,s_tu2,user,stime;
		private int j;
		private decimal l_id;
		private System.Windows.Forms.Button butFtp;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Label bieu02;
		private System.Windows.Forms.Label bieu031;
		private System.Windows.Forms.Label bieu04;
		private System.Windows.Forms.Label bieu11;
		private System.Windows.Forms.CheckBox chkbieu021;
		private System.Windows.Forms.CheckBox chkbieu022;
		private System.Windows.Forms.CheckBox chkbieu0312;
		private System.Windows.Forms.CheckBox chkbieu0311;
		private System.Windows.Forms.CheckBox chkbieu042;
		private System.Windows.Forms.CheckBox chkbieu041;
		private System.Windows.Forms.CheckBox chkbieu112;
		private System.Windows.Forms.CheckBox chkbieu111;
        private FolderBrowserDialog fldBrowser;
		private System.ComponentModel.IContainer components;

		public frmNop(AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNop));
            this.butOk = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.exp = new System.Windows.Forms.Button();
            this.ketxuat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ky = new System.Windows.Forms.ComboBox();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.butFtp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.bieu02 = new System.Windows.Forms.Label();
            this.bieu031 = new System.Windows.Forms.Label();
            this.bieu04 = new System.Windows.Forms.Label();
            this.bieu11 = new System.Windows.Forms.Label();
            this.chkbieu021 = new System.Windows.Forms.CheckBox();
            this.chkbieu022 = new System.Windows.Forms.CheckBox();
            this.chkbieu0312 = new System.Windows.Forms.CheckBox();
            this.chkbieu0311 = new System.Windows.Forms.CheckBox();
            this.chkbieu042 = new System.Windows.Forms.CheckBox();
            this.chkbieu041 = new System.Windows.Forms.CheckBox();
            this.chkbieu112 = new System.Windows.Forms.CheckBox();
            this.chkbieu111 = new System.Windows.Forms.CheckBox();
            this.fldBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(114, 358);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(71, 25);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "Đồng ý";
            this.butOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(263, 358);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 25);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // exp
            // 
            this.exp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exp.Location = new System.Drawing.Point(400, 327);
            this.exp.Name = "exp";
            this.exp.Size = new System.Drawing.Size(24, 23);
            this.exp.TabIndex = 8;
            this.exp.Text = "...";
            this.exp.Click += new System.EventHandler(this.exp_Click);
            // 
            // ketxuat
            // 
            this.ketxuat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketxuat.Enabled = false;
            this.ketxuat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketxuat.Location = new System.Drawing.Point(54, 327);
            this.ketxuat.Name = "ketxuat";
            this.ketxuat.Size = new System.Drawing.Size(344, 23);
            this.ketxuat.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-16, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 26;
            this.label8.Text = "Thư mục :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.ky.Location = new System.Drawing.Point(96, 8);
            this.ky.Name = "ky";
            this.ky.Size = new System.Drawing.Size(168, 22);
            this.ky.TabIndex = 1;
            this.ky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ky_KeyDown);
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nam.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(308, 8);
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
            this.nam.TabIndex = 3;
            this.nam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nam_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kỳ hạn báo cáo :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(267, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.Location = new System.Drawing.Point(8, 115);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(416, 180);
            this.checkedListBox1.TabIndex = 4;
            // 
            // butFtp
            // 
            this.butFtp.Image = ((System.Drawing.Image)(resources.GetObject("butFtp.Image")));
            this.butFtp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butFtp.Location = new System.Drawing.Point(185, 358);
            this.butFtp.Name = "butFtp";
            this.butFtp.Size = new System.Drawing.Size(78, 25);
            this.butFtp.TabIndex = 6;
            this.butFtp.Text = "Gởi File";
            this.butFtp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.butFtp, "Gởi số liệu theo đường FTP");
            this.butFtp.Click += new System.EventHandler(this.butFtp_Click);
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Blue;
            this.lbl.Location = new System.Drawing.Point(8, 300);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(416, 23);
            this.lbl.TabIndex = 28;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bieu02
            // 
            this.bieu02.Location = new System.Drawing.Point(40, 36);
            this.bieu02.Name = "bieu02";
            this.bieu02.Size = new System.Drawing.Size(56, 16);
            this.bieu02.TabIndex = 29;
            this.bieu02.Text = "Biểu 02 :";
            this.bieu02.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bieu031
            // 
            this.bieu031.Location = new System.Drawing.Point(40, 54);
            this.bieu031.Name = "bieu031";
            this.bieu031.Size = new System.Drawing.Size(56, 16);
            this.bieu031.TabIndex = 30;
            this.bieu031.Text = "Biểu 031 :";
            this.bieu031.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bieu04
            // 
            this.bieu04.Location = new System.Drawing.Point(40, 72);
            this.bieu04.Name = "bieu04";
            this.bieu04.Size = new System.Drawing.Size(56, 16);
            this.bieu04.TabIndex = 31;
            this.bieu04.Text = "Biểu 04 :";
            this.bieu04.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bieu11
            // 
            this.bieu11.Location = new System.Drawing.Point(40, 90);
            this.bieu11.Name = "bieu11";
            this.bieu11.Size = new System.Drawing.Size(56, 16);
            this.bieu11.TabIndex = 32;
            this.bieu11.Text = "Biểu 11 :";
            this.bieu11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkbieu021
            // 
            this.chkbieu021.Checked = true;
            this.chkbieu021.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu021.Location = new System.Drawing.Point(96, 36);
            this.chkbieu021.Name = "chkbieu021";
            this.chkbieu021.Size = new System.Drawing.Size(112, 16);
            this.chkbieu021.TabIndex = 33;
            this.chkbieu021.Text = "Biểu thống kê";
            // 
            // chkbieu022
            // 
            this.chkbieu022.Checked = true;
            this.chkbieu022.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu022.Location = new System.Drawing.Point(228, 36);
            this.chkbieu022.Name = "chkbieu022";
            this.chkbieu022.Size = new System.Drawing.Size(112, 16);
            this.chkbieu022.TabIndex = 34;
            this.chkbieu022.Text = "Hồ sơ bệnh án";
            // 
            // chkbieu0312
            // 
            this.chkbieu0312.Checked = true;
            this.chkbieu0312.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu0312.Location = new System.Drawing.Point(228, 55);
            this.chkbieu0312.Name = "chkbieu0312";
            this.chkbieu0312.Size = new System.Drawing.Size(112, 16);
            this.chkbieu0312.TabIndex = 36;
            this.chkbieu0312.Text = "Hồ sơ bệnh án";
            // 
            // chkbieu0311
            // 
            this.chkbieu0311.Checked = true;
            this.chkbieu0311.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu0311.Location = new System.Drawing.Point(96, 55);
            this.chkbieu0311.Name = "chkbieu0311";
            this.chkbieu0311.Size = new System.Drawing.Size(112, 16);
            this.chkbieu0311.TabIndex = 35;
            this.chkbieu0311.Text = "Biểu thống kê";
            // 
            // chkbieu042
            // 
            this.chkbieu042.Checked = true;
            this.chkbieu042.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu042.Location = new System.Drawing.Point(228, 73);
            this.chkbieu042.Name = "chkbieu042";
            this.chkbieu042.Size = new System.Drawing.Size(112, 16);
            this.chkbieu042.TabIndex = 38;
            this.chkbieu042.Text = "Hồ sơ bệnh án";
            // 
            // chkbieu041
            // 
            this.chkbieu041.Checked = true;
            this.chkbieu041.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu041.Location = new System.Drawing.Point(96, 73);
            this.chkbieu041.Name = "chkbieu041";
            this.chkbieu041.Size = new System.Drawing.Size(112, 16);
            this.chkbieu041.TabIndex = 37;
            this.chkbieu041.Text = "Biểu thống kê";
            // 
            // chkbieu112
            // 
            this.chkbieu112.Checked = true;
            this.chkbieu112.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu112.Location = new System.Drawing.Point(228, 92);
            this.chkbieu112.Name = "chkbieu112";
            this.chkbieu112.Size = new System.Drawing.Size(112, 16);
            this.chkbieu112.TabIndex = 40;
            this.chkbieu112.Text = "Hồ sơ bệnh án";
            // 
            // chkbieu111
            // 
            this.chkbieu111.Checked = true;
            this.chkbieu111.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbieu111.Location = new System.Drawing.Point(96, 92);
            this.chkbieu111.Name = "chkbieu111";
            this.chkbieu111.Size = new System.Drawing.Size(112, 16);
            this.chkbieu111.TabIndex = 39;
            this.chkbieu111.Text = "Biểu thống kê";
            // 
            // frmNop
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(432, 397);
            this.Controls.Add(this.chkbieu112);
            this.Controls.Add(this.chkbieu111);
            this.Controls.Add(this.chkbieu042);
            this.Controls.Add(this.chkbieu041);
            this.Controls.Add(this.chkbieu0312);
            this.Controls.Add(this.chkbieu0311);
            this.Controls.Add(this.chkbieu022);
            this.Controls.Add(this.chkbieu021);
            this.Controls.Add(this.bieu11);
            this.Controls.Add(this.bieu04);
            this.Controls.Add(this.bieu031);
            this.Controls.Add(this.bieu02);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.butFtp);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ky);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exp);
            this.Controls.Add(this.ketxuat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết xuất số liệu nộp Sở, Bộ Y Tế";
            this.Load += new System.EventHandler(this.frmNop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void butOk_Click(object sender, System.EventArgs e)
		{
			if (!chkbieu112.Checked && !chkbieu111.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn cách kết xuất số liệu !"),LibMedi.AccessData.Msg);
				chkbieu111.Focus();
				return;
			}
			if (!chkbieu022.Checked && !chkbieu021.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn cách kết xuất số liệu !"),LibMedi.AccessData.Msg);
				chkbieu021.Focus();
				return;
			}
			if (!chkbieu0312.Checked && !chkbieu0311.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn cách kết xuất số liệu !"),LibMedi.AccessData.Msg);
				chkbieu0311.Focus();
				return;
			}
			if (!chkbieu042.Checked && !chkbieu041.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn cách kết xuất số liệu !"),LibMedi.AccessData.Msg);
				chkbieu041.Focus();
				return;
			}
			try
			{
				m.upd_thongso(8,"ten",ketxuat.Text.ToString().Trim());
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
				j=ky.SelectedIndex+1;
				string dir=System.IO.Directory.GetCurrentDirectory()+"//temp";
				string exp=dir+"//"+ky.Text.Substring(0,2)+nam.Value.ToString();
				string sql="";
				string filexuat=dir+"//"+m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+".ZIP";
				string filecopy=ketxuat.Text+"//"+m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+".ZIP";
				if (!Directory.Exists(ketxuat.Text)) Directory.CreateDirectory(ketxuat.Text);
				if (!Directory.Exists(exp)) Directory.CreateDirectory(exp);
				foreach(DataRow r in m.get_data("select * from "+user+".dmnop").Tables[0].Rows)
				{
					tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+r["tenfile"].ToString();
                    lbl.Text = tenfile + ".XML";
                    lbl.Refresh();
					if (r["tenfile"].ToString()=="B1")
					{
						sql="select id from "+user+".bieu_01 where ngay between to_date('"+s_tu+"',"+stime+") and to_date('"+s_den+"',"+stime+")";
						ds1=m.get_data(sql);
						l_id=(ds1.Tables[0].Rows.Count!=0)?decimal.Parse(ds1.Tables[0].Rows[0][0].ToString()):0;
						sql="select b.matk as ma,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,sum(a.c17) as c17,";
						sql+="sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23 from "+user+".bieu_01 a,"+user+".dm_01 b where a.ma=b.ma and a.id="+l_id+" group by b.matk";
					}
					else if (r["tenfile"].ToString()=="KH_B1")
					{
                        sql = "select id from " + user + ".kh_bieu_01 where ngay between to_date('" + s_tu + "'," + stime + ") and to_date('" + s_den + "'," + stime + ")";
						ds1=m.get_data(sql);
						l_id=(ds1.Tables[0].Rows.Count!=0)?decimal.Parse(ds1.Tables[0].Rows[0][0].ToString()):0;
						sql="select ma,c01,c02,c03,c04,c05,c06,c07,c08,c09,c10,c11 from "+user+".kh_bieu_01 where id="+l_id;
					}
					else if (r["tenfile"].ToString()=="KH_B6")
					{
                        sql = "select id from " + user + ".kh_bieu_06 where ngay between to_date('" + s_tu + "'," + stime + ") and to_date('" + s_den + "'," + stime + ")";
						ds1=m.get_data(sql);
						l_id=(ds1.Tables[0].Rows.Count!=0)?decimal.Parse(ds1.Tables[0].Rows[0][0].ToString()):0;
						sql="select ma,c01,c02,c03,c04,c05,c06,c07,c08,c09,c10,c11,c12,c13,c14,c15,c16,c17,c18,c19,c20,c21,c22,c23,c24,c25,c26,c27,c28,c29,c30,c31 from "+user+".kh_bieu_06 where id="+l_id;
					}
					else if (r["tenfile"].ToString()=="KH_B4")
					{
						sql="SELECT MA,SUM(C01) AS C01,SUM(C02) AS C02,SUM(C03) AS C03,SUM(C04) AS C04,SUM(C05) AS C05,SUM(C06) AS C06,SUM(C07) AS C07,SUM(C08) AS C08,SUM(C09) AS C09,SUM(C10) AS C10,SUM(C11) AS C11,SUM(C12) AS C12,SUM(C13) AS C13,SUM(C14) AS C14,SUM(C15) AS C15,SUM(C16) AS C16,SUM(C17) AS C17 FROM "+user+".KH_BIEU_04";
                        sql += " where ngay between to_date('" + s_tu + "'," + stime + ") and to_date('" + s_den + "'," + stime + ")";
						sql+=" group by ma";
					}
					else
					{
                        sql = r["sql"].ToString().Trim().Replace("medibv",user) + " where ngay between to_date('" + s_tu + "'," + stime + ") and to_date('" + s_den + "'," + stime + ")";
						if (r["tenfile"].ToString().Trim()=="B92")	sql+=" group by ma,ten";
						else sql+=" group by ma";
					}
					if (r["tenfile"].ToString().Substring(0,2)=="KH") tenfile=m.Matuyen(m.Mabv)+m.Maqu.Substring(3,2)+tenfile;
                    ds = m.get_data(sql);
					if (r["tenfile"].ToString()=="B7" && ds.Tables[0].Rows.Count!=0)
					{
                        sql = "select id from " + user + ".bieu_07 where ngay between to_date('" + s_tu + "'," + stime + ") and to_date('" + s_den + "'," + stime + ")";
						ds1=m.get_data(sql);
						l_id=(ds1.Tables[0].Rows.Count!=0)?decimal.Parse(ds1.Tables[0].Rows[0][0].ToString()):0;
						DataRow r1;
						sql="select ma,soluong from "+user+".bieu_07 where ma in (21,22,23,24) and id="+l_id;
						foreach(DataRow r2 in m.get_data(sql).Tables[0].Rows)
						{
							r1=m.getrowbyid(ds.Tables[0],"ma="+int.Parse(r2["ma"].ToString()));
							if (r1!=null) r1["soluong"]=r2["soluong"].ToString();
						}
					}
					if (ds.Tables[0].Rows.Count!=0)	ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);
				}
				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"B2";
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				ds=export.bieu_02(s_tu,s_tu1,s_den,"dm_02",chkbieu022.Checked,chkbieu021.Checked,true);
				ds.Tables[0].Columns.Remove("stt");
				ds.Tables[0].Columns.Remove("ten");
				ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"B31";
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				ds=export.bieu_031(s_tu,s_tu1,s_den,"dm_031",chkbieu0312.Checked,chkbieu0311.Checked,true);
				ds.Tables[0].Columns.Remove("stt");
				ds.Tables[0].Columns.Remove("ten");
				ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"B4";
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				ds=export.bieu_04(s_tu,s_tu1,s_den,"dm_04",chkbieu042.Checked,chkbieu041.Checked,true);
				ds.Tables[0].Columns.Remove("stt");
				ds.Tables[0].Columns.Remove("ten");
				ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"B11";
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				ds=export.bieu_11(s_tu,s_tu1,s_den,"dm_11",chkbieu112.Checked,chkbieu111.Checked,true);
				ds.Tables[0].Columns.Remove("stt");
				ds.Tables[0].Columns.Remove("ten");
				ds.Tables[0].Columns.Remove("icd10");
				ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"KH_B1451";
				tenfile=m.Matuyen(m.Mabv)+m.Maqu.Substring(3,2)+tenfile;
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				ds=export.kh_bieu_145(s_tu,s_tu1,s_den,"kh_dm_1451",true,true,true);
				ds.Tables[0].Columns.Remove("stt");
				ds.Tables[0].Columns.Remove("ten");
				ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"KH_B15";
				tenfile=m.Matuyen(m.Mabv)+m.Maqu.Substring(3,2)+tenfile;
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				ds=export.kh_bieu_15(s_tu,s_tu1,s_den,"dm_11",chkbieu112.Checked,chkbieu111.Checked,true);
				ds.Tables[0].Columns.Remove("stt");
				ds.Tables[0].Columns.Remove("ten");
				ds.Tables[0].Columns.Remove("icd10");
				ds.WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"DMCOSO";
				tenfile=m.Matuyen(m.Mabv)+m.Maqu.Substring(3,2)+tenfile;
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				m.get_data("select * from "+user+".dmcoso").WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString()+"DMCSSXKD";
				tenfile=m.Matuyen(m.Mabv)+m.Maqu.Substring(3,2)+tenfile;
                lbl.Text = tenfile + ".XML";
                lbl.Refresh();
				m.get_data("select * from "+user+".dmcssxkd").WriteXml(exp+"//"+tenfile+".XML",XmlWriteMode.WriteSchema);

				//exp_hosobenhan();

				zip.AddFiles(filexuat,exp);
				File.Copy(filexuat,filecopy,true);
				File.Delete(filexuat);
				checkedListBox1.Items.Clear();
				string [] files=Directory.GetFiles(ketxuat.Text);//exp
				for(int i=0;i<files.GetLength(0);i++)
				{
					checkedListBox1.Items.Add(files[i].ToString());
					if (files[i].ToString().ToUpper().IndexOf(".ZIP")!=-1)
						checkedListBox1.SetItemCheckState(i,CheckState.Checked);
				}
				zip.DeleteDirectory(exp);
				//Directory.Delete(exp);
				//Directory.Delete(dir);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void exp_hosobenhan()
		{
			tenfile=m.Mabv_so.ToString()+j.ToString()+nam.Value.ToString();
			string dir=System.IO.Directory.GetCurrentDirectory()+"//temp";
			string exp=dir+"//"+ky.Text.Substring(0,2)+nam.Value.ToString();
			//string exp=ketxuat.Text+"//"+ky.Text.Substring(0,2)+nam.Value.ToString();
			string sql="";
			foreach(DataRow r in m.get_data("select * from "+user+".tablehl7").Tables[0].Rows)
			{
				if (r["tenfile"].ToString()=="HL7_ADD")
					sql=r["sql"].ToString().Trim()+" and a.ngay between to_date('"+s_tu2+"',"+stime+") and to_date('"+s_den+"',"+stime+")";
				else
					sql=r["sql"].ToString().Trim()+" and (b.ngay is null or b.ngay between to_date('"+s_tu2+"',"+stime+") and to_date('"+s_den+"',"+stime+"))";
				ds=m.get_data(sql);
				ds.WriteXml(exp+"//"+tenfile+r["tenfile"].ToString()+".XML",XmlWriteMode.WriteSchema);
				lbl.Text=r["tenfile"].ToString()+".XML";
				lbl.Refresh();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void den_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private void exp_Click(object sender, System.EventArgs e)
        {
            //frmThumuc f=new frmThumuc(ketxuat.Text,"Chọn thư mục kết xuất số liệu",0);
            //f.ShowDialog();
            string s_PathCur = System.Environment.CurrentDirectory;
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowNewFolderButton = true;
            fld.ShowDialog();
            //if (f.s_dir != "") 
            ketxuat.Text = fld.SelectedPath;
            System.Environment.CurrentDirectory = s_PathCur;
        }

		private void frmNop_Load(object sender, System.EventArgs e)
		{
            user = m.user; stime = "'" + m.f_ngay + "'";
			ky.SelectedIndex=0;
			nam.Value=DateTime.Now.Year;
			ketxuat.Text=m.get_data("select ten from "+user+".thongso where id=8").Tables[0].Rows[0][0].ToString();
		}

		private void ky_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void nam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butFtp_Click(object sender, System.EventArgs e)
		{
			try
			{
				ftp.setDebug(true);
				ftp.setRemoteHost(m.Host);
				ftp.setRemoteUser(m.User);
				ftp.setRemotePass(m.Pass);
				ftp.login();
				ftp.chdir(m.Dir);
       			ftp.setBinaryMode(true);
				for(int i=0;i<checkedListBox1.Items.Count;i++)
				{
					if (checkedListBox1.GetItemChecked(i))
						ftp.upload(checkedListBox1.Items[i].ToString());
				}
				ftp.close();
				MessageBox.Show(lan.Change_language_MessageText("Đã hoàn thành !"),LibMedi.AccessData.Msg);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message,LibMedi.AccessData.Msg);
			}
		}
	}
}
