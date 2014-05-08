using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LibDuoc;
using System.Data;
using System.IO;
namespace Medisoft
{
	/// <summary>
	/// Summary description for frmsongaycholai.
	/// </summary>
	public class frmsongaycholai : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		public decimal i_songay=0;
        public int i_giam = 0, i_lientiep = 0, i_phieusau = 0;
		LibDuoc.AccessData d=new LibDuoc.AccessData();
		DataSet ds=new DataSet();
		//
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.CheckBox chkgiam;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.NumericUpDown songaycholai;
        private CheckBox chkLientiep;
        private CheckBox chkphieusaucung;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmsongaycholai(int lientiep)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            chkLientiep.Checked = lientiep == 1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsongaycholai));
            this.label16 = new System.Windows.Forms.Label();
            this.chkgiam = new System.Windows.Forms.CheckBox();
            this.butOk = new System.Windows.Forms.Button();
            this.songaycholai = new System.Windows.Forms.NumericUpDown();
            this.chkLientiep = new System.Windows.Forms.CheckBox();
            this.chkphieusaucung = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.songaycholai)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(-9, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 23);
            this.label16.TabIndex = 0;
            this.label16.Text = "Số ngày cho lại :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkgiam
            // 
            this.chkgiam.Location = new System.Drawing.Point(83, 36);
            this.chkgiam.Name = "chkgiam";
            this.chkgiam.Size = new System.Drawing.Size(64, 20);
            this.chkgiam.TabIndex = 3;
            this.chkgiam.Text = "Giảm";
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(77, 86);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "    Đồng ý";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // songaycholai
            // 
            this.songaycholai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songaycholai.ForeColor = System.Drawing.Color.Red;
            this.songaycholai.Location = new System.Drawing.Point(83, 12);
            this.songaycholai.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.songaycholai.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.songaycholai.Name = "songaycholai";
            this.songaycholai.Size = new System.Drawing.Size(40, 22);
            this.songaycholai.TabIndex = 1;
            this.songaycholai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.songaycholai.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.songaycholai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.songaycholai_KeyDown);
            // 
            // chkLientiep
            // 
            this.chkLientiep.AutoSize = true;
            this.chkLientiep.Location = new System.Drawing.Point(129, 13);
            this.chkLientiep.Name = "chkLientiep";
            this.chkLientiep.Size = new System.Drawing.Size(66, 17);
            this.chkLientiep.TabIndex = 2;
            this.chkLientiep.Text = "Liên tiếp";
            this.chkLientiep.UseVisualStyleBackColor = true;
            // 
            // chkphieusaucung
            // 
            this.chkphieusaucung.Location = new System.Drawing.Point(20, 59);
            this.chkphieusaucung.Name = "chkphieusaucung";
            this.chkphieusaucung.Size = new System.Drawing.Size(127, 20);
            this.chkphieusaucung.TabIndex = 5;
            this.chkphieusaucung.Text = "Theo phiếu sau cùng";
            // 
            // frmsongaycholai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(198, 123);
            this.Controls.Add(this.chkphieusaucung);
            this.Controls.Add(this.chkLientiep);
            this.Controls.Add(this.songaycholai);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.chkgiam);
            this.Controls.Add(this.label16);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmsongaycholai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số ngày cho lại";
            this.Load += new System.EventHandler(this.frmsongaycholai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.songaycholai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void songaycholai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{				
				try
				{
					i_songay=songaycholai.Value;
					i_giam=chkgiam.Checked?1:0;
				}
				catch{i_songay=1;}
				d.writeXml("d_songaycholai","songay",i_songay.ToString());
				d.writeXml("d_songaycholai","giam",(chkgiam.Checked)?"1":"0");
				this.Close();
			}
		}

		private void frmsongaycholai_Load(object sender, System.EventArgs e)
		{		
	
			ds.ReadXml("..//..//..//xml//d_songaycholai.xml");
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				songaycholai.Value=decimal.Parse(r["songay"].ToString());
				chkgiam.Checked=(r["giam"].ToString()=="0")?false:true;
			}
            
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{			
			try
			{
				i_songay=songaycholai.Value;
				i_giam=chkgiam.Checked?1:0;
                i_phieusau = (chkphieusaucung.Checked) ? 1 : 0;
			}
			catch{i_songay=1;}
            i_lientiep = (chkLientiep.Checked) ? 1 : 0;
			d.writeXml("d_songaycholai","songay",i_songay.ToString());
			d.writeXml("d_songaycholai","giam",(chkgiam.Checked)?"1":"0");
			this.Close();
		}
	}
}
