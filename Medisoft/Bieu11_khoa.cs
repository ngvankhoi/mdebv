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
	public class Bieu11_khoa : System.Windows.Forms.Form
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
		private DataTable dtkp=new DataTable();
        private dllReportM.Print p = new dllReportM.Print();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton phatsinh;
		private System.Windows.Forms.RadioButton mau;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nam;
		private string s_table,sql,s_tu,s_den,title,s_makp,s_tenkp,s_tu1,s_tu2;
		private bool bPhatsinh;
		private System.Windows.Forms.Button butXem;
		private System.Windows.Forms.CheckedListBox makp;
		private System.Windows.Forms.CheckBox time;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Bieu11_khoa(AccessData acc,string table,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_table = table; s_makp = makp; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bieu11_khoa));
            this.label1 = new System.Windows.Forms.Label();
            this.loaibc = new System.Windows.Forms.ComboBox();
            this.ky = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.DateTimePicker();
            this.den = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phatsinh = new System.Windows.Forms.RadioButton();
            this.mau = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.nam = new System.Windows.Forms.NumericUpDown();
            this.butXem = new System.Windows.Forms.Button();
            this.makp = new System.Windows.Forms.CheckedListBox();
            this.time = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(-2, 11);
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
            this.loaibc.Location = new System.Drawing.Point(76, 11);
            this.loaibc.Name = "loaibc";
            this.loaibc.Size = new System.Drawing.Size(56, 22);
            this.loaibc.TabIndex = 0;
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
            this.ky.Location = new System.Drawing.Point(132, 11);
            this.ky.Name = "ky";
            this.ky.Size = new System.Drawing.Size(79, 22);
            this.ky.TabIndex = 1;
            this.ky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ky_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(-2, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(166, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.CustomFormat = "dd/MM/yyyy";
            this.tu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tu.Location = new System.Drawing.Point(76, 35);
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(92, 22);
            this.tu.TabIndex = 4;
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.CustomFormat = "dd/MM/yyyy";
            this.den.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.den.Location = new System.Drawing.Point(204, 35);
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(92, 22);
            this.den.TabIndex = 6;
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
            // 
            // butIn
            // 
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(148, 162);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 10;
            this.butIn.Text = "      &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(218, 162);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phatsinh);
            this.groupBox1.Controls.Add(this.mau);
            this.groupBox1.Location = new System.Drawing.Point(76, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 72);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // phatsinh
            // 
            this.phatsinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.phatsinh.Location = new System.Drawing.Point(8, 40);
            this.phatsinh.Name = "phatsinh";
            this.phatsinh.Size = new System.Drawing.Size(208, 24);
            this.phatsinh.TabIndex = 1;
            this.phatsinh.Text = "Chỉ xem có mục có số liệu phát sinh";
            this.phatsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phatsinh_KeyDown);
            // 
            // mau
            // 
            this.mau.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mau.Location = new System.Drawing.Point(8, 15);
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(200, 24);
            this.mau.TabIndex = 0;
            this.mau.Text = "Tổng hợp theo mẫu báo cáo";
            this.mau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mau_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(204, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Năm :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nam
            // 
            this.nam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nam.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(244, 11);
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
            // butXem
            // 
            this.butXem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(78, 162);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(70, 25);
            this.butXem.TabIndex = 9;
            this.butXem.Text = "     &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // makp
            // 
            this.makp.CheckOnClick = true;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(304, 8);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(184, 164);
            this.makp.TabIndex = 12;
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // time
            // 
            this.time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.time.Location = new System.Drawing.Point(77, 133);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(219, 16);
            this.time.TabIndex = 106;
            this.time.Text = "checkBox1";
            // 
            // Bieu11_khoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 205);
            this.Controls.Add(this.time);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.tu);
            this.Controls.Add(this.den);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.ky);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loaibc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bieu11_khoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tình hình bệnh tật,tử vong theo khoa";
            this.Load += new System.EventHandler(this.Bieu11_khoa_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Bieu11_khoa_Load(object sender, System.EventArgs e)
		{
			time.Text=
lan.Change_language_MessageText("Giờ báo cáo :")+" "+m.sGiobaocao;
			sql="select * from "+m.user+".btdkp_bv where makp<>'01'";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
			sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
            makp.DataSource = dtkp;
            makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.Enabled=s_makp=="";
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

		private void bieu_11(bool prn)
		{
			ds=e.bieu_11_khoa(s_tu,s_tu1,s_den,s_table,s_makp,phatsinh.Checked,time.Checked);
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

		private void print(bool prn)
		{
			s_makp="'";s_tenkp="";
			if (makp.CheckedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i))
					{
						s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+"','";
						s_tenkp+=dtkp.Rows[i]["tenkp"].ToString().Trim()+";";
					}
            s_makp = (s_makp.Length > 1) ? s_makp.Substring(0, s_makp.Length - 1) : "";
			bPhatsinh=phatsinh.Checked;
			s_tenkp=(s_tenkp!="")?s_tenkp.Substring(0,s_tenkp.Length-1):"";
			title=s_tenkp.ToUpper()+
lan.Change_language_MessageText("( Từ ngày :")+" "+tu.Text+" "+
lan.Change_language_MessageText("đến ngày :")+" "+den.Text+")";
			s_tu=tu.Text;
			s_tu1=s_tu;
			s_den=den.Text;
			if (loaibc.SelectedIndex==0)
			{
                
				title=s_tenkp.ToUpper()+
lan.Change_language_MessageText("( Báo cáo thống kê")+" "+ky.Text+" "+
lan.Change_language_MessageText("năm")+" "+nam.Value.ToString()+" )";
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
			bieu_11(prn);
		}
	}
}
