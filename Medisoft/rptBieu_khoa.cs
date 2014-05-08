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
	public class rptBieukhoa : System.Windows.Forms.Form
	{
        Language lan = new Language();
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
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nam;
		private string s_table,title,s_tu,s_den,s_makp,s_tenkp,sql;
		private System.Windows.Forms.Button butXem;
		private Medisoft.Print p=new Medisoft.Print();
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckedListBox makp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBieukhoa(AccessData acc,string title,string table,string makp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m=acc;
			this.Text=title;
			s_table=table;s_makp=makp;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptBieukhoa));
			this.label1 = new System.Windows.Forms.Label();
			this.loaibc = new System.Windows.Forms.ComboBox();
			this.ky = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tu = new System.Windows.Forms.DateTimePicker();
			this.den = new System.Windows.Forms.DateTimePicker();
			this.butIn = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.nam = new System.Windows.Forms.NumericUpDown();
			this.butXem = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.makp = new System.Windows.Forms.CheckedListBox();
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
			this.loaibc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loaibc.Items.AddRange(new object[] {
														"Kỳ",
														"Ngày"});
			this.loaibc.Location = new System.Drawing.Point(88, 11);
			this.loaibc.Name = "loaibc";
			this.loaibc.Size = new System.Drawing.Size(80, 22);
			this.loaibc.TabIndex = 1;
			this.loaibc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibc_KeyDown);
			this.loaibc.SelectedIndexChanged += new System.EventHandler(this.loaibc_SelectedIndexChanged);
			// 
			// ky
			// 
			this.ky.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ky.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ky.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.tu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.den.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.den.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.den.Location = new System.Drawing.Point(240, 35);
			this.den.Name = "den";
			this.den.Size = new System.Drawing.Size(96, 22);
			this.den.TabIndex = 8;
			this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.den_KeyDown);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(135, 188);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 12;
			this.butIn.Text = "     &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(212, 188);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 13;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
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
			this.nam.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nam.Location = new System.Drawing.Point(284, 11);
			this.nam.Maximum = new System.Decimal(new int[] {
																3000,
																0,
																0,
																0});
			this.nam.Minimum = new System.Decimal(new int[] {
																1997,
																0,
																0,
																0});
			this.nam.Name = "nam";
			this.nam.Size = new System.Drawing.Size(52, 22);
			this.nam.TabIndex = 4;
			this.nam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nam.Value = new System.Decimal(new int[] {
															  2000,
															  0,
															  0,
															  0});
			this.nam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nam_KeyDown);
			// 
			// butXem
			// 
			this.butXem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXem.Image")));
			this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXem.Location = new System.Drawing.Point(58, 188);
			this.butXem.Name = "butXem";
			this.butXem.Size = new System.Drawing.Size(75, 28);
			this.butXem.TabIndex = 11;
			this.butXem.Text = "      &Xem";
			this.butXem.Click += new System.EventHandler(this.butXem_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 59);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Khoa :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makp
			// 
			this.makp.CheckOnClick = true;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(88, 60);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(248, 116);
			this.makp.TabIndex = 10;
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
			// 
			// rptBieukhoa
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 229);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.makp,
																		  this.label5,
																		  this.butXem,
																		  this.ky,
																		  this.nam,
																		  this.label4,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.den,
																		  this.tu,
																		  this.label3,
																		  this.label2,
																		  this.loaibc,
																		  this.label1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "rptBieukhoa";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tình hình phẫu thủ thuật";
			this.Load += new System.EventHandler(this.rptBieukhoa_Load);
			((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void rptBieukhoa_Load(object sender, System.EventArgs e)
		{
			sql="select * from btdkp_bv";
			if (s_makp!="") sql+=" where makp='"+s_makp+"'";
			sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
			makp.DisplayMember="TENKP";
			makp.ValueMember="MAKP";
			makp.DataSource=dtkp;
			makp.Enabled=s_makp=="";
			loaibc.SelectedIndex=0;
			ky.SelectedIndex=0;
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
			this.Close();
		}

		private void bieu_04(bool prn)
		{
			s_makp="";s_tenkp="";
			if (makp.CheckedItems.Count>0)
				for(int i=0;i<makp.Items.Count;i++)
					if (makp.GetItemChecked(i))
					{
						s_makp+=dtkp.Rows[i]["makp"].ToString().Trim()+",";
						s_tenkp+=dtkp.Rows[i]["tenkp"].ToString().Trim()+";";
					}
			s_tenkp=(s_tenkp!="")?s_tenkp.Substring(0,s_tenkp.Length-1):"";
			string tit=(s_tenkp!="")?title+" "+s_tenkp:title;
			ds=e.bieu_04_khoa(s_makp,s_tu,s_den,s_table);
			if (m.getrowbyid(ds.Tables[0],"c01+c02+c03+c04+c05+c06+c07+c08+c09+c10>0")==null)
				MessageBox.Show("Không có số liệu !",LibMedi.AccessData.Msg);
			else
			{
				if (prn) p.Printer(m,ds,"bieu_04.rpt",tit.ToUpper(),2);
				else
				{
					frmReport f=new frmReport(m,ds,tit.ToUpper(),"bieu_04.rpt");
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
			title="Từ ngày : "+tu.Text+" đến ngày : "+den.Text;
			s_tu=tu.Text;
			s_den=den.Text;
			if (loaibc.SelectedIndex==0)
			{
				title="( Báo cáo thống kê "+ky.Text+" năm "+nam.Value.ToString()+" )";
				s_tu="01/01/"+nam.Value.ToString();
				s_den="31/12/"+nam.Value.ToString();
				switch (ky.SelectedIndex)
				{
					case 0:	s_den="31/03/"+nam.Value.ToString();
						break;
					case 1:	s_den="30/06/"+nam.Value.ToString();
						break;
					case 2:	s_den="30/09/"+nam.Value.ToString();
						break;
				}
			}
			bieu_04(prn);
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
