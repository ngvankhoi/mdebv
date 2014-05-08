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
	/// Summary description for frmBiavdt.
	/// </summary>
	public class frmBiavdt : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox benhvien;
		private System.Windows.Forms.TextBox mabv;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox dienthoai;
		private System.Windows.Forms.TextBox noidung;
		private System.Windows.Forms.ComboBox matt;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private AccessData m;
        private DataSet ds = new DataSet();
		private System.Windows.Forms.Button butXem;
        private dllReportM.Print p = new dllReportM.Print();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBiavdt(AccessData acc)
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
        public frmBiavdt()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = new AccessData();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiavdt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.benhvien = new System.Windows.Forms.TextBox();
            this.mabv = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.dienthoai = new System.Windows.Forms.TextBox();
            this.noidung = new System.Windows.Forms.TextBox();
            this.matt = new System.Windows.Forms.ComboBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butXem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bệnh viện :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã BV :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tỉnh/TP :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa chỉ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điện thoại :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nội dung :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhvien
            // 
            this.benhvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhvien.Enabled = false;
            this.benhvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhvien.Location = new System.Drawing.Point(69, 16);
            this.benhvien.Name = "benhvien";
            this.benhvien.Size = new System.Drawing.Size(219, 21);
            this.benhvien.TabIndex = 1;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(69, 41);
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(219, 21);
            this.mabv.TabIndex = 3;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(69, 91);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(219, 21);
            this.diachi.TabIndex = 7;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // dienthoai
            // 
            this.dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienthoai.Location = new System.Drawing.Point(69, 116);
            this.dienthoai.Name = "dienthoai";
            this.dienthoai.Size = new System.Drawing.Size(219, 21);
            this.dienthoai.TabIndex = 9;
            this.dienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dienthoai_KeyDown);
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(69, 141);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(219, 21);
            this.noidung.TabIndex = 11;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noidung_KeyDown);
            // 
            // matt
            // 
            this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matt.Enabled = false;
            this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matt.Location = new System.Drawing.Point(69, 66);
            this.matt.Name = "matt";
            this.matt.Size = new System.Drawing.Size(219, 21);
            this.matt.TabIndex = 5;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(115, 176);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(75, 25);
            this.butIn.TabIndex = 13;
            this.butIn.Text = "&In ";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(190, 176);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(40, 176);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(75, 25);
            this.butXem.TabIndex = 12;
            this.butXem.Text = " &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // frmBiavdt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(304, 221);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.matt);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.dienthoai);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.benhvien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBiavdt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In trang bìa báo cáo";
            this.Load += new System.EventHandler(this.frmBiavdt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBiavdt_Load(object sender, System.EventArgs e)
		{            
			benhvien.Text=m.Tenbv;
			mabv.Text=m.Mabv;
			matt.DisplayMember="TENTT";
			matt.ValueMember="MATT";
			try
			{
				if (mabv.Text.Length>2)
				{
					matt.DataSource=m.get_data("select * from "+m.user+".btdtt e where matt='"+mabv.Text.Substring(0,3)+"'").Tables[0];
					matt.SelectedIndex=0;
				}
			}
			catch{}
			diachi.Text=m.Diachi;
			dienthoai.Text=m.Dienthoai;
			noidung.Text=
lan.Change_language_MessageText("Báo Cáo : ..... Tháng, Năm")+" "+DateTime.Now.Year.ToString();
            ds = m.get_data("select * from " + m.user + ".capid where id=0");
		}

		private void diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				diachi.Text=m.Caps(diachi.Text);
				SendKeys.Send("{Tab}");
			}
		}

		private void dienthoai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				dienthoai.Text=m.Caps(dienthoai.Text);
				SendKeys.Send("{Tab}");
			}
		}

		private void noidung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				noidung.Text=m.Caps(noidung.Text);
				SendKeys.Send("{Tab}");
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			dllReportM.frmReport f = new dllReportM.frmReport(m,ds,"rptBiaTkbv.rpt",benhvien.Text,mabv.Text,matt.Text,diachi.Text,dienthoai.Text,noidung.Text);
			f.ShowDialog(this);			
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			p.Bia(m,"rptBiaTkbv.rpt",benhvien.Text,mabv.Text,matt.Text,diachi.Text,dienthoai.Text,noidung.Text);
		}
	}
}
