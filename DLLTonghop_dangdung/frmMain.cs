using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DLLBCTonghop
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butVP;
		private System.Windows.Forms.Button butBN;
		private System.Windows.Forms.Button butDuoc;
		private System.Windows.Forms.Button butXN;
		private System.Windows.Forms.Button butCDHA;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butHelp;
		private System.ComponentModel.IContainer components;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			toolTip1.SetToolTip(this,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"<Tên table cần tạo>\")\n\nDLL:\n+ DLLBCTonghop.dll\n+ LibBC.dll");
			toolTip1.SetToolTip(butHelp,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"<Tên table cần tạo>\")\n\nDLL:\n+ DLLBCTonghop.dll\n+ LibBC.dll");
			toolTip1.SetToolTip(butBN,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"bn_treemenu\")");
			toolTip1.SetToolTip(butVP,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"vp_treemenu\")");
			toolTip1.SetToolTip(butDuoc,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"d_treemenu\")");
			toolTip1.SetToolTip(butXN,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"xn_treemenu\")");
			toolTip1.SetToolTip(butCDHA,"DLLBCTonghop.frmQuanlybenhvien af = new DLLBCTonghop.frmQuanlybenhvien(\"cdha_treemenu\")");

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
            this.butVP = new System.Windows.Forms.Button();
            this.butBN = new System.Windows.Forms.Button();
            this.butDuoc = new System.Windows.Forms.Button();
            this.butXN = new System.Windows.Forms.Button();
            this.butCDHA = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butVP
            // 
            this.butVP.Location = new System.Drawing.Point(8, 8);
            this.butVP.Name = "butVP";
            this.butVP.Size = new System.Drawing.Size(216, 23);
            this.butVP.TabIndex = 0;
            this.butVP.Text = "Báo cáo tổng hợp Viện phí";
            this.butVP.Click += new System.EventHandler(this.butVP_Click);
            // 
            // butBN
            // 
            this.butBN.Location = new System.Drawing.Point(8, 31);
            this.butBN.Name = "butBN";
            this.butBN.Size = new System.Drawing.Size(216, 23);
            this.butBN.TabIndex = 1;
            this.butBN.Text = "Báo cáo tổng hợp Bệnh nhân";
            this.butBN.Click += new System.EventHandler(this.butBN_Click);
            // 
            // butDuoc
            // 
            this.butDuoc.Location = new System.Drawing.Point(8, 54);
            this.butDuoc.Name = "butDuoc";
            this.butDuoc.Size = new System.Drawing.Size(216, 23);
            this.butDuoc.TabIndex = 2;
            this.butDuoc.Text = "Báocáo tổng hợp Dược";
            this.butDuoc.Click += new System.EventHandler(this.butDuoc_Click);
            // 
            // butXN
            // 
            this.butXN.Location = new System.Drawing.Point(8, 77);
            this.butXN.Name = "butXN";
            this.butXN.Size = new System.Drawing.Size(216, 23);
            this.butXN.TabIndex = 3;
            this.butXN.Text = "Báocáo tổng hợp Xét nghiệm";
            this.butXN.Click += new System.EventHandler(this.butXN_Click);
            // 
            // butCDHA
            // 
            this.butCDHA.Location = new System.Drawing.Point(8, 100);
            this.butCDHA.Name = "butCDHA";
            this.butCDHA.Size = new System.Drawing.Size(216, 23);
            this.butCDHA.TabIndex = 4;
            this.butCDHA.Text = "Báocáo tổng hợp CĐHA";
            this.butCDHA.Click += new System.EventHandler(this.butCDHA_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(8, 123);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(216, 23);
            this.butKetthuc.TabIndex = 5;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHelp
            // 
            this.butHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butHelp.ForeColor = System.Drawing.Color.Blue;
            this.butHelp.Location = new System.Drawing.Point(8, 152);
            this.butHelp.Name = "butHelp";
            this.butHelp.Size = new System.Drawing.Size(216, 23);
            this.butHelp.TabIndex = 6;
            this.butHelp.Text = "Rê chuột vào xem hướng dẫn";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(232, 182);
            this.Controls.Add(this.butHelp);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butCDHA);
            this.Controls.Add(this.butXN);
            this.Controls.Add(this.butDuoc);
            this.Controls.Add(this.butBN);
            this.Controls.Add(this.butVP);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

		}
		#endregion
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butVP_Click(object sender, System.EventArgs e)
		{
			frmQuanlybenhvien af = new frmQuanlybenhvien("vp_treemenu");
			af.ShowInTaskbar=false;
			af.ShowDialog(this);
		}

		private void butBN_Click(object sender, System.EventArgs e)
		{
			frmQuanlybenhvien af = new frmQuanlybenhvien("bn_treemenu");
			af.ShowInTaskbar=false;
			af.ShowDialog(this);
		}

		private void butDuoc_Click(object sender, System.EventArgs e)
		{
			frmQuanlybenhvien af = new frmQuanlybenhvien("d_treemenu");
			af.ShowInTaskbar=false;
			af.ShowDialog(this);
		}

		private void butXN_Click(object sender, System.EventArgs e)
		{
			frmQuanlybenhvien af = new frmQuanlybenhvien("xn_treemenu");
			af.ShowInTaskbar=false;
			af.ShowDialog(this);
		}

		private void butCDHA_Click(object sender, System.EventArgs e)
		{
			frmQuanlybenhvien af = new frmQuanlybenhvien("cdha_treemenu");
			af.ShowInTaskbar=false;
			af.ShowDialog(this);
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
