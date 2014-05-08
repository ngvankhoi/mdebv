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
	public class frmBiavkh : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox benhvien;
		private System.Windows.Forms.TextBox mabv;
		private System.Windows.Forms.TextBox noidung;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
        private DataSet ds = new DataSet();
		private AccessData m;
        private dllReportM.Print p = new dllReportM.Print();
		private System.Windows.Forms.Button butXem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBiavkh(AccessData acc)
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
        public frmBiavkh()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiavkh));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.benhvien = new System.Windows.Forms.TextBox();
            this.mabv = new System.Windows.Forms.TextBox();
            this.noidung = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butXem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ủy ban nhân dân :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trung tâm y tế :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(36, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nội dung :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // benhvien
            // 
            this.benhvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhvien.Enabled = false;
            this.benhvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhvien.Location = new System.Drawing.Point(98, 16);
            this.benhvien.Name = "benhvien";
            this.benhvien.Size = new System.Drawing.Size(219, 21);
            this.benhvien.TabIndex = 1;
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(98, 41);
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(219, 21);
            this.mabv.TabIndex = 3;
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(98, 66);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(219, 21);
            this.noidung.TabIndex = 5;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.noidung_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(132, 102);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(75, 25);
            this.butIn.TabIndex = 7;
            this.butIn.Text = "&In ";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(207, 102);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(75, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butXem
            // 
            this.butXem.Image = ((System.Drawing.Image)(resources.GetObject("butXem.Image")));
            this.butXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXem.Location = new System.Drawing.Point(57, 102);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(75, 25);
            this.butXem.TabIndex = 6;
            this.butXem.Text = " &Xem";
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // frmBiavkh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(328, 149);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.benhvien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBiavkh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In trang bìa báo cáo";
            this.Load += new System.EventHandler(this.frmBiavkh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBiavkh_Load(object sender, System.EventArgs e)
		{
			benhvien.Text=m.Syte;
			mabv.Text=m.Tenbv;
			noidung.Text=
lan.Change_language_MessageText("Tháng ....  Năm")+" "+DateTime.Now.Year.ToString();
            ds = m.get_data("select * from " + m.user + ".capid where id=0");
		}

		private void noidung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				noidung.Text=m.Caps(noidung.Text);
				SendKeys.Send("{Tab}");
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			p.Bia(m,"rptBiaTkyt.rpt",benhvien.Text,mabv.Text,noidung.Text,"","","");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butXem_Click(object sender, System.EventArgs e)
		{
			dllReportM.frmReport f = new dllReportM.frmReport(m,ds,"rptBiaTkyt.rpt",benhvien.Text,mabv.Text,noidung.Text,"","","");
			f.ShowDialog(this);
		}
	}
}
