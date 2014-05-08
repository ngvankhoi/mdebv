using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmtkdscls.
	/// </summary>
	public class frmCapstt : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butIN;
		private System.Windows.Forms.Button butKetthuc;
		private string sql,ngaysrv;
        private LibMedi.AccessData m;
        private dllReportM.Print print;
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private string user = "";
        private System.Windows.Forms.Label lbSTT;
        private System.Windows.Forms.Button butCapSTT;
        private System.Windows.Forms.CheckBox chkXem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCapstt(LibMedi.AccessData acc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            m = acc;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapstt));
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIN = new System.Windows.Forms.Button();
            this.lbSTT = new System.Windows.Forms.Label();
            this.butCapSTT = new System.Windows.Forms.Button();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // butKetthuc
            // 
            this.butKetthuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.DarkBlue;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(166, 203);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(84, 25);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "KẾT THÚC";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIN
            // 
            this.butIN.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIN.ForeColor = System.Drawing.Color.DarkBlue;
            this.butIN.Image = ((System.Drawing.Image)(resources.GetObject("butIN.Image")));
            this.butIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIN.Location = new System.Drawing.Point(81, 203);
            this.butIN.Name = "butIN";
            this.butIN.Size = new System.Drawing.Size(84, 25);
            this.butIN.TabIndex = 5;
            this.butIN.Text = "    IN";
            this.butIN.Click += new System.EventHandler(this.butIN_Click);
            // 
            // lbSTT
            // 
            this.lbSTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSTT.AutoSize = true;
            this.lbSTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSTT.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbSTT.Location = new System.Drawing.Point(123, 29);
            this.lbSTT.Name = "lbSTT";
            this.lbSTT.Size = new System.Drawing.Size(84, 91);
            this.lbSTT.TabIndex = 7;
            this.lbSTT.Text = "0";
            this.lbSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butCapSTT
            // 
            this.butCapSTT.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCapSTT.ForeColor = System.Drawing.Color.DarkBlue;
            this.butCapSTT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCapSTT.Location = new System.Drawing.Point(97, 130);
            this.butCapSTT.Name = "butCapSTT";
            this.butCapSTT.Size = new System.Drawing.Size(136, 39);
            this.butCapSTT.TabIndex = 8;
            this.butCapSTT.Text = "LẤY SỐ THỨ TỰ";
            this.butCapSTT.Click += new System.EventHandler(this.butCapSTT_Click);
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(228, 234);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 9;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // frmCapstt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(331, 253);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.butCapSTT);
            this.Controls.Add(this.lbSTT);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIN);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCapstt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấp STT đăng kí khám bệnh";
            this.Load += new System.EventHandler(this.frmSokham_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmSokham_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            print = new dllReportM.Print();
            lbSTT.Text = "0";
            ngaysrv = m.ngayhienhanh_server.Substring(0, 10);
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

        private void butIN_Click(object sender, System.EventArgs e)
        {
            if (lbSTT.Text == "0")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng bấm nút lấy số thứ tự !"));
                butCapSTT.Focus();
                return;
            }
            string asql = "select " + lbSTT.Text + " as stt from dual ";
            DataSet ads = m.get_data(asql);
            ads.WriteXml("..//..//dataxml//capstt.xml");
            if (chkXem.Checked)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(ads, "", "", "capstt.rpt");
                f.ShowDialog(this);
            }
            else
            {
                print.Printer1(m, ads, lbSTT.Text, "capstt.rpt", 0);
            }
            lbSTT.Text = "0";
        }

        private void butCapSTT_Click(object sender, EventArgs e)
        {
            string s_Quay = "DK";
            lbSTT.Text = m.get_capstt(ngaysrv, s_Quay,1).ToString();
            lbSTT.Location = new System.Drawing.Point(this.Width / 2 - (lbSTT.Width / 2),26);
        }
	}
}
