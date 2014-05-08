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
	public class rptBieu01 : System.Windows.Forms.Form
	{
        Language lan = new Language();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox loaibc;
		private System.Windows.Forms.ComboBox ky;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker tu;
		private System.Windows.Forms.DateTimePicker den;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
		private DataSet ds=new DataSet();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBieu01(AccessData acc,string title,bool ena)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m=acc;
			this.Text=title;
			checkBox4.Enabled=ena;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptBieu01));
			this.label1 = new System.Windows.Forms.Label();
			this.loaibc = new System.Windows.Forms.ComboBox();
			this.ky = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.DateTimePicker();
			this.den = new System.Windows.Forms.DateTimePicker();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.butIn = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
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
			this.loaibc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loaibc.Items.AddRange(new object[] {
														"Kỳ",
														"Ngày"});
			this.loaibc.Location = new System.Drawing.Point(88, 11);
			this.loaibc.Name = "loaibc";
			this.loaibc.Size = new System.Drawing.Size(80, 21);
			this.loaibc.TabIndex = 1;
			this.loaibc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibc_KeyDown);
			this.loaibc.SelectedIndexChanged += new System.EventHandler(this.loaibc_SelectedIndexChanged);
			// 
			// ky
			// 
			this.ky.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ky.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ky.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ky.Items.AddRange(new object[] {
													"03 tháng",
													"06 tháng",
													"09 tháng",
													"12 tháng"});
			this.ky.Location = new System.Drawing.Point(171, 11);
			this.ky.Name = "ky";
			this.ky.Size = new System.Drawing.Size(141, 21);
			this.ky.TabIndex = 2;
			this.ky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ky_KeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Từ ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(168, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "đến ngày :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tu
			// 
			this.tu.CustomFormat = "dd/MM/yyyy";
			this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.tu.Location = new System.Drawing.Point(88, 35);
			this.tu.Name = "tu";
			this.tu.Size = new System.Drawing.Size(80, 21);
			this.tu.TabIndex = 4;
			// 
			// den
			// 
			this.den.CustomFormat = "dd/MM/yyyy";
			this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.den.Location = new System.Drawing.Point(232, 35);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(80, 21);
			this.den.TabIndex = 6;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(88, 67);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(192, 24);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Tổng hợp theo mẫu báo cáo";
			this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox1_KeyDown);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(88, 91);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(216, 24);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Chỉ xem có mục có số liệu phát sinh";
			this.checkBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox2_KeyDown);
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(88, 115);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(168, 24);
			this.checkBox3.TabIndex = 9;
			this.checkBox3.Text = "Tổng hợp từ biểu thống kê";
			this.checkBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox3_KeyDown);
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(88, 139);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(192, 24);
			this.checkBox4.TabIndex = 10;
			this.checkBox4.Text = "Tổng hợp từ hồ sơ bệnh án";
			this.checkBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox4_KeyDown);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(91, 176);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 11;
			this.butIn.Text = "     &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(171, 176);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 12;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// rptBieu01
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 221);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butKetthuc,
																		  this.butIn,
																		  this.checkBox4,
																		  this.checkBox3,
																		  this.checkBox2,
																		  this.checkBox1,
																		  this.den,
																		  this.tu,
																		  this.label3,
																		  this.label2,
																		  this.ky,
																		  this.loaibc,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "rptBieu01";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bieu01";
			this.Load += new System.EventHandler(this.rptBieu01_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void rptBieu01_Load(object sender, System.EventArgs e)
		{
			loaibc.SelectedIndex=0;
			ky.SelectedIndex=0;
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
			tu.Enabled=!ky.Enabled;
			den.Enabled=tu.Enabled;
			if (loaibc.SelectedIndex==1) ky.SelectedIndex=-1;
			else if (ky.SelectedIndex==-1) ky.SelectedIndex=0;
		}

		private void ky_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void checkBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void checkBox2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void checkBox3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void checkBox4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string sql;
			sql="select a.ma,b.stt,b.ten,sum(a.c01) as c01,sum(a.c02) as c02,sum(a.c03) as c03,sum(a.c04) as c04,";
			sql+="sum(a.c05) as c05,sum(a.c06) as c06,sum(a.c07) as c07,sum(a.c08) as c08,";
			sql+="sum(a.c09) as c09,sum(a.c10) as c10,sum(a.c11) as c11,sum(a.c12) as c12,";
			sql+="sum(a.c13) as c13,sum(a.c14) as c14,sum(a.c15) as c15,sum(a.c16) as c16,";
			sql+="sum(a.c17) as c17,sum(a.c18) as c18,sum(a.c19) as c19,sum(a.c20) as c20,";
			sql+="sum(a.c21) as c21,sum(a.c22) as c22,sum(a.c23) as c23 ";
			sql+=" from bieu_01 a,dm_01 b where a.ma=b.ma group by a.ma,b.stt,b.ten order by a.ma";
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count==0)
				MessageBox.Show("Không có số liệu !",LibMedi.AccessData.Msg);
			else
			{
				string title="";
				title=(loaibc.SelectedIndex==0)?"kỳ : "+ky.Text:"Từ ngày : "+tu.Text+" đến ngày : "+den.Text;
				frmReport f=new frmReport(m,ds,title.ToUpper(),"bieu_01.rpt");
				f.ShowDialog();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
