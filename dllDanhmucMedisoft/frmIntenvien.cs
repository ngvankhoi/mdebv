using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
namespace dllDanhmucMedisoft
{
	/// <summary>
	/// Summary description for frmIntenvien.
	/// </summary>
	public class frmIntenvien : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.ComboBox mahang;
		private System.Windows.Forms.ComboBox matuyen;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.ComboBox maloai;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox mavung;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butIn;
		private AccessData m;
		private DataSet ds=new DataSet();
		private string sql,user;
        private Button butKetthuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIntenvien(AccessData acc)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntenvien));
            this.mahang = new System.Windows.Forms.ComboBox();
            this.matuyen = new System.Windows.Forms.ComboBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.maloai = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mavung = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mahang
            // 
            this.mahang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mahang.Location = new System.Drawing.Point(88, 80);
            this.mahang.Name = "mahang";
            this.mahang.Size = new System.Drawing.Size(160, 21);
            this.mahang.TabIndex = 7;
            this.mahang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mahang_KeyDown);
            // 
            // matuyen
            // 
            this.matuyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matuyen.Location = new System.Drawing.Point(88, 56);
            this.matuyen.Name = "matuyen";
            this.matuyen.Size = new System.Drawing.Size(160, 21);
            this.matuyen.TabIndex = 5;
            this.matuyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matuyen_KeyDown);
            // 
            // matt
            // 
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(88, 32);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(160, 21);
            this.matt.TabIndex = 3;
            this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
            // 
            // maloai
            // 
            this.maloai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maloai.Location = new System.Drawing.Point(88, 104);
            this.maloai.Name = "maloai";
            this.maloai.Size = new System.Drawing.Size(160, 21);
            this.maloai.TabIndex = 9;
            this.maloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maloai_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(40, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Loại :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(40, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hạng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tuyến :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mavung
            // 
            this.mavung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavung.Location = new System.Drawing.Point(88, 8);
            this.mavung.Name = "mavung";
            this.mavung.Size = new System.Drawing.Size(160, 21);
            this.mavung.TabIndex = 1;
            this.mavung.SelectedIndexChanged += new System.EventHandler(this.mavung_SelectedIndexChanged);
            this.mavung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavung_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(48, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Vùng :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tỉnh/thành phố :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(61, 136);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 10;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(131, 136);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmIntenvien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(264, 181);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.mahang);
            this.Controls.Add(this.matuyen);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.maloai);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mavung);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIntenvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục bệnh viện";
            this.Load += new System.EventHandler(this.frmIntenvien_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmIntenvien_Load(object sender, System.EventArgs e)
		{
            user = m.user;
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
			mavung.DisplayMember="TEN";
			mavung.ValueMember="MA";
			mavung.DataSource=m.get_data("select * from "+user+".dmvungbv order by ma").Tables[0];

			matuyen.DisplayMember="TEN";
			matuyen.ValueMember="MA";
            matuyen.DataSource = m.get_data("select * from " + user + ".dmtuyenbv order by ma").Tables[0];

			mahang.DisplayMember="TEN";
			mahang.ValueMember="MA";
            mahang.DataSource = m.get_data("select * from " + user + ".dmhangbv order by ma").Tables[0];

			maloai.DisplayMember="TEN";
			maloai.ValueMember="MA";
            maloai.DataSource = m.get_data("select * from " + user + ".dmloaibv order by ma").Tables[0];

			try
			{
                mavung.SelectedValue = m.get_data("select mavung from " + user + ".btdtt where matt='" + m.Mabv.Substring(0, 3) + "'").Tables[0].Rows[0][0].ToString();
				matt.SelectedValue=m.Mabv.Substring(0,3);
			}
			catch{}
		}

		private void mavung_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				load_tinh();
			}
			catch{}
		}

		private void mavung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void matuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mahang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void maloai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void load_tinh()
		{
            matt.DataSource = m.get_data("select * from " + user + ".btdtt where mavung='" + mavung.SelectedValue.ToString() + "'").Tables[0];
			try
			{
				matt.SelectedValue=m.Mabv.Substring(0,3);
				if (matt.SelectedIndex==-1) matt.SelectedIndex=0;
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			sql="select a.mabv,a.tenbv,b.tentt,c.ten as vung,d.ten as tuyen,e.ten as loai,f.ten as hang";
            sql += " from " + user + ".tenvien a," + user + ".btdtt b," + user + ".dmvungbv c," + user + ".dmtuyenbv d," + user + ".dmloaibv e," + user + ".dmhangbv f";
			sql+=" where a.matinh=b.matt and a.mavung=c.ma and a.matuyen=d.ma and a.maloai=e.ma and a.mahang=f.ma ";
			if (mavung.SelectedIndex!=-1)
				sql+=" and a.mavung='"+mavung.SelectedValue.ToString()+"'";
			if (matt.SelectedIndex!=-1)
				sql+=" and a.matinh='"+matt.SelectedValue.ToString()+"'";
			if (matuyen.SelectedIndex!=-1)
				sql+=" and a.matuyen='"+matuyen.SelectedValue.ToString()+"'";
			if (maloai.SelectedIndex!=-1)
				sql+=" and a.maloai='"+maloai.SelectedValue.ToString()+"'";
			if (mahang.SelectedIndex!=-1)
				sql+=" and a.mahang='"+mahang.SelectedValue.ToString()+"'";
			sql+=" order by a.mabv";
			ds=m.get_data(sql);
			dllReportM.frmReport f=new dllReportM.frmReport(m,ds,this.Text.ToUpper(),"tenvien.rpt");
			f.ShowDialog();
		}
	}
}
