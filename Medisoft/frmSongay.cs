using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSongay.
	/// </summary>
	public class frmSongay : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown songay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		public int i_so;
		public bool b_tatca=false;
		private System.Windows.Forms.CheckBox chkKhoa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSongay(int so,bool tatca)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); 

            i_so=so;
			chkKhoa.Checked=tatca;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSongay));
            this.label1 = new System.Windows.Forms.Label();
            this.songay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.chkKhoa = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songay
            // 
            this.songay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(65, 16);
            this.songay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(56, 23);
            this.songay.TabIndex = 1;
            this.songay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.songay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(122, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "ngày liên tiếp";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(35, 72);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "    Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = global::Medisoft.Properties.Resources.exit1;
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(106, 72);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // chkKhoa
            // 
            this.chkKhoa.Location = new System.Drawing.Point(16, 43);
            this.chkKhoa.Name = "chkKhoa";
            this.chkKhoa.Size = new System.Drawing.Size(184, 24);
            this.chkKhoa.TabIndex = 3;
            this.chkKhoa.Text = "Tất cả người bệnh trong khoa";
            this.chkKhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songay_KeyDown);
            // 
            // frmSongay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(210, 119);
            this.Controls.Add(this.chkKhoa);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.songay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSongay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngày cho thuốc liên tiếp";
            this.Load += new System.EventHandler(this.frmSongay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSongay_Load(object sender, System.EventArgs e)
		{
			songay.Value=i_so;		
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
			b_tatca=chkKhoa.Checked;
			i_so=Convert.ToInt16(songay.Value);
			this.Close();
		}

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			i_so=0;
			b_tatca=false;
			this.Close();
		}

		private void songay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}
	}
}
